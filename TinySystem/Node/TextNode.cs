using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed.TinySystem
{
    public class TextNode : DrawnNode
    {
        private readonly List<RenderedSprite> sprites = new List<RenderedSprite>();

        public string Text
        {
            get;
            set;
        }

        internal override void Draw()
        {
            throw new NotImplementedException();
        }

        protected internal override void UpdateTransform()
        {
            throw new NotImplementedException();
        }
    }
}
