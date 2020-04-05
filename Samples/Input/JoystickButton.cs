using System;
using Altseed;
using System.Linq;

namespace Sample
{
    class JoystickButton
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480, new Configuration());

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var node = new TextNode();
            var stateText = new TextNode();
            node.Font = font;
            stateText.Font = font;
            
            // 指定したインデックスのジョイスティックが存在しているかを確認
            if (Altseed.Engine.Joystick.IsPresent(0))
            {
                // 指定したインデックスのジョイスティックコントローラーのプロダクト名の取得
                var name = Altseed.Engine.Joystick.GetJoystickName(0);
                node.Text = $"コントローラー名: {name}";
            }
            else
            {
                node.Text = "コントローラーが接続されていません。";
            }

            while (Engine.DoEvents())
            {
                var displayText = "";

                foreach (int i in Enumerable.Range(0, 22))
                {
                    // ジョイスティックコントローラーのボタン入力を取得。
                    // ジョイスティックのインデックスと確認したいジョイスティックボタンを指定します。
                    //     第一引数: ジョイスティックのインデックス
                    //     第二引数: ジョイスティックボタンのインデックス
                    var state = Engine.Joystick.GetButtonState(0, (JoystickButtonType)i);
                    var button_name = Enum.GetName(typeof(JoystickButtonType), i);

                    if (state == ButtonState.Free)
                    {
                        displayText += $"{button_name} が離されています\n";
                    }
                    else if (state == ButtonState.Hold)
                    {
                        displayText += $"{button_name} が押されています\n";
                    }
                    else if (state == ButtonState.Push)
                    {
                        displayText += $"{button_name} が離されました！\n";
                    }
                    else if (state == ButtonState.Release)
                    {
                        displayText += $"{button_name} が押されました！\n";
                    }
                }
                // 周波数の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightDown) == ButtonState.Push)
                {
                    displayText += $"周波数: \n";
                }

                stateText.Text = displayText;

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
