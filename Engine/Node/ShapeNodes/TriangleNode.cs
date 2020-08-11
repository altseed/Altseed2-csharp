using System;

namespace Altseed2
{
    /// <summary>
    /// 三角形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class TriangleNode : ShapeNode
    {
        private bool _RequireUpdateVertexes = false;
        private Vector2F[] _Points;

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
        /// 頂点1を取得または設定します。
        /// </summary>
        public Vector2F Point1
        {
            get => _Points[0];
            set
            {
                if (_Points[0] == value) return;

                _Points[0] = value;
                _RequireUpdateVertexes = true;
            }
        }

        /// <summary>
        /// 頂点2を取得または設定します。
        /// </summary>
        public Vector2F Point2
        {
            get => _Points[1];
            set
            {
                if (_Points[1] == value) return;

                _Points[1] = value;
                _RequireUpdateVertexes = true;
            }
        }

        /// <summary>
        /// 頂点3を取得または設定します。
        /// </summary>
        public Vector2F Point3
        {
            get => _Points[2];
            set
            {
                if (_Points[2] == value) return;
                _Points[2] = value;
                _RequireUpdateVertexes = true;
            }
        }

        /// <summary>
        /// <see cref="TriangleNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public TriangleNode()
        {
            _Points = new Vector2F[3];
        }

        private void UpdateVertexes()
        {
            SetVertexes(_Points, Color);
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
