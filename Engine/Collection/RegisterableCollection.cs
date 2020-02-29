using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Altseed
{
    /// <summary>
    /// 追加および削除を予約できるコレクションを表します。
    /// </summary>
    [Serializable]
    internal class RegisterableCollection<TElement, TOwner>
        where TElement : Registerable<TOwner>
    {
        private readonly List<TElement> CurrentCollection = new List<TElement>();
        private readonly Queue<TElement> AddQueue = new Queue<TElement>();
        private readonly Queue<TElement> RemoveQueue = new Queue<TElement>();

        private readonly TOwner Owner;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        internal RegisterableCollection(TOwner owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// 要素の追加を予約します。
        /// </summary>
        internal void Add(TElement obj)
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
            if (obj.Status != RegisterStatus.Free)
            {
                Engine.Log.Info(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素の状態が無効です。");
                return;
            }

            AddQueue.Enqueue(obj);
            obj.Status = RegisterStatus.WaitAdded;
        }

        /// <summary>
        /// 要素の削除を予約します。
        /// </summary>
        /// <param name="obj"></param>
        internal void Remove(TElement obj)
        {
            if (obj == null)
            {
                Engine.Log.Info(LogCategory.Engine, $"null を削除しようとしました。");
                return;
            }
            if (!CurrentCollection.Contains(obj))
            {
                Engine.Log.Info(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素が既に含まれています。");
                return;
            }
            if (obj.Status != RegisterStatus.Registered)
            {
                Engine.Log.Info(LogCategory.Engine, $"削除しようとした {obj.GetType()} 要素の状態が無効です。");
                return;
            }

            RemoveQueue.Enqueue(obj);
            obj.Status = RegisterStatus.WaitRemoved;
        }

        /// <summary>
        /// コレクションを更新します。
        /// </summary>
        internal void Update()
        {
            while (RemoveQueue.Count > 0)
            {
                var obj = RemoveQueue.Dequeue();
                CurrentCollection.Remove(obj);
                obj.Status = RegisterStatus.Free;
                obj.Removed();
            }

            while (AddQueue.Count > 0)
            {
                var obj = AddQueue.Dequeue();
                CurrentCollection.Add(obj);
                obj.Status = RegisterStatus.Registered;
                obj.Added(Owner);
            }
        }

        /// <summary>
        /// 指定した比較子を使用して、コレクションをソートします。
        /// </summary>
        internal void Sort(IComparer<TElement> comparer)
        {
            CurrentCollection.Sort(comparer);
        }

        internal void Clear()
        {
            CurrentCollection.Clear();
            AddQueue.Clear();
            RemoveQueue.Clear();
        }

        /// <summary>
        /// 現在の要素の読み取り専用なコレクションを返します。
        /// </summary>
        internal ReadOnlyCollection<TElement> AsReadOnly()
        {
            return new ReadOnlyCollection<TElement>(CurrentCollection);
        }

        /// <summary>
        /// 直ちに要素を追加します。
        /// </summary>
        /// <remarks>列挙中に呼び出さないこと</remarks>
        internal void AddImmediately(TElement obj)
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
            if (obj.Status != RegisterStatus.Free)
            {
                Engine.Log.Info(LogCategory.Engine, $"追加しようとした {obj.GetType()} 要素の状態が無効です。");
                return;
            }

            CurrentCollection.Add(obj);
            obj.Status = RegisterStatus.Registered;
            obj.Added(Owner);
        }

        /// <summary>
        /// 直ちに要素を追加します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="objs"/>がnull</exception>
        /// <remarks>列挙中に呼び出さないこと</remarks>
        internal void AddImmediately(IEnumerable<TElement> objs)
        {
            if (objs == null) throw new ArgumentNullException("引数がnullです", nameof(objs));
            foreach (var o in objs)
            {
                AddImmediately(o);
            }
        }
    }
}
