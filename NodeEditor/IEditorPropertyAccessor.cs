using System;
using System.Reactive;

namespace Altseed2.NodeEditor
{
    internal interface IEditorPropertyAccessor
    {
        object Selected { get; set; }
        float MenuHeight { get; }

        Vector2F EditorWindowPosition { get; }

        IObservable<Unit> OnSelectedNodeChanged { get; }
    }
}
