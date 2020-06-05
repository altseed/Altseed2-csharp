using System;
using System.Text;

using Altseed;

namespace Sample
{
    class FileStaticFile
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("StaticFile", 640, 480)) return;

            // ファイルを読み込みます。
            var staticFile = StaticFile.Create(@"TestData\IO\test.txt");

            // バイト配列をUTF8として、string型に変換します。
            var text = Encoding.UTF8.GetString(staticFile.Buffer);

            // コンソールに出力します。
            Console.WriteLine(text);

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}
