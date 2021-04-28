using System;

namespace Altseed2.NodeEditor.View
{
    internal sealed class NodeEditorPane
    {
        private readonly string _name;

        private const ToolWindowFlags UiConfig = ToolWindowFlags.None;

        public NodeEditorPane(string name)
        {
            _name = name;
        }

        public void Render(Action onActive, ToolWindowFlags flags = UiConfig)
        {
            if (Engine.Tool.Begin(_name, flags))
            {
                onActive();
            }
            Engine.Tool.End();
        }
    }
}
