using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    class Camera
    {
        [Test, Apartment(ApartmentState.STA)]
        public void NoRenderTexture()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            Engine.AddNode(node);

            var camera = new CameraNode();
            camera.Transform = Matrix44F.GetTranslation2D(new Vector2F(300, 300));
            Engine.AddNode(camera);

            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void _RenderTexture()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
            Assert.NotNull(texture);

            var node = new SpriteNode();
            node.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node.Texture = texture;
            node.CenterPosition = texture.Size / 2;
            Engine.AddNode(node);

            var size = new Vector2I(200, 00);
            var renderTexture = RenderTexture.Create(ref size);
            var camera = new CameraNode();
            camera.TargetTexture = renderTexture;
            Engine.AddNode(camera);

            var node2 = new SpriteNode();
            node2.Src = new RectF(new Vector2F(100, 100), new Vector2F(200, 200));
            node2.Texture = renderTexture;
            node2.CenterPosition = texture.Size / 2;
            Engine.AddNode(node2);

            tc.LoopBody(c =>
            {
            }
            , null);

            tc.End();
        }
    }
}
