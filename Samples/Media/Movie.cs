using System;

using Altseed2;

namespace Sample
{
    class Movie
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("Movie", 640, 480)) return;

            // 空のテクスチャを読み込みます。
            var texture = RenderTexture.Create(new Vector2I(640, 480), TextureFormat.R8G8B8A8_UNORM);

            // 映像を読み込みます。
            var mediaPlayer = MediaPlayer.Load(@"TestData/Movie/Test1.mp4");

            // 映像を再生します。
            mediaPlayer.Play(false);

            // スプライトを描画するノードを作成します。
            var node = new SpriteNode();

            // テクスチャを設定します。
            node.Texture = texture;

            // ノードを登録します。
            Engine.AddNode(node);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // 現在の映像を画像に書き込みます。
                mediaPlayer.WriteToRenderTexture(texture);

                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}
