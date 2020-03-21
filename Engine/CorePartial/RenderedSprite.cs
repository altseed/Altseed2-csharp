using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    internal partial class RenderedSprite : ISerializable, ICacheKeeper<RenderedSprite>
    {
        #region SerializeName
        private const string S_Material = "S_Material";
        private const string S_Src = "S_Src";
        private const string S_Texture = "S_Texture";
        private const string S_Transform = "S_Transform";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedSprite"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RenderedSprite(SerializationInfo info, StreamingContext context) : base(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = cbg_RenderedSprite_Create();
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            CacheHelper.CacheHandling(this, ptr);

            Material = info.GetValue<Material>(S_Material);
            Src = info.GetValue<RectF>(S_Src);
            Texture = info.GetValue<Texture2D>(S_Texture);
            Transform = info.GetValue<Matrix44F>(S_Transform);
        }

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedSprite>> ICacheKeeper<RenderedSprite>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<RenderedSprite>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<RenderedSprite>.Release(IntPtr native) => cbg_RenderedSprite_Release(native);
        #endregion

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先のデータ</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Material, Material);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Transform, Transform);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
