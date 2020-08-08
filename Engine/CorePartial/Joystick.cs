namespace Altseed2
{
    public partial class Joystick
    {
        /// <summary>
        /// ジョイスティックの最大同時接続数を取得します。
        /// </summary>
        public readonly int MaxCount = 16;

        /// <summary>
        /// ボタンの状態をインデックスで取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="buttonIndex">状態を検索するボタンのインデックス</param>
        /// <returns>指定インデックスのボタンの状態</returns>
        public ButtonState GetButtonState(int joystickIndex, int buttonIndex)
            => (ButtonState)cbg_Joystick_GetButtonStateByIndex(selfPtr, joystickIndex, buttonIndex);

        /// <summary>
        /// ボタンの状態を種類から取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索するボタンの種類</param>
        /// <returns>指定種類のボタンの状態</returns>
        public ButtonState GetButtonState(int joystickIndex, JoystickButton type)
            => (ButtonState)cbg_Joystick_GetButtonStateByType(selfPtr, joystickIndex, (int)type);

        /// <summary>
        /// 軸の状態をインデックスで取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="axisIndex">状態を検索する軸のインデックス</param>
        /// <returns>指定インデックスの軸の状態</returns>
        public float GetAxisState(int joystickIndex, int axisIndex)
            => cbg_Joystick_GetAxisStateByIndex(selfPtr, joystickIndex, axisIndex);

        /// <summary>
        /// 軸の状態を軸の種類で取得します。
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索する軸の種類</param>
        /// <returns>指定種類の軸の状態</returns>
        public float GetAxisState(int joystickIndex, JoystickAxis type)
            => cbg_Joystick_GetAxisStateByType(selfPtr, joystickIndex, (int)type);
    }
}
