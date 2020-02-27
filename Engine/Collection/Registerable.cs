using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// <see cref="RegisterableCollection{TElement, TOwner}"/>に登録や削除が可能な要素であることを表します。
    /// </summary>
    [Serializable]
    public abstract class Registerable<TOwner>
    {
        internal abstract void Added(TOwner owner);

        internal abstract void Removed();

        /// <summary>
        /// 登録状況を取得します。
        /// </summary>
        public RegisterStatus Status { get; internal set; } = RegisterStatus.Free;
    }
}
