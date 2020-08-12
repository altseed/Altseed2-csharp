using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="RuledTransitionNode"/>の制御に用いる設定のクラス
    /// </summary>
    [Serializable]
    public sealed class RuledTransitionState
    {
        /// <summary>
        /// この設定を適用するノードを取得または設定します。
        /// </summary>
        public Node TargetNode { get; set; }
        /// <summary>
        /// 遷移に掛かる時間を取得または設定します。
        /// </summary>
        public float Duration { get; set; }
        public Texture2D RuleTexture { get; set; }
        public float Softness { get; set; }
        /// <summary>
        /// <see cref="RuledTransitionState"/>の新しいインスタンスを生成します。
        /// </summary>
        public RuledTransitionState() { }
    }

    /// <summary>
    /// パラメータ制御可能な<see cref="TransitionNode"/>のクラス
    /// </summary>
    [Serializable]
    public class RuledTransitionNode : TransitionNode
    {
        private readonly RuledTransitionEffectNode _TransitionEffectNode;

        private readonly RuledTransitionState _ClosingState;
        private readonly RuledTransitionState _OpeningState;

        /// <summary>
        /// 指定したマスクテクスチャを用いて<see cref="RuledTransitionNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="closingState">遷移元のノードにおける<see cref="RuledTransitionState"/>のインスタンス</param>
        /// <param name="openingState">遷移先のノードにおける<see cref="RuledTransitionState"/>のインスタンス</param>
        /// <param name="maskTexture">使用するマスクテクスチャ</param>
        public RuledTransitionNode(RuledTransitionState closingState, RuledTransitionState openingState, Texture2D maskTexture)
            : base(closingState.TargetNode, openingState.TargetNode, closingState.Duration, openingState.Duration)
        {
            _ClosingState = closingState;
            _OpeningState = openingState;

            _TransitionEffectNode = new RuledTransitionEffectNode
            {
                MaskTexture = maskTexture,
                RuleTexture = _ClosingState.RuleTexture,
                Softness = _ClosingState.Softness,
                MixRate = 0.0f,
                UseCaptionAsMaskTexture = false
            };
        }

        /// <summary>
        /// 既定のマスクテクスチャを用いて<see cref="RuledTransitionNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="closingState">遷移元のノードにおける<see cref="RuledTransitionState"/>のインスタンス</param>
        /// <param name="openingState">遷移先のノードにおける<see cref="RuledTransitionState"/>のインスタンス</param>
        public RuledTransitionNode(RuledTransitionState closingState, RuledTransitionState openingState)
            : base(closingState.TargetNode, openingState.TargetNode, closingState.Duration, openingState.Duration)
        {
            _ClosingState = closingState;
            _OpeningState = openingState;

            _TransitionEffectNode = new RuledTransitionEffectNode
            {
                MaskTexture = null,
                RuleTexture = _ClosingState.RuleTexture,
                Softness = _ClosingState.Softness,
                MixRate = 0.0f,
                UseCaptionAsMaskTexture = true
            };
        }

        /// <inheritdoc/>
        /// <remarks>オーバーライドするときは上書きせず呼び出す事</remarks>
        protected override void OnTransitionBegin()
        {
            AddChildNode(_TransitionEffectNode);
        }

        /// <inheritdoc/>
        /// <remarks>オーバーライドするときは上書きせず呼び出す事</remarks>
        protected override void OnClosing(float progress)
        {
            _TransitionEffectNode.MixRate = progress;
        }

        /// <inheritdoc/>
        /// <remarks>オーバーライドするときは上書きせず呼び出す事</remarks>
        protected override void OnNodeSwapped()
        {
            _TransitionEffectNode.RuleTexture = _OpeningState.RuleTexture;
            _TransitionEffectNode.Softness = _OpeningState.Softness;
            _TransitionEffectNode.MixRate = 1.0f;
        }

        /// <inheritdoc/>
        /// <remarks>オーバーライドするときは上書きせず呼び出す事</remarks>
        protected override void OnOpening(float progress)
        {
            _TransitionEffectNode.MixRate = 1.0f - progress;
        }
    }

    [Serializable]
    internal class RuledTransitionEffectNode : PostEffectNode
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
                float4 _MixRate;
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

                float4 stepLeft  = lerp(float4(1.0), float4(0.0) - _Softness, _MixRate);
                float4 stepRight = lerp(float4(1.0) + _Softness, float4(0.0), _MixRate);
                float4 mixRate = smoothstep(stepLeft, stepRight, ruleValue);

                return lerp(mainColor, maskColor, mixRate);
            }
        ";

        private readonly Material _Material;

        public TextureBase MaskTexture
        {
            get => _Material.GetTexture("_MaskTex");
            set
            {
                if (MaskTexture == value) return;
                _Material.SetTexture("_MaskTex", value);
            }
        }

        public TextureBase RuleTexture
        {
            get => _Material.GetTexture("_RuleTex");
            set
            {
                if (RuleTexture == value) return;
                _Material.SetTexture("_RuleTex", value);
            }
        }

        public float Softness
        {
            get => _Material.GetVector4F("_Softness").X;
            set
            {
                if (Softness == value) return;
                _Material.SetVector4F("_Softness", new Vector4F(value, value, value, value));
            }
        }

        public float MixRate
        {
            get => _Material.GetVector4F("_MixRate").X;
            set
            {
                if (MixRate == value) return;
                _Material.SetVector4F("_MixRate", new Vector4F(value, value, value, value));
            }
        }

        public bool UseCaptionAsMaskTexture { get; set; }

        public RuledTransitionEffectNode()
        {
            _Material = Material.Create();
            _Material.SetShader(Shader.Create("Transition", _ShaderCode, ShaderStage.Pixel));
        }

        protected override void Draw(RenderTexture src, Color clearColor)
        {
            if (UseCaptionAsMaskTexture && MaskTexture == null)
            {
                var maskTexture = RenderTexture.Create(src.Size, src.Format);
                Engine.Graphics.CommandList.CopyTexture(src, maskTexture);
                MaskTexture = maskTexture;
            }

            _Material.SetTexture("_MainTex", src);
            Engine.Graphics.CommandList.RenderToRenderTarget(_Material);
        }
    }
}
