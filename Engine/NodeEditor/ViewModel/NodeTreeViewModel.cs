using System;

namespace Altseed2.NodeEditor.ViewModel
{
    internal enum NodeType
    {
        Sprite, Text, Arc, Circle, Line, Rectangle, Triangle
    }
    
    internal sealed class NodeTreeViewModel
    {
        private readonly IEditorPropertyAccessor _accessor;

        public NodeTreeViewModel(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void CreateNewNode(NodeType type)
        {
            var node = type switch
            {
                NodeType.Sprite => (Node)new SpriteNode(),
                NodeType.Text => new TextNode(),
                NodeType.Arc => new ArcNode { Radius = 100, StartDegree = 0, EndDegree = 90 },
                NodeType.Circle => new CircleNode() { Radius = 100 },
                NodeType.Line => new LineNode() { Point2 = new Vector2F(100, 100) },
                NodeType.Rectangle => new RectangleNode() { RectangleSize = new Vector2F(100, 100) },
                NodeType.Triangle => new TriangleNode() { Point2 = new Vector2F(50, 50), Point3 = new Vector2F(100, 0) },
                _ => throw new Exception(),
            };
            Engine.AddNode(node);
        }

        public ToolTreeNodeFlags GetNodeStatus(Node node)
        {
            var flags = ToolTreeNodeFlags.OpenOnArrow;

            if (node == _accessor.Selected)
                flags |= ToolTreeNodeFlags.Selected;

            if (node.Children.Count == 0)
                flags |= ToolTreeNodeFlags.Leaf;

            return flags;
        }

        public void OnNodeSelected(Node node)
        {
            _accessor.Selected = node;
        }
    }
}
