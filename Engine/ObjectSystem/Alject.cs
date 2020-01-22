using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// Altseedで管理されるオブジェクト
    /// 名前適当なのでいい感じに直して
    /// </summary>
    public class Alject : IComponentRegisterable<AljectComponent>
    {
        private readonly List<AljectComponent> components;
        private readonly List<AljectComponent> addComponents;
        private readonly List<AljectComponent> removeComponents;
        /// <summary>
        /// 更新をするかどうかを取得または設定する
        /// </summary>
        public bool IsUpdated { get; set; }
        /// <summary>
        /// 現在所属している<see cref="Altseed.Scene"/>を取得する
        /// </summary>
        public Scene Scene { get; internal set; }
        internal ObjectStatus Status { get; set; }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public Alject()
        {
            IsUpdated = true;
            components = new List<AljectComponent>();
            addComponents = new List<AljectComponent>();
            removeComponents = new List<AljectComponent>();
            Status = ObjectStatus.Free;
        }
        /// <summary>
        /// 指定した<see cref="AljectComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に登録されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        public void AddComponent(AljectComponent component)
        {
            if (component == null) throw new ArgumentNullException("追加しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Free) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitAdded;
            addComponents.Add(component);
        }
        /// <summary>
        /// 指定した<see cref="AljectComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <exception cref="ArgumentException"><paramref name="component"/>が既に削除されている又は登録/削除処理待ち，若しくは破棄されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="component"/>がnull</exception>
        public void RemoveComponent(AljectComponent component)
        {
            if (component == null) throw new ArgumentNullException("削除しようとしたコンポーネントがnullです", nameof(component));
            if (component.Status != ObjectStatus.Registered) throw new ArgumentException("コンポーネントの状態が無効です", nameof(component));
            component.Status = ObjectStatus.WaitRemoved;
            removeComponents.Add(component);
        }
        internal void RaiseOnAdded()
        {
            OnAdded();
            foreach (var c in components)
                if (c.Status == ObjectStatus.Registered)
                    c.RaiseOnObjectAdded();
        }
        internal void RiaseOnRemoved(bool raiseEvent)
        {
            if (raiseEvent)
            {
                OnRemoved();
                foreach (var c in components)
                    if (c.Status == ObjectStatus.Registered)
                        c.RaiseObjectRemoved();
            }
        }
        internal void Update()
        {
            if (IsUpdated)
            {
                OnUpdate();
                foreach (var c in components)
                    if (c.Status == ObjectStatus.Registered)
                        c.RaiseOnUpdate();
                foreach (var a in addComponents) __AddComponent(a);
                foreach (var r in removeComponents) __RemoveComponent(r);
                addComponents.Clear();
                removeComponents.Clear();
            }
        }
        /// <summary>
        /// <see cref="Altseed.Scene"/>に登録されたときの実装
        /// </summary>
        protected virtual void OnAdded() { }
        /// <summary>
        /// 更新時に実行される処理
        /// </summary>
        protected virtual void OnUpdate() { }
        /// <summary>
        /// <see cref="Altseed.Scene"/>の登録を解除されるときに実行される処理
        /// </summary>
        protected virtual void OnRemoved() { }
        private void __AddComponent(AljectComponent component)
        {
            component.Owner = this;
            component.Status = ObjectStatus.Registered;
            components.Add(component);
        }
        void IComponentRegisterable<AljectComponent>.__AddComponent(AljectComponent component) => __AddComponent(component);
        private void __RemoveComponent(AljectComponent component)
        {
            component.Owner = null;
            component.Status = ObjectStatus.Free;
            components.Remove(component);
        }
        void IComponentRegisterable<AljectComponent>.__RemoveComponent(AljectComponent component) => __RemoveComponent(component);
    }
}
