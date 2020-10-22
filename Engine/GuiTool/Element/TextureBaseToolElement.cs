using System;
using Altseed2.NodeEditor.View;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class TextureBaseToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public TextureBaseToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!typeof(TextureBase).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がTextureBase型ではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            TextureBase texture = (TextureBase)PropertyInfo.GetValue(Source);
            if (texture != null)
            {
                if (Engine.Tool.ImageButton(texture,
                    new Vector2I(80, 80),
                    new Vector2F(0, 0),
                    new Vector2F(1, 1),
                    5,
                    new Color(),
                    new Color(255, 255, 255, 255)))
                {
                    NodeEditorHost.TextureBrowserTarget = this;
                    Engine.Tool.SetWindowFocusByName("Texture Browser");
                }
            }
            else
            {
                if (Engine.Tool.Button("null"))
                {
                    NodeEditorHost.TextureBrowserTarget = this;
                    Engine.Tool.SetWindowFocusByName("Texture Browser");
                }
            }
            Engine.Tool.SameLine();
            Engine.Tool.LabelText("Texture", Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static TextureBaseToolElement Create(object source, ObjectMapping objectMapping)
        {
            return new TextureBaseToolElement(objectMapping.Name, source, objectMapping.PropertyName);
        }
    }
}
