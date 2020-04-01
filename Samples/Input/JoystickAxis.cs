using System;
using Altseed;

namespace Sample
{
    class JoystickAxis
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480);

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var node = new TextNode();
            var stick_text = new TextNode();
            node.Font = font;
            stick_text.Font = font;

            Engine.Update();
            if (Altseed.Engine.Joystick.IsPresent(0))
            {
                var name = Altseed.Engine.Joystick.GetJoystickName(0);
                node.Text = $"コントローラー名: {name}";
            }
            else
            {
                node.Text = "コントローラーが接続されていません。";
            }

            // ゲームのメインループ
            while (Engine.DoEvents())
            {

                var left_h = Engine.Joystick.GetAxisStateByType(0, JoystickAxisType.LeftH);
                var left_v = Engine.Joystick.GetAxisStateByType(0, JoystickAxisType.LeftV);
                var right_h = Engine.Joystick.GetAxisStateByType(0, JoystickAxisType.RightH);
                var right_v = Engine.Joystick.GetAxisStateByType(0, JoystickAxisType.RightV);

                var lstick = $"左スティック: {left_h} / {left_v}";
                var rstick = $"右スティック: {right_h} / {right_v}";


                // Altseed2 の各種更新処理を行います。
                Engine.Update();
            }

            // Altseedの終了処理をします。
            Engine.Terminate();
        }
    }
}
