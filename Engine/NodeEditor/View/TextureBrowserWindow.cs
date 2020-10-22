using System;
using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    internal sealed class TextureBrowserWindow
    {
        private readonly IEditorPropertyAccessor _accessor;

        public TextureBrowserWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public List<TextureBase> TextureOptions { get; } = new List<TextureBase>();

        public void Render()
        {
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.PushID("Browser".GetHashCode());
                if (Engine.Tool.Button("+"))
                {
                    OpenImage();
                }

                foreach (var item in TextureOptions)
                {
                    RenderImageButton(item, () => SetTexture(item));
                }

                if (Engine.Tool.Button("null"))
                {
                    SetTexture(null);
                }

                Engine.Tool.PopID();

                if (!Engine.Tool.IsWindowFocused(ToolFocused.None))
                {
                    _accessor.TextureBrowserTarget = null;
                }
                Engine.Tool.End();
            }
        }

        private void SetTexture(TextureBase item)
        {
            _accessor.TextureBrowserTarget?.PropertyInfo.SetValue(_accessor.TextureBrowserTarget.Source, item);
            _accessor.TextureBrowserTarget = null;
        }

        private void OpenImage()
        {
            if (Engine.Tool.OpenDialog("png,jpg,jpeg,psd", "") is { } path
                && Texture2D.Load(path) is { } newTexture)
            {
                TextureOptions.Add(newTexture);
            }
        }

        private static void RenderImageButton(TextureBase image, Action onActive)
        {
            if (Engine.Tool.ImageButton(image,
                new Vector2F(80, 80),
                new Vector2F(0, 0),
                new Vector2F(1, 1),
                5,
                new Color(),
                new Color(255, 255, 255, 255)))
            {
                onActive();
            }
        }

    }
}
