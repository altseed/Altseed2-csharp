using Altseed2;

namespace Sample
{
    class ColliderVisualization
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Collision", 640, 480);

            // 衝突判定が行われるノードの親ノードを作成します。
            var scene = new Node();

            // コライダを自動処理するノードをシーンに登録します。
            scene.AddChildNode(new CollisionManagerNode());


            // 衝突判定を持つSpriteNodeを生成します。
            var texture = Texture2D.Load(@"TestData\IO\AltseedPink256.png");
            var sprite = new SpriteNode()
            {
                Position = new Vector2F(200f, 200f),
                Scale = new Vector2F(0.5f, 0.5f),
                Texture = texture,
                CenterPosition = texture.Size / 2,
            };

            // 円形コライダノードを生成します。
            var collider = new CircleColliderNode()
            {
                Radius = texture.Size.X / 2,
            };

            // colliderの衝突判定を視覚化できるノードを生成します。
            var visualizer = ColliderVisualizeNodeFactory.Create(collider);

            // エンジンにノードを追加します。
            scene.AddChildNode(sprite);
            sprite.AddChildNode(collider);
            collider.AddChildNode(visualizer);
            Engine.AddNode(scene);

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