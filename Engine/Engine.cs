using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed
{
    /// <summary>
    /// Altseed2 のエンジンを表します。
    /// </summary>
    public static class Engine
    {
        private static Configuration _Config;

        /// <summary>
        /// ルートノード
        /// </summary>
        private static RootNode _RootNode;

        /// <summary>
        /// 実際のUpdate対象のノード
        /// </summary>
        /// <remarks>Pause中は一部のノードのみが更新対象になる。</remarks>
        private static Node _UpdatedNode;

        private static DrawnNodeCollection _DrawnNodes;
        private static PostEffectNodeCollection _PostEffectNodes;
        private static CameraNodeCollection _CameraNodes;
        private static RenderedCamera _DefaultCamera;

        private static RenderTextureCache _RenderTextureCache;

        public static Color ClearColor { get; set; } = new Color(50, 50, 50, 255);

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
            _Config = (config ??= new Configuration());
            if (Core.Initialize(title, width, height, config))
            {
                Core = Core.GetInstance();
                Log = Log.GetInstance();

                Keyboard = Keyboard.GetInstance();
                Mouse = Mouse.GetInstance();
                Joystick = Joystick.GetInstance();

                File = File.GetInstance();
                Resources = Resources.GetInstance();

                Window = Window.GetInstance();
                Graphics = Graphics.GetInstance();
                Renderer = Renderer.GetInstance();
                CullingSystem = CullingSystem.GetInstance();

                Context = new AltseedContext();
                System.Threading.SynchronizationContext.SetSynchronizationContext(Context);

                if (config.ToolEnabled) Tool = Tool.GetInstance();

                Sound = SoundMixer.GetInstance();

                _RootNode = new RootNode();
                _UpdatedNode = _RootNode;

                _DrawnNodes = new DrawnNodeCollection();
                _PostEffectNodes = new PostEffectNodeCollection();
                _CameraNodes = new CameraNodeCollection();
                _DefaultCamera = RenderedCamera.Create();
                _DefaultCamera.RenderPassParameter = new RenderPassParameter(new Color(50, 50, 50, 255), true, true);

                _RenderTextureCache = new RenderTextureCache();

                PostEffectNode.InitializeCache();

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

            if (_Config.ToolEnabled)
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

            foreach (var node in _DrawnNodes.Nodes.SelectMany(obj => obj.Value))
            {
                // DrawnNodeのSizeを更新
                node.UpdateSize();
                // RenderedにTransform反映
                node.UpdateInheritedTransform();
            }

            // カリング用AABBの更新
            CullingSystem.UpdateAABB();

            // (ツール機能を使用しない場合は)描画を開始
            if (!_Config.ToolEnabled)
            {
                //ツール機能を使用するときはDoEventsでフレームを開始
                //使用しないときはUpdateでフレームを開始
                if (!Graphics.BeginFrame(new RenderPassParameter(ClearColor, true, true))) return false;
            }

            if (_CameraNodes.Count == 0)
            {
                // カメラが 1 つもない場合はデフォルトカメラを使用
                Renderer.SetCamera(_DefaultCamera);

                {
                    var cullingIds = CullingSystem.DrawingRenderedIds.ToArray();

                    var list = _DrawnNodes.Nodes;
                    foreach (var z in list.Keys.OrderBy(x => x))
                    {
                        var nodes = list[z];
                        foreach (var node in cullingIds.Join(nodes, id => id, n => n.CullingId, (id, n) => n))
                            node.Draw();
                    }

                    Renderer.Render();
                }

                {
                    var list = _PostEffectNodes.Nodes;

                    RenderTexture buffer = null;

                    foreach (var z in list.Keys.OrderBy(x => x))
                    {
                        foreach (var node in list[z])
                        {
                            if (buffer is null)
                            {
                                buffer = _RenderTextureCache.GetRenderTexture(Graphics.CommandList.GetScreenTexture().Size);
                            }

                            Graphics.CommandList.CopyTexture(Graphics.CommandList.GetScreenTexture(), buffer);
                            node.CallDraw(buffer);
                        }
                    }
                }
            }
            else
            {
                // 特定のカメラに映りこむノードを描画
                for (int i = 0; i <= 31; i++)
                {
                    foreach (var camera in _CameraNodes[i])
                    {
                        Renderer.SetCamera(camera.RenderedCamera);

                        {
                            var cullingIds = CullingSystem.DrawingRenderedIds.ToArray();

                            var list = _DrawnNodes[i];
                            foreach (var z in list.Keys.OrderBy(x => x))
                            {
                                var nodes = list[z];
                                foreach (var node in cullingIds.Join(nodes, id => id, n => n.CullingId, (id, n) => n))
                                    node.Draw();
                            }

                            Renderer.Render();
                        }

                        {
                            var list = _PostEffectNodes[i];

                            var target = camera.TargetTexture ?? Graphics.CommandList.GetScreenTexture();
                            RenderTexture buffer = null;

                            foreach (var z in list.Keys.OrderBy(x => x))
                            {
                                foreach (var node in list[z])
                                {
                                    if (buffer is null)
                                    {
                                        buffer = _RenderTextureCache.GetRenderTexture(target.Size);
                                    }

                                    Graphics.CommandList.CopyTexture(target, buffer);
                                    node.CallDraw(buffer);
                                }
                            }
                        }
                    }
                }
            }

            _RenderTextureCache.Update();
            PostEffectNode.UpdateCache();

            // （ツール機能を使用する場合は）ツールを描画
            if (_Config.ToolEnabled)
            {
                Tool.Render();
            }

            // 描画を終了
            if (!Graphics.EndFrame()) return false;
            return true;
        }

        /// <summary>
        /// エンジンを終了します。
        /// </summary>
        public static void Terminate()
        {
            Core.Terminate();
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

        internal static Core Core { get; private set; }

        /// <summary>
        /// ファイルを管理するクラスを取得します。
        /// </summary>
        public static File File { get; private set; }

        /// <summary>
        /// キーボードを管理するクラスを取得します。
        /// </summary>
        public static Keyboard Keyboard { get; private set; }

        /// <summary>
        /// マウスを管理するクラスを取得します。
        /// </summary>
        public static Mouse Mouse { get; private set; }

        /// <summary>
        /// ジョイスティックを管理するクラスを取得します。
        /// </summary>
        public static Joystick Joystick { get; private set; }

        /// <summary>
        /// グラフィックのクラスを取得します。
        /// </summary>
        internal static Graphics Graphics { get; private set; }

        /// <summary>
        /// ログを管理するクラスを取得します。
        /// </summary>
        public static Log Log { get; private set; }

        /// <summary>
        /// レンダラのクラスを取得します。
        /// </summary>
        internal static Renderer Renderer { get; private set; }

        /// <summary>
        /// カリングのクラスを取得します。
        /// </summary>
        internal static CullingSystem CullingSystem { get; private set; }

        /// <summary>
        /// 音を管理するクラスを取得します。
        /// </summary>
        public static SoundMixer Sound { get; private set; }

        /// <summary>
        /// リソースを管理するクラスを取得します。
        /// </summary>
        internal static Resources Resources { get; private set; }

        /// <summary>
        /// ウインドウを表すクラスを取得します。
        /// </summary>
        internal static Window Window { get; private set; }

        /// <summary>
        /// ツールを管理するクラスを取得します。
        /// </summary>
        public static Tool Tool { get; private set; }

        #endregion

        #region Node

        /// <summary>
        /// エンジンに登録されているノードの列挙子を返します。
        /// </summary>
        public static IEnumerable<Node> GetNodes() => _RootNode.Children;

        /// <summary>
        /// エンジンにノードを追加します。
        /// </summary>
        public static void AddNode(Node node)
        {
            _RootNode.AddChildNode(node);
        }

        /// <summary>
        /// エンジンからノードを削除します。
        /// </summary>
        public static void RemoveNode(Node node)
        {
            _RootNode.RemoveChildNode(node);
        }

        /// <summary>
        /// エンジンに登録されている <typeparamref name="T"/> 型のノードを列挙します。
        /// </summary>
        public static IEnumerable<T> FindNodes<T>() where T : Node
            => _RootNode.EnumerateDescendants<T>();

        /// <summary>
        /// エンジンに登録されている <typeparamref name="T"/> 型のノードのうち <paramref name="condition"/> を満たすものを列挙します。
        /// </summary>
        public static IEnumerable<T> FindNodes<T>(Func<T, bool> condition) where T : Node
                => _RootNode.EnumerateDescendants<T>(condition);

        #endregion

        #region DrawnNodeCollection

        internal static void RegisterDrawnNode(DrawnNode node)
        {
            _DrawnNodes.AddNode(node);
        }

        internal static void UnregisterDrawnNode(DrawnNode node)
        {
            _DrawnNodes.RemoveNode(node);
        }

        internal static void UpdateDrawnNodeCameraGroup(DrawnNode node, uint oldCameraGroup)
        {
            _DrawnNodes.UpdateCameraGroup(node, oldCameraGroup);
        }

        internal static void UpdateDrawnNodeZOrder(DrawnNode node, int oldZOrder)
        {
            _DrawnNodes.UpdateOrder(node, oldZOrder);
        }

        #endregion

        #region PostEffectNodeCollection

        internal static void RegisterPostEffectNode(PostEffectNode node)
        {
            _PostEffectNodes.AddNode(node);
        }

        internal static void UnregisterPostEffectNode(PostEffectNode node)
        {
            _PostEffectNodes.RemoveNode(node);
        }

        internal static void UpdatePostEffectNodeCameraGroup(PostEffectNode node, uint oldCameraGroup)
        {
            _PostEffectNodes.UpdateCameraGroup(node, oldCameraGroup);
        }

        internal static void UpdatePostEffectNodeOrder(PostEffectNode node, int oldOrder)
        {
            _PostEffectNodes.UpdateOrder(node, oldOrder);
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
        /// ウィンドウのサイズを取得する
        /// </summary>
        public static Vector2I WindowSize => Window.Size;

        /// <summary>
        /// ウインドウのタイトルを取得または設定します。
        /// </summary>
        public static string WindowTitle
        {
            get => Window.Title;
            set { Window.Title = value; }
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
