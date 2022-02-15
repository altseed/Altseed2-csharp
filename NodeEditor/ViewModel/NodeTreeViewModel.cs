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
            CreateNode<SpriteNode>();
        }
        public void CreateTextNode()
        {
            CreateNode<TextNode>();
        }
        public void CreateArcNode() 
        {
            CreateNode<ArcNode>();
        } 
        public void CreateCircleNode()
        {
            CreateNode<CircleNode>();
        }
        public void CreateLineNode()
        {
            CreateNode<LineNode>();
        }
        public void CreateRectangleNode() 
        {
            CreateNode<RectangleNode>();
        }
        public void CreateTriangleNode() 
        {
            CreateNode<TriangleNode>();
        }

        public int CreateNode<NodeType>() where NodeType : Node
        {
            return View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(NodeType),
                View.NodeEditorHost.Environment
            );
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
