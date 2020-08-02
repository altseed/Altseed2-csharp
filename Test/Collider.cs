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

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.Position = new Vector2F(200, 200);
            node.CenterPosition = texture.Size / 2;
            node.Scale = new Vector2F(0.2f, 0.2f);
            Engine.AddNode(node);

            var col = CircleCollider.Create();
            col.Radius = 200 * 0.2f;
            col.Position = node.Position;

            var node2 = new SpriteNode();
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node2.Texture = texture;
            node2.Position = new Vector2F(200, 200);
            node2.CenterPosition = texture.Size / 2;
            node2.Scale = new Vector2F(0.2f, 0.2f);
            Engine.AddNode(node2);
            var col2 = CircleCollider.Create();
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
        public void AutoCollisionSystem_Circle()
        {
            var tc = new TestCore();
            tc.Init();
            //tc.Duration = int.MaxValue;

            var texture = Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var scene = new Altseed2.Node();
            var manager = new CollisionManagerNode();
            scene.AddChildNode(manager);

            Engine.AddNode(scene);

            var player = new Player_Circle(texture);
            scene.AddChildNode(player);

            var comparison = new SpriteNode()
            {
                Texture = texture,
                CenterPosition = texture.Size / 2,
                Position = new Vector2F(500f, 100f),
                Scale = new Vector2F(0.8f, 0.8f),
            };
            var colliderNode = new CircleColliderNode()
            {
                Radius = texture.Size.X / 2,
                CenterPosition = new Vector2F(100, 100),
            };
            comparison.AddChildNode(colliderNode);
            colliderNode.AddChildNode(ColliderVisualizeNodeFactory.Create(colliderNode));
            scene.AddChildNode(comparison);

            tc.LoopBody(null, x =>
            {
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push) tc.Duration = 0;
                if (x == 10)
                {
                    //Assert.True(manager.ContainsCollider(colliderNode));
                    //Assert.AreEqual(manager.ColliderCount, 2);
                }
            });
            tc.End();
        }

        private sealed class Player_Circle : SpriteNode, ICollisionEventReceiver
        {
            private readonly CircleColliderNode node;

            private readonly TextNode text;

            public Player_Circle(Texture2D texture)
            {
                Engine.AddNode(text = new TextNode()
                {
                    Font = Font.LoadDynamicFontStrict("TestData/Font/mplus-1m-regular.ttf", 40),
                    Position = new Vector2F(0, 0),
                    Color = new Color(255, 255, 255, 255),
                });

                Texture = texture;
                Position = new Vector2F(0f, 300f);
                CenterPosition = texture.Size / 2;
                node = new CircleColliderNode()
                {
                    Radius = texture.Size.X / 2
                };
                node.AddChildNode(ColliderVisualizeNodeFactory.Create(node));
                AddChildNode(node);
            }

            protected override void OnUpdate()
            {
                Position += new Vector2F(5f, 0f);
                //if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) Position += new Vector2F(0.0f, -2.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) Position += new Vector2F(0.0f, 2.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) Position += new Vector2F(-2.0f, 0.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) Position += new Vector2F(2.0f, 0.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Num1) == ButtonState.Hold) Angle++;
                //if (Engine.Keyboard.GetKeyState(Key.Num2) == ButtonState.Hold) Angle--;
            }

            void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
            {
                text.Text = "Colliding";
            }

            void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
            {
                text.Text = string.Empty;
            }

            void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
            {

            }
        }

        private readonly static Vector2F[] array = new[] {
            default,
            new Vector2F(-225f, 0f), new Vector2F(-75f, -75f),
            new Vector2F(0f, -225f), new Vector2F(75f, -75f),
            new Vector2F(225f, 0f), new Vector2F(75f, 75f),
            new Vector2F(0f, 225f), new Vector2F(-75f, 75f),
            new Vector2F(-225f, 0f), default
        };

        [Test, Apartment(ApartmentState.STA)]
        public void AutoCollisionSystem_Polygon()
        {
            var tc = new TestCore();
            tc.Init();
            //tc.Duration = int.MaxValue;

            var texture = Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var scene = new Altseed2.Node();
            var manager = new CollisionManagerNode();
            scene.AddChildNode(manager);

            Engine.AddNode(scene);

            var player = new Player_Polygon(texture);
            player.Angle += 45f;

            scene.AddChildNode(player);

            var comparison = new SpriteNode()
            {
                Texture = texture,
                CenterPosition = texture.Size / 2,
                Position = new Vector2F(580f, 300f),
                Scale = new Vector2F(0.8f, 0.8f),
            };
            var colliderNode = new PolygonColliderNode
            {
                Vertexes = array,
                CenterPosition = texture.Size.To2F()*0.2f,
            };
            colliderNode.AddChildNode(ColliderVisualizeNodeFactory.Create(colliderNode));
            comparison.AddChildNode(colliderNode);

            scene.AddChildNode(comparison);

            tc.LoopBody(null, x =>
            {
                player.Angle++;
                comparison.Angle++;
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push) tc.Duration = 0;
                if (x == 10)
                {
                    Assert.True(manager.ContainsCollider(colliderNode));
                    Assert.AreEqual(manager.ColliderCount, 2);
                }
            });
            tc.End();
        }
        private sealed class Player_Polygon : SpriteNode, ICollisionEventReceiver
        {
            private readonly PolygonColliderNode node;
            private readonly TextNode text = new TextNode()
            {
                Font = Font.LoadDynamicFontStrict("TestData/Font/mplus-1m-regular.ttf", 40),
                Position = new Vector2F(0, 0),
                Color = new Color(255, 255, 255, 255),
            };
            public Player_Polygon(Texture2D texture)
            {
                Engine.AddNode(text);
                Texture = texture;
                CenterPosition = texture.Size / 2;
                Position = new Vector2F(220f, 300f);
                node = new PolygonColliderNode()
                {
                    Vertexes = array
                };
                node.AddChildNode(ColliderVisualizeNodeFactory.Create(node));
                AddChildNode(node);
            }
            //protected override void OnUpdate()
            //{
            //    if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) Position += new Vector2F(0.0f, -2.0f);
            //    if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) Position += new Vector2F(0.0f, 2.0f);
            //    if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) Position += new Vector2F(-2.0f, 0.0f);
            //    if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) Position += new Vector2F(2.0f, 0.0f);
            //    if (Engine.Keyboard.GetKeyState(Key.Num1) == ButtonState.Hold) Angle++;
            //    if (Engine.Keyboard.GetKeyState(Key.Num2) == ButtonState.Hold) Angle--;
            //}
            void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
            {
                text.Text = "Colliding";
            }
            void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
            {
                text.Text = string.Empty;
            }
            void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
            {

            }
        }

        [Test, Apartment(ApartmentState.STA)]
        public void AutoCollisionSystem_Rectangle()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var scene = new Altseed2.Node();
            var manager = new CollisionManagerNode();
            scene.AddChildNode(manager);

            Engine.AddNode(scene);

            var player = new Player_Rectangle(texture);

            scene.AddChildNode(player);

            var comparison = new SpriteNode()
            {
                Texture = texture,
                CenterPosition = texture.Size / 2,
                Position = new Vector2F(500f, 200f),
                Scale = new Vector2F(0.8f, 0.8f),
            };
            var colliderNode = new RectangleColliderNode()
            {
                RectangleSize = texture.Size,
                CenterPosition = texture.Size / 2,
            };
            colliderNode.AddChildNode(ColliderVisualizeNodeFactory.Create(colliderNode));
            comparison.AddChildNode(colliderNode);

            scene.AddChildNode(comparison);

            tc.LoopBody(null, x =>
            {
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push) tc.Duration = 0;
                if (x == 10)
                {
                    Assert.True(manager.ContainsCollider(colliderNode));
                    Assert.AreEqual(manager.ColliderCount, 2);
                }
            });
            tc.End();
        }
        private sealed class Player_Rectangle : SpriteNode, ICollisionEventReceiver
        {
            private readonly RectangleColliderNode node;
            private readonly TextNode text = new TextNode()
            {
                Font = Font.LoadDynamicFontStrict("TestData/Font/mplus-1m-regular.ttf", 40)
            };
            public Player_Rectangle(Texture2D texture)
            {
                Engine.AddNode(text);
                Texture = texture;
                CenterPosition = texture.Size / 2;
                Position = new Vector2F(0f, 300f);
                node = new RectangleColliderNode()
                {
                    RectangleSize = texture.Size,
                    CenterPosition = texture.Size / 2,
                };
                node.AddChildNode(ColliderVisualizeNodeFactory.Create(node));
                AddChildNode(node);
            }
            protected override void OnUpdate()
            {
                Position += new Vector2F(5f, 0f);
                //if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold) Position += new Vector2F(0.0f, -2.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold) Position += new Vector2F(0.0f, 2.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold) Position += new Vector2F(-2.0f, 0.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold) Position += new Vector2F(2.0f, 0.0f);
                //if (Engine.Keyboard.GetKeyState(Key.Num1) == ButtonState.Hold) Angle++;
                //if (Engine.Keyboard.GetKeyState(Key.Num2) == ButtonState.Hold) Angle--;
            }
            void ICollisionEventReceiver.OnCollisionEnter(CollisionInfo info)
            {
                text.Text = "Colliding";
            }
            void ICollisionEventReceiver.OnCollisionExit(CollisionInfo info)
            {
                text.Text = string.Empty;
            }
            void ICollisionEventReceiver.OnCollisionStay(CollisionInfo info)
            {

            }
        }
    }
}