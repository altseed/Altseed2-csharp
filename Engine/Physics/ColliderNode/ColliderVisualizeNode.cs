using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="ColliderNode"/>の当たり判定範囲として描画されるノードの基底クラス
    /// </summary>
    [Serializable]
    public class ColliderVisualizeNode : DrawnNode
    {
        public override Matrix44F AbsoluteTransform => RenderedPolygon.Transform;

        internal override int CullingId => RenderedPolygon.Id;

        internal RenderedPolygon RenderedPolygon { get; } = RenderedPolygon.Create();

        internal ColliderVisualizeNode(RenderedPolygon renderedPolygon)
        {
            RenderedPolygon = renderedPolygon;
        }

        internal override void Draw()
        {
            Engine.Renderer.DrawPolygon(RenderedPolygon);
        }

        internal override void UpdateInheritedTransform() { }
    }
}
