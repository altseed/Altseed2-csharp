using System;
using System.Reactive;

namespace Altseed2.NodeEditor
{
    internal interface IEditorPropertyAccessor
    {
        object Selected { get; set; }
        float MenuHeight { get; }

        IObservable<Unit> OnSelectedNodeChanged { get; }
    }
}
