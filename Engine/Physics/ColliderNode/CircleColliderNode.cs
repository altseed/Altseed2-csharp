using System;

namespace Altseed2
{
    /// <summary>
    /// 円形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class CircleColliderNode : ColliderNode
    {
        /// <summary>
        /// 拡大率を適用する方法を表す
        /// </summary>
        [Serializable]
        public enum ScaleCalcType
        {
            /// <summary>
            /// Scale.Xで計算する
            /// </summary>
            X,
            /// <summary>
            /// Scale.Yで計算する
            /// </summary>
            Y,
            /// <summary>
            /// Scale.Lengthで計算する
            /// </summary>
            Length,
            /// <summary>
            /// X，Yの最小値で計算する
            /// </summary>
            Min,
            /// <summary>
            /// X，Yの最大値で計算する
            /// </summary>
            Max,
            /// <summary>
            /// X，Yの絶対値の最小値で計算する
            /// </summary>
            AbsMin,
            /// <summary>
            /// X，Yの絶対値の最大値で計算する
            /// </summary>
            AbsMax
        }

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        internal CircleCollider CircleCollider { get; }
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
                Version++;
            }
        }
        private float _radius;

        /// <summary>
        /// 拡大率の計算方法を取得または設定します。
        /// </summary>
        /// <remarks>既定値：<see cref="ScaleCalcType.AbsMax"/></remarks>
        public ScaleCalcType ScaleType { get; set; } = ScaleCalcType.AbsMax;

        //public override Vector2F Size
        //{
        //    get => base.Size;
        //    set
        //    {
        //        if (base.Size == value) return;
        //        base.Size = value;

        //        if (Radius != 0) Scale = value / Radius / 2f;
        //    }
        //}

        internal int Version { get; private set; }

        /// <summary>
        /// 既定の<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CircleColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.CircleCollider"/>のインスタンス</param>
        internal CircleColliderNode(CircleCollider collider)
        {
            CircleCollider = collider ?? new CircleCollider();

            MathHelper.CalcFromTransform2D(InheritedTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            CircleCollider.Radius = Radius * (ScaleType switch
            {
                ScaleCalcType.X => scale.X,
                ScaleCalcType.Y => scale.Y,
                ScaleCalcType.Length => scale.Length,
                ScaleCalcType.AbsMin => Math.Min(scale.X, scale.Y),
                ScaleCalcType.AbsMax => Math.Max(scale.X, scale.Y),
                _ => 1.0f
            });
        }

        //public override void AdjustSize()
        //{
        //    var length = Radius * 2;
        //    base.Size = new Vector2F(length, length);
        //}

        internal override void UpdateCollider()
        {
            //UpdateInheritedTransform();

            MathHelper.CalcFromTransform2D(InheritedTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            CircleCollider.Radius = Radius * (ScaleType switch
            {
                ScaleCalcType.X => scale.X,
                ScaleCalcType.Y => scale.Y,
                ScaleCalcType.Length => scale.Length,
                ScaleCalcType.Max => Math.Max(scale.X, scale.Y),
                ScaleCalcType.Min => Math.Min(scale.X, scale.Y),
                ScaleCalcType.AbsMin => Math.Min(Math.Abs(scale.X), Math.Abs(scale.Y)),
                ScaleCalcType.AbsMax => Math.Max(Math.Abs(scale.X), Math.Abs(scale.Y)),
                _ => 1.0f
            });
        }
    }

    [Serializable]
    internal sealed class CircleColliderVisualizeNode : ColliderVisualizeNode
    {
        internal const int VisualizerVertNum = 100;

        private readonly CircleColliderNode owner;
        private int currentVersion;

        internal CircleColliderVisualizeNode(CircleColliderNode owner)
        {
            this.owner = owner;
            currentVersion = owner.Version;

            UpdatePolygon();
        }

        private protected override void UpdatePolygon()
        {
            const float deg = 360f / VisualizerVertNum;
            var positions = new Vector2F[VisualizerVertNum];
            var radius = owner.Radius;
            var vec = new Vector2F(0.0f, -radius);

            var rad = new Vector2F(radius, radius);
            for (int i = 0; i < VisualizerVertNum; i++)
            {
                positions[i] = vec;
                vec.Degree += deg;
                positions[i] += rad;
            }

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            RenderedPolygon.CreateVertexesByVector2F(array);
            RenderedPolygon.OverwriteVertexesColor(AreaColor);
        }

        internal void UpdateInheritedTransform()
        {
            base.UpdateInheritedTransform();

            if (currentVersion != owner.Version)
            {
                UpdatePolygon();
                currentVersion = owner.Version;
            }
        }
    }
}
