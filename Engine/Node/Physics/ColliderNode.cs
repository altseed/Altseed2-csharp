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
        /// コライダを取得します。
        /// </summary>
        internal abstract Collider Collider { get; }

        internal int _Version { get; private set; }

        /// <summary>
        /// <see cref="ColliderNode"/>の新しいインスタンスを生成します。
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

        private protected static Vector2F CalcScale(Matrix44F transform)
        {
            var sx = new Vector3F(transform[0, 0], transform[0, 1], transform[0, 2]).Length;
            var sy = new Vector3F(transform[1, 0], transform[1, 1], transform[1, 2]).Length;
            return new Vector2F(sx, sy);
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
