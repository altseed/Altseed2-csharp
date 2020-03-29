using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private static CameraNodeCollection _CameraNodes;
        private static RenderedCamera _DefaultCamera;

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
            _Config = config ?? new Configuration();
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

                if (config.ToolEnabled) Tool = Tool.GetInstance();

                Sound = SoundMixer.GetInstance();

                _RootNode = new RootNode();
                _UpdatedNode = _RootNode;

                _DrawnNodes = new DrawnNodeCollection();
                _CameraNodes = new CameraNodeCollection();
                _DefaultCamera = RenderedCamera.Create();
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
                if (!Graphics.BeginFrame()) return false;
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

            // (ツール機能を使用しない場合は)描画を開始
            if (!_Config.ToolEnabled)
            {
                //ツール機能を使用するときはDoEventsでフレームを開始
                //使用しないときはUpdateでフレームを開始
                if (!Graphics.BeginFrame()) return false;
            }

            if (_CameraNodes.Count == 0)
            {
                // カメラが 1 つもない場合はデフォルトカメラを使用
                Renderer.SetCamera(_DefaultCamera);

                var list = _DrawnNodes.Nodes;
                foreach (var z in list.Keys.OrderBy(x => x))
                {
                    var nodes = list[z];
                    foreach (var node in nodes)
                        node.Draw();
                }

                Renderer.Render();
            }
            else
            {
                // 特定のカメラに映りこむノードを描画
                for (int i = 0; i <= 31; i++)
                {
                    foreach (var camera in _CameraNodes[i])
                    {
                        Renderer.SetCamera(camera.RenderedCamera);

                        var list = _DrawnNodes[i];
                        foreach (var z in list.Keys.OrderBy(x => x))
                        {
                            var nodes = list[z];
                            foreach (var node in nodes)
                                node.Draw();
                        }

                        Renderer.Render();
                    }
                }
            }

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
            _DrawnNodes.UpdateZOrder(node, oldZOrder);
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
