using System;
using System.Collections.Generic;
using Altseed2.GuiTool.Factory;
using Altseed2.NodeEditor.Model;

namespace Altseed2.NodeEditor.View
{
    internal sealed class SelectedNodeWindow : IDisposable
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly IDisposable _subscription;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Selected");

        private IEnumerable<ToolElement> _selectedToolElements;

        public SelectedNodeWindow(IEditorPropertyAccessor accessor, IToolElementTreeFactory toolElementTreeFactory)
        {
            _accessor = accessor;

            _subscription = accessor.OnSelectedNodeChanged.Subscribe(
                x => _selectedToolElements = toolElementTreeFactory.CreateToolElements(accessor.Selected));
        }

        public void Render()
        {
            _pane.Render(() =>
            {
                if(_accessor.Selected != null)
                    NodeEditorModel.StartEditFields(_accessor.Selected);
                if (_selectedToolElements != null)
                {
                    Engine.Tool.PushID("Selected".GetHashCode());
#if DEBUG
                    Engine.Tool.Text(_accessor.Selected.InstanceID.ToString());
#endif
                    foreach (var toolElement in _selectedToolElements)
                    {
                        Engine.Tool.PushID(toolElement.GetHashCode());
                        toolElement.Update(_accessor.Selected);
                        Engine.Tool.PopID();
                    }
                    Engine.Tool.PopID();
                        
                }

                if (_accessor.Selected != null)
                    NodeEditorModel.EndEditFields(_accessor.Selected);
            });
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
