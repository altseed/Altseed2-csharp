using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altseed.Test
{
    [TestFixture]
    public class IO
    {
        [Test, Apartment(ApartmentState.STA)]
        public void FileRoot()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            Assert.True(Engine.File.Pack("../../Core/TestData/IO/pack/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("../../Core/TestData/IO/pack/", "password.pack", "altseed"));

            // default root
            Assert.True(Engine.File.Exists("../../Core/TestData/IO/test.txt"));

            // add directory root
            Assert.True(Engine.File.AddRootDirectory("../../Core/TestData/IO/root/"));

            // directory root
            Assert.False(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));
            Assert.True(Engine.File.Exists("全角　テスト.txt"));

            // clear root
            Engine.File.ClearRootDirectories();
            Assert.True(Engine.File.Exists("../../Core/TestData/IO/test.txt"));
            Assert.True(Engine.File.Exists("../../Core/TestData/IO/../IO/test.txt"));
            Assert.False(Engine.File.Exists("space test.txt"));
            Assert.False(Engine.File.Exists("全角 テスト.txt"));
            Assert.False(Engine.File.Exists("全角　テスト.txt"));

            // pack file root
            Assert.True(Engine.File.AddRootPackage("pack.pack"));
            Assert.True(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));
            Assert.True(Engine.File.Exists("全角　テスト.txt"));
            Assert.True(Engine.File.Exists("testDir/test.txt"));
            Assert.True(Engine.File.Exists("test dir/test.txt"));

            Engine.File.ClearRootDirectories();

            // pack file with password root
            Assert.True(Engine.File.AddRootPackageWithPassword("password.pack", "altseed"));
            Assert.True(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));
            Assert.True(Engine.File.Exists("全角　テスト.txt"));
            Assert.True(Engine.File.Exists("testDir/test.txt"));
            Assert.True(Engine.File.Exists("test dir/test.txt"));

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFileBase()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            // pack files
            Assert.True(Engine.File.Pack("../../Core/TestData/IO/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("../../Core/TestData/IO/pack/", "password.pack", "altseed"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StaticFile test = null;
            Assert.AreNotEqual(test = StaticFile.Create("../../Core/TestData/IO/test.txt"), null);
            Assert.False(test.IsInPackage);
            StaticFile testPack = null;
            Assert.AreNotEqual(testPack = StaticFile.Create("test.txt"), null);
            Assert.True(testPack.IsInPackage);
            Assert.AreEqual(test.Size, testPack.Size);

            // add package
            Assert.True(Engine.File.AddRootPackageWithPassword("password.pack", "altseed"));

            // clear cache
            Engine.Resources.Clear();

            StaticFile testPack2 = null;
            Assert.AreNotEqual(testPack2 = StaticFile.Create("test.txt"), null);
            Assert.True(testPack2.IsInPackage);
            Assert.AreNotEqual(testPack, testPack2);
            Assert.AreNotEqual(testPack.Size, testPack2.Size);

            // create static file, and compare no-package and package with password
            StaticFile test3 = null;
            Assert.AreNotEqual(test3 = StaticFile.Create("../../Core/TestData/IO/pack/test.txt"), null);
            Assert.AreEqual(test3.Size, testPack2.Size);
            Assert.AreEqual(test3.Size, testPack2.Size);

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StreamFileBase()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            // pack files
            Assert.True(Engine.File.Pack("../../Core/TestData/IO/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("../../Core/TestData/IO/pack/", "password.pack", "altseed"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StreamFile test = null;
            Assert.AreNotEqual(test = StreamFile.Create("../../Core/TestData/IO/test.txt"), null);
            Assert.False(test.IsInPackage);
            StreamFile testPack = null;
            Assert.AreNotEqual(testPack = StreamFile.Create("test.txt"), null);
            Assert.True(testPack.IsInPackage);
            Assert.AreEqual(test.Size, testPack.Size);
            Assert.AreEqual(test.TempBufferSize, 0);
            Assert.AreEqual(testPack.TempBufferSize, 0);
            for (int i = 0; i < test.Size; i++)
            {
                Assert.AreEqual(test.Read(1), 1);
                Assert.AreEqual(testPack.Read(1), 1);
                Assert.AreEqual(test.TempBufferSize, i + 1);
                Assert.AreEqual(testPack.TempBufferSize, i + 1);
                Assert.AreEqual(test.GetTempBuffer(), test.GetTempBuffer());
            }

            // add package
            Assert.True(Engine.File.AddRootPackageWithPassword("password.pack", "altseed"));

            // clear cache
            Engine.Resources.Clear();

            StreamFile testPack2 = null;
            Assert.AreNotEqual(testPack2 = StreamFile.Create("test.txt"), null);
            Assert.True(testPack2.IsInPackage);
            Assert.AreNotEqual(testPack, testPack2);
            Assert.AreNotEqual(testPack.Size, testPack2.Size);

            // create static file, and compare no-package and package with password
            StreamFile test3 = null;
            Assert.AreNotEqual(test3 = StreamFile.Create("../../Core/TestData/IO/pack/test.txt"), null);
            Assert.AreEqual(test3.Size, testPack2.Size);
            Assert.AreEqual(test3.Size, testPack2.Size);
            Assert.AreEqual(test3.TempBufferSize, 0);
            Assert.AreEqual(testPack2.TempBufferSize, 0);
            for (int i = 0; i < test3.Size; i++)
            {
                Assert.AreEqual(test3.Read(1), 1);
                Assert.AreEqual(testPack2.Read(1), 1);
                Assert.AreEqual(test3.TempBufferSize, i + 1);
                Assert.AreEqual(testPack2.TempBufferSize, i + 1);
            }

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Zenkaku()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            // pack files
            Assert.True(Engine.File.Pack("../../Core/TestData/IO/", "pack.pack"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            StaticFile test1 = null;
            StaticFile test2 = null;
            StaticFile testPack1 = null;
            StaticFile testPack2 = null;

            test1 = StaticFile.Create("../../Core/TestData/IO/全角 テスト.txt");
            test2 = StaticFile.Create("../../Core/TestData/IO/全角　テスト.txt");
            testPack1 = StaticFile.Create("全角 テスト.txt");
            testPack2 = StaticFile.Create("全角　テスト.txt");

            Assert.AreNotEqual(test1, null);
            Assert.AreNotEqual(test2, null);
            Assert.AreNotEqual(testPack1, null);
            Assert.AreNotEqual(testPack2, null);

            Assert.AreNotEqual(test1.Size, 0);
            Assert.AreNotEqual(test2.Size, 0);
            Assert.AreNotEqual(testPack1.Size, 0);
            Assert.AreNotEqual(testPack2.Size, 0);

            Engine.Terminate();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFileAsync()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, Configuration.Create()));

            // pack files
            Assert.True(Engine.File.Pack("../../Core/TestData/IO/", "pack.pack"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StaticFile test1 = null;
            StaticFile test2 = null;
            StaticFile test3 = null;
            StaticFile test4 = null;
            StaticFile testCache = null;
            StaticFile testPack1 = null;
            StaticFile testPack2 = null;
            StaticFile testPack3 = null;
            StaticFile testPack4 = null;
            StaticFile testPackCache = null;

            var task1 = Task.Run(() => {
                test1 = StaticFile.Create("../../Core/TestData/IO/test.txt");
                test3 = StaticFile.Create("../../Core/TestData/IO/全角 テスト.txt");
                testPack1 = StaticFile.Create("test.txt");
                testPack3 = StaticFile.Create("全角 テスト.txt");
                testCache = StaticFile.Create("../../Core/TestData/IO/test.txt");
            });

            var task2 = Task.Run(() => {
                test2 = StaticFile.Create("../../Core/TestData/IO/space test.txt");
                test4 = StaticFile.Create("../../Core/TestData/IO/全角　テスト.txt");
                testPack2 = StaticFile.Create("space test.txt");
                testPack4 = StaticFile.Create("全角　テスト.txt");
                testPackCache = StaticFile.Create("space test.txt");
            });

            task1.Wait();
            task2.Wait();

            Assert.AreNotEqual(test1, null);
            Assert.AreNotEqual(test2, null);
            Assert.AreNotEqual(test3, null);
            Assert.AreNotEqual(test4, null);
            Assert.AreNotEqual(testCache, null);
            Assert.AreNotEqual(testPack1, null);
            Assert.AreNotEqual(testPack2, null);
            Assert.AreNotEqual(testPack3, null);
            Assert.AreNotEqual(testPack4, null);
            Assert.AreNotEqual(testPackCache, null);

            Assert.AreEqual(test1.Size, testPack1.Size);
            Assert.AreEqual(test1.Size, testPack1.Size);
            Assert.AreEqual(test2.Size, testPack2.Size);
            Assert.AreEqual(test3.Size, testPack3.Size);
            Assert.AreEqual(test4.Size, testPack4.Size);

            Engine.Terminate();
        }
    }
}
