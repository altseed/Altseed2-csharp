namespace Altseed
{
    /// <summary>
    /// <see cref="Alject"/>に登録できるコンポーネントのクラス
    /// </summary>
    public abstract class AljectComponent : Component
    {
        /// <summary>
        /// 更新処理を行うかどうかを取得または設定する
        /// </summary>
        public bool IsUpdated { get; set; }
        /// <summary>
        /// このコンポーネントを所有する<see cref="Alject"/>を取得する
        /// </summary>
        public Alject Owner { get; internal set; }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected AljectComponent()
        {
            IsUpdated = true;
        }
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
    }
}
