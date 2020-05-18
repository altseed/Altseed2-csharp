using System;

namespace Altseed
{
    public sealed class PostEffectLightBloomNode : PostEffectNode
    {
        private readonly Material[] _DownSampler;
        private readonly Material[] _BlurXMaterial;
        private readonly Material[] _BlurXLumMaterial;
        private readonly Material[] _BlurYMaterial;
        private readonly Material[] _TextureMixer;

        private readonly RenderTexture _InputTexture;
        private readonly RenderTexture[] _DownTexture;
        private readonly RenderTexture[] _BlurXTexture;
        private readonly RenderTexture[] _BlurYTexture;
        private readonly RenderTexture _FinalTexture;

        public float Intensity
        {
            get => _BlurXMaterial[0].GetVector4F("_Intensity").X;
            set
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (IsLuminanceMode) _BlurXLumMaterial[i].SetVector4F("_Intensity", new Vector4F(value, value, value, value));
                    else _BlurXMaterial[i].SetVector4F("_Intensity", new Vector4F(value, value, value, value));
                    _BlurYMaterial[i].SetVector4F("_Intensity", new Vector4F(value, value, value, value));
                }
            }
        }

        public float Threshold
        {
            get => _BlurXMaterial[0].GetVector4F("_Threshold").X;
            set
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (IsLuminanceMode) _BlurXLumMaterial[i].SetVector4F("_Threshold", new Vector4F(value, value, value, value));
                    else _BlurXMaterial[i].SetVector4F("_Threshold", new Vector4F(value, value, value, value));
                    _BlurYMaterial[i].SetVector4F("_Threshold", new Vector4F(value, value, value, value));
                }
            }
        }

        public float Exposure
        {
            get => _BlurXMaterial[0].GetVector4F("_Exposure").X;
            set
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (IsLuminanceMode) _BlurXLumMaterial[i].SetVector4F("_Exposure", new Vector4F(value, value, value, value));
                    else _BlurXMaterial[i].SetVector4F("_Exposure", new Vector4F(value, value, value, value));
                    _BlurYMaterial[i].SetVector4F("_Exposure", new Vector4F(value, value, value, value));
                }
            }
        }

        public bool IsLuminanceMode
        {
            get;
            set;
        }

        public PostEffectLightBloomNode()
        {
            _DownSampler = new Material[3] { new Material(), new Material(), new Material() };
            _BlurXMaterial = new Material[3] { new Material(), new Material(), new Material() };
            _BlurXLumMaterial = new Material[3] { new Material(), new Material(), new Material() };
            _BlurYMaterial = new Material[3] { new Material(), new Material(), new Material() };
            _TextureMixer = new Material[3] { new Material(), new Material(), new Material() };

            _InputTexture = RenderTexture.Create(Engine.WindowSize * 2);
            _DownTexture = new RenderTexture[3]
            {
                    RenderTexture.Create(Engine.WindowSize / 1),
                    RenderTexture.Create(Engine.WindowSize / 2),
                    RenderTexture.Create(Engine.WindowSize / 4),
            };
            _BlurXTexture = new RenderTexture[3]
            {
                    RenderTexture.Create(Engine.WindowSize / 1),
                    RenderTexture.Create(Engine.WindowSize / 2),
                    RenderTexture.Create(Engine.WindowSize / 4),
            };
            _BlurYTexture = new RenderTexture[3]
            {
                    RenderTexture.Create(Engine.WindowSize / 1),
                    RenderTexture.Create(Engine.WindowSize / 2),
                    RenderTexture.Create(Engine.WindowSize / 4),
            };
            _FinalTexture = RenderTexture.Create(Engine.WindowSize * 2);

            for (int i = 0; i < 3; ++i)
            {
                _DownSampler[i].SetTexture("_MainTexture", _InputTexture);
                _DownSampler[i].SetShader(Shader.Create("DownSample", _SimpleShaderCode, ShaderStageType.Pixel));
            }

            var xBlurShader = Shader.Create("XBLur", "#define BLUR_X\n" + _BlurShaderCode, ShaderStageType.Pixel);
            for (int i = 0; i < 3; ++i)
            {
                _BlurXMaterial[i].SetShader(xBlurShader);
                _BlurXMaterial[i].SetTexture("_BaseTexture", _DownTexture[i]);
                _BlurXMaterial[i].SetVector4F("_Resolution", new Vector4F(_DownTexture[i].Size.X, _DownTexture[i].Size.Y, 0, 0));
            }

            var xLumBlurShader = Shader.Create("XBLur", "#define BLUR_X\n#define LUM_MODE" + _BlurShaderCode, ShaderStageType.Pixel);
            for (int i = 0; i < 3; ++i)
            {
                _BlurXLumMaterial[i].SetShader(xLumBlurShader);
                _BlurXLumMaterial[i].SetTexture("_BaseTexture", _DownTexture[i]);
                _BlurXLumMaterial[i].SetVector4F("_Resolution", new Vector4F(_DownTexture[i].Size.X, _DownTexture[i].Size.Y, 0, 0));
            }

            var yBlurShader = Shader.Create("YBLur", "#define BLUR_Y\n" + _BlurShaderCode, ShaderStageType.Pixel);
            for (int i = 0; i < 3; ++i)
            {
                _BlurYMaterial[i].SetShader(yBlurShader);
                _BlurYMaterial[i].SetTexture("_BaseTexture", _BlurXTexture[i]);
                _BlurYMaterial[i].SetVector4F("_Resolution", new Vector4F(_BlurXTexture[i].Size.X, _BlurXTexture[i].Size.Y, 0, 0));
            }

            var mixerShader = Shader.Create("Mixer", _MixerShaderCode, ShaderStageType.Pixel);
            for (int i = 0; i < 3; ++i)
            {
                var weight = MathF.Pow(2, -i - 1);
                _TextureMixer[i].SetShader(mixerShader);
                _TextureMixer[i].SetTexture("_Texture1", _FinalTexture);
                _TextureMixer[i].SetTexture("_Texture2", _BlurYTexture[i]);
                _TextureMixer[i].SetVector4F("_Weight", new Vector4F(weight, weight, weight, weight));
            }

            Intensity = 5;
            Threshold = 0.5f;
            Exposure = 3;
        }

        protected override void Draw(RenderTexture src)
        {
            Engine.Graphics.CommandList.CopyTexture(src, _InputTexture);

            for (int i = 0; i < 3; ++i) RenderToRenderTexture(_DownSampler[i], _DownTexture[i]);

            for (int i = 0; i < 3; ++i)
            {
                RenderToRenderTexture(IsLuminanceMode ? _BlurXLumMaterial[i] : _BlurXMaterial[i], _BlurXTexture[i]);
                RenderToRenderTexture(_BlurYMaterial[i], _BlurYTexture[i]);
            }

            Engine.Graphics.CommandList.CopyTexture(_InputTexture, _FinalTexture);

            for (int i = 0; i < 3; ++i)
            {
                if (i == 2) RenderToRenderTarget(_TextureMixer[i]);
                else Engine.Graphics.CommandList.RenderToRenderTexture(_TextureMixer[i], _FinalTexture, new RenderPassParameter(new Color(), false, false));
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

static float weight[8];

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
    for(int i = 0; i < 8; ++i)
    {
        weight[i] = gauss(i + 0.5, _Intensity.x);
        weightTotal += weight[i] * 2.0;
    }
    
    float3 outputColor = float3(0.0);

    for(int i = 0; i < 8; ++i)
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
