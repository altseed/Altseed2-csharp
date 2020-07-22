using System;

namespace Altseed2
{
    /// <summary>
    /// 三角形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class TriangleNode : PolygonNode
    {
        private bool changed = false;

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
                _RenderedPolygon.OverwriteVertexesColor(value);
            }
        }
        private Color _color = new Color(255, 255, 255);

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

        public override void AdjustSize()
        {
            var array = new Vector2F[3]
            {
                Point1,
                Point2,
                Point3
            };

            MathHelper.GetMinMax(out var min, out var max, array);
            Size = max - min;
        }

        /// <summary>
        /// <see cref="TriangleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public TriangleNode()
        {
            _RenderedPolygon.Vertexes = VertexArray.Create(3);
        }

        internal override void Update()
        {
            base.Update();
            UpdateInheritedTransform();//仮
        }

        internal override void UpdateInheritedTransform()
        {
            if (changed)
            {
                UpdateVertexes();
                if (IsAutoAdjustSize) AdjustSize();
                changed = false;
            }

            var array = _RenderedPolygon.Vertexes;
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

            _RenderedPolygon.Transform = CalcInheritedTransform() * mat;
        }

        private void UpdateVertexes()
        {
            var positions = new Vector2F[3];
            positions[0] = _point1;
            positions[1] = _point2;
            positions[2] = _point3;

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
