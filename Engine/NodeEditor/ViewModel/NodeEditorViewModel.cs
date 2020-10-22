using System.Collections.Generic;

namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class NodeEditorViewModel
    {
        public NodeEditorViewModel()
        {
            TextureBrowserViewModel = new TextureBrowserViewModel();
            FontBrowserViewModel = new FontBrowserViewModel();
            PreviewViewModel = new PreviewViewModel();
        }
        public TextureBrowserViewModel TextureBrowserViewModel { get; }
        public FontBrowserViewModel FontBrowserViewModel { get; }
        public PreviewViewModel PreviewViewModel { get; }

        public List<TextureBase> TextureOptions => TextureBrowserViewModel.Options;
        public List<Font> Fonts => FontBrowserViewModel.Options;
        public Vector2F MousePosition => PreviewViewModel.MousePosition;
        public bool IsMainWindowFocus => PreviewViewModel.IsMainWindowFocus;

        public TextureBaseToolElement TextureBrowserTarget
        {
            get => TextureBrowserViewModel.Selected;
            set => TextureBrowserViewModel.Selected = value;
        }

        public FontToolElement FontBrowserTarget
        {
            get => FontBrowserViewModel.Selected;
            set => FontBrowserViewModel.Selected = value;
        }
    }
}
