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
            var coreOption = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, coreOption));

            var count = 0;

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            //var t2 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.jpg");

            Assert.NotNull(t1);
            //Assert.NotNull(t2);

            var s1 = Engine.Renderer.CreateSprite();
            //var s2 = Engine.Renderer.CreateSprite();

            s1.Texture = t1;
            s1.Src = new RectF(0, 0, 128, 128);

            //auto trans = Altseed::Matrix44F();
            //trans.SetTranslation(200, 200, 0);
            //s2->SetTexture(t2);
            //s2->SetTransform(trans);
            //s2->SetSrc(Altseed::RectF(128, 128, 256, 256));

            while (Engine.DoEvents() && count++ < 300)
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Renderer.Reset();
                var cmdList = Engine.Graphics.GetCommandList();
                cmdList.SetRenderTargetWithScreen();

                Engine.Renderer.Render(cmdList);

                Engine.Update();
                Assert.True(Engine.Graphics.EndFrame());

            }

            Engine.Terminate();
        }
    }
}