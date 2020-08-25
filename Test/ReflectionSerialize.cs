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
    /// <summary>
    /// リフレクションを用いてシリアライズテストを行うクラス
    /// </summary>
    [TestFixture]
    public partial class ReflectionSerialize
    {
        /// <summary>
        /// ログ吐く用のライター
        /// </summary>
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
            // Serialization\フォルダの生成
            if (!Directory.Exists("Serialization")) Directory.CreateDirectory("Serialization");
            // ログの初期化
            writer = new StreamWriter("Serialization/SerializationLog.txt", false)
            {
                AutoFlush = true
            };

            var tc = new TestCore();
            tc.Init();

            // シリアライズ用のサンプルオブジェクトを順に取得
            foreach (var (_, info) in ReflectionSources.Info)
            {
                // シリアライズしないようにマークされていた場合スキップ
                if (!info.DoSerialization) continue;
                // バイナリファイル名
                var replacedTypeName = info.Type.FullName.Replace('.', '_').Replace('`', '_');

                var path = $"Serialization/Binaries/{replacedTypeName}.bin";

                // シリアライズ実行
                Serialize(path, info.Value);
                // シリアリライズで生成したファイルがあるかチェック
                if (!System.IO.File.Exists(path)) throw new AssertionException($"Failed to Serialze object\nType: {info.Type.FullName}");

                // デシリアライズ実行
                var deSerialized = Deserialize(path);
                // デシリアライズ結果がnullじゃないかチェック
                Assert.NotNull(deSerialized);

                // ログ吐き出し
                writer.WriteLine($"-{info.Type}-");

                // メンバー列挙
                EnumerateMembers(info.Value, deSerialized, info.Type, info.FieldInfos, info.PropertyInfos, info.MethodsInfos, $"{info.Type.FullName}");

                // 改行
                writer.WriteLine();
            }

            tc.End();
        }

        /// <summary>
        /// 指定したメンバーを列挙して比較する
        /// </summary>
        /// <param name="obj1">比較するオブジェクト1</param>
        /// <param name="obj2">比較するオブジェクト2</param>
        /// <param name="type"><paramref name="obj1"/>や<paramref name="obj2"/>における<see cref="Type"/></param>
        /// <param name="fields"><paramref name="obj1"/>と<paramref name="obj2"/>を比較する際に列挙するフィールド</param>
        /// <param name="properties"><paramref name="obj1"/>と<paramref name="obj2"/>を比較する際に列挙するプロパティ</param>
        /// <param name="methods"><paramref name="obj1"/>と<paramref name="obj2"/>を比較する際に列挙するメソッドとその引数</param>
        /// <param name="name">ログ吐き出し時に用いる要素の名前</param>
        private static void EnumerateMembers(object obj1, object obj2, Type type, FieldInfo[] fields, PropertyInfo[] properties, (MethodInfo, object[])[] methods, string name)
        {
            // Baseクラスの検証
            if (!ReflectionSources.Info.ContainsKey(type) && type.IsClass && type.BaseType != null && type.BaseType != typeof(object)) EnumerateMembers(obj1, obj2, type.BaseType, fields, properties, methods, name);

            // OptionalValueProviderに比較する要素が記述されている場合その要素を取り出して比較
            if (ReflectionSources.Info.TryGetValue(type, out var refInfo))
            {
                var values = refInfo.OptionalValueProvider?.Invoke(obj1, obj2);
                if (values != null)
                    foreach (var (valueName, valueType, comparison1, comparison2) in values)
                        Compare(comparison1, comparison2, valueType, $"{name}.{valueName}");
            }

            // フィールドを比較
            foreach (var field in fields) Compare(field.GetValue(obj1), field.GetValue(obj2), field.FieldType, $"{name}.{field.Name}");
            // プロパティを比較
            foreach (var property in properties) Compare(property.GetValue(obj1), property.GetValue(obj2), property.PropertyType, $"{name}.{property.Name}");
            // メソッドの返り値を比較
            foreach (var (method, args) in methods) Compare(method.Invoke(obj1, args), method.Invoke(obj2, args), method.ReturnType, $"{name}.{method.Name}");
        }

        /// <summary>
        /// 指定した要素の比較を行う
        /// </summary>
        /// <param name="obj1">比較する要素1</param>
        /// <param name="obj2">比較する要素2</param>
        /// <param name="type"><paramref name="obj1"/>や<paramref name="obj2"/>における<see cref="Type"/></param>
        /// <param name="name">ログ吐き出し時に用いる要素の名前</param>
        private static void Compare(object obj1, object obj2, Type type, string name)
        {
            if (obj1 == null)
            {
                // obj1がnullの時->obj2がnullであるべき
                if (obj2 != null) throw new AssertionException($"{name}\nobj1: null\nobj2: Not null");
                writer.WriteLine($"{name}<{type.FullName}> : {obj1.ToLogText()} - {obj2.ToLogText()}");
                return;
            }
            // obj1がnullでない時->obj2はnullでないべき
            if (obj2 == null) throw new AssertionException($"{name}\nobj1: Not null\nobj2: null");

            // 比較対象の要素の比較方法がReflectionSourcesに記載されている場合はその内容をもとに比較を行う
            if (ReflectionSources.Info.TryGetValue(type, out var refInfo))
            {
                EnumerateMembers(obj1, obj2, type, refInfo.FieldInfos, refInfo.PropertyInfos, refInfo.MethodsInfos, name);
                return;
            }
            //
            // [注意]
            // ValueTypeに対してobject.Equal(object, object)やobject == objectを実行すると必ずfalseになる
            //
            switch (type)
            {
                //
                // float，double，decimalなどの小数点系の場合，誤差を加味して比較
                //
                case Type t when t == typeof(float):
                    if (System.Math.Abs((float)obj1 - (float)obj2) >= MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t == typeof(double):
                    if (System.Math.Abs((double)obj1 - (double)obj2) >= MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                case Type t when t == typeof(decimal):
                    if (System.Math.Abs((decimal)obj1 - (decimal)obj2) >= (decimal)MathHelper.MatrixError) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                // Enumの場合は数値に直して比較
                case Type t when t.IsEnum:
                    if ((int)obj1 != (int)obj2) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                // TStruct?の場合は内部のTStructの値を比較
                // ※ 先程の操作でnullチェックがされているため，このswitch内ではobj1とobj2は共に非null
                case Type t when t.Name == typeof(Nullable<>).Name:
                    Compare(type.GetProperty("Value").GetValue(obj1), type.GetProperty("Value").GetValue(obj2), type.GetGenericArguments()[0], name);
                    return;
                // KeyValuePairの場合はKeyとValueでそれぞれ比較
                // ※ System.Collections.Generic.Dictionary`2 対策
                case Type t when t.Name == typeof(KeyValuePair<,>).Name:
                    Compare(type.GetProperty("Key").GetValue(obj1), type.GetProperty("Key").GetValue(obj2), type.GetGenericArguments()[0], $"{name}.Key");
                    Compare(type.GetProperty("Value").GetValue(obj1), type.GetProperty("Value").GetValue(obj2), type.GetGenericArguments()[1], $"{name}.Value");
                    return;
                // System.IEquatable`1 を実装している場合は System.IEquatable`1.Equalsを用いて比較(object.Equals(object, object)は先述の理由のため用いない)
                case Type t when (t.HasInterface(typeof(IEquatable<>)) && t.GetInterface(typeof(IEquatable<>).FullName).GetGenericArguments()[0] == t):
                    var IEquatableT = t.GetInterface(typeof(IEquatable<>).FullName);
                    if (!(bool)IEquatableT.GetMethod("Equals").Invoke(obj1, new[] { obj2 })) throw new AssertionException($"{name}\nNot Equals\nobj1: {obj1}\nobj2: {obj2}");
                    break;
                // foreach可能な場合object[]にして要素数比較→各要素を比較
                // この操作における制約は下記のToObjectArray参照
                case Type t when t.HasInterface(typeof(IEnumerable)):
                    var array1 = ((IEnumerable)obj1).ToObjectArray();
                    var array2 = ((IEnumerable)obj2).ToObjectArray();
                    if (array1.Length != array2.Length) throw new AssertionException($"{name}\nCollection Count is not same\nCount1: {array1.Length}\nCount2: {array2.Length}");
                    for (int i = 0; i < array1.Length; i++) Compare(array1[i], array2[i], array1[i]?.GetType(), $"{name}[{i}]");
                    return;
                // どの操作にも該当しない場合はフィールドとプロパティを全列挙して比較
                // 十中八九変な値(IntPtr等)を比較して死ぬのでなるべくReflectionSource内で記述すること
                default:
                    var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    var methods = Array.Empty<(MethodInfo, object[])>();
                    var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    EnumerateMembers(obj1, obj2, type, fields, properties, methods, name);
                    break;
            }
            // ログ吐き出し
            writer.WriteLine($"{name}<{type.FullName}> : {obj1.ToLogText()} - {obj2.ToLogText()}");
        }

        /// <summary>
        /// リフレクションを用いて比較する内容を持つクラス
        /// </summary>
        public sealed class ReflectionInfo
        {
            /// <summary>
            /// <see cref="Serialization"/>内で<see cref="Value"/>のシリアライズを行うかどうかを取得または設定する
            /// </summary>
            public bool DoSerialization { get; set; } = true;

            /// <summary>
            /// 比較するフィールドを取得または設定する
            /// </summary>
            public FieldInfo[] FieldInfos { get => _fieldInfos; set => _fieldInfos = value ?? Array.Empty<FieldInfo>(); }
            // 返り値がnullになるとforeach内で死ぬのでArray.Empty<T>()を必ず呼び出すこと
            private FieldInfo[] _fieldInfos = Array.Empty<FieldInfo>();

            /// <summary>
            /// 比較するメソッドとその引数を取得または設定する
            /// </summary>
            public (MethodInfo, object[])[] MethodsInfos { get => _methodInfos; set => _methodInfos = value ?? Array.Empty<(MethodInfo, object[])>(); }
            // 返り値がnullになるとforeach内で死ぬのでArray.Empty<T>()を必ず呼び出すこと
            private (MethodInfo, object[])[] _methodInfos = Array.Empty<(MethodInfo, object[])>();

            /// <summary>
            /// 追加で比較する要素がある場合はこの中で返り値として持たせる
            /// </summary>
            public OptionalValueProvider OptionalValueProvider { get; set; }

            /// <summary>
            /// 比較するプロパティを取得または設定する
            /// </summary>
            public PropertyInfo[] PropertyInfos { get => _propertyInfos; set => _propertyInfos = value ?? Array.Empty<PropertyInfo>(); }
            // 返り値がnullになるとforeach内で死ぬのでArray.Empty<T>()を必ず呼び出すこと
            private PropertyInfo[] _propertyInfos = Array.Empty<PropertyInfo>();

            /// <summary>
            /// 格納するオブジェクトの型を取得する
            /// </summary>
            public Type Type { get; private set; }

            /// <summary>
            /// <see cref="Serialization"/>内でシリアライズされるオブジェクトを取得する
            /// </summary>
            public object Value { get; private set; }

            /// <summary>
            /// 指定したオブジェクトを持つ<see cref="ReflectionInfo"/>の新しいインスタンスを生成する
            /// </summary>
            /// <typeparam name="T">格納する要素の型</typeparam>
            /// <param name="value">格納する要素</param>
            /// <returns><paramref name="value"/>を持つ<see cref="ReflectionInfo"/>の新しいインスタンス</returns>
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

        /// <summary>
        /// 追加で比較する要素を生成する関数
        /// </summary>
        /// <param name="obj1">与えられるオブジェクト1</param>
        /// <param name="obj2">与えられるオブジェクト2</param>
        /// <returns>追加で比較する要素を格納するコレクション</returns>
        public delegate IEnumerable<OptionalValueEntry> OptionalValueProvider(object obj1, object obj2);

        /// <summary>
        /// 追加で比較する要素を表す
        /// </summary>
        public struct OptionalValueEntry
        {
            /// <summary>
            /// 要素名を取得または設定する
            /// </summary>
            /// <remarks>ログで吐かれる名前なのでログを使わない場合は設定しなくてOK</remarks>
            public string Name { get; set; }
            /// <summary>
            /// 格納するオブジェクトの型を取得または設定する
            /// </summary>
            public Type Type { get; set; }
            /// <summary>
            /// 比較する値を取得または設定する
            /// </summary>
            public object Value1 { get; set; }
            /// <summary>
            /// 比較する値を取得または設定する
            /// </summary>
            public object Value2 { get; set; }
            public OptionalValueEntry(string name, Type type, object value1, object value2)
            {
                Name = name;
                Type = type;
                Value1 = value1;
                Value2 = value2;
            }
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
        /// <summary>
        /// メンバーを取り出すときに用いるフラグ
        /// </summary>
        private const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        /// <summary>
        /// 指定したインターフェイスを持つかどうかを判定する
        /// </summary>
        /// <param name="type">判定する型</param>
        /// <param name="interfaceType">実装を確認するインターフェイスの型</param>
        /// <returns><paramref name="type"/>が<paramref name="interfaceType"/>を実装していたらtrue，それ以外でfalse</returns>
        public static bool HasInterface(this Type type, Type interfaceType) => interfaceType.IsInterface && type.GetInterface(interfaceType.FullName) != null;
        /// <summary>
        /// 指定した名前の<see cref="FieldInfo"/>を取り出す
        /// </summary>
        /// <param name="info">フィールドを取り出したい<see cref="ReflectionSerialize.ReflectionInfo"/>のインスタンス</param>
        /// <param name="name">取り出すフィールドの名前</param>
        /// <returns><paramref name="info"/>における<paramref name="name"/>を名前として持つフィールド</returns>
        public static FieldInfo GetField(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetField(name, flags) ?? throw new InvalidOperationException($"フィールドの読み込みに失敗しました\nType: {info.Type.FullName}\nField: {name}");
        /// <summary>
        /// 指定した名前の<see cref="MethodInfo"/>を取り出す
        /// </summary>
        /// <param name="info">メソッドを取り出したい<see cref="ReflectionSerialize.ReflectionInfo"/>のインスタンス</param>
        /// <param name="name">取り出すメソッドの名前</param>
        /// <returns><paramref name="info"/>における<paramref name="name"/>を名前として持つメソッド</returns>
        public static MethodInfo GetMethod(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetMethod(name, flags) ?? throw new InvalidOperationException($"メソッドの読み込みに失敗しました\nType: {info.Type.FullName}\nMethod: {name}");
        /// <summary>
        /// 指定した名前の<see cref="PropertyInfo"/>を取り出す
        /// </summary>
        /// <param name="info">プロパティを取り出したい<see cref="ReflectionSerialize.ReflectionInfo"/>のインスタンス</param>
        /// <param name="name">取り出すプロパティの名前</param>
        /// <returns><paramref name="info"/>における<paramref name="name"/>を名前として持つプロパティ</returns>
        public static PropertyInfo GetProperty(this ReflectionSerialize.ReflectionInfo info, string name) => info.Type.GetProperty(name, flags) ?? throw new InvalidOperationException($"プロパティの読み込みに失敗しました\nType: {info.Type.FullName}\nProperty: {name}");
        /// <summary>
        /// ログに吐くテキストを取得する
        /// </summary>
        /// <param name="value">テキストにするオブジェクト</param>
        /// <returns><paramref name="value"/>を表すテキスト</returns>
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
        /// <summary>
        /// <see cref="IEnumerable"/>を<see cref="object"/>型の配列にする
        /// </summary>
        /// <param name="enumerable">配列にする<see cref="IEnumerable"/>のインスタンス</param>
        /// <exception cref="ArgumentException"><paramref name="enumerable"/>が配列で，その開始インデックスが0以外</exception>
        /// <exception cref="ArgumentNullException"><paramref name="enumerable"/>がnull</exception>
        /// <exception cref="RankException"><paramref name="enumerable"/>が2次元以上の配列</exception>
        /// <returns><paramref name="enumerable"/>内の要素を格納する配列</returns>
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
