using System;

namespace Altseed2
{
    /// <summary>
    /// 短形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class RectangleColliderNode : ColliderNode
    {
        private int version;

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        internal RectangleCollider RectangleCollider { get; }
        internal override Collider Collider => RectangleCollider;

        /// <summary>
        /// 短形のサイズを取得または設定します。
        /// </summary>
        public Vector2F RectangleSize
        {
            get => _rectangleSize;
            set
            {
                if (_rectangleSize == value) return;
                _rectangleSize = value;
                version++;
            }
        }
        private Vector2F _rectangleSize;

        public override Vector2F Size
        {
            get => base.Size;
            set
            {
                if (base.Size == value) return;
                base.Size = value;

                if (_rectangleSize.X != 0 && _rectangleSize.Y != 0) Scale = value / _rectangleSize;
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
        internal RectangleColliderNode(RectangleCollider collider)
        {
            RectangleCollider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");

            MathHelper.CalcFromTransform2D(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = _rectangleSize * scale;
        }

        public override void AdjustSize()
        {
            base.Size = _rectangleSize;
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform2D(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = _rectangleSize * scale;
        }

        [Serializable]
        internal sealed class RectangleColliderVisualizeNode : ColliderVisualizeNode
        {
            private readonly RectangleColliderNode owner;
            private int currentVersion;

            internal RectangleColliderVisualizeNode(RectangleColliderNode owner)
            {
                this.owner = owner;
                currentVersion = owner.version;

                UpdatePolygon();
            }

            internal override void UpdatePolygon()
            {
                var positions = new Vector2F[4];
                var Size = owner._rectangleSize;

                positions[0] = new Vector2F(0.0f, 0.0f);
                positions[1] = new Vector2F(0.0f, Size.Y);
                positions[2] = new Vector2F(Size.X, Size.Y);
                positions[3] = new Vector2F(Size.X, 0.0f);

                var array = Vector2FArray.Create(positions.Length);
                array.FromArray(positions);
                RenderedPolygon.CreateVertexesByVector2F(array);
                RenderedPolygon.OverwriteVertexesColor(AreaColor);
            }

            internal override void UpdateInheritedTransform()
            {
                base.UpdateInheritedTransform();

                if (currentVersion != owner.version)
                {
                    UpdatePolygon();
                    currentVersion = owner.version;
                }
            }
        }
    }
}
