using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed.TinySystem.Test
{
    static class TestCore
    {
        public static void Init([CallerMemberName]string testName = "")
        {
            Assert.True(Engine.Initialize($"Altseed2 C# TinySystem Test:{testName}", 800, 600, new Configuration()));
        }
    }

    [TestFixture]
    class EngineTest
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Empty()
        {
            TestCore.Init();

            int count = 0;
            while (Engine.DoEvents() && count++ < 300)
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
