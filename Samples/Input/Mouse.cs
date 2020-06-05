using System;
using Altseed;

namespace Sample
{
    class Mouse
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Mouse", 640, 480);

            // 状態を出力するための TextNode を作成します。
            // 詳細は TextNode のサンプルを参照してください。
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 40);
            var textNode = new TextNode();
            textNode.Font = font;
            Engine.AddNode(textNode);

            while (Engine.DoEvents())
            {
                // マウスの左ボタンが押されているかどうかを取得します。
                if (Engine.Mouse.GetMouseButtonState(MouseButtons.ButtonLeft) == ButtonState.Hold)
                {
                    textNode.Text = "左ボタンが押されています。";
                }
                else
                {
                    textNode.Text = "左ボタンが押されていません。";
                }

                // マウスの座標を取得します。
                Vector2F position = Engine.Mouse.Position;
                textNode.Text += $"\nポジション(x/y): {position.X} / {position.Y}";

                // マウスホイールの値を取得します。
                textNode.Text += $"\nホイール　　　　: {Engine.Mouse.Wheel}";

                // マウスモードを取得します。
                textNode.Text += $"\nモード　　　　　: {Engine.Mouse.CursorMode}";

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
