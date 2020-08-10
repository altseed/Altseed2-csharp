using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altseed2.Test
{
    [TestFixture]
    class Async
    {
        [Test, Apartment(ApartmentState.STA)]
        public void CreateStaticFile()
        {
            if (System.IO.Directory.Exists("tmp"))
                System.IO.Directory.Delete("tmp", true);

            System.IO.Directory.CreateDirectory("tmp");
            foreach (var i in Enumerable.Range(0, 1000))
            {
                System.IO.File.Copy("../Core/TestData/IO/test.txt", "tmp/test" + i + ".txt");
            }
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode() { Font = font, Text = "" };
            Engine.AddNode(node);

            var tasks = new List<Task<StaticFile>>();
            foreach (var i in Enumerable.Range(0, 1000))
            {
                tasks.Add(StaticFile.CreateAsync("tmp/test" + i + ".txt"));
            }

            while (Engine.DoEvents())
            {
                node.Text = $"Static File: {tasks.Count(obj => obj.IsCompleted)}/{tasks.Count()}";
                Assert.True(Engine.Update());

                if (tasks.All(obj => obj.IsCompleted))
                    break;
            }

            foreach (var i in Enumerable.Range(0, 1000))
            {
                Assert.AreEqual(tasks[0].Result.Size, tasks[i].Result.Size);
            }

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void LoadTexture()
        {
            if (System.IO.Directory.Exists("tmp"))
                System.IO.Directory.Delete("tmp", true);

            System.IO.Directory.CreateDirectory("tmp");
            foreach (var i in Enumerable.Range(0, 100))
            {
                System.IO.File.Copy("../Core/TestData/IO/AltseedPink.png", "tmp/test" + i + ".png");
            }
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode() { Font = font, Text = "", CameraGroup = 1 << 0 };
            Engine.AddNode(node);

            var camera = new CameraNode();
            camera.Group = 0;
            Engine.AddNode(camera);

            var tasks = new List<Task<Texture2D>>();
            foreach (var i in Enumerable.Range(0, 100))
            {
                tasks.Add(Texture2D.LoadAsync("tmp/test" + i + ".png"));
            }

            while (Engine.DoEvents())
            {
                node.Text = $"Loading Texture: {tasks.Count(obj => obj.IsCompleted)}/{tasks.Count()}";
                Assert.True(Engine.Update());

                if (tasks.All(obj => obj.IsCompleted))
                    break;
            }

            foreach (var i in Enumerable.Range(0, 100))
            {
                Assert.AreNotEqual(tasks[0].Result, null);
            }

            int count = 0;

            var sprite = new SpriteNode();
            sprite.Position = new Vector2F(300, 300);
            sprite.Texture = tasks[0].Result;
            sprite.Src = new RectF(new Vector2F(), tasks[0].Result.Size);
            sprite.CenterPosition = sprite.Texture.Size / 2;
            sprite.CameraGroup = 1 << 0;
            Engine.AddNode(sprite);

            while (Engine.DoEvents() && count < 100)
            {
                node.Text = $"Shown Texture: {count}/{tasks.Count()}";
                sprite.Texture = tasks[count].Result;
                Assert.True(Engine.Update());
                count++;
            }

            tc.End();
        }
    }
}
