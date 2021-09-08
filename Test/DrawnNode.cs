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

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            //node.Pivot = new Vector2F(0.5f, 0.5f);
            //node.AdjustSize();
            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) node.Position += new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) node.Position -= new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) node.Position += new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) node.Position -= new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Key.B) == ButtonState.Hold) node.Scale += new Vector2F(0.01f, 0.01f);
                if (Engine.Keyboard.GetKeyState(Key.S) == ButtonState.Hold) node.Scale -= new Vector2F(0.01f, 0.01f);
                if (Engine.Keyboard.GetKeyState(Key.R) == ButtonState.Hold) node.Angle += 3;
                if (Engine.Keyboard.GetKeyState(Key.L) == ButtonState.Hold) node.Angle -= 3;
                if (Engine.Keyboard.GetKeyState(Key.X) == ButtonState.Hold) node.Src = new RectF(node.Src.X, node.Src.Y, node.Src.Width - 2.0f, node.Src.Height - 2.0f);
                if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Hold) node.Src = new RectF(node.Src.X, node.Src.Y, node.Src.Width + 2.0f, node.Src.Height + 2.0f);
                if (Engine.Keyboard.GetKeyState(Key.C) == ButtonState.Hold) node.Src = new RectF(node.Src.X - 2.0f, node.Src.Y - 2.0f, node.Src.Width, node.Src.Height);
                if (Engine.Keyboard.GetKeyState(Key.V) == ButtonState.Hold) node.Src = new RectF(node.Src.X + 2.0f, node.Src.Y + 2.0f, node.Src.Width, node.Src.Height);
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void SpriteNodeWithMaterial()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.CenterPosition = new Vector2F(100, 100);
            Engine.AddNode(node);

            var node2 = new SpriteNode();
            node2.Texture = texture;
            node2.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node2.CenterPosition = new Vector2F(100, 100);
            node2.Angle = 45;
            node2.ZOrder = 1;

            node2.Material = Material.Create();
            node2.Material.AlphaBlend = AlphaBlend.Multiply;

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
            node2.Material.SetShader(Shader.Create("ps", psCode, ShaderStage.Pixel));
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

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            var font2 = Font.LoadDynamicFont("TestData/Font/GenYoMinJP-Bold.ttf", 64);
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"TestData/IO/AltseedPink.png"));

            Engine.AddNode(new TextNode() { Font = font, FontSize = 80, Text = "Hello, world! こんにちは" });
            Engine.AddNode(new TextNode() { Font = font, FontSize = 80, Text = "色を指定します。", Position = new Vector2F(0.0f, 100.0f), Color = new Color(0, 0, 255) });
            Engine.AddNode(new TextNode() { Font = font2, FontSize = 80, Text = "𠀋 𡈽 𡌛 𡑮 𡢽 𠮟 𡚴 𡸴 𣇄 𣗄 𣜿 𣝣 𣳾", Position = new Vector2F(0.0f, 300.0f) });
            Engine.AddNode(new TextNode() { Font = imageFont, FontSize = 80, Text = "Altseed〇Altseed", Position = new Vector2F(0.0f, 500.0f) });
            var rotated = new TextNode() { Font = font, FontSize = 80, Text = "回転します。", Position = new Vector2F(400.0f, 400.0f) };
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

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            var font2 = Font.LoadDynamicFont("TestData/Font/GenYoMinJP-Bold.ttf", 64);
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"TestData/IO/AltseedPink.png"));

            TextNode node = new TextNode() { Font = font2, FontSize = 40, Text = "Hello, world! こんにちは カーニングあるよ！！", IsEnableKerning = false, Color = new Color(255, 0, 0, 200) };
            Engine.AddNode(node);
            Engine.AddNode(new TextNode() { Font = font2, FontSize = 40, Text = "Hello, world! こんにちは カーニングないです", Color = new Color(0, 255, 0, 200) });
            Engine.AddNode(new TextNode() { Font = font, FontSize = 40, Text = node.ContentSize.ToString(), Position = new Vector2F(0.0f, 50.0f) });
            Engine.AddNode(new TextNode() { Font = font, FontSize = 40, Text = "字間5です。\n行間標準です。", CharacterSpace = 10, Position = new Vector2F(0.0f, 150.0f) });
            Engine.AddNode(new TextNode() { Font = font, FontSize = 40, Text = "字間10です。\n行間70です。", CharacterSpace = 50, LineGap = 200, Position = new Vector2F(0.0f, 250.0f) });
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

            Assert.IsTrue(Font.GenerateFontFile("TestData/Font/mplus-1m-regular.ttf", "test.a2f", "Hello, world! こんにちは", 64));

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            var font2 = Font.LoadStaticFont("test.a2f");
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"TestData/IO/AltseedPink.png"));

            Engine.AddNode(new TextNode() { Font = font, FontSize = 80, Text = "Hello, world! こんにちは" });
            Engine.AddNode(new TextNode() { Font = font2, FontSize = 80, Text = "Hello, world! こんにちは", Position = new Vector2F(0.0f, 100.0f), Color = new Color(0, 0, 255) });

            tc.LoopBody(c => { }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Culling()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            Assert.NotNull(font);

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var text = new TextNode() { Font = font, FontSize = 30, Text = "", ZOrder = 10 };
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

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink256.png");
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

                Span<Vector2F> span = stackalloc Vector2F[] {
                    new Vector2F(100 + cos, 100 - sin),
                    new Vector2F(100 - sin, 100 - cos),
                    new Vector2F(100 - cos, 100 + sin),
                    new Vector2F(100 + sin, 100 + cos),
                };

                node.SetVertexes(span, new Color(255, c % 255, 255, 255));
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
                Position = new Vector2F(250, 250)
            };
            Engine.AddNode(node);

            Span<Vector2F> span = stackalloc Vector2F[]
            {
                new Vector2F(-100, -100),
                new Vector2F(100, -100),
                new Vector2F(100, 100),
                new Vector2F(-100, 100),
            };

            node.SetVertexes(span, new Color(255, 0, 0));

            foreach (var current in node.Buffers) System.Diagnostics.Debug.WriteLine(current);

            tc.LoopBody(c => { }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void IBPolygonNode()
        {
            var tc = new TestCore();
            tc.Init();

            var node = new PolygonNode()
            {
                Position = new Vector2F(250, 250)
            };
            Engine.AddNode(node);

            //Span<Vector2F> span = stackalloc Vector2F[]
            //{
            //    new Vector2F(-100, -100),
            //    new Vector2F(-50, -100),
            //    new Vector2F(-50, -50),
            //    new Vector2F(-100, -50),
            //    new Vector2F(50, 50),
            //    new Vector2F(100, 50),
            //    new Vector2F(100, 100),
            //    new Vector2F(50, 100),
            //};

            //node.SetVertexes(span, new Color(255, 0, 0));

            //node.Buffers = new[]
            //{
            //    new IndexBuffer(0, 1, 2),
            //    new IndexBuffer(0, 2, 3),
            //    new IndexBuffer(4, 5, 6),
            //    new IndexBuffer(4, 6, 7),
            //};

            node.SetVertexGroupsFromPositions(new[]
            {
                new[]
                {
                    new Vector2F(-100, -100),
                    new Vector2F(-50, -100),
                    new Vector2F(-50, -50),
                    new Vector2F(-100, -50),
                },
                new[]
                {
                    new Vector2F(50, 50),
                    new Vector2F(100, 50),
                    new Vector2F(100, 100),
                    new Vector2F(50, 100),
                },
            }, new Color(255, 0, 0));

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void IBPolygonNodeWithTexture()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new PolygonNode()
            {
                Position = new Vector2F(250, 250),
                Texture = texture
            };
            Engine.AddNode(node);

            var basePositions = new[]
            {
                new Vector2F(-100f, -100f),
                new Vector2F(100f, 100f),
                new Vector2F(-150f, 250f),
                new Vector2F(250f, -150f),
            };
            var array = new Vector2F[basePositions.Length][];
            for (int i = 0; i < basePositions.Length; i++)
            {
                array[i] = new[]
                {
                    basePositions[i],
                    basePositions[i] + new Vector2F(50f, 0f),
                    basePositions[i] + new Vector2F(50f, 50f),
                    basePositions[i] + new Vector2F(0f, 50f),
                };
            }

            node.SetVertexGroupsFromPositions(array, new Color(255, 255, 255));

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void CenterPosition()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.Position = Engine.WindowSize / 2;
            Engine.AddNode(node);

            var child = new SpriteNode();
            child.Texture = texture;
            child.CenterPosition = texture.Size / 2;
            //child.Position = texture.Size / 2;
            node.AddChildNode(child);

            var child2 = new SpriteNode();
            child2.Texture = texture;
            child2.CenterPosition = texture.Size / 2;
            child2.Position = texture.Size / 2;
            node.AddChildNode(child2);

            tc.LoopBody(c =>
            {
                node.Angle += 1.0f;
                child.Angle += 1.0f;
                child2.Angle += 1.0f;
            }
            , null);

            tc.End();
        }


        [Test, Apartment(ApartmentState.STA)]
        public void Pivot()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            Assert.NotNull(font);

            var rotated = new AnchorTransformerNode()
            {
                Position = new Vector2F(300.0f, 300.0f),
                Pivot = new Vector2F(0.5f, 0.5f),
            };
            var text = new TextNode();
            text.Font = font;
            text.FontSize = 80;
            text.Text = "中心で回転します";
            rotated.Size = text.ContentSize;
            Engine.AddNode(text);
            text.AddChildNode(rotated);

            tc.LoopBody(c =>
            {
                text.Text = "中心で回転します" + c.ToString();
                rotated.Size = text.ContentSize;

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

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            Assert.NotNull(font);

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var sprite = new SpriteNode();
            sprite.Texture = texture;
            sprite.ZOrder = 5;

            Vector2F rectSize = texture.Size;
            var parent = new AnchorTransformerNode();
            parent.Position = Engine.WindowSize / 2;
            parent.Size = rectSize;
            parent.AnchorMode = AnchorMode.Fill;
            Engine.AddNode(sprite);
            sprite.AddChildNode(parent);

            var sprite2 = new SpriteNode();
            sprite2.Texture = texture;
            sprite2.Color = new Color(255, 0, 0, 200);
            sprite2.ZOrder = 10;

            var child = new AnchorTransformerNode();
            child.Position = rectSize / 2;
            child.Pivot = new Vector2F(0.5f, 0.5f);
            child.AnchorMin = new Vector2F(0.0f, 0.0f);
            child.AnchorMax = new Vector2F(0.5f, 1f);
            child.HorizontalAlignment = HorizontalAlignment.Left;
            child.VerticalAlignment = VerticalAlignment.Center;
            child.Size = sprite2.ContentSize;
            child.AnchorMode = AnchorMode.KeepAspect;
            sprite.AddChildNode(sprite2);
            sprite2.AddChildNode(child);

            var text = new TextNode();
            text.Font = font;
            text.FontSize = 20;
            text.Color = new Color(0, 0, 0);
            text.Text = "あいうえお";
            text.ZOrder = 15;

            var childText = new AnchorTransformerNode();
            childText.Pivot = new Vector2F(0.5f, 0.5f);
            childText.AnchorMin = new Vector2F(0.5f, 0.5f);
            childText.AnchorMax = new Vector2F(0.5f, 0.5f);
            childText.Size = text.ContentSize;
            //childText.HorizontalAlignment = HorizontalAlignment.Center;
            //childText.VerticalAlignment = VerticalAlignment.Center;
            childText.AnchorMode = AnchorMode.ContentSize;
            sprite2.AddChildNode(text);
            text.AddChildNode(childText);

            var text2 = new TextNode()
            {
                Font = font,
                FontSize = 20,
                Text = "",
                ZOrder = 10,
                Scale = new Vector2F(0.8f, 0.8f),
                Color = new Color(255, 128, 0)
            };
            Engine.AddNode(text2);

            tc.Duration = 10000;

            string infoText(AnchorTransformerNode n) =>
                    $"Scale:{n.Scale}\n" +
                    $"Position:{n.Position}\n" +
                    $"Pivot:{n.Pivot}\n" +
                    $"Size:{n.Size}\n" +
                    $"Margin: LT:{n.LeftTop} RB:{n.RightBottom}\n" +
                    $"Anchor: {n.AnchorMin} {n.AnchorMax}\n";

            tc.LoopBody(c =>
            {
                if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) rectSize.X += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) rectSize.X -= 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) rectSize.Y += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) rectSize.Y -= 1.5f;

                if (Engine.Keyboard.GetKeyState(Key.D) == ButtonState.Hold) parent.Position += new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.A) == ButtonState.Hold) parent.Position += new Vector2F(-1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.S) == ButtonState.Hold) parent.Position += new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Key.W) == ButtonState.Hold) parent.Position += new Vector2F(0, -1.5f);

                if (Engine.Keyboard.GetKeyState(Key.Q) == ButtonState.Hold) child.Angle += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.E) == ButtonState.Hold) child.Angle -= 1.5f;

                if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Hold) parent.Scale += new Vector2F(0.1f, 0);
                if (Engine.Keyboard.GetKeyState(Key.C) == ButtonState.Hold) parent.Scale -= new Vector2F(0.1f, 0);

                parent.Size = rectSize;

                text2.Text = infoText(parent) + '\n' + infoText(child) + '\n' + infoText(childText);
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void IsDrawn()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.Position = new Vector2F(100, 100);
            Engine.AddNode(node);

            var node2 = new SpriteNode();
            node2.Texture = texture;
            node2.CenterPosition = texture.Size / 2;
            node2.Position = new Vector2F(200, 200);

            var node3 = new RectangleNode();
            node3.RectangleSize = texture.Size;
            node3.Texture = texture;
            node3.CenterPosition = texture.Size / 2;
            node3.Position = new Vector2F(300, 300);

            tc.LoopBody(c =>
            {
                if (c == 2)
                {
                    node.AddChildNode(node2);
                }
                else if (c == 4)
                {
                    node.IsDrawn = false;
                    Assert.IsFalse(node.IsDrawnActually);
                    Assert.IsFalse(node2.IsDrawnActually);
                }

                else if (c == 6)
                {
                    node2.AddChildNode(node3);
                }

                else if (c == 8)
                {
                    node.IsDrawn = true;

                    Assert.IsTrue(node.IsDrawnActually);
                    Assert.IsTrue(node2.IsDrawnActually);
                    Assert.IsTrue(node3.IsDrawnActually);
                }
                else if (c == 10)
                {
                    node2.IsDrawn = false;

                    Assert.IsTrue(node.IsDrawnActually);
                    Assert.IsFalse(node2.IsDrawnActually);
                    Assert.IsFalse(node3.IsDrawnActually);
                }
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ZOrder()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.Position = new Vector2F(100, 100);
            node.Color = new Color(255, 0, 0);
            node.ZOrder = 300;
            Engine.AddNode(node);

            var node2 = new SpriteNode();
            node2.Texture = texture;
            node2.CenterPosition = texture.Size / 2;
            node2.Position = new Vector2F(200, 200);
            node2.ZOrder = 200;
            node2.Color = new Color(0, 0, 255);
            Engine.AddNode(node2);

            var node3 = new SpriteNode();
            node3.Texture = texture;
            node3.CenterPosition = texture.Size / 2;
            node3.Position = new Vector2F(300, 300);
            node3.ZOrder = 150;
            node3.Color = new Color(0, 255, 0);
            Engine.AddNode(node3);

            tc.LoopBody(c =>
            {
                node3.ZOrder++;
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TransformNodeInfo()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.Position = new Vector2F(100, 200);
            node.Src = new RectF(0, 0, 128, 128);
            Engine.AddNode(node);

            var node2 = new SpriteNode();
            node2.Texture = texture;
            node2.CenterPosition = texture.Size / 2;
            node2.Position = new Vector2F(200, 200);
            node2.Angle = 68;
            node2.ZOrder = 200;
            node2.Scale = new Vector2F(0.8f, 0.5f);
            node2.Color = new Color(0, 0, 255);
            node.AddChildNode(node2);

            var node3 = new SpriteNode();
            node3.Texture = texture;
            node3.CenterPosition = texture.Size / 2;
            node3.Position = new Vector2F(300, 300);
            node3.ZOrder = 150;
            node3.Color = new Color(0, 255, 0);
            node2.AddChildNode(node3);

            tc.Duration = 600;
            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void VisibleTransformNodeInfo()
        {
            var tc = new TestCore(new Configuration() { VisibleTransformInfo = true });
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node4 = new SpriteNode();
            node4.Texture = texture;
            node4.Position = new Vector2F(400, 200);
            node4.Src = new RectF(0, 0, 128, 128);
            node4.VisibleTransformNodeInfo = false;
            Engine.AddNode(node4);

            var node5 = new SpriteNode();
            node5.Texture = texture;
            node5.CenterPosition = texture.Size / 2;
            node5.Position = new Vector2F(200, 200);
            node5.Angle = 68;
            node5.ZOrder = 200;
            node5.Scale = new Vector2F(0.8f, 0.5f);
            node5.Color = new Color(0, 0, 255);
            node5.VisibleTransformNodeInfo = false;
            node4.AddChildNode(node5);

            var node6 = new SpriteNode();
            node6.Texture = texture;
            node6.CenterPosition = texture.Size / 2;
            node6.Position = new Vector2F(300, 300);
            node6.ZOrder = 150;
            node6.Color = new Color(0, 255, 0);
            node6.VisibleTransformNodeInfo = false;
            node5.AddChildNode(node6);

            tc.Duration = 600;
            tc.LoopBody(c =>
            {
                node4.VisibleTransformNodeInfo = (c / 10) % 2 == 0;
                node5.VisibleTransformNodeInfo = !node4.VisibleTransformNodeInfo;
                node6.VisibleTransformNodeInfo = !node5.VisibleTransformNodeInfo;
            }
            , null);

            tc.End();
        }
    }
}
