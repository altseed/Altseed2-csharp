using System;

namespace Altseed.ComponentSystem
{
    /// <summary>
    /// <see cref="Scene"/>に登録できるコンポーネントを表します。
    /// </summary>
    [Serializable]
    public abstract class SceneComponent : Registerable<Scene>
    {
        /// <summary>
        /// 更新処理を行うかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated { get; set; } = true;

        /// <summary>
        /// このコンポーネントを所有する<see cref="Scene"/>を取得します。
        /// </summary>
        public Scene Owner { get; internal set; }

        internal void RaiseOnUpdating()
        {
            if (IsUpdated) OnUpdating();
        }

        internal void RaiseOnUpdated()
        {
            if (IsUpdated) OnUpdated();
        }

        /// <summary>
        /// シーン更新前に実行します。
        /// </summary>
        protected virtual void OnUpdating() { }

        /// <summary>
        /// シーン更新後に実行します。
        /// </summary>
        protected virtual void OnUpdated() { }

        /// <summary>
        /// シーンに追加します。
        /// </summary>
        internal sealed override void Added(Scene owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// シーンから削除します。
        /// </summary>
        internal sealed override void Removed()
        {
            Owner = null;
        }
    }
}
