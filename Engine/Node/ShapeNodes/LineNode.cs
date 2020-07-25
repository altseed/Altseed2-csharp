using System;

namespace Altseed2
{
    /// <summary>
    /// 直線を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class LineNode : PolygonNode
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
        /// 描画の始点を取得または設定します。
        /// </summary>
        public Vector2F Point1
        {
            get => _Point1;
            set
            {
                if (_Point1 == value) return;

                _Point1 = value;
                _RequireUpdateVertexes = true;
            }
        }
        private Vector2F _Point1;

        /// <summary>
        /// 描画の終点を取得または設定します。
        /// </summary>
        public Vector2F Point2
        {
            get => _Point2;
            set
            {
                if (_Point2 == value) return;

                _Point2 = value;
                _RequireUpdateVertexes = true;
            }
        }
        private Vector2F _Point2;

        /// <summary>
        /// 直線の太さを取得または設定します。
        /// </summary>
        public float Thickness
        {
            get => _Thickness;
            set
            {
                if (_Thickness == value) return;

                _Thickness = value;
                _RequireUpdateVertexes = true;
            }
        }
        private float _Thickness;

        private void UpdateVertexes()
        {
            var positions = new Vector2F[4];
            var vec = _Point2 - _Point1;

            var side = new Vector2F(vec.Y, -vec.X).Normal * Thickness / 2f;

            positions[0] = _Point1 - side;
            positions[1] = _Point1 + side;
            positions[2] = _Point2 + side;
            positions[3] = _Point2 - side;

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
