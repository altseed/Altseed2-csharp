using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using Altseed2.NodeEditor.View;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2
{
    /// <summary>
    /// エディター
    /// </summary>
    public static class Editor
    {
        private static EditorPropertyAccessor propertyAccessor;
        private static NodeTreeWindow nodeTreeWindow;
        private static SelectedNodeWindow selectedNodeWindow;
        private static PreviewWindow previewWindow_refactor;
        private static TextureBrowserWindow textureBrowserWindow_refactor;
        private static FontBrowserWindow fontBrowserWindow_refactor;

        private static object selected;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public static List<Font> Fonts = new List<Font>();

        /// <summary>
        /// マウス座標
        /// </summary>
        public static Vector2F MousePosition => previewWindow_refactor.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsMainWindowFocus => previewWindow_refactor.IsMainWindowFocus;

        internal static TextureBaseToolElement TextureBrowserTarget { get; set; }
        internal static FontToolElement FontBrowserTarget { get; set; }

        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public static object Selected
        {
            get => selected;
            set
            {
                if (value == selected)
                    return;
                selected = value;

                propertyAccessor.OnSelectedValueChanged();
            }
        }

        /// <summary>
        /// エディターを初期化する
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            if (config == null)
                config = new Configuration();
            config.EnabledCoreModules |= CoreModules.Tool;
            config.IsResizable = true;

            var res = Engine.Initialize(title, width, height, config);
            Engine.Tool.AddFontFromFileTTF("../TestData/Font/mplus-1m-regular.ttf", 20, ToolGlyphRange.Japanese);
            Engine.Tool.ToolUsage = ToolUsage.Main;
            ToolElementManager.SetAltseed2DefaultObjectMapping();

            first = true;

            propertyAccessor = new EditorPropertyAccessor();
            nodeTreeWindow = new NodeTreeWindow(propertyAccessor, new NodeTreeViewModel(propertyAccessor));
            selectedNodeWindow = new SelectedNodeWindow(propertyAccessor);
            previewWindow_refactor = new PreviewWindow(propertyAccessor);
            textureBrowserWindow_refactor = new TextureBrowserWindow(propertyAccessor);
            fontBrowserWindow_refactor = new FontBrowserWindow(propertyAccessor);

            return res;
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
            selectedNodeWindow.Dispose();
            Engine.Terminate();
        }

        /// <summary>
        /// 更新処理を行う。
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            if (first)
            {
                OnFirstUpdate();
            }

            UpdateCameraGroup();
            UpdateComponents();

            // ノードの更新
            Engine._UpdatedNode?.Update();

            // Contextの更新
            Engine.Context.Update();

            // Graphicsが初期化されていない場合は早期リターン
            if (Engine.Graphics == null) return true;

            // カリング用AABBの更新
            Engine.CullingSystem?.UpdateAABB();

            // (ツール機能を使用しない場合は)描画を開始
            if (Engine.Tool == null)
            {
                //ツール機能を使用するときはDoEventsでフレームを開始
                //使用しないときはUpdateでフレームを開始
                if (!Engine.Graphics.BeginFrame(new RenderPassParameter(Engine.ClearColor, true, true))) return false;
            }

            // カメラが 1 つもない場合はデフォルトカメラを使用
            Engine.DrawCameraGroup(Engine._DefaultCamera, Engine._DrawnCollection.GetDrawns());

            // 特定のカメラに映りこむノードを描画
            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
            {
                foreach (var camera in Engine._CameraNodes[i])
                {
                    Engine.DrawCameraGroup(camera.RenderedCamera, Engine._DrawnCollection[i]);
                }
            }

            Engine._RenderTextureCache.Update();
            PostEffectNode.UpdateCache();

            // （ツール機能を使用する場合は）ツールを描画
            if (Engine.Tool != null)
            {
                Engine.Tool.Render();
            }

            // 描画を終了
            if (!Engine.Graphics.EndFrame()) return false;
            return true;
        }

        private static void UpdateCameraGroup()
        {
            foreach (var node in Engine.GetNodes().Union(Engine.GetNodes().SelectMany(obj => obj.EnumerateDescendants())))
            {
                try
                {
                    var propertyInfo = node.GetType().GetProperty("CameraGroup");
                    propertyInfo?.SetValue(node, (ulong)propertyInfo.GetValue(node) | 1u << 63);
                }
                catch
                {
                }
            }
        }

        private static void UpdateComponents()
        {
            previewWindow_refactor.Render();
            UpdateMenu();
            nodeTreeWindow.Render();
            selectedNodeWindow.Render();

            if (TextureBrowserTarget != null)
                textureBrowserWindow_refactor.Render();
            if (FontBrowserTarget != null)
                UpdateFontBrowser();
        }

        private static void OnFirstUpdate()
        {
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.End();
            }

            if (Engine.Tool.Begin("Font Browser", ToolWindowFlags.None))
            {
                Engine.Tool.End();
            }

            first = false;
        }

        private static float menuHeight = 20;   // UpdateMainWindow, UpdateNodeTreeWindow, UpdateSelectedWindow, UpdateMenu で使われる
        private static bool first;

        static void UpdateMenu()
        {
            if (Engine.Tool.BeginMainMenuBar())
            {
                if (Engine.Tool.BeginMenu("File", true))
                {
                    Engine.Tool.MenuItem("New", "", false, true);
                    Engine.Tool.MenuItem("Open", "", false, true);
                    Engine.Tool.EndMenu();
                }
                if (Engine.Tool.BeginMenu("Edit", true))
                {
                    Engine.Tool.MenuItem("Copy", "", false, true);
                    Engine.Tool.MenuItem("Paste", "", false, true);
                    Engine.Tool.EndMenu();
                }
                Engine.Tool.Text(Engine.CurrentFPS.ToString());
                Engine.Tool.EndMainMenuBar();
            }
            menuHeight = Engine.Tool.GetFrameHeight();
        }

        static int fontSize = 50;   // UpdateFontBrowser だけで使用される

        private static void UpdateFontBrowser()
        {
            fontBrowserWindow_refactor.UpdateFontBrowser();
        }
        
        private sealed class EditorPropertyAccessor : IEditorPropertyAccessor
        {
            private readonly Subject<Unit> _onSelectedNodeChanged = new Subject<Unit>();

            public object Selected
            {
                get => Editor.Selected;
                set => Editor.Selected = value;
            }

            public float MenuHeight => menuHeight;

            public IObservable<Unit> OnPropertyChanged_Selected_refactor => _onSelectedNodeChanged;
            public TextureBaseToolElement TextureBrowserTarget
            {
                get => Editor.TextureBrowserTarget;
                set => Editor.TextureBrowserTarget = value;
            }

            public FontToolElement FontBrowserTarget
            {
                get => Editor.FontBrowserTarget;
                set => Editor.FontBrowserTarget = value;
            }

            public void OnSelectedValueChanged() => _onSelectedNodeChanged.OnNext(Unit.Default);
        }
    }
}
