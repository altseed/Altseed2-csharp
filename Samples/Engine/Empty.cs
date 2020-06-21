using Altseed2;

class Empty
{
    static void Main(string[] args)
    {
        // Altseed2 を起動する前にいくつかの設定ができます。
        var config = new Configuration()
        {
            // 垂直同期信号を待つかどうかを取得または設定します。
            WaitVSync = true,
        };

        // Altseed2 を初期化します。
        Engine.Initialize("Empty", 640, 480, config);

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