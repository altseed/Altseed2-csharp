using System;
using System.Buffers;
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
        /// 格納されている要素数を取得します。
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定します。
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>        
        T this[int index] { get; set; }

        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">変更先のサイズ</param>
        void Resize(int size);

        /// <summary>
        /// データを指定したポインターにコピーします。
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

        public static Int8Array Create(ReadOnlySpan<byte> src)
        {
            var dst = Create(src.Length);
            dst.FromSpan(src);
            return dst;
        }

        public static Int8Array Create(IEnumerable<byte> src)
        {
            var dst = Create(0);
            dst.FromEnumerable(src);
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
            this.FromSpan(array);
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

        public static Int32Array Create(ReadOnlySpan<int> src)
        {
            var dst = Create(src.Length);
            dst.FromSpan(src);
            return dst;
        }

        public static Int32Array Create(IEnumerable<int> src)
        {
            var dst = Create(0);
            dst.FromEnumerable(src);
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
            this.FromSpan(array);
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

        public static VertexArray Create(ReadOnlySpan<Vertex> src)
        {
            var dst = Create(src.Length);
            dst.FromSpan(src);
            return dst;
        }

        public static VertexArray Create(IEnumerable<Vertex> src)
        {
            var dst = Create(0);
            dst.FromEnumerable(src);
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
            this.FromSpan(array);
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

        public static FloatArray Create(ReadOnlySpan<float> src)
        {
            var dst = Create(src.Length);
            dst.FromSpan(src);
            return dst;
        }

        public static FloatArray Create(IEnumerable<float> src)
        {
            var dst = Create(0);
            dst.FromEnumerable(src);
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
            this.FromSpan(array);
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

        public static Vector2FArray Create(ReadOnlySpan<Vector2F> src)
        {
            var dst = Create(src.Length);
            dst.FromSpan(src);
            return dst;
        }

        public static Vector2FArray Create(IEnumerable<Vector2F> src)
        {
            var dst = Create(0);
            dst.FromEnumerable(src);
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
            this.FromSpan(array);
        }
    }

    /// <summary>
    /// Coreとの接続に使用する配列の拡張メソッドの定義クラス
    /// </summary>
    internal static class ArrayExtension
    {
        /// <summary>
        /// このインスタンスと同じデータを持った<typeparamref name="TElement"/>型の配列の新しいインスタンスを生成します。
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
        /// Core接続配列に指定した配列のデータを設定します。
        /// </summary>
        /// <typeparam name="TElement">Spanに格納される要素の型</typeparam>
        /// <param name="obj">配列のもとになるCore接続用配列クラスのインスタンス</param>
        /// <param name="span">書き込み先の<see cref="Span{TElement}"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>がnull</exception>
        /// <exception cref="ArgumentException"><paramref name="span"/>の長さが<see cref="IArray{TElement}.Count"/>未満。</exception>
        internal static void CopyTo<TElement>(this IArray<TElement> obj, Span<TElement> span)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (obj.Count > span.Length) throw new ArgumentException(nameof(span), $"Spanの長さが{obj.Count}未満です。");

            if (obj.Count == 0) return;

            unsafe
            {
                fixed (TElement* ptr = span)
                {
                    obj.CopyTo(new IntPtr(ptr));
                }
            }
        }

        /// <summary>
        /// Core接続配列に指定した配列のデータを設定します。
        /// </summary>
        /// <typeparam name="TElement">配列に格納される要素の型</typeparam>
        /// <param name="obj">データを設定するCore接続配列のインデスタンス</param>
        /// <param name="span">設定するデータとなる配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="span"/>がnull</exception>
        internal static void FromSpan<TElement>(this IArray<TElement> obj, ReadOnlySpan<TElement> span)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            obj.Resize(span.Length);

            if (span.Length == 0) return;

            unsafe
            {
                fixed (TElement* ptr = span)
                {
                    obj.Assign(new IntPtr(ptr), span.Length);
                }
            }
        }

        /// <summary>
        /// Core接続配列に指定した配列のデータを設定する
        /// </summary>
        /// <typeparam name="TElement">配列に格納される要素の型</typeparam>
        /// <param name="obj">データを設定するCore接続配列のインスタンス</param>
        /// <param name="elements">設定するデータとなる<see cref="IEnumerable{TElement}"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="elements"/>がnull</exception>
        internal static void FromEnumerable<TElement>(this IArray<TElement> obj, IEnumerable<TElement> elements)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (elements == null) throw new ArgumentNullException(nameof(elements), "引数がnullです");

            obj.FromSpan(elements switch
            {
                TElement[] array => array,
                _ => elements.ToArray(),
            });
        }
    }
}