using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed.TinySystem.Test
{
    [TestFixture]
    class DrawnNode
    {
        [Test, Apartment(ApartmentState.STA)]
        public void SpriteNode()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            s.Texture = t1;
            Engine.CurrentScene.AddNode(s);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TextureNode()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new TextureNode();
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);
            Engine.CurrentScene.AddNode(s);

            tc.LoopBody(null, null);

            tc.End();
        }
    }
}
