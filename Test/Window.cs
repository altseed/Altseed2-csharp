using System;
using System.IO;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Window
    {
        [Test]
        public void Base()
        {
            var coreOption = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, coreOption));

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
