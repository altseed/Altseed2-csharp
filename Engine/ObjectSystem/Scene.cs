using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// オブジェクトを統括するシーンのクラス
    /// </summary>
    [Serializable]
    public class Scene : IComponentRegisterable<SceneComponent>
    {
        [Serializable]
        private sealed class AljectDrawingPriorityComparer : IComparer<Alject>
        {
            /// <summary>
            /// 指定した2つの<see cref="Alject"/>の<see cref="Alject.DrawingPriority"/>を比較する
            /// </summary>
            /// <param name="x">更新優先度を比較する<see cref="Alject"/></param>
            /// <param name="y">更新優先度を比較する<see cref="Alject"/></param>
            /// <returns><paramref name="x"/>と<paramref name="y"/>を比較した結果</returns>
            public int Compare(Alject x, Alject y)
            {
                if (x == null) throw new ArgumentNullException("比較するオブジェクトがnullです", nameof(x));
                if (y == null) throw new ArgumentNullException("比較するオブジェクトがnullです", nameof(y));
                return x.DrawingPriority.CompareTo(y.DrawingPriority);
            }
        }
        private readonly static AljectDrawingPriorityComparer priorityComparer;
        internal bool NeededSort { get; set; } = false;
        /// <summary>
        /// 登録されているオブジェクトを取得する
        /// </summary>
        public IReadOnlyList<Alject> Objects => _objects.AsReadOnly();
        /// <summary>
        /// 登録されているオブジェクトの個数を取得する
        /// </summary>
        public int ObjectCount => _objects.Count;
        static Scene()
        {
            priorityComparer = new AljectDrawingPriorityComparer();
        }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public Scene()
        {
            _objects = new List<Alject>();
            addObjects = new List<Alject>();
            removeObjects = new List<Alject>();
            components = new List<SceneComponent>();
            addComponents = new List<SceneComponent>();
            removeComponents = new List<SceneComponent>();
        }
        #region ComponentRegister
        private readonly List<SceneComponent> components;
        private readonly List<SceneComponent> addComponents;
        private readonly List<SceneComponent> removeComponents;
        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に登録されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        /// <remarks>追加されるのはそのフレームの更新処理が終了した後</remarks>
        public void AddComponent(SceneComponent component)
        {
            if (component == null) throw new ArgumentNullException("追加しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Free) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitAdded;
            addComponents.Add(component);
        }
        /// <summary>
        /// 指定した<see cref="SceneComponent"/>が登録されているかどうかを返す
        /// </summary>
        /// <param name="component">検索する<see cref="SceneComponent"/></param>
        /// <returns><paramref name="component"/>が登録されていたらtrue，それ以外でfalse</returns>
        public bool ContainsComponent(SceneComponent component) => component == null ? false : components.Contains(component);
        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に削除されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void RemoveComponent(SceneComponent component)
        {
            if (component == null) throw new ArgumentNullException("削除しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Registered) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitRemoved;
            removeComponents.Add(component);
        }
        private void __AddComponent(SceneComponent component)
        {
            component.Owner = this;
            component.Status = ObjectStatus.Registered;
        }
        void IComponentRegisterable<SceneComponent>.__AddComponent(SceneComponent component) => __AddComponent(component);
        private void __RemoveComponent(SceneComponent component)
        {
            component.Owner = null;
            component.Status = ObjectStatus.Free;
        }
        void IComponentRegisterable<SceneComponent>.__RemoveComponent(SceneComponent component) => __RemoveComponent(component);
        #endregion
        #region AljectRegister
        private readonly List<Alject> _objects;
        private readonly List<Alject> addObjects;
        private readonly List<Alject> removeObjects;
        /// <summary>
        /// 指定したオブジェクトを登録する
        /// </summary>
        /// <param name="obj">登録されるオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="obj"/>が既に登録されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        /// <remarks>追加されるのはそのフレームの更新処理が終了した後</remarks>
        public void AddObject(Alject obj)
        {
            if (obj == null) throw new ArgumentNullException("追加しようとしたオブジェクトがnullです", nameof(obj));
            if (obj.Status != ObjectStatus.Free) throw new ArgumentException("オブジェクトの状態が無効です", nameof(obj));
            obj.Status = ObjectStatus.WaitAdded;
            addObjects.Add(obj);
        }
        /// <summary>
        /// 登録されているオブジェクトをすべて削除する
        /// </summary>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void Clear()
        {
            foreach (var o in _objects)
                if (o.Status == ObjectStatus.Registered)
                    o.Status = ObjectStatus.WaitRemoved;
            removeObjects.AddRange(_objects);
        }
        /// <summary>
        /// 指定したオブジェクトを削除する
        /// </summary>
        /// <param name="obj">削除されるオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="obj"/>が既に削除されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void RemoveObject(Alject obj)
        {
            if (obj == null) throw new ArgumentNullException("追加しようとしたオブジェクトがnullです", nameof(obj));
            if (obj.Status != ObjectStatus.Registered) throw new ArgumentException("オブジェクトの状態が無効です", nameof(obj));
            obj.Status = ObjectStatus.WaitRemoved;
            removeObjects.Add(obj);
        }
        private void __AddObject(Alject obj)
        {
            _objects.Add(obj);
            obj.Status = ObjectStatus.Registered;
            obj.Scene = this;
            obj.RaiseOnAdded();
            NeededSort = true;
        }
        private void __RemoveObject(Alject obj, bool raiseEvent)
        {
            _objects.Remove(obj);
            obj.Status = ObjectStatus.Free;
            obj.Scene = null;
            obj.RiaseOnRemoved(raiseEvent);
            NeededSort = true;
        }
        #endregion
        /// <summary>
        /// オブジェクトの更新が行われる前に実行
        /// </summary>
        protected virtual void OnUpdating() { }
        /// <summary>
        /// オブジェクトの更新が行われた後に実行
        /// </summary>
        protected virtual void OnUpdated() { }
        internal void Update()
        {
            foreach (var c in components)
                if (c.Status == ObjectStatus.Registered)
                    c.RaiseOnUpdating();
            OnUpdating();
            foreach (var o in _objects)
                if (o.Status == ObjectStatus.Registered)
                    o.Update();
            OnUpdated();
            foreach (var c in components)
                if (c.Status == ObjectStatus.Registered)
                    c.RaiseOnUpdated();
            DoDrawing();
            foreach (var a in addObjects) __AddObject(a);
            foreach (var r in removeObjects) __RemoveObject(r, true);
            foreach (var a in addComponents) __AddComponent(a);
            foreach (var r in removeComponents) __RemoveComponent(r);
            addObjects.Clear();
            removeObjects.Clear();
            addComponents.Clear();
            removeComponents.Clear();
            if (NeededSort)
            {
                _objects.Sort(priorityComparer);
                NeededSort = false;
            }
        }
        internal void DoDrawing()
        {
            foreach (var o in _objects) o.DoDrawing();
        }
    }
}
