using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

using Altseed.ComponentSystem;

namespace Altseed.Test
{
    [TestFixture]
    public class Sound
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Play()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

            var bgm = Altseed.Sound.Load(@"../../Core/TestData/Sound/bgm1.ogg", false);
            var se = Altseed.Sound.Load(@"../../Core/TestData/Sound/se1.wav", true);

            Assert.NotNull(bgm);
            Assert.NotNull(se);

            int bgm_id = Engine.Sound.Play(bgm);
            int se_id = Engine.Sound.Play(se);

            while (Engine.DoEvents() && (Engine.Sound.GetIsPlaying(bgm_id) || Engine.Sound.GetIsPlaying(se_id)))
            {
                Engine.Update();
            }

            Engine.Sound.StopAll();

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Loop()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

            var bgm = Altseed.Sound.Load(@"../../Core/TestData/Sound/bgm1.ogg", false);
            Assert.NotNull(bgm);

            bgm.IsLoopingMode = true;
            bgm.LoopStartingPoint = 1f;
            bgm.LoopEndPoint = 2.5f;

            int bgm_id = Engine.Sound.Play(bgm);

            while (Engine.DoEvents() && Engine.Sound.GetIsPlaying(bgm_id))
            {
                Engine.Update();
            }
            Engine.Sound.StopAll();

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void GetPosition()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();

            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

            var bgm = Altseed.Sound.Load(@"../../Core/TestData/Sound/bgm1.ogg", false);
            Assert.NotNull(bgm);

            int bgm_id = Engine.Sound.Play(bgm);

            stopwatch.Start();
            bool isChecked = false;

            while (Engine.DoEvents() && Engine.Sound.GetIsPlaying(bgm_id))
            {
                Engine.Update();
                if(stopwatch.ElapsedMilliseconds > 2000 && !isChecked)
                {
                    Console.WriteLine("BGM Position : {0}", Engine.Sound.GetPlaybackPosition(bgm_id));
                    isChecked = true;
                }
            }
            Engine.Sound.StopAll();

            Engine.Terminate();
        }
    }
}
