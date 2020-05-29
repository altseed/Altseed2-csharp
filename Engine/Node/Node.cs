using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        /// <summary>
        /// 更新
        /// </summary>
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

        /// <summary>
        /// 親ノードを取得または設定します。
        /// </summary>
        public Node Parent { get; private set; }

        private Node _ParentReserved;

        /// <summary>
        /// <paramref name="owner"/> に登録された際の処理
        /// </summary>
        /// <param name="owner"></param>
        internal override void Added(Node owner)
        {
            Parent = owner;

            for (var n = Parent; ; n = n.Parent)
            {
                if (n == null) return;
                if (n is RootNode) break;
            }
            Registered();
        }

        /// <summary>
        /// 親要素から削除されたときの処理
        /// </summary>
        internal override void Removed()
        {
            Parent = null;

            Unregistered();
        }

        /// <summary>
        /// エンジンに登録され、木を辿って<see cref="RootNode"/> にたどり着けるようになったとき実行
        /// </summary>
        protected internal virtual void Registered()
        {
            foreach (var c in Children)
            {
                c.Registered();
            }

            OnAdded();
        }

        /// <summary>
        /// エンジンから削除され、木を辿って<see cref="RootNode"/> にたどり着けなくなったとき実行
        /// </summary>
        protected internal virtual void Unregistered()
        {
            foreach (var c in Children)
            {
                c.Unregistered();
            }

            OnRemoved();
        }

        #endregion

        #region Registerable (親として)

        private readonly RegisterableCollection<Node, Node> _Children;

        /// <summary>
        /// 子要素のコレクションを取得します。
        /// </summary>
        public ReadOnlyCollection<Node> Children { get; }

        /// <summary>
        /// 子要素を追加します。
        /// </summary>
        /// <param name="node">追加する要素</param>
        public void AddChildNode(Node node)
        {
            if (node.Status == RegisterStatus.WaitRemoved && node.Parent == this)
                node.Status = RegisterStatus.Registered;

            _Children.Add(node);
            node._ParentReserved = this;
        }

        /// <summary>
        /// 子要素を削除します。
        /// </summary>
        /// <param name="node">削除する要素</param>
        public void RemoveChildNode(Node node)
        {
            if (node.Status == RegisterStatus.WaitAdded && node._ParentReserved == this)
                node.Status = RegisterStatus.Registered;

            _Children.Remove(node);
            node._ParentReserved = null;
        }

        #endregion

        #region 仮想メソッド

        /// <summary>
        /// エンジンに追加された時に実行します。
        /// </summary>
        /// <remarks>
        /// 自身もしくは親ノードがEngineに登録されたあとのUpdateの際に実行されます。
        /// </remarks>
        protected virtual void OnAdded() { }

        /// <summary>
        /// エンジンから削除された時に実行
        /// </summary>
        /// <remarks>
        /// 自身もしくは親ノードがEngineにから削除されたあとのUpdateの際に実行されます。
        /// </remarks>
        protected virtual void OnRemoved() { }

        /// <summary>
        /// 自身が更新された時に実行
        /// </summary>
        protected virtual void OnUpdate() { }

        #endregion

        /// <summary>
        /// 先祖ノードを列挙します。
        /// </summary>
        public IEnumerable<Node> EnumerateAncestors()
        {
            var current = Parent;
            for (var n = Parent; current != null && !(current is RootNode); current = current.Parent)
                yield return current;

            yield break;
        }

        /// <summary>
        /// 子孫ノードを列挙します。
        /// </summary>
        public IEnumerable<Node> EnumerateDescendants()
        {
            foreach (var c in Children)
            {
                yield return c;
                foreach (var g in c.EnumerateDescendants())
                    yield return g;
            }
        }

        /// <summary>
        /// <typeparamref name="T"/> 型の子孫ノードを列挙します。
        /// </summary>
        public IEnumerable<T> EnumerateDescendants<T>()
             where T : Node
        {
            return EnumerateDescendants<T>(null);
        }

        /// <summary>
        /// <typeparamref name="T"/>型の子孫ノードのうち <paramref name="condition"/> を満たすものを列挙します。
        /// </summary>
        public IEnumerable<T> EnumerateDescendants<T>(Func<T, bool> condition)
            where T : Node
        {
            foreach (var child in Children)
            {
                foreach (var g in child.EnumerateDescendants<T>(condition))
                    yield return g;

                if (child is T c)
                    yield return c;
            }
        }
    }
}
