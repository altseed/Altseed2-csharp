using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;
using PartsTreeSystem;
using System;
using System.Linq;

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
            set => _nodeEditor.Selected = value as Node;
        }

        /// <summary>
        /// エディターを初期化する
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null )
        {
            var res = Model.NodeEditorModel.Initialize( title, width, height, config );
            if (!res)
                return false;
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
            _nodeEditor.Render();

            return Model.NodeEditorModel.Update();
        }

        /// <summary>
        /// エディターを終了する。
        /// </summary>
        public static void Terminate()
        {
            _nodeEditor.Dispose();
            
            Model.NodeEditorModel.Terminate();
        }
    }
}
