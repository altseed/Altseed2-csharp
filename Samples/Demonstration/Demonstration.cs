using System;
using System.Linq;
using Altseed2;

namespace Sample
{
    class Demonstration
    {
        // HSV を RGB に変換します。
        private static Color HSV2RGB(int hue, int saturation, int value)
        {
            hue %= 360;
            int max = value;
            int min = (int)(value * ((255.0 - saturation) / 255.0));
            int mid = (int)((1.0 - Math.Abs(1.0 - (hue % 120) / 60.0)) * (max - min) + min);

            if(0 <= hue && hue < 60) return new Color(max, mid, min, 255);
            if(60 <= hue && hue < 120) return new Color(mid, max, min, 255);
            if(120 <= hue && hue < 180) return new Color(min, max, mid, 255);
            if(180 <= hue && hue < 240) return new Color(min, mid, max, 255);
            if(240 <= hue && hue < 300) return new Color(mid, min, max, 255);
            if(300 <= hue && hue < 360) return new Color(max, min, mid, 255);

            throw new Exception();
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            Engine.Initialize("~ Altseed2 DEMO ~", 640, 480);
            Engine.ClearColor = new Color(0, 0, 0);

            // テキストを描画するノードを作成し、エンジンに登録します。
            var title = new TextNode();
            title.Font = Font.LoadDynamicFont("Courier.ttf", 48);
            title.Text = Engine.WindowTitle;
            title.CenterPosition = title.ContentSize / 2;
            title.Position = new Vector2F(320.0f, 80.0f);
            Engine.AddNode(title);

            // スペクトルバーを示す図形ノードを作成し、エンジンに登録します。
            var spectrumBars = new RectangleNode[16, 16];
            for(int i = 0; i < 16; ++i)
                for(int j = 0; j < 16; ++j)
                {
                    spectrumBars[i, j] = new RectangleNode();
                    spectrumBars[i, j].RectangleSize = new Vector2F(20.0f, 8.0f);
                    spectrumBars[i, j].CenterPosition = new Vector2F(10.0f, 4.0f);
                    spectrumBars[i, j].Position = new Vector2F(28.0f * i + 110.0f, 16.0f * j + 60.0f);
                    spectrumBars[i, j].Color = HSV2RGB((int)(22.5 * i), 255, 255);

                    Engine.AddNode(spectrumBars[i, j]);
                }

            // シークバーを示す図形ノードを作成し、エンジンに登録します。
            var seekBarLine = new LineNode();
            seekBarLine.Point1 = new Vector2F(0.0f, 0.0f);
            seekBarLine.Point2 = new Vector2F(500.0f, 0.0f);
            seekBarLine.Thickness = 5.0f;
            seekBarLine.Position = new Vector2F(70.0f, 400.0f);

            var seekBarDot = new CircleNode();
            seekBarDot.VertNum = 360;
            seekBarDot.Radius = 12.0f;
            seekBarDot.Position = new Vector2F(0.0f, 2.5f);

            seekBarLine.AddChildNode(seekBarDot);
            Engine.AddNode(seekBarLine);

            // ライトブルームのポストエフェクトを作成し、エンジンに登録します。
            var lightBloom = new PostEffectLightBloomNode();
            lightBloom.Intensity = 5.0f;
            lightBloom.Threshold = 0.1f;
            lightBloom.CameraGroup = 1;
            Engine.AddNode(lightBloom);

            // 音ファイルを読み込んで再生します。
            var sound = Sound.Load(@"sample.ogg", false);
            var soundId = Engine.Sound.Play(sound);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while(Engine.DoEvents())
            {
                // スペクトル情報を取得します。
                var spectrum = Engine.Sound.GetSpectrum(soundId, 1024, FFTWindow.Blackman);
                
                // スペクトル情報を区分ごとに合計し、スペクトルバーにその値を反映させます。
                for(int i = 0; i < 16; ++i)
                {
                    var amplitude = spectrum.Skip(i * 8).Take(8).Average();
                    for(int j = 0; j < 16; ++j)
                    {
                        var color = spectrumBars[i, 15 - j].Color;
                        color.A = (byte)((amplitude > j * 4.5) ? 255 : 0);
                        spectrumBars[i, 15 - j].Color = color;
                    }
                }

                // スペクトル情報を全て平均し、ライトブルームの光の強さに使用します。
                var amplitudeTotal = spectrum.Average();
                lightBloom.Exposure = amplitudeTotal * 0.5f;

                // 曲の長さと再生位置を取得します。
                var songLength = sound.Length;
                var songPosition = Engine.Sound.GetPlaybackPosition(soundId);

                // 曲の長さと再生位置を、シークバーに反映させます。
                seekBarDot.Position = new Vector2F(songPosition / songLength * 500.0f, 2.5f);

                // Altseed を更新します。
                Engine.Update();

                // 音が止まっていたらメインループを終了します。
                if(!Engine.Sound.GetIsPlaying(soundId)) break;
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}
