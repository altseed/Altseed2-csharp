using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    public class Window
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Base()
        {
            var tc = new TestCore();
            tc.Init();

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void FullScreen()
        {
            var tc = new TestCore(new Configuration() { IsFullscreen = true });
            tc.Init();

            tc.LoopBody(null, null);

            tc.End();
        }
    }
}
