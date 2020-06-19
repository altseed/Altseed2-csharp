using System.Collections.Generic;

namespace Altseed
{
    internal abstract class RenderedCollection<T>
    {
        protected abstract ulong GetGroup(T o);
        protected abstract int GetOrder(T o);

        internal Dictionary<int, List<T>> Nodes { get; private set; }
        private Dictionary<int, List<T>>[] _Lists;

        internal RenderedCollection()
        {
            Nodes = new Dictionary<int, List<T>>();

            _Lists = new Dictionary<int, List<T>>[Engine.MaxCameraCount + 1];
            for (int i = 0; i < Engine.MaxCameraCount; i++)
                _Lists[i] = new Dictionary<int, List<T>>();
        }

        internal void UpdateCameraGroup(T node, ulong oldCameraGroup)
        {
            var nodeGroup = GetGroup(node);
            var nodeOrder = GetOrder(node);

            for (int i = 0; i < Engine.MaxCameraCount; i++)
            {
                var mask = 1u << i;

                if (HasBit(oldCameraGroup, mask) && !HasBit(nodeGroup, mask))
                {
                    // 削除
                    _Lists[i][nodeOrder].Remove(node);
                }

                if (!HasBit(oldCameraGroup, mask) && HasBit(nodeGroup, mask))
                {
                    // 追加
                    if (!_Lists[i].ContainsKey(nodeOrder))
                        _Lists[i][nodeOrder] = new List<T>();

                    _Lists[i][nodeOrder].Add(node);
                }
            }
        }

        internal void UpdateOrder(T node, int oldZOrder)
        {
            var nodeGroup = GetGroup(node);
            var nodeOrder = GetOrder(node);

            for (int i = 0; i < Engine.MaxCameraCount; i++)
            {
                var mask = 1u << i;
                if (!HasBit(nodeGroup, mask)) continue;

                var group = _Lists[i];

                group[oldZOrder].Remove(node);

                if (!group.ContainsKey(nodeOrder))
                    group[nodeOrder] = new List<T>();

                group[nodeOrder].Add(node);
            }
        }

        internal void AddNode(T node)
        {
            var nodeGroup = GetGroup(node);
            var nodeOrder = GetOrder(node);

            if (!Nodes.ContainsKey(nodeOrder))
                Nodes[nodeOrder] = new List<T>();
            Nodes[nodeOrder].Add(node);

            for (int i = 0; i < Engine.MaxCameraCount; i++)
            {
                var mask = 1u << i;
                if (!HasBit(nodeGroup, mask)) continue;

                var group = _Lists[i];

                if (!group.ContainsKey(nodeOrder))
                    group[nodeOrder] = new List<T>();
                group[nodeOrder].Add(node);
            }
        }

        internal void RemoveNode(T node)
        {
            var nodeGroup = GetGroup(node);
            var nodeOrder = GetOrder(node);

            Nodes[nodeOrder].Remove(node);

            for (int i = 0; i < Engine.MaxCameraCount; i++)
            {
                var mask = 1u << i;
                if (!HasBit(nodeGroup, mask)) continue;

                var group = _Lists[i];
                group[nodeOrder].Remove(node);
            }
        }

        internal Dictionary<int, List<T>> this[int group] => _Lists[group];

        private bool HasBit(ulong value, uint mask) => (value & mask) != 0;
    }

    internal class DrawnNodeCollection : RenderedCollection<DrawnNode>
    {
        protected override ulong GetGroup(DrawnNode o)
        {
            return o.CameraGroup;
        }

        protected override int GetOrder(DrawnNode o)
        {
            return o.ZOrder;
        }
    }

    internal class PostEffectNodeCollection : RenderedCollection<PostEffectNode>
    {
        protected override ulong GetGroup(PostEffectNode o)
        {
            return o.CameraGroup;
        }

        protected override int GetOrder(PostEffectNode o)
        {
            return o.DrawingOrder;
        }
    }

    internal class CameraNodeCollection
    {
        private List<CameraNode>[] _Lists;

        internal int Count { get; private set; }

        internal CameraNodeCollection()
        {
            _Lists = new List<CameraNode>[Engine.MaxCameraCount];
            for (int i = 0; i < Engine.MaxCameraCount; i++)
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
