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
        /// <summary>
        /// 要素が<paramref name="owner"/>に登録されたとき実行します。
        /// </summary>
        internal abstract void Added(TOwner owner);

        /// <summary>
        /// 要素が親要素から削除されたときに実行します。
        /// </summary>
        internal abstract void Removed();

        /// <summary>
        /// 登録状況を取得します。
        /// </summary>
        public RegisterStatus Status { get; internal set; } = RegisterStatus.Free;
    }
}
