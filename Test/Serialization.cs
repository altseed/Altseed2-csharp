using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using NUnit.Framework;

namespace Altseed.Test
{
    internal static class FormatterExtension
    {
        internal static T Deserialize<T>(this BinaryFormatter formatter, Stream stream) => (T)formatter.Deserialize(stream);
    }
    [TestFixture]
    public class Serialization
    {
        private static void Serialize<T>(string path, T item)
        {
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, item);
        }

        private static T Deserialize<T>(string path)
        {
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Open);
            return formatter.Deserialize<T>(stream);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFile()
        {
            var tc = new TestCore();
            tc.Init();

            var file1 = Altseed.StaticFile.CreateStrict("../../Core/TestData/IO/test.txt");

            const string path = "Serialization/StaticFile.bin";

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StaticFile>(path);
            file2.Save("Serialization/StaticFile.txt");

            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Debug.WriteLine(file1.Path);
            Debug.WriteLine(file2.Path);

            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.Buffer, file2.Buffer));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StreamFile()
        {
            var tc = new TestCore();
            tc.Init();

            var file1 = Altseed.StreamFile.CreateStrict("../../Core/TestData/IO/test.txt");

            const string path = "Serialization/StreamFile.bin";
            file1.Read(3);

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StreamFile>(path);
            file2.Save("Serialization/StreamFile.txt");

            Assert.AreEqual(file1.GetPath(), file2.GetPath());
            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Assert.AreEqual(file1.CurrentPosition, file2.CurrentPosition);
            Assert.AreEqual(file1.TempBufferSize, file2.TempBufferSize);
            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.TempBuffer, file2.TempBuffer));

            tc.End();

        }

        [Test, Apartment(ApartmentState.STA)]
        public void Configuration()
        {
            var tc = new TestCore();
            tc.Init();

            var config1 = new Configuration()
            {
                ConsoleLoggingEnabled = true,
                FileLoggingEnabled = false,
                IsFullscreen = false,
                IsResizable = true,
                LogFileName = "Log.txt"
            };

            const string path = "Serialization/Configuration.bin";

            Serialize(path, config1);

            Assert.True(System.IO.File.Exists(path));

            var config2 = Deserialize<Configuration>(path);

            Assert.AreEqual(config1.ConsoleLoggingEnabled, true);
            Assert.AreEqual(config1.ConsoleLoggingEnabled, config2.ConsoleLoggingEnabled);
            Assert.AreEqual(config1.FileLoggingEnabled, false);
            Assert.AreEqual(config1.FileLoggingEnabled, config2.FileLoggingEnabled);
            Assert.AreEqual(config1.IsFullscreen, false);
            Assert.AreEqual(config1.IsFullscreen, config2.IsFullscreen);
            Assert.AreEqual(config1.IsResizable, true);
            Assert.AreEqual(config1.IsResizable, config2.IsResizable);
            Assert.AreEqual(config1.LogFileName, "Log.txt");
            Assert.AreEqual(config1.LogFileName, config2.LogFileName);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void DynamicFont()
        {
            var tc = new TestCore();
            tc.Init();

            var font1 = Font.LoadDynamicFontStrict("../../Core/TestData/Font/mplus-1m-regular.ttf", 50);

            Assert.NotNull(font1);

            const string path = "Serialization/DynamicFont.bin";

            Serialize(path, font1);

            Assert.True(System.IO.File.Exists(path));

            var font2 = Deserialize<Altseed.Font>(path);

            Assert.NotNull(font2);

            Assert.AreEqual(font1.GetPath(), font2.GetPath());
            Assert.AreEqual(font1.Ascent, font2.Ascent);
            Assert.AreEqual(font1.Descent, font2.Descent);
            Assert.AreEqual(font1.LineGap, font2.LineGap);
            Assert.AreEqual(font1.Size, font2.Size);

            var obj1 = new TextNode()
            {
                Position = new Vector2F(100, 100),
                Font = font1,
                Text = "Font1"
            };
            var obj2 = new TextNode()
            {
                Position = new Vector2F(100, 500),
                Font = font2,
                Text = "Font2"
            };

            Engine.AddNode(obj1);
            Engine.AddNode(obj2);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Texture2D()
        {
            var tc = new TestCore()
            {
                Duration = int.MaxValue
            };

            tc.Init();

            var texture1 = Altseed.Texture2D.LoadStrict(@"../../Core/TestData/IO/AltseedPink.png");

            Assert.NotNull(texture1);

            const string path = "Serialization/Texture2D.bin";

            Serialize(path, texture1);

            Assert.True(System.IO.File.Exists(path));

            var texture2 = Deserialize<Texture2D>(path);

            Assert.NotNull(texture2);

            Assert.AreEqual(texture1.Size, texture2.Size);

            var obj1 = new SpriteNode()
            {
                Position = new Vector2F(100, 100),
                Texture = texture1
            };
            var obj2 = new SpriteNode()
            {
                Position = new Vector2F(100, 500),
                Texture = texture2
            };

            Engine.AddNode(obj1);
            Engine.AddNode(obj2);

            tc.LoopBody(null, c =>
            {
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) tc.Duration = 0;
            });

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Sound()
        {
            var tc = new TestCore();
            tc.Init();

            var sound1 = Altseed.Sound.LoadStrict(@"../../Core/TestData/Sound/se1.wav", true);

            Assert.NotNull(sound1);

            const string path = "Serialization/Sound.bin";

            Serialize(path, sound1);

            Assert.True(System.IO.File.Exists(path));

            var font2 = Deserialize<Altseed.Sound>(path);

            Assert.NotNull(font2);

            Assert.AreEqual(sound1.GetPath(), font2.GetPath());
            Assert.AreEqual(sound1.GetIsDecompressed(), font2.GetIsDecompressed());
            Assert.AreEqual(sound1.IsLoopingMode, font2.IsLoopingMode);
            Assert.AreEqual(sound1.Length, font2.Length);
            Assert.AreEqual(sound1.LoopEndPoint, font2.LoopEndPoint);
            Assert.AreEqual(sound1.LoopStartingPoint, font2.LoopStartingPoint);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Int8Array()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new byte[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed.Int8Array.Create(netArray1.Length);
            Assert.NotNull(array1);
            array1.FromArray(netArray1);

            const string path = "Serialization/Int8Array.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Int8Array>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Int32Array()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new int[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed.Int32Array.Create(netArray1.Length);
            Assert.NotNull(array1);
            array1.FromArray(netArray1);

            const string path = "Serialization/Int32Array.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Int32Array>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void VertexArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new Vertex[]
            {
                new Vertex(new Vector3F(10, 10, 10), new Color(10, 10, 10, 10), new Vector2F(10, 10), new Vector2F(10, 10)),
                new Vertex(new Vector3F(20, 20, 20), new Color(20, 20, 20, 20), new Vector2F(20, 20), new Vector2F(20, 20)),
                new Vertex(new Vector3F(30, 30, 30), new Color(30, 30, 30, 30), new Vector2F(30, 30), new Vector2F(30, 30))
            };

            var array1 = Altseed.VertexArray.Create(netArray1.Length);
            Assert.NotNull(array1);
            array1.FromArray(netArray1);

            const string path = "Serialization/VertexArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<VertexArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void FloatArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new float[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed.FloatArray.Create(netArray1.Length);
            Assert.NotNull(array1);
            array1.FromArray(netArray1);

            const string path = "Serialization/FloatArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<FloatArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Vector2FArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new Vector2F[]
            {
                new Vector2F(10, 10),
                new Vector2F(20, 20),
                new Vector2F(30, 30)
            };

            var array1 = Altseed.Vector2FArray.Create(netArray1.Length);
            Assert.NotNull(array1);
            array1.FromArray(netArray1);

            const string path = "Serialization/Vector2FArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Vector2FArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }
    }
}
