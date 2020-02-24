using Altseed;

namespace MacTest
{
    class SoundTest
    {
        public static void Play()
        {
            Engine.Initialize("SoundTest Play", 640, 480);

            Sound bgm = Sound.Load(@"../Core/TestData/Sound/bgm1.ogg", false);
            Sound se = Sound.Load(@"../Core/TestData/Sound/se1.wav", true);

            int bgm_id = Engine.Sound.Play(bgm);
            int se_id = Engine.Sound.Play(se);

            while(Engine.DoEvents() && (Engine.Sound.GetIsPlaying(bgm_id) || Engine.Sound.GetIsPlaying(se_id)))
            {
                Engine.Update();
            }

            Engine.Terminate();
        }

        public static void Loop()
        {
            Engine.Initialize("SoundTest Loop", 640, 480);

            Sound bgm = Sound.Load(@"../Core/TestData/Sound/bgm1.ogg", false);
            bgm.IsLoopingMode = true;
            bgm.LoopStartingPoint = 1.0f;
            bgm.LoopEndPoint = 2.5f;

            int bgm_id = Engine.Sound.Play(bgm);

            while(Engine.DoEvents() && Engine.Sound.GetIsPlaying(bgm_id) )
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}