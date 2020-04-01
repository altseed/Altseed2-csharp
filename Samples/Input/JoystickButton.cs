using System;
using Altseed;
using System.Linq;

namespace Sample
{
    class JoystickButton
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480);

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var node = new TextNode();
            var button = new TextNode();
            node.Font = font;
            button.Font = font;
            
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
                var rightup = Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.RightUp);
                if ( rightup == ButtonState.Push
                  || rightup == ButtonState.Hold)
                {
                    continue;
                }

                foreach (int i in Enumerable.Range(0, (int)JoystickButtonType.Max))
                {
                    // ジョイスティックコントローラーのボタン入力を取得。
                    // ジョイスティックのインデックスと確認したいジョイスティックボタンを指定します。
                    //     第一引数: ジョイスティックのインデックス
                    //     第二引数: ジョイスティックボタンのインデックス
                    var state = Engine.Joystick.GetButtonStateByIndex(0, i);
                    var button_name = Enum.GetName(typeof(JoystickButtonType), i);

                    if (state == ButtonState.Free)
                    {
                        button.Text = $"{button_name} が離されています";
                    }
                    else if (state == ButtonState.Hold)
                    {
                        button.Text = $"{button_name} が押されています";
                    }
                    else if (state == ButtonState.Push)
                    {
                        button.Text = $"{button_name} が離されました！";
                    }
                    else if (state == ButtonState.Release)
                    {
                        button.Text = $"{button_name} が押されました！";
                    }
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
