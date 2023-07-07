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

        /// <summary>
        /// このノードを描画するかどうかを取得または設定します。
        /// </summary>
        bool IsDrawn { get; set; }

        /// <summary>
        /// 先祖の<see cref="IDrawn.IsDrawn" />を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        bool IsDrawnActually { get; internal set; }
    }

    /// <summary>
    /// カリング対象ノードインターフェース
    /// </summary>
    public interface ICullableDrawn : IDrawn
    {
        internal Rendered Rendered { get; }

        internal int CullingId { get; }

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
            where T : Node, IDrawn
        {
            static void UpdateRecursive(Node n, bool ancestorsIsDawnActually)
            {
                var isDrawnActually = ancestorsIsDawnActually;

                if (n is IDrawn dn)
                {
                    isDrawnActually = dn.IsDrawn && ancestorsIsDawnActually;
                    dn.IsDrawnActually = isDrawnActually;
                }

                foreach (var child in n.Children)
                {
                    UpdateRecursive(child, isDrawnActually);
                }
            }

            var ancestorsIsDrawnActually = node.GetAncestorSpecificNode<IDrawn>()?.IsDrawnActually ?? true;
            UpdateRecursive(node, ancestorsIsDrawnActually);
        }

        internal static void UpdateIsDrawnActuallyFromAncestors<T>(this T node)
            where T : Node, IDrawn
        {
            var ancestorsIsDrawnActually = node.GetAncestorSpecificNode<IDrawn>()?.IsDrawnActually ?? true;
            node.IsDrawnActually = ancestorsIsDrawnActually && node.IsDrawn;
        }
    }
}
