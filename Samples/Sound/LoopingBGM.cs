using System;

using Altseed;

namespace Sample
{
    class SoundLoop
    {
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            Engine.Initialize("Sound_Loop", 640, 480);

            // 音ファイルを読み込みます。
            // 効果音の場合は第2引数を true に設定して再生しながら解凍することが推奨されている。
            var bgm = Sound.Load(@"TestData\Sound\bgm1.ogg", false);

            // 音のループモードを有効にします。
            bgm.IsLoopingMode = true;

            // ループの始端を1秒に、終端を2.5秒にします。
            bgm.LoopStartingPoint = 1.0f;
            bgm.LoopEndPoint = 2.5f;

            // 音を再生します。
            var id = Engine.Sound.Play(bgm);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // Altseedを更新します。
                Engine.Update();

                // 音の再生が終了しているか調べる。
                if (!Engine.Sound.GetIsPlaying(id))
                {
                    break;
                }
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}