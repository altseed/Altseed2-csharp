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

            var core = asd.Core.TryGetFromCache(IntPtr.Zero);
            core.Initialize("Altseed2 C# Engine", 800, 600, ref coreOption);

            while (core.DoEvent()) ;

            core.Terminate();
        }
    }
}
