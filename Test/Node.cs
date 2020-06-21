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

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
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

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
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

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
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
    }
}
