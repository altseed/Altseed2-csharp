using System;

namespace Altseed.Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var dn = new Test.DrawnNode();
            dn.SpriteNode();
            dn.TextNode();

            Console.ReadLine();
        }
    }
}
