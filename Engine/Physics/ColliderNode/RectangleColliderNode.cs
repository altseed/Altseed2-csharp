using System;

namespace Altseed2
{
    /// <summary>
    /// 短形コライダを管理するノード
    /// </summary>
    [Serializable]
    public class RectangleColliderNode : ColliderNode
    {
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
            get => _RectangleSize;
            set
            {
                if (_RectangleSize == value) return;
                _RectangleSize = value;
                UpdateVersion();
            }
        }
        private Vector2F _RectangleSize;

        /// <summary>
        /// 既定の<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public RectangleColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.RectangleCollider"/>を使用して<see cref="RectangleColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.RectangleCollider"/>のインスタンス</param>
        internal RectangleColliderNode(RectangleCollider collider)
        {
            RectangleCollider = collider ?? RectangleCollider.Create();
        }

        internal override void UpdateCollider()
        {
            MathHelper.CalcFromTransform2D(InheritedTransform, out var position, out var scale, out var angle);
            Collider.Position = position - CenterPosition;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
            RectangleCollider.Size = _RectangleSize * scale;

            UpdateVersion();
        }
    }

    [Serializable]
    internal sealed class RectangleColliderVisualizeNode : RectangleNode
    {
        private readonly RectangleColliderNode _Owner;
        private int _CurrentVersion;

        internal RectangleColliderVisualizeNode(RectangleColliderNode owner)
        {
            Color = ColliderVisualizeNodeFactory.AreaColor;
            _Owner = owner;
            _CurrentVersion = owner._Version;
            UpdateRectangle();
        }

        internal override void Update()
        {
            if (_CurrentVersion != _Owner._Version)
                UpdateRectangle();

            base.Update();
        }

        private void UpdateRectangle()
        {
            RectangleSize = _Owner.RectangleSize * _Owner.Scale;
            CenterPosition = _Owner.CenterPosition;

            _CurrentVersion = _Owner._Version;
        }
    }
}
