using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Window
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Base()
        {
            var coreOption = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
