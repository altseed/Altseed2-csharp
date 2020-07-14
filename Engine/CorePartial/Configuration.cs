using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    public sealed partial class Configuration
    {
        /// <summary>
        /// 変形に関する情報の表示を取得または設定します。
        /// </summary>
        public bool VisibleTransformInfo
        {
            get
            {
                return _VisibleTransformInfo;
            }
            set
            {
                if (_VisibleTransformInfo == value) return;
                _VisibleTransformInfo = value;
            }
        }
        private bool _VisibleTransformInfo　= false;
    }
}
