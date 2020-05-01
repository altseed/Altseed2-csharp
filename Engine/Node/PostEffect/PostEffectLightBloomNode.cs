using System;
using System.Runtime.CompilerServices;

namespace Altseed
{
    public sealed class PostEffectLightBloomNode : PostEffectNode
    {
        private readonly Material materialX;
        private readonly Material materialXLum;
        private readonly Material materialY;
        private readonly Material materialSum;
        private readonly Material materialDownsample;

        private float intensity;

        public float Intensity
        {
            get => intensity;
            set
            {
                intensity = value;

                Vector4F weights1;
                Vector4F weights2;

                unsafe
                {
                    float total = 0.0f;
                    float dispersion = intensity * intensity;

                    float* ws = stackalloc float[8];

                    for (int i = 0; i < 8; i++)
                    {
                        float pos = 1.0f + 2.0f * i;
                        ws[i] = (float)Math.Exp(-0.5f * pos * pos / dispersion);
                        total += ws[i] * 2.0f;
                    }

                    weights1 = new Vector4F(ws[0], ws[1], ws[2], ws[3]) / total;
                    weights2 = new Vector4F(ws[4], ws[5], ws[6], ws[7]) / total;
                }

                materialX.SetVector4F("weight1", weights1);
                materialX.SetVector4F("weight2", weights2);

                materialXLum.SetVector4F("weight1", weights1);
                materialXLum.SetVector4F("weight2", weights2);

                materialY.SetVector4F("weight1", weights1);
                materialY.SetVector4F("weight2", weights2);

                materialSum.SetVector4F("weight1", weights1);
                materialSum.SetVector4F("weight2", weights2);
            }
        }

        public float Threashold { get; set; }
        public float Exposure { get; set; }

        public bool IsLuminanceMode { get; set; }

        public PostEffectLightBloomNode()
        {
            materialX = new Material();
            materialXLum = new Material();
            materialY = new Material();
            materialSum = new Material();
            materialDownsample = new Material();

            var baseCode = Engine.Graphics.BuiltinShader.LightBloomShader;

            materialX.SetShader(Shader.Create("LightBloomX", "#define BLUR_X 1\n" + baseCode, ShaderStageType.Pixel));
            materialXLum.SetShader(Shader.Create("LightBloomXLum", "#define BLUR_X 1\n#define LUM 1\n" + baseCode, ShaderStageType.Pixel));
            materialY.SetShader(Shader.Create("LightBloomY", "#define BLUR_Y 1\n" + baseCode, ShaderStageType.Pixel));
            materialSum.SetShader(Shader.Create("LightBloomSum", "#define SUM 1\n" + baseCode, ShaderStageType.Pixel));
            materialDownsample.SetShader(Shader.Create("Downsample", Engine.Graphics.BuiltinShader.DownsampleShader, ShaderStageType.Pixel));

            Intensity = 5.0f;
            Threashold = 1.0f;
            Exposure = 1.0f;
            IsLuminanceMode = false;
        }

        protected override void Draw(RenderTexture src)
        {
            var downsampledTexture0 = GetBuffer(0, src.Size / 2);
            var downsampledTexture1 = GetBuffer(0, src.Size / 4);
            var downsampledTexture2 = GetBuffer(0, src.Size / 8);
            var downsampledTexture3 = GetBuffer(0, src.Size / 16);

            {
                var offset = new Vector4F(0.5f / src.Size.X, 0.5f / src.Size.Y, 0.0f, 0.0f);

                materialDownsample.SetTexture("mainTex", src);
                materialDownsample.SetVector4F("offset", offset);
                RenderToRenderTexture(materialDownsample, downsampledTexture0);

                materialDownsample.SetTexture("mainTex", downsampledTexture0);
                materialDownsample.SetVector4F("offset", offset * 2.0f);
                RenderToRenderTexture(materialDownsample, downsampledTexture1);

                materialDownsample.SetTexture("mainTex", downsampledTexture1);
                materialDownsample.SetVector4F("offset", offset * 4.0f);
                RenderToRenderTexture(materialDownsample, downsampledTexture2);

                materialDownsample.SetTexture("mainTex", downsampledTexture2);
                materialDownsample.SetVector4F("offset", offset * 8.0f);
                RenderToRenderTexture(materialDownsample, downsampledTexture3);
            }

            var blurX = IsLuminanceMode ? materialXLum : materialX;

            {
                var v = new Vector4F(Threashold, Exposure, 0.0f, 0.0f);
                blurX.SetVector4F("threshold_exposure", v);
                materialY.SetVector4F("threshold_exposure", v);
                materialSum.SetVector4F("threshold_exposure", v);
            }

            void ApplyBlur(RenderTexture tex)
            {
                var tmp = GetBuffer(1, tex.Size);
                blurX.SetTexture("blurredTex", tex);
                RenderToRenderTexture(blurX, tmp);

                materialY.SetTexture("blurredTex", tmp);
                RenderToRenderTexture(materialY, tex);
            }

            ApplyBlur(downsampledTexture1);
            ApplyBlur(downsampledTexture2);
            ApplyBlur(downsampledTexture3);

            materialSum.SetTexture("blurred0Tex", downsampledTexture1);
            materialSum.SetTexture("blurred1Tex", downsampledTexture2);
            materialSum.SetTexture("blurred2Tex", downsampledTexture3);
            materialSum.SetTexture("blurred3Tex", src);

            RenderToRenderTarget(materialSum);
        }
    }
}
