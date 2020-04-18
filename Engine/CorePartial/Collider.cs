using System;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class Collider
    {
        /// <summary>
        /// このインスタンスを管理する<see cref="ColliderNode"/>を取得する
        /// </summary>
        public ColliderNode Owner { get; internal set; }
    }
    public partial class CircleCollider
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info) => ptr = cbg_CircleCollider_Constructor_0();
    }
    public partial class RectangleCollider
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info) => ptr = cbg_RectangleCollider_Constructor_0();
    }
    public partial class PolygonCollider
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info) => ptr = cbg_PolygonCollider_Constructor_0();
    }
}
