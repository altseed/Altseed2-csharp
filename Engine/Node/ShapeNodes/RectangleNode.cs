using System;

namespace Altseed2
{
    /// <summary>
    /// 短形を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class RectangleNode : PolygonNode
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
        /// 短形のサイズを取得または設定します。
        /// </summary>
        public Vector2F RectangleSize
        {
            get => _RectangleSize;
            set
            {
                if (_RectangleSize == value) return;
                _RectangleSize = value;
                changed = true;
            }
        }
        private Vector2F _RectangleSize = new Vector2F();

        public override void AdjustSize()
        {
            Size = RectangleSize;
        }

        /// <summary>
        /// <see cref="RectangleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleNode()
        {
            _RenderedPolygon.Vertexes = VertexArray.Create(4);
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
            var positions = new Vector2F[4];
            positions[0] = new Vector2F(0.0f, 0.0f);
            positions[1] = new Vector2F(0.0f, RectangleSize.Y);
            positions[2] = new Vector2F(RectangleSize.X, RectangleSize.Y);
            positions[3] = new Vector2F(RectangleSize.X, 0.0f);
            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(_color);
         
            if (IsAutoAdjustSize) AdjustSize();
        }
    }
}
