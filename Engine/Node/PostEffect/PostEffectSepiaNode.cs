using System;

namespace Altseed2
{
    public sealed class PostEffectSepiaNode : PostEffectNode
    {
        readonly Material material;

        public PostEffectSepiaNode()
        {
            material = Material.Create();
            var shader = Shader.Create("Sepia", Engine.Graphics.BuiltinShader.SepiaShader, ShaderStageType.Pixel);
            material.SetShader(shader);
        }

        protected override void Draw(RenderTexture src, Color clearColor)
        {
            material.SetTexture("mainTex", src);
            Engine.Graphics.CommandList.RenderToRenderTarget(material);
        }
    }
}
