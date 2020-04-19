using System;

namespace Altseed
{
    /// <summary>
    /// コライダを管理するノード
    /// </summary>
    [Serializable]
    public class ColliderNode : Node
    {
        /// <summary>
        /// コライダを取得する
        /// </summary>
        public Collider Collider { get; }

        /// <summary>
        /// 指定した<see cref="Altseed.Collider"/>を持つ<see cref="ColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">登録するコライダ</param>
        /// <exception cref="ArgumentException"><paramref name="collider"/>が既に別の<see cref="ColliderNode"/>に所属している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="collider"/>がnull</exception>
        public ColliderNode(Collider collider)
        {
            Collider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");
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
    }
}
