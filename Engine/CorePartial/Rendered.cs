using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    internal partial class RenderedCamera
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedCamera_Create();
        }
    }

    internal partial class RenderedPolygon
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedPolygon_Create();
        }
    }

    internal partial class RenderedSprite
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedSprite_Create();
        }
    }

    internal partial class RenderedText
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedText_Create();
        }
    }
}
