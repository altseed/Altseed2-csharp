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
            Assert.True(EngineCore.Initialize("StaticFile", 50, 50));

            var file1 = Altseed.StaticFile.CreateStrict("../../Core/TestData/IO/test.txt");

            const string path = "Serialization/StaticFile.bin";

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StaticFile>(path);
            file2.Save("Serialization/StaticFile.txt");

            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Debug.WriteLine(file1.Path);
            Debug.WriteLine(file2.Path);

            //Assert.AreEqual(file1.Path, file2.Path);
            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.Buffer, file2.Buffer));

            EngineCore.Terminate();
        }
    }
}
