using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="ColliderNode"/>の当たり判定範囲として描画されるノードの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ColliderVisualizeNode : DrawnNode
    {
        internal readonly static Color AreaColor = new Color(255, 100, 100, 100);

        public override Matrix44F AbsoluteTransform => RenderedPolygon.Transform;

        internal override int CullingId => RenderedPolygon.Id;

        /// <summary>
        /// 描画モードを取得または設定します。
        /// </summary>
        public DrawMode Mode { get; set; } = DrawMode.Absolute;

        internal RenderedPolygon RenderedPolygon { get; } = RenderedPolygon.Create();

        private protected ColliderVisualizeNode() { }

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>の当たり判定領域を表示するノードを生成する
        /// </summary>
        /// <param name="colliderNode">使用するコライダノード</param>
        /// <exception cref="ArgumentNullException"><paramref name="colliderNode"/>がnull</exception>
        /// <returns><paramref name="colliderNode"/>の当たり当たり領域を表示するノード</returns>
        public static ColliderVisualizeNode CreateVisualizeNode(ColliderNode colliderNode)
        {
            if (colliderNode == null) throw new ArgumentNullException(nameof(colliderNode), "引数がnullです");
            return colliderNode switch
            {
                CircleColliderNode c => new CircleColliderVisualizeNode(c),
                PolygonColliderNode p => new PolygonColliderVisualizeNode(p),
                RectangleColliderNode r => new RectangleColliderVisualizeNode(r),
                _ => throw new ArgumentException($"サポートされていない型です\n型：{colliderNode.GetType()}", nameof(colliderNode))
            };
        }

        internal override void Draw()
        {
            Engine.Renderer.DrawPolygon(RenderedPolygon);
        }

        private protected abstract void UpdatePolygon();

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
