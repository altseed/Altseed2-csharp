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
        /// 衝突判定が行われる範囲を描画するノードを取得します
        /// </summary>
        public RectangleNode CollisionArea => _collisionArea ??= CreateShapeNode();
        private RectangleNode _collisionArea;
        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        public RectangleCollider RectangleCollider { get; }
        internal override Collider Collider => RectangleCollider;

        public override Vector2F Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                if (_collisionArea != null) _collisionArea.Size = Size;
            }
        }

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

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = Size * scale;
        }

        public override void AdjustSize() { }

        private RectangleNode CreateShapeNode()
        {
            var result = new RectangleNode()
            {
                Color = AreaColor,
                Size = Size
            };
            var anc = GetAncestorSpecificNode<DrawnNode>();
            if (anc != null) result.ZOrder = anc.ZOrder;
            return result;
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = Size * scale;
        }

        internal override void Update()
        {
            base.Update();

            if (_collisionArea == null) return;
            var anc = GetAncestorSpecificNode<DrawnNode>();
            if (anc != null) _collisionArea.ZOrder = anc.ZOrder;
        }
    }
}
