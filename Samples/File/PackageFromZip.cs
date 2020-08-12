﻿using System;

using Altseed2;

namespace Sample
{
    class PackageFromZip
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            if (!Engine.Initialize("SpriteNode", 640, 480)) return;

            // Package.zip をルートパッケージにします。
            Engine.File.AddRootPackage("Package.zip");

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
