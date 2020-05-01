using System;

namespace Altseed
{
    public sealed class PostEffectGrayScaleNode : PostEffectNode
    {
        readonly Material material;

        public PostEffectGrayScaleNode()
        {
            material = new Material();
            var shader = Shader.Create("GrayScale", Engine.Graphics.BuiltinShader.GrayScaleShader, ShaderStageType.Pixel);
            material.SetShader(shader);
        }

        protected override void Draw(RenderTexture src)
        {
            material.SetTexture("mainTex", src);
            RenderToRenderTarget(material);
        }
    }
}