using System;
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
        /// <summary>
        /// 頂点情報の配列を取得または設定します。
        /// </summary>
        public Vector2F[] VertexArray
        {
            get => Vertexes?.ToArray();
            set
            {
                if (value is null)
                {
                    Vertexes = null;
                    return;
                }

                var array = Vector2FArray.Create(value.Length);
                array.FromArray(value);
                Vertexes = array;
            }
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_PolygonCollider_Create();
        }
    }
}
