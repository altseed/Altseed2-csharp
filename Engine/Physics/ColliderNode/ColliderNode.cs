using System;

namespace Altseed2
{
    /// <summary>
    /// コライダを管理するノード
    /// </summary>
    [Serializable]
    public abstract class ColliderNode : TransformNode
    {
        internal readonly static Color AreaColor = new Color(255, 100, 100, 100);

        public override Matrix44F AbsoluteTransform => _absoluteTransform;
        private Matrix44F _absoluteTransform;

        /// <summary>
        /// コライダを取得する
        /// </summary>
        internal abstract Collider Collider { get; }

        /// <summary>
        /// <see cref="ColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        private protected ColliderNode() { }

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
                CircleColliderNode c => new CircleColliderNode.CircleColliderVisualizeNode(c),
                PolygonColliderNode p => new PolygonColliderNode.PolygonColliderVisualizeNode(p),
                RectangleColliderNode r => new RectangleColliderNode.RectangleColliderVisualizeNode(r),
                _ => throw new ArgumentException($"サポートされていない型です\n型：{colliderNode.GetType()}", nameof(colliderNode))
            };
        }

        private static CollisionManagerNode SearchManagerFromChildren(Node node)
        {
            if (node == null) return null;
            foreach (var current in node.Children)
                if (current is CollisionManagerNode m)
                    return m;
            return null;
        }

        internal override void Added(Node owner)
        {
            base.Added(owner);
            SearchManagerFromChildren(owner.Parent)?.AddCollider(this);
        }

        internal override void Removed()
        {
            SearchManagerFromChildren(Parent.Parent)?.RemoveCollider(this);
            base.Removed();
        }

        internal abstract void UpdateCollider();

        internal override void UpdateInheritedTransform()
        {
            _absoluteTransform = CalcInheritedTransform();
        }
    }
}
