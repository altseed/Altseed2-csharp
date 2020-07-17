using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="ColliderNode"/>の当たり判定範囲として描画されるノードの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ColliderVisualizeNode : DrawnNode
    {
        public override Matrix44F AbsoluteTransform => RenderedPolygon.Transform;

        internal override int CullingId => RenderedPolygon.Id;

        /// <summary>
        /// 描画モードを取得または設定します。
        /// </summary>
        public DrawMode Mode { get; set; } = DrawMode.Absolute;

        internal RenderedPolygon RenderedPolygon { get; } = RenderedPolygon.Create();

        private protected ColliderVisualizeNode() { }

        internal override void Draw()
        {
            Engine.Renderer.DrawPolygon(RenderedPolygon);
        }

        internal abstract void UpdatePolygon();

        internal override void UpdateInheritedTransform()
        {
            var array = RenderedPolygon.Vertexes;
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
            RenderedPolygon.Transform = CalcInheritedTransform() * mat;
        }
    }
}
