namespace Altseed
{
    /// <summary>
    /// <see cref="Scene"/>に登録できるコンポーネントのクラス
    /// </summary>
    public abstract class SceneComponent : Component
    {
        /// <summary>
        /// 更新処理を行うかどうかを取得または設定する
        /// </summary>
        public bool IsUpdated { get; set; }
        /// <summary>
        /// このコンポーネントを所有する<see cref="Scene"/>を取得する
        /// </summary>
        public Scene Owner { get; internal set; }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected SceneComponent()
        {
            IsUpdated = true;
        }
        internal void RaiseOnUpdating()
        {
            if (IsUpdated) OnUpdating();
        }
        internal void RaiseOnUpdated()
        {
            if (IsUpdated) OnUpdated();
        }
        /// <summary>
        /// シーン更新前に実行
        /// </summary>
        protected virtual void OnUpdating() { }
        /// <summary>
        /// シーン更新後に実行
        /// </summary>
        protected virtual void OnUpdated() { }
    }
}
