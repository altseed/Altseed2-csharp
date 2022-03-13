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
            var newnodeid = NodeEditorModel.AddNode<SpriteNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateTextNode()
        {
            var newnodeid = NodeEditorModel.AddNode<TextNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateArcNode()
        {
            var newnodeid = NodeEditorModel.AddNode<ArcNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateCircleNode()
        {
            var newnodeid = NodeEditorModel.AddNode<CircleNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateLineNode()
        {
            var newnodeid = NodeEditorModel.AddNode<LineNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateRectangleNode()
        {
            var newnodeid = NodeEditorModel.AddNode<RectangleNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
        }
        public void CreateTriangleNode()
        {
            var newnodeid = NodeEditorModel.AddNode<TriangleNode>();
            _accessor.Selected = NodeEditorModel.FindInstance(newnodeid);
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
                    if (hasSelectedChild(child))
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
