using System;
using System.IO;

namespace Altseed2_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreOption = new asd.CoreOption()
            {
                IsFullscreenMode = false,
                IsResizable = false,
            };

            asd.Core.Initialize("Altseed2 C# Engine", 800, 600, ref coreOption);

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
            while (asd.Core.GetInstance().DoEvent())
            {
                //Console.WriteLine(asd.Keyboard.GetInstance().GetKeyState(asd.Keys.Space));
            }

            asd.Core.Terminate();
        }
    }
}
