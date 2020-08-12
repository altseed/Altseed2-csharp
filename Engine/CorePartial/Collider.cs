using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed2
{
    public partial class Collider
    {
        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        public Vector2F Position
        {
            get => _position ??= cbg_Collider_GetPosition(selfPtr);
            set
            {
                if (_position == value) return;
                _position = value;
                cbg_Collider_SetPosition(selfPtr, value);
                _transform = null;
            }
        }
        private Vector2F? _position;

        /// <summary>
        /// 回転(弧度法)を取得または設定します。
        /// </summary>
        public float Rotation
        {
            get => _rotation ??= cbg_Collider_GetRotation(selfPtr);
            set
            {
                if (_rotation == value) return;
                _rotation = value;
                cbg_Collider_SetRotation(selfPtr, value);
                _transform = null;
            }
        }
        private float? _rotation;

        /// <summary>
        /// 変形行列を取得または設定します。
        /// </summary>
        public Matrix44F Transform
        {
            get => _transform ??= cbg_Collider_GetTransform(selfPtr);
            set
            {
                if (_transform == value) return;
                _transform = value;
                cbg_Collider_SetTransform(selfPtr, value);
                _position = null;
                _rotation = null;
            }
        }
        private Matrix44F? _transform;
    }

    public partial class CircleCollider
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_CircleCollider_Create();
        }
    }

    public partial class RectangleCollider
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RectangleCollider_Create();
        }
    }

    public partial class PolygonCollider
    {
        #region SerializeName
        private const string S_Vertexes = "S_Vertexes";
        #endregion

        /// <summary>
        /// 頂点情報のコレクションを取得または設定します。
        /// </summary>
        public IReadOnlyList<Vector2F> Vertexes
        {
            get => VertexesInternal?.ToArray();
            set
            {
                SetVertexes(value);
            }
        }

        internal Vector2FArray VertexesInternal
        {
            get => Vector2FArray.TryGetFromCache(cbg_PolygonCollider_GetVertexes(selfPtr));
            private set
            {
                cbg_PolygonCollider_SetVertexes(selfPtr, value?.selfPtr ?? IntPtr.Zero);
            }
        }
        private Vector2FArray _vertexesInternalCache;

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_PolygonCollider_Create();
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            VertexesInternal = info.GetValue<Vector2FArray>(S_Vertexes);
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Vertexes, VertexesInternal);
        }

        /// <summary>
        /// 指定した座標に頂点を設定します。
        /// </summary>
        /// <param name="positions">設定する座標</param>
        public void SetVertexes(IEnumerable<Vector2F> positions)
        {
            if (positions is null)
            {
                VertexesInternal = null;
                return;
            }

            if (_vertexesInternalCache is null)
            {
                _vertexesInternalCache = Vector2FArray.Create(positions);
            }
            else
            {
                _vertexesInternalCache.FromEnumerable(positions, positions.Count());
            }
            VertexesInternal = _vertexesInternalCache;
        }

        /// <summary>
        /// 指定した座標に頂点を設定する
        /// </summary>
        /// <param name="positions">設定する座標</param>
        public void SetVertexes(ReadOnlySpan<Vector2F> positions)
        {
            if (positions.Length == 0)
            {
                VertexesInternal = null;
                return;
            }

            if (_vertexesInternalCache is null)
            {
                _vertexesInternalCache = Vector2FArray.Create(positions);
            }
            else
            {
                _vertexesInternalCache.FromSpan(positions);
            }

            VertexesInternal = _vertexesInternalCache;
        }
    }
}
