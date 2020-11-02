using System;

namespace Altseed2
{
    /// <summary>
    /// 線分コライダを管理するノード
    /// </summary>
    [Serializable]
    public class EdgeColliderNode : ColliderNode
    {
        private bool requireUpdate = true;

        /// <summary>
        /// 使用するコライダを取得します。
        /// </summary>
        internal EdgeCollider EdgeCollider { get; }
        internal override Collider Collider => EdgeCollider;

        /// <summary>
        /// 線分の始点を取得または設定します。
        /// </summary>
        public Vector2F Point1
        {
            get => EdgeCollider.Point1;
            set
            {
                if (EdgeCollider.Point1 == value) return;

                EdgeCollider.Point1 = value;
                requireUpdate = true;
            }
        }

        /// <summary>
        /// 線分の終点を取得または設定します。
        /// </summary>
        public Vector2F Point2
        {
            get => EdgeCollider.Point2;
            set
            {
                if (EdgeCollider.Point2 == value) return;

                EdgeCollider.Point2 = value;
                requireUpdate = true;
            }
        }

        /// <summary>
        /// 既定の<see cref="Altseed2.EdgeCollider"/>を使用して<see cref="EdgeColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public EdgeColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.EdgeCollider"/>を使用して<see cref="EdgeColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.EdgeCollider"/>のインスタンス</param>
        internal EdgeColliderNode(EdgeCollider collider)
        {
            EdgeCollider = collider ?? new EdgeCollider();
        }

        internal override void UpdateCollider()
        {
            if (!requireUpdate) return;

            UpdateVersion();
            requireUpdate = false;
        }
    }

    [Serializable]
    internal sealed class EdgeColliderVisualizeNode : LineNode
    {
        private readonly EdgeColliderNode _Owner;
        private int _CurrentVersion;

        internal EdgeColliderVisualizeNode(EdgeColliderNode owner)
        {
            Color = ColliderVisualizeNodeFactory.AreaColor;
            Thickness = 3;
            _Owner = owner;
            _CurrentVersion = owner._Version;
            UpdateEdge();
        }

        internal override void Update()
        {
            if (_CurrentVersion != _Owner._Version)
                UpdateEdge();

            base.Update();
        }

        private void UpdateEdge()
        {
            _CurrentVersion = _Owner._Version;
            Point1 = _Owner.Point1;
            Point2 = _Owner.Point2;
        }
    }
}
