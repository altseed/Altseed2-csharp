using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Altseed
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
        internal void Resize(int size);

        /// <summary>
        /// データを指定したポインターにコピーする
        /// </summary>
        /// <param name="ptr">コピー先のポインター</param>
        internal void CopyTo(IntPtr ptr);

        internal void Assign(IntPtr ptr, int size);
    }

    [Serializable]
    internal sealed partial class Int8Array : IArray<byte>, ISerializable, ICacheKeeper<Int8Array>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        private Int8Array(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<byte[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            var ptr = cbg_Int8Array_Create(array.Length);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            this.FromArray(array);
        }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>
        public byte this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException("インデックスが無効です"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException("インデックスが無効です");
                SetAt(index, value);
            }
        }

        #region IArray
        void IArray<byte>.Assign(IntPtr ptr, int size) => Assign(ptr, size);

        void IArray<byte>.CopyTo(IntPtr ptr) => CopyTo(ptr);

        void IArray<byte>.Resize(int size) => Resize(size);
        #endregion

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Int8Array>> ICacheKeeper<Int8Array>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<Int8Array>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<Int8Array>.Release(IntPtr native) => cbg_Int8Array_Release(native);
        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Array, this.ToArray());
        }
    }

    [Serializable]
    internal sealed partial class Int32Array : IArray<int>, ISerializable, ICacheKeeper<Int32Array>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        private Int32Array(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<int[]>(S_Array) ??  throw new SerializationException("デシリアライズに失敗しました");
            var ptr = cbg_Int32Array_Create(array.Length);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            this.FromArray(array);
        }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>
        public int this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException("インデックスが無効です"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException("インデックスが無効です");
                SetAt(index, value);
            }
        }

        #region IArray
        void IArray<int>.Assign(IntPtr ptr, int size) => Assign(ptr, size);

        void IArray<int>.CopyTo(IntPtr ptr) => CopyTo(ptr);

        void IArray<int>.Resize(int size) => Resize(size);
        #endregion

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Int32Array>> ICacheKeeper<Int32Array>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<Int32Array>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<Int32Array>.Release(IntPtr native) => cbg_Int32Array_Release(native);
        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Array, this.ToArray());
        }
    }

    [Serializable]
    internal sealed partial class VertexArray : IArray<Vertex>, ISerializable, ICacheKeeper<VertexArray>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        private VertexArray(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<Vertex[]>(S_Array) ??  throw new SerializationException("デシリアライズに失敗しました");
            var ptr = cbg_VertexArray_Create(array.Length);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            this.FromArray(array);
        }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>
        public Vertex this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException("インデックスが無効です"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException("インデックスが無効です");
                SetAt(index, value);
            }
        }

        #region IArray
        void IArray<Vertex>.Assign(IntPtr ptr, int size) => Assign(ptr, size);

        void IArray<Vertex>.CopyTo(IntPtr ptr) => CopyTo(ptr);

        void IArray<Vertex>.Resize(int size) => Resize(size);
        #endregion

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<VertexArray>> ICacheKeeper<VertexArray>.CacheRepo => cacheRepo;

        internal IntPtr Self { get => selfPtr; set => selfPtr = value; }
        IntPtr ICacheKeeper<VertexArray>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<VertexArray>.Release(IntPtr native) => cbg_VertexArray_Release(native);
        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Array, this.ToArray());
        }
    }

    [Serializable]
    internal sealed partial class FloatArray : IArray<float>, ISerializable, ICacheKeeper<FloatArray>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        private FloatArray(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<float[]>(S_Array) ??  throw new SerializationException("デシリアライズに失敗しました");
            var ptr = cbg_FloatArray_Create(array.Length);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            this.FromArray(array);
        }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>
        public float this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException("インデックスが無効です"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException("インデックスが無効です");
                SetAt(index, value);
            }
        }

        #region IArray
        void IArray<float>.Assign(IntPtr ptr, int size) => Assign(ptr, size);

        void IArray<float>.CopyTo(IntPtr ptr) => CopyTo(ptr);

        void IArray<float>.Resize(int size) => Resize(size);
        #endregion

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<FloatArray>> ICacheKeeper<FloatArray>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<FloatArray>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<FloatArray>.Release(IntPtr native) => cbg_FloatArray_Release(native);
        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Array, this.ToArray());
        }
    }

    [Serializable]
    internal sealed partial class Vector2FArray : IArray<Vector2F>, ISerializable, ICacheKeeper<Vector2FArray>
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion

        private Vector2FArray(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<Vector2F[]>(S_Array) ??  throw new SerializationException("デシリアライズに失敗しました");
            var ptr = cbg_Vector2FArray_Create(array.Length);
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            this.FromArray(array);
        }

        /// <summary>
        /// 指定したインデックスの要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <returns><paramref name="index"/>に該当する要素</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/>の値が0未満または<see cref="Count"/>以上</exception>
        public Vector2F this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException("インデックスが無効です"); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException("インデックスが無効です");
                SetAt(index, value);
            }
        }

        #region IArray
        void IArray<Vector2F>.Assign(IntPtr ptr, int size) => Assign(ptr, size);

        void IArray<Vector2F>.CopyTo(IntPtr ptr) => CopyTo(ptr);

        void IArray<Vector2F>.Resize(int size) => Resize(size);
        #endregion

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Vector2FArray>> ICacheKeeper<Vector2FArray>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<Vector2FArray>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<Vector2FArray>.Release(IntPtr native) => cbg_Vector2FArray_Release(native);
        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Array, this.ToArray());
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
        public static TElement[] ToArray<TElement>(this IArray<TElement> obj)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException("引数がnullです", nameof(obj));

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
        public static void FromArray<TElement>(this IArray<TElement> obj, TElement[] array)
            where TElement : unmanaged
        {
            if (obj == null) throw new ArgumentNullException("引数がnullです", nameof(obj));
            if (array == null) throw new ArgumentNullException("引数がnullです", nameof(array));

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
