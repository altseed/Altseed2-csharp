using System;

using Altseed2;

namespace Sample
{
    class Camera
    {
        [STAThread]
        static void Main(string[] args)
        {
            const ulong cameraGroup = 0b1;

            // Altseed2 を初期化します。
            if (!Engine.Initialize("Camera", 640, 480)) return;

            // SpriteNode を作成します。
            // 詳しくは SpriteNode のサンプルを参照してください。
            var sprite = new SpriteNode();
            // テクスチャを設定します。
            sprite.Texture = Texture2D.Load(@"TestData/IO/AltseedPink256.png");
            sprite.CameraGroup = cameraGroup;
            Engine.AddNode(sprite);

            // sprite の座標を設定します。
            sprite.Position = new Vector2F(100, 100);

            // カメラノードを作成します。
            var camera = new CameraNode();

            // カメラが映す対象とするグループを設定します。
            camera.Group = cameraGroup;

            // カメラが映す箇所の座標を設定します。
            camera.Position = new Vector2F(100, 100);

            // カメラノードを登録します。
            Engine.AddNode(camera);

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
