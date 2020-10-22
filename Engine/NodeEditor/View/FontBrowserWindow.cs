using System;
using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    internal sealed class FontBrowserWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private int _fontSize = 50;

        public FontBrowserWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public List<Font> Fonts { get; } = new List<Font>();

        public void UpdateFontBrowser()
        {
            if (Engine.Tool.Begin("Font Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());

                Engine.Tool.InputInt("Font Size", ref _fontSize);
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("+"))
                {
                    OpenFont();
                }

                foreach (var item in Fonts)
                {
                    RenderFontButton(item, () => SetTexture(item));
                }

                if (Engine.Tool.Button("null"))
                {
                    SetTexture(null);
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    _accessor.FontBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }

        private void SetTexture(Font item)
        {
            _accessor.FontBrowserTarget?.PropertyInfo.SetValue(_accessor.FontBrowserTarget.Source, item);
            _accessor.FontBrowserTarget = null;
        }

        private void OpenFont()
        {
            if (Engine.Tool.OpenDialog("ttf", "") is {} path)
            {
                var font = Font.LoadDynamicFont(path, _fontSize);
                font.GetGlyph((int) 'a');
                font.GetGlyph((int) 'あ');
                font.GetGlyph((int) '阿');
                Fonts.Add(font);
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
