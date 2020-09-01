using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using System.Reflection;

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

            var t1 = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Src = new RectF(new Vector2F(100, 100), new Vector2F(100, 100));
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s2.Texture = t1;
            s2.Position = new Vector2F(200, 200);

            var s3 = new SpriteNode();
            s3.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s3.Texture = t1;
            s3.Position = new Vector2F(200, 200);

            s.AddChildNode(s2);
            s2.AddChildNode(s3);

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

            var t1 = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new Altseed2.Node();
            //s.Texture = t1;
            //s.Position = new Vector2F(100, 100);

            var s2 = new SpriteNode();
            s2.Texture = t1;
            s2.Position = new Vector2F(100, 100);

            var s3 = new SpriteNode();
            s3.Texture = t1;
            s3.Position = new Vector2F(100, 100);

            var s4 = new SpriteNode();
            s4.Texture = t1;
            s4.Position = new Vector2F(100, 100);

            s.AddChildNode(s2);
            s2.AddChildNode(s3);
            s3.AddChildNode(s4);

            Engine.AddNode(s);

            tc.LoopBody(c =>
            {
                if (c == 100) Engine.RemoveNode(s);
                if (c == 101)
                {
                    Assert.IsFalse(s.IsRegistered);
                    Assert.IsFalse(s2.IsRegistered);
                    Assert.IsFalse(s3.IsRegistered);
                    Assert.IsFalse(s4.IsRegistered);

                    var dc = typeof(Engine).GetField("_DrawnCollection", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as DrawnCollection;
                    var drawns = typeof(DrawnCollection).GetField("_Drawns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dc) as SortedDictionary<int, HashSet<IDrawn>>;
                    Assert.IsTrue(drawns.All(kv => kv.Value.Count == 0));
                }
                if (c == 110) Engine.AddNode(s);
                if (c == 111)
                {
                    Assert.IsTrue(s.IsRegistered);
                    Assert.IsTrue(s2.IsRegistered);
                    Assert.IsTrue(s3.IsRegistered);
                    Assert.IsTrue(s4.IsRegistered);

                    var dc = typeof(Engine).GetField("_DrawnCollection", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as DrawnCollection;
                    var drawns = typeof(DrawnCollection).GetField("_Drawns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dc) as SortedDictionary<int, HashSet<IDrawn>>;
                    Assert.AreEqual(3, drawns.Sum(kv => kv.Value.Count));
                }
                if (c == 120)
                {
                    s2.RemoveChildNode(s3);
                    s2.FlushQueue();

                    Assert.AreEqual(RegisteredStatus.Free, s3.Status);

                    Assert.IsTrue(s.IsRegistered);
                    Assert.IsTrue(s2.IsRegistered);
                    Assert.IsFalse(s3.IsRegistered);
                    Assert.IsFalse(s4.IsRegistered);

                    var dc = typeof(Engine).GetField("_DrawnCollection", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as DrawnCollection;
                    var drawns = typeof(DrawnCollection).GetField("_Drawns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dc) as SortedDictionary<int, HashSet<IDrawn>>;
                    Assert.AreEqual(1, drawns.Sum(kv => kv.Value.Count));
                }

            }, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void EnuemrateAncestors()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"TestData/IO/AltseedPink.png");
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

            var t1 = Texture2D.Load(@"TestData/IO/AltseedPink.png");
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
