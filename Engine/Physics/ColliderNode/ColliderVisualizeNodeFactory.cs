using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="ColliderNode"/>の当たり判定範囲として描画されるノードの基底クラス
    /// </summary>
    [Serializable]
    public static class ColliderVisualizeNodeFactory
    {
        internal readonly static int VertNum = 64;
        internal readonly static Color AreaColor = new Color(255, 100, 100, 100);

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>の当たり判定領域を表示するノードを生成する
        /// </summary>
        /// <param name="colliderNode">使用するコライダノード</param>
        /// <exception cref="ArgumentNullException"><paramref name="colliderNode"/>がnull</exception>
        /// <returns><paramref name="colliderNode"/>の当たり領域を表示するノード</returns>
        public static Node Create(ColliderNode colliderNode)
        {
            if (colliderNode == null) throw new ArgumentNullException(nameof(colliderNode), "引数がnullです");
            return colliderNode switch
            {
                CircleColliderNode c => new CircleColliderVisualizeNode(c),
                PolygonColliderNode p => new PolygonColliderVisualizeNode(p),
                RectangleColliderNode r => new RectangleColliderVisualizeNode(r),
                _ => throw new ArgumentException($"サポートされていない型です\n型：{colliderNode.GetType()}", nameof(colliderNode))
            };
        }
    }
}
