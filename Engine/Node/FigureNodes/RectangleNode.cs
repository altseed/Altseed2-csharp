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

        /// <summary>
        /// 中心座標を取得または設定します。
        /// </summary>
        public Vector2F Center
        {
            get => _center;
            set
            {
                if (_center == value) return;
                _center = value;
                changed = true;
            }
        }
        private Vector2F _center;

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
        public Vector2F Size
        {
            get => _size;
            set
            {
                if (_size == value) return;
                _size = value;
                changed = true;
            }
        }
        private Vector2F _size = new Vector2F(1.0f, 1.0f);

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture { get => renderedPolygon.Texture; set => renderedPolygon.Texture = value; }

        /// <summary>
        /// <see cref="RectangleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(4);
        }

        internal override void Draw()
        {
            if (changed)
            {
                UpdateVertexes();
                changed = false;
            }
            Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        internal override void UpdateInheritedTransform() => renderedPolygon.Transform = CalcInheritedTransform();

        private void UpdateVertexes()
        {
            var positions = new Vector2F[4];
            positions[0] = -_center;
            positions[1] = new Vector2F(0.0f, Size.Y) - _center;
            positions[2] = new Vector2F(Size.X, Size.Y) - _center;
            positions[3] = new Vector2F(Size.X, 0.0f) - _center;
            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
        }
    }
}
