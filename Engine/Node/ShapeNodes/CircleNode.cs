using System;

namespace Altseed2
{
    /// <summary>
    /// 円を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class CircleNode : PolygonNode
    {
        private bool _RequireUpdateVertexes = false;

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
        /// 半径を取得または設定します。
        /// </summary>
        public float Radius
        {
            get => _Radius;
            set
            {
                if (_Radius == value) return;

                _Radius = value;
                _RequireUpdateVertexes = true;
            }
        }
        private float _Radius;

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

        private void UpdateVertexes()
        {
            var deg = 360f / _VertNum;
            var positions = new Vector2F[_VertNum];

            for (int i = 0; i < _VertNum; i++)
            {
                positions[i] = new Vector2F(MathF.Cos(deg * i), MathF.Sin(deg * i)) * Radius;
            }

            SetVertexes(positions, Color);
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
