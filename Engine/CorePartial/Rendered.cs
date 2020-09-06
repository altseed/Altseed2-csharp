using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    internal partial class RenderedCamera
    {
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue($"{S_RenderPassParameter}_Fix", RenderPassParameter);
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            RenderPassParameter = info.GetValue<RenderPassParameter>($"{S_RenderPassParameter}_Fix");
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedCamera_Create();
        }
    }

    internal partial class RenderedPolygon
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedPolygon_Create();
        }
    }

    internal partial class RenderedIBPolygon
    {
        /// <summary>
        /// インデックスバッファーを取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public IndexBufferArray Buffers
        {
            get => _buffers ??= IndexBufferArray.TryGetFromCache(cbg_RenderedIBPolygon_GetBuffers(selfPtr));
            set
            {
                _buffers = value ?? throw new ArgumentNullException(nameof(value), "引数がnullです");
                cbg_RenderedIBPolygon_SetBuffers(selfPtr, value.selfPtr);
            }
        }
        private IndexBufferArray _buffers;

        /// <summary>
        /// インデックスバッファーを<see cref="RenderedPolygon"/>と同様の方式に設定します。
        /// </summary>
        public void SetDefaultIndexBuffer()
        {
            cbg_RenderedIBPolygon_SetDefaultIndexBuffer(selfPtr);
            _buffers = null;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedIBPolygon_Create();
        }
    }

    internal partial class RenderedSprite
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedSprite_Create();
        }
    }

    internal partial class RenderedText
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderedText_Create();
        }
    }
}
