using System;
using System.Collections.Generic;
using Altseed2.GuiTool.Factory;

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
                    View.NodeEditorHost.CommandManager.StartEditFields(NodeEditorHost.NodeTreeGroup, NodeEditorHost.NodeTree, _accessor.Selected , NodeEditorHost.Environment); 
                if (_selectedToolElements != null)
                {
                    Engine.Tool.PushID("Selected".GetHashCode());
                    foreach (var toolElement in _selectedToolElements)
                    {
                        Engine.Tool.PushID(toolElement.GetHashCode());
                        toolElement.Update(_accessor.Selected);
                        Engine.Tool.PopID();
                    }
                    Engine.Tool.PopID();
                        
                }

                if (_accessor.Selected != null)
                    View.NodeEditorHost.CommandManager.EndEditFields(_accessor.Selected, NodeEditorHost.Environment);
            });
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
