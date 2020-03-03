using System;

namespace Altseed.ComponentSystem
{
    /// <summary>
    /// 描画コンポーネントを表します。
    /// </summary>
    [Serializable]
    public abstract class DrawnComponent : AljectComponent
    {
        /// <summary>
        /// 角度を取得または設定する
        /// </summary>
        public abstract float Angle { get; set; }

        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public abstract Vector2F Position { get; set; }

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public abstract Vector2F Scale { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected DrawnComponent() { }

        /// <summary>
        /// 描画を実行する
        /// </summary>
        internal abstract void Draw();


    }
}
