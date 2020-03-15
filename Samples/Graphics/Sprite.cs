using System;

using Altseed;

namespace Sample
{
    class Sprite
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            if (!Engine.Initialize("SpriteNode", 640, 480, new Configuration())) return;

            // テクスチャを読み込みます。
            var texture = Texture2D.Load(@"TestData\IO\AltseedPink256.png");

            // スプライトを描画するノードを作成します。
            var node = new SpriteNode();
            node.Texture = texture;

            // ノードを登録します。
            Engine.AddNode(node);

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
