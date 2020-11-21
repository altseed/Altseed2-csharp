using System;
using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal class NodeTreeWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly NodeTreeViewModel _viewModel;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Node");

        public NodeTreeWindow(IEditorPropertyAccessor accessor, NodeTreeViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;
        }

        public void Render()
        {
            var size = new Vector2F(300, Engine.WindowSize.Y - _accessor.MenuHeight);
            var pos = new Vector2F(0, _accessor.MenuHeight);

            _pane.Render(pos, size, () =>
            {
                RenderButton("Sprite", _viewModel.CreateSpriteNode, true);
                RenderButton("Text", _viewModel.CreateTextNode);
                RenderButton("Arc", _viewModel.CreateArcNode);
                RenderButton("Circle", _viewModel.CreateCircleNode);
                RenderButton("Line", _viewModel.CreateLineNode, true);
                RenderButton("Rectangle", _viewModel.CreateRectangleNode);
                RenderButton("Triangle", _viewModel.CreateTriangleNode);

                RenderNodeTree(Engine.GetNodes());
            });
        }

        private void RenderButton(string label, Action action, bool onNewLine = false)
        {
            if (!onNewLine)
            {
                Engine.Tool.SameLine(0, -1);
            }

            if (Engine.Tool.Button(label))
            {
                action();
            }
        }

        private void RenderNodeTree(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Engine.Tool.PushID(node.GetHashCode());

                bool treeNode = Engine.Tool.TreeNodeEx(node.ToString(), _viewModel.GetNodeStatus(node));

                if (Engine.Tool.IsItemClicked(0))
                {
                    _viewModel.OnNodeSelected(node);
                }

                if (treeNode)
                {
                    RenderNodeTree(node.Children);
                    Engine.Tool.TreePop();
                }

                Engine.Tool.PopID();
            }
        }
    }
}
