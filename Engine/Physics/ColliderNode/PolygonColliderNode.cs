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
        /// 衝突判定が行われる範囲を描画するノードを取得します
        /// </summary>
        public PolygonNode CollisionArea => _collisionArea ??= CreateShapeNode();
        private PolygonNode _collisionArea;

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
                if (value == null) throw new ArgumentNullException(nameof(value), "引数がnullです");
                if (value == _vertexes || (_vertexes.Length == 0 && value.Length == 0)) return;
                _vertexes = value;
                AdjustSize();
                if (_collisionArea == null) return;
                _collisionArea.SetVertexes(value, AreaColor);
                _collisionArea.AdjustSize();
                MathHelper.GetMinMax(out var min, out _, value);
                _collisionArea.Position = -min;
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

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
        }

        public override void AdjustSize()
        {
            MathHelper.GetMinMax(out var min, out var max, _vertexes);
            base.Size = max - min;
        }

        private PolygonNode CreateShapeNode()
        {
            var result = new PolygonNode();
            result.SetVertexes(Vertexes, AreaColor);
            var anc = GetAncestorSpecificNode<DrawnNode>();
            if (anc != null) result.ZOrder = anc.ZOrder;
            MathHelper.GetMinMax(out var min, out _, _vertexes);
            result.Position = -min;
            result.AdjustSize();
            return result;
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform(AbsoluteTransform, out var position, out var scale, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);

            var count = _vertexes.Length;
            var array = new Vector2F[count];
            if (array.Length > 0)
            {
                MathHelper.GetMinMax(out var min, out _, _vertexes);
                for (int i = 0; i < count; i++) array[i] = _vertexes[i] * scale - min;
            }

            PolygonCollider.VertexArray = array;
        }

        internal override void Update()
        {
            base.Update();

            if (_collisionArea == null) return;
            var anc = GetAncestorSpecificNode<DrawnNode>();
            if (anc != null) _collisionArea.ZOrder = anc.ZOrder;
        }
    }
}
