using System;

using Altseed2;

namespace Sample
{
    class PackageWithPassword
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            if (!Engine.Initialize("SpriteNode", 640, 480)) return;

            // TestData ディレクトリからファイルパッケージを生成します。
            // パスワードを ALTSEED とします。
            Engine.File.PackWithPassword("TestData", "Package.pack", "ALTSEED");

            // Package.pack をルートパッケージにします。
            Engine.File.AddRootPackageWithPassword("Package.pack", "ALTSEED");

            // パッケージに含まれる画像データをロードします。
            var texture = Texture2D.Load(@"TestData/IO/AltseedPink256.png");

            // 画像を描画するノードを生成・登録します。
            var node = new SpriteNode();
            node.Texture = texture;
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
