using System;
using Altseed;

namespace Sample
{
    class Keyboard
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480);

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var nodeText = new TextNode();
            nodeText.Font = font;

            while (Engine.DoEvents())
            {
                var zstate = Engine.Keyboard.GetKeyState(Keys.Z);

                // Zキーが押されているかどうかを取得
                if (zstate == ButtonState.Free)
                {
                    nodeText.Text = "Zキーを離しています。";
                }
                else if (zstate == ButtonState.Hold)
                {
                    nodeText.Text = "Zキーを押しています。";
                }
                else if (zstate == ButtonState.Push)
                {
                    nodeText.Text = "Zキーを押しました！";
                }
                else if (zstate == ButtonState.Release)
                {
                    nodeText.Text = "Zキーを離しました！";
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
