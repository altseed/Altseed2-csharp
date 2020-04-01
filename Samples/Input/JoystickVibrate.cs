using System;
using Altseed;

namespace Sample
{
    public class JoystickVibrate
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480);

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var node = new TextNode();
            var status = new TextNode();
            node.Font = font;
            status.Font = font;

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
                //インデックス0のジョイスティックを、振動数150・振幅0.7で振動させます。
                var frequency = 100.0f;
                var amptitude = 0.7f;
                var time = 1000f;

                var freq_rate = 10.0f;
                var amp_rate = 0.05f;
                var time_rate = 250f;

                // 振動時間を管理
                var sw = new System.Diagnostics.Stopwatch();

                while (Altseed.Engine.Joystick.IsPresent(0))
                {
                    if (sw.IsRunning && (sw.Elapsed).Milliseconds >= time)
                    {
                        Engine.Joystick.Vibrate(0, 100f, 0.0f);
                        status.Text += "振動停止\n";
                    }

                    // 振動数の調整
                    if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.RightDown) == ButtonState.Push)
                    {
                        frequency -= freq_rate;
                        status.Text += $"振動数: {frequency}\n";
                    }
                    else if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.RightUp) == ButtonState.Push)
                    {
                        frequency += freq_rate;
                        status.Text += $"振動数: {frequency}\n";
                    }

                    // 振幅の調整
                    if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.RightLeft) == ButtonState.Push)
                    {
                        amptitude -= amp_rate;
                        status.Text += $"振幅: {amptitude}\n";
                    }
                    else if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.RightRight) == ButtonState.Push)
                    {
                        amptitude += amp_rate;
                        status.Text += $"振幅: {amptitude}\n";
                    }

                    // 時間
                    if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.L3) == ButtonState.Push)
                    {
                        time -= time_rate;
                        status.Text += $"時間(ミリ秒): {time}\n";
                    }
                    else if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.R3) == ButtonState.Push)
                    {
                        time += time_rate;
                        status.Text += $"時間(ミリ秒): {time}\n";
                    }

                    // ジョイスティックの振動
                    if (Engine.Joystick.GetButtonStateByType(0, JoystickButtonType.R1) == ButtonState.Push && !sw.IsRunning)
                    {
                        Engine.Joystick.Vibrate(0, frequency, amptitude);
                        sw.Start();
                    }

                }

                // Altseed2 の各種更新処理を行います。
                Engine.Update();
            }

            // Altseedの終了処理をします。
            Engine.Terminate();
        }
    }
}
