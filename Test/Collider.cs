using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class Collider
    {
        [Test, Apartment(ApartmentState.STA)]
        public void SpriteNode()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.AdjustSize();
            node.Position = new Vector2F(200, 200);
            node.CenterPosition = texture.Size / 2;
            node.Scale = new Vector2F(0.2f, 0.2f);
            Engine.AddNode(node);

            var col = new CircleCollider();
            col.Radius = 200 * 0.2f;
            col.Position = node.Position;

            var node2 = new SpriteNode();
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node2.Texture = texture;
            node2.AdjustSize();
            node2.Position = new Vector2F(200, 200);
            node2.CenterPosition = texture.Size / 2;
            node2.Scale = new Vector2F(0.2f, 0.2f);
            Engine.AddNode(node2);
            var col2 = new CircleCollider();
            col2.Radius = 200 * 0.2f;
            col2.Position = node.Position;

            tc.LoopBody(c =>
            {
                node2.Position = col2.Position = Engine.Mouse.Position;
                if (col.GetIsCollidedWith(col2))
                {
                    node2.Angle++;
                }
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void AutoCollisionSystem()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var scene = new Altseed2.Node();
            var manager = new CollisionManagerNode();
            scene.AddChildNode(manager);

            Engine.AddNode(scene);

            var player = new Player(texture);

            scene.AddChildNode(player);

            var comparison = new SpriteNode()
            {
                Texture = texture,
                Pivot = new Vector2F(0.5f, 0.5f),
                Position = new Vector2F(500f, 300f)
            };
            comparison.AdjustSize();
            var colliderNode = new CircleColliderNode()
            {
                Radius = texture.Size.X / 2
            };
            comparison.AddChildNode(colliderNode);

            scene.AddChildNode(comparison);

            tc.LoopBody(null, x =>
            {
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) tc.Duration = 0;
                if (x == 10)
                {
                    Assert.True(manager.ContainsCollider(colliderNode));
                    Assert.AreEqual(manager.ColliderCount, 2);
                }
            });
            tc.End();
        }
        private sealed class Player : SpriteNode, ICollisionEventReceiver
        {
            private readonly ColliderNode node;
            public Player(Texture2D texture)
            {
                Texture = texture;
                Pivot = new Vector2F(0.5f, 0.5f);
                Position = new Vector2F(0f, 300f);
                AdjustSize();
                node = new CircleColliderNode()
                {
                    Radius = texture.Size.X / 2
                };
                AddChildNode(node);
            }
            protected override void OnUpdate()
            {
                Position += new Vector2F(5f, 0f);
                if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) Position += new Vector2F(0.0f, -2.0f);
                if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) Position += new Vector2F(0.0f, 2.0f);
                if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) Position += new Vector2F(-2.0f, 0.0f);
                if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) Position += new Vector2F(2.0f, 0.0f);
            }
            void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
            {
                Color = new Color(100, 100, 100);
            }
            void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
            {
                Color = new Color(255, 255, 255);
            }
            void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
            {
                Angle++;
            }
        }
    }
}