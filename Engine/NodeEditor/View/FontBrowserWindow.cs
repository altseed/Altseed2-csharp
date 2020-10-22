using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    internal sealed class FontBrowserWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly List<Font> _fonts = new List<Font>();  // TODO: publicにしてユーザーに公開すべき
        private int _fontSize = 50;

        public FontBrowserWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void UpdateFontBrowser()
        {
            if (Engine.Tool.Begin("Font Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());

                Engine.Tool.InputInt("Font Size", ref _fontSize);
                Engine.Tool.SameLine();
                if (Engine.Tool.Button("+"))
                {
                    string path;
                    if ((path = Engine.Tool.OpenDialog("ttf", "")) != null)
                    {
                        var font = Font.LoadDynamicFont(path, _fontSize);
                        font.GetGlyph((int)'a');
                        font.GetGlyph((int)'あ');
                        font.GetGlyph((int)'阿');
                        if (font != null)
                            _fonts.Add(font);
                    }
                }

                foreach (var item in _fonts)
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
                        if (_accessor.FontBrowserTarget != null)
                            _accessor.FontBrowserTarget.PropertyInfo.SetValue(_accessor.FontBrowserTarget.Source, item);
                        _accessor.FontBrowserTarget = null;
                    }
                }

                if (Engine.Tool.Button("null"))
                {
                    _accessor.FontBrowserTarget.PropertyInfo.SetValue(_accessor.FontBrowserTarget.Source, null);
                    _accessor.FontBrowserTarget = null;
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    _accessor.FontBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }
    }
}
