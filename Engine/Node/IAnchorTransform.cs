using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// アンカーによって変形するノードのインターフェース
    /// </summary>
    public interface IAnchorTransform
    {
        /// <summary>
        /// 角度(度数法)を取得または設定します。
        /// </summary>
        float Angle { get; set; }

        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        Vector2F Position { get; set; }

        /// <summary>
        /// 中心となる座標を[0, 1]で取得または設定します。
        /// </summary>
        Vector2F Pivot { get; set; }

        /// <summary>
        /// 拡大率を取得または設定します。
        /// </summary>
        Vector2F Scale { get; set; }

        /// <summary>
        /// 左右を反転するかどうかを取得または設定します。
        /// </summary>
        bool HorizontalFlip { get; set; }

        /// <summary>
        /// 上下を反転するかどうかを取得または設定します。
        /// </summary>
        bool VerticalFlip { get; set; }

        /// <summary>
        /// レイアウト自動計算の方法を指定します。
        /// </summary>
        AnchorMode AnchorMode { get; set; }

        /// <summary>
        /// 描画サイズを取得または設定します。
        /// </summary>
        Vector2F Size { get; set; }

        /// <summary>
        /// <see cref="Size" />の左上から親ノードの<see cref="Size" />の左上までの距離
        /// </summary>
        Vector2F LeftTop { get; set; }

        /// <summary>
        /// <see cref="Size" />の右下から親ノードの<see cref="Size" />の右下までの距離
        /// </summary>
        Vector2F RightBottom { get; set; }

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        Vector2F AnchorMin { get; set; }

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        Vector2F AnchorMax { get; set; }
    }

    internal interface IAnchorTransformInternal : IAnchorTransform
    {
        internal void SetPositionDirectly(Vector2F position);
        internal void SetSizeDirectly(Vector2F size);
    }
}
