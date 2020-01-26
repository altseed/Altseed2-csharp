using System;
using System.IO;
using Xunit;

namespace Altseed.Test
{
    public class Window
    {
        [Fact]
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
