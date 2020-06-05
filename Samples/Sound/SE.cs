using System;

using Altseed;

namespace Sample
{
    class SoundSE
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Sound_SE", 640, 480);

            // 音ファイルを読み込みます。
            // 効果音の場合は第2引数を true に設定して事前にファイルを解凍することが推奨されている。
            var se = Sound.Load(@"TestData\Sound\se1.wav", true);

            // 音を再生します。
            var id = Engine.Sound.Play(se);

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