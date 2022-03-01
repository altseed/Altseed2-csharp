using System;
using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal class NodeTreeWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly NodeTreeViewModel _viewModel;
        public NodeTreeViewModel ViewModel { get { return _viewModel; } }
        private readonly NodeEditorPane _pane = new NodeEditorPane("Node");

        public NodeTreeWindow(IEditorPropertyAccessor accessor, NodeTreeViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;
        }

        public void Render()
        {
            _pane.Render(() =>
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

                if (Engine.Tool.IsItemClicked(ToolMouseButton.Left))
                {
                    _viewModel.OnNodeSelected(node);
                }

                if (Engine.Tool.IsItemClicked(ToolMouseButton.Right))
                {
                    Engine.Tool.OpenPopup(menuKey, ToolPopupFlags.None);
                }

                RenderPopupMenu(node);

                if (treeNode)
                {
                    RenderNodeTree(node.Children);
                    Engine.Tool.TreePop();
                }

                Engine.Tool.PopID();
            }
        }

        private void RenderPopupMenu(Node clicked)
        {
            if(Altseed2.Engine.Tool.BeginPopup(menuKey, Altseed2.ToolWindowFlags.None))
            {
                //add node
                if(Altseed2.Engine.Tool.BeginMenu("add child node", true))
                {
                    void render<NodeType>() where NodeType : Node
                    {
                        if (Engine.Tool.MenuItem(typeof(NodeType).Name, "", false, true))
                        {
                            Model.NodeEditorModel.AddNode<NodeType>(clicked);
                            Engine.Tool.CloseCurrentPopup();
                        }
                    }

                    render<SpriteNode>();
                    render<TextNode>();
                    render<ArcNode>();
                    render<CircleNode>();
                    render<LineNode>();
                    render<RectangleNode>();
                    render<TriangleNode>();
                    

                    Engine.Tool.EndMenu();
                }

                //remove
                if (Model.NodeEditorModel.isRemovable(clicked))
                    if(Engine.Tool.MenuItem("remove", "", false, true))
                    {
                        Model.NodeEditorModel.RemoveNode(clicked);
                    }

                Altseed2.Engine.Tool.EndPopup();
            }
        }
        string menuKey = "popupmenu";
    }
}
