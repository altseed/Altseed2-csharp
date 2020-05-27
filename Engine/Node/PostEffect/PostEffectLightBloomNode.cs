using System;

namespace Altseed
{
    public sealed class PostEffectLightBloomNode : PostEffectNode
    {
        private readonly Material _DownSampler;
        private readonly Material _BlurXMaterial;
        private readonly Material _BlurXLumMaterial;
        private readonly Material _BlurYMaterial;
        private readonly Material _TextureMixer;

        public float Intensity
        {
            get => _BlurXMaterial.GetVector4F("intensity").X;
            set
            {
                _BlurXLumMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
            }
        }

        public float Threshold
        {
            get => _BlurXMaterial.GetVector4F("threshold").X;
            set
            {
                _BlurXLumMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
            }
        }

        public float Exposure
        {
            get => _BlurXMaterial.GetVector4F("exposure").X;
            set
            {
                _BlurXLumMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
            }
        }

        public bool IsLuminanceMode { get; set; }

        public PostEffectLightBloomNode()
        {
            _DownSampler = new Material();
            _BlurXMaterial = new Material();
            _BlurXLumMaterial = new Material();
            _BlurYMaterial = new Material();
            _TextureMixer = new Material();

            _DownSampler.SetShader(Shader.Create("DownSample", Engine.Graphics.BuiltinShader.DownsampleShader, ShaderStageType.Pixel));

            var blurShaderCode = Engine.Graphics.BuiltinShader.LightBloomShader;

            var xBlurShader = Shader.Create("XBLur", "#define BLUR_X\n" + blurShaderCode, ShaderStageType.Pixel);
            _BlurXMaterial.SetShader(xBlurShader);

            var xLumBlurShader = Shader.Create("XLumBLur", "#define BLUR_X\n#define LUM_MODE" + blurShaderCode, ShaderStageType.Pixel);
            _BlurXLumMaterial.SetShader(xLumBlurShader);

            var yBlurShader = Shader.Create("YBLur", "#define BLUR_Y\n" + blurShaderCode, ShaderStageType.Pixel);
            _BlurYMaterial.SetShader(yBlurShader);

            var mixerShader = Shader.Create("Mixer", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStageType.Pixel);
            _TextureMixer.SetShader(mixerShader);

            Intensity = 5;
            Threshold = 1;
            Exposure = 1;
        }

        protected override void Draw(RenderTexture src)
        {
            var downSampleCount = 3; // ここ任意の値に設定できるようにしたい
            var downSampleScale = 16; // ここ任意の値に設定できるようにしたい
            var downTexture = new RenderTexture[downSampleCount];
            for(int i = 0; i < downSampleCount; ++i)
            {
                downTexture[i] = GetBuffer(0, src.Size / downSampleScale);
                downSampleScale *= 2;
            }

            var renderParameter = new RenderPassParameter(new Color(), false, false);

            for (int i = 0; i < downSampleCount; ++i)
            {
                _DownSampler.SetTexture("mainTex", i == 0 ? src : downTexture[i - 1]);
                _DownSampler.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_DownSampler, downTexture[i], renderParameter);
            }

            for (int i = 0; i < downSampleCount; ++i)
            {
                var tmpTexture = GetBuffer(1, downTexture[i].Size);
                if (IsLuminanceMode)
                {
                    _BlurXLumMaterial.SetTexture("mainTex", downTexture[i]);
                    _BlurXLumMaterial.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                    Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXLumMaterial, tmpTexture, renderParameter);
                }
                else
                {
                    _BlurXMaterial.SetTexture("mainTex", downTexture[i]);
                    _BlurXMaterial.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                    Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXMaterial, tmpTexture, renderParameter);
                }
                _BlurYMaterial.SetTexture("mainTex", tmpTexture);
                _BlurYMaterial.SetVector4F("imageSize", new Vector4F(tmpTexture.Size.X, tmpTexture.Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurYMaterial, downTexture[i], renderParameter);
            }

            var inBuffer = src;
            var outBuffer = GetBuffer(1, src.Size);
            var weight = 0.25f; // ここ任意の値に設定できるようにしたい
            for (int i = 0; i < downSampleCount; ++i)
            {
                _TextureMixer.SetTexture("mainTex1", inBuffer);
                _TextureMixer.SetTexture("mainTex2", downTexture[i]);
                _TextureMixer.SetVector4F("weight", new Vector4F(weight, weight, weight, weight));

                if (i == downSampleCount - 1) RenderToRenderTarget(_TextureMixer);
                else
                {
                    Engine.Graphics.CommandList.RenderToRenderTexture(_TextureMixer, outBuffer, renderParameter);
                    Engine.Graphics.CommandList.CopyTexture(outBuffer, inBuffer);
                }

                weight *= 0.5f;
            }
        }
    }
}
