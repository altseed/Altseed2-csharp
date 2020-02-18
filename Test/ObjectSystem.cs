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
        public void Test()
        {
            var option = new CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false
            };

            Assert.True(Engine.Initialize("ObjectSystem Test", 800, 600, option));

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var scene = Engine.CurrentScene;
            var obj1 = new TaggedObject()
            {
                DrawingPriority = 1,
                Tag = "1"
            };
            var comp1 = new TextureComponent()
            {
                Texture = texture,
                Src = new RectF(200, 0, 200, 200)
            };
            obj1.AddComponent(comp1);
            scene.AddObject(obj1);
            var obj2 = new TaggedObject()
            {
                DrawingPriority = 2,
                Tag = "2"
            };
            var comp2 = new TextureComponent()
            {
                Texture = texture,
                Src = new RectF(0, 0, 400, 400)
            };
            obj2.AddComponent(comp2);
            scene.AddObject(obj2);
            var obj3 = new TaggedObject()
            {
                DrawingPriority = 3,
                Tag = "3"
            };
            var comp3 = new TextureComponent()
            {
                Texture = texture,
                Src = new RectF(0, 200, 200, 200)
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
        public sealed class TaggedObject : Alject
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
    }
}
