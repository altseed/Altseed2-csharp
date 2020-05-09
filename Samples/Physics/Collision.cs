using Altseed;
using System;

namespace Sample
{
    class Collision
    {
        static void Main(string[] args)
        {
            // Altseed を初期化します。
            Engine.Initialize("Collision", 640, 480);

            // 衝突判定を行うノードを登録するシーンとなるノードを生成します。
            var scene = new Node();

            // コライダを自動処理するノードをシーンに登録します。
            scene.AddChildNode(new CollisionManagerNode());

            // 衝突判定を持つスプライトノードを生成します。
            var character1 = new CollidableSprite()
            {
                Position = new Vector2F(0, 100)
            };

            // 衝突時のイベントを実行する衝突判定を持つスプライトノードを生成します。
            var character2 = new EventRaisedCollidableSprite()
            {
                Position = new Vector2F(300, 100)
            };

            // シーンにキャラクターを追加
            scene.AddChildNode(character1);
            scene.AddChildNode(character2);

            // シーンにエンジンを追加
            Engine.AddNode(scene);

            // メインループ。
            // Altseed のウインドウが閉じられると終了します。
            while (Engine.DoEvents())
            {
                // 右側に移動させる
                character1.Position += new Vector2F(5, 0);

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
            // テクスチャを読み込みます
            Texture = Texture2D.Load(@"TestData\IO\AltseedPink256.png");

            // 半径を設定します
            colliderNode.Radius = Texture.Size.X / 2;

            // 中心座標を設定します
            CenterPosition = Texture.Size / 2;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            colliderNode.Position = Position;
        }
    }

    // 衝突時の内容を実装できるクラス
    class EventRaisedCollidableSprite : CollidableSprite, ICollisionEventReceiver
    {
        // 衝突が開始された時に実行
        void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
        {
            Console.WriteLine("Collision started.");
        }

        // 衝突が継続している時に実行
        void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
        {
            Console.WriteLine("Collision is keeped.");
        }

        // 衝突が解除された時に実行
        void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
        {
            Console.WriteLine("Collision finished.");
        }
    }
}