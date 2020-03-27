using System;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class Shader
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            var code = info.GetString(S_Code);
            var name = info.GetString(S_Name);
            var stage = info.GetValue<ShaderStageType>(S_StageType);

            ptr = cbg_Shader_Create(code, name, (int)stage);
        }
    }
}
