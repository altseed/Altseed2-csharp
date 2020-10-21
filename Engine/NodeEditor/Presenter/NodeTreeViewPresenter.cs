using System;

namespace Altseed2.NodeEditor.Presenter
{
    internal enum NodeType
    {
        Sprite, Text, Arc, Circle, Line, Rectangle, Triangle
    }
    
    // このクラスに対してメソッドを呼び出したい場面が不明なので、ひょっとすると不要なクラスかもしれない
    internal class NodeTreeViewPresenter
    {
        public NodeTreeViewPresenter(INodeTreeView view)
        {
            view.OnCommitNewNode.Subscribe(CreateNewNode);
        }

        private void CreateNewNode(NodeType type)
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
    }
}
