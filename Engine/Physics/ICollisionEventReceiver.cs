namespace Altseed2
{
    /// <summary>
    /// 衝突判定を感知するイベントを提供するインターフェイス
    /// </summary>
    public interface ICollisionEventReceiver
    {
        /// <summary>
        /// 衝突を開始した時に呼び出される
        /// </summary>
        /// <param name="info">衝突に関する情報</param>
        void OnCollisionEnter(CollisionInfo info);
        /// <summary>
        /// 衝突を終了した時に呼び出される
        /// </summary>
        /// <param name="info">衝突に関する情報</param>
        void OnCollisionExit(CollisionInfo info);
        /// <summary>
        /// 衝突が継続している時に呼び出される
        /// </summary>
        /// <param name="info">衝突に関する情報</param>
        void OnCollisionStay(CollisionInfo info);
    }
}
