using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using asd;

namespace Altseed
{
    public static class Engine
    {
        public static bool Initialize(string title, int width, int height, CoreOption option)
        {
            var o = option.toAsd();
            if (Core.Initialize(title, width, height, ref o))
            {
                Keyboard = Keyboard.GetInstance();
                return true;
            }
            return false;
        }

        public static bool DoEvents()
        {
            return Core.GetInstance().DoEvent();
        }

        public static void Terminate()
        {
            Core.Terminate();
        }

        public static Keyboard Keyboard { get; private set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;

        internal asd.CoreOption toAsd()
        {
            return new asd.CoreOption()
            {
                IsFullscreenMode = this.IsFullscreenMode,
                IsResizable = this.IsResizable,
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DI
    {
        public int X;
        public int Y;

        internal asd.Vector2DI toAsd()
        {
            return new asd.Vector2DI()
            {
                X = this.X,
                Y = this.Y,
            };
        }
    }
}
