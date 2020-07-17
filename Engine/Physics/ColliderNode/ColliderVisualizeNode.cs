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

        internal RenderedPolygon RenderedPolygon { get; } = RenderedPolygon.Create();

        private protected ColliderVisualizeNode() { }

        internal override void Draw()
        {
            Engine.Renderer.DrawPolygon(RenderedPolygon);
        }

        internal abstract void UpdatePolygon();
    }
}
