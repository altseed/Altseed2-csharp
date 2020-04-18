using System;

namespace Altseed
{
    /// <summary>
    /// 衝突判定に関する情報を格納したクラス
    /// </summary>
    [Serializable]
    public sealed class CollisionInfo
    {
        /// <summary>
        /// 自身のコライダを取得する
        /// </summary>
        public Collider SelfCollider { get; }

        /// <summary>
        /// 衝突相手のコライダを取得する
        /// </summary>
        public Collider TheirsCollider { get; }

        internal CollisionInfo(Collider selfCollider, Collider theirsCollider)
        {
            SelfCollider = selfCollider ?? throw new ArgumentNullException(nameof(selfCollider), "引数がnullです");
            TheirsCollider = theirsCollider ?? throw new ArgumentNullException(nameof(theirsCollider), "引数がnullです");
        }
    }
}
