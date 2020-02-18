using System;
using System.Diagnostics;
using System.Text;
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
            obj1.AddComponent(new TextureComponent()
            {
                Texture = texture
            });
            var obj2 = new TaggedObject()
            {
                DrawingPriority = 2,
                Tag = "2"
            };
            obj2.AddComponent(new TextureComponent()
            {
                Texture = texture
            });
            var obj3 = new TaggedObject()
            {
                DrawingPriority = 3,
                Tag = "3"
            };
            obj3.AddComponent(new TextureComponent()
            {
                Texture = texture
            });
            scene.AddObject(obj1);
            scene.AddObject(obj2);
            scene.AddObject(obj3);

            while (Engine.DoEvents())
            {
                Assert.True(Engine.Graphics.BeginFrame());

                Engine.Update();

                Assert.True(Engine.Graphics.EndFrame());
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;
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
