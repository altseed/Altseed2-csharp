using System;
using Altseed;

namespace Sample
{
    public class JoystickVibrate
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Altseed Docs Test", 640, 480, new Configuration());

            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 100);

            var node = new TextNode();
            var status = new TextNode();
            node.Font = font;
            status.Font = font;

            //Engine.AddNode(node);
            //Engine.AddNode(status);
            if (Altseed.Engine.Joystick.IsPresent(0))
            {
                var name = Altseed.Engine.Joystick.GetJoystickType(0);
                node.Text = $"コントローラー名: {name}";
            }
            else
            {
                node.Text = "コントローラーが接続されていません。";
            }
            Console.WriteLine(node.Text);

            //インデックス0のジョイスティックを、振動数150・振幅0.7で振動させます。
            var frequency = 100.0f;
            var amptitude = 0.7f;
            var time = 500f;

            var freq_rate = 10.0f;
            var amp_rate = 0.05f;
            var time_rate = 25f;

            // 振動時間を管理
            var sw = new System.Diagnostics.Stopwatch();
            var tl = new System.Diagnostics.Stopwatch();
            tl.Start();

            var displayText = "";

            // ゲームのメインループ
            while (Engine.DoEvents())
            {

                // 指定した時間になったら、振動を停止させる。
                if (sw.IsRunning && sw.Elapsed.TotalMilliseconds >= time)
                {
                    Engine.Joystick.Vibrate(0, 100f, 0.0f);
                    displayText += "振動停止\n";
                    sw.Reset();
                }

                // 周波数の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightDown) == ButtonState.Push)
                {
                    frequency -= freq_rate;
                    displayText += $"周波数: {frequency}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightUp) == ButtonState.Push)
                {
                    frequency += freq_rate;
                    displayText += $"周波数: {frequency}\n";
                }

                // 振幅の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightLeft) == ButtonState.Push)
                {
                    amptitude -= amp_rate;
                    displayText += $"振幅: {amptitude}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightRight) == ButtonState.Push)
                {
                    amptitude += amp_rate;
                    displayText += $"振幅: {amptitude}\n";
                }

                // 時間
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.L3) == ButtonState.Push)
                {
                    time -= time_rate;
                    displayText += $"時間(ミリ秒): {time}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.R3) == ButtonState.Push)
                {
                    time += time_rate;
                    displayText += $"時間(ミリ秒): {time}\n";
                }

                // ジョイスティックの振動
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.R1) == ButtonState.Push && !sw.IsRunning)
                {
                    displayText += "振動開始\n";
                    displayText += $"  周波数: {frequency}\n";
                    displayText += $"  振幅　: {amptitude}\n";
                    displayText += $"  時間　: {time}\n";
                    Engine.Joystick.Vibrate(0, frequency, amptitude);
                    sw.Start();
                }
                status.Text = displayText;

                Console.WriteLine(displayText);

                // Altseed2 の各種更新処理を行います。
                Engine.Update();
            }

            // Altseedの終了処理をします。
            Engine.Terminate();
        }
    }
}
