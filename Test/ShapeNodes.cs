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
                Pivot = new Vector2F(0.5f, 0.5f),
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
                Pivot = new Vector2F(0.5f, 0.1f),
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
    }
}
