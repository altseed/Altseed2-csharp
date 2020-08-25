using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    public class ReflectionSerialize
    {
        private static StreamWriter writer;
        private static void Serialize(string path, object item)
        {
            var direc = Path.GetDirectoryName(path);
            if (!Directory.Exists(direc)) Directory.CreateDirectory(direc);
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, item);
        }

        private static object Deserialize(string path)
        {
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.Open);
            return formatter.Deserialize(stream);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Serialization()
        {
            if (!Directory.Exists("Serialization")) Directory.CreateDirectory("Serialization");
            writer = new StreamWriter("Serialization/SerializationLog.txt", false)
            {
                AutoFlush = true
            };
            var tc = new TestCore();
            tc.Init();

            foreach (var (_, info) in ReflectionSources.Info)
            {
                if (!info.DoSerialization) continue;
                var replacedTypeName = info.Type.FullName.Replace('.', '_').Replace('`', '_');

                var path = $"Serialization/Binaries/{replacedTypeName}.bin";

                Serialize(path, info.Value);
                if (!System.IO.File.Exists(path)) throw new AssertionException($"Failed to Serialze object\nType: {info.Type.FullName}");

                var deSerialized = Deserialize(path);
                Assert.NotNull(deSerialized);

                writer.WriteLine($"-{info.Type}-");

                EnumerateMembers(info.Value, deSerialized, info.Type, info.FieldInfos, info.PropertyInfos, info.MethodsInfos, $"{info.Type.FullName}");

                writer.WriteLine();
            }

            tc.End();
        }

        private static void EnumerateMembers(object obj1, object obj2, Type type, FieldInfo[] fields, PropertyInfo[] properties, (MethodInfo, object[])[] methods, string name)
        {
            if (!ReflectionSources.Info.ContainsKey(type) && type.IsClass && type.BaseType != null && type.BaseType != typeof(object)) EnumerateMembers(obj1, obj2, type.BaseType, fields, properties, methods, name);
            if (ReflectionSources.Info.TryGetValue(type, out var refInfo))
            {
                var values = refInfo.OptionalValueProvider?.Invoke(obj1, obj2);
                if (values != null)
                    foreach (var (valueName, valueType, comparison1, comparison2) in values)
                        Compare(comparison1, comparison2, valueType, $"{name}.{valueName}");
            }
            foreach (var field in fields) Compare(field.GetValue(obj1), field.GetValue(obj2), field.FieldType, $"{name}.{field.Name}");
            foreach (var property in properties) Compare(property.GetValue(obj1), property.GetValue(obj2), property.PropertyType, $"{name}.{property.Name}");
            foreach (var (method, args) in methods) Compare(method.Invoke(obj1, args), method.Invoke(obj2, args), method.ReturnType, $"{name}.{method.Name}");
        }

        private static void Compare(object obj1, object obj2, Type type, string name)
        {
            if (obj1 == null)
            {
                Assert.Null(obj2, $"{name}\nBasic obj: null\nDeserialized obj: Not null");
                writer.WriteLine($"{name}<{type.FullName}> : {obj1.ToLogText()} - {obj2.ToLogText()}");
                return;
            }
            Assert.NotNull(obj2, $"{name}\nBasic obj: Not null\nDeserialized obj: null");
            //if (obj1.GetType() != type) throw new AssertionException($"typeof obj1 is not {type.FullName}");
            //if (obj2.GetType() != type) throw new AssertionException($"typeof obj2 is not {type.FullName}");

            if (ReflectionSources.Info.TryGetValue(type, out var refInfo))
            {
                EnumerateMembers(obj1, obj2, type, refInfo.FieldInfos, refInfo.PropertyInfos, refInfo.MethodsInfos, name);
                return;
            }
            switch (type)
            {
                case Type t when t == typeof(float):
                    if (System.Math.Abs((float)obj1 - (float)obj2) >= MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t == typeof(double):
                    if (System.Math.Abs((double)obj1 - (double)obj2) >= MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t == typeof(decimal):
                    if (System.Math.Abs((decimal)obj1 - (decimal)obj2) >= (decimal)MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t.IsEnum:
                    if ((int)obj1 != (int)obj2) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t.Name == typeof(KeyValuePair<,>).Name:
                    Compare(type.GetProperty("Key").GetValue(obj1), type.GetProperty("Key").GetValue(obj2), type.GetGenericArguments()[0], $"{name}.Key");
                    Compare(type.GetProperty("Value").GetValue(obj1), type.GetProperty("Value").GetValue(obj2), type.GetGenericArguments()[1], $"{name}.Value");
                    return;
                case Type t when (t.HasInterface(typeof(IEquatable<>)) && t.GetInterface(typeof(IEquatable<>).FullName).GetGenericArguments()[0] == t):
                    var IEquatableT = t.GetInterface(typeof(IEquatable<>).FullName);
                    if (!(bool)IEquatableT.GetMethod("Equals").Invoke(obj1, new[] { obj2 })) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t.HasInterface(typeof(IEnumerable)):
                    var array1 = ((IEnumerable)obj1).ToObjectArray();
                    var array2 = ((IEnumerable)obj2).ToObjectArray();
                    if (array1.Length != array2.Length) throw new AssertionException($"{name}\nCollection Count is not same\nCount1: {array1.Length}\nCount2: {array2.Length}");
                    for (int i = 0; i < array1.Length; i++) Compare(array1[i], array2[i], array1[i]?.GetType(), $"{name}[{i}]");
                    return;
                default:
                    var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    var methods = Array.Empty<(MethodInfo, object[])>();
                    var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    EnumerateMembers(obj1, obj2, type, fields, properties, methods, name);
                    break;
            }
            writer.WriteLine($"{name}<{type.FullName}> : {obj1.ToLogText()} - {obj2.ToLogText()}");
        }

        internal static class ReflectionSources
        {
            public static Dictionary<Type, ReflectionInfo> Info { get; } = GetInfo();
            private static Dictionary<Type, ReflectionInfo> GetInfo()
            {
                var result = new Dictionary<Type, ReflectionInfo>();

                // Altseed2.Int8Array
                var int8Array = ReflectionInfo.Create(Int8Array.Create((ReadOnlySpan<byte>)new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
                int8Array.OptionalValueProvider = (x, y) => new[]
                {
                    new OptionalValueEntry()
                    {
                        Name = "Values",
                        Type = typeof(byte[]),
                        Value1 = ((Int8Array)x).ToArray(),
                        Value2 = ((Int8Array)y).ToArray(),
                    },
                };
                result.Add(int8Array.Type, int8Array);

                // Altseed2.Int32Array
                var int32Array = ReflectionInfo.Create(Int32Array.Create((ReadOnlySpan<int>)new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
                int32Array.OptionalValueProvider = (x, y) => new[]
                {
                    new OptionalValueEntry()
                    {
                        Name = "Values",
                        Type = typeof(int[]),
                        Value1 = ((Int32Array)x).ToArray(),
                        Value2 = ((Int32Array)y).ToArray(),
                    },
                };
                result.Add(int32Array.Type, int32Array);

                // Altseed2.VertexArray
                var vertexArray = ReflectionInfo.Create(VertexArray.Create((ReadOnlySpan<Vertex>)new Vertex[]
                {
                    new Vertex { Color = new Color(255, 100, 100), Position = new Vector3F(0f, 0f, 0.5f), UV1 = new Vector2F(0.3f, 0.3f), UV2 = new Vector2F(1f, 1f) },
                    new Vertex { Color = new Color(100, 255, 100), Position = new Vector3F(10f, 0f, 0.5f), UV1 = new Vector2F(0.4f, 0.4f), UV2 = new Vector2F(-1f, 1f) },
                    new Vertex { Color = new Color(100, 100, 255), Position = new Vector3F(10f, 10f, 0.5f), UV1 = new Vector2F(0.5f, 0.5f), UV2 = new Vector2F(1f, -1f) },
                    new Vertex { Color = new Color(255, 255, 255), Position = new Vector3F(0f, 10f, 0.5f), UV1 = new Vector2F(0.6f, 0.6f), UV2 = new Vector2F(-1f, -1f) }
                }));
                vertexArray.OptionalValueProvider = (x, y) => new[]
                {
                    new OptionalValueEntry()
                    {
                        Name = "Values",
                        Type = typeof(Vertex[]),
                        Value1 = ((VertexArray)x).ToArray(),
                        Value2 = ((VertexArray)y).ToArray(),
                    },
                };
                result.Add(vertexArray.Type, vertexArray);

                // Altseed2.FloatArray
                var floatArray = ReflectionInfo.Create(FloatArray.Create((ReadOnlySpan<float>)new float[] { 0, 1f, 0.2f, 0.3f, 0.4f, 0.5f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f }));
                floatArray.OptionalValueProvider = (x, y) => new[]
                {
                    new OptionalValueEntry()
                    {
                        Name = "Values",
                        Type = typeof(float[]),
                        Value1 = ((FloatArray)x).ToArray(),
                        Value2 = ((FloatArray)y).ToArray(),
                    },
                };
                result.Add(floatArray.Type, floatArray);

                // Altseed2.Verctor2FArray
                var vector2FArray = ReflectionInfo.Create(Vector2FArray.Create((ReadOnlySpan<Vector2F>)new[]
                {
                    new Vector2F(0.1f, 0.1f),
                    new Vector2F(0.2f, 0.2f),
                    new Vector2F(0.3f, 0.3f),
                    new Vector2F(0.4f, 0.4f),
                    new Vector2F(0.5f, 0.5f),
                    new Vector2F(0.6f, 0.6f),
                    new Vector2F(0.7f, 0.7f),
                    new Vector2F(0.8f, 0.8f),
                    new Vector2F(0.9f, 0.9f),
                    new Vector2F(1.0f, 1.0f),
                }));
                vector2FArray.OptionalValueProvider = (x, y) => new[]
                {
                    new OptionalValueEntry()
                    {
                        Name = "Values",
                        Type = typeof(Vector2F[]),
                        Value1 = ((Vector2FArray)x).ToArray(),
                        Value2 = ((Vector2FArray)y).ToArray(),
                    },
                };
                result.Add(vector2FArray.Type, vector2FArray);

                // Altseed2.CircleCollider
                var circleCollider_Value = CircleCollider.Create();
                circleCollider_Value.Position = new Vector2F(30f, 30f);
                circleCollider_Value.Radius = 25f;
                circleCollider_Value.Rotation = MathHelper.DegreeToRadian(30f);
                var circleCollider = ReflectionInfo.Create(circleCollider_Value);
                circleCollider.PropertyInfos = new[]
                {
                    circleCollider.GetProperty("Position"),
                    circleCollider.GetProperty("Radius"),
                    circleCollider.GetProperty("Rotation"),
                };
                result.Add(circleCollider.Type, circleCollider);

                // Altseed2.PolygonCollider
                var polygonCollider_Value = PolygonCollider.Create();
                polygonCollider_Value.Position = new Vector2F(30f, 30f);
                polygonCollider_Value.Rotation = MathHelper.DegreeToRadian(30f);
                polygonCollider_Value.Vertexes = new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(0f, 10f),
                    new Vector2F(10f, 10f),
                    new Vector2F(10f, 0f),
                };
                var polygonCollider = ReflectionInfo.Create(polygonCollider_Value);
                polygonCollider.PropertyInfos = new[]
                {
                    polygonCollider.GetProperty("Position"),
                    polygonCollider.GetProperty("Rotation"),
                    polygonCollider.GetProperty("Vertexes"),
                };
                result.Add(polygonCollider.Type, polygonCollider);

                // Altseed2.RectangleCollider
                var rectangleCollider_Value = RectangleCollider.Create();
                rectangleCollider_Value.CenterPosition = new Vector2F(25f, 25f);
                rectangleCollider_Value.Position = new Vector2F(30f, 30f);
                rectangleCollider_Value.Rotation = MathHelper.DegreeToRadian(30f);
                rectangleCollider_Value.Size = new Vector2F(50f, 50f);
                var rectangleCollider = ReflectionInfo.Create(rectangleCollider_Value);
                rectangleCollider.PropertyInfos = new[]
                {
                    rectangleCollider.GetProperty("CenterPosition"),
                    rectangleCollider.GetProperty("Position"),
                    rectangleCollider.GetProperty("Rotation"),
                    rectangleCollider.GetProperty("Size"),
                };
                result.Add(rectangleCollider.Type, rectangleCollider);

                // Altseed2.Configuration
                var configuration = ReflectionInfo.Create(new Configuration()
                {
                    ConsoleLoggingEnabled = true,
                    DeviceType = GraphicsDevice.DirectX,
                    FileLoggingEnabled = true,
                    IsFullscreen = true,
                    IsGraphicsOnly = false,
                    IsResizable = true,
                    LogFileName = "Log.txt",
                    ToolEnabled = true,
                    VisibleTransformInfo = true,
                    WaitVSync = true
                });
                configuration.PropertyInfos = new[]
                {
                    configuration.GetProperty("ConsoleLoggingEnabled"),
                    configuration.GetProperty("DeviceType"),
                    configuration.GetProperty("FileLoggingEnabled"),
                    configuration.GetProperty("IsFullscreen"),
                    configuration.GetProperty("IsGraphicsOnly"),
                    configuration.GetProperty("IsResizable"),
                    configuration.GetProperty("LogFileName"),
                    configuration.GetProperty("ToolEnabled"),
                    configuration.GetProperty("VisibleTransformInfo"),
                    configuration.GetProperty("WaitVSync"),
                };
                result.Add(configuration.Type, configuration);

                // Altseed2.Font
                var font_Value = Font.LoadDynamicFontStrict("TestData/Font/GenYoMinJP-Bold.ttf", 30);
                var font = ReflectionInfo.Create(font_Value);
                font.PropertyInfos = new[]
                {
                    font.GetProperty("Ascent"),
                    font.GetProperty("Descent"),
                    font.GetProperty("IsStaticFont"),
                    font.GetProperty("LineGap"),
                    font.GetProperty("Path"),
                    font.GetProperty("Size"),
                };
                result.Add(font.Type, font);

                // Altseed2.Vertex
                var vertex = ReflectionInfo.Create(new Vertex()
                {
                    Color = new Color(255, 100, 100),
                    Position = new Vector3F(30f, 30f, 30f),
                    UV1 = new Vector2F(0.1f, 0.1f),
                    UV2 = new Vector2F(1.0f, 1.0f)
                });
                vertex.FieldInfos = new[]
                {
                    vertex.GetField("Color"),
                    vertex.GetField("Position"),
                    vertex.GetField("UV1"),
                    vertex.GetField("UV2"),
                };
                result.Add(vertex.Type, vertex);

                // Altseed2.Color
                var color = ReflectionInfo.Create(new Color(255, 100, 100, 50));
                color.FieldInfos = new[]
                {
                    color.GetField("R"),
                    color.GetField("G"),
                    color.GetField("B"),
                    color.GetField("A"),
                };
                result.Add(color.Type, color);

                // Altseed2.RenderPassParameter
                var renderPassParameter = ReflectionInfo.Create(new RenderPassParameter()
                {
                    ClearColor = new Color(255, 100, 100),
                    IsColorCleared = true,
                    IsDepthCleared = true,
                });
                renderPassParameter.FieldInfos = new[]
                {
                    renderPassParameter.GetField("ClearColor"),
                    renderPassParameter.GetField("IsColorCleared"),
                    renderPassParameter.GetField("IsDepthCleared"),
                };
                result.Add(renderPassParameter.Type, renderPassParameter);

                // Altseed2.AlphaBlend
                var alphaBlend = ReflectionInfo.Create(AlphaBlend.Normal);
                alphaBlend.FieldInfos = new[]
                {
                    alphaBlend.GetField("IsBlendEnabled"),
                    alphaBlend.GetField("BlendSrcFunc"),
                    alphaBlend.GetField("BlendDstFunc"),
                    alphaBlend.GetField("BlendSrcFuncAlpha"),
                    alphaBlend.GetField("BlendDstFuncAlpha"),
                    alphaBlend.GetField("BlendEquationRGB"),
                    alphaBlend.GetField("BlendEquationAlpha"),
                };
                result.Add(alphaBlend.Type, alphaBlend);

                // Altseed2.StaticFile
                var staticFile = ReflectionInfo.Create(StaticFile.CreateStrict("TestData/IO/test.txt"));
                staticFile.PropertyInfos = new[]
                {
                    staticFile.GetProperty("Buffer"),
                    staticFile.GetProperty("IsInPackage"),
                    staticFile.GetProperty("Path"),
                    staticFile.GetProperty("Size"),
                };
                result.Add(staticFile.Type, staticFile);

                // Altseed2.StreamFile
                var streamFile_Value = StreamFile.CreateStrict("TestData/IO/test.txt");
                streamFile_Value.Read(1);
                var streamFile = ReflectionInfo.Create(streamFile_Value);
                streamFile.PropertyInfos = new[]
                {
                    streamFile.GetProperty("CurrentPosition"),
                    streamFile.GetProperty("IsInPackage"),
                    streamFile.GetProperty("Path"),
                    streamFile.GetProperty("Size"),
                    streamFile.GetProperty("TempBuffer"),
                    streamFile.GetProperty("TempBufferSize"),
                };
                result.Add(streamFile.Type, streamFile);

                // Altseed2/Material
                var material_Value = Material.Create();
                var material_Value_shader = Shader.Create("MaterialShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel);
                material_Value.SetShader(material_Value_shader);
                material_Value.SetVector4F("Vec1", new Vector4F(20, 20, 20, 20));
                material_Value.AlphaBlend = AlphaBlend.Normal;
                var material = ReflectionInfo.Create(material_Value);
                material.FieldInfos = new[]
                {
                    material.GetField("matrixes"),
                    material.GetField("textures"),
                    material.GetField("vectors"),
                };
                material.MethodsInfos = new[]
                {
                    (material.GetMethod("GetShader"), new object[]{ ShaderStage.Pixel }),
                };
                material.PropertyInfos = new[]
                {
                    material.GetProperty("AlphaBlend"),
                };
                result.Add(material.Type, material);

                // Altseed2.RenderedCamera
                var renderedCamera_Value = RenderedCamera.Create();
                renderedCamera_Value.RenderPassParameter = new RenderPassParameter(new Color(255, 100, 100), true, true);
                renderedCamera_Value.TargetTexture = RenderTexture.Create(new Vector2I(300, 300), TextureFormat.R32G32B32A32_FLOAT);
                renderedCamera_Value.ViewMatrix = MathHelper.CalcTransform(new Vector2F(30f, 30f), MathHelper.DegreeToRadian(30f), new Vector2F(3f, 2f));
                var renderedCamera = ReflectionInfo.Create(renderedCamera_Value);
                renderedCamera.PropertyInfos = new[]
                {
                    renderedCamera.GetProperty("RenderPassParameter"),
                    renderedCamera.GetProperty("TargetTexture"),
                    renderedCamera.GetProperty("ViewMatrix"),
                };
                result.Add(renderedCamera.Type, renderedCamera);

                // Altseed2.RenderedPolygon
                var renderedPolygon_Value = RenderedPolygon.Create();
                renderedPolygon_Value.AlphaBlend = AlphaBlend.Normal;
                renderedPolygon_Value.Material = Material.Create();
                renderedPolygon_Value.Material.AlphaBlend = AlphaBlend.Add;
                renderedPolygon_Value.Material.SetShader(Shader.Create("RenderedPolygonShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel));
                renderedPolygon_Value.Material.SetVector4F("Vec", new Vector4F(10f, 20f, 30f, 40f));
                renderedPolygon_Value.Src = new RectF(30f, 30f, 50f, 50f);
                renderedPolygon_Value.Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png");
                renderedPolygon_Value.Texture.FilterType = TextureFilter.Nearest;
                renderedPolygon_Value.Transform = MathHelper.CalcTransform(new Vector2F(30f, 30f), MathHelper.DegreeToRadian(30f), new Vector2F(3f, 2f));
                renderedPolygon_Value.Vertexes = VertexArray.Create((ReadOnlySpan<Vertex>)new Vertex[]
                {
                    new Vertex { Color = new Color(255, 100, 100), Position = new Vector3F(0f, 0f, 0.5f), UV1 = new Vector2F(0.3f, 0.3f), UV2 = new Vector2F(1f, 1f) },
                    new Vertex { Color = new Color(100, 255, 100), Position = new Vector3F(10f, 0f, 0.5f), UV1 = new Vector2F(0.4f, 0.4f), UV2 = new Vector2F(-1f, 1f) },
                    new Vertex { Color = new Color(100, 100, 255), Position = new Vector3F(10f, 10f, 0.5f), UV1 = new Vector2F(0.5f, 0.5f), UV2 = new Vector2F(1f, -1f) },
                    new Vertex { Color = new Color(255, 255, 255), Position = new Vector3F(0f, 10f, 0.5f), UV1 = new Vector2F(0.6f, 0.6f), UV2 = new Vector2F(-1f, -1f) }
                });
                var renderedPolygon = ReflectionInfo.Create(renderedPolygon_Value);
                renderedPolygon.PropertyInfos = new[]
                {
                    renderedPolygon.GetProperty("AlphaBlend"),
                    renderedPolygon.GetProperty("Material"),
                    renderedPolygon.GetProperty("Src"),
                    renderedPolygon.GetProperty("Texture"),
                    renderedPolygon.GetProperty("Transform"),
                    renderedPolygon.GetProperty("Vertexes"),
                };
                result.Add(renderedPolygon.Type, renderedPolygon);

                // Altseed2.RenderedSprite
                var renderedSprite_Value = RenderedSprite.Create();
                renderedSprite_Value.AlphaBlend = AlphaBlend.Normal;
                renderedSprite_Value.Color = new Color(255, 100, 100);
                renderedSprite_Value.Material = Material.Create();
                renderedSprite_Value.Material.AlphaBlend = AlphaBlend.Add;
                renderedSprite_Value.Material.SetShader(Shader.Create("RenderedPolygonShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel));
                renderedSprite_Value.Material.SetVector4F("Vec", new Vector4F(10f, 20f, 30f, 40f));
                renderedSprite_Value.Src = new RectF(30f, 30f, 50f, 50f);
                renderedSprite_Value.Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png");
                renderedSprite_Value.Texture.FilterType = TextureFilter.Linear;
                renderedSprite_Value.Transform = MathHelper.CalcTransform(new Vector2F(30f, 30f), MathHelper.DegreeToRadian(30f), new Vector2F(3f, 2f));
                var renderedSprite = ReflectionInfo.Create(renderedSprite_Value);
                renderedSprite.PropertyInfos = new[]
                {
                    renderedSprite.GetProperty("AlphaBlend"),
                    renderedSprite.GetProperty("Color"),
                    renderedSprite.GetProperty("Material"),
                    renderedSprite.GetProperty("Src"),
                    renderedSprite.GetProperty("Texture"),
                    renderedSprite.GetProperty("Transform"),
                };
                result.Add(renderedSprite.Type, renderedSprite);

                // Altseed2.RenderedText
                var renderedText_Value = RenderedText.Create();
                renderedText_Value.AlphaBlend = AlphaBlend.Normal;
                renderedText_Value.CharacterSpace = 20f;
                renderedText_Value.Color = new Color(255, 100, 100);
                renderedText_Value.Font = Font.LoadDynamicFontStrict("TestData/Font/GenYoMinJP-Bold.ttf", 30);
                renderedText_Value.IsEnableKerning = true;
                renderedText_Value.LineGap = 10f;
                renderedText_Value.MaterialGlyph = Material.Create();
                renderedText_Value.MaterialGlyph.AlphaBlend = AlphaBlend.Add;
                renderedText_Value.MaterialGlyph.SetShader(Shader.Create("RenderedPolygonShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel));
                renderedText_Value.MaterialGlyph.SetVector4F("Vec", new Vector4F(10f, 20f, 30f, 40f));
                renderedText_Value.MaterialImage = Material.Create();
                renderedText_Value.MaterialImage.AlphaBlend = AlphaBlend.Substract;
                renderedText_Value.MaterialImage.SetShader(Shader.Create("RenderedPolygonShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel));
                renderedText_Value.MaterialImage.SetVector4F("Vec", new Vector4F(10f, 20f, 30f, 40f));
                renderedText_Value.Text = "Text";
                renderedText_Value.Transform = MathHelper.CalcTransform(new Vector2F(30f, 30f), MathHelper.DegreeToRadian(30f), new Vector2F(3f, 2f));
                renderedText_Value.Weight = 45;
                renderedText_Value.WritingDirection = WritingDirection.Horizontal;
                var renderedText = ReflectionInfo.Create(renderedText_Value);
                renderedText.PropertyInfos = new[]
                {
                    renderedText.GetProperty("AlphaBlend"),
                    renderedText.GetProperty("CharacterSpace"),
                    renderedText.GetProperty("Color"),
                    renderedText.GetProperty("Font"),
                    renderedText.GetProperty("IsEnableKerning"),
                    renderedText.GetProperty("LineGap"),
                    renderedText.GetProperty("MaterialGlyph"),
                    renderedText.GetProperty("MaterialImage"),
                    renderedText.GetProperty("Text"),
                    renderedText.GetProperty("TextureSize"),
                    renderedText.GetProperty("Transform"),
                    renderedText.GetProperty("Weight"),
                    renderedText.GetProperty("WritingDirection"),
                };
                result.Add(renderedText.Type, renderedText);

                // Altseed2.Shader
                var shader = ReflectionInfo.Create(Shader.Create("SerializedShader", Engine.Graphics.BuiltinShader.TextureMixShader, ShaderStage.Pixel));
                shader.PropertyInfos = new[]
                {
                    shader.GetProperty("Code"),
                    shader.GetProperty("Name"),
                    shader.GetProperty("StageType"),
                };
                result.Add(shader.Type, shader);

                // Altseed2.Sound
                var sound_Value = Altseed2.Sound.LoadStrict("TestData/Sound/bgm1.ogg", false);
                sound_Value.IsLoopingMode = true;
                sound_Value.LoopEndPoint = 20.5f;
                sound_Value.LoopStartingPoint = 1.5f;
                var sound = ReflectionInfo.Create(sound_Value);
                sound.PropertyInfos = new[]
                {
                    sound.GetProperty("IsDecompressed"),
                    sound.GetProperty("IsLoopingMode"),
                    sound.GetProperty("Length"),
                    sound.GetProperty("LoopEndPoint"),
                    sound.GetProperty("LoopStartingPoint"),
                    sound.GetProperty("Path"),
                };
                result.Add(sound.Type, sound);

                // Altseed2.Texture2D
                var texture2D_Value = Texture2D.LoadStrict("TestData/IO/AltseedPink.png");
                texture2D_Value.FilterType = TextureFilter.Linear;
                texture2D_Value.WrapMode = TextureWrapMode.Repeat;
                var texture2D = ReflectionInfo.Create(texture2D_Value);
                texture2D.PropertyInfos = new[]
                {
                    texture2D.GetProperty("FilterType"),
                    texture2D.GetProperty("Format"),
                    texture2D.GetProperty("Path"),
                    texture2D.GetProperty("Size"),
                    texture2D.GetProperty("WrapMode"),
                };
                result.Add(texture2D.Type, texture2D);

                // Altseed2.RenderTexture
                var renderTexture_Value = RenderTexture.Create(new Vector2I(300, 300), TextureFormat.R32G32B32A32_FLOAT);
                renderTexture_Value.FilterType = TextureFilter.Linear;
                renderTexture_Value.WrapMode = TextureWrapMode.Clamp;
                var renderTexture = ReflectionInfo.Create(renderTexture_Value);
                renderTexture.PropertyInfos = new[]
                {
                    renderTexture.GetProperty("FilterType"),
                    renderTexture.GetProperty("Format"),
                    renderTexture.GetProperty("Size"),
                    renderTexture.GetProperty("WrapMode"),
                };
                result.Add(renderTexture.Type, renderTexture);



                // Optional
                var textureBase = ReflectionInfo.Create(default(TextureBase));
                textureBase.DoSerialization = false;
                textureBase.OptionalValueProvider = (x, y) =>
                {
                    if (x == null)
                    {
                        if (y is Texture2D _t2d2) return new[] { new OptionalValueEntry(string.Empty, typeof(Texture2D), null, _t2d2) };
                        if (y is RenderTexture _r2) return new[] { new OptionalValueEntry(string.Empty, typeof(RenderTexture), null, _r2) };
                        return new[] { new OptionalValueEntry(string.Empty, typeof(Texture2D), null, y) };
                    }
                    if (x is Texture2D _t2d1)
                    {
                        if (y is Texture2D _t2d2) return new[] { new OptionalValueEntry(string.Empty, typeof(Texture2D), _t2d1, _t2d2) };
                        else if (y == null) return new[] { new OptionalValueEntry(string.Empty, typeof(Texture2D), _t2d1, null) };
                    }
                    if (x is RenderTexture _r1)
                    {
                        if (y is RenderTexture _r2) return new[] { new OptionalValueEntry(string.Empty, typeof(RenderTexture), _r1, _r2) };
                        else if (y == null) return new[] { new OptionalValueEntry(string.Empty, typeof(RenderTexture), _r1, null) };
                    }
                    throw new AssertionException($"Invalid Texture Type\nobj1: {x.GetType().FullName}\nobj2: {y?.GetType().FullName ?? "null"}");
                };
                result.Add(textureBase.Type, textureBase);

                return result;
                //Altseed2.
            }
        }

        public sealed class ReflectionInfo
        {
            public bool DoSerialization { get; set; } = true;
            public FieldInfo[] FieldInfos { get => _fieldInfos; set => _fieldInfos = value ?? Array.Empty<FieldInfo>(); }
            private FieldInfo[] _fieldInfos = Array.Empty<FieldInfo>();
            public (MethodInfo, object[])[] MethodsInfos { get => _methodInfos; set => _methodInfos = value ?? Array.Empty<(MethodInfo, object[])>(); }
            private (MethodInfo, object[])[] _methodInfos = Array.Empty<(MethodInfo, object[])>();
            public OptionalValueProvider OptionalValueProvider { get; set; }
            public PropertyInfo[] PropertyInfos { get => _propertyInfos; set => _propertyInfos = value ?? Array.Empty<PropertyInfo>(); }
            private PropertyInfo[] _propertyInfos = Array.Empty<PropertyInfo>();
            public Type Type { get; private set; }
            public object Value { get; private set; }

            public static ReflectionInfo Create<T>(T value)
            {
                var result = new ReflectionInfo
                {
                    Type = typeof(T),
                    Value = value
                };
                return result;
            }
        }


        public delegate IEnumerable<OptionalValueEntry> OptionalValueProvider(object obj1, object obj2);

        public struct OptionalValueEntry
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public object Value1 { get; set; }
            public object Value2 { get; set; }
            public OptionalValueEntry(string name, Type type, object value1, object value2)
            {
                Name = name;
                Type = type;
                Value1 = value1;
                Value2 = value2;
            }
            public readonly void Deconstruct(out string name, out Type type, out object value1, out object value2)
            {
                name = Name;
                type = Type;
                value1 = Value1;
                value2 = Value2;
            }
        }
    }
    internal static class ReflectionHelper
    {
        private const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public static bool HasInterface(this Type type, Type interfaceType) => interfaceType.IsInterface && type.GetInterface(interfaceType.FullName) != null;
        public static FieldInfo GetField(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetField(name, flags) ?? throw new InvalidOperationException($"�t�B�[���h�̓ǂݍ��݂Ɏ��s���܂���\nType: {info.Type.FullName}\nField: {name}");
        public static MethodInfo GetMethod(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetMethod(name, flags) ?? throw new InvalidOperationException($"���\�b�h�̓ǂݍ��݂Ɏ��s���܂���\nType: {info.Type.FullName}\nField: {name}");
        public static PropertyInfo GetProperty(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetProperty(name, flags) ?? throw new InvalidOperationException($"�v���p�e�B�̓ǂݍ��݂Ɏ��s���܂���\nType: {info.Type.FullName}\nField: {name}");
        public static string ToLogText(this object value)
        {
            if (value == null) return "null";
            switch (value)
            {
                case float v: return $"{v}f";
                case double v: return $"{v}d";
                case decimal v: return $"{v}m";
                case char v: return $"'{v}'";
                case string v: return $"\"{v}\"";
                default: return value.ToString();
            }
        }
        public static object[] ToObjectArray(this IEnumerable enumerable)
        {
            object[] result;
            if (enumerable is ICollection c)
            {
                if (c.Count == 0) return Array.Empty<object>();
                result = new object[c.Count];
                c.CopyTo(result, 0);
                return result;
            }
            var list = new List<object>();
            foreach (var current in list) list.Add(current);
            return list.ToArray();
        }
    }
}
