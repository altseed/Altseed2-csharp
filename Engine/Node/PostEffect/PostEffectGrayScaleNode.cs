using System;

namespace Altseed2
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

        protected override void Draw(RenderTexture src, Color clearColor)
        {
            material.SetTexture("mainTex", src);
            Engine.Graphics.CommandList.RenderToRenderTarget(material);
        }
    }
}