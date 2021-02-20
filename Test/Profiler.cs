using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    public class Profiler
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Basic()
        {
            var tc = new TestCore();
            tc.Init();

            Engine.Profiler.StartCapture();

            {
                using var block1 = new ProfilerBlock("Block1", new Color(255, 0, 0));
                System.Threading.Thread.Sleep(500);
                {
                    using var block2 = new ProfilerBlock("Block2", new Color(0, 255, 0));
                    System.Threading.Thread.Sleep(500);
                }
            }

            Engine.Profiler.DumpToFileAndStopCapture("Profiler.prof");

            tc.End();
        }
    }
}
