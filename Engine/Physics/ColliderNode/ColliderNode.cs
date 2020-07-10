using System;

namespace Altseed2
{
    /// <summary>
    /// コライダを管理するノード
    /// </summary>
    [Serializable]
    public abstract class ColliderNode : TransformNode
    {
        internal readonly static Color AreaColor = new Color(255, 100, 100, 100);

        public override Matrix44F AbsoluteTransform => _absoluteTransform;
        private Matrix44F _absoluteTransform;

        /// <summary>
        /// コライダを取得する
        /// </summary>
        internal abstract Collider Collider { get; }

        internal RenderedPolygon VisualizerPolygon
        {
            get
            {
                if (_visualizerPolygon == null)
                {
                    _visualizerPolygon = RenderedPolygon.Create();
                    _visualizerPolygon.Transform = _absoluteTransform;
                    UpdateVisualizerPolygon();
                }
                return _visualizerPolygon;
            }
        }
        private RenderedPolygon _visualizerPolygon;

        /// <summary>
        /// <see cref="ColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        protected ColliderNode() { }

        /// <summary>
        /// 指定した<see cref="ColliderNode"/>の当たり判定領域を表示するノードを生成する
        /// </summary>
        /// <param name="colliderNode">使用するコライダノード</param>
        /// <exception cref="ArgumentNullException"><paramref name="colliderNode"/>がnull</exception>
        /// <returns><paramref name="colliderNode"/>の当たり当たり領域を表示するノード</returns>
        public static ColliderVisualizeNode CreateVisualizeNode(ColliderNode colliderNode)
        {
            if (colliderNode == null) throw new ArgumentNullException(nameof(colliderNode), "引数がnullです");
            return new ColliderVisualizeNode(colliderNode.VisualizerPolygon);
        }

        private static CollisionManagerNode SearchManagerFromChildren(Node node)
        {
            if (node == null) return null;
            foreach (var current in node.Children)
                if (current is CollisionManagerNode m)
                    return m;
            return null;
        }

        internal override void Added(Node owner)
        {
            base.Added(owner);
            SearchManagerFromChildren(owner.Parent)?.AddCollider(this);
        }

        internal override void Removed()
        {
            SearchManagerFromChildren(Parent.Parent)?.RemoveCollider(this);
            base.Removed();
        }

        internal bool TryGetVisualizePolygon(out RenderedPolygon result)
        {
            result = _visualizerPolygon;
            return _visualizerPolygon != null;
        }

        internal abstract void UpdateCollider();

        private protected abstract void UpdateVisualizerPolygon();

        internal override void UpdateInheritedTransform()
        {
            _absoluteTransform = CalcInheritedTransform();
            if (_visualizerPolygon != null) _visualizerPolygon.Transform = _absoluteTransform;
        }
    }
}
