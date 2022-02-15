using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Altseed2
{
    public partial class CommandList
    {
        /// <summary>
        /// GPUへデータをアップロードする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        public void UploadBuffer<T>(Buffer<T> buffer) where T : struct
        {
            UploadBuffer(buffer.InternalBuffer);
        }

        /// <summary>
        /// GPUからデータを読み込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        public void ReadbackBuffer<T>(Buffer<T> buffer) where T : struct
        {
            ReadbackBuffer(buffer.InternalBuffer);
        }

        /// <summary>
        /// GPUのデータをコピーする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public void CopyBuffer<T>(Buffer<T> src, Buffer<T> dst) where T : struct
        {
            CopyBuffer(src.InternalBuffer, dst.InternalBuffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="indexBuffer"></param>
        /// <param name="offset"></param>
        public void SetIndexBuffer<T>(Buffer<T> indexBuffer, int offset = 0) where T : struct
        {
            int stride = Marshal.SizeOf<T>();
            SetIndexBuffer(indexBuffer.InternalBuffer, stride, offset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vertexBuffer"></param>
        /// <param name="offset"></param>
        public void SetVertexBuffer<T>(Buffer<T> vertexBuffer, int offset = 0) where T : struct
        {
            int stride = Marshal.SizeOf<T>();
            SetVertexBuffer(vertexBuffer.InternalBuffer, stride, offset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="computeBuffer"></param>
        /// <param name="unit"></param>
        /// <param name="shaderStage"></param>
        public void SetComputeBuffer<T>(Buffer<T> computeBuffer, int unit, ShaderStage shaderStage = ShaderStage.Compute) where T : struct
        {
            int stride = Marshal.SizeOf<T>();
            SetComputeBuffer(computeBuffer.InternalBuffer, stride, unit, shaderStage);
        }

        public Material Material
        {
            set
            {
                value.SetMatrix44F("matView", Engine.CurrentCamera.ViewMatrix);
                value.SetMatrix44F("matProjection", Engine.CurrentCamera.ProjectionMatrix);
                cbg_CommandList_SetMaterial(this.selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }

        public void SetMaterialWithConstantBuffer<T>(Material material, Buffer<T> constantBuffer) where T : struct
        {
            cbg_CommandList_SetMaterialWithConstantBuffer(
                this.selfPtr,
                material != null ? material.selfPtr : IntPtr.Zero,
                constantBuffer != null ? constantBuffer.InternalBuffer.selfPtr : IntPtr.Zero);
        }

        public void SetComputePipelineStateWithConstantBuffer<T>(ComputePipelineState computePipelineState, Buffer<T> constantBuffer) where T : struct
        {
            cbg_CommandList_SetComputePipelineStateWithConstantBuffer(
                this.selfPtr,
                computePipelineState != null ? computePipelineState.selfPtr : IntPtr.Zero,
                constantBuffer != null ? constantBuffer.InternalBuffer.selfPtr : IntPtr.Zero);
        }
    }
}
