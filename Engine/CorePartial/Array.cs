using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    public interface IArray<T>
        where T : unmanaged
    {
        int Count { get; }

        void Resize(int size);

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
        public static unsafe TElement[] ToArray<TElement>(this IArray<TElement> obj)
            where TElement : unmanaged
        {
            var array = new TElement[obj.Count];

            fixed (TElement* ptr = array)
            {
                obj.CopyTo(new IntPtr(ptr));
            }

            return array;
        }

        public static unsafe void FromArray<TElement>(this IArray<TElement> obj, TElement[] array)
            where TElement : unmanaged
        {
            if (obj.Count < array.Length) obj.Resize(array.Length);

            fixed (TElement* ptr = array)
            {
                obj.Assign(new IntPtr(ptr), array.Length);
            }
        }
    }
}
