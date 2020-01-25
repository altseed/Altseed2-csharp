using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DI
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DF
    {
        public float X;
        public float Y;
    }
}
