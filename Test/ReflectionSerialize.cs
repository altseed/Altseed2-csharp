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
    public partial class ReflectionSerialize
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
                case Type t when t.Name == typeof(Nullable<>).Name:
                    Compare(type.GetProperty("Value").GetValue(obj1), type.GetProperty("Value").GetValue(obj2), type.GetGenericArguments()[0], name);
                    return;
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
        public static FieldInfo GetField(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetField(name, flags) ?? throw new InvalidOperationException($"フィールドの読み込みに失敗しました\nType: {info.Type.FullName}\nField: {name}");
        public static MethodInfo GetMethod(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetMethod(name, flags) ?? throw new InvalidOperationException($"メソッドの読み込みに失敗しました\nType: {info.Type.FullName}\nField: {name}");
        public static PropertyInfo GetProperty(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetProperty(name, flags) ?? throw new InvalidOperationException($"プロパティの読み込みに失敗しました\nType: {info.Type.FullName}\nField: {name}");
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
