using System;
using System.Collections.ObjectModel;

namespace Altseed
{
    [Serializable]
    internal sealed class RootNode : Node
    {
        internal ReadOnlyCollection<Node> Nodes { get; }

        internal RootNode()
        {
            Nodes = Children;
        }
    }
}
