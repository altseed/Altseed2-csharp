using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    public partial class Shader
    {
        public static Shader Create(string name, string code, ShaderStage shaderStage)
            => Compile(name, code, shaderStage).Value;

        public static Shader CreateFromFile(string name, string path, ShaderStage shaderStage)
            => Compile(name, path, shaderStage).Value;

        public static string TryCreate(string name, string code, ShaderStage shaderStage, out Shader shader)
        {
            var result = Compile(name, code, shaderStage);
            shader = result.Value;
            return result.Message;
        }

        public static string TryCreateFromFile(string name, string code, ShaderStage shaderStage, out Shader shader)
        {
            var result = Compile(name, code, shaderStage);
            shader = result.Value;
            return result.Message;
        }
    }
}
