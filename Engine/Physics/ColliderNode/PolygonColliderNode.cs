using System;

namespace Altseed2
{
    /// <summary>
    /// ポリゴンコライダを管理するノード
    /// </summary>
    [Serializable]
    public class PolygonColliderNode : ColliderNode
    {
        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        public PolygonCollider PolygonCollider { get; }
        internal override Collider Collider => PolygonCollider;

        /// <summary>
        /// 頂点情報の配列を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public Vector2F[] Vertexes
        {
            get => _vertexes;
            set
            {
                _vertexes = value ?? throw new ArgumentNullException(nameof(value), "引数がnullです");
                AdjustSize();
            }
        }
        private Vector2F[] _vertexes = Array.Empty<Vector2F>();

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public new Vector2F Size => base.Size;

        /// <summary>
        /// 既定の<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public PolygonColliderNode() : this(new PolygonCollider()) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.PolygonCollider"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="collider"/>がnull</exception>
        public PolygonColliderNode(PolygonCollider collider)
        {
            PolygonCollider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");
        }

        public override void AdjustSize()
        {
            MathHelper.GetMinMax(out var min, out var max, _vertexes);
            base.Size = max - min;
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);

            var count = _vertexes.Length;
            var array = new Vector2F[count];
            for (int i = 0; i < count; i++) array[i] = _vertexes[i] * Scale;

            PolygonCollider.VertexArray = _vertexes;
        }
    }
}
