namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class NodeTreeViewModel
    {
        private readonly IEditorPropertyAccessor _accessor;

        public NodeTreeViewModel(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public void CreateSpriteNode() 
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup, 
                View.NodeEditorHost.NodeTree, 
                EngineNode.GetInstance().InstanceID, 
                typeof(SpriteNode), 
                View.NodeEditorHost.Environment);
        }
        public void CreateTextNode() => 
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(TextNode),
                View.NodeEditorHost.Environment);
        public void CreateArcNode() 
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(ArcNode),
                View.NodeEditorHost.Environment);

            //ToDo
            //ここで初期値を設定できるようにしたい
        } 
        public void CreateCircleNode() => EngineNode.GetInstance().AddChild(new CircleNode
        {
            Radius = 100
        });
        public void CreateLineNode() => EngineNode.GetInstance().AddChild(new LineNode
        {
            Point2 = new Vector2F(100, 100)
        });
        public void CreateRectangleNode() => EngineNode.GetInstance().AddChild(new RectangleNode
        {
            RectangleSize = new Vector2F(100, 100)
        });
        public void CreateTriangleNode() => EngineNode.GetInstance().AddChild(new TriangleNode
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
