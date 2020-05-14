using System;

namespace Altseed
{
    [Serializable]
    public class RuledMaskTransitionNode : TransitionNode
    {
        private readonly RuledMaskTransitionEffectNode _EffectNode;

        public RuledMaskTransitionNode(Node oldNode, Node newNode, float duration, Texture2D ruleTexture, float softness) : base(oldNode, newNode, 0.0f, duration)
        {
            _EffectNode = new RuledMaskTransitionEffectNode(ruleTexture, softness);
        }

        protected override void OnTransitionBegin() => AddChildNode(_EffectNode);

        protected override void OnOpening(float progress) => _EffectNode.Progress = progress;
    }

    internal class RuledMaskTransitionEffectNode : PostEffectNode
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
                float4 _Progress;
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

                float4 stepLeft  = lerp(float4(1.0), float4(0.0) - _Softness, _Progress);
                float4 stepRight = lerp(float4(1.0) + _Softness, float4(0.0), _Progress);
                float4 mixRate = smoothstep(stepLeft, stepRight, ruleValue);

                return lerp(maskColor, mainColor, mixRate);
            }
        ";
        
        private readonly Material _TransitionMaterial;

        public float Progress
        {
            get => _TransitionMaterial.GetVector4F("_Progress").X;
            set => _TransitionMaterial.SetVector4F("_Progress", new Vector4F(value, value, value, value));
        }

        public RuledMaskTransitionEffectNode(Texture2D ruleTexture, float softness)
        {
            var shader = Shader.Create("Transition", _ShaderCode, ShaderStageType.Pixel);

            _TransitionMaterial = new Material();
            _TransitionMaterial.SetShader(shader);
            _TransitionMaterial.SetTexture("_RuleTex", ruleTexture);
            _TransitionMaterial.SetVector4F("_Softness", new Vector4F(softness, softness, softness, softness));
            _TransitionMaterial.SetVector4F("_Progress", new Vector4F(0.0f, 0.0f, 0.0f, 0.0f));
        }

        protected override void Draw(RenderTexture src)
        {
            if (_TransitionMaterial.GetTexture("_MaskTex") == null)
                _TransitionMaterial.SetTexture("_MaskTex", src);

            _TransitionMaterial.SetTexture("_MainTex", src);

            RenderToRenderTarget(_TransitionMaterial);
        }
    }
}