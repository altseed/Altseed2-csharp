using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// コンポーネントのクラス
    /// </summary>
    public abstract class Component
    {
        internal ObjectStatus Status { get; set; }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected Component()
        {
            Status = ObjectStatus.Free;
        }
    }
}
