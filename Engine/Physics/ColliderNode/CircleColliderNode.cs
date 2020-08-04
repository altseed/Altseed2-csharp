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
                UpdateVersion();
            }
        }
        private float _radius;

        /// <summary>
        /// 拡大率の計算方法を取得または設定します。
        /// </summary>
        /// <remarks>既定値：<see cref="ScaleCalcType.AbsMax"/></remarks>
        public ScaleCalcType ScaleType { get; set; } = ScaleCalcType.AbsMax;

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
            CircleCollider = collider ?? CircleCollider.Create();
        }

        internal override void UpdateCollider()
        {
            MathHelper.CalcFromTransform2D(InheritedTransform, out var position, out var scale, out var angle);
            Collider.Position = position - CenterPosition;
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
            UpdateVersion();
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
