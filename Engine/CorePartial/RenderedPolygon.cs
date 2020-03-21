using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    internal partial class RenderedPolygon : ISerializable, ICacheKeeper<RenderedPolygon>
    {
        #region SerializeName
        private const string S_Material = "S_Material";
        private const string S_Src = "S_Src";
        private const string S_Texture = "S_Texture";
        private const string S_Transform = "S_Transform";
        private const string S_Vertexes = "S_Vertexes";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedPolygon"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RenderedPolygon(SerializationInfo info, StreamingContext context) : base(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = cbg_RenderedPolygon_Create();
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            CacheHelper.CacheHandling(this, ptr);

            Material = info.GetValue<Material>(S_Material);
            Src = info.GetValue<RectF>(S_Src);
            Texture = info.GetValue<Texture2D>(S_Texture);
            Transform = info.GetValue<Matrix44F>(S_Transform);
            Vertexes = info.GetValue<VertexArray>(S_Vertexes);
        }

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedPolygon>> ICacheKeeper<RenderedPolygon>.CacheRepo => cacheRepo;

        internal IntPtr Self { get => selfPtr; set => selfPtr = value; }
        IntPtr ICacheKeeper<RenderedPolygon>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<RenderedPolygon>.Release(IntPtr native) => cbg_RenderedPolygon_Release(native);
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
            info.AddValue(S_Vertexes, Vertexes);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
