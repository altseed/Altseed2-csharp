using System;
using System.Runtime.Serialization;

namespace Altseed.CorePartial
{
    [Serializable]
    public partial class Shader : ISerializable
    {
        #region SerializeName
        #endregion

        /// <summary>
        /// シリアライズされた情報から新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Shader(SerializationInfo info, StreamingContext context)
        {

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

        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
