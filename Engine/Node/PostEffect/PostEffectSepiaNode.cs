namespace Altseed2
{
    /// <summary>
    /// セピア補正のポストエフェクトのクラス
    /// </summary>
    public sealed class PostEffectSepiaNode : PostEffectNode
    {
        readonly Material material;

        /// <summary>
        /// <see cref="PostEffectSepiaNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public PostEffectSepiaNode()
        {
            material = Material.Create();
            var shader = Shader.Create("Sepia", Engine.Graphics.BuiltinShader.SepiaShader, ShaderStage.Pixel);
            material.SetShader(shader);
        }

        /// <inheritdoc/>
        protected override void Draw(RenderTexture src, Color clearColor)
        {
            material.SetTexture("mainTex", src);
            Engine.Graphics.CommandList.RenderToRenderTarget(material);
        }
    }
}
