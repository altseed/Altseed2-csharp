using System;

using Altseed;

namespace Sample
{
    class SpriteNode
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (!Engine.Initialize("Altseed2 サンプルビュワー", 800, 600, new Configuration())) return;

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
