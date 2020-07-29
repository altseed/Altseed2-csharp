using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class EngineTest
    {
        [Test, Apartment(ApartmentState.STA)]
        public void PauseAndResume()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new RotateSpriteNode();
            node.Texture = texture;
            node.AdjustSize();
            node.CenterPosition = texture.Size / 2;
            node.Position = new Vector2F(200, 200);
            Engine.AddNode(node);

            var node2 = new RotateSpriteNode();
            node2.Texture = texture;
            node2.AdjustSize();
            node2.CenterPosition = texture.Size / 2;
            node2.Position = new Vector2F(600, 200);
            Engine.AddNode(node2);

            tc.LoopBody(c =>
            {
                if (c == 50) Engine.Pause(node);
                if (c == 150) Engine.Resume();
            }
            , null);

            tc.End();
        }

        class RotateSpriteNode : SpriteNode
        {
            protected override void OnUpdate()
            {
                Angle++;
            }
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RemovingNodeCauseCrash()
        {
            var tc = new TestCore(new Configuration() { WaitVSync = false });
            tc.Init();
            Engine.TargetFPS = 10000;
            SpriteNode node = null;
            tc.Duration = 100000;
            tc.LoopBody(c =>
            {
                if (node != null) Engine.RemoveNode(node);

                node = new SpriteNode();
                node.Texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
                node.CenterPosition = node.Texture.Size / 2;
                node.Position = new Vector2F(200, 200);
                Engine.AddNode(node);
            }
            , null);

            tc.End();
        }
    }
}
