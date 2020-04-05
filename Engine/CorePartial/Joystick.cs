namespace Altseed
{
    public partial class Joystick
    {
        /// <summary>
        /// ジョイスティックの最大同時接続数を取得します。
        /// </summary>
        public int MaxCount { get; } = 16;

        /// <summary>
        /// ボタンの状態をインデックスで取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="buttonIndex">状態を検索するボタンのインデックス</param>
        /// <returns>指定インデックスのボタンの状態</returns>
        public ButtonState GetButtonState(int joystickIndex, int buttonIndex) => GetButtonStateByIndex(joystickIndex, buttonIndex);

        /// <summary>
        /// ボタンの状態を種類から取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索するボタンの種類</param>
        /// <returns>指定種類のボタンの状態</returns>
        public ButtonState GetButtonState(int joystickIndex, JoystickButtonType type) => GetButtonStateByType(joystickIndex, type);

        /// <summary>
        /// 軸の状態をインデックスで取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="axisIndex">状態を検索する軸のインデックス</param>
        /// <returns>指定インデックスの軸の状態</returns>
        internal float GetAxisState(int joystickIndex, int axisIndex) => GetAxisStateByIndex(joystickIndex, axisIndex);

        /// <summary>
        /// 軸の状態を軸の種類で取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索する軸の種類</param>
        /// <returns>指定種類の軸の状態</returns>
        internal float GetAxisState(int joystickIndex, JoystickAxisType type) => GetAxisStateByType(joystickIndex, type);
    }
}
