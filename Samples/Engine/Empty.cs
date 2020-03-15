using Altseed;

class Empty
{
    static void Main(string[] args)
    {
        // Altseed を初期化します。
        Engine.Initialize("Empty", 640, 480);

        // ここで画像などのデータを読み込んだりノードツリーを作成したりすることができます。

        // メインループ。
        // Altseed のウインドウが閉じられると終了します。
        while (Engine.DoEvents())
        {
            // ここに挙動をべた書きすることも可能です。

            // Altseed を更新します。
            Engine.Update();
        }

        // Altseed の終了処理をします。
        Engine.Terminate();
    }
}