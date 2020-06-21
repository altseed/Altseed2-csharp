using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    internal partial class RenderedCamera
    {
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedCamera_Create();
        }
    }

    internal partial class RenderedPolygon
    {
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedPolygon_Create();
        }
    }

    internal partial class RenderedSprite
    {
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedSprite_Create();
        }
    }

    internal partial class RenderedText
    {
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedText_Create();
        }
    }
}
