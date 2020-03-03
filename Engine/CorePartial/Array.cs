using System;

namespace Altseed
{
    /// <summary>
    /// Coreとの接続に使用する配列のインターフェイス
    /// </summary>
    /// <typeparam name="T">配列に格納される要素の型</typeparam>
    public interface IArray<T>
        where T : unmanaged
    {
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        int Count { get; }

        T this[int index] { get;set; }

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

    public partial class Int8Array : IArray<byte>
    {
        public byte this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException(); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException();
                SetAt(index, value);
            }
        }
    }

    public partial class Int32Array : IArray<int>
    {
        public int this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException(); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException();
                SetAt(index, value);
            }
        }
    }

    public partial class VertexArray : IArray<Vertex>
    {
        public Vertex this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException(); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException();
                SetAt(index, ref value);
            }
        }
    }

    public partial class FloatArray : IArray<float>
    {
        public float this[int index]
        {
            get { return (0 <= index && index < Count) ? GetAt(index) : throw new IndexOutOfRangeException(); }
            set
            {
                if (index < 0 || Count <= index) throw new IndexOutOfRangeException();
                SetAt(index, value);
            }
        }
    }

    public static class ArrayExtension
    {
        public static TElement[] ToArray<TElement>(this IArray<TElement> obj)
            where TElement : unmanaged
        {
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

        public static void FromArray<TElement>(this IArray<TElement> obj, TElement[] array)
            where TElement : unmanaged
        {
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
