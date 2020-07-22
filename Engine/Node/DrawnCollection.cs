using System;
using System.Collections.Generic;

namespace Altseed2
{
    internal class DrawnCollection
    {
        private SortedDictionary<int, HashSet<IDrawn>> _Drawns;
        private SortedDictionary<int, SortedDictionary<int, HashSet<IDrawn>>> _Sorted;

        internal DrawnCollection()
        {
            _Drawns = new SortedDictionary<int, HashSet<IDrawn>>();
            _Sorted = new SortedDictionary<int, SortedDictionary<int, HashSet<IDrawn>>>();
            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
                _Sorted[i] = new SortedDictionary<int, HashSet<IDrawn>>();
        }

        internal void Register(IDrawn node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            {
                if (!_Drawns.TryGetValue(-node.ZOrder, out var set))
                    set = _Drawns[-node.ZOrder] = new HashSet<IDrawn>();

                set.Add(node);
            }

            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
            {
                var mask = 1u << i;
                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Sorted[i];

                if (!group.TryGetValue(-node.ZOrder, out var set))
                    set = group[-node.ZOrder] = new HashSet<IDrawn>();

                set.Add(node);
            }
        }

        internal void Unregister(IDrawn node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            _Drawns[-node.ZOrder].Remove(node);

            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
            {
                var mask = 1u << i;
                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Sorted[i];
                group[-node.ZOrder].Remove(node);
            }
        }

        internal void UpdateCameraGroup(IDrawn node, ulong old)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
            {
                var mask = 1u << i;

                if (HasBit(old, mask) && !HasBit(node.CameraGroup, mask))
                {
                    // 削除
                    _Sorted[i][-node.ZOrder].Remove(node);
                }

                if (!HasBit(old, mask) && HasBit(node.CameraGroup, mask))
                {
                    // 追加
                    var group = _Sorted[i];

                    if (!group.TryGetValue(-node.ZOrder, out var set))
                        set = group[-node.ZOrder] = new HashSet<IDrawn>();

                    set.Add(node);
                }
            }
        }

        internal void UpdateZOrder(IDrawn node, int old)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
            {
                var mask = 1u << i;

                if (!HasBit(node.CameraGroup, mask)) continue;

                var group = _Sorted[i];

                group[old].Remove(node);
                group[-node.ZOrder].Add(node);
            }
        }

        internal SortedDictionary<int, HashSet<IDrawn>> GetDrawns() => _Drawns;
        internal SortedDictionary<int, HashSet<IDrawn>> this[int cameraGroup] => _Sorted[cameraGroup];

        private bool HasBit(ulong value, uint mask) => (value & mask) != 0;
    }

    internal class CameraNodeCollection
    {
        private List<CameraNode>[] _Lists;

        internal int Count { get; private set; }

        internal CameraNodeCollection()
        {
            _Lists = new List<CameraNode>[Engine.MaxCameraGroupCount];
            for (int i = 0; i < Engine.MaxCameraGroupCount; i++)
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
