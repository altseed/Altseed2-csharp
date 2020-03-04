using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed.TinySystem
{
    public class TextNode : DrawnNode
    {
        private readonly List<RenderedSprite> _Sprites;

        public string Text
        {
            get => _Text;
            set
            {
                if (_Text == value) return;
                _Text = value;
                UpdateVertexes();
            }
        }
        private string _Text;

        public Font Font
        {
            get => _Font;
            set
            {
                if (_Font == value) return;
                _Font = value;
                UpdateVertexes();
            }
        }
        private Font _Font;

        public Vector2F Rect { get; private set; }

        /// <summary>
        /// カーニングを使用するかどうかを取得または設定する
        /// </summary>
        public bool UseKerning
        {
            get;
            set;
        }


        private Material __Material;
        public TextNode()
        {
            _Sprites = new List<RenderedSprite>();

            var shader = Engine.Graphics.BuildinShader.Create(Altseed.BuildinShaderType.FontUnlitPS);
            __Material = new Material();
            __Material.Shader = shader;

        }

        internal override void Draw()
        {
            foreach (var s in _Sprites)
            {
                Engine.Renderer.DrawSprite(s);
            }
        }


        private void UpdateVertexes()
        {
            // TODO: 一つのスプライトというかポリゴンにまとめる！
            if (Font == null || _Text == null) return;

            var offset = new Vector2F();
            var charArray = _Text.ToCharArray();
            //TODO: 4byte?
            for (int i = 0; i < charArray.Length; i++)
            {
                var c = charArray[i];
                var glyph = Font.GetGlyph(c);
                var pos = offset + glyph.Offset.To2DF() + new Vector2F(0, Font.Ascent);

                var sprite = RenderedSprite.Create();
                sprite.Material = __Material;
                sprite.Texture = Font.GetFontTexture(glyph.TextureIndex);

                var trans = new Matrix44F();
                trans.SetTranslation(pos.X, pos.Y, 0);
                sprite.Transform = trans;

                sprite.Src = new Altseed.RectF(glyph.Position.X, glyph.Position.Y, glyph.Size.X, glyph.Size.Y);
                _Sprites.Add(sprite);

                offset += new Altseed.Vector2F(glyph.GlyphWidth, 0);

                if (UseKerning && i < charArray.Length - 1)
                    offset += new Vector2F(Font.GetKerning(charArray[i], charArray[i + 1]), 0);
            }
        }

        protected internal override void UpdateTransform()
        {
            throw new NotImplementedException();
            var mat = _MatPosition * _MatAngle * _MatScale;
            // TODO: CenterPosition
            // TODO: Parent Transform

        }
    }
}
