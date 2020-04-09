using System;
using System.Threading;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

namespace Altseed.Test
{
    [TestFixture]
    public class Graphics
    {
        //[Test]
        //public void BasicSpriteTexture()
        //{
        //    Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

        //    var count = 0;

        //    var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");
        //    var t2 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.jpg");

        //    Assert.NotNull(t1);
        //    Assert.NotNull(t2);

        //    var s1 = RenderedSprite.Create();
        //    var s1_2 = RenderedSprite.Create();
        //    var s1_3 = RenderedSprite.Create();
        //    var s2 = RenderedSprite.Create();

        //    s1.Texture = t1;
        //    s1.Src = new RectF(0, 0, 128, 128);

        //    var trans = new Matrix44F();
        //    trans.SetTranslation(100, 200, 0);
        //    s1_2.Texture = t1;
        //    s1_2.Transform = trans;
        //    s1_2.Src = new RectF(128, 128, 256, 256);

        //    trans = new Matrix44F();
        //    trans.SetTranslation(200, 200, 0);
        //    s1_3.Texture = t1;
        //    s1_3.Transform = trans;
        //    s1_3.Src = new RectF(128, 128, 256, 256);

        //    trans = new Matrix44F();
        //    trans.SetTranslation(200, 200, 0);
        //    s2.Texture = t2;
        //    s2.Transform = trans;
        //    s2.Src = new RectF(128, 128, 256, 256);

        //    while (Engine.DoEvents() && count++ < 300)
        //    {
        //        Assert.True(Engine.Graphics.BeginFrame());

        //        Engine.Renderer.DrawSprite(s1);
        //        Engine.Renderer.DrawSprite(s1_2);
        //        Engine.Renderer.DrawSprite(s2);
        //        Engine.Update();

        //        var cmdList = Engine.Graphics.CommandList;
        //        cmdList.SetRenderTargetWithScreen();

        //        Engine.Renderer.Render(cmdList);
        //        Assert.True(Engine.Graphics.EndFrame());
        //    }

        //    Engine.Terminate();
        //}

        //[Test]
        //public void Polygon()
        //{
        //    Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

        //    var count = 0;

        //    var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");

        //    Assert.NotNull(t1);

        //    var vb = new Vertex[]{
        //        new Vertex{ Position = new Vector3F( 10,  10, 0.5f), Color = new Color(  0, 255, 255, 255), UV1 = new Vector2F(0.0f, 0.0f) },
        //        new Vertex{ Position = new Vector3F(110,  10, 0.5f), Color = new Color(255,   0, 255, 255), UV1 = new Vector2F(1.0f, 0.0f) },
        //        new Vertex{ Position = new Vector3F(110, 110, 0.5f), Color = new Color(255, 255,   0, 255), UV1 = new Vector2F(1.0f, 1.0f) },
        //        new Vertex{ Position = new Vector3F( 10, 110, 0.5f), Color = new Color(255, 255, 255, 255), UV1 = new Vector2F(0.0f, 1.0f) },
        //    };

        //    var ib = new int[] { 0, 1, 2, 2, 3, 0 };

        //    while (Engine.DoEvents() && count++ < 300)
        //    {
        //        Assert.True(Engine.Graphics.BeginFrame());

        //        Engine.Renderer.DrawPolygon(vb, ib, t1, null);
        //        Engine.Update();

        //        var cmdList = Engine.Graphics.CommandList;
        //        cmdList.SetRenderTargetWithScreen();

        //        Engine.Renderer.Render(cmdList);
        //        Assert.True(Engine.Graphics.EndFrame());
        //    }

        //    Engine.Terminate();
        //}
        //[Test]
        //public void VertexIndexAccess()
        //{
        //    Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

        //    var count = 0;

        //    var t1 = Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png");

        //    Assert.NotNull(t1);

        //    var vb = VertexArray.Create(4);
        //    vb.FromArray(new Vertex[]{
        //        new Vertex{ Position = new Vector3F( 10,  10, 0.5f), Color = new Color(  0, 255, 255, 255), UV1 = new Vector2F(0.0f, 0.0f) },
        //        new Vertex{ Position = new Vector3F(110,  10, 0.5f), Color = new Color(255,   0, 255, 255), UV1 = new Vector2F(1.0f, 0.0f) },
        //        new Vertex{ Position = new Vector3F(110, 110, 0.5f), Color = new Color(255, 255,   0, 255), UV1 = new Vector2F(1.0f, 1.0f) },
        //        new Vertex{ Position = new Vector3F( 10, 110, 0.5f), Color = new Color(255, 255, 255, 255), UV1 = new Vector2F(0.0f, 1.0f) },
        //    });

        //    var ib = Int32Array.Create(4);
        //    ib.FromArray(new int[] { 0, 1, 2, 2, 3, 0 });

        //    while (Engine.DoEvents() && count++ < 300)
        //    {
        //        Assert.True(Engine.Graphics.BeginFrame());


        //        var v = vb[1];
        //        v.Position.X = count + 110;
        //        vb[1] = v;

        //        v = vb[2];
        //        v.Position.X = count + 110;
        //        vb[2] = v;

        //        Engine.Renderer.DrawPolygon(vb, ib, t1, null);

        //        Engine.Update();

        //        var cmdList = Engine.Graphics.CommandList;
        //        cmdList.SetRenderTargetWithScreen();

        //        Engine.Renderer.Render(cmdList);
        //        Assert.True(Engine.Graphics.EndFrame());
        //    }

        //    Engine.Terminate();
        //}

        [Test]
        public void DrawText()
        {
            Assert.True(Engine.Initialize("Altseed2 C# Engine", 800, 600, new Configuration()));

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            var font2 = Font.LoadDynamicFont("../../Core/TestData/Font/GenYoMinJP-Bold.ttf", 100);
            Assert.NotNull(font);
            Assert.NotNull(font2);
            var imageFont = Font.CreateImageFont(font);
            imageFont.AddImageGlyph('〇', Texture2D.Load(@"../../Core/TestData/IO/AltseedPink.png"));

            List<RenderedText> texts = new List<RenderedText>();

            {
                var t = RenderedText.Create();
                t.Font = font;
                t.Text = "Hello, world! こんにちは";
                t.Transform = MathHelper.CalcTransform(new Vector2F(), new Vector2F(), 0, new Vector2F(1, 1));
                texts.Add(t);
            }

            {
                var t = RenderedText.Create();
                t.Font = font;
                t.Text = "色を指定する。";
                t.Color = new Color(0, 0, 255, 255);
                t.Transform = MathHelper.CalcTransform(new Vector2F(0, 100), new Vector2F(), 0, new Vector2F(1, 1));
                texts.Add(t);
            }

            {
                var t = RenderedText.Create();
                t.Font = font2;
                t.Text = "𠀋 𡈽 𡌛 𡑮 𡢽 𠮟 𡚴 𡸴 𣇄 𣗄 𣜿 𣝣 𣳾 𤟱 𥒎 𥔎 𥝱 𥧄 𥶡 𦫿 𦹀 𧃴 𧚄 𨉷";
                t.Transform = MathHelper.CalcTransform(new Vector2F(0, 200), new Vector2F(), 0, new Vector2F(1, 1));
                texts.Add(t);
            }

            var rotatedText = RenderedText.Create();
            {
                rotatedText.Font = font;
                rotatedText.Text = "くるくるまわる";
                texts.Add(rotatedText);
            }

            {
                var imageFontText = RenderedText.Create();
                imageFontText.Font = imageFont;
                imageFontText.Text = "Altseed〇Altseed";
                imageFontText.Transform = MathHelper.CalcTransform(new Vector2F(0, 300), new Vector2F(), 0, new Vector2F(1, 1));
                texts.Add(imageFontText);
            }

            int count = 0;

            while (Engine.DoEvents() && count++ < 300)
            {
                Assert.True(Engine.Graphics.BeginFrame());
                rotatedText.Transform = MathHelper.CalcTransform(new Vector2F(0, 300), new Vector2F(), count, new Vector2F(1, 1));

                foreach (var item in texts)
                {
                    Engine.Renderer.DrawText(item);
                }

                Engine.Renderer.Render();
                Assert.True(Engine.Graphics.EndFrame());
            }

            Engine.Terminate();
        }
    }
}