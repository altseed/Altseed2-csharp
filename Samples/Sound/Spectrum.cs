using System;

using Altseed2;

namespace Sample
{
    class SoundSpectrum
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Sound_BGM", 640, 480);

            // 音ファイルを読み込みます。
            // 効果音の場合は第2引数を true に設定して再生しながら解凍することが推奨されている。
            var bgm = Sound.Load(@"TestData\Sound\bgm1.ogg", false);

            // 音を再生します。
            var id = Engine.Sound.Play(bgm);

            // スペクトルバーのインスタンスを1024個作成します。
            var spectrumBars = new PolygonNode[1024];
            for (int i = 0; i < 1024; ++i)
            {
                // ※ 640 / 1024 = 0.625
                var spectrumBar = new PolygonNode();
                spectrumBar.Position = new Vector2F(i * 0.625f, 1.0f);
                Span<Vector2F> vertexes = stackalloc Vector2F[4] {
                    new Vector2F(0.0f, 480.0f),
                    new Vector2F(0.0f, 480.0f),
                    new Vector2F(0.625f, 480.0f),
                    new Vector2F(0.625f, 480.0f),
                };
                spectrumBar.SetVertexes(vertexes, new Color(255, 255, 255));
                spectrumBars[i] = spectrumBar;
                Engine.AddNode(spectrumBar);
            }

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // Altseedを更新します。
                Engine.Update();

                // 再生されている音のスペクトル情報を取得します。
                // データの長さは2のn乗でなくてはなりません。
                var spectrum = Engine.Sound.GetSpectrum(id, 1024, FFTWindow.Rectangular);

                // 取得したスペクトル情報をスペクトルバーに反映させます。
                for (int i = 0; i < 1024; ++i)
                {
                    Span<Vector2F> vertexes = stackalloc Vector2F[]
                    {
                        new Vector2F(0.0f, 480.0f),
                        new Vector2F(0.0f, 480.0f - spectrum[i]),
                        new Vector2F(0.625f, 480.0f - spectrum[i]),
                        new Vector2F(0.625f, 480.0f),
                    };
                    spectrumBars[i].SetVertexes(vertexes, new Color(255, 255, 255));
                }

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