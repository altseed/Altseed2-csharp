using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Sound
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Play()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            var s1 = Engine.Sound.CreateSound(@"../../Core/TestData/Sound/bgm1.ogg", false);
            var s2 = Engine.Sound.CreateSound(@"../../Core/TestData/Sound/se1.wav", true);

            Assert.NotNull(s1);
            Assert.NotNull(s2);

            Engine.Sound.Play(s1);
            Engine.Sound.Play(s2);

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Sound.StopAll();

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Loop()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            var s1 = Engine.Sound.CreateSound(@"../../Core/TestData/Sound/bgm1.ogg", false);
            Assert.NotNull(s1);

            s1.IsLoopingMode = true;
            s1.LoopStartingPoint = 0f;
            s1.LoopEndPoint = 1f;

            Engine.Sound.Play(s1);

            int count = 0;
            while (Engine.DoEvents() && count++ < 300)
            {
                Engine.Update();
            }
            Engine.Sound.StopAll();

            Engine.Terminate();
        }
    }
}
