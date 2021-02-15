using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="ColliderNode"/>の当たり判定範囲として描画されるノードを提供するクラス
    /// </summary>
    [Serializable]
    public static class ColliderVisualizeNodeFactory
    {
        internal readonly static int VertNum = 64;
        internal readonly static Color AreaColor = new Color(255, 100, 100, 100);

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>の当たり判定領域を表示するノードを生成します。
        /// </summary>
        /// <param name="colliderNode">使用するコライダノード</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="colliderNode"/>の型がサポートされていない型である
        /// (<see cref="CircleColliderNode"/>，<see cref="PolygonColliderNode"/>，<see cref="RectangleColliderNode"/>若しくはそれらから派生した型ではない)
        /// </exception>
        /// <exception cref="InvalidOperationException">Graphics機能が初期化されていない。</exception>
        /// <exception cref="ArgumentNullException"><paramref name="colliderNode"/>がnull</exception>
        /// <returns><paramref name="colliderNode"/>の当たり領域を表示するノード</returns>
        public static Node Create(ColliderNode colliderNode)
        {
            if (!Engine.Config.EnabledCoreModules.HasFlag(CoreModules.Graphics))
            {
                throw new InvalidOperationException("Graphics機能が初期化されていません。");
            }

            if (colliderNode == null) throw new ArgumentNullException(nameof(colliderNode), "引数がnullです");

            return colliderNode switch
            {
                CircleColliderNode c => new CircleColliderVisualizeNode(c),
                PolygonColliderNode p => new PolygonColliderVisualizeNode(p),
                RectangleColliderNode r => new RectangleColliderVisualizeNode(r),
                EdgeColliderNode e => new EdgeColliderVisualizeNode(e),
                _ => throw new ArgumentException($"サポートされていない型です\n型：{colliderNode.GetType()}", nameof(colliderNode))
            };
        }
    }
}
