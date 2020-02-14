using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Altseed
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;
    }
}
