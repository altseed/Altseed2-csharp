using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public partial class Shader : ISerializable
    {
        #region SerializeName
        private const string S_Code = "S_Code";
        private const string S_Name = "S_Name";
        private const string S_ShaderStageType = "S_ShaderStageType";
        #endregion

        /// <summary>
        /// シリアライズされた情報から新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Shader(SerializationInfo info, StreamingContext context)
        {
            var code = info.GetString(S_Code);
            var name = info.GetString(S_Name);
            var stage = info.GetValue<ShaderStageType>(S_ShaderStageType);

            var ptr = cbg_Shader_Create(code, name, (int)stage);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンスの生成に失敗しました");
            selfPtr = ptr;

            cacheRepo.TryAdd(ptr, new WeakReference<Shader>(this));
        }

        /// <summary>
        /// シリアライズする情報を設定する
        /// </summary>
        /// <param name="info">シリアライズする情報が格納されるオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Code, Code);
            info.AddValue(S_Name, Name);
            info.AddValue(S_ShaderStageType, StageType);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
