using System;

namespace Altseed2
{
    /// <summary>
    /// コライダを管理するノード
    /// </summary>
    [Serializable]
    public abstract class ColliderNode : TransformNode
    {
        /// <summary>
        /// コライダを取得する
        /// </summary>
        internal abstract Collider Collider { get; }

        internal int _Version { get; private set; }

        /// <summary>
        /// <see cref="ColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        private protected ColliderNode() { }

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

        private protected void UpdateVersion()
        {
            _Version++;
        }
    }
}
