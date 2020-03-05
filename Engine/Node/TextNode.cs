using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
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

        /// <summary>
        /// 描画領域の大きさを取得します。
        /// </summary>
        public Vector2F Size { get; private set; }

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
            var maxHeight = 0.0f;

            _Sprites.Clear();
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
                maxHeight = (maxHeight < glyph.Size.Y) ? glyph.Size.Y : maxHeight;

                if (UseKerning && i < charArray.Length - 1)
                    offset += new Vector2F(Font.GetKerning(charArray[i], charArray[i + 1]), 0);
            }

            Size = new Vector2F(offset.X, maxHeight);
        }

        protected internal override void UpdateTransform()
        {
            throw new NotImplementedException();
            var mat = _MatPosition * _MatAngle * _MatScale;
            // TODO: CenterPosition
            // TODO: Parent Transform

        }

        // TODO: Serialization
    }
}
