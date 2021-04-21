using System;

using Altseed2;
using System.Linq;

namespace Sample
{
    class JoystickAxisSample
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("JoystickAxis", 640, 480);

            // 状態を出力するための TextNode を作成します。
            // 詳細は TextNode のサンプルを参照してください。
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 64);
            var textNode = new TextNode();
            textNode.Font = font;
            textNode.FontSize = 30;
            Engine.AddNode(textNode);

            // ゲームのメインループ
            while (Engine.DoEvents())
            {
                var displayText = "";

                var info = Engine.Joystick.GetJoystickInfo(0);

                if (info is null)
                {
                    displayText = "コントローラーが接続されていません。\n";
                }
                else
                {
                    displayText += $"コントローラー名: {info.Name}\n";
                    displayText += $"プロダクトID: {info.Product}\n";
                    displayText += $"ベンダーID: {info.Vendor}\n";

                    if (info.IsGamepad)
                    {
                        // ゲームパッドとして登録されているJoystickの場合

                        displayText += $"ゲームパッド名: {info.GamepadName}\n";

                        foreach (var axisType in Enum.GetValues(typeof(JoystickAxis)).Cast<JoystickAxis>())
                        {
                            // ジョイスティックコントローラーの軸入力を取得します。
                            // ジョイスティックのインデックスと確認したい軸の種類を指定します。
                            //     第一引数: ジョイスティックのインデックス
                            //     第二引数: ジョイスティック軸の種類(対応しているコントローラーでのみ利用可能)
                            var state = Engine.Joystick.GetAxisState(0, axisType);
                            displayText += $"{axisType} : {state} \n";
                        }
                    }
                    else
                    {
                        // ゲームパッドとして登録されていないJoystickの場合

                        displayText += $"ゲームパッドとして登録されていません。\n";

                        for (int axisIndex = 0; axisIndex < info.AxisCount; axisIndex++)
                        {
                            // ジョイスティックコントローラーの軸入力を取得します。
                            // ジョイスティックのインデックスと確認したい軸のインデックスを指定します。
                            //     第一引数: ジョイスティックのインデックス
                            //     第二引数: ジョイスティックの軸のインデックス
                            var state = Engine.Joystick.GetAxisState(0, axisIndex);
                            displayText += $"{axisIndex}番目のスティック : {state} \n";
                        }
                    }
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
