using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// 描画コンポーネントを表します。
    /// </summary>
    public abstract class DrawnComponent : AljectComponent
    {
        /// <summary>
        /// 描画を実行する
        /// </summary>
        internal abstract void Draw();
    }
}
