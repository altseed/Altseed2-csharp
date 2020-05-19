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
            get => _BlurXMaterial.GetVector4F("_Intensity").X;
            set
            {
                _BlurXLumMaterial.SetVector4F("_Intensity", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("_Intensity", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("_Intensity", new Vector4F(value, value, value, value));
            }
        }

        public float Threshold
        {
            get => _BlurXMaterial.GetVector4F("_Threshold").X;
            set
            {
                _BlurXLumMaterial.SetVector4F("_Threshold", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("_Threshold", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("_Threshold", new Vector4F(value, value, value, value));
            }
        }

        public float Exposure
        {
            get => _BlurXMaterial.GetVector4F("_Exposure").X;
            set
            {

                _BlurXLumMaterial.SetVector4F("_Exposure", new Vector4F(value, value, value, value));
                _BlurXMaterial.SetVector4F("_Exposure", new Vector4F(value, value, value, value));
                _BlurYMaterial.SetVector4F("_Exposure", new Vector4F(value, value, value, value));
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

            _DownSampler.SetShader(Shader.Create("DownSample", _SimpleShaderCode, ShaderStageType.Pixel));

            var xBlurShader = Shader.Create("XBLur", "#define BLUR_X\n" + _BlurShaderCode, ShaderStageType.Pixel);
            _BlurXMaterial.SetShader(xBlurShader);

            var xLumBlurShader = Shader.Create("XLumBLur", "#define BLUR_X\n#define LUM_MODE" + _BlurShaderCode, ShaderStageType.Pixel);
            _BlurXLumMaterial.SetShader(xLumBlurShader);

            var yBlurShader = Shader.Create("YBLur", "#define BLUR_Y\n" + _BlurShaderCode, ShaderStageType.Pixel);
            _BlurYMaterial.SetShader(yBlurShader);

            var mixerShader = Shader.Create("Mixer", _MixerShaderCode, ShaderStageType.Pixel);
            _TextureMixer.SetShader(mixerShader);

            Intensity = 5;
            Threshold = 1;
            Exposure = 1;
        }

        protected override void Draw(RenderTexture src)
        {
            var downTexture = new RenderTexture[3] { GetBuffer(1, src.Size / 2), GetBuffer(2, src.Size / 4), GetBuffer(3,src.Size / 8), };
            var renderParameter = new RenderPassParameter(new Color(), false, false);

            for (int i = 0; i < 3; ++i)
            {
                _DownSampler.SetTexture("_MainTexture", i == 0 ? src : downTexture[i - 1]);
                Engine.Graphics.CommandList.RenderToRenderTexture(_DownSampler, downTexture[i], renderParameter);
            }

            for (int i = 0; i < 3; ++i)
            {
                var tmpTexture = GetBuffer(4, downTexture[i].Size);
                if (IsLuminanceMode)
                {
                    _BlurXLumMaterial.SetTexture("_BaseTexture", downTexture[i]);
                    _BlurXLumMaterial.SetVector4F("_Resolution", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                    Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXLumMaterial, tmpTexture, renderParameter);
                }
                else
                {
                    _BlurXMaterial.SetTexture("_BaseTexture", downTexture[i]);
                    _BlurXMaterial.SetVector4F("_Resolution", new Vector4F(downTexture[i].Size.X, downTexture[i].Size.Y, 0, 0));
                    Engine.Graphics.CommandList.RenderToRenderTexture(_BlurXMaterial, tmpTexture, renderParameter);
                }
                _BlurYMaterial.SetTexture("_BaseTexture", tmpTexture);
                _BlurYMaterial.SetVector4F("_Resolution", new Vector4F(tmpTexture.Size.X, tmpTexture.Size.Y, 0, 0));
                Engine.Graphics.CommandList.RenderToRenderTexture(_BlurYMaterial, downTexture[i], renderParameter);
            }

            var inBuffer = src;
            var outBuffer = GetBuffer(5, src.Size);
            for (int i = 0; i < 3; ++i)
            {
                var weight = MathF.Pow(2, -i - 1);

                _TextureMixer.SetTexture("_Texture1", inBuffer);
                _TextureMixer.SetTexture("_Texture2", downTexture[i]);
                _TextureMixer.SetVector4F("_Weight", new Vector4F(weight, weight, weight, weight));

                if (i == 2) RenderToRenderTarget(_TextureMixer);
                else
                {
                    Engine.Graphics.CommandList.RenderToRenderTexture(_TextureMixer, outBuffer, renderParameter);
                    Engine.Graphics.CommandList.CopyTexture(outBuffer, inBuffer);
                }
            }
        }



        private readonly string _SimpleShaderCode = @"

Texture2D _MainTexture : register(t0);
SamplerState _MainSampler : register(s0);

struct PS_INPUT
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 UV1 : UV0;
    float2 UV2 : UV1;
};

float4 main(PS_INPUT input) : SV_TARGET 
{
	return _MainTexture.Sample(_MainSampler, input.UV1);
}

        ";



        private readonly string _BlurShaderCode = @"

struct PS_INPUT
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 UV1 : UV0;
    float2 UV2 : UV1;
};

cbuffer Consts : register(b1)
{
    float4 _Resolution;
    float4 _Intensity;
    float4 _Threshold;
    float4 _Exposure;
};

Texture2D _BaseTexture : register(t0);
SamplerState _BaseSampler : register(s0);

static float weight[4];

float3 getLuminance(float3 color)
{
    return float3(color.x * 0.300000 + color.y * 0.590000 + color.z * 0.110000);
}

float gauss(float x, float sigma)
{
    return exp(- 0.5 * (x * x) / (sigma * sigma));
}

float3 getColor(float2 uv)
{
#ifdef BLUR_X
    float4 color = _BaseTexture.Sample(_BaseSampler, uv) * _Exposure;
    color.xyz = min(color.xyz, float4(255.0));

#ifdef LUM_MODE
    float3 lum = getLuminance(color.xyz);
    float3 bloomedLum = lum - _Threshold;
    float3 bloomedPower = min(max(bloomedLum / 2.0, 0.0), 1.0);
    return color.xyz * bloomedPower;
#else
    float3 bloomedLum = color.xyz - _Threshold.xyz;
    bloomedLum = max(bloomedLum, float3(0.0, 0.0, 0.0));
    color.xyz = bloomedLum;
    return color;
#endif

#endif

#ifdef BLUR_Y
    return _BaseTexture.Sample(_BaseSampler, uv);
#endif
}

float4 getGaussianBlur(float2 uv)
{
    float weightTotal = 0;
    for(int i = 0; i < 4; ++i)
    {
        weight[i] = gauss(i + 0.5, _Intensity.x);
        weightTotal += weight[i] * 2.0;
    }
    
    float3 outputColor = float3(0.0);

    for(int i = 0; i < 4; ++i)
    {
#ifdef BLUR_X
        float2 nShiftedUV = uv + float2(-(i + 0.5) / _Resolution.x, 0.0);
        float2 pShiftedUV = uv + float2(+(i + 0.5) / _Resolution.x, 0.0);
#endif
#ifdef BLUR_Y
        float2 nShiftedUV = uv + float2(0.0, -(i + 0.5) / _Resolution.y);
        float2 pShiftedUV = uv + float2(0.0, +(i + 0.5) / _Resolution.y);
#endif
        outputColor += getColor(nShiftedUV) * weight[i] / weightTotal;
        outputColor += getColor(pShiftedUV) * weight[i] / weightTotal;
    }

    return float4(outputColor, 1.0);
}

float4 main(PS_INPUT input) : SV_TARGET 
{
    return getGaussianBlur(input.UV1);
}

        ";



        private readonly string _MixerShaderCode = @"

struct PS_INPUT
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 UV1 : UV0;
    float2 UV2 : UV1;
};

cbuffer Consts : register(b1)
{
    float4 _Weight;
};

Texture2D _Texture1 : register(t0);
SamplerState _Sampler1 : register(s0);

Texture2D _Texture2 : register(t1);
SamplerState _Sampler2 : register(s1);

float4 main(PS_INPUT input) : SV_TARGET 
{
    float4 color1 = _Texture1.Sample(_Sampler1, input.UV1);
    float4 color2 = _Texture2.Sample(_Sampler2, input.UV1);
    return color1 + color2 * _Weight;
}

        ";
    }
}
