using System;
using Altseed;

namespace Sample
{
    class MouseCursor
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("MouseCursor", 640, 480);

            // まず、カーソルオブジェクトを生成します。画像の読み込みに失敗するとnullが返ります。
            // 引数は、string(png画像のパス), Altseed.Vector2I(クリック判定の相対座標) です。
            var cursor = Cursor.Create("../../Core/TestData/Input/altseed_logo.png", new Vector2I(16, 16));

            if (cursor != null)
            {
                // マウスにカーソルをセットします。
                Engine.Mouse.SetCursorImage(cursor);
            }

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
