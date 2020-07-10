using System;

namespace Altseed2
{
    /// <summary>
    /// 短形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class RectangleColliderNode : ColliderNode
    {
        private bool changed;

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        public RectangleCollider RectangleCollider { get; }
        internal override Collider Collider => RectangleCollider;

        public override Vector2F Size
        {
            get => base.Size;
            set
            {
                if (base.Size == value) return;
                base.Size = value;
                changed = true;
            }
        }

        /// <summary>
        /// 既定の<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleColliderNode() : this(new RectangleCollider()) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.RectangleCollider"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="collider"/>がnull</exception>
        public RectangleColliderNode(RectangleCollider collider)
        {
            RectangleCollider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = Size * scale;
        }

        public override void AdjustSize() { }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = Size * scale;

            if (changed)
            {
                UpdateVisualizerPolygon();
                changed = false;
            }
        }

        private protected override void UpdateVisualizerPolygon()
        {
            if (!TryGetVisualizePolygon(out var polygon)) return;

            var positions = new Vector2F[4];
            positions[0] = new Vector2F(0.0f, 0.0f);
            positions[1] = new Vector2F(0.0f, Size.Y);
            positions[2] = new Vector2F(Size.X, Size.Y);
            positions[3] = new Vector2F(Size.X, 0.0f);
            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            polygon.CreateVertexesByVector2F(array);
            polygon.OverwriteVertexesColor(AreaColor);
        }
    }
}
