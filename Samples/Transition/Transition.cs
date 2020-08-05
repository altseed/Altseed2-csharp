using System;

using Altseed2;

namespace Sample
{
    class Transition
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Transition", 640, 480);

            // Altseed のロゴを描画するノードを作成します。
            var altseedPink = new SpriteNode();
            var texAltseed = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            altseedPink.Texture = texAltseed;
            altseedPink.CenterPosition = new Vector2F(200, 200);
            altseedPink.Position = new Vector2F(320, 240);

            // Altseed のロゴを描画するノードを登録します。
            Engine.AddNode(altseedPink);

            // Amusement Creators のロゴを描画するノードを作成します。
            var amusementCreators = new SpriteNode();
            var texAmusementCreators = Texture2D.Load(@"TestData/IO/AmusementCreators.png");
            amusementCreators.Texture = texAmusementCreators;
            amusementCreators.CenterPosition = new Vector2F(200, 200);
            amusementCreators.Position = new Vector2F(320, 240);

            // トランジションを行うノードを作成します。
            var transitionNode = new MyTransitionNode(altseedPink, amusementCreators);

            // トランジションを行うノードを登録します。
            // この瞬間、トランジションが開始されます。
            Engine.AddNode(transitionNode);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }

    // トランジションを行うノードのクラス
    class MyTransitionNode : TransitionNode
    {
        // トランジションに使用するポストエフェクトのノード
        private TransitionEffectNode _MyPostEffect;

        // コンストラクタ
        public MyTransitionNode(Node oldNode, Node newNode) : base(oldNode, newNode, 1.0f, 1.0f)
        {
            // ポストエフェクトのノードを作成します。
            _MyPostEffect = new TransitionEffectNode();

            // ポストエフェクトのノードを登録します。
            Engine.AddNode(_MyPostEffect);
        }

        // ノードが入れ替わるまでの処理
        protected override void OnClosing(float progress)
        {
            // ポストエフェクトのマテリアルに値を渡します。
            _MyPostEffect.Material.SetVector4F("_Value", new Vector4F(1.0f - progress, 0, 0, 0));
        }

        // ノードが入れ替わった後の処理
        protected override void OnOpening(float progress)
        {
            // ポストエフェクトのマテリアルに値を渡します。
            _MyPostEffect.Material.SetVector4F("_Value", new Vector4F(progress, 0, 0, 0));
        }
    }

    // トランジションに使用するポストエフェクトのクラス
    class TransitionEffectNode : PostEffectNode
    {
        // ポストエフェクトに使用するマテリアル
        // 外部からアクセス可
        public Material Material;

        // コンストラクタ
        public TransitionEffectNode()
        {
            // シェーダコード
            var shaderCode = @"
                struct PS_INPUT
                {
                    float4 Position : SV_POSITION;
                    float4 Color : COLOR0;
                    float2 UV1 : UV0;
                    float2 UV2 : UV1;
                };
                Texture2D mainTex : register(t0);
                SamplerState mainSamp : register(s0);
                float4 _Value : register(t1);
                float4 main(PS_INPUT input) : SV_TARGET 
                { 
                    float4 color = mainTex.Sample(mainSamp, input.UV1);
                    color.r *= _Value;
                    color.g *= _Value;
                    color.b *= _Value;
                    return color;
                }
            ";

            // ポストエフェクトに使用するシェーダを作成します。
            var shader = Shader.Create("Transition", shaderCode, ShaderStage.Pixel);

            // ポストエフェクトに使用するマテリアルを作成します。
            Material = Material.Create();

            // マテリアルにシェーダを登録します。
            Material.SetShader(shader);
        }

        // ポストエフェクトを適用する処理
        protected override void Draw(RenderTexture src, Color clearColor)
        {
            // マテリアルにテクスチャを渡します。
            Material.SetTexture("mainTex", src);

            // ポストエフェクトを適用します。
            Engine.Graphics.CommandList.RenderToRenderTarget(Material);
        }
    }
}