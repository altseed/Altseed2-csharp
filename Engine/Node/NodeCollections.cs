using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    internal class DrawnNodeCollection
    {
        internal Dictionary<int, List<DrawnNode>> Nodes { get; private set; }
        private Dictionary<int, List<DrawnNode>>[] _Lists;

        internal DrawnNodeCollection()
        {
            Nodes = new Dictionary<int, List<DrawnNode>>();

            _Lists = new Dictionary<int, List<DrawnNode>>[33];
            for (int i = 0; i <= 31; i++)
                _Lists[i] = new Dictionary<int, List<DrawnNode>>();
        }

        internal void UpdateCameraGroup(DrawnNode node, uint oldCameraGroup)
        {
            for (int i = 0; i <= 31; i++)
            {
                var mask = 1u << i;

                if (HasBit(oldCameraGroup, mask) && !HasBit(node.CameraGroup, mask))
                {
                    // 削除
                    _Lists[i][node.ZOrder].Remove(node);
                }

                if (!HasBit(oldCameraGroup, mask) && HasBit(node.CameraGroup, mask))
                {
                    // 追加
                    if (!_Lists[i].ContainsKey(node.ZOrder))
                        _Lists[i][node.ZOrder] = new List<DrawnNode>();

                    _Lists[i][node.ZOrder].Add(node);
                }
            }
        }

        internal void UpdateZOrder(DrawnNode node, int oldZOrder)
        {
            for (int i = 0; i <= 31; i++)
            {
                var mask = 1u << i;
                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Lists[i];

                group[oldZOrder].Remove(node);

                if (!group.ContainsKey(node.ZOrder))
                    group[node.ZOrder] = new List<DrawnNode>();

                group[node.ZOrder].Add(node);
            }
        }

        internal void AddNode(DrawnNode node)
        {
            if (!Nodes.ContainsKey(node.ZOrder))
                Nodes[node.ZOrder] = new List<DrawnNode>();
            Nodes[node.ZOrder].Add(node);

            for (int i = 0; i <= 31; i++)
            {
                var mask = 1u << i;
                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Lists[i];

                if (!group.ContainsKey(node.ZOrder))
                    group[node.ZOrder] = new List<DrawnNode>();
                group[node.ZOrder].Add(node);
            }
        }

        internal void RemoveNode(DrawnNode node)
        {
            Nodes[node.ZOrder].Remove(node);

            for (int i = 0; i <= 31; i++)
            {
                var mask = 1u << i;
                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Lists[i];
                group[node.ZOrder].Remove(node);
            }
        }

        internal Dictionary<int, List<DrawnNode>> this[int group] => _Lists[group];

        private bool HasBit(uint value, uint mask) => (value & mask) != 0;
    }

    internal class CameraNodeCollection
    {
        private List<CameraNode>[] _Lists;

        internal int Count { get; private set; }

        internal CameraNodeCollection()
        {
            _Lists = new List<CameraNode>[32];
            for (int i = 0; i <= 31; i++)
                _Lists[i] = new List<CameraNode>();

        }

        internal void AddCamera(CameraNode node)
        {
            _Lists[node.Group].Add(node);
            Count++;
        }

        internal void RemoveCamera(CameraNode node)
        {
            _Lists[node.Group].Remove(node);
            Count--;
        }

        internal void UpdateGroup(CameraNode node, int oldGroup)
        {
            _Lists[oldGroup].Remove(node);
            _Lists[node.Group].Add(node);
        }

        internal List<CameraNode> this[int index] => _Lists[index];
    }
}
