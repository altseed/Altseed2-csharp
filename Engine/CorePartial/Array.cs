﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Altseed2
{
    /// <summary>
    /// Coreとの接続に使用する配列のインターフェイス
    /// </summary>
    /// <typeparam name="T">配列に格納される要素の型</typeparam>
    internal interface IArray<T>
        where T : unmanaged
    {
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>        
        T this[int index] { get; set; }

        /// <summary>
        /// サイズを変更する
        /// </summary>
        /// <param name="size">変更先のサイズ</param>
        void Resize(int size);

        /// <summary>
        /// データを指定したポインターにコピーする
        /// </summary>
        /// <param name="ptr">コピー先のポインター</param>
        void CopyTo(IntPtr ptr);

        void Assign(IntPtr ptr, int size);
    }

    internal partial class Int8Array : IArray<byte>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        /// <inheritdoc/>
        public byte this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}");
                SetAt(index, value);
            }
        }

        public static Int8Array Create(IEnumerable<byte> collection)
        {
            var src = ArrayExtension.ConvertToArray(collection);
            var dst = Create(src.Length);

            unsafe
            {
                fixed (byte* ptr = src)
                {
                    dst.Assign(new IntPtr(ptr), src.Length);
                }
            }
            return dst;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_Int8Array_Create(info.GetInt32(S_Count));
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Array, this.ToArray());
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<byte[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            this.FromArray(array);
        }
    }

    internal partial class Int32Array : IArray<int>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        /// <inheritdoc/>
        public int this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}");
                SetAt(index, value);
            }
        }

        public static Int32Array Create(IEnumerable<int> collection)
        {
            var src = ArrayExtension.ConvertToArray(collection);
            var dst = Create(src.Length);

            unsafe
            {
                fixed (int* ptr = src)
                {
                    dst.Assign(new IntPtr(ptr), src.Length);
                }
            }
            return dst;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_Int32Array_Create(info.GetInt32(S_Count));
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Array, this.ToArray());
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<int[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            this.FromArray(array);
        }
    }

    internal partial class VertexArray : IArray<Vertex>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        /// <inheritdoc/>
        public Vertex this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}");
                SetAt(index, value);
            }
        }

        public static VertexArray Create(IEnumerable<Vertex> collection)
        {
            var src = ArrayExtension.ConvertToArray(collection);
            var dst = Create(src.Length);

            unsafe
            {
                fixed (Vertex* ptr = src)
                {
                    dst.Assign(new IntPtr(ptr), src.Length);
                }
            }
            return dst;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_VertexArray_Create(info.GetInt32(S_Count));
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Array, this.ToArray());
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<Vertex[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            this.FromArray(array);
        }
    }

    internal partial class FloatArray : IArray<float>, ISerializable, ICacheKeeper<FloatArray>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        /// <inheritdoc/>
        public float this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}");
                SetAt(index, value);
            }
        }

        public static FloatArray Create(IEnumerable<float> collection)
        {
            var src = ArrayExtension.ConvertToArray(collection);
            var dst = Create(src.Length);

            unsafe
            {
                fixed (float* ptr = src)
                {
                    dst.Assign(new IntPtr(ptr), src.Length);
                }
            }
            return dst;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_FloatArray_Create(info.GetInt32(S_Count));
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Array, this.ToArray());
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<float[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            this.FromArray(array);
        }
    }

    internal partial class Vector2FArray : IArray<Vector2F>, ISerializable, ICacheKeeper<Vector2FArray>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        /// <inheritdoc/>
        public Vector2F this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException($"インデックスが無効です\n許容される値：0～{Count - 1}\n実際の値：{index}");
                SetAt(index, value);
            }
        }

        public static Vector2FArray Create(IEnumerable<Vector2F> collection)
        {
            var src = ArrayExtension.ConvertToArray(collection);
            var dst = Create(src.Length);

            unsafe
            {
                fixed (Vector2F* ptr = src)
                {
                    dst.Assign(new IntPtr(ptr), src.Length);
                }
            }
            return dst;
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_Vector2FArray_Create(info.GetInt32(S_Count));
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Array, this.ToArray());
        }

        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<Vector2F[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            this.FromArray(array);
        }
    }

    /// <summary>
    /// Coreとの接続に使用する配列の拡張メソッドの定義クラス
    /// </summary>
    internal static class ArrayExtension
    {
        /// <summary>
        /// このインスタンスと同じデータを持った<typeparamref name="TElement"/>型の配列の新しいインスタンスを生成する
        /// </summary>
        /// <typeparam name="TElement">配列に格納される要素の型</typeparam>
        /// <param name="obj">配列のもとになるCore接続用配列クラスのインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        /// <returns><paramref name="obj"/>と同じデータを持った配列</returns>
        internal static TElement[] ToArray<TElement>(this IArray<TElement> obj)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");

            var array = new TElement[obj.Count];

            unsafe
            {
                fixed (TElement* ptr = array)
                {
                    obj.CopyTo(new IntPtr(ptr));
                }
            }

            return array;
        }

        /// <summary>
        /// Core接続配列に指定した配列のデータを設定する
        /// </summary>
        /// <typeparam name="TElement">配列に格納される要素の型</typeparam>
        /// <param name="obj">データを設定するCore接続配列のインデスタンス</param>
        /// <param name="array">設定するデータとなる配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="array"/>がnull</exception>
        internal static void FromArray<TElement>(this IArray<TElement> obj, TElement[] array)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (array == null) throw new ArgumentNullException(nameof(array), "引数がnullです");

            if (obj.Count < array.Length) obj.Resize(array.Length);

            unsafe
            {
                fixed (TElement* ptr = array)
                {
                    obj.Assign(new IntPtr(ptr), array.Length);
                }
            }
        }

        /// <summary>
        /// コレクションを配列に変換する（もしかして単にLINQのToArrayするだけでよかったりする？）
        /// </summary>
        /// <typeparam name="TElement">変換する配列の要素の型</typeparam>
        /// <param name="collection">変換するコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <returns><paramref name="collection"/>と同じ要素を持つ配列</returns>
        internal static TElement[] ConvertToArray<TElement>(IEnumerable<TElement> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection), "引数がnullです");

            switch (collection)
            {
                case TElement[] a:
                    return a;

                case IReadOnlyCollection<TElement> c:
                    var array = new TElement[c.Count];
                    var i = 0;
                    foreach (var current in c) array[i++] = current;
                    return array;

                default:
                    return collection.ToArray();
            }
        }

        /// <summary>
        /// Core接続配列に指定した配列のデータを設定する
        /// </summary>
        /// <typeparam name="TElement">配列に格納される要素の型</typeparam>
        /// <param name="obj">データを設定するCore接続配列のインデスタンス</param>
        /// <param name="collection">設定するデータとなる配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="collection"/>がnull</exception>
        internal static void FromEnumerable<TElement>(this IArray<TElement> obj, IEnumerable<TElement> collection)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (collection == null) throw new ArgumentNullException(nameof(collection), "引数がnullです");

            var array = ConvertToArray(collection);

            if (obj.Count < array.Length) obj.Resize(array.Length);

            unsafe
            {
                fixed (TElement* ptr = array)
                {
                    obj.Assign(new IntPtr(ptr), array.Length);
                }
            }
        }
    }
}