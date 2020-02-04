using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class File
    {
        public static DefaultTraceListener Listener = new DefaultTraceListener()
        {
            LogFileName = "debug.txt"
        };
        [Test, Apartment(System.Threading.ApartmentState.STA)]
        public void Base()
        {
            Engine.Initialize("FileTest", 640, 480, new CoreOption());
            ReadStaticFile();
            Engine.Terminate();
        }
        private void ReadStaticFile()
        {
            var file = Engine.File.CreateStaticFileStrict("Test.txt");
            Listener.WriteLine(file.IsInPackage);
            Listener.WriteLine(file.Path);
            Listener.WriteLine(file.Size);
        }
    }
}
