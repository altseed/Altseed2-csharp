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
                var replacedTypeName = info.Type.FullName.Replace('.', '_').Replace('`', '_');

                var path = $"Serialization/{replacedTypeName}.bin";

                Serialize(path, info.Value);
                if (!System.IO.File.Exists(path)) throw new AssertionException($"Failed to Serialze object\nType: {info.Type.FullName}");

                var deSerialized = Deserialize(path);
                Assert.NotNull(deSerialized);

                EnumerateMembers(info.Value, deSerialized, info.Type, info.FieldInfos, info.PropertyInfos, info.MethodsInfos, $"{info.Type.FullName}");
            }

            tc.End();
        }

        private static void EnumerateMembers(object obj1, object obj2, Type type, FieldInfo[] fields, PropertyInfo[] properties, (MethodInfo, object[])[] methods, string name)
        {
            writer.WriteLine($"<{name}>");
            if (type.IsClass && type.BaseType != null && type.BaseType != typeof(object)) EnumerateMembers(obj1, obj2, type.BaseType, fields, properties, methods, name);
            foreach (var field in fields) Compare(field.GetValue(obj1), field.GetValue(obj2), field.FieldType, $"{name}.{field.Name}");
            foreach (var property in properties) Compare(property.GetValue(obj1), property.GetValue(obj2), property.PropertyType, $"{name}.{property.Name}");
            foreach (var (method, args) in methods) Compare(method.Invoke(obj1, args), method.Invoke(obj2, args), method.ReturnType, $"{name}.{method.Name}");
            writer.WriteLine();
        }

        private static void Compare(object obj1, object obj2, Type type, string name)
        {
            writer.WriteLine($"{name} : {obj1 ?? "null"} - {obj2 ?? "null"}");
            if (obj1 == null)
            {
                Assert.Null(obj2, $"{name}\nBasic obj: null\nDeserialized obj: Not null");
                return;
            }
            Assert.NotNull(obj2, $"{name}\nBasic obj: Not null\nDeserialized obj: null");
            if (obj1.GetType() != type) throw new AssertionException($"typeof obj1 is not {type.FullName}");
            if (obj2.GetType() != type) throw new AssertionException($"typeof obj2 is not {type.FullName}");

            switch (type)
            {
                case Type t when (t.HasInterface(typeof(IEquatable<>)) && t.GetInterface(typeof(IEquatable<>).FullName).GetGenericArguments()[0] == t) || t.IsEnum:
                    Assert.AreEqual(obj1, obj2, $"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t.HasInterface(typeof(IEnumerable)):
                    var array1 = ((IEnumerable)obj1).ToObjectArray();
                    var array2 = ((IEnumerable)obj2).ToObjectArray();
                    if (array1.Length != array2.Length) throw new AssertionException($"{name}\nCollection Count is not same\nCount1: {array1.Length}\nCount2: {array2.Length}");
                    for (int i = 0; i < array1.Length; i++) Compare(array1[i], array2[i], array1[i]?.GetType(), $"{name}[{i}]");
                    break;
                default:
                    FieldInfo[] fields;
                    PropertyInfo[] properties;
                    (MethodInfo, object[])[] methods;
                    if (ReflectionSources.Info.TryGetValue(type, out var info))
                    {
                        fields = info.FieldInfos;
                        methods = info.MethodsInfos;
                        properties = info.PropertyInfos;
                    }
                    else
                    {
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        methods = Array.Empty<(MethodInfo, object[])>();
                        properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    }
                    EnumerateMembers(obj1, obj2, type, fields, properties, methods, name);
                    break;
            }
        }

        internal static class ReflectionSources
        {
            public static Dictionary<Type, ReflectionInfo> Info { get; } = GetInfo();
            private static Dictionary<Type, ReflectionInfo> GetInfo()
            {
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var result = new Dictionary<Type, ReflectionInfo>();

                // Altseed2.AlphaBlend
                var alphaBlend = ReflectionInfo.Create(AlphaBlend.Normal);
                alphaBlend.FieldInfos = new[]
                {
                    alphaBlend.Type.GetField("IsBlendEnabled", flags),
                    alphaBlend.Type.GetField("BlendSrcFunc", flags),
                    alphaBlend.Type.GetField("BlendDstFunc", flags),
                    alphaBlend.Type.GetField("BlendSrcFuncAlpha", flags),
                    alphaBlend.Type.GetField("BlendDstFuncAlpha", flags),
                    alphaBlend.Type.GetField("BlendEquationRGB", flags),
                    alphaBlend.Type.GetField("BlendEquationAlpha", flags),
                };
                result.Add(alphaBlend.Type, alphaBlend);

                return result;
            }
        }

        public sealed class ReflectionInfo
        {
            public SerializedObjectComparer Comparer { get; set; }
            public FieldInfo[] FieldInfos { get => _fieldInfos; set => _fieldInfos = value ?? Array.Empty<FieldInfo>(); }
            private FieldInfo[] _fieldInfos = Array.Empty<FieldInfo>();
            public (MethodInfo, object[])[] MethodsInfos { get => _methodInfos; set => _methodInfos = value ?? Array.Empty<(MethodInfo, object[])>(); }
            private (MethodInfo, object[])[] _methodInfos = Array.Empty<(MethodInfo, object[])>();
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


        public delegate AssertionException SerializedObjectComparer(object obj1, object obj2);
    }
    internal static class ReflectionHelper
    {
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
        public static bool HasInterface(this Type type, Type interfaceType) => interfaceType.IsInterface && type.GetInterface(interfaceType.FullName) != null;
    }
}
