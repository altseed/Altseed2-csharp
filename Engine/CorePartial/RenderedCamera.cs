using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    internal partial class RenderedCamera : ISerializable
    {
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedCamera"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RenderedCamera(SerializationInfo info, StreamingContext context) : base(new MemoryHandle(IntPtr.Zero))
        {
            //var ptr = cbg_RenderedCamera_Create();
            //if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            //selfPtr = ptr;

            //if (!cacheRepo.ContainsKey(ptr)) cacheRepo.Add(ptr, new WeakReference<RenderedCamera>(this));
            Transform = info.GetValue<Matrix44F>(S_Transform);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先のデータ</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Transform, Transform);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
