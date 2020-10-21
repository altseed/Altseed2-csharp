using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altseed2
{
    internal class NodeTreeWindow
    {
        private class NewNodeButton
        {
            private readonly string _label;
            private readonly Func<Node> _create;

            public NewNodeButton(string label, Func<Node> create)
            {
                _label = label;
                _create = create;
            }

            public void Update()
            {
                if (Engine.Tool.Button(_label))
                {
                    Engine.AddNode(_create());
                }
            }
        }

        private readonly IEditorPropertyAccessor _accessor;

        public NodeTreeWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void UpdateNodeTreeWindow()
        {
            void NodeTree(IEnumerable<Altseed2.Node> nodes)
            {
                foreach (var node in nodes)
                {
                    // 特定のnodeに注目
                    // 

                    Engine.Tool.PushID(node.GetHashCode());

                    var flags = ToolTreeNodeFlags.OpenOnArrow;
                    if (node == _accessor.Selected)
                        flags |= ToolTreeNodeFlags.Selected;
                    if (node.Children.Count == 0)
                        flags |= ToolTreeNodeFlags.Leaf;

                    bool treeNode = Engine.Tool.TreeNodeEx(node.ToString(), flags);
                    if (Engine.Tool.IsItemClicked(0))
                    {
                        _accessor.Selected = node;
                    }

                    if (treeNode)
                    {
                        NodeTree(node.Children);
                        Engine.Tool.TreePop();
                    }
                    Engine.Tool.PopID();
                }
            }

            var size = new Vector2F(300, Engine.WindowSize.Y - _accessor.MenuHeight);
            var pos = new Vector2F(0, _accessor.MenuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

            var buttons = new NewNodeButton[]
            {
                new NewNodeButton("Sprite", () => new SpriteNode()),
                new NewNodeButton("Text", () => new TextNode()),
                new NewNodeButton("Arc", () => new ArcNode{ Radius = 100, StartDegree = 0, EndDegree = 90 }),
                new NewNodeButton("Circle", () => new CircleNode() { Radius = 100 }),
                new NewNodeButton("Line", () => new LineNode() { Point2 = new Vector2F(100, 100) }),
                new NewNodeButton("Rectangle", () => new RectangleNode() { RectangleSize = new Vector2F(100, 100) }),
                new NewNodeButton("Triangle", () => new TriangleNode() { Point2 = new Vector2F(50, 50), Point3 = new Vector2F(100, 0) }), 
            };

            if (Engine.Tool.Begin("Node", flags))
            {
                foreach (var button in buttons.Select((x, i) => (instance: x, index: i)))
                {
                    button.instance.Update();
                    if (button.index < buttons.Length - 1)
                    {
                        Engine.Tool.SameLine();
                    }
                }

                NodeTree(Engine.GetNodes());
                Engine.Tool.End();
            }
        }
    }
}
