using System;
using Altseed2;

namespace Sample
{
    public class PostEffectGrayScale
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("PostEffect - GrayScale", 640, 480)) return;

            // 画像を表示するノードを作成して登録します。
            // 詳しくはSpriteのサンプルを参照してください。
            var node = new SpriteNode
            {
                Texture = Texture2D.Load(@"TestData/Graphics/flower.png"),
                Scale = new Vector2F(0.5f, 0.5f)
            };

            Engine.AddNode(node);

            // グレースケールを適用するポストエフェクトを作成して登録します。
            var postEffect = new PostEffectGrayScaleNode();

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
