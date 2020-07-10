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

        /// <summary>
        /// アンカーを取得します。
        /// </summary>
        public override Vector2F AnchorMax => base.AnchorMax;

        /// <summary>
        /// アンカーを取得します。
        /// </summary>
        public override Vector2F AnchorMin => base.AnchorMin;

        /// <summary>
        /// 角度(度数法)を取得します。
        /// </summary>
        public override float Angle => base.Angle;

        /// <summary>
        /// 回転の中心となる座標をピクセル単位で取得します。
        /// </summary>
        public override Vector2F CenterPosition => base.CenterPosition;

        internal override int CullingId => RenderedPolygon.Id;

        /// <summary>
        /// 左右を反転するかどうかを取得します。
        /// </summary>
        public override bool HorizontalFlip => base.HorizontalFlip;

        /// <summary>
        /// 回転の中心となる座標を[0,1]で取得します。
        /// </summary>

        public override Vector2F Pivot => base.Pivot;

        /// <summary>
        /// 座標を取得します。
        /// </summary>
        public override Vector2F Position => base.Position;

        internal RenderedPolygon RenderedPolygon { get; } = RenderedPolygon.Create();

        /// <summary>
        /// 拡大率を取得します。
        /// </summary>
        public override Vector2F Scale => base.Scale;

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public override Vector2F Size => base.Size;

        internal override Matrix44F Transform => RenderedPolygon.Transform;

        /// <summary>
        /// 上下を反転するかどうかを取得します。
        /// </summary>
        public override bool VerticalFlip => base.VerticalFlip;

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
