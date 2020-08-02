using System;

namespace Altseed2
{
    public sealed class PostEffectLightBloomNode : PostEffectNode
    {
        private readonly Material _HighColorMaterial;
        private readonly Material _HighLuminanceMaterial;
        private readonly Material _DownSampler;
        private readonly Material _BlurXMaterial;
        private readonly Material _BlurYMaterial;
        private readonly Material _TextureMixer;

        /// <summary>
        /// ぼけの強さ。値が大きいほど光がぼけます。
        /// </summary>
        public float Intensity
        {
            get => _BlurXMaterial.GetVector4F("intensity").X;
            set
            {
                _BlurXMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("intensity", new Vector4F(value, value, value, value));
            }
        }

        /// <summary>
        /// この値を超えた画素がぼかされます。255を1.0とした数値を指定します。
        /// </summary>
        public float Threshold
        {
            get => _BlurXMaterial.GetVector4F("threshold").X;
            set
            {
                _HighColorMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
                _HighLuminanceMaterial.SetVector4F("threshold", new Vector4F(value, value, value, value));
            }
        }

        /// <summary>
        /// 露光の強さ。この値が大きいほど、ぼけた光が強くなります。
        /// </summary>
        public float Exposure
        {
            get => _BlurXMaterial.GetVector4F("exposure").X;
            set
            {
                _HighColorMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
                _HighLuminanceMaterial.SetVector4F("exposure", new Vector4F(value, value, value, value));
            }
        }

        /// <summary>
        /// RGBではなく、輝度を参照してぼかす色を決定します。
        /// </summary>
        public bool IsLuminanceMode { get; set; }

        public PostEffectLightBloomNode()
        {
            _HighColorMaterial = Material.Create();
            _HighLuminanceMaterial = Material.Create();
            _DownSampler = Material.Create();
            _BlurXMaterial = Material.Create();
            _BlurYMaterial = Material.Create();
            _TextureMixer = Material.Create();

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

        private const int DownSampleCount = 6;
        private readonly RenderTexture[] downTexture = new RenderTexture[DownSampleCount];

        protected override void Draw(RenderTexture src, Color clearColor)
        {
            src.WrapMode = TextureWrapMode.Clamp;

            for (int i = 0; i < DownSampleCount; ++i)
            {
                downTexture[i] = GetBuffer(0, src.Size / (int)Math.Pow(2, i), src.Format);
                downTexture[i].WrapMode = TextureWrapMode.Clamp;
                downTexture[i].FilterType = TextureFilterType.Linear;
            }

            var renderParameter = new RenderPassParameter(clearColor, true, true);

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
            for (int i = 1; i < DownSampleCount; ++i)
            {
                _DownSampler.SetTexture("mainTex", downTexture[i - 1]);
                _DownSampler.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_DownSampler, downTexture[i], renderParameter);
            }

            // ガウスぼかし
            for (int i = DownSampleCount - 3; i < DownSampleCount; ++i)
            {
                var tmpTexture = GetBuffer(1, downTexture[i].Size, src.Format);
                tmpTexture.WrapMode = TextureWrapMode.Clamp;
                tmpTexture.FilterType = TextureFilterType.Linear;

                _BlurXMaterial.SetTexture("mainTex", downTexture[i]);
                _BlurXMaterial.SetVector4F("imageSize", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXMaterial, tmpTexture, renderParameter);
                
                _BlurYMaterial.SetTexture("mainTex", tmpTexture);
                _BlurYMaterial.SetVector4F("imageSize", new Vector4F(tmpTexture.Size.X, tmpTexture.Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurYMaterial, downTexture[i], renderParameter);
            }

            // テクスチャ合成
            var inBuffer = src;
            var outBuffer = GetBuffer(1, src.Size, src.Format);
            var weight = 1.0f;
            for (int i = DownSampleCount - 3; i < DownSampleCount; ++i)
            {
                _TextureMixer.SetTexture("mainTex1", inBuffer);
                _TextureMixer.SetTexture("mainTex2", downTexture[i]);
                _TextureMixer.SetVector4F("weight", new Vector4F(weight, weight, weight, weight));

                if (i == DownSampleCount - 1)
                {
                    Engine.Graphics.CommandList.RenderToRenderTarget(_TextureMixer);
                }
                else
                {
                    Engine.Graphics.CommandList.RenderToRenderTexture(_TextureMixer, outBuffer, renderParameter);
                    Engine.Graphics.CommandList.CopyTexture(outBuffer, inBuffer);
                }

                weight *= 0.5f;
            }

            Array.Clear(downTexture, 0, downTexture.Length);
        }
    }
}
