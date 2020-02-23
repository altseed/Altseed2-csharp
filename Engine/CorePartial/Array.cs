using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    public partial class Int8Array
    {
        public byte[] ToArray()
        {
            var array = new byte[Count];
            Marshal.Copy(GetData(), array, 0, Count);
            return array;
        }

        public void FromArray(byte[] array)
        {
            var ptr = Marshal.AllocCoTaskMem(sizeof(byte) * array.Length);
            Marshal.Copy(array, 0, ptr, array.Length);
            SetData(ptr, array.Length);
            Marshal.FreeCoTaskMem(ptr);
        }
    }
}
