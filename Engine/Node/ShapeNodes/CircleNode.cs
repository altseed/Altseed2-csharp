using System;
using System.Buffers;

namespace Altseed2
{
    /// <summary>
    /// 円を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class CircleNode : ShapeNode
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
        private float _Radius = 1.0f;

        /// <summary>
        /// 頂点の個数を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentException">設定しようとした値が 3 未満</exception>
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
        /// <see cref="CircleNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public CircleNode() { }

        private void UpdateVertexes()
        {
            var deg = MathF.PI * 2f / _VertNum;

            Span<Vector2F> positions = _VertNum <= Engine.MaxStackalloclLength ? stackalloc Vector2F[_VertNum] : Engine.Vector2FBuffer.GetAsSpan(_VertNum);
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
