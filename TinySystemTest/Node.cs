using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed.TinySystem.Test
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
            var tr = new Matrix44F();
            tr.SetTranslation(100, 100, 0);
            s.Transform = tr;

            var s2 = new SpriteNode();
            s.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s.Texture = t1;
            s.Transform.SetTranslation(200, 200, 0);
            s.AddChildNode(s2);

            Engine.CurrentScene.AddNode(s);

            tc.LoopBody(null, null);

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
            s.Transform.SetTranslation(100, 100, 0);

            var s2 = new SpriteNode();
            s.Src = new RectF(new Vector2F(200, 200), new Vector2F(100, 100));
            s.Texture = t1;
            s.Transform.SetTranslation(200, 200, 0);
            s.AddChildNode(s2);

            Engine.CurrentScene.AddNode(s);

            tc.LoopBody((c) =>
            {
                if (c == 100)
                    Engine.CurrentScene.RemoveNode(s);
            }, null);

            tc.End();
        }
    }
}
