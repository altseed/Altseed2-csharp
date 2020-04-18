using System;

namespace Altseed
{
    /// <summary>
    /// 衝突判定を制御ノード
    /// </summary>
    [Serializable]
    public class CollisionManagerNode : Node
    {
        private readonly CollisionCollection collisionCollection = new CollisionCollection();

        /// <summary>
        /// <see cref="CollisionManagerNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CollisionManagerNode() { }

        internal void AddCollider(ColliderNode node)
        {
            collisionCollection.Add(node);
        }

        internal void RemoveCollider(ColliderNode node)
        {
            collisionCollection.Remove(node);
        }

        internal override void Added(Node owner)
        {
            foreach (var child in owner.Children)
                foreach (var node in child.EnumerateColliderNodes())
                    AddCollider(node);
            base.Added(owner);
        }

        internal override void Removed()
        {
            foreach (var child in Parent.Children)
                foreach (var node in child.EnumerateColliderNodes())
                    RemoveCollider(node);
            base.Removed();
        }

        internal override void Update()
        {
            base.Update();

            collisionCollection.Update();
        }
    }
}
