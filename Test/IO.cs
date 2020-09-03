using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altseed2.Test
{
    [TestFixture]
    public class IO
    {
        [Test, Apartment(ApartmentState.STA)]
        public void FileRoot()
        {
            var tc = new TestCore();
            tc.Init();

            Assert.True(Engine.File.Pack("TestData/IO/pack/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("TestData/IO/pack/", "password.pack", "altseed"));

            // default root
            Assert.True(Engine.File.Exists("TestData/IO/test.txt"));

            // add directory root
            Assert.True(Engine.File.AddRootDirectory("TestData/IO/root/"));

            // directory root
            Assert.False(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));

#if !CI
            Assert.True(Engine.File.Exists("全角　テスト.txt"));
#endif
            // clear root
            Engine.File.ClearRootDirectories();
            Assert.True(Engine.File.Exists("TestData/IO/test.txt"));
            Assert.True(Engine.File.Exists("TestData/IO/../IO/test.txt"));
            Assert.False(Engine.File.Exists("space test.txt"));
            Assert.False(Engine.File.Exists("全角 テスト.txt"));

#if !CI
            Assert.False(Engine.File.Exists("全角　テスト.txt"));
#endif

            // pack file root
            Assert.True(Engine.File.AddRootPackage("pack.pack"));
            Assert.True(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));
#if !CI
            Assert.True(Engine.File.Exists("全角　テスト.txt"));
#endif
            Assert.True(Engine.File.Exists("testDir/test.txt"));
            Assert.True(Engine.File.Exists("test dir/test.txt"));

            Engine.File.ClearRootDirectories();

            // pack file with password root
            Assert.True(Engine.File.AddRootPackageWithPassword("password.pack", "altseed"));
            Assert.True(Engine.File.Exists("test.txt"));
            Assert.True(Engine.File.Exists("space test.txt"));
            Assert.True(Engine.File.Exists("全角 テスト.txt"));
#if !CI
            Assert.True(Engine.File.Exists("全角　テスト.txt"));
#endif
            Assert.True(Engine.File.Exists("testDir/test.txt"));
            Assert.True(Engine.File.Exists("test dir/test.txt"));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFileBase()
        {
            var tc = new TestCore();
            tc.Init();

            // pack files
            Assert.True(Engine.File.Pack("TestData/IO/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("TestData/IO/pack/", "password.pack", "altseed"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StaticFile test = null;
            Assert.AreNotEqual(test = StaticFile.Create("TestData/IO/test.txt"), null);
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
            Assert.AreNotEqual(test3 = StaticFile.Create("TestData/IO/pack/test.txt"), null);
            Assert.AreEqual(test3.Size, testPack2.Size);
            Assert.AreEqual(test3.Size, testPack2.Size);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StreamFileBase()
        {
            var tc = new TestCore();
            tc.Init();

            // pack files
            Assert.True(Engine.File.Pack("TestData/IO/", "pack.pack"));
            Assert.True(Engine.File.PackWithPassword("TestData/IO/pack/", "password.pack", "altseed"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StreamFile test = null;
            Assert.AreNotEqual(test = StreamFile.Create("TestData/IO/test.txt"), null);
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
                Assert.AreEqual(test.TempBuffer, test.TempBuffer);
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
            Assert.AreNotEqual(test3 = StreamFile.Create("TestData/IO/pack/test.txt"), null);
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

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Zenkaku()
        {
            var tc = new TestCore();
            tc.Init();

            // pack files
            Assert.True(Engine.File.Pack("TestData/IO/", "pack.pack"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            StaticFile test1 = null;
            StaticFile test2 = null;
            StaticFile testPack1 = null;
            StaticFile testPack2 = null;

            test1 = StaticFile.Create("TestData/IO/全角 テスト.txt");
#if !CI
            test2 = StaticFile.Create("TestData/IO/全角　テスト.txt");
#endif
            testPack1 = StaticFile.Create("全角 テスト.txt");

#if !CI
            testPack2 = StaticFile.Create("全角　テスト.txt");
#endif

            Assert.AreNotEqual(test1, null);
            Assert.AreNotEqual(testPack1, null);

#if !CI
            Assert.AreNotEqual(test2, null);
            Assert.AreNotEqual(testPack2, null);
#endif

            Assert.AreNotEqual(test1.Size, 0);
            Assert.AreNotEqual(testPack1.Size, 0);

#if !CI
            Assert.AreNotEqual(test2.Size, 0);
            Assert.AreNotEqual(testPack2.Size, 0);
#endif

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFileAsync()
        {
            var tc = new TestCore();
            tc.Init();

            // pack files
            Assert.True(Engine.File.Pack("TestData/IO/", "pack.pack"));

            // add package
            Assert.True(Engine.File.AddRootPackage("pack.pack"));

            // create static file, and compare no-package and package without password
            StaticFile test1 = null;
            StaticFile test2 = null;
            StaticFile test3 = null;
#if !CI
            StaticFile test4 = null;
#endif
            StaticFile testCache = null;
            StaticFile testPack1 = null;
            StaticFile testPack2 = null;
            StaticFile testPack3 = null;
#if !CI
            StaticFile testPack4 = null;
#endif
            StaticFile testPackCache = null;

            var task1 = Task.Run(() =>
            {
                test1 = StaticFile.Create("TestData/IO/test.txt");
                test3 = StaticFile.Create("TestData/IO/全角 テスト.txt");
                testPack1 = StaticFile.Create("test.txt");
                testPack3 = StaticFile.Create("全角 テスト.txt");
                testCache = StaticFile.Create("TestData/IO/test.txt");
            });

            var task2 = Task.Run(() =>
            {
                test2 = StaticFile.Create("TestData/IO/space test.txt");
#if !CI
                test4 = StaticFile.Create("TestData/IO/全角　テスト.txt");
#endif
                testPack2 = StaticFile.Create("space test.txt");
#if !CI
                testPack4 = StaticFile.Create("全角　テスト.txt");
#endif
                testPackCache = StaticFile.Create("space test.txt");
            });

            task1.Wait();
            task2.Wait();

            Assert.AreNotEqual(test1, null);
            Assert.AreNotEqual(test2, null);
            Assert.AreNotEqual(test3, null);
#if !CI
            Assert.AreNotEqual(test4, null);
#endif
            Assert.AreNotEqual(testCache, null);
            Assert.AreNotEqual(testPack1, null);
            Assert.AreNotEqual(testPack2, null);
            Assert.AreNotEqual(testPack3, null);
#if !CI
            Assert.AreNotEqual(testPack4, null);
#endif
            Assert.AreNotEqual(testPackCache, null);

            Assert.AreEqual(test1.Size, testPack1.Size);
            Assert.AreEqual(test1.Size, testPack1.Size);
            Assert.AreEqual(test2.Size, testPack2.Size);
            Assert.AreEqual(test3.Size, testPack3.Size);
#if !CI
            Assert.AreEqual(test4.Size, testPack4.Size);
#endif
            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFileCache()
        {
            var tc = new TestCore();
            tc.Init();

            var path = System.IO.Path.GetFullPath("TestData/IO/AltseedPink.png");
            Assert.True(Engine.File.Exists(path));
            StaticFile test = null;
            Assert.AreNotEqual(test = StaticFile.Create(path), null);

            StaticFile test3 = null;
            Assert.AreNotEqual(test3 = StaticFile.Create(path), null);

            Engine.Log.Info(LogCategory.Engine, $"{test.selfPtr}/{test3.selfPtr}");
            Engine.Log.Info(LogCategory.Engine, Engine.Resources.GetResourcesCount(ResourceType.StaticFile).ToString());
            tc.End();
        }
    }
}
