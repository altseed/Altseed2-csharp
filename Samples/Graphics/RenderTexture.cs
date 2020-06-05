using System;

using Altseed;

namespace Sample
{
    class Camera_RenderTexture
    {
        [STAThread]
        static void Main(string[] args)
        {
            const int cameraGroup = 1;
            const int cameraGroup2 = 2;

            // Altseed2 を初期化します。
            if (!Engine.Initialize("RenderTexture", 640, 480)) return;

            // SpriteNode を作成します。
            // 詳しくは SpriteNode のサンプルを参照してください。
            var sprite = new SpriteNode();
            sprite.Texture = Texture2D.Load(@"TestData\IO\AltseedPink256.png");
            sprite.CameraGroup = 1u << cameraGroup;
            sprite.Scale = new Vector2F(200, 200) / sprite.Texture.Size;
            Engine.AddNode(sprite);

            // スクリーンのように描画先にできるテクスチャを作成します。
            var renderTexture = RenderTexture.Create(new Vector2I(200, 200));

            // sprite を写してrenderTexture に出力する CameraNode を作成します。
            // 詳しくは CameraNode のサンプルを参照してください。
            var camera = new CameraNode();
            camera.Group = cameraGroup;
            Engine.AddNode(camera);

            // カメラの描画先を設定します。
            // null のとき出力先はスクリーンになります。
            camera.TargetTexture = renderTexture;

            // 描画する前に TargetTexture を指定色で塗りつぶすかどうかを設定します。
            camera.IsColorCleared = true;

            // 塗りつぶす色を設定します。
            camera.ClearColor = new Color(100, 100, 100);

            // renderTexture をスクリーンに描画するための SpriteNode を作成します。
            var sprite2 = new SpriteNode();
            sprite2.Texture = renderTexture;
            sprite2.CameraGroup = 1u << cameraGroup2;
            Engine.AddNode(sprite2);

            // sprite2 を写してスクリーンに出力するカメラを作成します。
            var camera2 = new CameraNode();
            camera2.Group = cameraGroup2;
            Engine.AddNode(camera2);

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
