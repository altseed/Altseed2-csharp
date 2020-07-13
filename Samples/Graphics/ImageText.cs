using System;
using Altseed2;

namespace Sample
{
    public class ImageTextSample
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            if (!Engine.Initialize("TextNode", 640, 480)) return;

            // フォントファイルを読み込みます。
            var font = Font.LoadDynamicFont(@"TestData/Font/mplus-1m-regular.ttf", 48);

            // テクスチャ追加対応フォントを作成します。
            var imageFont = Font.CreateImageFont(font);

            // 絵文字にする画像を読み込みます。
            var textImage = Texture2D.Load(@"TestData/IO/AltseedPink.png");

            // 特定の文字に対応する絵文字を登録します。
            imageFont.AddImageGlyph('○', textImage);

            // テキストを描画するノードを作成します。
            var node = new TextNode();

            // フォントを設定します。
            node.Font = imageFont;

            // 描画する文字列を設定します。
            node.Text = "Altseed2 ○ Altseed2";

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
