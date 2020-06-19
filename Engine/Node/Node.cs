using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

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
        public Node Parent { get => _parent; private set { _parent = value; } }
        [NonSerialized]
        private Node _parent;

        public override RegisterStatus Status { get => _status; internal set { _status = value; } }
        [NonSerialized]
        private RegisterStatus _status;

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
        internal virtual void Registered()
        {
            if (surpressing)
            {
                surpressing = false;
                return;
            }

            foreach (var c in Children)
            {
                c.Registered();
            }

            OnAdded();
        }

        /// <summary>
        /// エンジンから削除され、木を辿って<see cref="RootNode"/> にたどり着けなくなったとき実行
        /// </summary>
        internal virtual void Unregistered()
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
        public ReadOnlyCollection<Node> Children => _readonlyChildren ??= _Children.AsReadOnly();
        [NonSerialized]
        private ReadOnlyCollection<Node> _readonlyChildren;

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

        #region Serialization
        // 
        // Rootはシリアライズしない
        // 親がRootだった場合は親無しとしてシリアライズし，デシリアライズ時にEngine.AddNode(this)を実行する
        //

        private Node serialization_Parent;
        private RegisterStatus serialization_Status;
        private bool isRootChild;
        private bool surpressing; // デシリアライズ時にEngine.AddNodeをした時Registered内の処理を行うのを止める

        /// <summary>
        /// シリアライズ時に実行
        /// </summary>
        /// <param name="context">送信先の情報</param>
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            if (Parent is RootNode)
            {
                isRootChild = true;
                serialization_Parent = null;
                serialization_Status = RegisterStatus.Free;
                surpressing = true;
            }
            else
            {
                isRootChild = false;
                serialization_Parent = _parent;
                serialization_Status = Status;
                surpressing = false;
            }
        }

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="context">送信元の情報</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (isRootChild) Engine.AddNode(this);
            else _parent = serialization_Parent;
            Status = serialization_Status;
            isRootChild = default;
            serialization_Parent = null;
            serialization_Status = default;
        }
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
