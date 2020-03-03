using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Altseed.TinySystem.Test
{
    [TestFixture]
    class EngineTest
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Empty()
        {
            var tc = new TestCore();

            tc.Init();

            tc.LoopBody(null, null);

            tc.End();
        }
    }
}
