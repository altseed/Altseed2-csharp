using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 描画ノードインターフェース
    /// </summary>
    public interface IDrawn
    {
        internal void Draw();

        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        ulong CameraGroup { get; set; }

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        int ZOrder { get; }
    }

    /// <summary>
    /// カリング対象ノードインターフェース
    /// </summary>
    public interface ICullableDrawn : IDrawn
    {
        internal Rendered Rendered { get; }

        internal int CullingId { get; }

        /// <summary>
        /// このノードを描画するかどうかを取得または設定します。
        /// </summary>
        bool IsDrawn { get; }

        /// <summary>
        /// 先祖の<see cref="IsDrawn" />を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        bool IsDrawnActually { get; internal set; }

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        Vector2F ContentSize { get; }
    }

    internal static class DrawnExtension
    {
        /// <summary>
        /// 自身と子孫ノードの IsDrawnActually プロパティを更新します。
        /// </summary>
        internal static void UpdateIsDrawnActuallyOfDescendants<T>(this T node)
            where T : Node, ICullableDrawn
        {
            node.IsDrawnActually = node.IsDrawn && (node.GetAncestorSpecificNode<T>()?.IsDrawnActually ?? true);

            foreach (var child in node.Children)
            {
                if (child is T d)
                    d.UpdateIsDrawnActuallyOfDescendants();
            }
        }
    }
}
