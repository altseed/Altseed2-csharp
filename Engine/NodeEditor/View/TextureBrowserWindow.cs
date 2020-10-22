using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2.NodeEditor.View
{
    internal sealed class TextureBrowserWindow
    {
        private readonly List<TextureBase> _textureOptions = new List<TextureBase>();
        private readonly IEditorPropertyAccessor _accessor;

        public TextureBrowserWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void UpdateTextureBrowser()
        {
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());
                if (Engine.Tool.Button("+"))
                {
                    string path;
                    if ((path = Engine.Tool.OpenDialog("png,jpg,jpeg,psd", "")) != null)
                    {
                        var newTexture = Texture2D.Load(path);
                        if (newTexture != null)
                            _textureOptions.Add(newTexture);
                    }
                }

                foreach (var item in _textureOptions)
                {
                    if (Engine.Tool.ImageButton(item,
                        new Vector2F(80, 80),
                        new Vector2F(0, 0),
                        new Vector2F(1, 1),
                        5,
                        new Color(),
                        new Color(255, 255, 255, 255)))
                    {
                        if (_accessor.TextureBrowserTarget != null)
                            _accessor.TextureBrowserTarget.PropertyInfo.SetValue(_accessor.TextureBrowserTarget.Source, item);
                        _accessor.TextureBrowserTarget = null;
                    }
                }

                if (Engine.Tool.Button("null"))
                {
                    _accessor.TextureBrowserTarget.PropertyInfo.SetValue(_accessor.TextureBrowserTarget.Source, null);
                    _accessor.TextureBrowserTarget = null;
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    _accessor.TextureBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }

    }
}
