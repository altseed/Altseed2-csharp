using System;

namespace Altseed
{
    /// <summary>
    /// 直線を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class LineNode : DrawnNode
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
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material { get => renderedPolygon.Material; set { renderedPolygon.Material = value; } }

        /// <summary>
        /// 描画の始点を取得または設定します。
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
        /// 描画の終点を取得または設定します。
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
        /// 直線の太さを取得または設定します。
        /// </summary>
        public float Thickness
        {
            get => _thickness;
            set
            {
                if (_thickness == value) return;
                _thickness = value;
                changed = true;
            }
        }
        private float _thickness;

        /// <summary>
        /// <see cref="LineNode"/>の新しいインスタンスを生成する
        /// </summary>
        public LineNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(4);
        }

        public override void AdjustSize()
        {
            MathHelper.GetMinMax(out var min, out var max, renderedPolygon.Vertexes);
            Size = max - min;
        }

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
            var sub = _point2 - _point1;
            var degree = sub.Degree;
            var x = new Vector2F(sub.Length, 0.0f)
            {
                Degree = degree
            };
            var y = new Vector2F(0.0f, _thickness / 2)
            {
                Degree = degree + 90
            };
            positions[0] = _point1 - y;
            positions[1] = _point1 + y;
            positions[2] = _point1 + x + y;
            positions[3] = _point1 + x - y;

            AdjustSize();

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
