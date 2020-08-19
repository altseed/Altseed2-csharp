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
        /// 拡大率を適用する方法を表します。
        /// </summary>
        [Serializable]
        public enum ScaleCalcType
        {
            /// <summary>
            /// Scale.Xで計算します。
            /// </summary>
            X,
            /// <summary>
            /// Scale.Yで計算します。
            /// </summary>
            Y,
            /// <summary>
            /// Scale.Lengthで計算します。
            /// </summary>
            Length,
            /// <summary>
            /// X，Yの最小値で計算します。
            /// </summary>
            Min,
            /// <summary>
            /// X，Yの最大値で計算します。
            /// </summary>
            Max,
            /// <summary>
            /// X，Yの絶対値の最小値で計算します。
            /// </summary>
            AbsMin,
            /// <summary>
            /// X，Yの絶対値の最大値で計算します。
            /// </summary>
            AbsMax
        }

        private bool requireUpdate = true;

        /// <summary>
        /// 使用するコライダを取得します。
        /// </summary>
        internal CircleCollider CircleCollider { get; }
        internal override Collider Collider => CircleCollider;

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize => new Vector2F(Radius * 2, Radius * 2);

        /// <inheritdoc/>
        public sealed override Matrix44F InheritedTransform
        {
            get => base.InheritedTransform;
            protected internal set
            {
                if (base.InheritedTransform == value) return;
                base.InheritedTransform = value;
                AbsoluteTransform = value * Matrix44F.GetTranslation2D(-CenterPosition);
                Collider.Transform = AbsoluteTransform;
                requireUpdate = true;
            }
        }

        /// <summary>
        /// 衝突半径を取得または設定します。
        /// </summary>
        public float Radius
        {
            get => _radius;
            set
            {
                if (_radius == value) return;
                _radius = value;
                requireUpdate = true;
            }
        }
        private float _radius;

        /// <summary>
        /// 拡大率の計算方法を取得または設定します。
        /// </summary>
        /// <remarks>既定値：<see cref="ScaleCalcType.AbsMax"/></remarks>
        public ScaleCalcType ScaleType { get; set; } = ScaleCalcType.AbsMax;

        /// <summary>
        /// 既定の<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public CircleColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.CircleCollider"/>を使用して<see cref="CircleColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.CircleCollider"/>のインスタンス</param>
        internal CircleColliderNode(CircleCollider collider)
        {
            CircleCollider = collider ?? CircleCollider.Create();
        }

        internal override void UpdateCollider()
        {
            if (!requireUpdate) return;
            var scale = CalcScale(InheritedTransform);
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

            UpdateVersion();
            requireUpdate = false;
        }
    }

    [Serializable]
    internal sealed class CircleColliderVisualizeNode : CircleNode
    {
        private readonly CircleColliderNode _Owner;
        private int _CurrentVersion;

        internal CircleColliderVisualizeNode(CircleColliderNode owner)
        {
            VertNum = ColliderVisualizeNodeFactory.VertNum;
            Color = ColliderVisualizeNodeFactory.AreaColor;
            _Owner = owner;
            _CurrentVersion = owner._Version;

            UpdateCircle();
        }

        internal override void Update()
        {
            if (_CurrentVersion != _Owner._Version)
                UpdateCircle();

            base.Update();
        }

        private void UpdateCircle()
        {
            Radius = _Owner.Radius;
            CenterPosition = _Owner.CenterPosition;

            _CurrentVersion = _Owner._Version;
        }
    }
}
