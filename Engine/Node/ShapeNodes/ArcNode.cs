using System;

namespace Altseed2
{
    /// <summary>
    /// 円弧を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class ArcNode : PolygonNode
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
        /// 描画を終了する角度を取得または設定します。
        /// </summary>
        public float EndDegree
        {
            get => _enddegree;
            set
            {
                if (_enddegree == value) return;
                _enddegree = Math.Abs(_startdegree - value) == 360f ? value : value % 360f;
                changed = true;
            }
        }
        private float _enddegree = 360f;

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
        /// 描画を開始する頂点を取得または設定します。
        /// </summary>
        public float StartDegree
        {
            get => _startdegree;
            set
            {
                if (_startdegree == value) return;
                _startdegree = Math.Abs(_enddegree - value) == 360f ? value : value % 360f;
                changed = true;
            }
        }
        private float _startdegree = 0.0f;

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
        /// <see cref="ArcNode"/>の新しいインスタンスを生成する
        /// </summary>
        public ArcNode()
        {
            _RenderedPolygon.Vertexes = VertexArray.Create(_vertnum);
        }

        public override void AdjustSize()
        {
            var length = _radius * 2;
            Size = new Vector2F(length, length);
        }

        private Vector2F GetBaseVector(float degree)
        {
            var result = new Vector2F(0.0f, -_radius);
            result.Degree += degree;
            return result;
        }

        private void GetDegrees(out float min, out float max)
        {
            if (_startdegree == _enddegree)
            {
                min = max = _startdegree;
                return;
            }
            if (_startdegree < _enddegree)
            {
                min = _startdegree;
                max = _enddegree;
            }
            else
            {
                min = _enddegree;
                max = _startdegree;
            }
            if (min < 0 && _startdegree * _enddegree > 0)
            {
                min += 360f;
                max += 360f;
            }
            if (max - min > 360f) max -= 360f;
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

            _RenderedPolygon.Transform = CalcInheritedTransform() * mat;
        }

        private void UpdateVertexes()
        {
            GetDegrees(out var _startdegree, out var _enddegree);
            var deg = 360f / _vertnum;
            var size = (int)(Math.Abs(_enddegree - _startdegree) / deg);
            var startVertexNum = (int)MathF.Ceiling(_startdegree / deg);
            var endVertexNum = (int)MathF.Floor(_enddegree / deg);
            var startMatched = startVertexNum * deg == _startdegree;
            var endMatched = endVertexNum * deg == _enddegree;
            if (!startMatched) size++;
            if (!endMatched) size++;
            var positions = new Vector2F[size + 2];
            var currentIndex = 1;
            if (!startMatched) positions[currentIndex++] = GetBaseVector(_startdegree);
            var vec = GetBaseVector(deg * startVertexNum);
            for (var i = startVertexNum; i <= endVertexNum; currentIndex++, i++)
            {
                positions[currentIndex] = vec;
                vec.Degree += deg;
            }

            if (!endMatched) positions[currentIndex] = GetBaseVector(_enddegree);

            var rad = new Vector2F(Radius, Radius);
            for (int i = 0; i < positions.Length; i++) positions[i] += rad;

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(Color);

            if (IsAutoAdjustSize) AdjustSize();
        }
    }
}
