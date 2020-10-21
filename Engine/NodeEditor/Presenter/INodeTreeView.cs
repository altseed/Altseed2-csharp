using System;

namespace Altseed2.NodeEditor.Presenter
{
    internal interface INodeTreeView
    {
        IObservable<NodeType> OnCommitNewNode { get; }
    }
}
