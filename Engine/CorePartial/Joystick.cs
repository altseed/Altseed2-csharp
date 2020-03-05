using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public partial class Joystick
    {
        /// <summary>
        /// ジョイスティックの最大同時接続数を取得します。
        /// </summary>
        public int MaxCount { get; } = 16;
    }
}
