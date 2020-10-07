using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    /// <summary>
    /// 短形コライダのクラス
    /// </summary>
    [Serializable]
    public class RectangleCollider : ShapeCollider
    {
        #region SerializeName
        private const string S_CenterPosition = "S_CenterPosition";
        private const string S_Size = "S_Size";
        #endregion

        private bool requireUpdate = true;

        /// <summary>
        /// 中心座標を取得または設定します。
        /// </summary>
        public Vector2F CenterPosition
        {
            get => _centerPosition;
            set
            {
                if (_centerPosition == value) return;
                _centerPosition = value;
                requireUpdate = true;
            }
        }
        private Vector2F _centerPosition;

        /// <summary>
        /// 短形の大きさを取得または設定します。
        /// </summary>
        public Vector2F Size
        {
            get => _size;
            set
            {
                if (_size == value) return;
                _size = value;
                requireUpdate = true;
            }
        }
        private Vector2F _size;

        /// <summary>
        /// <see cref="RectangleCollider"/>の新しいインスタンスを生成します。
        /// </summary>
        public RectangleCollider()
        {
            Vertexes = Vector2FArray.Create(4);
        }
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RectangleCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RectangleCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _centerPosition = info.GetValue<Vector2F>(S_CenterPosition);
            _size = info.GetValue<Vector2F>(S_Size);

            requireUpdate = true;
        }

        /// <inheritdoc/>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_CenterPosition, _centerPosition);
            info.AddValue(S_Size, _size);
        }

        /// <inheritdoc/>
        public override bool GetIsCollidedWith(Collider collider)
        {
            if (requireUpdate)
            {
                UpdateVertexes();
                requireUpdate = false;
            }
            return base.GetIsCollidedWith(collider);
        }

        private void UpdateVertexes()
        {
            Span<Vector2F> positions = stackalloc Vector2F[4];
            positions[0] = -_centerPosition;
            positions[1] = new Vector2F(_size.X, 0f) - _centerPosition;
            positions[2] = _size - _centerPosition;
            positions[3] = new Vector2F(0f, _size.Y) - _centerPosition;
            SetVertexes(positions);
        }
    }
}
