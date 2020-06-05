using System;
using Altseed;

namespace Sample
{
    public class JoystickVibrate
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("JoystickVibrate", 640, 480);

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

            //インデックス0のジョイスティックを、振動数150・振幅0.7で振動させます。
            var frequency = 100.0f;
            var amptitude = 0.7f;
            var time = 500f;

            var freqRate = 10.0f;
            var ampRate = 0.05f;
            var timeRate = 25f;

            // 振動時間を管理します。
            var sw = new System.Diagnostics.Stopwatch();
            var tl = new System.Diagnostics.Stopwatch();
            tl.Start();

            // ゲームのメインループ
            while (Engine.DoEvents())
            {
                // 指定した時間になったら、振動を停止させます。
                if (sw.IsRunning && sw.Elapsed.TotalMilliseconds >= time)
                {
                    Engine.Joystick.Vibrate(0, 100f, 0.0f);
                    displayText += "振動停止\n";
                    sw.Reset();
                }

                // 周波数の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightDown) == ButtonState.Push)
                {
                    frequency -= freqRate;
                    displayText += $"周波数: {frequency}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightUp) == ButtonState.Push)
                {
                    frequency += freqRate;
                    displayText += $"周波数: {frequency}\n";
                }

                // 振幅の調整
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightLeft) == ButtonState.Push)
                {
                    amptitude -= ampRate;
                    displayText += $"振幅: {amptitude}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.RightRight) == ButtonState.Push)
                {
                    amptitude += ampRate;
                    displayText += $"振幅: {amptitude}\n";
                }

                // 時間
                if (Engine.Joystick.GetButtonState(0, JoystickButtonType.L3) == ButtonState.Push)
                {
                    time -= timeRate;
                    displayText += $"時間(ミリ秒): {time}\n";
                }
                else if (Engine.Joystick.GetButtonState(0, JoystickButtonType.R3) == ButtonState.Push)
                {
                    time += timeRate;
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

                textNode.Text = displayText;

                // Altseed2 の各種更新処理を行います。
                Engine.Update();
            }

            // Altseedの終了処理をします。
            Engine.Terminate();
        }
    }
}
