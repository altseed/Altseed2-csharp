using System;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class FontBrowserWindow
    {
        private readonly FontBrowserViewModel _viewModel;

        public FontBrowserWindow(FontBrowserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool IsActive => _viewModel.Selected != null;

        public void UpdateFontBrowser()
        {
            bool pOpen = true;
            if (Engine.Tool.Begin("Font Browser", ref pOpen, ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());

                Engine.Tool.InputInt("Sampling Size", ref _viewModel.SamplingSize, 1, 1, ToolInputTextFlags.None);
                Engine.Tool.SameLine(0, -1);
                if (Engine.Tool.Button("+"))
                {
                    OpenFont();
                }

                foreach (var item in _viewModel.Options)
                {
                    RenderFontButton(item, () => _viewModel.SetSelection(item));
                }

                if (Engine.Tool.Button("null"))
                {
                    _viewModel.SetSelection(null);
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocusedFlags.None))
                {
                    _viewModel.Selected = null;
                }
                Engine.Tool.End();
            }
        }

        private void OpenFont()
        {
            if (Engine.Tool.OpenDialog("ttf,otf", "") is { } path)
            {
                _viewModel.LoadFont(path);
            }
        }

        private void RenderFontButton(Font font, Action onClick)
        {
            var glyph = font.GetGlyph((int)'阿');
            if (Engine.Tool.ImageButton(font.GetFontTexture(glyph.TextureIndex),
                new Vector2I(80, 80),
                new Vector2F(0, 0),
                (glyph.Position + glyph.Size).To2F() / glyph.TextureSize,
                5,
                new Color(),
                new Color(255, 255, 255, 255)))
            {
                onClick();
            }
        }
    }
}
