using System;
using System.IO;
using Xunit;

namespace Altseed.Test
{
    public class Engine
    {
        [Fact]
        public void Initialize()
        {
            var coreOption = new Altseed.CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            Altseed.Engine.Initialize("Altseed2 C# Engine", 800, 600, coreOption);

            /*
            Console.WriteLine(asd.File.GetInstance().AddRootDirectory("../../Core/TestData"));

            var staticFile = asd.File.GetInstance().CreateStaticFile("IO/test.txt");
            Console.WriteLine(staticFile.GetPath());
            string str;
            using (var fileStream = new FileStream("../../Core/TestData/IO/test.txt", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fileStream))
            {
                str = reader.ReadToEnd();
            }
            Console.WriteLine(staticFile.GetSize() == str.Length);

            Console.WriteLine(staticFile.GetSize());
            */

            while (Altseed.Engine.DoEvents())
            {
                Console.WriteLine(Altseed.Engine.Keyboard.GetKeyState(Altseed.Keys.Space));
                Altseed.Engine.Update();
            }

            Altseed.Engine.Terminate();

            Assert.True(true);
        }
    }
}
