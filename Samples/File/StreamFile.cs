using System;
using System.Text;

using Altseed2;

namespace Sample
{
    class FileStreamFile
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("StaticFile", 640, 480)) return;

            // ファイルを読み込みます。
            var streamFile = StreamFile.Create(@"TestData/IO/test.txt");

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // Altseedを更新します。
                Engine.Update();

                // 1バイト読み込む
                var size = streamFile.Read(1);

                // バイト配列をUTF8として、string型に変換します。
                var text = Encoding.UTF8.GetString(streamFile.TempBuffer);

                // コンソールに出力します。
                Console.WriteLine(text);

                // 新たに読み込んだデータが0なら終了させます。
                if (size == 0) break;
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}
