using System;
namespace Altseed
{
    public sealed class PostEffectSepiaNode : PostEffectNode
    {
        readonly Material material;

        public PostEffectSepiaNode()
        {
            material = new Material();
            var shader = Shader.Create("Sepia", Engine.Graphics.BuiltinShader.SepiaShader, ShaderStageType.Pixel);
            material.SetShader(shader);
        }

        protected override void Draw(RenderTexture src)
        {
            material.SetTexture("mainTex", src);
            RenderToRenderTarget(material);
        }
    }
}
