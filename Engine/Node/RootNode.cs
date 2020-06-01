using System.Collections.ObjectModel;

namespace Altseed
{
    internal sealed class RootNode : Node
    {
        internal ReadOnlyCollection<Node> Nodes { get; }

        internal RootNode()
        {
            Nodes = Children;
        }
    }
}
