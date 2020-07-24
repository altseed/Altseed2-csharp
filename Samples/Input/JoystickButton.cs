using System;
using Altseed2;
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
            var font = Font.LoadDynamicFont("./mplus-1m-regular.ttf", 20);
            var textNode = new TextNode();
            textNode.Font = font;
            Engine.AddNode(textNode);

            while (Engine.DoEvents())
            {
                var displayText = "";

                var info = Engine.Joystick.GetJoystickInfo(0);

                // 指定したインデックスのジョイスティックが接続しているかどうかを確認します。
                // Joystick.IsPresentも利用できます。(こちらの方が高速)
                if(info is null)
                {
                    displayText = "コントローラーが接続されていません。\n";
                }
                else
                {
                    displayText += $"コントローラー名: {info.Name}\n";
                    displayText += $"プロダクトID: {info.Product}\n";
                    displayText += $"ベンダーID: {info.Vendor}\n";

                    if(info.IsGamepad)
                    {
                        // ゲームパッドとして登録されているJoystickの場合

                        // Nameよりもわかりやすい名前を取得可能です。
                        displayText += $"ゲームパッド名: {info.GamepadName}\n";

                        foreach (var buttonType in Enum.GetValues(typeof(JoystickButtons)).Cast<JoystickButtons>())
                        {
                            // ジョイスティックコントローラーのボタン入力を取得します。
                            // ジョイスティックのインデックスと確認したいジョイスティックボタンを指定します。
                            //     第一引数: ジョイスティックのインデックス
                            //     第二引数: ジョイスティックボタンの種類(対応しているコントローラーでのみ利用可能)
                            var state = Engine.Joystick.GetButtonState(0, buttonType);
                            var buttonName = buttonType.ToString();

                            displayText += state switch {
                                ButtonState.Free => $"{buttonName}が離されています\n",
                                ButtonState.Hold => $"{buttonName}が押されています\n",
                                ButtonState.Release => $"{buttonName}が離されました！\n",
                                ButtonState.Push => $"{buttonName}が押されました！\n",
                                _ => $"{buttonName}が想定されていない状態({(int)state})です\n",
                            };
                        }
                    }
                    else
                    {
                        // ゲームパッドとして登録されていないJoystickの場合
                        displayText += $"ゲームパッドとして登録されていません。\n";

                        for (int buttonIndex = 0; buttonIndex < info.ButtonCount; buttonIndex++)
                        {
                            // ジョイスティックコントローラーのボタン入力を取得します。
                            // ジョイスティックのインデックスと確認したいボタンインデックスを指定します。
                            //     第一引数: ジョイスティックのインデックス
                            //     第二引数: ジョイスティックのボタンのインデックス
                            var state = Engine.Joystick.GetButtonState(0, buttonIndex);

                            displayText += state switch {
                                ButtonState.Free => $"{buttonIndex}番目のボタンが離されています\n",
                                ButtonState.Hold => $"{buttonIndex}番目のボタンが押されています\n",
                                ButtonState.Release => $"{buttonIndex}番目のボタンが離されました！\n",
                                ButtonState.Push => $"{buttonIndex}番目のボタンが押されました！\n",
                                _ => $"{buttonIndex}番目のボタンが想定されていない状態({(int)state})です\n",
                            };
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
