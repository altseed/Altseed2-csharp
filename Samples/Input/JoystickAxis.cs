using System;

using Altseed;

namespace Sample
{
    class JoystickAxis
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("JoystickAxis", 640, 480);

            // 状態を出力するための TextNode を作成します。
            // 詳細は TextNode のサンプルを参照してください。
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 40);
            var textNode = new TextNode();
            textNode.Font = font;
            Engine.AddNode(textNode);

            string displayText;
            // 指定したインデックスのジョイスティックが接続しているかどうかを取得します。
            if (Engine.Joystick.IsPresent(0))
            {
                var name = Engine.Joystick.GetJoystickName(0);
                displayText = $"コントローラー名: {name}";
            }
            else
            {
                displayText = "コントローラーが接続されていません。";
            }

            // ゲームのメインループ
            while (Engine.DoEvents())
            {
                if (Engine.Joystick.IsPresent(0))
                {
                    var leftH = Engine.Joystick.GetAxisState(0, JoystickAxisType.LeftH);
                    var leftV = Engine.Joystick.GetAxisState(0, JoystickAxisType.LeftV);
                    var rightH = Engine.Joystick.GetAxisState(0, JoystickAxisType.RightH);
                    var rightV = Engine.Joystick.GetAxisState(0, JoystickAxisType.RightV);

                    textNode.Text = displayText +
                        $"水平 / 垂直\n" +
                        $"左スティック:{leftH} / {leftV}\n" +
                        $"右スティック: {rightH} / {rightV}";
                }
                else textNode.Text = displayText;

                // Altseed2 の各種更新処理を行います。
                Engine.Update();
            }

            // Altseedの終了処理をします。
            Engine.Terminate();
        }
    }
}
