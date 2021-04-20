using System;

using Altseed2;

namespace Sample
{
    public class TextSample
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("TextNode", 640, 480)) return;

            // フォントファイルを読み込みます。
            var font = Font.LoadDynamicFont(@"TestData/Font/mplus-1m-regular.ttf", 64);

            // テキストを描画するノードを作成します。
            var node = new TextNode();

            // フォントを設定します。
            node.Font = font;

            // フォントサイズ
            node.FontSize = 48;

            // 描画する文字列を設定します。
            node.Text = "Hello World!";

            // ノードを登録します。
            Engine.AddNode(node);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }
}
