using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altseed2.Test
{
    [TestFixture]
    class ComputeShader
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct InputData
        {
            public float value1;
            public float value2;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct OutputData
        {
            public float value;
        };

        [Test, Apartment(ApartmentState.STA)]
        public void Buffer()
        {
            var tc = new TestCore();
            tc.Init();

            int dataSize = 256;

            var input = Buffer<InputData>.CreateStrict(BufferUsageType.MapWrite | BufferUsageType.CopySrc, dataSize);
            Assert.NotNull(input);

            using (var data = input.LockStrict())
            {
                for (int i = 0; i < input.Count; i++)
                {
                    data.Span[i] = new InputData()
                    {
                        value1 = i * 2,
                        value2 = i * 2 + 1,
                    };
                }
            }

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ComputeShaderBasic()
        {
            var tc = new TestCore();
            tc.Init();

            string csCode1 = @"
struct CS_INPUT{
    float value1;
    float value2;
};

struct CS_OUTPUT{
    float value;
};

cbuffer CB : register(b0)
{
  float4 offset;
};

RWStructuredBuffer<CS_INPUT> read : register(u0);
RWStructuredBuffer<CS_OUTPUT> write : register(u1);

[numthreads(1, 1, 1)]
void main(uint3 dtid : SV_DispatchThreadID)
{
   write[dtid.x].value = read[dtid.x].value1 * read[dtid.x].value2 + offset.x;
}
";

            string csCode2 = @"
struct CS_INPUT{
    float value1;
    float value2;
};

struct CS_OUTPUT{
    float value;
};

cbuffer CB : register(b0)
{
  float4 offset;
};

RWStructuredBuffer<CS_INPUT> read : register(u0);
RWStructuredBuffer<CS_OUTPUT> write : register(u1);

[numthreads(1, 1, 1)]
void main(uint3 dtid : SV_DispatchThreadID)
{
   write[dtid.x].value = read[dtid.x].value1 * read[dtid.x].value2 * offset.x;
}
";

            int offset = 100;

            var pip1 = ComputePipelineState.Create();
            pip1.Shader = Shader.Create("cs1", csCode1, ShaderStage.Compute);
            pip1.SetVector4F("offset", new Vector4F(offset, 0, 0, 0));

            var pip2 = ComputePipelineState.Create();
            pip2.Shader = Shader.Create("cs2", csCode2, ShaderStage.Compute);
            pip2.SetVector4F("offset", new Vector4F(offset, 0, 0, 0));

            int dataSize = 256;

            var input = Buffer<InputData>.CreateStrict(BufferUsageType.MapWrite | BufferUsageType.CopySrc, dataSize);
            Assert.NotNull(input);

            using (var data = input.LockStrict())
            {
                for (int i = 0; i < input.Count; i++)
                {
                    data.Span[i] = new InputData()
                    {
                        value1 = i * 2,
                        value2 = i * 2 + 1,
                    };
                }
            }

            var inputBuffer = Buffer<InputData>.CreateStrict(BufferUsageType.Compute | BufferUsageType.CopyDst, dataSize);

            var write1 = Buffer<OutputData>.CreateStrict(BufferUsageType.Compute | BufferUsageType.CopySrc, dataSize);
            var write2 = Buffer<OutputData>.CreateStrict(BufferUsageType.Compute | BufferUsageType.CopySrc, dataSize);

            Assert.NotNull(inputBuffer);
            Assert.NotNull(write1);
            Assert.NotNull(write2);

            var write1Dst = Buffer<OutputData>.Create(BufferUsageType.MapRead | BufferUsageType.CopyDst, dataSize);
            var write2Dst = Buffer<OutputData>.Create(BufferUsageType.MapRead | BufferUsageType.CopyDst, dataSize);

            Assert.NotNull(write1Dst);
            Assert.NotNull(write2Dst);

            Engine.Graphics.CommandList.Begin();

            Engine.Graphics.CommandList.CopyBuffer(input, inputBuffer);

            Engine.Graphics.CommandList.BeginComputePass();

            Engine.Graphics.CommandList.SetComputeBuffer(inputBuffer, 0);
            Engine.Graphics.CommandList.SetComputeBuffer(write1, 1);
            Engine.Graphics.CommandList.ComputePipelineState = pip1;
            Engine.Graphics.CommandList.Dispatch(dataSize, 1, 1);

            Engine.Graphics.CommandList.SetComputeBuffer(inputBuffer, 0);
            Engine.Graphics.CommandList.SetComputeBuffer(write2, 1);
            Engine.Graphics.CommandList.ComputePipelineState = pip2;
            Engine.Graphics.CommandList.Dispatch(dataSize, 1, 1);

            Engine.Graphics.CommandList.EndComputePass();

            Engine.Graphics.CommandList.CopyBuffer(write1, write1Dst);
            Engine.Graphics.CommandList.CopyBuffer(write2, write2Dst);

            Engine.Graphics.CommandList.End();
            Engine.Graphics.ExecuteCommandList();
            Engine.Graphics.WaitFinish();


            using (var readValues = input.LockStrict())
            using (var write1Values = write1Dst.LockStrict())
            using (var write2Values = write2Dst.LockStrict())
            {
                for (int i = 0; i < readValues.Span.Length; i++)
                {
                    Assert.AreEqual(
                        write1Values.Span[i].value,
                        readValues.Span[i].value1 * readValues.Span[i].value2 + offset);
                    Assert.AreEqual(
                        write2Values.Span[i].value,
                        readValues.Span[i].value1 * readValues.Span[i].value2 * offset);
                }
            }

            tc.End();
        }
    }
}
