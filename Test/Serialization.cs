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
                EnabledConsoleLogging = true,
                EnabledFileLogging = false,
                IsFullscreenMode = false,
                IsResizable = true,
                LogFilename = "Log.txt"
            };

            const string path = "Serialization/Configuration.bin";

            Serialize(path, config1);

            Assert.True(System.IO.File.Exists(path));

            var config2 = Deserialize<Configuration>(path);

            Assert.AreEqual(config1.EnabledConsoleLogging, true);
            Assert.AreEqual(config1.EnabledConsoleLogging, config2.EnabledConsoleLogging);
            Assert.AreEqual(config1.EnabledFileLogging, false);
            Assert.AreEqual(config1.EnabledFileLogging, config2.EnabledFileLogging);
            Assert.AreEqual(config1.IsFullscreenMode, false);
            Assert.AreEqual(config1.IsFullscreenMode, config2.IsFullscreenMode);
            Assert.AreEqual(config1.IsResizable, true);
            Assert.AreEqual(config1.IsResizable, config2.IsResizable);
            Assert.AreEqual(config1.LogFilename, "Log.txt");
            Assert.AreEqual(config1.LogFilename, config2.LogFilename);

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
        public void StreamFile()
        {
            Assert.True(EngineCore.Initialize("StreamFile", 50, 50));

            var file1 = Altseed.StreamFile.CreateStrict("../../Core/TestData/IO/test.txt");

            const string path = "Serialization/StreamFile.bin";
            file1.Read(3);

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StreamFile>(path);

            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Assert.AreEqual(file1.CurrentPosition, file2.CurrentPosition);
            Assert.AreEqual(file1.TempBufferSize, file2.TempBufferSize);
            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.TempBuffer, file2.TempBuffer));

            EngineCore.Terminate();
        }
    }
}
