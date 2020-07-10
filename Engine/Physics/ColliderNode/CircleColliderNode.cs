using System;

namespace Altseed2
{
    /// <summary>
    /// 円形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class CircleColliderNode : ColliderNode
    {
        internal const int VisualizerVertNum = 100;

        private bool changed;

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        public CircleCollider CircleCollider { get; }
        internal override Collider Collider => CircleCollider;

        /// <summary>
        /// 衝突半径を取得または設定する
        /// </summary>
        public float Radius
        {
            get => _radius;
            set
            {
                if (_radius == value) return;
                _radius = value;
                AdjustSize();
                changed = true;
            }
        }
        private float _radius;

        public override Vector2F Size
        {
            get => base.Size;
            set
            {
                if (base.Size == value) return;
                base.Size = value;

                if (Radius != 0) Scale = value / Radius / 2f;
            }
        }

        /// <summary>
        /// 既定の<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CircleColliderNode() : this(new CircleCollider()) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.CircleCollider"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="collider"/>がnull</exception>
        public CircleColliderNode(CircleCollider collider)
        {
            CircleCollider = collider ?? throw new ArgumentNullException(nameof(collider), "引数がnullです");

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            CircleCollider.Radius = Radius * scale;
        }

        public override void AdjustSize()
        {
            var length = Radius * 2;
            Size = new Vector2F(length, length);
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            CircleCollider.Radius = Radius * scale;

            if (changed)
            {
                UpdateVisualizerPolygon();
                changed = false;
            }
        }

        private protected override void UpdateVisualizerPolygon()
        {
            if (!TryGetVisualizePolygon(out var polygon)) return;

            const float deg = 360f / VisualizerVertNum;
            var positions = new Vector2F[VisualizerVertNum];
            var vec = new Vector2F(0.0f, -_radius);

            var rad = new Vector2F(_radius, _radius);
            for (int i = 0; i < VisualizerVertNum; i++)
            {
                positions[i] = vec;
                vec.Degree += deg;
                positions[i] += rad;
            }

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            polygon.CreateVertexesByVector2F(array);
            polygon.OverwriteVertexesColor(AreaColor);
        }
    }
}
