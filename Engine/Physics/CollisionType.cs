using System;

namespace Altseed2
{
    /// <summary>
    /// 衝突のタイプ
    /// </summary>
    [Serializable]
    public enum CollisionType : int
    {
        /// <summary>
        /// 前フレームでは衝突しておらず，このフレームで衝突している
        /// </summary>
        Enter,
        /// <summary>
        /// 前フレームでは衝突しており，このフレームでも衝突している
        /// </summary>
        Stay,
        /// <summary>
        /// 前フレームでは衝突しており，このフレームで衝突していない
        /// </summary>
        Exit
    }
}
