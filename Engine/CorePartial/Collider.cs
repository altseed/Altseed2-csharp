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
            get => cbg_Collider_GetPosition(selfPtr);
            set => cbg_Collider_SetPosition(selfPtr, value);
        }

        /// <summary>
        /// 回転(弧度法)を取得または設定します。
        /// </summary>
        public float Rotation
        {
            get => cbg_Collider_GetRotation(selfPtr);
            set => cbg_Collider_SetRotation(selfPtr, value);
        }
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
