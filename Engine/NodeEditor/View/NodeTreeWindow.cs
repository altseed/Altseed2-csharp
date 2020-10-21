using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal class NodeTreeWindow
    {
        private static readonly NewNodeButton[] NodeButtonLayout = {
            new NewNodeButton(NodeType.Sprite, true),
            new NewNodeButton(NodeType.Text),
            new NewNodeButton(NodeType.Arc),
            new NewNodeButton(NodeType.Circle),
            new NewNodeButton(NodeType.Line, true),
            new NewNodeButton(NodeType.Rectangle),
            new NewNodeButton(NodeType.Triangle),
        };
        private static readonly ToolWindowFlags NodeTreeWindowConfig =
            ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
            | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
            | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

        private readonly IEditorPropertyAccessor _accessor;
        private readonly NodeTreeViewModel _viewModel;

        public NodeTreeWindow(IEditorPropertyAccessor accessor, NodeTreeViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;
        }

        public void Render()
        {
            // TODO: size, pos, begin, end の呼び出しのセットが頻出するかを確認して、クラスに抽出したい
            var size = new Vector2F(300, Engine.WindowSize.Y - _accessor.MenuHeight);
            var pos = new Vector2F(0, _accessor.MenuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);

            if (Engine.Tool.Begin("Node", NodeTreeWindowConfig))
            {
                foreach (var button in NodeButtonLayout)
                {
                    button.Render(_viewModel);
                }

                RenderNodeTree(Engine.GetNodes());
                Engine.Tool.End();
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

        private sealed class NewNodeButton
        {
            private readonly NodeType _type;
            private readonly bool _onNewLine;

            public NewNodeButton(NodeType type, bool onNewLine = false)
            {
                _type = type;
                _onNewLine = onNewLine;
            }

            public void Render(NodeTreeViewModel model)
            {
                if (!_onNewLine)
                {
                    Engine.Tool.SameLine();
                }

                if (Engine.Tool.Button(_type.ToString()))
                {
                    model.CreateNewNode(_type);
                }
            }
        }
    }
}
