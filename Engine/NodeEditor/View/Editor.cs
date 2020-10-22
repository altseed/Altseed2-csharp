using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    /// <summary>
    /// エディター
    /// </summary>
    public static class Editor
    {
        private static EditorLogic logic_refactor;
        
        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public static List<TextureBase> TextureOptions => logic_refactor.TextureOptions;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public static List<Font> Fonts => logic_refactor.Fonts;

        /// <summary>
        /// マウス座標
        /// </summary>
        public static Vector2F MousePosition => logic_refactor.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsMainWindowFocus => logic_refactor.IsMainWindowFocus;

        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public static object Selected
        {
            get => logic_refactor.Selected;
            set => logic_refactor.Selected = value;
        }

        internal static TextureBaseToolElement TextureBrowserTarget
        {
            get => logic_refactor.TextureBrowserTarget;
            set => logic_refactor.TextureBrowserTarget = value;
        }

        internal static FontToolElement FontBrowserTarget
        {
            get => logic_refactor.FontBrowserTarget;
            set => logic_refactor.FontBrowserTarget = value;
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

            logic_refactor = new EditorLogic();
            logic_refactor.InitializeComponents();

            return res;
        }

        /// <summary>
        /// 更新処理を行う。
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            logic_refactor.UpdateUi();

            return Engine.UpdateComponents(true, true);
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
            logic_refactor.Dispose();
            Engine.Terminate();
        }
    }
}
