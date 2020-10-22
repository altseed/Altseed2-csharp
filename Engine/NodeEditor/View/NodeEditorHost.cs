using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    /// <summary>
    /// エディター
    /// </summary>
    public static class NodeEditorHost
    {
        private static NodeEditor _logic;
        
        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public static List<TextureBase> TextureOptions => _logic.TextureOptions;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public static List<Font> Fonts => _logic.Fonts;

        /// <summary>
        /// マウス座標
        /// </summary>
        public static Vector2F MousePosition => _logic.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsMainWindowFocus => _logic.IsMainWindowFocus;

        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public static object Selected
        {
            get => _logic.Selected;
            set => _logic.Selected = value;
        }

        internal static TextureBaseToolElement TextureBrowserTarget
        {
            get => _logic.TextureBrowserTarget;
            set => _logic.TextureBrowserTarget = value;
        }

        internal static FontToolElement FontBrowserTarget
        {
            get => _logic.FontBrowserTarget;
            set => _logic.FontBrowserTarget = value;
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
            config ??= new Configuration();
            config.EnabledCoreModules |= CoreModules.Tool;
            config.IsResizable = true;

            var res = Engine.Initialize(title, width, height, config);
            Engine.Tool.AddFontFromFileTTF("../TestData/Font/mplus-1m-regular.ttf", 20, ToolGlyphRange.Japanese);
            Engine.Tool.ToolUsage = ToolUsage.Main;
            ToolElementManager.SetAltseed2DefaultObjectMapping();

            _logic = new NodeEditor();

            return res;
        }

        /// <summary>
        /// 更新処理を行う。
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            _logic.UpdateUi();

            return Engine.UpdateComponents(true, true);
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
            _logic.Dispose();
            Engine.Terminate();
        }
    }
}
