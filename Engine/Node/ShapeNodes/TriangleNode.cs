using System;

namespace Altseed
{
    /// <summary>
    /// 三角形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class TriangleNode : DrawnNode
    {
        private bool changed = false;
        private readonly RenderedPolygon renderedPolygon;

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

        internal override int CullingId => renderedPolygon.Id;

        /// <summary>
        /// 頂点1を取得または設定します。
        /// </summary>
        public Vector2F Point1
        {
            get => _point1;
            set
            {
                if (_point1 == value) return;
                _point1 = value;
                changed = true;
            }
        }
        private Vector2F _point1;

        /// <summary>
        /// 頂点2を取得または設定します。
        /// </summary>
        public Vector2F Point2
        {
            get => _point2;
            set
            {
                if (_point2 == value) return;
                _point2 = value;
                changed = true;
            }
        }
        private Vector2F _point2;

        /// <summary>
        /// 頂点3を取得または設定します。
        /// </summary>
        public Vector2F Point3
        {
            get => _point3;
            set
            {
                if (_point3 == value) return;
                _point3 = value;
                changed = true;
            }
        }
        private Vector2F _point3;

        /// <summary>
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material { get => renderedPolygon.Material; set { renderedPolygon.Material = value; } }

        /// <summary>
        /// <see cref="TriangleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public TriangleNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(3);
        }

        public override void AdjustSize()
        {
            MathHelper.GetMinMax(out var min, out var max, renderedPolygon.Vertexes);
            Size = max - min;
        }

        protected internal override void Draw() => Engine.Renderer.DrawPolygon(renderedPolygon);

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
            var positions = new Vector2F[3];
            positions[0] = _point1;
            positions[1] = _point2;
            positions[2] = _point3;

            AdjustSize();

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
