using System;
using System.Collections;
using System.Collections.Generic;

namespace Altseed
{
    /// <summary>
    /// コライダを格納するコレクション
    /// </summary>
    [Serializable]
    internal sealed class CollisionCollection : IEnumerable<ColliderNode>
    {
        private readonly Dictionary<Node, HashSet<ColliderNode>> collection = new Dictionary<Node, HashSet<ColliderNode>>();
        private Dictionary<ColliderEntry, bool> preCollisionInfo;
        private int version = 0;

        /// <summary>
        /// 格納されている<see cref="ColliderNode"/>の個数を取得する
        /// </summary>
        internal int Count
        {
            get
            {
                var count = 0;
                foreach (var current in collection) count += current.Value.Count;
                return count;
            }
        }

        /// <summary>
        /// 指定したコライダを追加する
        /// </summary>
        /// <param name="node">追加するコライダのノード</param>
        /// <exception cref="ArgumentException"><paramref name="node"/>が親に存在しない</exception>
        /// <exception cref="ArgumentNullException"><paramref name="node"/>がnull</exception>
        /// <returns><paramref name="node"/>を追加出来たらtrue，それ以外でfalse</returns>
        internal bool Add(ColliderNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node), "引数がnullです");
            if (node.Parent == null) throw new ArgumentException("衝突ノードが他ノードに所属していません", nameof(node));
            if (collection.TryGetValue(node.Parent, out var set))
            {
                var result = set.Add(node);
                if (result) version++;
                return result;
            }
            else
            {
                set = new HashSet<ColliderNode>() { node };
                collection[node.Parent] = set;
                version++;
            }
            return true;
        }

        /// <summary>
        /// 全ての要素を削除する
        /// </summary>
        internal void Clear()
        {
            collection.Clear();
            version++;
        }

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>が格納されているかどうかを返す
        /// </summary>
        /// <param name="node">検索する<see cref="ColliderNode"/></param>
        /// <returns><paramref name="node"/>が格納されていたらtrue，それ以外でfalse</returns>
        internal bool Contains(ColliderNode node)
        {
            if (node?.Parent == null) return false;
            return collection.TryGetValue(node.Parent, out var set) ? set.Contains(node) : false;
        }

        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<ColliderNode> IEnumerable<ColliderNode>.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// 指定したコライダを削除する
        /// </summary>
        /// <param name="node">削除するコライダのノード</param>
        /// <exception cref="ArgumentException"><paramref name="node"/>が親に存在しない</exception>
        /// <exception cref="ArgumentNullException"><paramref name="node"/>がnull</exception>
        /// <returns><paramref name="node"/>を削除出来たらtrue，それ以外でfalse</returns>
        internal bool Remove(ColliderNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node), "引数がnullです");
            if (node.Parent == null) throw new ArgumentException("衝突ノードが他ノードに所属していません", nameof(node));
            if (collection.TryGetValue(node, out var set))
            {
                var result = set.Remove(node);
                if (result) version++;
                return result;
            }
            return false;
        }

        /// <summary>
        /// 衝突判定を実施する
        /// </summary>
        internal void Update()
        {
            var dictionary = new Dictionary<ColliderEntry, bool>(preCollisionInfo?.Count ?? collection.Count);
            foreach (var current in this)
                foreach (var comparison in this)
                {
                    if (current == comparison) continue;
                    var entry = new ColliderEntry(current.Collider, comparison.Collider);
                    if (dictionary.TryAdd(entry, entry.IsColliding()))
                    {
                        var beforeColliding = (preCollisionInfo != null && preCollisionInfo.TryGetValue(entry, out var value)) ? value : false;
                        var nowColliding = entry.IsColliding();
                        if (current.Parent is ICollisionEventReceiver receiver1)
                        {
                            if (beforeColliding)
                            {
                                if (nowColliding) receiver1.OnCollisionStay(new CollisionInfo(current.Collider, comparison.Collider, CollisionType.Stay));
                                else receiver1.OnCollisionExit(new CollisionInfo(current.Collider, comparison.Collider, CollisionType.Exit));
                            }
                            else if (nowColliding) receiver1.OnCollisionEnter(new CollisionInfo(current.Collider, comparison.Collider, CollisionType.Enter));
                        }
                        if (comparison.Parent is ICollisionEventReceiver receiver2)
                        {
                            if (beforeColliding)
                            {
                                if (nowColliding) receiver2.OnCollisionStay(new CollisionInfo(comparison.Collider, current.Collider, CollisionType.Stay));
                                else receiver2.OnCollisionExit(new CollisionInfo(comparison.Collider, current.Collider, CollisionType.Exit));
                            }
                            else if (nowColliding) receiver2.OnCollisionEnter(new CollisionInfo(comparison.Collider, current.Collider, CollisionType.Enter));
                        }
                    }
                }
            preCollisionInfo = dictionary;
        }

        [Serializable]
        private readonly struct ColliderEntry : IEquatable<ColliderEntry>
        {
            private readonly Collider collider1;
            private readonly Collider collider2;

            internal ColliderEntry(Collider collider1, Collider collider2)
            {
                if (collider1 == null) throw new ArgumentNullException(nameof(collider1), "引数がnullです");
                if (collider2 == null) throw new ArgumentNullException(nameof(collider2), "引数がnullです");
                if (collider1 == collider2) throw new ArgumentException("同じコライダを2引数に使用しないでください", $"{nameof(collider1)}, {nameof(collider2)}");
                this.collider1 = collider1;
                this.collider2 = collider2;
            }

            public readonly bool Equals(ColliderEntry other)
            {
                if (collider1 == other.collider1) return collider2 == other.collider2;
                else return collider1 == other.collider2 ? collider2 == other.collider1 : false;
            }

            public readonly override bool Equals(object obj) => obj is ColliderEntry other ? Equals(other) : false;

            public readonly override int GetHashCode() => collider1.GetHashCode() ^ collider2.GetHashCode();

            internal bool IsColliding() => collider1.GetIsCollidedWith(collider2);

            public static bool operator ==(ColliderEntry left, ColliderEntry right) => left.Equals(right);
            public static bool operator !=(ColliderEntry left, ColliderEntry right) => !(left == right);
        }

        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        internal struct Enumerator : IEnumerator<ColliderNode>
        {
            private readonly CollisionCollection collection;
            private Dictionary<Node, HashSet<ColliderNode>>.Enumerator enumerator;
            private HashSet<ColliderNode>.Enumerator enumerator_set;
            private int index;
            private HashSet<ColliderNode> set;
            private readonly int version;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public ColliderNode Current { get; private set; }
            readonly object IEnumerator.Current
            {
                get
                {
                    if (index <= 0 || index < set.Count) throw new InvalidOperationException("現在列挙されている要素を取得できませんでした");
                    return Current;
                }
            }
            /// <summary>
            /// <see cref="Enumerator"/>の新しいインスタンスを生成する
            /// </summary>
            /// <param name="collection">使用する<see cref="CollisionCollection"/>のインスタンス</param>
            /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
            internal Enumerator(CollisionCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException(nameof(collection), "引数がnullです");
                Current = null;
                enumerator = collection.collection.GetEnumerator();
                enumerator_set = default;
                index = 0;
                set = null;
                version = collection.version;
            }
            /// <summary>
            /// このインスタンスを破棄する
            /// </summary>
            public void Dispose()
            {
                enumerator = default;
                enumerator_set = default;
                set = null;
            }
            /// <summary>
            /// 列挙を次に進める
            /// </summary>
            /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
            /// <returns>列挙を次に進められたらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                ThrowIfChanged();
                if (set == null || index == set.Count)
                {
                    if (!enumerator.MoveNext()) return MoveNextRare();
                    set = enumerator.Current.Value;
                    enumerator_set = set.GetEnumerator();
                    index = 0;
                }
                if (index < set.Count)
                {
                    if (!enumerator_set.MoveNext()) throw new InvalidOperationException("列挙に失敗しました");
                    Current = enumerator_set.Current;
                    index++;
                    return true;
                }
                return MoveNextRare();
            }
            private bool MoveNextRare()
            {
                Current = null;
                enumerator = default;
                enumerator_set = default;
                index = set?.Count + 1 ?? -1;
                set = null;
                return false;
            }
            void IEnumerator.Reset()
            {
                ThrowIfChanged();
                Current = null;
                enumerator = collection.collection.GetEnumerator();
                enumerator_set = default;
                index = 0;
                set = null;
            }
            private readonly void ThrowIfChanged()
            {
                if (version != collection.version) throw new InvalidOperationException("列挙中にコレクションが変更されました");
            }
        }
    }
}
