using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    internal interface IArray<T>
        where T : unmanaged
    {
        int Count { get; }

        void Resize(int size);

        void CopyTo(IntPtr ptr);

        void Assign(IntPtr ptr, int size);
    }

    internal partial class Int8Array : IArray<byte> { }
    internal partial class Int32Array : IArray<int> { }
    internal partial class VertexArray : IArray<Vertex> { }
    internal partial class FloatArray : IArray<float> { }

    internal static class ArrayExtension
    {
        internal static unsafe TElement[] ToArray<TElement>(this IArray<TElement> obj)
            where TElement : unmanaged
        {
            var array = new TElement[obj.Count];

            fixed (TElement* ptr = array)
            {
                obj.CopyTo(new IntPtr(ptr));
            }

            return array;
        }

        internal static unsafe void FromArray<TElement>(this IArray<TElement> obj, TElement[] array)
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
