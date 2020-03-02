using System;

namespace Altseed.Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var sound = new Test.Sound();
            sound.Play();
            sound.Loop();
            sound.GetPosition();

            Console.ReadLine();
        }
    }
}
