using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    public partial class Shader
    {
        /// <summary>
        /// コードをコンパイルして<see cref="Shader"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">シェーダにつける名前</param>
        /// <param name="code">シェーダのコード</param>
        /// <param name="shaderStage">シェーダの種類</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>または<paramref name="code"/>がnull</exception>
        /// <returns><paramref name="code"/>をコンパイルしてできる<see cref="Shader"/>の新しいインスタンス コンパイルに失敗した場合はnull</returns>
        public static Shader Create(string name, string code, ShaderStage shaderStage)
            => Compile(name, code, shaderStage).Value;

        /// <summary>
        /// ファイルに書かれたコードをコンパイルして<see cref="Shader"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">シェーダにつける名前</param>
        /// <param name="path">シェーダのコードが書かれたファイルのパス</param>
        /// <param name="shaderStage">シェーダの種類</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>または<paramref name="path"/>がnull</exception>
        /// <returns><paramref name="path"/>に書かれたコードをコンパイルしてできる<see cref="Shader"/>の新しいインスタンス コンパイルに失敗した場合はnull</returns>
        public static Shader CreateFromFile(string name, string path, ShaderStage shaderStage)
            => CompileFromFile(name, path, shaderStage).Value;

        /// <summary>
        /// コードをコンパイルして<see cref="Shader"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">シェーダにつける名前</param>
        /// <param name="code">シェーダのコード</param>
        /// <param name="shaderStage">シェーダの種類</param>
        /// <param name="shader"><paramref name="code"/>をコンパイルしてできる<see cref="Shader"/>の新しいインスタンス コンパイルに失敗した場合はnull</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>または<paramref name="code"/>がnull</exception>
        /// <returns><paramref name="code"/>をコンパイルした際のメッセージ</returns>
        public static string TryCreate(string name, string code, ShaderStage shaderStage, out Shader shader)
        {
            var result = Compile(name, code, shaderStage);
            shader = result.Value;
            return result.Message;
        }

        /// <summary>
        /// ファイルに書かれたコードをコンパイルして<see cref="Shader"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">シェーダにつける名前</param>
        /// <param name="path">シェーダのコードが書かれたファイルのパス</param>
        /// <param name="shaderStage">シェーダの種類</param>
        /// <param name="shader"></param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>に書かれたコードをコンパイルしてできる<see cref="Shader"/>の新しいインスタンス コンパイルに失敗した場合はnull<paramref name="name"/>または<paramref name="path"/>がnull</exception>
        /// <returns><paramref name="path"/>に書かれたコードをコンパイルした際のメッセージ</returns>
        public static string TryCreateFromFile(string name, string path, ShaderStage shaderStage, out Shader shader)
        {
            var result = CompileFromFile(name, path, shaderStage);
            shader = result.Value;
            return result.Message;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            Shader_Unsetter_Deserialize(info, out var stage, out var code, out var name);
            var result = new ShaderCompileResult(new MemoryHandle(cbg_Shader_Compile(name, code, (int)stage)));
            if (result.Value == null) throw new SerializationException($"シェーダのデシリアライズ時のコンパイルに失敗しました\n{nameof(result.Message)}: {result.Message}");
            ptr = result.GetValueWithoutReleasing().selfPtr;
        }
    }

    internal partial class ShaderCompileResult
    {
        /// <summary>
        /// <see cref="Shader.cbg_Shader_Release(IntPtr)"/>を行わず<see cref="Value"/>を取得する
        /// </summary>
        /// <returns><see cref="Value"/></returns>
        /// <remarks><see cref="Shader"/>デシリアライズ時に仕様</remarks>
        internal Shader GetValueWithoutReleasing()
        {
            var ptr = cbg_ShaderCompileResult_GetValue(selfPtr);
            var CacheRepo = ((ICacheKeeper<Shader>)new Shader(default)).CacheRepo;
            if (CacheRepo.TryGetValue(ptr, out var weakRef) && weakRef.TryGetTarget(out var result)) return result;
            result = new Shader(new MemoryHandle(ptr));
            CacheRepo[ptr] = new WeakReference<Shader>(result);
            return result;
        }
    }
}
