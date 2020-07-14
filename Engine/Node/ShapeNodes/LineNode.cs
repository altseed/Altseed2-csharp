using System;

namespace Altseed2
{
    /// <summary>
    /// 直線を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class LineNode : DrawnNode
    {
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
        /// 描画モードを取得または設定します。
        /// </summary>
        public DrawMode Mode
        {
            get => _Mode;
            set
            {
                if (_Mode == value) return;

                _Mode = value;
            }
        }
        private DrawMode _Mode = DrawMode.Absolute;

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
                UpdateVertexes();
                if (IsAutoAdjustSize) AdjustSize();
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
                UpdateVertexes();
                if (IsAutoAdjustSize) AdjustSize();
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
                UpdateVertexes();
                if (IsAutoAdjustSize) AdjustSize();
            }
        }
        private float _thickness;

        public override void AdjustSize()
        {
            var array = renderedPolygon.Vertexes;
            MathHelper.GetMinMax(out var min, out var max, array);
            Size = max - min;
        }

        /// <summary>
        /// <see cref="LineNode"/>の新しいインスタンスを生成する
        /// </summary>
        public LineNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(4);
        }

        internal override void Draw() => Engine.Renderer.DrawPolygon(renderedPolygon);

        internal override void UpdateInheritedTransform()
        {
            var array = renderedPolygon.Vertexes;
            MathHelper.GetMinMax(out var min, out var max, array);
            var size = max - min;

            var mat = new Matrix44F();
            switch (Mode)
            {
                case DrawMode.Fill:
                    mat = Matrix44F.GetScale2D(Size / size);
                    break;
                case DrawMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > size.X / size.Y)
                        scale.X = size.X * Size.Y / size.Y;
                    else
                        scale.Y = size.Y * Size.X / size.X;

                    scale /= size;

                    mat = Matrix44F.GetScale2D(scale);
                    break;
                case DrawMode.Absolute:
                    mat = Matrix44F.Identity;
                    break;
                default:
                    break;
            }
            mat *= Matrix44F.GetTranslation2D(-min);

            renderedPolygon.Transform = CalcInheritedTransform() * mat;
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

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
