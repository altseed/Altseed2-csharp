using System;
using Altseed2;

namespace Sample
{
    public class MyPostEffectNode : PostEffectNode
    {
        static readonly string _HlslCode = @"

        struct PS_INPUT
        {
            float4 Position : SV_POSITION;
            float4 Color : COLOR0;
            float2 UV1 : UV0;
            float2 UV2 : UV1;
        };

        Texture2D mainTex : register(t0);
        SamplerState mainSamp : register(s0);

        float4 main(PS_INPUT input) : SV_TARGET 
        {
            // 入力画像のUV画像に対応するピクセルの色を取得します。
            float4 color = mainTex.Sample(mainSamp, input.UV1);

            // RGBの値を反転します。
            color.xyz = float3(1.0) - color.xyz;

            // 算出した値を返します。
            return color;
        }

        ";

        // ポストエフェクトに使用するマテリアル
        private readonly Material _Material;

        public MyPostEffectNode()
        {
            // マテリアルに使用するシェーダを作成します。
            var shader = Shader.Create("Negative", _HlslCode, ShaderStageType.Pixel);

            // スプライトを描画するノードを作成します。
            _Material = new Material();

            // マテリアルにシェーダを割り当てます。
            _Material.SetShader(shader);
        }

        protected override void Draw(RenderTexture src)
        {
            // マテリアルを入力画像を設定します。
            _Material.SetTexture("mainTex", src);

            // マテリアルを適用します。
            RenderToRenderTarget(_Material);
        }
    }

    public class PostEffectSample
    {

        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("TextNode", 640, 480)) return;

            // テクスチャを読み込みます。
            var texture = Texture2D.Load(@"TestData/IO/AltseedPink256.png");

            // スプライトを描画するノードを作成します。
            var node = new SpriteNode();

            // テクスチャを設定します。
            node.Texture = texture;

            // スプライトを描画するノードを登録します。
            Engine.AddNode(node);

            // ポストエフェクトを描画するノードを作成します。
            var postEffect = new MyPostEffectNode();

            // ポストエフェクトを描画するノードを登録します。
            Engine.AddNode(postEffect);

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
}
