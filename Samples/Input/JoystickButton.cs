using System;
using Altseed;
using System.Linq;

namespace Sample
{
    class JoystickButton
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("JoystickButton", 640, 480);

            // 状態を出力するための TextNode を作成します。
            // 詳細は TextNode のサンプルを参照してください。
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 40);
            var textNode = new TextNode();
            textNode.Font = font;
            Engine.AddNode(textNode);

            var displayText = "";
            // 指定したインデックスのジョイスティックが接続しているかどうかを取得します。
            if (Engine.Joystick.IsPresent(0))
            {
                var name = Engine.Joystick.GetJoystickName(0);
                displayText = $"コントローラー名: {name}\n";
            }
            else
            {
                displayText = "コントローラーが接続されていません。\n";
            }

            while (Engine.DoEvents())
            {
                foreach (int i in Enumerable.Range(0, 22))
                {
                    // ジョイスティックコントローラーのボタン入力を取得します。
                    // ジョイスティックのインデックスと確認したいジョイスティックボタンを指定します。
                    //     第一引数: ジョイスティックのインデックス
                    //     第二引数: ジョイスティックボタンのインデックス
                    var state = Engine.Joystick.GetButtonState(0, (JoystickButtonType)i);
                    var buttonName = Enum.GetName(typeof(JoystickButtonType), i);

                    if (state == ButtonState.Free)
                    {
                        displayText += $"{buttonName} が離されています\n";
                    }
                    else if (state == ButtonState.Hold)
                    {
                        displayText += $"{buttonName} が押されています\n";
                    }
                    else if (state == ButtonState.Push)
                    {
                        displayText += $"{buttonName} が離されました！\n";
                    }
                    else if (state == ButtonState.Release)
                    {
                        displayText += $"{buttonName} が押されました！\n";
                    }
                }

                // 周波数の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightDown) == ButtonState.Push)
                {
                    displayText += $"周波数: \n";
                }

                textNode.Text = displayText;

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
