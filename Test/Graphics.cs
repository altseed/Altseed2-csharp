using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Graphics
    {
        [Test, Apartment(ApartmentState.STA)]
        public void BasicSpriteTexture()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

            var count = 0;

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            var t2 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.jpg");

            Assert.NotNull(t1);
            Assert.NotNull(t2);

            var s1 = RenderedSprite.Create();
            var s2 = RenderedSprite.Create();

            s1.Texture = t1;
            s1.Src = new RectF(0, 0, 128, 128);

            var trans = new Matrix44F();
            trans.SetTranslation(200, 200, 0);
            s2.Texture = t2;
            s2.Transform = trans;
            s2.Src = new RectF(128, 128, 256, 256);

            while (Engine.DoEvents() && count++ < 300)
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Renderer.DrawSprite(s1);
                Engine.Renderer.DrawSprite(s2);
                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();

                Engine.Renderer.Render(cmdList);

                Engine.Update();
                Assert.True(Engine.Graphics.EndFrame());

            }

            Engine.Terminate();
        }
    }
}