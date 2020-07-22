using System;

namespace Altseed2
{
    /// <summary>
    /// 円を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class CircleNode : PolygonNode
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
        /// 半径を取得または設定します。
        /// </summary>
        public float Radius
        {
            get => _radius;
            set
            {
                if (_radius == value) return;
                _radius = value;
                changed = true;
                AdjustSize();
            }
        }
        private float _radius;

        /// <summary>
        /// 頂点の個数を取得または設定します。
        /// </summary>
        public int VertNum
        {
            get => _vertnum;
            set
            {
                if (value < 3) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が3未満です\n実際の値：{value}");
                if (_vertnum == value) return;
                _vertnum = value;
                changed = true;
            }
        }
        private int _vertnum = 3;

        /// <summary>
        /// <see cref="CircleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CircleNode()
        {
            _RenderedPolygon.Vertexes = VertexArray.Create(_vertnum);
        }

        public override void AdjustSize()
        {
            var length = _radius * 2;
            Size = new Vector2F(length, length);
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
            var deg = 360f / _vertnum;
            var positions = new Vector2F[_vertnum];
            var vec = new Vector2F(0.0f, -_radius);

            var rad = new Vector2F(Radius, Radius);
            for (int i = 0; i < _vertnum; i++)
            {
                positions[i] = vec;
                vec.Degree += deg;
                positions[i] += rad;
            }

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(_color);

            if (IsAutoAdjustSize) AdjustSize();
        }
    }
}
