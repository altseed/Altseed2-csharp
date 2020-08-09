using Altseed2;

namespace Collider
{
    class ColliderDemonstration
    {
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            Engine.Initialize("~ Altseed2 DEMO ~", 640, 480);

            // 移動するスプライトを作って、エンジンに登録します。
            var sprite1 = new CollidableSprite();
            Engine.AddNode(sprite1);

            // 固定するスプライトを作って、エンジンに登録します。
            var sprite2 = new CollidableSprite();
            sprite2.Position = new Vector2F(480, 320);
            Engine.AddNode(sprite2);

            // コライダを自動処理するノードをシーンに登録します。
            var collisionManager = new CollisionManagerNode();
            Engine.AddNode(collisionManager);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // スプライトの描画位置を更新します。
                sprite1.Position = Engine.Mouse.Position;

                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }

    // 衝突判定機能を持ったスプライトを描画するクラス
    class CollidableSprite : SpriteNode, ICollisionEventReceiver
    {
        public CollidableSprite()
        {
            // テクスチャ・大きさ・中心位置を設定します。
            Texture = Texture2D.Load(@"AltseedPink256.png");
            Scale = new Vector2F(0.4f, 0.4f);
            CenterPosition = Texture.Size.To2F() * 0.5f;

            // コライダを作成して子ノードとして登録します。
            var colliderNode = new CircleColliderNode();
            colliderNode.Radius = Texture.Size.X * 0.5f;
            AddChildNode(colliderNode);
        }

        // 衝突が開始された時に実行されます。
        void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
        {
            Color = new Color(255, 50, 50);
        }

        // 衝突が継続している時に実行されます。
        void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info) { }

        // 衝突が解除された時に実行されます。
        void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
        {
            Color = new Color(255, 255, 255);
        }
    }
}
