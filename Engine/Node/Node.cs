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
        /// <see cref="Node"/>の新しいインスタンスを生成します。
        /// </summary>
        public Node()
        {
            _Children = new RegisterableCollection<Node>(this);
        }

        /// <summary>
        /// 更新を行います。　
        /// </summary>
        internal virtual void Update()
        {
            if (!IsUpdated) return;

            OnUpdate();

            _IsEnumeratingChildren = true;

            _Children.Update();
            foreach (var c in Children)
            {
                c.Update();
            }

            _IsEnumeratingChildren = false;

        }

        #region Registerable (子として)

        /// <summary>
        /// 親ノードを取得または設定します。
        /// </summary>
        public Node Parent => _Parent;

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

        /// <summary>
        /// <paramref name="owner"/>に登録された際の処理を行います。
        /// </summary>
        /// <param name="owner">新たなオーナー</param>
        internal override void Added(Node owner)
        {
            for (var n = Parent; ; n = n.Parent)
            {
                if (n == null) return;
                if (n is RootNode) break;
            }
            _Children.Update();

            if (!_IsRegistered)
            {
                _IsRegistered = true;
                Registered();
            }
        }

        /// <summary>
        /// 親要素から削除されたときの処理を行います。
        /// </summary>
        internal override void Removed()
        {
            _Children.Update();
            if (_IsRegistered)
            {
                _IsRegistered = false;
                Unregistered();
            }
        }

        /// <summary>
        /// エンジンに登録され、ノードツリーを辿って<see cref="RootNode"/> にたどり着けるようになったとき実行します。
        /// </summary>
        internal virtual void Registered()
        {
            if (surpressing)
            {
                surpressing = false;
                return;
            }

            _IsEnumeratingChildren = true;

            foreach (var c in Children)
            {
                if (!c._IsRegistered)
                {
                    c._IsRegistered = true;
                    c.Registered();
                }
            }

            _IsEnumeratingChildren = false;

            OnAdded();
        }

        /// <summary>
        /// エンジンから削除され、ノードツリーを辿って<see cref="RootNode"/> にたどり着けなくなったとき実行します。
        /// </summary>
        internal virtual void Unregistered()
        {
            _IsEnumeratingChildren = true;

            foreach (var c in Children)
            {
                if (c._IsRegistered)
                {
                    c._IsRegistered = false;
                    c.Unregistered();
                }
            }

            _IsEnumeratingChildren = false;

            OnRemoved();
        }

        #endregion

        #region Registerable (親として)

        internal readonly RegisterableCollection<Node> _Children;

        private bool _IsEnumeratingChildren = false;

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
            // NOTE: null を食わせてもおｋ
            _Children.Add(node);
        }

        /// <summary>
        /// 子要素を削除します。
        /// </summary>
        /// <param name="node">削除する要素</param>
        public void RemoveChildNode(Node node)
        {
            // NOTE: null を食わせてもおｋ
            _Children.Remove(node);
        }

        /// <summary>
        /// 予約されている追加・削除を直ちに実行します。
        /// </summary>
        /// <remarks>この<see cref="Node"/>自身の更新中に実行することはできません。</remarks>
        public void FlushQueue()
        {
            if (_IsEnumeratingChildren)
            {
                Engine.Log.Warn(LogCategory.Engine, $"この{GetType()}は子要素の列挙中です。直ちに追加・削除を実行することはできません。");
                return;
            }

            _Children.Update();
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
        /// エンジンから削除された時に実行します。
        /// </summary>
        /// <remarks>
        /// 自身もしくは親ノードがEngineにから削除されたあとのUpdateの際に実行されます。
        /// </remarks>
        protected virtual void OnRemoved() { }

        /// <summary>
        /// 自身が更新された時に実行します。
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
        /// シリアライズ時に実行します。
        /// </summary>
        /// <param name="context">送信先の情報</param>
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // _ParentReserved is RootNode：RootNodeに追加されようとしている
            // _Parent is RootNode：RootNodeの親
            // 
            // この場合はRootNodeを除いてシリアライズする必要があるため，Parent = nullとしてシリアライズし，
            // デシリアライズ時にEngine.AddNode(this)で再登録する
            if (_ParentReserved is RootNode || _Parent is RootNode)
            {
                isRootChild = Status != RegisteredStatus.WaitingRemoved; // RootNodeから削除されようとしている場合はデシリアライズ時に再登録されないようにする
                serialization_Parent = null;
                serialization_ParentReserved = null;
                serialization_Status = RegisteredStatus.Free;
                surpressing = Status != RegisteredStatus.WaitingRemoved;// RootNodeから削除されようとしている場合はデシリアライズ時に再登録されないようにする
            }
            // 上記の場合以外は親や登録状態は全てそのままで実行
            else
            {
                isRootChild = false;
                serialization_Parent = _Parent;
                serialization_ParentReserved = _ParentReserved;
                serialization_Status = Status;
                surpressing = false;
            }
        }

        /// <summary>
        /// シリアライズ終了時に実行します。
        /// </summary>
        /// <param name="context">送信先の情報</param>
        [OnSerializing]
        private void OnSerialized(StreamingContext context)
        {
            // シリアライズ終了時にシリアライズ関連のフィールドを初期化してバグを防ぐ
            ResetSerializationField();
            surpressing = false;
        }

        /// <summary>
        /// デシリアライズ時に実行します。
        /// </summary>
        /// <param name="context">送信元の情報</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Status = serialization_Status;
            // シリアライズ時にRootNodeの子だった場合，Engineに自身を登録
            if (isRootChild) Engine.AddNode(this);
            // それ以外の場合は親情報をそのまま引き継ぐ
            else
            {
                _Parent = serialization_Parent;
                _ParentReserved = serialization_ParentReserved;
            }
            // シリアライズ関連のフィールドをリセットしてバグを防ぐ
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
        /// エンジンに登録され、ノードツリーを辿って<see cref="RootNode"/> にたどり着けるかどうかを取得します。
        /// </summary>
        public bool IsRegistered => _IsRegistered;
        [NonSerialized]
        private bool _IsRegistered = false;


        /// <summary>
        /// この<see cref="Node"/>が更新されるかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated
        {
            get => _IsUpdated;
            set
            {
                _IsUpdated = value;
                PropagateIsUpdatedActually(this, Parent?.IsUpdatedActually ?? true);
            }
        }
        private bool _IsUpdated = true;

        /// <summary>
        /// 先祖の<see cref="IsUpdated" />を考慮して、このノードが更新されるかどうかを取得します。
        /// </summary>
        public bool IsUpdatedActually { get; private set; } = true;

        /// <summary>
        /// 子孫ノード<see cref="Node"/>に対して<see cref="IsUpdatedActually"/>を伝播させます。
        /// </summary>
        /// <param name="node"><see cref="IsUpdatedActually"/>を変更する対象のノード</param>
        /// <param name="isUpdatedActually">親ノードの<see cref="IsUpdatedActually"/></param>
        private void PropagateIsUpdatedActually(Node node, bool isUpdatedActually)
        {
            node.IsUpdatedActually = isUpdatedActually && node.IsUpdated;

            foreach (var child in node.Children)
            {
                PropagateIsUpdatedActually(child, node.IsUpdatedActually);
            }
        }

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
            _IsEnumeratingChildren = true;

            foreach (var c in Children)
            {
                yield return c;
                foreach (var g in c.EnumerateDescendants())
                    yield return g;
            }

            _IsEnumeratingChildren = false;
        }

        /// <summary>
        /// <typeparamref name="T"/>型の子孫ノードのうち <paramref name="condition"/> を満たすものを列挙します。
        /// </summary>
        /// <typeparam name="T">列挙されるノードの型</typeparam>
        /// <param name="condition">列挙するノードの条件</param>
        public IEnumerable<T> EnumerateDescendants<T>(Func<T, bool> condition = null)
            where T : Node
        {
            _IsEnumeratingChildren = true;

            foreach (var child in Children)
            {
                foreach (var g in child.EnumerateDescendants(condition))
                    yield return g;

                if (child is T c && (condition?.Invoke(c) ?? true))
                    yield return c;
            }

            _IsEnumeratingChildren = false;
        }
    }
}
