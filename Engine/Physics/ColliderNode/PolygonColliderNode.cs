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
        /// 使用するコライダを取得する
        /// </summary>
        internal PolygonCollider PolygonCollider { get; }
        internal override Collider Collider => PolygonCollider;

        /// <summary>
        /// 頂点情報の配列を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        internal Vector2F[] Vertexes
        {
            get => _vertexes;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "引数がnullです");
                if (value == _vertexes || (_vertexes.Length == 0 && value.Length == 0)) return;
                _vertexes = value;
                UpdateVersion();
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
            PolygonCollider = collider ?? PolygonCollider.Create();
        }

        internal override void UpdateCollider()
        {
            MathHelper.CalcFromTransform2D(InheritedTransform, out var position, out var scale, out var angle);
            Collider.Position = position ;
            Collider.Rotation = MathHelper.DegreeToRadian(angle);

            var array = new Vector2F[_vertexes.Length];
            for (int i = 0; i < _vertexes.Length; i++) array[i] = _vertexes[i] * scale - CenterPosition;
            PolygonCollider.VertexArray = array;

            UpdateVersion();
        }
    }

    [Serializable]
    internal sealed class PolygonColliderVisualizeNode : PolygonNode
    {
        private readonly PolygonColliderNode _Owner;
        private int _CurrentVersion;

        internal PolygonColliderVisualizeNode(PolygonColliderNode owner)
        {
            _Owner = owner;
            _CurrentVersion = owner._Version;

            UpdatePolygon();
        }

        internal override void Update()
        {
            if (_CurrentVersion != _Owner._Version)
                UpdatePolygon();

            base.Update();
        }

        private void UpdatePolygon()
        {
            var vertexes = new Vector2F[_Owner.Vertexes.Length];
            SetVertexes(_Owner.Vertexes, ColliderVisualizeNodeFactory.AreaColor);
            CenterPosition = _Owner.CenterPosition;
            _CurrentVersion = _Owner._Version;
        }
    }
}
