using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

using Altseed2;

namespace Sample
{
    public static class Viewer
    {
        private static List<Sample> Samples;
        private static int Selected;
        private static string SamplesString;

        [STAThread]
        static void Main(string[] args)
        {
            Samples = new List<Sample>();
            Samples.Add(new Sample("Sprite", "SpriteNode を使ってテクスチャを描画します。", typeof(Sprite)));
            Samples.Add(new Sample("Text", "TextNode を使って文字列を描画します。", typeof(TextSample)));
            Samples.Add(new Sample("ImageGlyph", "ImageGlyph を使って絵文字を描画します。", typeof(ImageTextSample)));
            Samples.Add(new Sample("Camera", "CameraNode を使って描画対象を設定して描画します。", typeof(Camera)));
            Samples.Add(new Sample("RenderTexture", "描画結果を再利用します。", typeof(Camera_RenderTexture)));
            Samples.Add(new Sample("SE", "効果音を再生します。", typeof(SoundSE)));
            Samples.Add(new Sample("BGM", "BGM を再生します。", typeof(SoundBGM)));
            Samples.Add(new Sample("BGMLoop", "BGM をループ再生します。", typeof(SoundLoop)));
            Samples.Add(new Sample("StaticFile", "StaticFile を使って、ファイルを読み込みます。", typeof(FileStaticFile)));
            Samples.Add(new Sample("StreamFile", "StreamFile を使って、ファイルを読み込みます。", typeof(FileStreamFile)));
            Samples.Add(new Sample("Serialization", "バイナリデータシリアライズのサンプルです。", typeof(Serialization)));
            Samples.Add(new Sample("MouseCursor", "マウスカーソル設定のサンプルです。", typeof(MouseCursor)));
            Samples.Add(new Sample("Collision", "衝突の実装を行います。", typeof(Collision)));
            Samples.Add(new Sample("CollisionVisualizer", "衝突範囲の描画を行います。", typeof(ColliderVisualization)));
            Samples.Add(new Sample("JoystickAxis", "ジョイスティックのアナログ入力を行います。", typeof(JoystickAxis)));
            Samples.Add(new Sample("JoystickButton", "ジョイスティックのボタン入力を行います。", typeof(JoystickButton)));
            // Samples.Add(new Sample("JoystickVibrate", "ジョイスティックの振動を行います。", typeof(JoystickVibrate)));
            Samples.Add(new Sample("Keyboard", "キーボード入力を行います。", typeof(Keyboard)));
            Samples.Add(new Sample("Mouse", "マウス入力を行います。", typeof(Mouse)));
            Samples.Add(new Sample("MouseCursor", "マウスカーソルを変更します。", typeof(MouseCursor)));
            Samples.Add(new Sample("ShapeNode", "図形ノードを描画します。", typeof(ShapeNode)));

            Samples.Add(new Sample("PostEffect/GrayScale", "グレースケールのポストエフェクトを適用します。", typeof(PostEffectGrayScale)));
            Samples.Add(new Sample("PostEffect/Sepia", "セピアのポストエフェクトを適用します。", typeof(PostEffectSepia)));
            Samples.Add(new Sample("PostEffect/GaussianBlur", "ガウスぼかしのポストエフェクトを適用します。", typeof(PostEffectGaussianBlur)));
            Samples.Add(new Sample("PostEffect/LightBloom", "ライトブルームのポストエフェクトを適用します。", typeof(PostEffectLightBloom)));
            Samples.Add(new Sample("CustomPostEffect", "自作のポストエフェクトを適用します。", typeof(CustomPostEffect)));

            SamplesString = string.Join('\t', Samples.Select(s => s.Name));

            if (args.Length != 1) ShowViewer();
            else
            {
                var s = Samples.FirstOrDefault(s => s.TypeName == args[0]);
                s?.Run();
            }
        }

        private static void ShowViewer()
        {
            var config = new Configuration()
            {
                ToolEnabled = true,
                FileLoggingEnabled = true,
            };
            if (!Engine.Initialize("Altseed2 サンプルビュワー", 640, 480, config)) return;

            Engine.Tool.AddFontFromFileTTF(@"mplus-1m-regular.ttf", 20, ToolGlyphRanges.Japanese);

            while (Engine.DoEvents())
            {
                if (Engine.Tool.BeginFullScreen(0))
                {
                    Engine.Tool.ListBox("", ref Selected, SamplesString, 8);

                    var selectedSample = Samples[Selected];
                    Engine.Tool.Text($"{ selectedSample.Name}\n{selectedSample.Description}");
                    if (Engine.Tool.Button("実行")) selectedSample.CreateProcess();
                    Engine.Tool.End();
                }
                Engine.Update();
            }

            Engine.Terminate();
        }
    }

    /// <summary>
    /// サンプルの情報を表します。
    /// </summary>
    class Sample
    {
        /// <summary>
        /// サンプルのタイトルを取得します。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// サンプルの説明文を取得します。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// サンプルを実装するクラスの型の完全修飾名を取得します。
        /// </summary>
        public string TypeName { get; private set; }

        public Sample(string name, string description, Type type)
        {
            Name = name;
            Description = description;
            TypeName = type.FullName;
        }

        /// <summary>
        /// サンプルを実行するプロセスを起動します。
        /// </summary>
        /// <returns></returns>
        public bool CreateProcess()
        {
            string command = "dotnet";
            string arguments = $"{Assembly.GetExecutingAssembly().Location} {TypeName}";
            try
            {
                var process = new Process();
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                var result = process.Start();
                if (!result) return false;
            }
            catch (PlatformNotSupportedException _)
            {
                return Process.Start(command, arguments) != null;
            }

            return true;
        }

        /// <summary>
        /// サンプルを実装するクラスの Main メソッドを実行します。
        /// </summary>
        public void Run()
        {
            var type = Type.GetType(TypeName);
            var mainMethod = type?.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            mainMethod?.Invoke(null, new[] { new string[] { } });
        }
    }
}
