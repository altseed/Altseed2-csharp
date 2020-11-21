using System.Collections.Generic;

namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class TextureBrowserViewModel
    {
        public List<TextureBase> Options { get; } = new List<TextureBase>();
        public TextureBaseToolElement Selected { get; set; }
        
        public void SetSelection(TextureBase item)
        {
            Selected?.PropertyInfo.SetValue(Selected.Source, item);
            Selected = null;
        }

        public void LoadImage(string texturePath)
        {
            if (Texture2D.Load(texturePath) is {} newTexture)
            {
                Options.Add(newTexture);
            }
        }
    }
}