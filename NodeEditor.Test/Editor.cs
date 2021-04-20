using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using Altseed2.NodeEditor.View;

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
    }
}
