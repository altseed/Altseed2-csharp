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
        public void Rotate()
        {
            var tc = new TestCore();
            tc.Init();

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(t1);

            var s = new SpriteNode();
            s.Texture = t1;
            s.Position = new Vector2F(100, 100);
            s.CenterPosition = s.Texture.Size / 2;
            Engine.CurrentScene.AddNode(s);

            tc.LoopBody(c =>
            {
                s.Angle++;
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TextNode()
        {
            var tc = new TestCore();
            tc.Init();

            var color = new Color(255, 0, 0, 255);
            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100, ref color);
            Assert.NotNull(font);

            var t = new TextNode();
            t.Font = font;
            t.Text = "TextNodeのテスト！";

            Engine.CurrentScene.AddNode(t);

            tc.LoopBody(null, null);

            tc.End();
        }
    }
}
