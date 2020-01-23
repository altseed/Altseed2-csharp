using System;

namespace Altseed
{
    [Serializable]
    internal enum ObjectStatus : int
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
        /// <summary>
        /// 破棄待ち
        /// </summary>
        WaitDisposed,
        /// <summary>
        /// 破棄済み
        /// </summary>
        Disposed
    }
}
