using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace Altseed.Test
{
    [TestFixture]
    public class Font
    {
        [Test, Apartment(ApartmentState.STA)]
        public void DrawBasicFont()
        {
            Assert.True(Engine.Initialize("test", 1280, 720, new Configuration()));

            int count = 0;

            var color = new Color(255, 0, 0, 255);
            var font = Altseed.Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100, ref color);

            var shader = Engine.Graphics.BuildinShader.Create(Altseed.BuildinShaderType.FontUnlitPS);
            var material = new Material();
            material.Shader = shader;

            List<Altseed.RenderedSprite> sprites = new List<RenderedSprite>();
            string text = "こんにちは！ Hello World";
            Altseed.Vector2F position = new Vector2F(100, 100);
            for (int i = 0; i < text.Length; i++)
            {
                var glyph = font.GetGlyph(text[i]);
                if (glyph == null) continue;

                var tempPosition = position + glyph.Offset.To2DF() + new Altseed.Vector2F(0, font.Ascent);
                var sprite = Altseed.RenderedSprite.Create();
                sprite.Material = material;
                sprite.Texture = font.GetFontTexture(glyph.TextureIndex);

                Altseed.Matrix44F trans = new Matrix44F();
                trans.SetTranslation(tempPosition.X, tempPosition.Y, 0);
                sprite.Transform = trans;

                sprite.Src = new Altseed.RectF(glyph.Position.X, glyph.Position.Y, glyph.Size.X, glyph.Size.Y);
                sprites.Add(sprite);

                position += new Altseed.Vector2F(glyph.GlyphWidth, 0);

                if (i < text.Length - 1) position += new Altseed.Vector2F(font.GetKerning(text[i], text[i + 1]), 0);
            }

            while (count++ < 100 && Engine.DoEvents())
            {
                Assert.True(Engine.Graphics.BeginFrame());
                foreach (var s in sprites)
                {
                    Engine.Renderer.DrawSprite(s);
                }

                var cmdList = Engine.Graphics.CommandList;
                cmdList.SetRenderTargetWithScreen();
                Engine.Renderer.Render(cmdList);
                Assert.True(Engine.Graphics.EndFrame());
            }

            Engine.Terminate();
        }
    }
}
