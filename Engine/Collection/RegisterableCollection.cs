using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Altseed2
{
    /// <summary>
    /// 追加および削除を予約できるコレクションを表します。
    /// </summary>
    [Serializable]
    internal class RegisterableCollection<T>
        where T : Registerable<T>
    {
        private readonly List<T> CurrentCollection = new List<T>();
        private readonly Queue<T> AddQueue = new Queue<T>();
        private readonly Queue<T> RemoveQueue = new Queue<T>();

        /// <summary>
        /// このコレクションを持っているオブジェクト
        /// </summary>
        private readonly T Owner;

        /// <summary>
        /// <see cref="RegisterableCollection{T}"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="owner">自身のオーナー</param>
        internal RegisterableCollection(T owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// 要素の追加を予約します。
        /// </summary>
        /// <param name="obj">追加する要素</param>
        internal void Add(T obj)
        {
            if (obj == null)
            {
                Engine.Log.Warn(LogCategory.Engine, $"null を追加しようとしました。");
                return;
            }

            if (obj == Owner)
            {
                Engine.Log.Warn(LogCategory.Engine, $"自身を追加することはできません。");
                return;
            }

            if (obj.Status != RegisteredStatus.Free)
            {
                Engine.Log.Warn(LogCategory.Engine, $"既に登録されている {typeof(T)} を追加することはできません。");
                return;
            }

            // Status == Free のときのみ追加予約できる。
            AddQueue.Enqueue(obj);
            obj.Status = RegisteredStatus.WaitingAdded;
            obj._ParentReserved = Owner;
        }

        /// <summary>
        /// 要素の削除を予約します。
        /// </summary>
        /// <param name="obj">削除する要素</param>
        internal void Remove(T obj)
        {
            if (obj == null)
            {
                Engine.Log.Warn(LogCategory.Engine, $"null を削除しようとしました。");
                return;
            }

            if (obj.Status != RegisteredStatus.Registered || obj._Parent != Owner)
            {
                Engine.Log.Warn(LogCategory.Engine, $"削除しようとした {typeof(T)} は登録されていません。");
                return;
            }

            // Status == Registered かつ 現在の親からの削除のみ削除予約できる。
            RemoveQueue.Enqueue(obj);
            obj.Status = RegisteredStatus.WaitingRemoved;
        }

        /// <summary>
        /// コレクションを更新します。
        /// </summary>
        internal void Update()
        {
            while (RemoveQueue.TryDequeue(out var obj))
            {
                CurrentCollection.Remove(obj);
                obj.Status = RegisteredStatus.Free;
                obj._Parent = null;
                obj.Removed();
            }

            while (AddQueue.TryDequeue(out var obj))
            {
                CurrentCollection.Add(obj);
                obj.Status = RegisteredStatus.Registered;
                obj._Parent = Owner;
                obj._ParentReserved = null;
                obj.Added(Owner);
            }
        }

        /// <summary>
        /// 子要素の登録をすべて削除します。
        /// </summary>
        internal void Clear()
        {
            foreach (var current in CurrentCollection)
            {
                current.Status = RegisteredStatus.Free;
                current._Parent = null;
                current.Removed();
            }
            CurrentCollection.Clear();
            while (AddQueue.TryDequeue(out var current))
            {
                current.Status = RegisteredStatus.Free;
                current._Parent = null;
                current.Removed();
            }
            while (RemoveQueue.TryDequeue(out var current))
            {
                current.Status = RegisteredStatus.Free;
                current._Parent = null;
                current.Removed();
            }
        }

        /// <summary>
        /// 現在の要素の読み取り専用なコレクションを返します。
        /// </summary>
        internal ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(CurrentCollection);
        }

        /// <summary>
        /// 直ちに要素を追加します。
        /// </summary>
        /// <param name="obj">追加する要素</param>
        /// <remarks>列挙中に呼び出さないこと</remarks>
        internal void AddImmediately(T obj)
        {
            if (obj == null)
            {
                Engine.Log.Info(LogCategory.Engine, $"null を追加しようとしました。");
                return;
            }
            if (CurrentCollection.Contains(obj))
            {
                Engine.Log.Info(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素が既に含まれています。");
                return;
            }
            if (obj.Status != RegisteredStatus.Free)
            {
                Engine.Log.Info(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素の状態が無効です。");
                return;
            }

            CurrentCollection.Add(obj);
            obj.Status = RegisteredStatus.Registered;
            obj.Added(Owner);
        }

        /// <summary>
        /// 直ちに要素を追加します。
        /// </summary>
        /// <param name="objs">追加する要素のコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="objs"/>がnull</exception>
        /// <remarks>列挙中に呼び出さないこと</remarks>
        internal void AddImmediately(IEnumerable<T> objs)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs), "引数がnullです");
            foreach (var o in objs)
            {
                AddImmediately(o);
            }
        }
    }
}
