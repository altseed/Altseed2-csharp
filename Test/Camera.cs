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

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            node.CameraGroup = 1 << 0;
            Engine.AddNode(node);

            var camera = new CameraNode();
            camera.Transform = Matrix44F.GetTranslation2D(new Vector2F(-200, -200));
            camera.Group = 0;
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

            var texture = Texture2D.Load(@"../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            //node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            //node.CenterPosition = texture.Size / 2;
            node.Scale = new Vector2F(0.5f, 0.5f);
            node.CameraGroup = 1 << 0;
            Engine.AddNode(node);

            var renderTexture = RenderTexture.Create(new Vector2I(200, 200));
            var camera = new CameraNode();
            camera.Group = 0;
            camera.TargetTexture = renderTexture;
            Engine.AddNode(camera);

            var node2 = new SpriteNode();
            node2.CameraGroup = 1 << 1;
            node2.Texture = renderTexture;
            node2.Position = new Vector2F(300, 300);
            Engine.AddNode(node2);

            var camera2 = new CameraNode();
            camera2.Group = 1;
            Engine.AddNode(camera2);

            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }
    }
}
