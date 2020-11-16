using System;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class TextureBrowserWindow
    {
        private readonly TextureBrowserViewModel _viewModel;

        public TextureBrowserWindow(TextureBrowserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool IsActive => _viewModel.Selected != null;

        public void Render()
        {
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());
                if (Engine.Tool.Button("+"))
                {
                    OpenImage();
                }

                foreach (var item in _viewModel.Options)
                {
                    RenderImageButton(item, () => _viewModel.SetSelection(item));
                }

                if (Engine.Tool.Button("null"))
                {
                    _viewModel.SetSelection(null);
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    _viewModel.Selected = null;
                }
                Engine.Tool.End();
            }
        }

        private void OpenImage()
        {
            if (Engine.Tool.OpenDialog("png,jpg,jpeg,psd", "") is { } path)
            {
                _viewModel.LoadImage(path);
            }
        }

        private static void RenderImageButton(TextureBase image, Action onClick)
        {
            if (Engine.Tool.ImageButton(image,
                new Vector2F(80, 80),
                new Vector2F(0, 0),
                new Vector2F(1, 1),
                5,
                new Color(),
                new Color(255, 255, 255, 255)))
            {
                onClick();
            }
        }

    }
}
