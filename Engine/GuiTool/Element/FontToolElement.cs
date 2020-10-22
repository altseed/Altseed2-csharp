using System;
using Altseed2.NodeEditor.View;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class FontToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public FontToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!typeof(Font).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がFont型ではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            Font font = (Font)PropertyInfo.GetValue(Source);
            if (font != null)
            {
                var glyph = font.GetGlyph((int)'阿');
                if (Engine.Tool.ImageButton(font.GetFontTexture(0),
                    new Vector2I(80, 80),
                    new Vector2F(0, 0),
                    (glyph.Position + glyph.Size).To2F() / glyph.TextureSize,
                    5,
                    new Color(),
                    new Color(255, 255, 255, 255)))
                {
                    NodeEditorHost.FontBrowserTarget = this;
                    Engine.Tool.SetWindowFocusByName("Font Browser");
                }
            }
            else
            {
                if (Engine.Tool.Button("null"))
                {
                    NodeEditorHost.FontBrowserTarget = this;
                    Engine.Tool.SetWindowFocusByName("Font Browser");
                }
            }
            Engine.Tool.SameLine();
            Engine.Tool.LabelText("Font", Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static FontToolElement Create(object source, ObjectMapping objectMapping)
        {
            return new FontToolElement(objectMapping.Name, source, objectMapping.PropertyName);
        }
    }
}
