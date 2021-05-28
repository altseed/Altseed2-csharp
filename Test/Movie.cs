using System;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    public class Movie
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Basic()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Create(new Vector2I(640, 480));
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            Engine.AddNode(node);

            var mp = MediaPlayer.Load(@"TestData/Movie/Test1.mp4");
            mp.Play(false);

            tc.LoopBody(c =>
            {
                mp.WriteToTexture2D(texture);
            }
            , null);

            tc.End();
        }
    }
}
