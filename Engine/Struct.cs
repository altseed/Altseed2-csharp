using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace asd
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;
    }
}
