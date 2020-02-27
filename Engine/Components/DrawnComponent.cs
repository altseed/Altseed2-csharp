using System;

namespace Altseed
{
    /// <summary>
    /// 描画コンポーネントを表します。
    /// </summary>
    [Serializable]
    public abstract class DrawnComponent : AljectComponent
    {
        /// <summary>
        /// 描画を実行する
        /// </summary>
        internal abstract void Draw();
    }
}
