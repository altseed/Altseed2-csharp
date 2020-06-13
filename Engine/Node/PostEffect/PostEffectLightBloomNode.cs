using System;

namespace Altseed
{
    public sealed class PostEffectLightBloomNode : PostEffectNode
    {
        private readonly Material _HighColorMaterial;
        private readonly Material _HighLuminanceMaterial;
        private readonly Material _DownSampler;
        private readonly Material _BlurXMaterial;
        private readonly Material _BlurYMaterial;
        private readonly Material _TextureMixer;

        public float Intensity
        {
            get => _BlurXMaterial.GetVector4F("intensity").X;
            set
            {
                _BlurXMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
            }
        }

        public float Threshold
        {
            get => _BlurXMaterial.GetVector4F("threshold").X;
            set
            {
                _HighColorMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
                _HighLuminanceMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
            }
        }

        public float Exposure
        {
            get => _BlurXMaterial.GetVector4F("exposure").X;
            set
            {
                _HighColorMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
                _HighLuminanceMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
            }
        }

        public bool IsLuminanceMode { get; set; }

        public PostEffectLightBloomNode()
        {
            _HighColorMaterial = new Material();
            _HighLuminanceMaterial = new Material();
            _DownSampler = new Material();
            _BlurXMaterial = new Material();
            _BlurYMaterial = new Material();
            _TextureMixer = new Material();

            var highLuminanceShaderCode = Engine.Graphics.BuiltinShader.HighLuminanceShader;
            _HighColorMaterial.SetShader(Shader.Create("HighLuminance", highLuminanceShaderCode, ShaderStageType.Pixel));
            _HighLuminanceMaterial.SetShader(Shader.Create("HighLuminance", "#define LUM_MODE\n" + highLuminanceShaderCode, ShaderStageType.Pixel));

            _DownSampler.SetShader(Shader.Create("DownSample", Engine.Graphics.BuiltinShader.DownsampleShader, ShaderStageType.Pixel));

            var blurShaderCode = Engine.Graphics.BuiltinShader.LightBloomShader;
            _BlurXMaterial.SetShader(Shader.Create("XBLur", "#define BLUR_X\n" + blurShaderCode, ShaderStageType.Pixel));
            _BlurYMaterial.SetShader(Shader.Create("YBLur", "#define BLUR_Y\n" + blurShaderCode, ShaderStageType.Pixel));

            _TextureMixer.SetShader(Shader.Create("Mixer", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStageType.Pixel));

            Intensity = 5;
            Threshold = 1;
            Exposure = 1;
        }

        protected override void Draw(RenderTexture src)
        {
            var downSampleCount = 6;
            var downTexture = new RenderTexture[downSampleCount];
            for (int i = 0; i < downSampleCount; ++i) downTexture[i] = GetBuffer(0, src.Size / (int)Math.Pow(2, i));

            var renderParameter = new RenderPassParameter(new Color(), true, true);

            // 高輝度抽出
            if (IsLuminanceMode)
            {
                _HighLuminanceMaterial.SetTexture("mainTex", src);
                Engine.Graphics.CommandList.RenderToRenderTexture(_HighLuminanceMaterial, downTexture[0], renderParameter);
            }
            else
            {
                _HighColorMaterial.SetTexture("mainTex", src);
                Engine.Graphics.CommandList.RenderToRenderTexture(_HighColorMaterial, downTexture[0], renderParameter);
            }

            // ダウンサンプリング
            for (int i = 1; i < downSampleCount; ++i)
            {
                _DownSampler.SetTexture("mainTex", downTexture[i - 1]);
                _DownSampler.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_DownSampler, downTexture[i], renderParameter);
            }

            // ガウスぼかし
            for (int i = downSampleCount - 3; i < downSampleCount; ++i)
            {
                var tmpTexture = GetBuffer(1, downTexture[i].Size);

                _BlurXMaterial.SetTexture("mainTex", downTexture[i]);
                _BlurXMaterial.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXMaterial, tmpTexture, renderParameter);
                
                _BlurYMaterial.SetTexture("mainTex", tmpTexture);
                _BlurYMaterial.SetVector4F("imageSize", new Vector4F(tmpTexture.Size.X, tmpTexture.Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurYMaterial, downTexture[i], renderParameter);
            }

            // テクスチャ合成
            var inBuffer = src;
            var outBuffer = GetBuffer(1, src.Size);
            var weight = 1.0f;
            for (int i = downSampleCount - 3; i < downSampleCount; ++i)
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
