using Altseed2.NodeEditor.Model;

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
            NodeEditorModel.AddNode<SpriteNode>();
        }
        public void CreateTextNode()
        {
            NodeEditorModel.AddNode<TextNode>();
        }
        public void CreateArcNode() 
        {
            NodeEditorModel.AddNode<ArcNode>();
        } 
        public void CreateCircleNode()
        {
            NodeEditorModel.AddNode<CircleNode>();
        }
        public void CreateLineNode()
        {
            NodeEditorModel.AddNode<LineNode>();
        }
        public void CreateRectangleNode() 
        {
            NodeEditorModel.AddNode<RectangleNode>();
        }
        public void CreateTriangleNode() 
        {
            NodeEditorModel.AddNode<TriangleNode>();
        }

        public ToolTreeNodeFlags GetNodeStatus(Node node)
        {
            var flags = new ToolTreeNodeFlags();
            if (node == _accessor.Selected)
            {
                flags |= ToolTreeNodeFlags.Selected;
            } 

            bool hasSelectedChild(Node node)
            {
                if (node == null)
                    return false;

                if (node == _accessor.Selected)
                    return true;

                if (node.Children.Count == 0)
                    return false;

                foreach (var child in node.Children)
                    if(hasSelectedChild(child))
                        return true;

                return false;
            }

            if (hasSelectedChild(_accessor.Selected))
                flags |= ToolTreeNodeFlags.DefaultOpen;
            else
                flags |= ToolTreeNodeFlags.OpenOnArrow;

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
