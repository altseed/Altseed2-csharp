using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    class Tool
    {
        [Test, Apartment(ApartmentState.STA)]
        public void BeginEnd()
        {
            var tc = new TestCore(new Configuration { ToolEnabled = true });
            tc.Init();

            tc.LoopBody(c =>
            {
                if (Engine.Tool.Begin("Test", ToolWindow.None))
                {
                    Engine.Tool.End();
                }
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Input()
        {
            var tc = new TestCore(new Configuration { ToolEnabled = true });
            tc.Init();
            Engine.Tool.AddFontFromFileTTF("../../Core/TestData/Font/mplus-1m-regular.ttf", 20, ToolGlyphRanges.Japanese);
            string str0 = "";
            string str1 = "";
            string str2 = "";
            int[] intArray = new int[] { 0, 1, 2, 3, 4 };
            float[] floatArray = new float[] { 0, 1, 2, 3, 4 };
            tc.Duration = 10000;
            tc.LoopBody(c =>
            {
                if (Engine.Tool.Begin("Test", ToolWindow.None))
                {
                    var tmp = Engine.Tool.InputText("InputText", str0, 1024, ToolInputText.None);
                    if (tmp != null) str0 = tmp;

                    tmp = Engine.Tool.InputTextMultiline("InputTextMultiline", str1, 1024, new Vector2F(), ToolInputText.None);
                    if (tmp != null) str1 = tmp;

                    tmp = Engine.Tool.InputTextWithHint("InputTextWithHint", "hint", str2, 1024, ToolInputText.None);
                    if (tmp != null) str2 = tmp;

                    Engine.Tool.InputInt2("InputInt2", intArray);
                    Engine.Tool.InputInt4("InputInt4", intArray);
                    Engine.Tool.InputFloat3("InputFloat3", floatArray);
                    Engine.Tool.InputFloat2("InputFloat2", floatArray);

                    Engine.Tool.SliderInt2("SliderInt2", intArray, 0.1f, 0, 100);
                    Engine.Tool.SliderInt4("SliderInt4", intArray, 0.1f, 0, 100);
                    Engine.Tool.SliderFloat3("SliderFloat3", floatArray, 0.1f, 0, 100);
                    Engine.Tool.SliderFloat2("SliderFloat2", floatArray, 0.1f, 0, 100);

                    Engine.Tool.End();
                }
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Color()
        {
            var tc = new TestCore(new Configuration { ToolEnabled = true });
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            Engine.AddNode(node);

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            var text = new TextNode() { Font = font, Text = "色テスト", Position = new Vector2F(0.0f, 0.0f) };
            Engine.AddNode(text);

            Color col1 = new Color(10, 20, 50, 100);
            Color col2 = new Color(10, 20, 50, 100);
            tc.LoopBody(c =>
            {
                if (Engine.Tool.Begin("Test", ToolWindow.None))
                {
                    Engine.Tool.ColorEdit3("Color1", ref col1, ToolColorEdit.None);  // RGB
                    Engine.Tool.ColorEdit4("Color2", ref col2, ToolColorEdit.None);  // RGBAのアルファ付き

                    var flag = ToolColorEdit.Float | ToolColorEdit.NoInputs | ToolColorEdit.NoLabel;

                    Engine.Tool.ColorEdit3("Color ID", ref col1, flag);
                    Engine.Tool.End();
                }

                text.Color = col1;
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ListBox()
        {
            var tc = new TestCore(new Configuration { ToolEnabled = true });
            tc.Init();

            int current = 1;
            tc.LoopBody(c =>
            {
                if (Engine.Tool.Begin("Test", ToolWindow.None))
                {
                    List<string> items = new List<string>() { "Apple", "Banana", "Cherry", "Kiwi", "Mango", "Orange", "Pineapple", "Strawberry", "Watermelon" };

                    Engine.Tool.ListBox("ListBox", ref current, items, 3);
                    Engine.Tool.Combo("Combo", ref current, items, 3);

                    Engine.Tool.End();
                }
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void OpenDialog()
        {
            var tc = new TestCore(new Configuration { ToolEnabled = true });
            tc.Init();

            Engine.Tool.OpenDialog("png;jpg,jpeg", "");

            tc.End();
        }
    }
}
