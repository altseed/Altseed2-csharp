using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class Node
    {
        [Test, Apartment(ApartmentState.STA)]
        public void TreeAdd()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new Altseed2.Node();
            //s.Src = new RectF(new Vector2F(100, 100), new Vector2F(100, 100));
            //s.Texture = t1;
            //s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s2.Texture = t1;
            s2.Position = new Vector2F(200, 200);

            s.AddChildNode(s2);

            tc.LoopBody(c =>
            {
                if (c == 100) Engine.AddNode(s);
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TreeDelete()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Src = new RectF(new Vector2F(100, 100), new Vector2F(100, 100));
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s2.Texture = t1;
            s2.Position = new Vector2F(200, 200);

            s.AddChildNode(s2);

            Engine.AddNode(s);

            tc.LoopBody(c =>
            {
                if (c == 100) Engine.RemoveNode(s);
            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void EnuemrateAncestors()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Src = new RectF(new Vector2F(100, 100), new Vector2F(100, 100));
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s2.Texture = t1;
            s2.Position = new Vector2F(200, 0);

            s.AddChildNode(s2);

            Engine.AddNode(s);

            tc.LoopBody(c =>
           {
               if (c == 2)
               {
                   var e = s2.EnumerateAncestors().ToArray();
                   Assert.AreEqual(1, e.Length);
                   Assert.AreSame(e[0], s);
               }
               s.Angle++;
           }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Reusable()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Texture = t1;
            s2.Position = new Vector2F(200, 200);
            s.AddChildNode(s2);
            Engine.AddNode(s);

            var n = new Node();

            tc.Duration = 5;
            tc.LoopBody(c =>
            {
                switch (c)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        Assert.True(s2.Parent == s);
                        break;

                    case 3:
                        Engine.RemoveNode(s);
                        break;

                    case 4:
                        Assert.Null(s.Parent);
                        Assert.True(s.Status == RegisteredStatus.Free);
                        break;

                    case 5:
                        s.RemoveChildNode(s2);
                        Assert.True(s2.Status == RegisteredStatus.WaitingRemoved);
                        s.FlushQueue();
                        Assert.Null(s2.Parent);
                        Assert.True(s2.Status == RegisteredStatus.Free);
                        Assert.AreEqual(s.Children.Count, 0);
                        break;
                }
            }, null);

            tc.End();
        }

    }
}
