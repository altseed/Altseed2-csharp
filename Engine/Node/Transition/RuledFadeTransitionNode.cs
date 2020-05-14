using System;

namespace Altseed
{
    [Serializable]
    public class RuledFadeTransitionNode : TransitionNode
    {
        private readonly RuledFadeTransitionEffectNode _EffectNode;

        private readonly Texture2D _ClosingRuleTexture;
        private readonly Texture2D _OpeningRuleTexture;

        private readonly float _ClosingSoftness;
        private readonly float _OpeningSoftness;

        public RuledFadeTransitionNode(Node oldNode, Node newNode, float closingDuration, float openingDuration, Texture2D maskTexture, Texture2D closingRuleTexture, Texture2D openingRuleTexture, float closingSoftness, float openingSoftness) : base(oldNode, newNode, closingDuration, openingDuration)
        {
            _EffectNode = new RuledFadeTransitionEffectNode(maskTexture);

            _ClosingRuleTexture = closingRuleTexture;
            _OpeningRuleTexture = openingRuleTexture;

            _ClosingSoftness = closingSoftness;
            _OpeningSoftness = openingSoftness;
        }

        protected override void OnTransitionBegin()
        {
            _EffectNode.RuleTexture = _ClosingRuleTexture;
            _EffectNode.Softness = _ClosingSoftness;
            _EffectNode.MaskedRate = 0.0f;

            AddChildNode(_EffectNode);
        }

        protected override void OnClosing(float progress)
        {
            _EffectNode.MaskedRate = progress;
        }

        protected override void OnNodeSwapped()
        {
            _EffectNode.RuleTexture = _OpeningRuleTexture;
            _EffectNode.Softness = _OpeningSoftness;
            _EffectNode.MaskedRate = 1.0f;
        }

        protected override void OnOpening(float progress)
        {
            _EffectNode.MaskedRate = 1.0f - progress;
        }
    }

    internal class RuledFadeTransitionEffectNode : PostEffectNode
    {
        private const string _ShaderCode = @"
            struct PS_INPUT
            {
                float4 Position : SV_POSITION;
                float4 Color : COLOR0;
                float2 UV1 : UV0;
                float2 UV2 : UV1;
            };
            
            cbuffer Consts : register(b1)
            {
                float4 _Softness;
                float4 _MaskedRate;
            };

            Texture2D _MainTex : register(t0);
            SamplerState _MainSamp : register(s0);

            Texture2D _MaskTex : register(t1);
            SamplerState _MaskSamp : register(s1);
            
            Texture2D _RuleTex : register(t2);
            SamplerState _RuleSamp : register(s2);

            float4 main(PS_INPUT input) : SV_TARGET
            {
                float4 mainColor = _MainTex.Sample(_MainSamp, input.UV1);
                float4 maskColor = _MaskTex.Sample(_MaskSamp, input.UV1);
                float4 ruleValue = _RuleTex.Sample(_RuleSamp, input.UV1);

                float4 stepLeft  = lerp(float4(1.0), float4(0.0) - _Softness, _MaskedRate);
                float4 stepRight = lerp(float4(1.0) + _Softness, float4(0.0), _MaskedRate);
                float4 maskedRate = smoothstep(stepLeft, stepRight, ruleValue);

                return lerp(mainColor, maskColor, maskedRate);
            }
        ";

        private readonly Material _TransitionMaterial;

        public TextureBase RuleTexture
        {
            get => _TransitionMaterial.GetTexture("_RuleTex");
            set => _TransitionMaterial.SetTexture("_RuleTex", value);
        }

        public float MaskedRate
        {
            get => _TransitionMaterial.GetVector4F("_MaskedRate").X;
            set => _TransitionMaterial.SetVector4F("_MaskedRate", new Vector4F(value, value, value, value));
        }

        public float Softness
        {
            get => _TransitionMaterial.GetVector4F("_Softness").X;
            set => _TransitionMaterial.SetVector4F("_Softness", new Vector4F(value, value, value, value));
        }

        public RuledFadeTransitionEffectNode(Texture2D maskTexture)
        {
            var shader = Shader.Create("Transition", _ShaderCode, ShaderStageType.Pixel);

            _TransitionMaterial = new Material();
            _TransitionMaterial.SetShader(shader);
            _TransitionMaterial.SetTexture("_MaskTex", maskTexture);
        }

        protected override void Draw(RenderTexture src)
        {
            _TransitionMaterial.SetTexture("_MainTex", src);
            RenderToRenderTarget(_TransitionMaterial);
        }
    }
}
