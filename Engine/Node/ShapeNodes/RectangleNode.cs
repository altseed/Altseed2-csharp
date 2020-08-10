using System;

namespace Altseed2
{
    /// <summary>
    /// 短形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class RectangleNode : ShapeNode
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
                _RenderedPolygon.OverwriteVertexesColor(value);
            }
        }
        private Color _Color = new Color(255, 255, 255);

        /// <summary>
        /// 短形のサイズを取得または設定します。
        /// </summary>
        public Vector2F RectangleSize
        {
            get => _RectangleSize;
            set
            {
                if (_RectangleSize == value) return;

                _RectangleSize = value;
                _RequireUpdateVertexes = true;
            }
        }
        private Vector2F _RectangleSize = new Vector2F();

        /// <summary>
        /// <see cref="RectangleNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public RectangleNode() { }

        private void UpdateVertexes()
        {
            var positions = new Vector2F[4];
            positions[0] = new Vector2F(0.0f, 0.0f);
            positions[1] = new Vector2F(0.0f, RectangleSize.Y);
            positions[2] = new Vector2F(RectangleSize.X, RectangleSize.Y);
            positions[3] = new Vector2F(RectangleSize.X, 0.0f);

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
