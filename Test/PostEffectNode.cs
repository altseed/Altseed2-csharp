using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class PostEffectNode
    {
        private class TestPostEffect : Altseed2.PostEffectNode {

            const string Code = @"
Texture2D mainTex : register(t0);
    SamplerState mainSamp : register(s0);
    cbuffer Consts : register(b1)
    {
        float4 time;
    };
    struct PS_INPUT
    {
        float4 Position : SV_POSITION;
    float4 Color    : COLOR0;
    float2 UV1 : UV0;
    float2 UV2 : UV1;
};
    float4 main(PS_INPUT input) : SV_TARGET 
{ 
    if (input.UV1.x > 0.5) {
        return float4(input.UV1, 1.0, 1.0);
}

float x = frac(input.UV1.x + time.x * 0.5 - floor(input.UV1.y * 10) * 0.1);

float4 tex = mainTex.Sample(mainSamp, float2(x, input.UV1.y));
    
    return float4(tex.xyz, 1.0);
}
";
            Material material = new Material();

            int count = 0;

            protected override void OnAdded()
            {
                var ps = Shader.Create("postEffectTest", Code, ShaderStageType.Pixel);

                material.SetShader(ps);
            }

            protected override void Draw(RenderTexture src)
            {
                material.SetTexture("mainTex", src);
                count = (count + 1) % 200;
                material.SetVector4F("time", new Vector4F(count / 200.0f, 0.0f, 0.0f, 0.0f));

                Engine.Graphics.CommandList.RenderToRenderTarget(material);
            }
        }


        [Test, Apartment(ApartmentState.STA)]
        public void PostEffect()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Engine.AddNode(new SpriteNode() { Texture = texture });

            var postEffect = new TestPostEffect();

            Engine.AddNode(postEffect);

            tc.LoopBody(c => {
                
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void GrayScale()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Engine.AddNode(new SpriteNode() { Texture = texture });

            Engine.AddNode(new PostEffectGrayScaleNode());

            tc.LoopBody(c => {

            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Sepia()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Engine.AddNode(new SpriteNode() { Texture = texture });

            Engine.AddNode(new PostEffectSepiaNode());

            tc.LoopBody(c => {

            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void GaussianBlur()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Engine.AddNode(new SpriteNode() { Texture = texture });

            Engine.AddNode(new PostEffectGaussianBlurNode());

            tc.LoopBody(c => {

            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void LightBloom()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Engine.AddNode(new SpriteNode() { Texture = texture });

            Engine.AddNode(new PostEffectLightBloomNode { Threshold = 0.1f});

            tc.LoopBody(c => {

            }, null);

            tc.End();
        }
    }
}
