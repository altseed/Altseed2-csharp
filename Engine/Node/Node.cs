using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Altseed2
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

        /// <summary>
        /// このノードの登録状況を取得または設定します。
        /// </summary>
        public sealed override RegisteredStatus Status
        {
            get => _status;
            internal set
            {
                _status = value;
            }
        }
        [NonSerialized]
        private RegisteredStatus _status;

        [NonSerialized]
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
        /// <exception cref="ArgumentNullException"><paramref name="node"/>がnull</exception>
        public void AddChildNode(Node node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Status == RegisteredStatus.WaitingRemoved && node.Parent == this)
                node.Status = RegisteredStatus.Registered;

            _Children.Add(node);
            node._ParentReserved = this;
        }

        /// <summary>
        /// 子要素を削除します。
        /// </summary>
        /// <param name="node">削除する要素</param>
        /// <exception cref="ArgumentNullException"><paramref name="node"/>がnull</exception>
        public void RemoveChildNode(Node node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Status == RegisteredStatus.WaitingAdded && node._ParentReserved == this)
                node.Status = RegisteredStatus.Registered;

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
        private Node serialization_ParentReserved;
        private RegisteredStatus serialization_Status;
        private bool isRootChild;
        private bool surpressing; // デシリアライズ時にEngine.AddNodeをした時Registered内の処理を行うのを止める

        /// <summary>
        /// シリアライズ時に実行
        /// </summary>
        /// <param name="context">送信先の情報</param>
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            if (_ParentReserved is RootNode)
            {
                isRootChild = true;
                serialization_Parent = null;
                serialization_ParentReserved = null;
                serialization_Status = RegisteredStatus.Free;
                surpressing = true;
            }
            else
            {
                isRootChild = false;
                serialization_Parent = _parent;
                serialization_Parent = _ParentReserved;
                serialization_Status = Status;
                surpressing = false;
            }
        }

        /// <summary>
        /// シリアライズ終了時に実行
        /// </summary>
        /// <param name="context">送信先の情報</param>
        [OnSerializing]
        private void OnSerialized(StreamingContext context)
        {
            ResetSerializationField();
            surpressing = false;
        }

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="context">送信元の情報</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Status = serialization_Status;
            if (isRootChild) Engine.AddNode(this);
            else
            {
                _parent = serialization_Parent;
                _ParentReserved = serialization_ParentReserved;
            }
            ResetSerializationField();
        }

        private void ResetSerializationField()
        {
            isRootChild = default;
            serialization_Parent = null;
            serialization_ParentReserved = null;
            serialization_Status = default;
        }
        #endregion

        /// <summary>
        /// 先祖ノードを列挙します。
        /// </summary>
        public IEnumerable<Node> EnumerateAncestors()
        {
            for (var current = Parent; current != null && !(current is RootNode); current = current.Parent)
                yield return current;

            yield break;
        }

        internal T GetAncestorSpecificNode<T>()
            where T : class
        {
            if (Parent == null)
                return null;

            for (var n = Parent; n != null; n = n.Parent)
            {
                if (n is T t)
                    return t;
            }
            return null;
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
        /// <typeparam name="T">列挙されるノードの型</typeparam>
        public IEnumerable<T> EnumerateDescendants<T>()
             where T : Node
        {
            return EnumerateDescendants<T>(x => true);
        }

        /// <summary>
        /// <typeparamref name="T"/>型の子孫ノードのうち <paramref name="condition"/> を満たすものを列挙します。
        /// </summary>
        /// <typeparam name="T">列挙されるノードの型</typeparam>
        /// <param name="condition">列挙するノードの条件</param>
        /// <exception cref="ArgumentNullException"><paramref name="condition"/>がnull</exception>
        public IEnumerable<T> EnumerateDescendants<T>(Func<T, bool> condition)
            where T : Node
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition), "引数がnullです");
            foreach (var child in Children)
            {
                foreach (var g in child.EnumerateDescendants(condition))
                    if (condition.Invoke(g)) yield return g;

                if (child is T c && condition.Invoke(c))
                    yield return c;
            }
        }
    }
}
