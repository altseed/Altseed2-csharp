using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Input
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Mouse()
        {
            var coreOption = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");

            Assert.NotNull(t1);

            var s1 = RenderedSprite.Create();

            s1.Texture = t1;
            s1.Src = new RectF(0, 0, 128, 128);

            while (Engine.DoEvents())
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Renderer.DrawSprite(s1);
                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();

                Engine.Renderer.Render(cmdList);

                Engine.Update();
                Assert.True(Engine.Graphics.EndFrame());

                s1.Src = new RectF(0, 0, (int)Engine.Mouse.Position.X, (int)Engine.Mouse.Position.Y);
            }

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Keyboard()
        {
            var coreOption = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            while (Engine.DoEvents() && Engine.Keyboard.GetKeyState(Keys.Space) == ButtonState.Free)
            {
                Engine.Update();
            }

            while (Engine.DoEvents() && Engine.Keyboard.GetKeyState(Keys.Space) == ButtonState.Push)
            {
                Engine.Update();
            }

            while (Engine.DoEvents() && Engine.Keyboard.GetKeyState(Keys.Space) == ButtonState.Hold)
            {
                Engine.Update();
            }

            while (Engine.DoEvents() && Engine.Keyboard.GetKeyState(Keys.Space) == ButtonState.Release)
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
