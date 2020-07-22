using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class DrawnNode
    {
        [Test, Apartment(ApartmentState.STA)]
        public void SpriteNode()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            //node.Pivot = new Vector2F(0.5f, 0.5f);
            //node.AdjustSize();
            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) node.Position += new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) node.Position -= new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) node.Position += new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) node.Position -= new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Keys.B) == ButtonState.Hold) node.Scale += new Vector2F(0.01f, 0.01f);
                if (Engine.Keyboard.GetKeyState(Keys.S) == ButtonState.Hold) node.Scale -= new Vector2F(0.01f, 0.01f);
                if (Engine.Keyboard.GetKeyState(Keys.R) == ButtonState.Hold) node.Angle += 3;
                if (Engine.Keyboard.GetKeyState(Keys.L) == ButtonState.Hold) node.Angle -= 3;
                if (Engine.Keyboard.GetKeyState(Keys.X) == ButtonState.Hold) node.Src = new RectF(node.Src.X, node.Src.Y, node.Src.Width - 2.0f, node.Src.Height - 2.0f);
                if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Hold) node.Src = new RectF(node.Src.X, node.Src.Y, node.Src.Width + 2.0f, node.Src.Height + 2.0f);
                if (Engine.Keyboard.GetKeyState(Keys.C) == ButtonState.Hold) node.Src = new RectF(node.Src.X - 2.0f, node.Src.Y - 2.0f, node.Src.Width, node.Src.Height);
                if (Engine.Keyboard.GetKeyState(Keys.V) == ButtonState.Hold) node.Src = new RectF(node.Src.X + 2.0f, node.Src.Y + 2.0f, node.Src.Width, node.Src.Height);
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void SpriteNodeWithMaterial()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Pivot = new Vector2F(0.5f, 0.5f);
            node.AdjustSize();

            Engine.AddNode(node);

            var node2 = new SpriteNode();
            node2.Texture = texture;
            node2.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node2.Pivot = new Vector2F(0.5f, 0.5f);
            node2.AdjustSize();
            node2.Angle = 45;
            node2.ZOrder = 1;

            node2.Material = new Material()
            {
                BlendMode = AlphaBlendMode.Multiply,
            };
            var psCode = @"
Texture2D mainTex : register(t0);
SamplerState mainSamp : register(s0);
struct PS_INPUT
{
    float4  Position : SV_POSITION;
    float4  Color    : COLOR0;
    float2  UV1 : UV0;
    float2  UV2 : UV1;
};
float4 main(PS_INPUT input) : SV_TARGET 
{ 
    float4 c;
    c = mainTex.Sample(mainSamp, input.UV1) * input.Color;
    return c;
}";
            node2.Material.SetShader(Shader.Create("ps", psCode, ShaderStageType.Pixel));
            node2.Material.SetTexture("mainTex", texture);
            Engine.AddNode(node2);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TextNode()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            var font2 = Font.LoadDynamicFont("../Core/TestData/Font/GenYoMinJP-Bold.ttf", 100);
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png"));

            Engine.AddNode(new TextNode() { Font = font, Text = "Hello, world! こんにちは" });
            Engine.AddNode(new TextNode() { Font = font, Text = "色を指定します。", Position = new Vector2F(0.0f, 100.0f), Color = new Color(0, 0, 255) });
            Engine.AddNode(new TextNode() { Font = font, Text = "太さを指定します。", Position = new Vector2F(0.0f, 200.0f), Weight = 1.0f });
            Engine.AddNode(new TextNode() { Font = font, Text = "太さを指定します。", Position = new Vector2F(0.0f, 200.0f), Weight = 1.0f });
            Engine.AddNode(new TextNode() { Font = font2, Text = "𠀋 𡈽 𡌛 𡑮 𡢽 𠮟 𡚴 𡸴 𣇄 𣗄 𣜿 𣝣 𣳾", Position = new Vector2F(0.0f, 300.0f) });
            Engine.AddNode(new TextNode() { Font = imageFont, Text = "Altseed〇Altseed", Position = new Vector2F(0.0f, 500.0f) });
            var rotated = new TextNode() { Font = font, Text = "太さを指定します。", Position = new Vector2F(400.0f, 400.0f) };
            Engine.AddNode(rotated);

            tc.LoopBody(c =>
            {
                rotated.Angle += 1.0f;
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TextNode2()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 40);
            var font2 = Font.LoadDynamicFont("../Core/TestData/Font/GenYoMinJP-Bold.ttf", 40);
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png"));

            TextNode node = new TextNode() { Font = font2, Text = "Hello, world! こんにちは カーニングあるよ！！", IsEnableKerning = false, Color = new Color(255, 0, 0, 200) };
            Engine.AddNode(node);
            Engine.AddNode(new TextNode() { Font = font2, Text = "Hello, world! こんにちは カーニングないです", Color = new Color(0, 255, 0, 200) });
            Engine.AddNode(new TextNode() { Font = font, Text = node.Size.ToString(), Position = new Vector2F(0.0f, 50.0f) });
            Engine.AddNode(new TextNode() { Font = font, Text = "字間5です。\n行間標準です。", CharacterSpace = 10, Position = new Vector2F(0.0f, 150.0f) });
            Engine.AddNode(new TextNode() { Font = font, Text = "字間10です。\n行間70です。", CharacterSpace = 50, LineGap = 200, Position = new Vector2F(0.0f, 250.0f) });
            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFont()
        {
            var tc = new TestCore();
            tc.Init();

            Assert.IsTrue(Font.GenerateFontFile("../Core/TestData/Font/mplus-1m-regular.ttf", "test.a2f", 100, "Hello, world! こんにちは"));

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            var font2 = Font.LoadStaticFont("test.a2f");
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png"));

            Engine.AddNode(new TextNode() { Font = font, Text = "Hello, world! こんにちは" });
            Engine.AddNode(new TextNode() { Font = font2, Text = "Hello, world! こんにちは", Position = new Vector2F(0.0f, 100.0f), Color = new Color(0, 0, 255) });

            tc.LoopBody(c => { }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Culling()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 30);
            Assert.NotNull(font);

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var text = new TextNode() { Font = font, Text = "", ZOrder = 10 };
            Engine.AddNode(text);

            var parent = new Altseed2.Node();
            Engine.AddNode(parent);

            tc.LoopBody(c =>
            {
                text.Text = "Drawing Object : " + Engine.CullingSystem.DrawingRenderedCount + " FPS: " + Engine.CurrentFPS.ToString();

                var node = new SpriteNode();
                node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
                node.Texture = texture;
                node.Position = new Vector2F(200, -500);
                parent.AddChildNode(node);

                foreach (var item in parent.Children.OfType<SpriteNode>())
                {
                    item.Position += new Vector2F(0, 10);
                }

            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void MassSpriteNode()
        {
            var tc = new TestCore(new Configuration() { WaitVSync = false });
            tc.Init();

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink256.png");
            Assert.NotNull(texture);

            var ws = Engine.WindowSize;
            var size = 10;
            for (var x = 0; x < ws.X / size; x++)
            {
                for (var y = 0; y < ws.Y / size; y++)
                {
                    var node = new SpriteNode();
                    node.Texture = texture;
                    node.Src = new RectF(new Vector2F(128 * (x % 2), 128 * (y % 2)), new Vector2F(128, 128));
                    node.Scale = new Vector2F(1, 1) * size / 128f;
                    node.Position = new Vector2F(x, y) * size;
                    Engine.AddNode(node);
                }
            }

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void PolygonNode_SetVertexesByVector2F()
        {
            var tc = new TestCore(new Configuration() { WaitVSync = false });
            tc.Init();

            var node = new PolygonNode();
            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var sin = MathF.Sin(MathHelper.DegreeToRadian(c)) * 50;
                var cos = MathF.Cos(MathHelper.DegreeToRadian(c)) * 50;

                node.SetVertexes(new[] {
                    new Vector2F(100 + cos, 100 - sin),
                    new Vector2F(100 - sin, 100 - cos),
                    new Vector2F(100 - cos, 100 + sin),
                    new Vector2F(100 + sin, 100 + cos),
                }, new Color(255, c % 255, 255, 255));
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void PolygonNode()
        {
            var tc = new TestCore();
            tc.Init();

            PolygonNode node = new PolygonNode()
            {
                IsAutoAdjustSize = true,
                Position = new Vector2F(250, 250)
            };
            Engine.AddNode(node);

            node.SetVertexes(new[] {
                new Vector2F(-100 , -100),
                new Vector2F(100, -100),
                new Vector2F(100, 100),
                new Vector2F(-100, 100),
            }, new Color(255, 0, 0));

            tc.LoopBody(c => { }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Pivot()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            var font2 = Font.LoadDynamicFont("../Core/TestData/Font/GenYoMinJP-Bold.ttf", 100);
            Assert.NotNull(font);

            var rotated = new TextNode() { Font = font, Text = "中心で回転します", Position = new Vector2F(300.0f, 300.0f), Pivot = new Vector2F(0.5f, 0.5f) };
            rotated.AdjustSize();
            Engine.AddNode(rotated);

            tc.LoopBody(c =>
            {
                rotated.Angle += 1.0f;
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Anchor()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 30);
            Assert.NotNull(font);

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            Vector2F rectSize = texture.Size;
            var parent = new PolygonNode();
            parent.Position = new Vector2F(320, 240);
            //parent.Pivot = new Vector2F(0.5f, 0.5f);
            parent.SetVertexes(new[] {
                        new Vector2F(0, 0),
                        new Vector2F(rectSize.X, 0),
                        new Vector2F(rectSize.X, rectSize.Y),
                        new Vector2F(0, rectSize.Y),
                    }, new Color(255, 255, 255, 255));
            parent.AdjustSize();
            Engine.AddNode(parent);

            var child = new SpriteNode();
            child.Texture = texture;
            child.Position = new Vector2F(120, 200);
            child.Src = new RectF(new Vector2F(), texture.Size);
            child.Pivot = new Vector2F(0.5f, 0.5f);
            child.AnchorMin = new Vector2F(0.2f, 0.0f);
            child.AnchorMax = new Vector2F(0.8f, 1f);
            child.ZOrder = 10;
            child.Mode = DrawMode.Fill;
            child.AdjustSize();
            parent.AddChildNode(child);

            var childText = new TextNode();
            childText.Font = font;
            childText.Color = new Color(0, 0, 0);
            childText.Text = "あいうえお";
            childText.Pivot = new Vector2F(0.5f, 0.5f);
            childText.AnchorMin = new Vector2F(0.5f, 0.5f);
            childText.AnchorMax = new Vector2F(0.5f, 0.5f);
            childText.ZOrder = 15;
            childText.HorizontalAlignment = HorizontalAlignment.Center;
            childText.VerticalAlignment = VerticalAlignment.Center;
            childText.Size = child.Size;
            child.AddChildNode(childText);

            var text = new TextNode() { Font = font, Text = "", ZOrder = 10 };
            Engine.AddNode(text);

            tc.Duration = 1000;
            tc.LoopBody(c =>
            {
                if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) rectSize.X += 1.5f;
                if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) rectSize.X -= 1.5f;
                if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) rectSize.Y += 1.5f;
                if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) rectSize.Y -= 1.5f;

                if (Engine.Keyboard.GetKeyState(Keys.D) == ButtonState.Hold) parent.Position += new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Keys.A) == ButtonState.Hold) parent.Position += new Vector2F(-1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Keys.S) == ButtonState.Hold) parent.Position += new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Keys.W) == ButtonState.Hold) parent.Position += new Vector2F(0, -1.5f);

                parent.SetVertexes(new[] {
                        new Vector2F(0, 0),
                        new Vector2F(rectSize.X, 0),
                        new Vector2F(rectSize.X, rectSize.Y),
                        new Vector2F(0, rectSize.Y),
                    }, new Color(255, 255, 255, 255));
                parent.AdjustSize();

                text.Text = child.Size.ToString();
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ArcNode()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var arc1 = new ArcNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100, 100),
                Radius = 50f,
                VertNum = 30,
                IsAutoAdjustSize = true,
            };
            var arc2 = new ArcNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400, 200),
                Radius = 30f,
                VertNum = 8,
                IsAutoAdjustSize = true,
            };
            var arc3 = new ArcNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(50, 400),
                Radius = 40f,
                VertNum = 5,
                IsAutoAdjustSize = true,
            };
            Engine.AddNode(arc1);
            Engine.AddNode(arc2);
            Engine.AddNode(arc3);

            tc.LoopBody(x =>
            {
                arc1.StartDegree++;
                arc2.StartDegree++;
                arc3.StartDegree++;
                arc1.EndDegree--;
                arc2.EndDegree--;
                arc3.EndDegree--;
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void CircleNode()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var circle1 = new CircleNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100, 100),
                Radius = 50f,
                VertNum = 30,
                IsAutoAdjustSize = true,
            };
            var circle2 = new CircleNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400, 200),
                Radius = 30f,
                VertNum = 8,
                IsAutoAdjustSize = true,
            };
            var circle3 = new CircleNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(50, 400),
                Radius = 40f,
                VertNum = 5,
                IsAutoAdjustSize = true,
            };
            Engine.AddNode(circle1);
            Engine.AddNode(circle2);
            Engine.AddNode(circle3);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void LineNode()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var line1 = new LineNode()
            {
                Color = new Color(255, 0, 0),
                Point1 = new Vector2F(100f, 100f),
                Point2 = new Vector2F(200f, 200f),
                Thickness = 10f,
                IsAutoAdjustSize = true
            };
            var line2 = new LineNode()
            {
                Color = new Color(0, 255, 0),
                Point1 = new Vector2F(50f, 450f),
                Point2 = new Vector2F(600f, 50f),
                Thickness = 5.0f,
                IsAutoAdjustSize = true,
            };
            var line3 = new LineNode()
            {
                Color = new Color(0, 0, 255),
                Point1 = new Vector2F(100f, 150f),
                Point2 = new Vector2F(100f, 350f),
                Thickness = 15.0f,
                IsAutoAdjustSize = true
            };
            Engine.AddNode(line1);
            Engine.AddNode(line2);
            Engine.AddNode(line3);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RectangleNode()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var rectangle1 = new RectangleNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100f, 100f),
                Pivot = new Vector2F(0.5f, 0.5f),
                RectangleSize = new Vector2F(50f, 50f),
                IsAutoAdjustSize = true,
            };
            var rectangle2 = new RectangleNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400f, 200f),
                RectangleSize = new Vector2F(200f, 100f),
                IsAutoAdjustSize = true,
            };
            var rectangle3 = new RectangleNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(200f, 300f),
                RectangleSize = new Vector2F(100f, 150f),
                IsAutoAdjustSize = true,
            };
            Engine.AddNode(rectangle1);
            Engine.AddNode(rectangle2);
            Engine.AddNode(rectangle3);

            tc.LoopBody((c) =>
            {
                rectangle1.RectangleSize += new Vector2F(1, 1);
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TriangleNode()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var triangle = new TriangleNode()
            {
                Color = new Color(255, 0, 0),
                Point1 = new Vector2F(100f, 100f),
                Point2 = new Vector2F(200f, 200f),
                Point3 = new Vector2F(100f, 200f),
                Position = new Vector2F(100, 100),
                Pivot = new Vector2F(0.5f, 0.1f),
                IsAutoAdjustSize = true,
            };
            Engine.AddNode(triangle);

            tc.LoopBody((c) =>
            {
                triangle.Point2 += new Vector2F(1, 1);
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void LineNodeAndCulling()
        {
            var tc = new TestCore();
            tc.Init();

            var line1 = new LineNode()
            {
                Color = new Color(255, 0, 0),
                Point1 = new Vector2F(2000f, 0f),
                Point2 = new Vector2F(2000f, 1000f),
                Thickness = 10f,
                IsAutoAdjustSize = true,
            };

            Engine.AddNode(line1);

            tc.LoopBody(c =>
            {
                if (c == 3)
                {
                    line1.Point1 = new Vector2F(100f, 0f);
                    line1.Point2 = new Vector2F(100f, 1000f);
                }
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void IsDrawn()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.Pivot = new Vector2F(0.5f, 0.5f);
            node.Position = new Vector2F(100, 100);
            node.AdjustSize();
            Engine.AddNode(node);

            var node2 = new SpriteNode();
            var node3 = new SpriteNode();

            tc.LoopBody(c =>
            {
                node2.Texture = texture;
                node2.Pivot = new Vector2F(0.5f, 0.5f);
                node2.Position = new Vector2F(200, 200);
                node2.AdjustSize();

                node3.Texture = texture;
                node3.Pivot = new Vector2F(0.5f, 0.5f);
                node3.Position = new Vector2F(300, 300);
                node3.AdjustSize();

                if (c == 2)
                {
                    node.AddChildNode(node2);
                }

                if (c == 4)
                {
                    node.IsDrawn = false;
                    Assert.IsFalse(node.IsDrawnActually);
                    Assert.IsFalse(node2.IsDrawnActually);
                }

                if (c == 6)
                {
                    node2.AddChildNode(node3);
                }

                if (c == 8)
                {
                    node.IsDrawn = true;

                    Assert.IsTrue(node.IsDrawnActually);
                    Assert.IsTrue(node2.IsDrawnActually);
                    Assert.IsTrue(node3.IsDrawnActually);
                }

                if (c == 10)
                {
                    node2.IsDrawn = false;

                    Assert.IsTrue(node.IsDrawnActually);
                    Assert.IsFalse(node2.IsDrawnActually);
                    Assert.IsFalse(node3.IsDrawnActually);
                }
            }, null);

            tc.End();
        }
    }
}
