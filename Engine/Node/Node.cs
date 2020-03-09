using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Altseed
{
    /// <summary>
    /// ゲームシーンを構成するノードを表します。
    /// </summary>
    [Serializable]
    public class Node : Registerable<Node>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Node()
        {
            _Children = new RegisterableCollection<Node, Node>(this);
            Children = _Children.AsReadOnly();
        }

        internal virtual void Update()
        {
            OnUpdate();

            _Children.Update();
            foreach (var c in Children)
            {
                c.Update();
            }
        }

        #region Registerable (子として)

        public Node Parent { get; private set; }

        internal override void Added(Node owner)
        {
            Parent = owner;
            OnAdded();
        }

        internal override void Removed()
        {
            Parent = null;
            OnRemoved();
        }

        #endregion

        #region Registerable (親として)

        private RegisterableCollection<Node, Node> _Children;
        public ReadOnlyCollection<Node> Children { get; }

        public virtual void AddChildNode(Node node)
        {
            _Children.Add(node);
        }

        public virtual void RemoveChildNode(Node node)
        {
            _Children.Remove(node);
        }

        #endregion

        #region 仮想メソッド

        protected virtual void OnAdded() { }

        protected virtual void OnRemoved() { }

        protected virtual void OnUpdate() { }


        #endregion

        /// <summary>
        /// 先祖ノードを列挙します。
        /// </summary>
        public IEnumerable<Node> EnumerateAncestor()
        {
            var current = Parent;
            for (var n = Parent; current != null && !(current is RootNode); current = current.Parent)
                yield return current;

            yield break;
        }
    }
}
