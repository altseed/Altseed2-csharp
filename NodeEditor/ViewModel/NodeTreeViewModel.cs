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
        public void CreateTextNode()
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(TextNode),
                View.NodeEditorHost.Environment);
        }
        public void CreateArcNode() 
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(ArcNode),
                View.NodeEditorHost.Environment);
        } 
        public void CreateCircleNode()
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(CircleNode),
                View.NodeEditorHost.Environment);
        }
        public void CreateLineNode()
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(LineNode),
                View.NodeEditorHost.Environment);
        }
        public void CreateRectangleNode() 
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(RectangleNode),
                View.NodeEditorHost.Environment);
        }
        public void CreateTriangleNode() 
        {
            View.NodeEditorHost.CommandManager.AddNode(
                View.NodeEditorHost.NodeTreeGroup,
                View.NodeEditorHost.NodeTree,
                EngineNode.GetInstance().InstanceID,
                typeof(TriangleNode),
                View.NodeEditorHost.Environment);
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
