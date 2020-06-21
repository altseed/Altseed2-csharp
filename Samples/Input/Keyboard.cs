using System;
using Altseed2;

namespace Sample
{
    class Keyboard
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Keyboard", 640, 480);

            // 状態を出力するための TextNode を作成します。
            // 詳細は TextNode のサンプルを参照してください。
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 40);
            var textNode = new TextNode();
            textNode.Font = font;

            while (Engine.DoEvents())
            {
                var zState = Engine.Keyboard.GetKeyState(Keys.Z);

                // Zキーが押されているかどうかを取得します。
                if (zState == ButtonState.Free)
                {
                    textNode.Text = "Zキーを離しています。";
                }
                else if (zState == ButtonState.Hold)
                {
                    textNode.Text = "Zキーを押しています。";
                }
                else if (zState == ButtonState.Push)
                {
                    textNode.Text = "Zキーを押しました！";
                }
                else if (zState == ButtonState.Release)
                {
                    textNode.Text = "Zキーを離しました！";
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
