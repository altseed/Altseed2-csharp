using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    internal partial class RenderedText : ISerializable
    {
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_Font = "S_Font";
        private const string S_Material = "S_Material";
        private const string S_Text = "S_Text";
        private const string S_Transform = "S_Transform";
        private const string S_Weight = "S_Weight";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedText"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected RenderedText(SerializationInfo info, StreamingContext context) : base(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = cbg_RenderedText_Create();
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            selfPtr = ptr;

            if (!cacheRepo.ContainsKey(ptr)) cacheRepo.Add(ptr, new WeakReference<RenderedText>(this));
            Color = info.GetValue<Color>(S_Color);
            Font = info.GetValue<Font>(S_Font);
            Material = info.GetValue<Material>(S_Material);
            Text = info.GetString(S_Text);
            Transform = info.GetValue<Matrix44F>(S_Transform);
            Weight = info.GetSingle(S_Weight);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先のデータ</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Material, Material);
            info.AddValue(S_Text, Text);
            info.AddValue(S_Transform, Transform);
            info.AddValue(S_Weight, Weight);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
