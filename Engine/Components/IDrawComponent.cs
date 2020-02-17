using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// 描画コンポーネントを表すインターフェイス
    /// </summary>
    public interface IDrawComponent
    {
        /// <summary>
        /// <see cref="Component"/>としてキャスティングする
        /// </summary>
        /// <returns><see cref="Component"/>としてのインスタンス</returns>
        Component AsComponent();
        /// <summary>
        /// 描画を実行する
        /// </summary>
        void Draw();
    }
}
