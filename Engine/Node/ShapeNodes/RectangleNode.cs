using System;

namespace Altseed
{
    /// <summary>
    /// 短形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class RectangleNode : DrawnNode
    {
        private bool changed = false;
        private readonly RenderedPolygon renderedPolygon;

        internal override int CullingId => renderedPolygon.Id;

        public override Matrix44F AbsoluteTransform => renderedPolygon.Transform;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                if (_color == value) return;
                _color = value;
                renderedPolygon.OverwriteVertexesColor(value);
            }
        }
        private Color _color = new Color(255, 255, 255);

        /// <summary>
        /// サイズを取得または設定します。
        /// </summary>
        public override Vector2F Size
        {
            get => base.Size;
            set
            {
                if (base.Size == value) return;
                base.Size = value;
                changed = true;
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material { get => renderedPolygon.Material; set { renderedPolygon.Material = value; } }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => renderedPolygon.Texture;
            set
            {
                if (renderedPolygon.Texture == value) return;
                renderedPolygon.Texture = value;
                renderedPolygon.Src = new RectF(default, value?.Size ?? Vector2F.One);
            }
        }

        /// <summary>
        /// <see cref="RectangleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(4);
        }

        public override void AdjustSize() { }

        internal override void Draw() => Engine.Renderer.DrawPolygon(renderedPolygon);

        internal override void UpdateInheritedTransform()
        {
            if (changed)
            {
                UpdateVertexes();
                changed = false;
            }
            renderedPolygon.Transform = CalcInheritedTransform();
        }

        private void UpdateVertexes()
        {
            var positions = new Vector2F[4];
            positions[0] = new Vector2F(0.0f, 0.0f);
            positions[1] = new Vector2F(0.0f, Size.Y);
            positions[2] = new Vector2F(Size.X, Size.Y);
            positions[3] = new Vector2F(Size.X, 0.0f);
            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
