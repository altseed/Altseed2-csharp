using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal class NodeTreeWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly NodeTreeViewModel _viewModel;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Node");

        private List<Type> _userDefinedNodes = new();

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

                RenderUserDefinedNodeCreateButtons(_userDefinedNodes);

                RenderButton("+", OpenDLL);
                RenderNodeTree(Engine.GetNodes());
            });
        }

        private void OpenDLL()
        {
            if (Engine.Tool.OpenDialog("dll", "") is { } path)
            {
                _userDefinedNodes = LoadDLL(path);
            }
        }

        public List<Type> LoadDLL(string path)
        {
            List<Type> nodes = new();

            var asm = Assembly.LoadFrom(path);
            var typeinfo = asm.GetTypes();

            foreach (var type in typeinfo)
            {
                if (type.IsSubclassOf(typeof(Node)))
                {
                    nodes.Add(type);
                }
            }

            return nodes;
        }

        private void RenderUserDefinedNodeCreateButtons(List<Type> types)
        {
            foreach (var type in types)
            {
                RenderButton(type.Name, () => { CreateUserDefinedNode(type); });
            }
        }

        private void CreateUserDefinedNode(Type type)
        {
            dynamic node = Activator.CreateInstance(type);
            Engine.AddNode(node);
        }

        private void RenderButton(string label, Action action, bool onNewLine = true)
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
