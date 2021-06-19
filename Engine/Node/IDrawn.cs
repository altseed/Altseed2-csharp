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
        int ZOrder { get; set; }
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
        bool IsDrawn { get; set; }

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
        internal static void UpdateIsDrawnActuallyOfDescendants(this Node node)
        {
            static void UpdateRecursive(Node n, bool ancestorsIsDawnActually)
            {
                var dn = (ICullableDrawn)n;

                var isDrawnActually = dn.IsDrawn && ancestorsIsDawnActually;
                dn.IsDrawnActually = isDrawnActually;
                foreach (var child in n.Children)
                {
                    if (child is ICullableDrawn)
                    {
                        UpdateRecursive(child, isDrawnActually);
                    }
                }
            }

            if (node is ICullableDrawn)
            {
                var ancestorsIsDrawnActually = node.GetAncestorSpecificNode<ICullableDrawn>()?.IsDrawnActually ?? true;
                UpdateRecursive(node, ancestorsIsDrawnActually);
            }
        }
    }
}
