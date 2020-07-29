using Altseed2;

namespace Sample
{
    class ShapeNode
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("ShapeNode", 640, 480);

            // 円を描画するノード 
            var circle = new CircleNode()
            {
                Color = new Color(255, 100, 100),
                Radius = 30f,
                Position = new Vector2F(100f, 300f),
                VertNum = 30
            };

            // 円弧を描画するノード
            var arc = new ArcNode()
            {
                Color = new Color(100, 255, 100),
                Radius = 25f,
                Position = new Vector2F(300f, 100f),
                StartDegree = 30f,
                EndDegree = 150f,
                VertNum = 30
            };

            // 直線を描画するノード
            var line = new LineNode()
            {
                Color = new Color(100, 100, 255),
                Point1 = new Vector2F(200f,150f),
                Point2 = new Vector2F(400f, 350f),
                Thickness = 5f
            };

            // 短形を描画するノード
            var rectangle = new RectangleNode()
            {
                Color = new Color(255, 255, 100),
                Position = new Vector2F(300f, 400f),
                RectangleSize = new Vector2F(50f, 50f)
            };

            // 三角形を描画するノード
            var triangle = new TriangleNode()
            {
                Color = new Color(255, 100, 255),
                Point1 = new Vector2F(50f, 50f),
                Point2 = new Vector2F(100f, 50f),
                Point3 = new Vector2F(50f, 100f),
            };

            // エンジンにノードを追加します。
            Engine.AddNode(circle);
            Engine.AddNode(arc);
            Engine.AddNode(line);
            Engine.AddNode(rectangle);
            Engine.AddNode(triangle);

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