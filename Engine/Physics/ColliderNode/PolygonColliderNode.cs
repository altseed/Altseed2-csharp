using System;

namespace Altseed2
{
    /// <summary>
    /// ポリゴンコライダを管理するノード
    /// </summary>
    [Serializable]
    public class PolygonColliderNode : ColliderNode
    {
        private int version;

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        internal PolygonCollider PolygonCollider { get; }
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
                version++;
            }
        }
        private Vector2F[] _vertexes = Array.Empty<Vector2F>();

        /// <summary>
        /// 既定の<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        public PolygonColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.PolygonCollider"/>のインスタンス</param>
        internal PolygonColliderNode(PolygonCollider collider)
        {
            PolygonCollider = collider ?? new PolygonCollider();

            MathHelper.CalcFromTransform2D(AbsoluteTransform, out var position, out _, out var angle);
            Collider.Position = position;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);
        }

        public override void AdjustSize()
        {
            MathHelper.GetMinMax(out var min, out var max, _vertexes);
            base.Size = max - min;
        }

        internal override void UpdateCollider()
        {
            UpdateInheritedTransform();

            MathHelper.CalcFromTransform2D(AbsoluteTransform, out var position, out var scale, out var angle);
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

        [Serializable]
        internal sealed class PolygonColliderVisualizeNode : ColliderVisualizeNode
        {
            private readonly PolygonColliderNode owner;
            private int currentVersion;

            internal PolygonColliderVisualizeNode(PolygonColliderNode owner)
            {
                this.owner = owner;
                currentVersion = owner.version;

                UpdatePolygon();
            }

            internal override void UpdatePolygon()
            {
                var vertexes = owner._vertexes;
                MathHelper.GetMinMax(out var min, out _, vertexes);

                var positions = new Vector2F[vertexes.Length];
                for (int i = 0; i < vertexes.Length; i++) positions[i] = vertexes[i] - min;

                var array = Vector2FArray.Create(vertexes.Length);
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
