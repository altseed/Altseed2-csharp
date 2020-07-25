using System;

namespace Altseed2
{
    /// <summary>
    /// 短形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class RectangleNode : PolygonNode
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

        internal void UpdateInheritedTransform()
        {
            if (_RequireUpdateVertexes)
            {
                UpdateVertexes();
                _RequireUpdateVertexes = false;
            }

            var array = _RenderedPolygon.Vertexes;
            MathHelper.GetMinMax(out var min, out var max, array);
            var size = max - min;

            var mat = new Matrix44F();
            switch (ScalingMode)
            {
                case ScalingMode.Fill:
                    mat = Matrix44F.GetScale2D(Size / size);
                    break;
                case ScalingMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > size.X / size.Y)
                        scale.X = size.X * Size.Y / size.Y;
                    else
                        scale.Y = size.Y * Size.X / size.X;

                    scale /= size;

                    mat = Matrix44F.GetScale2D(scale);
                    break;
                case ScalingMode.Manual:
                    mat = Matrix44F.Identity;
                    break;
                default:
                    break;
            }
            mat *= Matrix44F.GetTranslation2D(-min);

        }

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
