using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
