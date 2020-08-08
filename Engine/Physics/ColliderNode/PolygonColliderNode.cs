using System;

namespace Altseed2
{
    /// <summary>
    /// ポリゴンコライダを管理するノード
    /// </summary>
    [Serializable]
    public class PolygonColliderNode : ColliderNode
    {
        private bool requireUpdate = true;

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize
        {
            get
            {
                MathHelper.GetMinMax(out var min, out var max, _vertexes);
                return max - min;
            }
        }

        /// <summary>
        /// 使用するコライダを取得する
        /// </summary>
        internal readonly PolygonCollider PolygonCollider;
        internal override Collider Collider => PolygonCollider;

        /// <inheritdoc/>
        public sealed override Matrix44F InheritedTransform
        {
            get => _InheritedTransform;
            internal set
            {
                if (_InheritedTransform == value) return;
                _InheritedTransform = value;
                requireUpdate = true;
                Collider.Transform = value * Matrix44F.GetTranslation2D(-CenterPosition);
            }
        }

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
                requireUpdate = true;
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
            if (!requireUpdate) return;

            var scale = CalcScale(InheritedTransform);

            var array = new Vector2F[_vertexes.Length];
            for (int i = 0; i < _vertexes.Length; i++) array[i] = _vertexes[i] * scale - CenterPosition;
            PolygonCollider.VertexArray = array;

            UpdateVersion();
            requireUpdate = false;
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
            SetVertexes(_Owner.Vertexes, ColliderVisualizeNodeFactory.AreaColor);
            CenterPosition = _Owner.CenterPosition;

            _CurrentVersion = _Owner._Version;
        }
    }
}
