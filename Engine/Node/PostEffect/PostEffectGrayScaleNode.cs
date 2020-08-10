namespace Altseed2
{
    /// <summary>
    /// 白黒化を実装するポストエフェクトのクラス
    /// </summary>
    public sealed class PostEffectGrayScaleNode : PostEffectNode
    {
        readonly Material material;

        /// <summary>
        /// <see cref="PostEffectGrayScaleNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public PostEffectGrayScaleNode()
        {
            material = Material.Create();
            var shader = Shader.Create("GrayScale", Engine.Graphics.BuiltinShader.GrayScaleShader, ShaderStage.Pixel);
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