using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    class Camera
    {
        [Test, Apartment(ApartmentState.STA)]
        public void NoRenderTexture()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.CameraGroup = 0b1;
            Engine.AddNode(node);

            var camera = new CameraNode();
            camera.Position = new Vector2F(100, 0);
            camera.Scale = new Vector2F(2, 2);
            camera.Group = 0b1;
            Engine.AddNode(camera);

            tc.LoopBody(c =>
            {
                node.Angle++;
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void _RenderTexture()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.Scale = new Vector2F(0.5f, 0.5f);
            node.CameraGroup = 0b1;
            Engine.AddNode(node);

            var renderTexture = RenderTexture.Create(new Vector2I(200, 200), TextureFormat.R8G8B8A8_UNORM);
            var camera = new CameraNode();
            camera.Group = 0b1;
            camera.TargetTexture = renderTexture;
            Engine.AddNode(camera);

            var node2 = new SpriteNode();
            node2.CameraGroup = 0b10;
            node2.Texture = renderTexture;
            node2.Position = new Vector2F(300, 300);
            Engine.AddNode(node2);

            var camera2 = new CameraNode();
            camera2.Group = 0b10;
            Engine.AddNode(camera2);

            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }
    }
}
