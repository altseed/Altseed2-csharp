using System;

namespace Altseed2
{
    /// <summary>
    /// 円弧を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class ArcNode : ShapeNode
    {
        private bool _RequireUpdateVertexes = true;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _Color;
            set
            {
                if (_Color == value) return;
                _Color = value;
                OverwriteVertexColor(value);
            }
        }
        private Color _Color = new Color(255, 255, 255);

        /// <summary>
        /// 描画を終了する角度を取得または設定します。
        /// </summary>
        public float EndDegree
        {
            get => _EndDegree;
            set
            {
                if (_EndDegree == value) return;

                _EndDegree = Math.Abs(_StartDegree - value) == 360f ? value : value % 360f;
                _RequireUpdateVertexes = true;
            }
        }
        private float _EndDegree = 360f;

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
                _RequireUpdateVertexes = true;
            }
        }
        private float _radius = 1.0f;

        /// <summary>
        /// 描画を開始する頂点を取得または設定します。
        /// </summary>
        public float StartDegree
        {
            get => _StartDegree;
            set
            {
                if (_StartDegree == value) return;

                _StartDegree = Math.Abs(_EndDegree - value) == 360f ? value : value % 360f;
                _RequireUpdateVertexes = true;
            }
        }
        private float _StartDegree = 0.0f;

        /// <summary>
        /// 頂点の個数を取得または設定します。
        /// </summary>
        public int VertNum
        {
            get => _VertNum;
            set
            {
                if (value < 3) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が3未満です\n実際の値：{value}");

                if (_VertNum == value) return;
                _VertNum = value;
                _RequireUpdateVertexes = true;
            }
        }
        private int _VertNum = 3;

        /// <summary>
        /// <see cref="ArcNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public ArcNode() { }

        private Vector2F GetBaseVector(float degree)
        {
            var result = new Vector2F(0.0f, -_radius);
            result.Degree += degree;
            return result;
        }

        private void GetDegrees(out float min, out float max)
        {
            if (_StartDegree == _EndDegree)
            {
                min = max = _StartDegree;
                return;
            }
            if (_StartDegree < _EndDegree)
            {
                min = _StartDegree;
                max = _EndDegree;
            }
            else
            {
                min = _EndDegree;
                max = _StartDegree;
            }
            if (min < 0 && _StartDegree * _EndDegree > 0)
            {
                min += 360f;
                max += 360f;
            }
            if (max - min > 360f) max -= 360f;
        }

        private void UpdateVertexes()
        {
            // local arguments for position calculation
            GetDegrees(out var _startdegree, out var _enddegree);
            var deg = 360f / _VertNum;
            var size = (int)(Math.Abs(_enddegree - _startdegree) / deg);
            var startVertexNum = (int)MathF.Ceiling(_startdegree / deg);
            var endVertexNum = (int)MathF.Floor(_enddegree / deg);
            var startMatched = startVertexNum * deg == _startdegree;
            var endMatched = endVertexNum * deg == _enddegree;
            if (!startMatched) size++;
            if (!endMatched) size++;

            // local arguments for UV calculation
            var diameter = _radius * 2;
            if (diameter == 0) diameter = 1f; // to avoid dividing by Zero
            var upperLeftPos = -new Vector2F(_radius, _radius);

            Span<Vertex> vertexes = size + 2 <= Engine.MaxStackalloclLength ? stackalloc Vertex[size + 2] : Engine.VertexBuffer.GetAsSpan(size + 2);
            var currentIndex = 1;
            if (!startMatched) vertexes[currentIndex++].Position = To3F(GetBaseVector(_startdegree));
            var vec = GetBaseVector(deg * startVertexNum);
            for (var i = startVertexNum; i <= endVertexNum; currentIndex++, i++)
            {
                vertexes[currentIndex].Position = To3F(vec);
                vec.Degree += deg;
            }

            if (!endMatched) vertexes[currentIndex].Position = To3F(GetBaseVector(_enddegree));

            for (int i = 0; i < vertexes.Length; i++)
            {
                vertexes[i].Color = Color;
                vertexes[i].UV1 = new Vector2F(vertexes[i].Position.X - upperLeftPos.X, vertexes[i].Position.Y - upperLeftPos.Y) / diameter;
            }

            SetVertexes(vertexes);

            static Vector3F To3F(Vector2F vector) => new Vector3F(vector.X, vector.Y, 0.5f);
        }

        internal override void Update()
        {
            if (_RequireUpdateVertexes)
            {
                UpdateVertexes();
                _RequireUpdateVertexes = false;
            }

            base.Update();
        }
    }
}
