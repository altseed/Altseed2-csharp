using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using Altseed2.NodeEditor.View;
using Altseed2.NodeEditor.Model;

namespace Altseed2.Test
{
    [TestFixture]
    class EditorTest
    {
        [ToolAuto]
        class TestNode : SpriteNode
        {
            public string Label => "Test OutPut";
            public string Text { get; set; }

            [ToolPath(isDirectory: true)]
            public string Path { get; set; }

            [ToolList(selectedItemPropertyName: "Selected")]
            public List<int> Hoge { get; set; } = new List<int>() { 1, 2, 3 };

            public int Selected { get; set; }

            [ToolGroup]
            public TextNode TextNode { get; set; }

            [ToolButton]
            public void Test()
            {
                Text = "hoge";
                TextNode = new TextNode();
            }
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Basic()
        {
            NodeEditorHost.Initialize("Texture2DExtension", 1500, 800, new Configuration() { ConsoleLoggingEnabled = true, IsResizable = true });

            for (int i = 0; i < 5; i++)
            {
                var sprite = new TestNode();
                sprite.Position = new Vector2F(50 + 75 * i, 400);
                sprite.Texture = Texture2D.Load("../TestData/IO/AltseedPink.png");
                sprite.CenterPosition = (sprite.Texture?.Size.To2F() ?? default) / 2.0f;
                for (int l = 0; l < 3; l++)
                {
                    var text = new TextNode();
                    text.Position = new Vector2F(0, 50 * l);
                    text.Font = Font.LoadDynamicFont("../TestData/Font/mplus-1m-regular.ttf", 64);
                    text.Color = new Color(255, 255, 255);
                    text.Text = "テキスト";
                    text.FontSize = 80;
                    sprite.AddChildNode(text);
                }
                Engine.AddNode(sprite);
                NodeEditorHost.Selected = sprite;
            }


            while (Engine.DoEvents())
            {
                NodeEditorHost.Update();
            }

            NodeEditorHost.Terminate();
        }

        [Test, Apartment (ApartmentState.STA)]
        public void SaveLoad()
        {
            NodeEditorHost.Initialize("SaveLoad", 1500, 800, new Configuration() { ConsoleLoggingEnabled = true, IsResizable = true });

            var spriteID = NodeEditorModel.AddNode<SpriteNode>();
            var textID = NodeEditorModel.AddNode<TextNode>();
            var arcID = NodeEditorModel.AddNode<ArcNode>();
            var circleID = NodeEditorModel.AddNode<CircleNode>();
            var lineID = NodeEditorModel.AddNode<LineNode>();
            var rectID = NodeEditorModel.AddNode<RectangleNode>();
            var triangleID = NodeEditorModel.AddNode<TriangleNode>();

            if (Engine.DoEvents())
                NodeEditorHost.Update();

            var circle = NodeEditorModel.FindInstance(circleID) as CircleNode;
            NodeEditorModel.StartEditFields(circle);
            NodeEditorModel.NotifyEditFields(circle);
            circle.Radius = 100;
            circle.Position = new Vector2F(500, 500);
            circle.Color = new Color(255, 0, 100, 255);
            NodeEditorModel.EndEditFields(circle);
            while (Engine.DoEvents())
                NodeEditorHost.Update();
            NodeEditorModel.Save("TestData/Editor/SaveLoadTest");
            var before = NodeEditorModel.NodeTree;
            NodeEditorHost.Terminate();

            NodeEditorHost.Initialize("SaveLoad", 1500, 800, new Configuration() { ConsoleLoggingEnabled = true, IsResizable = true });
            NodeEditorModel.Load("TestData/Editor/SaveLoadTest.nodes");
            while (Engine.DoEvents())
                NodeEditorHost.Update();
            var after = NodeEditorModel.NodeTree;

            NodeEditorHost.Terminate();
        }
    }
}
