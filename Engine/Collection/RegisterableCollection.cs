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

            switch (obj.Status)
            {
                case RegisteredStatus.Free:
                    AddQueue.Enqueue(obj);
                    obj.Status = RegisteredStatus.WaitingAdded;
                    obj._ParentReserved = Owner;
                    return;

                case RegisteredStatus.WaitingAdded:
                case RegisteredStatus.Registered:
                    Engine.Log.Warn(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素が既に追加されています。");
                    return;

                case RegisteredStatus.WaitingRemoved:
                    // 削除待ちのときに登録しようとした場合：
                    // NOTE: どちらも削除時の扱いに注意
                    if (obj._Parent == Owner)
                    {
                        // 同じ親に再登録しようとした場合は状態を登録済みに戻すだけ。
                        obj.Status = RegisteredStatus.Registered;
                        return;
                    }
                    else
                    {
                        // 異なる親に再登録しようとした場合は登録キューに入れる。
                        obj.Status = RegisteredStatus.WaitingAdded;
                        obj._ParentReserved = Owner;
                        AddQueue.Enqueue(obj);
                        return;
                    }
            }
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

            switch (obj.Status)
            {
                case RegisteredStatus.Free:
                case RegisteredStatus.WaitingRemoved:
                    Engine.Log.Warn(LogCategory.Engine, $"削除しようとした {typeof(T)} 要素は登録されていません。");
                    return;

                case RegisteredStatus.WaitingAdded:
                    // 追加待ちの場合
                    if (obj._ParentReserved == Owner)
                    {
                        // 同じ親から削除しようとした場合は状態を未登録に戻すだけ。
                        obj.Status = RegisteredStatus.Free;
                        return;
                    }
                    else
                    {
                        // 親が異なる場合は削除しない。
                        Engine.Log.Warn(LogCategory.Engine, $"削除しようとした {typeof(T)} 要素は他の{typeof(T)} 要素に登録されています。");
                        return;
                    }
                case RegisteredStatus.Registered:
                    if (obj._Parent == Owner)
                    {
                        // 同じ親から削除しようとした場合は削除を予約。
                        RemoveQueue.Enqueue(obj);
                        obj.Status = RegisteredStatus.WaitingRemoved;
                    }
                    else
                    {
                        // 親が異なる場合は削除しない。
                        Engine.Log.Warn(LogCategory.Engine, $"削除しようとした {typeof(T)} 要素は他の{typeof(T)} 要素に登録されています。");
                        return;
                    }

                    return;
            }
        }

        /// <summary>
        /// コレクションを更新します。
        /// </summary>
        internal void Update()
        {
            while (RemoveQueue.TryDequeue(out var obj))
            {
                if (obj.Status == RegisteredStatus.Free && obj._ParentReserved == Owner)
                {
                    // 削除予約状態で他のオブジェクトに登録した場合、こちらのコレクションからの削除だけ行う。
                    CurrentCollection.Remove(obj);
                    obj.Removed();
                    continue;
                }

                if (obj.Status == RegisteredStatus.WaitingRemoved && obj._Parent == Owner)
                {
                    CurrentCollection.Remove(obj);
                    obj.Status = RegisteredStatus.Free;
                    obj._Parent = null;
                    obj._ParentReserved = null;
                    obj.Removed();
                    continue;
                }

                Engine.Log.Error(LogCategory.Engine, "Error on flushing RemoveQueue!");
            }

            while (AddQueue.TryDequeue(out var obj))
            {
                if (obj.Status == RegisteredStatus.Free && obj._ParentReserved == Owner)
                {
                    obj._Parent = null;
                    continue;
                }

                if (obj.Status == RegisteredStatus.WaitingAdded && obj._ParentReserved == Owner)
                {
                    CurrentCollection.Add(obj);
                    obj.Status = RegisteredStatus.Registered;
                    obj._Parent = Owner;
                    obj._ParentReserved = null;
                    obj.Added(Owner);
                    continue;
                }

                Engine.Log.Error(LogCategory.Engine, "Error on flushing AddQueue!");
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
