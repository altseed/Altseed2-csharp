using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using NUnit.Framework;

namespace Altseed2.Test
{
    internal static class FormatterExtension
    {
        internal static T Deserialize<T>(this BinaryFormatter formatter, Stream stream) => (T)formatter.Deserialize(stream);
    }
    [TestFixture]
    public class Serialization
    {
        private static void Serialize<T>(string path, T item)
        {
            var direc = Path.GetDirectoryName(path);
            if (!Directory.Exists(direc)) Directory.CreateDirectory(direc);
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, item);
        }

        private static T Deserialize<T>(string path)
        {
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Open);
            return formatter.Deserialize<T>(stream);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFile()
        {
            var tc = new TestCore();
            tc.Init();

            var file1 = Altseed2.StaticFile.CreateStrict("TestData/IO/test.txt");

            const string path = "Serialization/StaticFile.bin";

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StaticFile>(path);
            using var stream = new FileStream("Serialization/StaticFile.txt", FileMode.Create);
            stream.Write(file2.Buffer, 0, file2.Size);

            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Debug.WriteLine(file1.Path);
            Debug.WriteLine(file2.Path);

            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.Buffer, file2.Buffer));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StreamFile()
        {
            var tc = new TestCore();
            tc.Init();

            var file1 = Altseed2.StreamFile.CreateStrict("TestData/IO/test.txt");

            const string path = "Serialization/StreamFile.bin";
            file1.Read(3);

            Serialize(path, file1);

            Assert.True(System.IO.File.Exists(path));

            var file2 = Deserialize<StreamFile>(path);
            using var stream = new FileStream("Serialization/StreamFile.txt", FileMode.Create);
            stream.Write(file2.TempBuffer, 0, file2.TempBufferSize);

            Assert.AreEqual(file1.Path, file2.Path);
            Assert.AreEqual(file1.IsInPackage, file2.IsInPackage);
            Assert.AreEqual(file1.CurrentPosition, file2.CurrentPosition);
            Assert.AreEqual(file1.TempBufferSize, file2.TempBufferSize);
            Assert.AreEqual(file1.Size, file2.Size);
            Assert.True(Enumerable.SequenceEqual(file1.TempBuffer, file2.TempBuffer));

            tc.End();

        }

        [Test, Apartment(ApartmentState.STA)]
        public void Configuration()
        {
            var tc = new TestCore();
            tc.Init();

            var config1 = new Configuration()
            {
                ConsoleLoggingEnabled = true,
                DeviceType = GraphicsDevice.Metal,
                FileLoggingEnabled = false,
                IsFullscreen = false,
                IsResizable = true,
                LogFileName = "Log.txt",
                VisibleTransformInfo = true,
                WaitVSync = true,
                EnabledCoreModules = CoreModules.Default | CoreModules.Tool
            };

            const string path = "Serialization/Configuration.bin";

            Serialize(path, config1);

            Assert.True(System.IO.File.Exists(path));

            var config2 = Deserialize<Configuration>(path);

            Assert.AreEqual(config1.ConsoleLoggingEnabled, true);
            Assert.AreEqual(config1.ConsoleLoggingEnabled, config2.ConsoleLoggingEnabled);
            Assert.AreEqual(config1.DeviceType, GraphicsDevice.Metal);
            Assert.AreEqual(config1.DeviceType, config2.DeviceType);
            Assert.AreEqual(config1.FileLoggingEnabled, false);
            Assert.AreEqual(config1.FileLoggingEnabled, config2.FileLoggingEnabled);
            Assert.AreEqual(config1.IsFullscreen, false);
            Assert.AreEqual(config1.IsFullscreen, config2.IsFullscreen);
            Assert.AreEqual(config1.EnabledCoreModules, CoreModules.Default | CoreModules.Tool);
            Assert.AreEqual(config1.EnabledCoreModules, config2.EnabledCoreModules);
            Assert.AreEqual(config1.IsResizable, true);
            Assert.AreEqual(config1.IsResizable, config2.IsResizable);
            Assert.AreEqual(config1.LogFileName, "Log.txt");
            Assert.AreEqual(config1.LogFileName, config2.LogFileName);
            Assert.AreEqual(config1.VisibleTransformInfo, true);
            Assert.AreEqual(config1.VisibleTransformInfo, config2.VisibleTransformInfo);
            Assert.AreEqual(config1.WaitVSync, true);
            Assert.AreEqual(config1.WaitVSync, config2.WaitVSync);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void DynamicFont()
        {
            var tc = new TestCore();
            tc.Init();

            var font1 = Font.LoadDynamicFontStrict("TestData/Font/mplus-1m-regular.ttf", 64);

            Assert.NotNull(font1);

            const string path = "Serialization/DynamicFont.bin";

            Serialize(path, font1);

            Assert.True(System.IO.File.Exists(path));

            var font2 = Deserialize<Font>(path);

            Assert.NotNull(font2);

            Assert.AreEqual(font1.Path, font2.Path);
            Assert.AreEqual(font1.Ascent, font2.Ascent);
            Assert.AreEqual(font1.Descent, font2.Descent);
            Assert.AreEqual(font1.EmSize, font2.EmSize);
            Assert.AreEqual(font1.LineGap, font2.LineGap);
            Assert.AreEqual(font1.SamplingSize, font2.SamplingSize);
            Assert.AreEqual(font1.IsStaticFont, font2.IsStaticFont);

            var obj1 = new TextNode()
            {
                Position = new Vector2F(100, 100),
                Font = font1,
                FontSize = 50,
                Text = "Font1"
            };
            var obj2 = new TextNode()
            {
                Position = new Vector2F(100, 500),
                Font = font2,
                FontSize = 50,
                Text = "Font2"
            };

            Engine.AddNode(obj1);
            Engine.AddNode(obj2);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void StaticFont()
        {
            var tc = new TestCore();
            tc.Init();

            Assert.True(Font.GenerateFontFile("TestData/Font/mplus-1m-regular.ttf", "test.a2f", 64, "Hello, world! こんにちは"));
            var font1 = Font.LoadStaticFontStrict("test.a2f");

            Assert.NotNull(font1);

            const string path = "Serialization/StaticFont.bin";

            Serialize(path, font1);

            Assert.True(System.IO.File.Exists(path));

            var font2 = Deserialize<Font>(path);

            Assert.NotNull(font2);

            Assert.AreEqual(font1.Path, font2.Path);
            Assert.AreEqual(font1.Ascent, font2.Ascent);
            Assert.AreEqual(font1.Descent, font2.Descent);
            Assert.AreEqual(font1.EmSize, font2.EmSize);
            Assert.AreEqual(font1.LineGap, font2.LineGap);
            Assert.AreEqual(font1.SamplingSize, font2.SamplingSize);
            Assert.AreEqual(font1.IsStaticFont, font2.IsStaticFont);

            var obj1 = new TextNode()
            {
                Position = new Vector2F(100, 100),
                Font = font1,
                FontSize = 80,
                Text = "Hellow"
            };
            var obj2 = new TextNode()
            {
                Position = new Vector2F(100, 500),
                Font = font2,
                FontSize = 80,
                Text = "Hellow"
            };

            Engine.AddNode(obj1);
            Engine.AddNode(obj2);

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Texture2D()
        {
            var tc = new TestCore();

            tc.Init();

            var texture1 = Altseed2.Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");

            Assert.NotNull(texture1);

            const string path = "Serialization/Texture2D.bin";

            Serialize(path, texture1);

            Assert.True(System.IO.File.Exists(path));

            var texture2 = Deserialize<Texture2D>(path);

            Assert.NotNull(texture2);

            Assert.AreEqual(texture1.Size, texture2.Size);
            Assert.AreEqual(texture1.Path, texture2.Path);
            Assert.AreEqual(texture1.FilterType, texture2.FilterType);
            Assert.AreEqual(texture1.Format, texture2.Format);
            Assert.AreEqual(texture1.WrapMode, texture2.WrapMode);

            var obj1 = new SpriteNode()
            {
                Position = new Vector2F(100, 100),
                Texture = texture1
            };
            var obj2 = new SpriteNode()
            {
                Position = new Vector2F(100, 500),
                Texture = texture2
            };

            Engine.AddNode(obj1);
            Engine.AddNode(obj2);

            tc.LoopBody(null, c =>
            {
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push) tc.Duration = 0;
            });

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RenderTexture()
        {
            var tc = new TestCore();

            tc.Init();

            var size = new Vector2I(100, 100);
            var texture1 = Altseed2.RenderTexture.Create(size, TextureFormat.R8G8B8A8_UNORM);

            Assert.NotNull(texture1);

            const string path = "Serialization/RenderTexture.bin";

            Serialize(path, texture1);

            Assert.True(System.IO.File.Exists(path));

            var texture2 = Deserialize<RenderTexture>(path);

            Assert.NotNull(texture2);

            Assert.AreEqual(texture1.Size, texture2.Size);
            Assert.AreEqual(texture1.FilterType, texture2.FilterType);
            Assert.AreEqual(texture1.Format, texture2.Format);
            Assert.AreEqual(texture1.WrapMode, texture2.WrapMode);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Sound()
        {
            var tc = new TestCore();
            tc.Init();

            var sound1 = Altseed2.Sound.LoadStrict(@"TestData/Sound/se1.wav", true);

            Assert.NotNull(sound1);

            const string path = "Serialization/Sound.bin";

            Serialize(path, sound1);

            Assert.True(System.IO.File.Exists(path));

            var font2 = Deserialize<Altseed2.Sound>(path);

            Assert.NotNull(font2);

            Assert.AreEqual(sound1.Path, font2.Path);
            Assert.AreEqual(sound1.IsDecompressed, font2.IsDecompressed);
            Assert.AreEqual(sound1.IsLoopingMode, font2.IsLoopingMode);
            Assert.AreEqual(sound1.Length, font2.Length);
            Assert.AreEqual(sound1.LoopEndPoint, font2.LoopEndPoint);
            Assert.AreEqual(sound1.LoopStartingPoint, font2.LoopStartingPoint);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Int8Array()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new byte[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed2.Int8Array.Create(netArray1.AsSpan());
            Assert.NotNull(array1);

            const string path = "Serialization/Int8Array.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Int8Array>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Int32Array()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new int[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed2.Int32Array.Create(netArray1.AsSpan());
            Assert.NotNull(array1);

            const string path = "Serialization/Int32Array.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Int32Array>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void VertexArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new Vertex[]
            {
                new Vertex(new Vector3F(10, 10, 10), new Color(10, 10, 10, 10), new Vector2F(10, 10), new Vector2F(10, 10)),
                new Vertex(new Vector3F(20, 20, 20), new Color(20, 20, 20, 20), new Vector2F(20, 20), new Vector2F(20, 20)),
                new Vertex(new Vector3F(30, 30, 30), new Color(30, 30, 30, 30), new Vector2F(30, 30), new Vector2F(30, 30))
            };

            var array1 = Altseed2.VertexArray.Create(netArray1.AsSpan());
            Assert.NotNull(array1);

            const string path = "Serialization/VertexArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<VertexArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void FloatArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new float[] { 1, 2, 3, 4, 5 };

            var array1 = Altseed2.FloatArray.Create(netArray1.AsSpan());
            Assert.NotNull(array1);

            const string path = "Serialization/FloatArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<FloatArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Vector2FArray()
        {
            var tc = new TestCore();
            tc.Init();

            var netArray1 = new Vector2F[]
            {
                new Vector2F(10, 10),
                new Vector2F(20, 20),
                new Vector2F(30, 30)
            };

            var array1 = Altseed2.Vector2FArray.Create(netArray1.AsSpan());
            Assert.NotNull(array1);

            const string path = "Serialization/Vector2FArray.bin";

            Serialize(path, array1);

            var array2 = Deserialize<Vector2FArray>(path);

            Assert.NotNull(array2);

            var netArray2 = array2.ToArray();

            Assert.AreEqual(netArray1.Length, netArray2.Length);
            Assert.True(Enumerable.SequenceEqual(netArray1, netArray2));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RenderedSprite()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Altseed2.Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");

            Assert.NotNull(texture);

            var sprite1 = Altseed2.RenderedSprite.Create();

            Assert.NotNull(sprite1);

            sprite1.Src = new RectF(100, 100, 200, 200);
            sprite1.Texture = texture;

            const string path = "Serialization/RenderedSprite.bin";

            Serialize(path, sprite1);

            var sprite2 = Deserialize<RenderedSprite>(path);

            Assert.NotNull(sprite2);

            Assert.AreEqual(sprite1.Color, sprite2.Color);
            Assert.AreEqual(sprite1.Material, sprite2.Material);
            Assert.AreEqual(sprite1.AlphaBlend, sprite2.AlphaBlend);
            Assert.AreEqual(sprite1.Src, sprite2.Src);
            Assert.AreEqual((sprite1.Texture as Texture2D).Path, (sprite1.Texture as Texture2D).Path);
            Assert.AreEqual(sprite1.Texture.Size, sprite2.Texture.Size);
            Assert.AreEqual(sprite1.Transform, sprite2.Transform);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RenderedText()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFontStrict("TestData/Font/mplus-1m-regular.ttf", 64);

            Assert.NotNull(font);

            var text1 = Altseed2.RenderedText.Create();

            Assert.NotNull(text1);

            text1.Color = new Color(100, 255, 200, 255);
            text1.Font = font;
            text1.FontSize = 50;
            text1.Text = "test";

            const string path = "Serialization/RenderedText.bin";

            Serialize(path, text1);

            var text2 = Deserialize<RenderedText>(path);

            Assert.NotNull(text2);

            Assert.AreEqual(text1.AlphaBlend, text2.AlphaBlend);
            Assert.AreEqual(text1.CharacterSpace, text2.CharacterSpace);
            Assert.AreEqual(text1.Color, text2.Color);
            Assert.AreEqual(text1.Font.Path, text2.Font.Path);
            Assert.AreEqual(text1.Font.SamplingSize, text2.Font.SamplingSize);
            Assert.AreEqual(text1.IsEnableKerning, text2.IsEnableKerning);
            Assert.AreEqual(text1.LineGap, text2.LineGap);
            Assert.AreEqual(text1.MaterialGlyph, text2.MaterialGlyph);
            Assert.AreEqual(text1.MaterialImage, text2.MaterialImage);
            Assert.AreEqual(text1.Text, text2.Text);
            Assert.AreEqual(text1.RenderingSize, text2.RenderingSize);
            Assert.AreEqual(text1.Transform, text2.Transform);
            Assert.AreEqual(text1.FontSize, text2.FontSize);
            Assert.AreEqual(text1.WritingDirection, text2.WritingDirection);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RenderedPolygon()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Altseed2.Texture2D.LoadStrict(@"TestData/IO/AltseedPink.png");
            var array = new Vector2F[]
            {
                new Vector2F(100, 100),
                new Vector2F(200, 200)
            };

            Assert.NotNull(texture);

            var polygon1 = Altseed2.RenderedPolygon.Create();

            Assert.NotNull(polygon1);

            polygon1.Src = new RectF(100, 100, 200, 200);
            polygon1.Texture = texture;
            var v_array = Altseed2.Vector2FArray.Create(array.AsSpan());
            polygon1.CreateVertexesByVector2F(v_array);

            const string path = "Serialization/RenderedPolygon.bin";

            Serialize(path, polygon1);

            var polygon2 = Deserialize<RenderedPolygon>(path);

            Assert.NotNull(polygon2);

            Assert.AreEqual(polygon1.Material, polygon2.Material);
            Assert.AreEqual(polygon1.AlphaBlend, polygon2.AlphaBlend);
            Assert.AreEqual(polygon1.Src, polygon2.Src);
            Assert.AreEqual(polygon1.Texture.Size, polygon2.Texture.Size);
            Assert.AreEqual(polygon1.Transform, polygon2.Transform);
            Assert.True(Enumerable.SequenceEqual(polygon1.Vertexes.ToArray(), polygon2.Vertexes.ToArray()));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RenderedCamera()
        {
            var tc = new TestCore();
            tc.Init();

            var texture = Altseed2.RenderTexture.Create(new Vector2I(100, 100), TextureFormat.R8G8B8A8_UNORM);

            Assert.NotNull(texture);

            var camera1 = Altseed2.RenderedCamera.Create();

            Assert.NotNull(camera1);

            camera1.ViewMatrix = Matrix44F.GetTranslation2D(new Vector2F(10, 10));
            camera1.TargetTexture = texture;

            const string path = "Serialization/RenderedCamera.bin";

            Serialize(path, camera1);

            var camera2 = Deserialize<RenderedCamera>(path);

            Assert.NotNull(camera2);

            Assert.AreEqual(camera1.RenderPassParameter.ClearColor, camera2.RenderPassParameter.ClearColor);
            Assert.AreEqual(camera1.RenderPassParameter.IsColorCleared, camera2.RenderPassParameter.IsColorCleared);
            Assert.AreEqual(camera1.RenderPassParameter.IsDepthCleared, camera2.RenderPassParameter.IsDepthCleared);
            Assert.AreEqual(camera1.TargetTexture.Size, camera2.TargetTexture.Size);
            Assert.AreEqual(camera1.ViewMatrix, camera2.ViewMatrix);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void CircleCollider()
        {
            var tc = new TestCore();
            tc.Init();

            var collider1 = new CircleCollider();

            collider1.Position = new Vector2F(30f, 30f);
            collider1.Rotation = MathHelper.DegreeToRadian(10.0f);
            collider1.Radius = 30.0f;

            const string path = "Serialization/CircleCollider.bin";

            Serialize(path, collider1);

            var collider2 = Deserialize<CircleCollider>(path);

            Assert.NotNull(collider2);

            Assert.AreEqual(collider1.Position, collider2.Position);
            Assert.AreEqual(collider1.Rotation, collider2.Rotation);
            Assert.AreEqual(collider1.Radius, collider2.Radius);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void PolygonCollider()
        {
            var tc = new TestCore();
            tc.Init();

            var collider1 = new PolygonCollider();
            collider1.Position = new Vector2F(30f, 30f);
            collider1.Rotation = MathHelper.DegreeToRadian(10.0f);

            Span<Vector2F> array = stackalloc Vector2F[]
            {
                new Vector2F(10f, 10f),
                new Vector2F(20f, 20f),
                new Vector2F(30f, 30f),
            };

            collider1.SetVertexes(array);

            const string path = "Serialization/PolygonCollider.bin";

            Serialize(path, collider1);

            var collider2 = Deserialize<PolygonCollider>(path);

            Assert.NotNull(collider2);

            Assert.AreEqual(collider1.Position, collider2.Position);
            Assert.AreEqual(collider1.Rotation, collider2.Rotation);
            Assert.True(Enumerable.SequenceEqual(collider1.Vertexes, collider2.Vertexes));

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void RectangleCollider()
        {
            var tc = new TestCore();
            tc.Init();

            var collider1 = new RectangleCollider();

            collider1.CenterPosition = new Vector2F(15f, 15f);
            collider1.Position = new Vector2F(30f, 30f);
            collider1.Rotation = MathHelper.DegreeToRadian(10.0f);
            collider1.Size = new Vector2F(20f, 20f);


            const string path = "Serialization/RectangleCollider.bin";

            Serialize(path, collider1);

            var collider2 = Deserialize<RectangleCollider>(path);

            Assert.NotNull(collider2);

            Assert.AreEqual(collider1.CenterPosition, collider2.CenterPosition);
            Assert.AreEqual(collider1.Position, collider2.Position);
            Assert.AreEqual(collider1.Rotation, collider2.Rotation);
            Assert.AreEqual(collider1.Size, collider2.Size);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Shader()
        {
            var tc = new TestCore();
            tc.Init();

            var shader1 = Altseed2.Shader.Create("ShaderTest", Engine.Graphics.BuiltinShader.DownsampleShader, ShaderStage.Pixel);
            Assert.NotNull(shader1);

            const string path = "Serialization/Shader.bin";

            Serialize(path, shader1);

            var shader2 = Deserialize<Shader>(path);
            Assert.NotNull(shader2);

            Assert.AreEqual(shader1.Code, shader2.Code);
            Assert.AreEqual(shader1.Name, shader2.Name);
            Assert.AreEqual(shader1.StageType, shader2.StageType);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Node()
        {
            var tc = new TestCore()
            {
                Duration = 5
            };
            tc.Init();

            //
            // RootNode
            // --node0
            //   |-node1
            //   --node2
            //
            // node3 is isolated from other nodes
            //

            var node0 = new NumericNode(0);
            var node1 = new NumericNode(1);
            var node2 = new NumericNode(2);
            var node3 = new NumericNode(3);

            NumericNode deserialized_node0 = null;
            NumericNode deserialized_node3 = null;

            node0.AddChildNode(node1);
            node0.AddChildNode(node2);
            Engine.AddNode(node0);

            int[] comparisonArray = null;

            const string path = "Serialization/Node.bin";

            tc.LoopBody(null, x =>
            {
                switch (x)
                {
                    case 1:
                        var set = new SortedSet<int>();
                        foreach (var node in EnumerateEngineNodes())
                            if (node is NumericNode n)
                                set.Add(n.Index);
                        comparisonArray = set.ToArray();

                        Serialize(path, (node0, node3));

                        Assert.AreEqual(node0.Children.Count, 2);
                        Assert.AreEqual(EnumerateEngineNodes().Count(), 3);
                        break;
                    case 2:
                        Engine.RemoveNode(node0);
                        break;
                    case 3:
                        var tuple = Deserialize<(NumericNode, NumericNode)>(path);
                        deserialized_node0 = tuple.Item1;
                        deserialized_node3 = tuple.Item2;

                        Assert.AreEqual(node0.Index, deserialized_node0.Index);
                        Assert.AreEqual(node3.Index, deserialized_node3.Index);
                        Assert.AreEqual(EnumerateEngineNodes().Count(), 0);
                        break;
                    case 4:
                        Assert.NotNull(comparisonArray);
                        Assert.NotNull(deserialized_node0);
                        Assert.NotNull(deserialized_node3);

                        set = new SortedSet<int>();
                        foreach (var node in EnumerateEngineNodes())
                            if (node is NumericNode n)
                                set.Add(n.Index);

                        Assert.True(Enumerable.SequenceEqual(comparisonArray, set.ToArray()));
                        Assert.AreEqual(deserialized_node0.Children.Count, 2);
                        Assert.AreEqual(EnumerateEngineNodes().Count(), 3);
                        break;
                }
            });

            tc.End();

            static IEnumerable<Altseed2.Node> EnumerateEngineNodes()
            {
                foreach (var child in Engine.GetNodes())
                {
                    yield return child;
                    foreach (var node in child.EnumerateDescendants())
                        yield return node;
                }
            }
        }

        [Serializable]
        private class NumericNode : Altseed2.Node
        {
            public int Index { get; set; }
            public NumericNode(int index)
            {
                Index = index;
            }
            public override string ToString() => Index.ToString();
        }
    }
}
