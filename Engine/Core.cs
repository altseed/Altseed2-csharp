using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace asd {
    struct MemoryHandle {
        public IntPtr selfPtr;
        public MemoryHandle(IntPtr p) {
            this.selfPtr = p;
        }
    }
    
    public enum Keys : int {
        Unknown,
        Space,
        Apostrophe,
        Comma,
        Minus,
        Period,
        Slash,
        Num0,
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Num9,
        Semicolon,
        Equal,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        LeftBracket,
        Backslash,
        RightBracket,
        GraveAccent,
        World1,
        World2,
        Escape,
        Enter,
        Tab,
        Backspace,
        Insert,
        Delete,
        Right,
        Left,
        Down,
        Up,
        PageUp,
        PageDown,
        Home,
        End,
        CapsLock,
        ScrollLock,
        NumLock,
        PrintScreen,
        Pause,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        F13,
        F14,
        F15,
        F16,
        F17,
        F18,
        F19,
        F20,
        F21,
        F22,
        F23,
        F24,
        F25,
        Keypad0,
        Keypad1,
        Keypad2,
        Keypad3,
        Keypad4,
        Keypad5,
        Keypad6,
        Keypad7,
        Keypad8,
        Keypad9,
        KeypadDecimal,
        KeypadDivide,
        KeypadMultiply,
        KeypadSubstract,
        KeypadAdd,
        KeypadEnter,
        KeypadEqual,
        LeftShift,
        LeftControl,
        LeftAlt,
        LeftWin,
        RightShift,
        RightControl,
        RightAlt,
        RightWin,
        Menu,
        Last,
        MAX,
    }
    
    public enum DeviceType : int {
    }
    
    public class Graphics {
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();
        
        public static Graphics TryGetFromCache(IntPtr native)
        {
            if(cacheRepo.ContainsKey(native))
            {
                Subject cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Graphics_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Graphics(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Graphics>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core.dll")]
        private static extern void cbg_Graphics_GetInstance();
        
        [DllImport("Altseed_Core.dll")]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);
        
        
        internal Graphics(MemoryHandle handle) {
            this.selfPtr = handle.selfPtr;
        }
        
        public void GetInstance() {
            cbg_Graphics_GetInstance();
        }
        
        ~Graphics() {
            lock (this)  {
                if (selfPtr != IntPtr.Zero) {
                    cbg_Graphics_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public class Texture2D {
        private static Dictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new Dictionary<IntPtr, WeakReference<Texture2D>>();
        
        public static Texture2D TryGetFromCache(IntPtr native)
        {
            if(cacheRepo.ContainsKey(native))
            {
                Subject cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Texture2D_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Texture2D(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Texture2D>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core.dll")]
        private static extern void cbg_Texture2D_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core.dll")]
        private static extern void cbg_Texture2D_GetSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core.dll")]
        private static extern void cbg_Texture2D_Release(IntPtr selfPtr);
        
        
        internal Texture2D(MemoryHandle handle) {
            this.selfPtr = handle.selfPtr;
        }
        
        public void Reload() {
            cbg_Texture2D_Reload(selfPtr);
        }
        
        public void GetSize() {
            cbg_Texture2D_GetSize(selfPtr);
        }
        
        ~Texture2D() {
            lock (this)  {
                if (selfPtr != IntPtr.Zero) {
                    cbg_Texture2D_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
}
