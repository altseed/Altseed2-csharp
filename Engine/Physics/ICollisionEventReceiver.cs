namespace Altseed
{
    /// <summary>
    /// 衝突判定を感知するイベントを提供するインターフェイス
    /// </summary>
    public interface ICollisionEventReceiver
    {
        /// <summary>
        /// 衝突した時に呼び出される
        /// </summary>
        /// <param name="info">衝突に関する情報</param>
        void OnCollision(CollisionInfo info);
    }
}
