using Altseed;

namespace MacTest
{
    class SoundTest
    {
        public static void Play()
        {
            Engine.Initialize("SoundTest Play", 640, 480);

            Sound bgm = Engine.Sound.Load(@"../Core/TestData/Sound/bgm1.ogg", false);
            Sound se = Engine.Sound.Load(@"../Core/TestData/Sound/se1.wav", true);

            int bgm_id = Engine.Sound.Play(bgm);
            int se_id = Engine.Sound.Play(se);

            while(Engine.DoEvents() && (Engine.Sound.GetIsPlaying(bgm_id) || Engine.Sound.GetIsPlaying(se_id)))
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}