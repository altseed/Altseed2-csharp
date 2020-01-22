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
    public class Scene : IComponentRegisterable<SceneComponent>
    {
        private readonly List<Alject> _objects;
        private readonly List<SceneComponent> components;
        /// <summary>
        /// 登録されているオブジェクトを取得する
        /// </summary>
        public IReadOnlyList<Alject> Objects => _objects.AsReadOnly();
        /// <summary>
        /// 登録されているオブジェクトの個数を取得する
        /// </summary>
        public int ObjectCount => _objects.Count;
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public Scene()
        {
            _objects = new List<Alject>();
            components = new List<SceneComponent>();
        }
        /// <summary>
        /// 指定したオブジェクトを登録する
        /// </summary>
        /// <param name="obj">登録されるオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="obj"/>が既に登録されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        public void AddObject(Alject obj)
        {
            if (obj == null) throw new ArgumentNullException("追加しようとしたオブジェクトがnullです", nameof(obj));
            if (obj.Status != ObjectStatus.Free) throw new ArgumentException("オブジェクトの状態が無効です", nameof(obj));
            obj.Status = ObjectStatus.WaitAdded;
            Engine.Actions.Enqueue(() => __AddObject(obj));
        }
        /// <summary>
        /// 登録されているオブジェクトをすべて削除する
        /// </summary>
        public void Clear()
        {
            foreach (var o in _objects)
                if (o.Status == ObjectStatus.Registered)
                    o.Status = ObjectStatus.WaitRemoved;
            Engine.Actions.Enqueue(() => __Clear());
        }
        /// <summary>
        /// 指定したオブジェクトを削除する
        /// </summary>
        /// <param name="obj">削除されるオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="obj"/>が既に削除されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        public void RemoveObject(Alject obj)
        {
            if (obj == null) throw new ArgumentNullException("追加しようとしたオブジェクトがnullです", nameof(obj));
            if (obj.Status != ObjectStatus.Registered) throw new ArgumentException("オブジェクトの状態が無効です", nameof(obj));
            obj.Status = ObjectStatus.WaitRemoved;
            Engine.Actions.Enqueue(() => __RemoveObject(obj, true));
        }
        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に登録されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        public void AddComponent(SceneComponent component)
        {
            if (component == null) throw new ArgumentNullException("追加しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Free) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitAdded;
            Engine.Actions.Enqueue(() => __AddComponent(component));
        }
        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に削除されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        public void RemoveComponent(SceneComponent component)
        {
            if (component == null) throw new ArgumentNullException("削除しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Registered) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitRemoved;
            Engine.Actions.Enqueue(() => __RemoveComponent(component));
        }
        /// <summary>
        /// オブジェクトの更新が行われる前に実行
        /// </summary>
        protected virtual void OnUpdating() { }
        /// <summary>
        /// オブジェクトの更新が行われた後に実行
        /// </summary>
        protected virtual void OnUpdated() { }
        private void __AddObject(Alject obj)
        {
            _objects.Add(obj);
            obj.Status = ObjectStatus.Registered;
            obj.Scene = this;
            obj.RaiseOnAdded();
        }
        private void __Clear()
        {
            foreach (var o in _objects)
                if (o.Status == ObjectStatus.WaitRemoved)
                {
                    o.Status = ObjectStatus.Free;
                    o.RiaseOnRemoved(true);
                    o.Scene = null;
                }
            _objects.Clear();
        }
        private void __RemoveObject(Alject obj, bool raiseEvent)
        {
            _objects.Remove(obj);
            obj.Status = ObjectStatus.Free;
            obj.Scene = null;
            obj.RiaseOnRemoved(raiseEvent);
        }
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
    }
}
