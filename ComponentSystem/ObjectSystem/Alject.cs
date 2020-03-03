using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed.ComponentSystem
{
    /// <summary>
    /// Altseedで管理されるオブジェクト
    /// 名前適当なのでいい感じに直して
    /// </summary>
    [Serializable]
    public class Alject : Registerable<Scene>
    {
        /// <summary>
        /// 描画優先度を取得または設定します。
        /// </summary>
        /// <remarks>実際の更新の順序の変更は次フレーム以降</remarks>
        public int DrawingPriority
        {
            get => _drawingPriority;
            set
            {
                _drawingPriority = value;
                if (Scene != null) Scene.NeededSort = true;
            }
        }
        private int _drawingPriority = 0;

        /// <summary>
        /// 描画を実行するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn { get; set; } = true;

        /// <summary>
        /// シーンが変更されても次のシーンへ引き継がれるかどうかを取得または設定します。
        /// </summary>
        public bool IsInherited { get; set; } = true;

        /// <summary>
        /// 更新をするかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated { get; set; } = true;

        /// <summary>
        /// 現在所属している<see cref="Altseed.Scene"/>取得します。
        /// </summary>
        public Scene Scene { get; internal set; }

        public Alject()
        {
            _Components = new RegisterableCollection<AljectComponent, Alject>(this);
            Components = _Components.AsReadOnly();
        }

        /// <summary>
        /// コンポーネントを予め登録して新しいインスタンスを生成する
        /// </summary>
        /// <param name="components">登録するコンポーネントのコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="components"/>がnull</exception>
        internal Alject(IEnumerable<AljectComponent> components) : this()
        {
            _Components.AddImmediately(components);
        }

        #region ComponentRegister
        /// <summary>
        /// 登録されているコンポーネントを取得する
        /// </summary>
        public ReadOnlyCollection<AljectComponent> Components { get; }
        private readonly RegisterableCollection<AljectComponent, Alject> _Components;

        /// <summary>
        /// 指定した<see cref="AljectComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <remarks>追加されるのはそのフレームの更新処理が終了した後</remarks>
        public void AddComponent(AljectComponent component)
        {
            _Components.Add(component);
        }

        /// <summary>
        /// 指定した<see cref="AljectComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void RemoveComponent(AljectComponent component)
        {
            _Components.Remove(component);
        }

        #endregion

        internal void RaiseOnAdded()
        {
            OnAdded();
            foreach (var c in Components)
                if (c.Status == RegisterStatus.Registered)
                    c.RaiseOnObjectAdded();
        }

        internal void RiaseOnRemoved(bool raiseEvent)
        {
            if (raiseEvent)
            {
                OnRemoved();
                foreach (var c in Components)
                    if (c.Status == RegisterStatus.Registered)
                        c.RaiseObjectRemoved();
            }
        }

        internal void Update()
        {
            if (IsUpdated)
            {
                OnUpdate();
                foreach (var c in Components)
                {
                    if (c.Status == RegisterStatus.Registered)
                        c.RaiseOnUpdate();
                }

                _Components.Update();
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

        internal void Draw()
        {
            foreach (var c in Components)
            {
                if (c is DrawnComponent d)
                    d.Draw();
            }

            OnDrawn();
        }

        /// <summary>
        /// 描画時に実行
        /// </summary>
        protected virtual void OnDrawn() { }

        internal override void Added(Scene owner)
        {
            Scene = owner;
            OnAdded();
        }

        internal override void Removed()
        {
            Scene = null;
            OnRemoved();
        }
    }
}
