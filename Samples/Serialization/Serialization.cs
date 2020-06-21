using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using Altseed2;

namespace Sample
{
    class Serialization
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("Serialization", 640, 480)) return;

            // シリアライズ結果を保存するファイルのパス
            var path = "SerializeSample.bin";

            // StaticFileを生成。
            var file1 = StaticFile.Create(@"TestData\IO\test.txt");

            // fileをシリアライズします。
            Serialize(path, file1);

            // シリアライズされたfileをデシリアライズします。
            var file2 = (StaticFile)DeSerialize(path);

            // バイト配列をUTF8として、string型に変換します。
            var text1 = Encoding.UTF8.GetString(file1.Buffer);
            var text2 = Encoding.UTF8.GetString(file2.Buffer);

            // テキストをコンソールに出力します。
            Console.WriteLine("text1 : {0}", text1);
            Console.WriteLine("text2 : {0}", text2);

            // Altseed の終了処理をします。
            Engine.Terminate();
        }

        // シリアライズを行うメソッド
        static void Serialize(string path, object value)
        {
            // バイナリシリアライズに使用するフォーマッターを生成。
            var formatter = new BinaryFormatter();

            // シリアライズに使用するストリームを生成。
            using var stream = new FileStream(path, FileMode.Create);

            // valueをシリアライズする。
            formatter.Serialize(stream, value);
        }

        // デシリアライズを行うメソッド
        static object DeSerialize(string path)
        {
            // バイナリデシリアライズに使用するフォーマッターを生成。
            var formatter = new BinaryFormatter();

            // デシリアライズに使用するストリームを生成。
            using var stream = new FileStream(path, FileMode.Open);

            // デシリアライズを実行
            var result = formatter.Deserialize(stream);

            // デシリアライズの結果を返す。
            return result;
        }
    }
}
