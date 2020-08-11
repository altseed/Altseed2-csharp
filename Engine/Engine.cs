using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed2
{
    /// <summary>
    /// Altseed2 のエンジンを表します。
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// カメラグループの個数の最大値
        /// </summary>
        internal const int MaxCameraGroupCount = 64;

        /// <summary>
        /// ルートノード
        /// </summary>
        private static RootNode _RootNode;

        /// <summary>
        /// 実際のUpdate対象のノード
        /// </summary>
        /// <remarks>Pause中は一部のノードのみが更新対象になる。</remarks>
        private static Node _UpdatedNode;

        /// <summary>
        /// ポーズ中か否かによらず更新対象となる<see cref="Node"/>部分木の根を取得します。
        /// </summary>
        internal static Node UpdatedTreeRoot => _UpdatedNode;

        private static CameraNodeCollection _CameraNodes;
        private static RenderedCamera _DefaultCamera;
        private static DrawnCollection _DrawnCollection;

        private static RenderTextureCache _RenderTextureCache;
        internal static RenderTexture _PostEffectBuffer; // TODO: 渡し方をうまくやる。

        /// <summary>
        /// スクリーンのクリア色を取得または設定します。
        /// </summary>
        public static Color ClearColor
        {
            get => _ClearColor;
            set
            {
                if (_ClearColor == value) return;
                _ClearColor = value;
                _DefaultCamera.RenderPassParameter = new RenderPassParameter(value, true, true);
            }
        }
        private static Color _ClearColor = new Color(50, 50, 50, 255);

        /// <summary>
        /// エンジンを初期化します。
        /// </summary>
        /// <param name="title">ウィンドウタイトル</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">設定</param>
        /// <returns>初期化に成功したらtrue、それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            Config = (config ??= new Configuration());
            if (Core.Initialize(title, width, height, config))
            {
                _core = Core.GetInstance();
                _log = Log.GetInstance();

                _keyboard = Keyboard.GetInstance();
                _mouse = Mouse.GetInstance();
                _joystick = Joystick.GetInstance();

                _file = File.GetInstance();
                _resources = Resources.GetInstance();

                _window = Window.GetInstance();
                _graphics = Graphics.GetInstance();
                _renderer = Renderer.GetInstance();
                _cullingSystem = CullingSystem.GetInstance();

                Context = new AltseedContext();
                System.Threading.SynchronizationContext.SetSynchronizationContext(Context);

                if (config.ToolEnabled) _tool = Tool.GetInstance();

                _sound = SoundMixer.GetInstance();

                _RootNode = new RootNode();
                _UpdatedNode = _RootNode;

                _DrawnCollection = new DrawnCollection();
                _CameraNodes = new CameraNodeCollection();

                _RenderTextureCache = new RenderTextureCache();

                PostEffectNode.InitializeCache();

                isActive = true;

                _DefaultCamera = RenderedCamera.Create();
                _DefaultCamera.ViewMatrix = Matrix44F.GetTranslation2D(-WindowSize / 2);
                _DefaultCamera.RenderPassParameter = new RenderPassParameter(ClearColor, true, true);

                return true;
            }
            return false;
        }

        /// <summary>
        /// システムイベントを処理します。
        /// </summary>
        public static bool DoEvents()
        {
            Graphics.DoEvents();
            if (!Core.GetInstance().DoEvent()) return false;

            if (Config.ToolEnabled)
            {
                //ツール機能を使用するときはDoEventsでフレームを開始
                //使用しないときはUpdateでフレームを開始
                if (!Graphics.BeginFrame(new RenderPassParameter(ClearColor, true, true))) return false;
                Tool.NewFrame();
            }

            return true;
        }

        /// <summary>
        /// エンジンを更新します。
        /// </summary>
        public static bool Update()
        {
            // ノードの更新
            _UpdatedNode?.Update();

            // Contextの更新
            Context.Update();

            // カリング用AABBの更新
            CullingSystem.UpdateAABB();

            // (ツール機能を使用しない場合は)描画を開始
            if (!Config.ToolEnabled)
            {
                //ツール機能を使用するときはDoEventsでフレームを開始
                //使用しないときはUpdateでフレームを開始
                if (!Graphics.BeginFrame(new RenderPassParameter(ClearColor, true, true))) return false;
            }

            if (_CameraNodes.Count == 0)
            {
                // カメラが 1 つもない場合はデフォルトカメラを使用
                DrawCameraGroup(_DefaultCamera, _DrawnCollection.GetDrawns());
            }
            else
            {
                // 特定のカメラに映りこむノードを描画
                for (int i = 0; i < MaxCameraGroupCount; i++)
                {
                    foreach (var camera in _CameraNodes[i])
                    {
                        DrawCameraGroup(camera.RenderedCamera, _DrawnCollection[i]);
                    }
                }
            }

            _RenderTextureCache.Update();
            PostEffectNode.UpdateCache();

            // （ツール機能を使用する場合は）ツールを描画
            if (Config.ToolEnabled)
            {
                Tool.Render();
            }

            // 描画を終了
            if (!Graphics.EndFrame()) return false;
            return true;
        }

        private static void DrawCameraGroup(RenderedCamera camera, SortedDictionary<int, HashSet<IDrawn>> drawns)
        {
            Renderer.SetCamera(camera);

            // カリングの結果
            var cullingIds = CullingSystem.DrawingRenderedIds.ToArray();
            Array.Sort(cullingIds);

            _PostEffectBuffer = null;
            var requireRender = false;

            foreach (var (_, znodes) in drawns)
            {
                foreach (var node in znodes)
                {
                    if (node is PostEffectNode)
                    {
                        if (requireRender)
                        {
                            Renderer.Render();
                            requireRender = false;
                        }

                        _PostEffectBuffer ??= _RenderTextureCache.GetRenderTexture(Graphics.CommandList.GetScreenTexture().Size, Graphics.CommandList.ScreenTextureFormat);

                        Graphics.CommandList.CopyTexture(Graphics.CommandList.GetScreenTexture(), _PostEffectBuffer);
                        node.Draw();
                    }
                    else if (node is ICullableDrawn cdrawn)
                    {
                        if (!cdrawn.IsDrawnActually) continue;
                        // NOTE: WhereIterator を生成させないために foreach (var node in nodes.Where(n => n.IsDrawnActually)) などとしない

                        if (Array.BinarySearch(cullingIds, cdrawn.CullingId) < 0) continue;

                        node.Draw();
                        //if (node is TransformNode t)
                        //    t.DrawTransformInfo();
                        requireRender = true;
                    }
                    else throw new InvalidOperationException();
                }
            }
            if (requireRender) Renderer.Render();
        }

        /// <summary>
        /// エンジンを終了します。
        /// </summary>
        public static void Terminate()
        {
            // RootNode直下のNodeをEngineからRemove(CullingSystemから削除するため)
            _RootNode._Children.Clear();

            _RenderTextureCache = null;
            PostEffectNode.TerminateCache();
            Core.Terminate();
            isActive = false;
        }

        /// <summary>
        /// ノードの更新を一時停止します。
        /// </summary>
        /// <param name="keepUpdated">一時停止の対象から除外するノード</param>
        public static void Pause(Node keepUpdated = null)
        {
            _UpdatedNode = keepUpdated;
        }

        /// <summary>
        /// ノードの更新を再開します。
        /// </summary>
        public static void Resume()
        {
            _UpdatedNode = _RootNode;
        }

        #region Modules
        private static bool isActive;

        internal static Core Core => isActive ? _core : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Core _core;

        /// <summary>
        /// ファイルを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static File File => isActive ? _file : throw new InvalidOperationException("現在その操作は許可されていません");
        private static File _file;

        /// <summary>
        /// キーボードを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Keyboard Keyboard => isActive ? _keyboard : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Keyboard _keyboard;

        /// <summary>
        /// マウスを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Mouse Mouse => isActive ? _mouse : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Mouse _mouse;

        /// <summary>
        /// ジョイスティックを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Joystick Joystick => isActive ? _joystick : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Joystick _joystick;

        /// <summary>
        /// グラフィックのクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Graphics Graphics => isActive ? _graphics : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Graphics _graphics;

        /// <summary>
        /// ログを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Log Log => isActive ? _log : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Log _log;

        /// <summary>
        /// レンダラのクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        internal static Renderer Renderer => isActive ? _renderer : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Renderer _renderer;

        /// <summary>
        /// カリングのクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        internal static CullingSystem CullingSystem => isActive ? _cullingSystem : throw new InvalidOperationException("現在その操作は許可されていません");
        private static CullingSystem _cullingSystem;

        /// <summary>
        /// 音を管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static SoundMixer Sound => isActive ? _sound : throw new InvalidOperationException("現在その操作は許可されていません");
        private static SoundMixer _sound;

        /// <summary>
        /// リソースを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        internal static Resources Resources => isActive ? _resources : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Resources _resources;

        /// <summary>
        /// ウインドウを表すクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        internal static Window Window => isActive ? _window : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Window _window;

        /// <summary>
        /// ツールを管理するクラスを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">エンジンが初期されていなかったり終了していて操作を実行できなかった</exception>
        public static Tool Tool => isActive ? _tool : throw new InvalidOperationException("現在その操作は許可されていません");
        private static Tool _tool;

        #endregion

        #region Node

        /// <summary>
        /// エンジンに登録されているノードの列挙子を返します。
        /// </summary>
        public static IEnumerable<Node> GetNodes() => _RootNode.Children;

        /// <summary>
        /// エンジンにノードを追加します。
        /// </summary>
        /// <param name="node">追加されるノード</param>
        public static void AddNode(Node node)
        {
            _RootNode.AddChildNode(node);
        }

        /// <summary>
        /// エンジンからノードを削除します。
        /// </summary>
        /// <param name="node">削除するノード</param>
        public static void RemoveNode(Node node)
        {
            _RootNode.RemoveChildNode(node);
        }

        /// <summary>
        /// エンジンに登録されている <typeparamref name="T"/> 型のノードを列挙します。
        /// </summary>
        /// <typeparam name="T">検索するノードの型</typeparam>
        public static IEnumerable<T> FindNodes<T>() where T : Node
            => _RootNode.EnumerateDescendants<T>();

        /// <summary>
        /// エンジンに登録されている <typeparamref name="T"/> 型のノードのうち <paramref name="condition"/> を満たすものを列挙します。
        /// </summary>
        /// <typeparam name="T">検索するノードの型</typeparam>
        /// <param name="condition">検索するノードの条件</param>
        /// <exception cref="ArgumentNullException"><paramref name="condition"/>がnull</exception>
        public static IEnumerable<T> FindNodes<T>(Func<T, bool> condition) where T : Node
                => _RootNode.EnumerateDescendants(condition);

        internal static void RegisterDrawn(IDrawn node)
        {
            _DrawnCollection.Register(node);
        }

        internal static void UnregisterDrawn(IDrawn node)
        {
            _DrawnCollection.Unregister(node);
        }

        internal static void UpdateDrawnCameraGroup(IDrawn node, ulong old)
        {
            _DrawnCollection.UpdateCameraGroup(node, old);
        }

        internal static void UpdateDrawnZOrder(IDrawn node, int old)
        {
            _DrawnCollection.UpdateZOrder(node, old);
        }

        #endregion

        #region CameraNodeCollection

        internal static void RegisterCameraNode(CameraNode camera)
        {
            _CameraNodes.AddCamera(camera);
        }

        internal static void UnregisterCameraNode(CameraNode camera)
        {
            _CameraNodes.RemoveCamera(camera);
        }

        internal static void UpdateCameraNodeGroup(CameraNode camera, int oldGroup)
        {
            _CameraNodes.UpdateGroup(camera, oldGroup);
        }

        #endregion

        /// <summary>
        /// <see cref="System.Threading.SynchronizationContext"/>を取得します。
        /// </summary>
        internal static AltseedContext Context { get; private set; }

        /// <summary>
        /// ウィンドウのサイズを取得または設定します。
        /// </summary>
        public static Vector2I WindowSize
        {
            get => Window.Size;
            set
            {
                Window.Size = value;
                _DefaultCamera.ViewMatrix = Matrix44F.GetTranslation2D(-value / 2);
            }
        }

        internal static Configuration Config { get; private set; }

        /// <summary>
        /// ウインドウのタイトルを取得または設定します。
        /// </summary>
        public static string WindowTitle
        {
            get => Window.Title;
            set
            {
                Window.Title = value;
            }
        }

        #region FPS制御

        /// <summary>
        /// フレームレートの制御方法を取得または設定します。
        /// </summary>
        public static FramerateMode FramerateMode
        {
            get => Core.FramerateMode;
            set { Core.FramerateMode = value; }
        }

        /// <summary>
        /// 目標フレームレートを取得または設定します。
        /// </summary>
        public static float TargetFPS
        {
            get => Core.TargetFPS;
            set { Core.TargetFPS = value; }
        }

        /// <summary>
        /// 現在のFPSを取得します。
        /// </summary>
        public static float CurrentFPS => Core.CurrentFPS;

        /// <summary>
        /// 前のフレームからの経過時間(秒)を取得します。
        /// </summary>
        public static float DeltaSecond => Core.DeltaSecond;

        #endregion
    }
}
