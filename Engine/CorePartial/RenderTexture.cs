using System;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class RenderTexture
    {
        #region SerializeName
        private const string S_Size = "S_Size";
        #endregion
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info) => ptr = cbg_RenderTexture_Create(info.GetValue<Vector2I>(S_Size));
    }
}
