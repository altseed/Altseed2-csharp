using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    internal partial class RenderedCamera : ISerializable, ICacheKeeper<RenderedCamera>
    {
        #region SerializeName
        private const string S_CenterOffSet = "S_CenterOffSet";
        private const string S_TargetTexture = "S_TargetTexture";
        private const string S_Transform = "S_Transform";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedCamera"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RenderedCamera(SerializationInfo info, StreamingContext context) : base(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = cbg_RenderedCamera_Create();
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            CacheHelper.CacheHandling(this, ptr);

            Transform = info.GetValue<Matrix44F>(S_Transform);
            CenterOffset = info.GetValue<Vector2F>(S_CenterOffSet);
            TargetTexture = info.GetValue<RenderTexture>(S_TargetTexture);
        }

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedCamera>> ICacheKeeper<RenderedCamera>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<RenderedCamera>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<RenderedCamera>.Release(IntPtr native) => cbg_RenderedCamera_Release(native);
        #endregion

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先のデータ</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_CenterOffSet, CenterOffset);
            info.AddValue(S_TargetTexture, TargetTexture);
            info.AddValue(S_Transform, Transform);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
