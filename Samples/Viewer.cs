using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

using Altseed;

namespace Sample
{
    public static class Viewer
    {
        private static Dictionary<string, Sample> Samples;

        [STAThread]
        static void Main(string[] args)
        {
            var list = new List<Sample>();
            list.Add(new Sample("Sprite", "SpriteNodeを使ってテクスチャを描画します。", typeof(Sprite)));
            list.Add(new Sample("SE", "効果音を再生します。", typeof(SoundSE)));
            list.Add(new Sample("BGM", "BGMを再生します。", typeof(SoundBGM)));
            list.Add(new Sample("BGMLoop", "BGMをループ再生します。", typeof(SoundLoop)));
            list.Add(new Sample("StaticFile", "StaticFileを使って、ファイルを読み込みます。", typeof(FileStaticFile)));
            list.Add(new Sample("StreamFile", "StreamFileを使って、ファイルを読み込みます。", typeof(FileStreamFile)));
            list.Add(new Sample("Serialization", "バイナリデータシリアライズのサンプルです。", typeof(Serialization)));
            list.Add(new Sample("MouseCursor", "マウスカーソル設定のサンプルです。", typeof(MouseCursor)));
            list.Add(new Sample("Collision", "衝突の実装を行います。", typeof(Collision)));

            Samples = list.ToDictionary(s => s.TypeName);

            if (args.Length != 1) ShowViewer();
            else if (Samples.TryGetValue(args[0], out var s)) s.Run();
        }

        private static void ShowViewer()
        {
            var config = new Configuration()
            {
                ToolEnabled = true,
            };
            if (!Engine.Initialize("Altseed2 サンプルビュワー", 640, 480, config)) return;

            while (Engine.DoEvents())
            {
                if (Engine.Tool.BeginFullScreen(0))
                {
                    foreach (var s in Samples.Values)
                    {
                        var size = new Vector2F(96, 24);
                        if (Engine.Tool.Button(s.Name, size))
                            s.CreateProcess();
                    }
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
