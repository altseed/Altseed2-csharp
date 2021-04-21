using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class ShapeNodes
    {
        [Test, Apartment(ApartmentState.STA)]
        public void ArcNode()
        {
            var tc = new TestCore();
            tc.Init();

            var arc1 = new ArcNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100, 100),
                Radius = 50f,
                VertNum = 30,
            };
            var arc2 = new ArcNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400, 200),
                Radius = 30f,
                VertNum = 8,
            };
            var arc3 = new ArcNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(50, 400),
                Radius = 40f,
                VertNum = 5,
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
            var tc = new TestCore(new Configuration());
            tc.Init();

            var circle1 = new CircleNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100, 100),
                Radius = 50f,
                VertNum = 30,
            };
            var circle2 = new CircleNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400, 200),
                Radius = 30f,
                VertNum = 8,
            };
            var circle3 = new CircleNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(50, 400),
                Radius = 40f,
                VertNum = 5,
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
            var tc = new TestCore(new Configuration());
            tc.Init();

            var line1 = new LineNode()
            {
                Color = new Color(255, 0, 0),
                Point1 = new Vector2F(100f, 100f),
                Point2 = new Vector2F(200f, 200f),
                Thickness = 10f,
            };
            var line2 = new LineNode()
            {
                Color = new Color(0, 255, 0),
                Point1 = new Vector2F(50f, 450f),
                Point2 = new Vector2F(600f, 50f),
                Thickness = 5.0f,
            };
            var line3 = new LineNode()
            {
                Color = new Color(0, 0, 255),
                Point1 = new Vector2F(100f, 150f),
                Point2 = new Vector2F(100f, 350f),
                Thickness = 15.0f,
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
            var tc = new TestCore(new Configuration());
            tc.Init();

            var rectangle1 = new RectangleNode()
            {
                Color = new Color(255, 0, 0),
                Position = new Vector2F(100f, 100f),
                CenterPosition = new Vector2F(25f, 25f),
                RectangleSize = new Vector2F(50f, 50f),
            };
            var rectangle2 = new RectangleNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400f, 200f),
                RectangleSize = new Vector2F(200f, 100f),
            };
            var rectangle3 = new RectangleNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(200f, 300f),
                RectangleSize = new Vector2F(100f, 150f),
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
            var tc = new TestCore(new Configuration());
            tc.Init();

            var triangle = new TriangleNode()
            {
                Color = new Color(255, 0, 0),
                Point1 = new Vector2F(100f, 100f),
                Point2 = new Vector2F(200f, 200f),
                Point3 = new Vector2F(100f, 200f),
                Position = new Vector2F(100, 100),
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
        public void AcnhorAndShapeNode()
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

            var circle2 = new CircleNode()
            {
                Color = new Color(0, 255, 0),
                Position = new Vector2F(400, 200),
                Radius = 100f,
                VertNum = 80,
                ZOrder = 10,
            };

            var circle2Anchor = new AnchorTransformerNode();
            circle2Anchor.AnchorMin = new Vector2F(0.0f, 0.0f);
            circle2Anchor.AnchorMax = new Vector2F(0.5f, 1f);
            circle2Anchor.AnchorMode = AnchorMode.Fill;
            sprite.AddChildNode(circle2);
            circle2.AddChildNode(circle2Anchor);

            var circle3 = new CircleNode()
            {
                Color = new Color(0, 0, 255),
                Position = new Vector2F(50, 400),
                Radius = 100f,
                VertNum = 50,
                ZOrder = 15,
            };

            var circle3Anchor = new AnchorTransformerNode();
            circle3Anchor.AnchorMin = new Vector2F(0.5f, 0.5f);
            circle3Anchor.AnchorMax = new Vector2F(1f, 1f);
            circle3Anchor.AnchorMode = AnchorMode.Fill;
            circle2.AddChildNode(circle3);
            circle3.AddChildNode(circle3Anchor);

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
                    circle2Anchor.RightBottom = new Vector2F();
                    circle3Anchor.RightBottom = new Vector2F();

                if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) rectSize.X += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) rectSize.X -= 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) rectSize.Y += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) rectSize.Y -= 1.5f;

                if (Engine.Keyboard.GetKeyState(Key.D) == ButtonState.Hold) parent.Position += new Vector2F(1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.A) == ButtonState.Hold) parent.Position += new Vector2F(-1.5f, 0);
                if (Engine.Keyboard.GetKeyState(Key.S) == ButtonState.Hold) parent.Position += new Vector2F(0, 1.5f);
                if (Engine.Keyboard.GetKeyState(Key.W) == ButtonState.Hold) parent.Position += new Vector2F(0, -1.5f);

                if (Engine.Keyboard.GetKeyState(Key.Q) == ButtonState.Hold) circle2Anchor.Angle += 1.5f;
                if (Engine.Keyboard.GetKeyState(Key.E) == ButtonState.Hold) circle2Anchor.Angle -= 1.5f;

                if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Hold) parent.Scale += new Vector2F(0.1f, 0);
                if (Engine.Keyboard.GetKeyState(Key.C) == ButtonState.Hold) parent.Scale -= new Vector2F(0.1f, 0);

                parent.Size = rectSize;

                text2.Text = infoText(parent) + '\n' + infoText(circle2Anchor) + '\n' + infoText(circle3Anchor);
            }, null);

            tc.End();
        }
    }
}
