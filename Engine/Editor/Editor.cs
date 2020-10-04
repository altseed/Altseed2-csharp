using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// エディター
    /// </summary>
    public static class Editor
    {
        private static object selected;
        private static RenderTexture main;

        private static IEnumerable<ToolElement> selectedToolElements;

        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public static List<TextureBase> TextureBases = new List<TextureBase>();

        /// <summary>
        /// フォント一覧
        /// </summary>
        public static List<Font> Fonts = new List<Font>();

        /// <summary>
        /// マウス座標
        /// </summary>
        public static Vector2F MousePosition { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsMainWindowFocus { get; private set; }

        /// <summary>
        /// メインウィンドウ対象カメラ
        /// </summary>
        public static CameraNode MainCamera
        {
            get => mainCamera;
            set
            {
                if (value == mainCamera) return;
                mainCamera?.Parent?.RemoveChildNode(mainCamera);

                mainCamera = value;
                if (mainCamera.Status == RegisteredStatus.Free)
                {
                    Engine.AddNode(mainCamera);
                }
            }
        }

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

                selectedToolElements = ToolElementManager.CreateToolElements(selected);
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

            var res = Engine.Initialize(title, width, height, config);
            Engine.Tool.AddFontFromFileTTF("../TestData/Font/mplus-1m-regular.ttf", 20, ToolGlyphRange.Japanese);
            Engine.Tool.ToolUsage = ToolUsage.Main;
            ToolElementManager.SetAltseed2DefaultObjectMapping();

            main = RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM);

            MainCamera = new CameraNode();
            MainCamera.IsColorCleared = true;
            MainCamera.ClearColor = new Color(50, 50, 50);
            MainCamera.Group = 63;
            MainCamera.TargetTexture = main;
            Engine.AddNode(MainCamera);

            first = true;

            return res;
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
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

            foreach (var node in Engine.GetNodes().Union(Engine.GetNodes().SelectMany(obj => obj.EnumerateDescendants())))
            {
                try
                {
                    var propertyInfo = node.GetType().GetProperty("CameraGroup");
                    propertyInfo.SetValue(node, (ulong)propertyInfo.GetValue(node) | 1u << 63);
                }
                catch { }
            }

            UpdateMainWindow();
            UpdateMenu();
            UpdateNodeTreeWindow();
            UpdateSelectedWindow();

            if (TextureBrowserTarget != null)
                UpdateTextureBrowser();
            if (FontBrowserTarget != null)
                UpdateFontBrowser();
            return Engine.Update();
        }

        static Vector2I windowSize = Engine.WindowSize;
        private static float menuHeight = 20;
        private static bool first;

        private static void UpdateMainWindow()
        {
            if (windowSize != Engine.WindowSize)
            {
                Vector2I texSize = Engine.WindowSize - new Vector2I(600, (int)menuHeight);
                if (texSize.X > 0 && texSize.Y > 0)
                    main = RenderTexture.Create(texSize, TextureFormat.R8G8B8A8_UNORM);
                MainCamera.TargetTexture = main;
                windowSize = Engine.WindowSize;
            }

            var size = windowSize - new Vector2F(600, menuHeight);
            var pos = new Vector2F(300, menuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoTitleBar | ToolWindowFlags.NoScrollWithMouse;

            Engine.Tool.PushStyleVarVector2F(ToolStyleVar.WindowPadding, default);
            Engine.Tool.PushStyleVarFloat(ToolStyleVar.WindowRounding, 0);
            if (Engine.Tool.Begin("Main", flags))
            {
                IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocused.None);
                MousePosition = Engine.Mouse.Position - Engine.Tool.GetWindowPos();
                Engine.Tool.Image(main, main.Size, default, new Vector2F(1, 1), new Color(255, 255, 255), new Color());
                Engine.Tool.End();
            }
            Engine.Tool.PopStyleVar(2);
        }

        private static void UpdateNodeTreeWindow()
        {
            void NodeTree(IEnumerable<Altseed2.Node> nodes)
            {
                foreach (var node in nodes)
                {
                    if (node == MainCamera) continue;

                    Engine.Tool.PushID(node.GetHashCode());
                    var flags = ToolTreeNodeFlags.OpenOnArrow;
                    if (node == Selected)
                        flags |= ToolTreeNodeFlags.Selected;
                    if (node.Children.Count == 0)
                        flags |= ToolTreeNodeFlags.Leaf;

                    bool treeNode = Engine.Tool.TreeNodeEx(node.ToString(), flags);
                    if (Engine.Tool.IsItemClicked(0))
                    {
                        Selected = node;
                    }

                    if (treeNode)
                    {
                        NodeTree(node.Children);
                        Engine.Tool.TreePop();
                    }
                    Engine.Tool.PopID();
                }
            }

            var size = new Vector2F(300, Engine.WindowSize.Y - menuHeight);
            var pos = new Vector2F(0, menuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

            if (Engine.Tool.Begin("Node", flags))
            {
                if (Engine.Tool.Button("Sprite"))
                    Engine.AddNode(new SpriteNode());
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("Text"))
                    Engine.AddNode(new TextNode());
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("Arc"))
                    Engine.AddNode(new ArcNode() { Radius = 100, StartDegree = 0, EndDegree = 90 });
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("Circle"))
                    Engine.AddNode(new CircleNode() { Radius = 100 });
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("Line"))
                    Engine.AddNode(new LineNode() { Point2 = new Vector2F(100, 100) });
                if (Engine.Tool.Button("Rectangle"))
                    Engine.AddNode(new RectangleNode() { RectangleSize = new Vector2F(100, 100) });
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("Triangle"))
                    Engine.AddNode(new TriangleNode() { Point2 = new Vector2F(50, 50), Point3 = new Vector2F(100, 0) });

                NodeTree(Engine.GetNodes());
                Engine.Tool.End();
            }
        }

        private static void UpdateSelectedWindow()
        {
            var size = new Vector2F(300, Engine.WindowSize.Y - menuHeight);
            var pos = new Vector2F(Engine.WindowSize.X - size.X, menuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

            if (Engine.Tool.Begin("Selected", flags))
            {
                if (selectedToolElements != null)
                {
                    Engine.Tool.PushID("Selected".GetHashCode());
                    foreach (var toolElement in selectedToolElements)
                    {
                        Engine.Tool.PushID(toolElement.GetHashCode());
                        toolElement.Update();
                        Engine.Tool.PopID();
                    }
                    Engine.Tool.PopID();
                }
                Engine.Tool.End();
            }
        }

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

        static void UpdateTextureBrowser()
        {
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());
                if (Engine.Tool.Button("+"))
                {
                    string path;
                    if ((path = Engine.Tool.OpenDialog("png,jpg,jpeg,psd", "")) != null)
                    {
                        var newTexture = Texture2D.Load(path);
                        if (newTexture != null)
                            TextureBases.Add(newTexture);
                    }
                }

                foreach (var item in TextureBases)
                {
                    if (Engine.Tool.ImageButton(item,
                        new Vector2F(80, 80),
                        new Vector2F(0, 0),
                        new Vector2F(1, 1),
                        5,
                        new Color(),
                        new Color(255, 255, 255, 255)))
                    {
                        if (TextureBrowserTarget != null)
                            TextureBrowserTarget.PropertyInfo.SetValue(TextureBrowserTarget.Source, item);
                        TextureBrowserTarget = null;
                    }
                }

                if (Engine.Tool.Button("null"))
                {
                    TextureBrowserTarget.PropertyInfo.SetValue(TextureBrowserTarget.Source, null);
                    TextureBrowserTarget = null;
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    TextureBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }

        static int fontSize = 50;
        private static CameraNode mainCamera;

        private static void UpdateFontBrowser()
        {
            if (Engine.Tool.Begin("Font Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());

                Engine.Tool.InputInt("Font Size", ref fontSize);
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("+"))
                {
                    string path;
                    if ((path = Engine.Tool.OpenDialog("ttf", "")) != null)
                    {
                        var font = Font.LoadDynamicFont(path, fontSize);
                        font.GetGlyph((int)'a');
                        font.GetGlyph((int)'あ');
                        font.GetGlyph((int)'阿');
                        if (font != null)
                            Fonts.Add(font);
                    }
                }

                foreach (var item in Fonts)
                {
                    var glyph = item.GetGlyph((int)'阿');
                    if (Engine.Tool.ImageButton(item.GetFontTexture(glyph.TextureIndex),
                        new Vector2I(80, 80),
                        new Vector2F(0, 0),
                        (glyph.Position + glyph.Size).To2F() / glyph.TextureSize,
                        5,
                        new Color(),
                        new Color(255, 255, 255, 255)))
                    {
                        if (FontBrowserTarget != null)
                            FontBrowserTarget.PropertyInfo.SetValue(FontBrowserTarget.Source, item);
                        FontBrowserTarget = null;
                    }
                }

                if (Engine.Tool.Button("null"))
                {
                    FontBrowserTarget.PropertyInfo.SetValue(FontBrowserTarget.Source, null);
                    FontBrowserTarget = null;
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    FontBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }
    }
}
