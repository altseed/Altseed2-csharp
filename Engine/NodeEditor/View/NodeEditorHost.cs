using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    /// <summary>
    /// エディター
    /// </summary>
    public static class NodeEditorHost
    {
        private static NodeEditorViewModel _nodeEditorViewModel;
        private static NodeEditor _nodeEditor;
        
        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public static List<TextureBase> TextureOptions => _nodeEditorViewModel.TextureOptions;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public static List<Font> Fonts => _nodeEditorViewModel.Fonts;

        /// <summary>
        /// マウス座標
        /// </summary>
        public static Vector2F MousePosition => _nodeEditorViewModel.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsMainWindowFocus => _nodeEditorViewModel.IsMainWindowFocus;

        internal static TextureBaseToolElement TextureBrowserTarget
        {
            get => _nodeEditorViewModel.TextureBrowserTarget;
            set => _nodeEditorViewModel.TextureBrowserTarget = value;
        }

        internal static FontToolElement FontBrowserTarget
        {
            get => _nodeEditorViewModel.FontBrowserTarget;
            set => _nodeEditorViewModel.FontBrowserTarget = value;
        }

        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public static object Selected
        {
            get => _nodeEditor.Selected;
            set => _nodeEditor.Selected = value;
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

            _nodeEditorViewModel = new NodeEditorViewModel();
            _nodeEditor = new NodeEditor(_nodeEditorViewModel);

            return res;
        }

        /// <summary>
        /// 更新処理を行う。
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            _nodeEditor.UpdateUi();

            return Engine.UpdateComponents(true, true);
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
            _nodeEditor.Dispose();
            Engine.Terminate();
        }
    }
}
