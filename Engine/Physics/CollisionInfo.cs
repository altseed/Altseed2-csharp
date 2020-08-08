using System;

namespace Altseed2
{
    /// <summary>
    /// 衝突判定に関する情報を格納したクラス
    /// </summary>
    [Serializable]
    public sealed class CollisionInfo
    {
        /// <summary>
        /// 衝突の種類を取得する
        /// </summary>
        public readonly CollisionType CollisionType;

        /// <summary>
        /// 自身の<see cref="ColliderNode"/>を取得する
        /// </summary>
        public readonly ColliderNode SelfCollider;

        /// <summary>
        /// 衝突相手の<see cref="ColliderNode"/>を取得する
        /// </summary>
        public readonly ColliderNode TheirsCollider;

        internal CollisionInfo(ColliderNode selfCollider, ColliderNode theirsCollider, CollisionType type)
        {
            SelfCollider = selfCollider ?? throw new ArgumentNullException(nameof(selfCollider), "引数がnullです");
            TheirsCollider = theirsCollider ?? throw new ArgumentNullException(nameof(theirsCollider), "引数がnullです");
            CollisionType = type;
        }
    }
}
