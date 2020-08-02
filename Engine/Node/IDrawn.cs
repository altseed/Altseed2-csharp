using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    internal interface IDrawn
    {
        internal void Draw();

        ulong CameraGroup { get; set; }

        int ZOrder { get; }
    }

    internal interface ICullableDrawn : IDrawn
    {
        internal int CullingId { get; }

        bool IsDrawn { get; }

        bool IsDrawnActually { get; internal set; }
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
