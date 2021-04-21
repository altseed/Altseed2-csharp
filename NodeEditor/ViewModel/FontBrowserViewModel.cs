using System.Collections.Generic;

namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class FontBrowserViewModel
    {
        public List<Font> Options { get; } = new List<Font>();
        public FontToolElement Selected { get; set; }
        public int SamplingSize;

        public void SetSelection(Font item)
        {
            Selected?.PropertyInfo.SetValue(Selected.Source, item);
            Selected = null;
        }

        public void LoadFont(string fontPath)
        {
            var font = Font.LoadDynamicFont(fontPath, SamplingSize);
            font.GetGlyph((int) 'a');
            font.GetGlyph((int) 'あ');
            font.GetGlyph((int) '阿');
            Options.Add(font);
        }
    }
}
