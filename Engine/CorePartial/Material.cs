using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class Material
    {
        #region SerializeName
        private const string S_Matrixes = "S_Matrixes";
        private const string S_Shaders = "S_Shaders";
        private const string S_Textures = "S_Textures";
        private const string S_Vectors = "S_Vectors";
        #endregion

        private Dictionary<string, Matrix44F> matrixes = new Dictionary<string, Matrix44F>();
        private Dictionary<ShaderStageType, Shader> shaders = new Dictionary<ShaderStageType, Shader>();
        private Dictionary<string, TextureBase> textures = new Dictionary<string, TextureBase>();
        private Dictionary<string, Vector4F> vectors = new Dictionary<string, Vector4F>();

        /// <summary>
        /// 指定した名前を持つ<see cref="Matrix44F"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="Matrix44F"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="Matrix44F"/>のインスタンス</returns>
        public Matrix44F GetMatrix44F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (!matrixes.TryGetValue(key, out var result)) result = cbg_Material_GetMatrix44F(selfPtr, key);
            return result;
        }

        /// <summary>
        /// 指定した種類のシェーダを取得する
        /// </summary>
        /// <param name="shaderStage">検索するシェーダのタイプ</param>
        /// <returns><paramref name="shaderStage"/>に一致するタイプのシェーダ</returns>
        public Shader GetShader(ShaderStageType shaderStage)
        {
            if (!shaders.TryGetValue(shaderStage, out var result))
            {
                var ret = cbg_Material_GetShader(selfPtr, (int)shaderStage);
                result = Shader.TryGetFromCache(ret);
            }
            return result;
        }

        /// <summary>
        /// 指定した名前を持つ<see cref="TextureBase"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="TextureBase"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="TextureBase"/>のインスタンス</returns>
        public TextureBase GetTexture(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (!textures.TryGetValue(key, out var result))
            {
                var ret = cbg_Material_GetTexture(selfPtr, key);
                result = TextureBase.TryGetFromCache(ret);
            }
            return result;
        }

        /// <summary>
        /// 指定した名前を持つ<see cref="Vector4F"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="Vector4F"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="Vector4F"/>のインスタンス</returns>
        public Vector4F GetVector4F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (!vectors.TryGetValue(key, out var result)) result = cbg_Material_GetVector4F(selfPtr, key);
            return result;
        }

        /// <summary>
        /// 指定した名前を持つ<see cref="Matrix44F"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="Matrix44F"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="Matrix44F"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetMatrix44F(string key, Matrix44F value)
        {
            SetMatrix44FPrivate(key, value, true);
        }

        private void SetMatrix44FPrivate(string key, Matrix44F value, bool assign)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (assign) matrixes[key] = value;
            cbg_Material_SetMatrix44F(selfPtr, key, value);
        }

        /// <summary>
        /// シェーダを設定する
        /// </summary>
        /// <param name="shader">設定するシェーダ</param>
        /// <exception cref="ArgumentNullException"><paramref name="shader"/>がnull</exception>
        public void SetShader(Shader shader)
        {
            SetShaderPrivate(shader, true);
        }

        private void SetShaderPrivate(Shader shader, bool assign)
        {
            if (shader == null) throw new ArgumentNullException(nameof(shader), "引数がnullです");
            if (assign) shaders[shader.StageType] = shader;
            cbg_Material_SetShader(selfPtr, shader != null ? shader.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// 指定した名前を持つ<see cref="TextureBase"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="TextureBase"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="TextureBase"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetTexture(string key, TextureBase value)
        {
            SetTexturePrivate(key, value, true);
        }

        private void SetTexturePrivate(string key, TextureBase value, bool assign)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (assign) textures[key] = value;
            cbg_Material_SetTexture(selfPtr, key, value != null ? value.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// 指定した名前を持つ<see cref="Vector4F"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="Vector4F"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="Vector4F"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetVector4F(string key, Vector4F value)
        {
            SetVector4FPrivate(key, value, true);
        }

        private void SetVector4FPrivate(string key, Vector4F value, bool assign)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            if (assign) vectors[key] = value;
            cbg_Material_SetVector4F(selfPtr, key, value);
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            matrixes = info.GetValue<Dictionary<string, Matrix44F>>(S_Matrixes);
            shaders = info.GetValue<Dictionary<ShaderStageType, Shader>>(S_Shaders);
            textures = info.GetValue<Dictionary<string, TextureBase>>(S_Textures);
            vectors = info.GetValue<Dictionary<string, Vector4F>>(S_Vectors);

            foreach (var current in matrixes) SetMatrix44FPrivate(current.Key, current.Value, false);
            foreach (var current in shaders) SetShaderPrivate(current.Value, false);
            foreach (var current in textures) SetTexturePrivate(current.Key, current.Value, false);
            foreach (var current in vectors) SetVector4FPrivate(current.Key, current.Value, false);
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_Material_Constructor_0();
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Matrixes, matrixes);
            info.AddValue(S_Shaders, shaders);
            info.AddValue(S_Textures, textures);
            info.AddValue(S_Vectors, vectors);
        }
    }
}
