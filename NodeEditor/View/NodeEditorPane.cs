using System;

namespace Altseed2.NodeEditor.View
{
    internal sealed class NodeEditorPane
    {
        private readonly string _name;

        private const ToolWindowFlags UiConfig = ToolWindowFlags.NoMove
            | ToolWindowFlags.NoBringToFrontOnFocus
            | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
            | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

        public NodeEditorPane(string name)
        {
            _name = name;
        }

        public void Render(Vector2F position, Vector2F size, Action onActive)
        {
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(position, ToolCond.None);

            if (Engine.Tool.Begin(_name, UiConfig))
            {
                onActive();
                Engine.Tool.End();
            }
        }
    }
}
