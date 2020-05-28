using System;

namespace Altseed
{
    /// <summary>
    /// 登録状況を表します。
    /// </summary>
    [Serializable]
    public enum RegisterStatus : int
    {
        /// <summary>
        /// 所属なし
        /// </summary>
        Free,
        /// <summary>
        /// 追加待ち
        /// </summary>
        WaitAdded,
        /// <summary>
        /// 所属有り
        /// </summary>
        Registered,
        /// <summary>
        /// 削除待ち
        /// </summary>
        WaitRemoved,
    }
}
