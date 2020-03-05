using System;

namespace Altseed
{
    [Serializable]
    internal enum SceneStatus : int
    {
        /// <summary>
        /// 未登録
        /// インスタンス生成時のデフォルト
        /// </summary>
        Free,

        /// <summary>
        /// フェードイン開始
        /// </summary>
        FadingIn,

        /// <summary>
        /// アップデート開始
        /// 引継ぎ処理実行済み
        /// </summary>
        StartUpdating,

        /// <summary>
        /// 遷移が終了し、登録されている
        /// </summary>
        Updated,

        /// <summary>
        /// フェードアウト開始
        /// </summary>
        FadingOut,

        /// <summary>
        /// アップデート終了
        /// 引継ぎ処理実行開始
        /// </summary>
        StopUpdating,

        /// <summary>
        /// 破棄待ち
        /// </summary>
        WaitDisposed,

        /// <summary>
        /// 破棄済み
        /// </summary>
        Disposed,

        /// <summary>
        /// 未知
        /// </summary>
        UnKnown
    }
}