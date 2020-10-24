namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class NodeTreeViewModel
    {
        private readonly IEditorPropertyAccessor _accessor;

        public NodeTreeViewModel(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void CreateSpriteNode() => Engine.AddNode(new SpriteNode());
        public void CreateTextNode() => Engine.AddNode(new TextNode());
        public void CreateArcNode() => Engine.AddNode(new ArcNode
        {
            Radius = 100, StartDegree = 0, EndDegree = 90
        });
        public void CreateCircleNode() => Engine.AddNode(new CircleNode
        {
            Radius = 100
        });
        public void CreateLineNode() => Engine.AddNode(new LineNode
        {
            Point2 = new Vector2F(100, 100)
        });
        public void CreateRectangleNode() => Engine.AddNode(new RectangleNode
        {
            RectangleSize = new Vector2F(100, 100)
        });
        public void CreateTriangleNode() => Engine.AddNode(new TriangleNode
        {
            Point2 = new Vector2F(50, 50), Point3 = new Vector2F(100, 0)
        });

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
