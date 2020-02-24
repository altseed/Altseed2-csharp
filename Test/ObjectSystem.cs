using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class ObjectSystem
    {
        public static DefaultTraceListener Listener { get; } = new DefaultTraceListener()
        {
            LogFileName = "debug_ObjectSystem.txt"
        };
        [Test, Apartment(ApartmentState.STA)]
        public void DrawingPriority()
        {
            Assert.True(Engine.Initialize("ObjectSystem Test", 800, 600, new Configuration()));

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            var texture2 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.jpg");
            Assert.NotNull(texture);

            var scene = Engine.CurrentScene;
            var obj1 = new TaggedObject()
            {
                DrawingPriority = 1,
                Tag = "1",
            };

            var tr = new Matrix44F();
            tr.SetTranslation(0, 0, 0);
            var comp1 = new SpriteComponent()
            {
                Texture = texture,
                Src = new RectF(200, 0, 200, 200),
                Transform = tr,
            };
            obj1.AddComponent(comp1);
            scene.AddObject(obj1);

            var obj2 = new TaggedObject()
            {
                DrawingPriority = 2,
                Tag = "2",
            };
            tr = new Matrix44F();
            tr.SetTranslation(200, 200, 0);
            var comp2 = new SpriteComponent()
            {
                Texture = texture2,
                Src = new RectF(100, 100, 200, 200),
                Transform = tr,
            };
            obj2.AddComponent(comp2);
            scene.AddObject(obj2);

            var obj3 = new TaggedObject()
            {
                DrawingPriority = 3,
                Tag = "3",
            };
            tr = new Matrix44F();
            tr.SetTranslation(400, 400, 0);
            var comp3 = new SpriteComponent()
            {
                Texture = texture,
                Src = new RectF(0, 200, 200, 200),
                Transform = tr,
            };
            obj3.AddComponent(comp3);
            scene.AddObject(obj3);

#if COUNT
            var count = 0;
#endif
            while (Engine.DoEvents()
#if COUNT
                 && count < 300
#endif
                )
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Update();
                
                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();
                Engine.Renderer.Render(cmdList);

                Assert.True(Engine.Graphics.EndFrame());
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;
#if COUNT
                count++;
#endif
            }

            Engine.Terminate();
        }

        private sealed class TaggedObject : Alject
        {
            public string Tag
            {
                get => _tag;
                set => _tag = value ?? throw new ArgumentNullException();
            }
            private string _tag;
            protected override void OnDrawn()
            {
                Listener.WriteLine(Tag);
            }
        }

        [Test, Apartment(ApartmentState.STA)]
        public void SceneChange()
        {
            Assert.True(Engine.Initialize("ObjectSystem Test", 800, 600, new Configuration()));

            var count = 0;

            while (Engine.DoEvents())
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Update();

                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();
                Engine.Renderer.Render(cmdList);

                Assert.True(Engine.Graphics.EndFrame());

                if (Engine.Keyboard.GetKeyState(Keys.A) == ButtonState.Push) Engine.ChangeScene(new TaggedScene(count.ToString()));

                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;

                count++;
            }

            Engine.Terminate();
        }

        private sealed class TaggedScene : Scene
        {
            public string Tag { get => _tag; set => _tag = value ?? throw new ArgumentNullException(); }
            private string _tag;
            public TaggedScene(string tag)
            {
                Tag = tag;
            }
            protected override void OnRegistered() => Listener.WriteLine($"{Tag}-Registered-1");
            protected override void OnStartUpdating() => Listener.WriteLine($"{Tag}-StartUpdate-2");
            protected override void OnStopUpdating() => Listener.WriteLine($"{Tag}-StopUpdate-6");
            protected override void OnTransitionBegin() => Listener.WriteLine($"{Tag}-TransitionBegin-5");
            protected override void OnTransitionFinished() => Listener.WriteLine($"{Tag}-TransitionFinish-3");
            protected override void OnUnRegistered() => Listener.WriteLine($"{Tag}-UnRegistered-7");
            protected override void OnUpdated() => Listener.WriteLine($"{Tag}-Update-4");
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ObjectInherit()
        {
            Assert.True(Engine.Initialize("ObjectSystem Test", 800, 600, new Configuration()));

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            var texture2 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.jpg");

            var scene = Engine.CurrentScene;

            var obj1 = new Alject()
            {
                IsInherited = true,
                DrawingPriority = 1
            };

            var tr = new Matrix44F();
            tr.SetTranslation(0, 0, 0);
            var comp1 = new SpriteComponent()
            {
                Texture = texture,
                Src = new RectF(200, 0, 200, 200),
                Transform = tr,
            };
            obj1.AddComponent(comp1);
            scene.AddObject(obj1);

            var obj2 = new Alject()
            {
                DrawingPriority = 2
            };
            tr = new Matrix44F();
            tr.SetTranslation(200, 200, 0);
            var comp2 = new SpriteComponent()
            {
                Texture = texture2,
                Src = new RectF(100, 100, 200, 200),
                Transform = tr,
            };
            obj2.AddComponent(comp2);
            scene.AddObject(obj2);

            var count = 0;

            while (Engine.DoEvents())
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Update();

                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();
                Engine.Renderer.Render(cmdList);

                if (count == 400)
                {
                    Listener.WriteLine("Changed");
                    Engine.ChangeScene(new Scene());
                }

                Assert.True(Engine.Graphics.EndFrame());

                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;

                count++;
            }

            Engine.Terminate();
        }
    }
}
