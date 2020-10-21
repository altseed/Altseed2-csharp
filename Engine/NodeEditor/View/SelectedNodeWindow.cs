using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2.NodeEditor.View
{
    internal sealed class SelectedNodeWindow : IDisposable
    {
        private readonly IEditorPropertyAccessor _accessor;
        private IEnumerable<ToolElement> _selectedToolElements;
        private IDisposable _subscription;

        public SelectedNodeWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;

            _subscription = accessor.OnPropertyChanged_Selected_refactor.Subscribe(
                x => _selectedToolElements = ToolElementManager.CreateToolElements(accessor.Selected));
        }

        public void UpdateSelectedWindow()
        {
            var menuHeight = _accessor.MenuHeight;

            var size = new Vector2F(300, Engine.WindowSize.Y - menuHeight);
            var pos = new Vector2F(Engine.WindowSize.X - size.X, menuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

            if (Engine.Tool.Begin("Selected", flags))
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
                Engine.Tool.End();
            }
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
