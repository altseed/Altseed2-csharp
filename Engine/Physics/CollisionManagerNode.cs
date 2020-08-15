using System;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 衝突判定を制御するノード
    /// </summary>
    [Serializable]
    public class CollisionManagerNode : Node
    {
        private readonly CollisionCollection collisionCollection = new CollisionCollection();

        /// <summary>
        /// 格納されているコライダの個数を取得します。
        /// </summary>
        public int ColliderCount => collisionCollection.Count;

        /// <summary>
        /// 登録されているコライダを取得します。
        /// </summary>
        public IEnumerable<ColliderNode> Colliders => collisionCollection;

        /// <summary>
        /// <see cref="CollisionManagerNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public CollisionManagerNode() { }

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>が格納されているかどうかを返します。
        /// </summary>
        /// <param name="node">検索する<see cref="ColliderNode"/></param>
        /// <returns><paramref name="node"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool ContainsCollider(ColliderNode node) => collisionCollection.Contains(node);

        internal static IEnumerable<ColliderNode> EnumerateColliderNodes(Node node)
        {
            foreach (var current in node._Children.CurrentCollection)
                if (current is ColliderNode n)
                    yield return n;
        }

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
            foreach (var child in owner._Children.CurrentCollection)
            {
                if (child != this && child is CollisionManagerNode) throw new InvalidOperationException("既に衝突判定マネージャが格納されており，追加する事が出来ません");
                foreach (var node in EnumerateColliderNodes(child))
                    AddCollider(node);
            }
            base.Added(owner);
        }

        internal override void Removed()
        {
            foreach (var child in Parent._Children.CurrentCollection)
                foreach (var node in EnumerateColliderNodes(child))
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
