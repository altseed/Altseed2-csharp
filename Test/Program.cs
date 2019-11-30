using System;

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

            while (asd.Core.GetInstance().DoEvent())
            {
                Console.WriteLine(asd.Keyboard.GetInstance().GetKeyState(asd.Keys.Space));
            }

			asd.Core.Terminate();
        }
    }
}
