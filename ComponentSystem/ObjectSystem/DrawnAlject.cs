using System;

namespace Altseed.ComponentSystem
{
    /// <summary>
    /// 描画を実行する<see cref="Alject"/>のクラス
    /// </summary>
    [Serializable]
    public abstract class DrawnAlject : Alject
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
        protected DrawnAlject() { }
    }
}
