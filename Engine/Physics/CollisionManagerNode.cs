using System;
using System.Collections.Generic;

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
        /// 格納されているコライダの個数を取得する
        /// </summary>
        public int ColliderCount => collisionCollection.Count;

        /// <summary>
        /// 登録されているコライダを取得する
        /// </summary>
        public IEnumerable<ColliderNode> Colliders => collisionCollection;

        /// <summary>
        /// <see cref="CollisionManagerNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CollisionManagerNode() { }

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>が格納されているかどうかを返す
        /// </summary>
        /// <param name="node">検索する<see cref="ColliderNode"/></param>
        /// <returns><paramref name="node"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool ContainsCollider(ColliderNode node) => collisionCollection.Contains(node);

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
