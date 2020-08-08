using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    public partial class Shader
    {
        public static Shader Create(string name, string code, ShaderStage shaderStage)
            => Compile(name, code, shaderStage).Value;

        public static Shader CreateFromFile(string name, string path, ShaderStage shaderStage)
            => CompileFromFile(name, path, shaderStage).Value;

        public static string TryCreate(string name, string code, ShaderStage shaderStage, out Shader shader)
        {
            var result = Compile(name, code, shaderStage);
            shader = result.Value;
            return result.Message;
        }

        public static string TryCreateFromFile(string name, string code, ShaderStage shaderStage, out Shader shader)
        {
            var result = CompileFromFile(name, code, shaderStage);
            shader = result.Value;
            return result.Message;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            Shader_Unsetter_Deserialize(info, out var stage, out var code, out var name);
            var result = new ShaderCompileResult(new MemoryHandle(cbg_Shader_Compile(name, code, (int)stage)));
            if (result.Value == null) throw new SerializationException($"シェーダのデシリアライズ時のコンパイルに失敗しました\n{nameof(result.Message)}: {result.Message}");
            ptr = result.Value.selfPtr;
        }
    }
}
