using Altseed2;

using System;

namespace Sample
{
    class Collision
    {
        static void Main(string[] args)
        {
            // Altseed2 を初期化します。
            Engine.Initialize("Collision", 640, 480);

            // 衝突判定が行われるノードの親ノードを作成します。
            var scene = new Node();

            // コライダを自動処理するノードをシーンに登録します。
            scene.AddChildNode(new CollisionManagerNode());

            // 衝突判定を持つスプライトノードを生成します。
            var node1 = new CollidableSprite()
            {
                Position = new Vector2F(0, 100)
            };

            // 衝突時のイベントを実行する衝突判定を持つスプライトノードを生成します。
            var node2 = new EventRaisedCollidableSprite()
            {
                Position = new Vector2F(300, 100)
            };

            // エンジンにノードを追加します。
            scene.AddChildNode(node1);
            scene.AddChildNode(node2);
            Engine.AddNode(scene);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // 右側に移動させる
                node1.Position += new Vector2F(5, 0);

                // Altseed を更新します。
                Engine.Update();
            }

            // Altseed の終了処理をします。
            Engine.Terminate();
        }
    }

    // 衝突判定が行われるノードのクラス
    class CollidableSprite : SpriteNode
    {
        // 円形コライダを持つノード
        private readonly CircleColliderNode colliderNode = new CircleColliderNode();

        // コンストラクタ
        public CollidableSprite()
        {
            // テクスチャを読み込みます。
            Texture = Texture2D.Load(@"TestData\IO\AltseedPink256.png");

            // 半径を設定します。
            colliderNode.Radius = Texture.Size.X / 2;

            // 中心を設定します。
            Pivot = new Vector2F(0.5f, 0.5f);

            AdjustSize();

            // コライダを登録します。
            AddChildNode(colliderNode);
        }

        // フレーム毎に実行されます。
        protected override void OnUpdate()
        {
            colliderNode.Position = Position;
        }
    }

    // 衝突時の内容を実装できるクラス
    class EventRaisedCollidableSprite : CollidableSprite, ICollisionEventReceiver
    {
        // 衝突が開始された時に実行されます。
        void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
        {
            Color = new Color(255, 50, 50);
        }

        // 衝突が継続している時に実行されます。
        void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
        {
            Console.WriteLine("Collision is keeped.");
        }

        // 衝突が解除された時に実行されます。
        void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
        {
            Color = new Color(255, 255, 255);
        }
    }
}