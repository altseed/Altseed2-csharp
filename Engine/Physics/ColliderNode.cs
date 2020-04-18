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
        public Collider Collider
        {
            get => _collider;
            private set
            {
                if (_collider == value) return;
                if (value.Owner != null) throw new ArgumentException("既にほかノードに所属しています", nameof(value));
                if (_collider != null) _collider.Owner = null;
                value.Owner = this;
                _collider = value;
            }
        }
        private Collider _collider;

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

        internal override void Added(Node owner)
        {
            base.Added(owner);
            Parent.Parent?.SearchManager()?.AddCollider(this);
        }

        internal override void Removed()
        {
            Parent.Parent?.SearchManager()?.RemoveCollider(this);
            base.Removed();
        }
    }
}
