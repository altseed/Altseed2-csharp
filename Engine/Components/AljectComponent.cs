using System;

namespace Altseed
{
    /// <summary>
    /// <see cref="Alject"/>に登録できるコンポーネントを表します。
    /// </summary>
    [Serializable]
    public abstract class AljectComponent : Registerable<Alject>
    {
        /// <summary>
        /// 更新処理を行うかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated { get; set; } = true;

        /// <summary>
        /// このコンポーネントを所有する<see cref="Alject"/>を取得します。
        /// </summary>
        public Alject Owner { get; internal set; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected AljectComponent() { }

        internal void RaiseOnObjectAdded()
        {
            OnObjectAdded();
        }

        internal void RaiseOnUpdate()
        {
            if (IsUpdated) OnUpdate();
        }

        internal void RaiseObjectRemoved()
        {
            OnObjectRemoved();
        }

        /// <summary>
        /// <see cref="Owner"/>がシーンに登録されたときに実行
        /// </summary>
        protected virtual void OnObjectAdded() { }

        /// <summary>
        /// 更新時に実行
        /// </summary>
        protected virtual void OnUpdate() { }

        /// <summary>
        /// <see cref="Owner"/>がシーンから削除されたときに実行
        /// </summary>
        protected virtual void OnObjectRemoved() { }

        internal sealed override void Added(Alject owner)
        {
            Owner = owner;
        }

        internal sealed override void Removed()
        {
            Owner = null;
        }
    }
}
