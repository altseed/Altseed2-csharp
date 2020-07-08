using System;

namespace Altseed2
{
    /// <summary>
    /// 短形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class RectangleColliderNode : ColliderNode
    {
        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        public RectangleCollider RectangleCollider { get; }
        internal override Collider Collider => RectangleCollider;

        /// <summary>
        /// 既定の<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleColliderNode() : this(new RectangleCollider()) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.RectangleCollider"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="collider"/>がnull</exception>
        public RectangleColliderNode(RectangleCollider collider)
        {
            RectangleCollider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");
        }

        public override void AdjustSize() { }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = Size * scale;
        }
    }
}
