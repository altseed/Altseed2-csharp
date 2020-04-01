using System;
using Altseed;

namespace Sample
{
    class Mouse
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480);

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var nodeText = new TextNode();
            nodeText.Font = font;

            while (Engine.DoEvents())
            {
                // マウスの左ボタンが押されているかどうかを取得
                if (Engine.Mouse.GetMouseButtonState(MouseButtons.ButtonLeft) == ButtonState.Hold)
                {
                    nodeText.Text = "左ボタンが押されています。";
                }
                else
                {
                    nodeText.Text = "左ボタンが押されていません。";
                }

                // マウスの座標を取得
                Vector2F position = Engine.Mouse.Position;
                nodeText.Text += $"\nポジション(x/y): {position.X} / {position.Y}";

                // マウスホイールの値を取得
                nodeText.Text += $"\nホイール　　　　: {Engine.Mouse.Wheel}";

                // マウスモードの取得
                nodeText.Text += $"\nモード　　　　　: {Engine.Mouse.CursorMode}";

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
