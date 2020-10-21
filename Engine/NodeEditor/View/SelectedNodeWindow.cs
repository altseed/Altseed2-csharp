using System;
using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    internal sealed class SelectedNodeWindow : IDisposable
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly IDisposable _subscription;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Selected");

        private IEnumerable<ToolElement> _selectedToolElements;

        public SelectedNodeWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;

            _subscription = accessor.OnPropertyChanged_Selected_refactor.Subscribe(
                x => _selectedToolElements = ToolElementManager.CreateToolElements(accessor.Selected));
        }

        public void Render()
        {
            var size = new Vector2F(300, Engine.WindowSize.Y - _accessor.MenuHeight);
            var pos = new Vector2F(Engine.WindowSize.X - size.X, _accessor.MenuHeight);

            _pane.Render(pos, size, () =>
            {
                if (_selectedToolElements != null)
                {
                    Engine.Tool.PushID("Selected".GetHashCode());
                    foreach (var toolElement in _selectedToolElements)
                    {
                        Engine.Tool.PushID(toolElement.GetHashCode());
                        toolElement.Update();
                        Engine.Tool.PopID();
                    }
                    Engine.Tool.PopID();
                }
            });
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
