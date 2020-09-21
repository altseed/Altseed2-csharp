using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Altseed2.Test
{
    public partial class ReflectionSerialize
    {
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

                // Altseed2.Vector2FArray
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
                    EnabledCoreModules = CoreModules.Default | CoreModules.Tool,
                    IsResizable = true,
                    LogFileName = "Log.txt",
                    VisibleTransformInfo = true,
                    WaitVSync = true
                });
                configuration.PropertyInfos = new[]
                {
                    configuration.GetProperty("ConsoleLoggingEnabled"),
                    configuration.GetProperty("DeviceType"),
                    configuration.GetProperty("FileLoggingEnabled"),
                    configuration.GetProperty("IsFullscreen"),
                    configuration.GetProperty("EnabledCoreModules"),
                    configuration.GetProperty("IsResizable"),
                    configuration.GetProperty("LogFileName"),
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

                // Altseed2.Material
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
                renderedPolygon_Value.SetDefaultIndexBuffer();
                var renderedPolygon = ReflectionInfo.Create(renderedPolygon_Value);
                renderedPolygon.PropertyInfos = new[]
                {
                    renderedPolygon.GetProperty("AlphaBlend"),
                    renderedPolygon.GetProperty("Buffers"),
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

#if !CI
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
#endif

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

                // Altseed2.Matrix33F
                var matrix33F = ReflectionInfo.Create(Matrix33F.GetScale(new Vector2F(3f, 2f)));
                matrix33F.OptionalValueProvider = (x, y) =>
                {
                    var matx = (Matrix33F)x;
                    var maty = (Matrix33F)y;
                    var array1 = new float[9];
                    var array2 = new float[9];
                    for (int ix = 0; ix < 3; ix++)
                        for (int iy = 0; iy < 3; iy++)
                        {
                            array1[ix * 3 + iy] = matx[ix, iy];
                            array2[ix * 3 + iy] = maty[ix, iy];
                        }
                    return new[] { new OptionalValueEntry("Values", array1.GetType(), array1, array2) };
                };
                result.Add(matrix33F.Type, matrix33F);

                // Altseed2.Matrix33I
                var matrix33I = ReflectionInfo.Create(Matrix33I.GetScale(new Vector2I(3, 2)));
                matrix33I.OptionalValueProvider = (x, y) =>
                {
                    var matx = (Matrix33I)x;
                    var maty = (Matrix33I)y;
                    var array1 = new int[9];
                    var array2 = new int[9];
                    for (int ix = 0; ix < 3; ix++)
                        for (int iy = 0; iy < 3; iy++)
                        {
                            array1[ix * 3 + iy] = matx[ix, iy];
                            array2[ix * 3 + iy] = maty[ix, iy];
                        }
                    return new[] { new OptionalValueEntry("Values", array1.GetType(), array1, array2) };
                };
                result.Add(matrix33I.Type, matrix33I);

                // Altseed2.Matrix44F
                var matrix44F = ReflectionInfo.Create(Matrix44F.GetScale3D(new Vector3F(3f, 2f, 4f)));
                matrix44F.OptionalValueProvider = (x, y) =>
                {
                    var matx = (Matrix44F)x;
                    var maty = (Matrix44F)y;
                    var array1 = new float[16];
                    var array2 = new float[16];
                    for (int ix = 0; ix < 4; ix++)
                        for (int iy = 0; iy < 4; iy++)
                        {
                            array1[ix * 4 + iy] = matx[ix, iy];
                            array2[ix * 4 + iy] = maty[ix, iy];
                        }
                    return new[] { new OptionalValueEntry("Values", array1.GetType(), array1, array2) };
                };
                result.Add(matrix44F.Type, matrix44F);

                // Altseed2.Matrix44I
                var matrix44I = ReflectionInfo.Create(Matrix44I.GetScale3D(new Vector3I(3, 2, 4)));
                matrix44I.OptionalValueProvider = (x, y) =>
                {
                    var matx = (Matrix44I)x;
                    var maty = (Matrix44I)y;
                    var array1 = new int[16];
                    var array2 = new int[16];
                    for (int ix = 0; ix < 4; ix++)
                        for (int iy = 0; iy < 4; iy++)
                        {
                            array1[ix * 4 + iy] = matx[ix, iy];
                            array2[ix * 4 + iy] = maty[ix, iy];
                        }
                    return new[] { new OptionalValueEntry("Values", array1.GetType(), array1, array2) };
                };
                result.Add(matrix44I.Type, matrix44I);

                // Altseed2.RectF
                var rectF = ReflectionInfo.Create(new RectF(30f, 30f, 50f, 50f));
                rectF.FieldInfos = new[]
                {
                    rectF.GetField("X"),
                    rectF.GetField("Y"),
                    rectF.GetField("Width"),
                    rectF.GetField("Height"),
                };
                result.Add(rectF.Type, rectF);

                // Altseed2.RectI
                var rectI = ReflectionInfo.Create(new RectI(30, 30, 50, 50));
                rectI.FieldInfos = new[]
                {
                    rectI.GetField("X"),
                    rectI.GetField("Y"),
                    rectI.GetField("Width"),
                    rectI.GetField("Height"),
                };
                result.Add(rectI.Type, rectI);

                // Altseed2.Vector2F
                var vector2F = ReflectionInfo.Create(new Vector2F(30f, 50f));
                vector2F.FieldInfos = new[]
                {
                    vector2F.GetField("X"),
                    vector2F.GetField("Y"),
                };
                result.Add(vector2F.Type, vector2F);

                // Altseed2.Vector2I
                var vector2I = ReflectionInfo.Create(new Vector2I(30, 50));
                vector2I.FieldInfos = new[]
                {
                    vector2I.GetField("X"),
                    vector2I.GetField("Y"),
                };
                result.Add(vector2I.Type, vector2I);

                // Altseed2.Vector3F
                var vector3F = ReflectionInfo.Create(new Vector3F(30f, 50f, 100f));
                vector3F.FieldInfos = new[]
                {
                    vector3F.GetField("X"),
                    vector3F.GetField("Y"),
                    vector3F.GetField("Z"),
                };
                result.Add(vector3F.Type, vector3F);

                // Altseed2.Vector3I
                var vector3I = ReflectionInfo.Create(new Vector3I(30, 50, 100));
                vector3I.FieldInfos = new[]
                {
                    vector3I.GetField("X"),
                    vector3I.GetField("Y"),
                    vector3I.GetField("Z"),
                };
                result.Add(vector3I.Type, vector3I);

                // Altseed2.Vector4F
                var vector4F = ReflectionInfo.Create(new Vector4F(30f, 50f, 100f, 150f));
                vector4F.FieldInfos = new[]
                {
                    vector4F.GetField("X"),
                    vector4F.GetField("Y"),
                    vector4F.GetField("Z"),
                    vector4F.GetField("W"),
                };
                result.Add(vector4F.Type, vector4F);

                // Altseed2.Vector4I
                var vector4I = ReflectionInfo.Create(new Vector4I(30, 50, 100, 150));
                vector4I.FieldInfos = new[]
                {
                    vector4I.GetField("X"),
                    vector4I.GetField("Y"),
                    vector4I.GetField("Z"),
                    vector4I.GetField("W"),
                };
                result.Add(vector4I.Type, vector4I);

                // Altseed2.CircleColliderNode
                var circleColliderNode = ReflectionInfo.Create(new CircleColliderNode()
                {
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalFlip = false,
                    Position = new Vector2F(30f, 30f),
                    Radius = 50f,
                    Scale = new Vector2F(3f, 2f),
                    ScaleType = CircleColliderNode.ScaleCalcType.Length,
                    VerticalFlip = false,
                });
                circleColliderNode.PropertyInfos = new[]
                {
                    circleColliderNode.GetProperty("Angle"),
                    circleColliderNode.GetProperty("CenterPosition"),
                    circleColliderNode.GetProperty("ContentSize"),
                    circleColliderNode.GetProperty("HorizontalFlip"),
                    circleColliderNode.GetProperty("IsRegistered"),
                    circleColliderNode.GetProperty("IsUpdated"),
                    circleColliderNode.GetProperty("IsUpdatedActually"),
                    circleColliderNode.GetProperty("Position"),
                    circleColliderNode.GetProperty("Radius"),
                    circleColliderNode.GetProperty("Scale"),
                    circleColliderNode.GetProperty("ScaleType"),
                    circleColliderNode.GetProperty("Status"),
                    circleColliderNode.GetProperty("VerticalFlip"),
                };
                result.Add(circleColliderNode.Type, circleColliderNode);

                // Altseed2.PolygonColliderNode
                var polygonColliderNode = ReflectionInfo.Create(new PolygonColliderNode()
                {
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalFlip = false,
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Vertexes = new[]
                    {
                        new Vector2F(0f, 0f),
                        new Vector2F(10f, 0f),
                        new Vector2F(10f, 10f),
                        new Vector2F(0f, 10f),
                    },
                    VerticalFlip = false,
                });
                polygonColliderNode.PropertyInfos = new[]
                {
                    polygonColliderNode.GetProperty("Angle"),
                    polygonColliderNode.GetProperty("CenterPosition"),
                    polygonColliderNode.GetProperty("ContentSize"),
                    polygonColliderNode.GetProperty("HorizontalFlip"),
                    polygonColliderNode.GetProperty("IsRegistered"),
                    polygonColliderNode.GetProperty("IsUpdated"),
                    polygonColliderNode.GetProperty("IsUpdatedActually"),
                    polygonColliderNode.GetProperty("Position"),
                    polygonColliderNode.GetProperty("Scale"),
                    polygonColliderNode.GetProperty("Status"),
                    polygonColliderNode.GetProperty("Vertexes"),
                    polygonColliderNode.GetProperty("VerticalFlip"),
                };
                result.Add(polygonColliderNode.Type, polygonColliderNode);

                // Altseed2.RectangleColliderNode
                var rectangleColliderNode = ReflectionInfo.Create(new RectangleColliderNode()
                {
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalFlip = false,
                    Position = new Vector2F(30f, 30f),
                    RectangleSize = new Vector2F(50f, 50f),
                    Scale = new Vector2F(3f, 2f),
                    VerticalFlip = false,
                });
                rectangleColliderNode.PropertyInfos = new[]
                {
                    rectangleColliderNode.GetProperty("Angle"),
                    rectangleColliderNode.GetProperty("CenterPosition"),
                    rectangleColliderNode.GetProperty("ContentSize"),
                    rectangleColliderNode.GetProperty("HorizontalFlip"),
                    rectangleColliderNode.GetProperty("IsRegistered"),
                    rectangleColliderNode.GetProperty("IsUpdated"),
                    rectangleColliderNode.GetProperty("IsUpdatedActually"),
                    rectangleColliderNode.GetProperty("Position"),
                    rectangleColliderNode.GetProperty("RectangleSize"),
                    rectangleColliderNode.GetProperty("Scale"),
                    rectangleColliderNode.GetProperty("Status"),
                    rectangleColliderNode.GetProperty("VerticalFlip"),
                };
                result.Add(rectangleColliderNode.Type, rectangleColliderNode);

                // Altseed2.ArcNode
                var arcNode = ReflectionInfo.Create(new ArcNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    EndDegree = 330f,
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    Radius = 30f,
                    Scale = new Vector2F(3f, 2f),
                    StartDegree = 30f,
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    VerticalFlip = false,
                    VertNum = 30,
                    ZOrder = 10,
                });
                arcNode.PropertyInfos = new[]
                {
                    arcNode.GetProperty("AlphaBlend"),
                    arcNode.GetProperty("Angle"),
                    arcNode.GetProperty("CameraGroup"),
                    arcNode.GetProperty("CenterPosition"),
                    arcNode.GetProperty("Color"),
                    arcNode.GetProperty("ContentSize"),
                    arcNode.GetProperty("EndDegree"),
                    arcNode.GetProperty("HorizontalFlip"),
                    arcNode.GetProperty("IsDrawn"),
                    arcNode.GetProperty("IsRegistered"),
                    arcNode.GetProperty("IsUpdated"),
                    arcNode.GetProperty("IsUpdatedActually"),
                    arcNode.GetProperty("Material"),
                    arcNode.GetProperty("Position"),
                    arcNode.GetProperty("Radius"),
                    arcNode.GetProperty("Scale"),
                    arcNode.GetProperty("Src"),
                    arcNode.GetProperty("StartDegree"),
                    arcNode.GetProperty("Status"),
                    arcNode.GetProperty("Texture"),
                    arcNode.GetProperty("VerticalFlip"),
                    arcNode.GetProperty("VertNum"),
                    arcNode.GetProperty("ZOrder"),
                };
                result.Add(arcNode.Type, arcNode);

                // Altseed2.CircleNode
                var circleNode = ReflectionInfo.Create(new CircleNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    Radius = 30f,
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    VerticalFlip = false,
                    VertNum = 30,
                    ZOrder = 10,
                });
                circleNode.PropertyInfos = new[]
                {
                    circleNode.GetProperty("AlphaBlend"),
                    circleNode.GetProperty("Angle"),
                    circleNode.GetProperty("CameraGroup"),
                    circleNode.GetProperty("CenterPosition"),
                    circleNode.GetProperty("Color"),
                    circleNode.GetProperty("ContentSize"),
                    circleNode.GetProperty("HorizontalFlip"),
                    circleNode.GetProperty("IsDrawn"),
                    circleNode.GetProperty("IsRegistered"),
                    circleNode.GetProperty("IsUpdated"),
                    circleNode.GetProperty("IsUpdatedActually"),
                    circleNode.GetProperty("Material"),
                    circleNode.GetProperty("Position"),
                    circleNode.GetProperty("Radius"),
                    circleNode.GetProperty("Scale"),
                    circleNode.GetProperty("Src"),
                    circleNode.GetProperty("Status"),
                    circleNode.GetProperty("Texture"),
                    circleNode.GetProperty("VerticalFlip"),
                    circleNode.GetProperty("VertNum"),
                    circleNode.GetProperty("ZOrder"),
                };
                result.Add(circleNode.Type, circleNode);

                // Altseed2.LineNode
                var lineNode = ReflectionInfo.Create(new LineNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Point1 = new Vector2F(30f, 30f),
                    Point2 = new Vector2F(50f, 50f),
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    Thickness = 15f,
                    VerticalFlip = false,
                    ZOrder = 10,
                });
                lineNode.PropertyInfos = new[]
                {
                    lineNode.GetProperty("AlphaBlend"),
                    lineNode.GetProperty("Angle"),
                    lineNode.GetProperty("CameraGroup"),
                    lineNode.GetProperty("CenterPosition"),
                    lineNode.GetProperty("Color"),
                    lineNode.GetProperty("ContentSize"),
                    lineNode.GetProperty("HorizontalFlip"),
                    lineNode.GetProperty("IsDrawn"),
                    lineNode.GetProperty("IsRegistered"),
                    lineNode.GetProperty("IsUpdated"),
                    lineNode.GetProperty("IsUpdatedActually"),
                    lineNode.GetProperty("Material"),
                    lineNode.GetProperty("Point1"),
                    lineNode.GetProperty("Point2"),
                    lineNode.GetProperty("Position"),
                    lineNode.GetProperty("Scale"),
                    lineNode.GetProperty("Src"),
                    lineNode.GetProperty("Status"),
                    lineNode.GetProperty("Texture"),
                    lineNode.GetProperty("Thickness"),
                    lineNode.GetProperty("VerticalFlip"),
                    lineNode.GetProperty("ZOrder"),
                };
                result.Add(lineNode.Type, lineNode);

                // Altseed2.RectangleNode
                var rectangleNode = ReflectionInfo.Create(new RectangleNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    RectangleSize = new Vector2F(150f, 150f),
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    VerticalFlip = false,
                    ZOrder = 10,
                });
                rectangleNode.PropertyInfos = new[]
                {
                    rectangleNode.GetProperty("AlphaBlend"),
                    rectangleNode.GetProperty("Angle"),
                    rectangleNode.GetProperty("CameraGroup"),
                    rectangleNode.GetProperty("CenterPosition"),
                    rectangleNode.GetProperty("Color"),
                    rectangleNode.GetProperty("ContentSize"),
                    rectangleNode.GetProperty("HorizontalFlip"),
                    rectangleNode.GetProperty("IsDrawn"),
                    rectangleNode.GetProperty("IsRegistered"),
                    rectangleNode.GetProperty("IsUpdated"),
                    rectangleNode.GetProperty("IsUpdatedActually"),
                    rectangleNode.GetProperty("Material"),
                    rectangleNode.GetProperty("Position"),
                    rectangleNode.GetProperty("RectangleSize"),
                    rectangleNode.GetProperty("Scale"),
                    rectangleNode.GetProperty("Src"),
                    rectangleNode.GetProperty("Status"),
                    rectangleNode.GetProperty("Texture"),
                    rectangleNode.GetProperty("VerticalFlip"),
                    rectangleNode.GetProperty("ZOrder"),
                };
                result.Add(rectangleNode.Type, rectangleNode);

                // Altseed2.TriangleNode
                var triangleNode = ReflectionInfo.Create(new TriangleNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Point1 = new Vector2F(30f, 30f),
                    Point2 = new Vector2F(50f, 50f),
                    Point3 = new Vector2F(50f, 50f),
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    VerticalFlip = false,
                    ZOrder = 10,
                });
                triangleNode.PropertyInfos = new[]
                {
                    triangleNode.GetProperty("AlphaBlend"),
                    triangleNode.GetProperty("Angle"),
                    triangleNode.GetProperty("CameraGroup"),
                    triangleNode.GetProperty("CenterPosition"),
                    triangleNode.GetProperty("Color"),
                    triangleNode.GetProperty("ContentSize"),
                    triangleNode.GetProperty("HorizontalFlip"),
                    triangleNode.GetProperty("IsDrawn"),
                    triangleNode.GetProperty("IsRegistered"),
                    triangleNode.GetProperty("IsUpdated"),
                    triangleNode.GetProperty("IsUpdatedActually"),
                    triangleNode.GetProperty("Material"),
                    triangleNode.GetProperty("Point1"),
                    triangleNode.GetProperty("Point2"),
                    triangleNode.GetProperty("Point3"),
                    triangleNode.GetProperty("Position"),
                    triangleNode.GetProperty("Scale"),
                    triangleNode.GetProperty("Src"),
                    triangleNode.GetProperty("Status"),
                    triangleNode.GetProperty("Texture"),
                    triangleNode.GetProperty("VerticalFlip"),
                    triangleNode.GetProperty("ZOrder"),
                };
                result.Add(triangleNode.Type, triangleNode);

                // Altseed2.AnchorTransformerNode
                var anchorTransformerNode = ReflectionInfo.Create(new AnchorTransformerNode()
                {
                    AnchorMax = new Vector2F(100f, 100f),
                    AnchorMin = new Vector2F(50f, 50f),
                    AnchorMode = AnchorMode.KeepAspect,
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalFlip = false,
                    LeftTop = new Vector2F(10f, 10f),
                    Pivot = new Vector2F(0.3f, 0.3f),
                    Position = new Vector2F(30f, 30f),
                    RightBottom = new Vector2F(50f, 50f),
                    Scale = new Vector2F(3f, 2f),
                    Size = new Vector2F(250f, 250f),
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalFlip = false,
                });
                anchorTransformerNode.PropertyInfos = new[]
                {
                    anchorTransformerNode.GetProperty("AnchorMax"),
                    anchorTransformerNode.GetProperty("AnchorMin"),
                    anchorTransformerNode.GetProperty("AnchorMode"),
                    anchorTransformerNode.GetProperty("Angle"),
                    anchorTransformerNode.GetProperty("CenterPosition"),
                    anchorTransformerNode.GetProperty("HorizontalAlignment"),
                    anchorTransformerNode.GetProperty("HorizontalFlip"),
                    anchorTransformerNode.GetProperty("IsRegistered"),
                    anchorTransformerNode.GetProperty("IsUpdated"),
                    anchorTransformerNode.GetProperty("IsUpdatedActually"),
                    anchorTransformerNode.GetProperty("LeftTop"),
                    anchorTransformerNode.GetProperty("Pivot"),
                    anchorTransformerNode.GetProperty("Position"),
                    anchorTransformerNode.GetProperty("RightBottom"),
                    anchorTransformerNode.GetProperty("Scale"),
                    anchorTransformerNode.GetProperty("Size"),
                    anchorTransformerNode.GetProperty("Status"),
                    anchorTransformerNode.GetProperty("VerticalAlignment"),
                    anchorTransformerNode.GetProperty("VerticalFlip"),
                };
                result.Add(anchorTransformerNode.Type, anchorTransformerNode);

                // Altseed2.CameraNode
                var cameraNode = ReflectionInfo.Create(new CameraNode()
                {
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    ClearColor = new Color(150, 100, 100),
                    Group = 3,
                    IsColorCleared = true,
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    TargetTexture = RenderTexture.Create(new Vector2I(400, 400), TextureFormat.R32G32B32A32_FLOAT),
                });
                cameraNode.PropertyInfos = new[]
                {
                    cameraNode.GetProperty("Angle"),
                    cameraNode.GetProperty("CenterPosition"),
                    cameraNode.GetProperty("ClearColor"),
                    cameraNode.GetProperty("Group"),
                    cameraNode.GetProperty("IsColorCleared"),
                    cameraNode.GetProperty("IsRegistered"),
                    cameraNode.GetProperty("IsUpdated"),
                    cameraNode.GetProperty("IsUpdatedActually"),
                    cameraNode.GetProperty("Position"),
                    cameraNode.GetProperty("Scale"),
                    cameraNode.GetProperty("Status"),
                    cameraNode.GetProperty("TargetTexture"),
                };
                result.Add(cameraNode.Type, cameraNode);

                // Altseed2.Node
                var node = ReflectionInfo.Create(new Altseed2.Node());
                node.PropertyInfos = new[]
                {
                    node.GetProperty("IsRegistered"),
                    node.GetProperty("IsUpdated"),
                    node.GetProperty("IsUpdatedActually"),
                    node.GetProperty("Status"),
                };
                result.Add(node.Type, node);

                // Altseed2.PolygonNode
                var polygonNode = ReflectionInfo.Create(new PolygonNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    Vertexes = new Vertex[]
                    {
                        new Vertex { Color = new Color(255, 100, 100), Position = new Vector3F(0f, 0f, 0.5f), UV1 = new Vector2F(0.3f, 0.3f), UV2 = new Vector2F(1f, 1f) },
                        new Vertex { Color = new Color(100, 255, 100), Position = new Vector3F(10f, 0f, 0.5f), UV1 = new Vector2F(0.4f, 0.4f), UV2 = new Vector2F(-1f, 1f) },
                        new Vertex { Color = new Color(100, 100, 255), Position = new Vector3F(10f, 10f, 0.5f), UV1 = new Vector2F(0.5f, 0.5f), UV2 = new Vector2F(1f, -1f) },
                        new Vertex { Color = new Color(255, 255, 255), Position = new Vector3F(0f, 10f, 0.5f), UV1 = new Vector2F(0.6f, 0.6f), UV2 = new Vector2F(-1f, -1f) }
                    },
                    VerticalFlip = false,
                    ZOrder = 10,
                });
                polygonNode.PropertyInfos = new[]
                {
                    polygonNode.GetProperty("AlphaBlend"),
                    polygonNode.GetProperty("Angle"),
                    polygonNode.GetProperty("Buffers"),
                    polygonNode.GetProperty("CameraGroup"),
                    polygonNode.GetProperty("CenterPosition"),
                    polygonNode.GetProperty("ContentSize"),
                    polygonNode.GetProperty("HorizontalFlip"),
                    polygonNode.GetProperty("IsDrawn"),
                    polygonNode.GetProperty("IsRegistered"),
                    polygonNode.GetProperty("IsUpdated"),
                    polygonNode.GetProperty("IsUpdatedActually"),
                    polygonNode.GetProperty("Material"),
                    polygonNode.GetProperty("Position"),
                    polygonNode.GetProperty("Scale"),
                    polygonNode.GetProperty("Src"),
                    polygonNode.GetProperty("Status"),
                    polygonNode.GetProperty("Texture"),
                    polygonNode.GetProperty("Vertexes"),
                    polygonNode.GetProperty("VerticalFlip"),
                    polygonNode.GetProperty("ZOrder"),
                };
                result.Add(polygonNode.Type, polygonNode);

                // Altseed2.SpriteNode
                var spriteNode = ReflectionInfo.Create(new SpriteNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    Color = new Color(255, 100, 100),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    Material = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Texture = Texture2D.LoadStrict("TestData/IO/AltseedPink.png"),
                    Src = new RectF(30f, 30f, 50f, 50f),
                    VerticalFlip = false,
                    ZOrder = 10,
                });
                spriteNode.PropertyInfos = new[]
                {
                    spriteNode.GetProperty("AlphaBlend"),
                    spriteNode.GetProperty("Angle"),
                    spriteNode.GetProperty("CameraGroup"),
                    spriteNode.GetProperty("CenterPosition"),
                    spriteNode.GetProperty("Color"),
                    spriteNode.GetProperty("ContentSize"),
                    spriteNode.GetProperty("HorizontalFlip"),
                    spriteNode.GetProperty("IsDrawn"),
                    spriteNode.GetProperty("IsRegistered"),
                    spriteNode.GetProperty("IsUpdated"),
                    spriteNode.GetProperty("IsUpdatedActually"),
                    spriteNode.GetProperty("Material"),
                    spriteNode.GetProperty("Position"),
                    spriteNode.GetProperty("Scale"),
                    spriteNode.GetProperty("Src"),
                    spriteNode.GetProperty("Status"),
                    spriteNode.GetProperty("Texture"),
                    spriteNode.GetProperty("VerticalFlip"),
                    spriteNode.GetProperty("ZOrder"),
                };
                result.Add(spriteNode.Type, spriteNode);

                // Altseed2.TextNode
                var textNode = ReflectionInfo.Create(new TextNode()
                {
                    AlphaBlend = AlphaBlend.Normal,
                    Angle = 30f,
                    CameraGroup = 1,
                    CenterPosition = new Vector2F(50f, 50f),
                    CharacterSpace = 10f,
                    Color = new Color(255, 100, 100),
                    Font = Font.LoadDynamicFontStrict("TestData/Font/GenYoMinJP-Bold.ttf", 30),
                    HorizontalFlip = false,
                    IsDrawn = false,
                    IsEnableKerning = true,
                    LineGap = 30f,
                    MaterialGlyph = Material.Create(),
                    MaterialImage = Material.Create(),
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    Text = "Text",
                    VerticalFlip = false,
                    Weight = 15f,
                    WritingDirection = WritingDirection.Vertical,
                    ZOrder = 10,
                });
                textNode.PropertyInfos = new[]
                {
                    textNode.GetProperty("AlphaBlend"),
                    textNode.GetProperty("Angle"),
                    textNode.GetProperty("CameraGroup"),
                    textNode.GetProperty("CenterPosition"),
                    textNode.GetProperty("CharacterSpace"),
                    textNode.GetProperty("Color"),
                    textNode.GetProperty("ContentSize"),
                    textNode.GetProperty("Font"),
                    textNode.GetProperty("HorizontalFlip"),
                    textNode.GetProperty("IsDrawn"),
                    textNode.GetProperty("IsEnableKerning"),
                    textNode.GetProperty("IsRegistered"),
                    textNode.GetProperty("IsUpdated"),
                    textNode.GetProperty("IsUpdatedActually"),
                    textNode.GetProperty("LineGap"),
                    textNode.GetProperty("MaterialGlyph"),
                    textNode.GetProperty("MaterialImage"),
                    textNode.GetProperty("Position"),
                    textNode.GetProperty("Scale"),
                    textNode.GetProperty("Status"),
                    textNode.GetProperty("Text"),
                    textNode.GetProperty("VerticalFlip"),
                    textNode.GetProperty("Weight"),
                    textNode.GetProperty("WritingDirection"),
                    textNode.GetProperty("ZOrder"),
                };
                result.Add(textNode.Type, textNode);

                // Altseed2.TransformerNode
                var transformerNode = ReflectionInfo.Create(new TransformerNode()
                {
                    AbsoluteTransform = MathHelper.CalcTransform(new Vector2F(30f, 30f), MathHelper.DegreeToRadian(30f), new Vector2F(3f, 2f)),
                });
                transformerNode.PropertyInfos = new[]
                {
                    transformerNode.GetProperty("AbsoluteTransform"),
                    transformerNode.GetProperty("InheritedTransform"),
                    transformerNode.GetProperty("IsRegistered"),
                    transformerNode.GetProperty("IsUpdated"),
                    transformerNode.GetProperty("IsUpdatedActually"),
                    transformerNode.GetProperty("RequireCalcTransform"),
                    transformerNode.GetProperty("Status"),
                    transformerNode.GetProperty("Transform"),
                };
                result.Add(transformerNode.Type, transformerNode);

                // Altseed2.TransformNode
                var transformNode = ReflectionInfo.Create(new TransformNode()
                {
                    Angle = 30f,
                    CenterPosition = new Vector2F(50f, 50f),
                    HorizontalFlip = false,
                    Position = new Vector2F(30f, 30f),
                    Scale = new Vector2F(3f, 2f),
                    VerticalFlip = false,
                });
                transformNode.PropertyInfos = new[]
                {
                    transformNode.GetProperty("Angle"),
                    transformNode.GetProperty("CenterPosition"),
                    transformNode.GetProperty("ContentSize"),
                    transformNode.GetProperty("HorizontalFlip"),
                    transformNode.GetProperty("IsRegistered"),
                    transformNode.GetProperty("IsUpdated"),
                    transformNode.GetProperty("IsUpdatedActually"),
                    transformNode.GetProperty("Position"),
                    transformNode.GetProperty("Scale"),
                    transformNode.GetProperty("Status"),
                    transformNode.GetProperty("VerticalFlip"),
                };
                result.Add(transformNode.Type, transformNode);

                // Optional

                //
                // TextureBaseはシリアライズテストは行わないがTextureBase型でCompareが回されるときがあるためその対策
                // 
                var textureBase = ReflectionInfo.Create(default(TextureBase));
                textureBase.DoSerialization = false;
                textureBase.OptionalValueProvider = (x, y) =>
                {
                    if (x == null)
                    {
                        if (y is Texture2D _t2d2) return new[] { new OptionalValueEntry("ToTexture2D", typeof(Texture2D), null, _t2d2) };
                        if (y is RenderTexture _r2) return new[] { new OptionalValueEntry("ToRenderTexture", typeof(RenderTexture), null, _r2) };
                        return new[] { new OptionalValueEntry(string.Empty, typeof(Texture2D), null, y) };
                    }
                    if (x is Texture2D _t2d1)
                    {
                        if (y is Texture2D _t2d2) return new[] { new OptionalValueEntry("ToTexture2D", typeof(Texture2D), _t2d1, _t2d2) };
                        else if (y == null) return new[] { new OptionalValueEntry("ToTexture2D", typeof(Texture2D), _t2d1, null) };
                    }
                    if (x is RenderTexture _r1)
                    {
                        if (y is RenderTexture _r2) return new[] { new OptionalValueEntry("ToRenderTexture", typeof(RenderTexture), _r1, _r2) };
                        else if (y == null) return new[] { new OptionalValueEntry("ToRenderTexture", typeof(RenderTexture), _r1, null) };
                    }
                    throw new AssertionException($"Invalid Texture Type\nobj1: {x.GetType().FullName}\nobj2: {y?.GetType().FullName ?? "null"}");
                };
                result.Add(textureBase.Type, textureBase);

                return result;
            }
        }
    }
}
