using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Altseed
{
    struct MemoryHandle
    {
        public IntPtr selfPtr;
        public MemoryHandle(IntPtr p)
        {
            this.selfPtr = p;
        }
    }
    
    public enum ResourceType : int
    {
        StaticFile,
        StreamFile,
        Texture2D,
        Font,
        MAX,
    }
    
    public enum Keys : int
    {
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
    
    /// <summary>
    /// ボタンの押下状態を表します。
    /// </summary>
    public enum ButtonState : int
    {
        Free = 0,
        Push = 1,
        Hold = 3,
        Release = 2,
    }
    
    public enum MouseButtons : int
    {
        ButtonLeft = 0,
        ButtonRight = 1,
        ButtonMiddle = 2,
        SubButton1 = 3,
        SubButton2 = 4,
        SubButton3 = 5,
        SubButton4 = 6,
        SubButton5 = 7,
    }
    
    public enum CursorMode : int
    {
        Normal = 212993,
        Hidden = 212994,
        Disable = 212995,
    }
    
    public enum JoystickType : int
    {
        Other = 0,
        PS4 = 8200,
        XBOX360 = 8199,
        JoyconL = 8198,
        JoyconR = 8197,
    }
    
    public enum JoystickButtonType : int
    {
        Start,
        Select,
        Home,
        Release,
        Capture,
        LeftUp,
        LeftDown,
        LeftLeft,
        LeftRight,
        LeftPush,
        RightUp,
        RightRight,
        RightLeft,
        RightDown,
        RightPush,
        L1,
        R1,
        L2,
        R2,
        L3,
        R3,
        LeftStart,
        RightStart,
        Max,
    }
    
    public enum JoystickAxisType : int
    {
        Start,
        LeftH,
        LeftV,
        RightH,
        RightV,
        L2,
        R2,
        Max,
    }
    
    public enum DeviceType : int
    {
    }
    
    public enum EasingType : int
    {
        Linear,
        InSine,
        OutSine,
        InOutSine,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InBack,
        OutBack,
        InOutBack,
        InElastic,
        OutElastic,
        InOutElastic,
        InBounce,
        OutBounce,
        InOutBounce,
    }
    
    public partial class Core
    {
        private static Dictionary<IntPtr, WeakReference<Core>> cacheRepo = new Dictionary<IntPtr, WeakReference<Core>>();
        
        internal static Core TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Core cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Core_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Core(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Core>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_Initialize([MarshalAs(UnmanagedType.LPWStr)] string title, int width, int height, ref CoreOption option);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_DoEvent(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_Terminate();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Core_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_Release(IntPtr selfPtr);
        
        
        internal Core(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public static bool Initialize(string title, int width, int height, ref CoreOption option)
        {
            var ret = cbg_Core_Initialize(title, width, height, ref option);
            return ret;
        }
        
        public bool DoEvent()
        {
            var ret = cbg_Core_DoEvent(selfPtr);
            return ret;
        }
        
        public static void Terminate()
        {
            cbg_Core_Terminate();
        }
        
        public static Core GetInstance()
        {
            var ret = cbg_Core_GetInstance();
            return Core.TryGetFromCache(ret);
        }
        
        ~Core()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Core_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Int8Array
    {
        private static Dictionary<IntPtr, WeakReference<Int8Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int8Array>>();
        
        internal static Int8Array TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Int8Array cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Int8Array_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Int8Array(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Int8Array>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_CopyTo(IntPtr selfPtr, IntPtr array, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_Release(IntPtr selfPtr);
        
        
        internal Int8Array(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public void CopyTo(Int8Array array, int size)
        {
            cbg_Int8Array_CopyTo(selfPtr, array != null ? array.selfPtr : IntPtr.Zero, size);
        }
        
        ~Int8Array()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Int8Array_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Resources
    {
        private static Dictionary<IntPtr, WeakReference<Resources>> cacheRepo = new Dictionary<IntPtr, WeakReference<Resources>>();
        
        internal static Resources TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Resources cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Resources_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Resources(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Resources>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Resources_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Resources_GetResourcesCount(IntPtr selfPtr, int type);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Resources_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Resources_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Resources_Release(IntPtr selfPtr);
        
        
        internal Resources(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public static Resources GetInstance()
        {
            var ret = cbg_Resources_GetInstance();
            return Resources.TryGetFromCache(ret);
        }
        
        public int GetResourcesCount(ResourceType type)
        {
            var ret = cbg_Resources_GetResourcesCount(selfPtr, (int)type);
            return ret;
        }
        
        public void Clear()
        {
            cbg_Resources_Clear(selfPtr);
        }
        
        public void Reload()
        {
            cbg_Resources_Reload(selfPtr);
        }
        
        ~Resources()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Resources_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// キーボードを表します。
    /// </summary>
    public partial class Keyboard
    {
        private static Dictionary<IntPtr, WeakReference<Keyboard>> cacheRepo = new Dictionary<IntPtr, WeakReference<Keyboard>>();
        
        internal static Keyboard TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Keyboard cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Keyboard_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Keyboard(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Keyboard>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Keyboard_GetKeyState(IntPtr selfPtr, int key);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Keyboard_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Keyboard_Release(IntPtr selfPtr);
        
        
        internal Keyboard(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// キーの状態を取得します。
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>ボタンの押下状態</returns>
        public ButtonState GetKeyState(Keys key)
        {
            var ret = cbg_Keyboard_GetKeyState(selfPtr, (int)key);
            return (ButtonState)ret;
        }
        
        internal static Keyboard GetInstance()
        {
            var ret = cbg_Keyboard_GetInstance();
            return Keyboard.TryGetFromCache(ret);
        }
        
        ~Keyboard()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Keyboard_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// マウスを表します。
    /// </summary>
    public partial class Mouse
    {
        private static Dictionary<IntPtr, WeakReference<Mouse>> cacheRepo = new Dictionary<IntPtr, WeakReference<Mouse>>();
        
        internal static Mouse TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Mouse cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Mouse_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Mouse(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Mouse>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Mouse_GetInstance(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_RefreshInputState(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetPosition(IntPtr selfPtr, ref Vector2DF vec);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2DF cbg_Mouse_GetPosition(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Mouse_GetWheel(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_GetMouseButtonState(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Mouse_GetCursorMode(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetCursorMode(IntPtr selfPtr, int value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_Release(IntPtr selfPtr);
        
        
        internal Mouse(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public CursorMode CursorMode
        {
            get
            {
                if (_CursorMode != null)
                {
                    return _CursorMode.Value;
                }
                var ret = cbg_Mouse_GetCursorMode(selfPtr);
                return (CursorMode)ret;
            }
            set
            {
                _CursorMode = value;
                cbg_Mouse_SetCursorMode(selfPtr, (int)value);
            }
        }
        private CursorMode? _CursorMode;
        
        internal Mouse GetInstance()
        {
            var ret = cbg_Mouse_GetInstance(selfPtr);
            return Mouse.TryGetFromCache(ret);
        }
        
        internal void RefreshInputState()
        {
            cbg_Mouse_RefreshInputState(selfPtr);
        }
        
        /// <summary>
        /// マウスカーソルの座標を設定します。
        /// </summary>
        public void SetPosition(ref Vector2DF vec)
        {
            cbg_Mouse_SetPosition(selfPtr, ref vec);
        }
        
        /// <summary>
        /// マウスカーソルの座標を取得します。
        /// </summary>
        public Vector2DF GetPosition()
        {
            var ret = cbg_Mouse_GetPosition(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// マウスホイールの回転量を取得します。
        /// </summary>
        public float GetWheel()
        {
            var ret = cbg_Mouse_GetWheel(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// マウスボタンの状態を取得します。
        /// </summary>
        public void GetMouseButtonState(MouseButtons button)
        {
            cbg_Mouse_GetMouseButtonState(selfPtr, (int)button);
        }
        
        ~Mouse()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Mouse_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Joystick
    {
        private static Dictionary<IntPtr, WeakReference<Joystick>> cacheRepo = new Dictionary<IntPtr, WeakReference<Joystick>>();
        
        internal static Joystick TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Joystick cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Joystick_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Joystick(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Joystick>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_IsPresent(IntPtr selfPtr, int joystickIndex);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_RefreshInputState(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_RefreshConnectedState(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Joystick_GetButtonStateByIndex(IntPtr selfPtr, int joystickIndex, int buttonIndex);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Joystick_GetButtonStateByType(IntPtr selfPtr, int joystickIndex, int type);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Joystick_GetJoystickType(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Joystick_GetAxisStateByIndex(IntPtr selfPtr, int joystickIndex, int axisIndex);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Joystick_GetAxisStateByType(IntPtr selfPtr, int joystickIndex, int type);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Joystick_GetJoystickName(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_RefreshVibrateState(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_SetVibration(IntPtr selfPtr, int index, float high_freq, float low_freq, float high_amp, float low_amp, int life_time);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Joystick_Release(IntPtr selfPtr);
        
        
        internal Joystick(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public void IsPresent(int joystickIndex)
        {
            cbg_Joystick_IsPresent(selfPtr, joystickIndex);
        }
        
        public void RefreshInputState()
        {
            cbg_Joystick_RefreshInputState(selfPtr);
        }
        
        public void RefreshConnectedState()
        {
            cbg_Joystick_RefreshConnectedState(selfPtr);
        }
        
        public ButtonState GetButtonStateByIndex(int joystickIndex, int buttonIndex)
        {
            var ret = cbg_Joystick_GetButtonStateByIndex(selfPtr, joystickIndex, buttonIndex);
            return (ButtonState)ret;
        }
        
        public ButtonState GetButtonStateByType(int joystickIndex, JoystickButtonType type)
        {
            var ret = cbg_Joystick_GetButtonStateByType(selfPtr, joystickIndex, (int)type);
            return (ButtonState)ret;
        }
        
        public JoystickType GetJoystickType(int index)
        {
            var ret = cbg_Joystick_GetJoystickType(selfPtr, index);
            return (JoystickType)ret;
        }
        
        public float GetAxisStateByIndex(int joystickIndex, int axisIndex)
        {
            var ret = cbg_Joystick_GetAxisStateByIndex(selfPtr, joystickIndex, axisIndex);
            return ret;
        }
        
        public float GetAxisStateByType(int joystickIndex, JoystickAxisType type)
        {
            var ret = cbg_Joystick_GetAxisStateByType(selfPtr, joystickIndex, (int)type);
            return ret;
        }
        
        public string GetJoystickName(int index)
        {
            var ret = cbg_Joystick_GetJoystickName(selfPtr, index);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        public void RefreshVibrateState()
        {
            cbg_Joystick_RefreshVibrateState(selfPtr);
        }
        
        public void SetVibration(int index, float high_freq, float low_freq, float high_amp, float low_amp, int life_time)
        {
            cbg_Joystick_SetVibration(selfPtr, index, high_freq, low_freq, high_amp, low_amp, life_time);
        }
        
        ~Joystick()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Joystick_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Graphics
    {
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();
        
        internal static Graphics TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Graphics cacheRet;
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Graphics_GetInstance();
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_BeginFrame(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_EndFrame(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);
        
        
        internal Graphics(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public static Graphics GetInstance()
        {
            var ret = cbg_Graphics_GetInstance();
            return Graphics.TryGetFromCache(ret);
        }
        
        public bool BeginFrame()
        {
            var ret = cbg_Graphics_BeginFrame(selfPtr);
            return ret;
        }
        
        public bool EndFrame()
        {
            var ret = cbg_Graphics_EndFrame(selfPtr);
            return ret;
        }
        
        ~Graphics()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Graphics_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Texture2D
    {
        private static Dictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new Dictionary<IntPtr, WeakReference<Texture2D>>();
        
        internal static Texture2D TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Texture2D cacheRet;
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
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Texture2D_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2DI cbg_Texture2D_GetSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Texture2D_Release(IntPtr selfPtr);
        
        
        internal Texture2D(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public bool Reload()
        {
            var ret = cbg_Texture2D_Reload(selfPtr);
            return ret;
        }
        
        public Vector2DI GetSize()
        {
            var ret = cbg_Texture2D_GetSize(selfPtr);
            return ret;
        }
        
        ~Texture2D()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Texture2D_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class StreamFile
    {
        private static Dictionary<IntPtr, WeakReference<StreamFile>> cacheRepo = new Dictionary<IntPtr, WeakReference<StreamFile>>();
        
        internal static StreamFile TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                StreamFile cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_StreamFile_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new StreamFile(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<StreamFile>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetCurrentPosition(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_Read(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StreamFile_GetTempBuffer(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetTempBufferSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_GetIsInPackage(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_StreamFile_Release(IntPtr selfPtr);
        
        
        internal StreamFile(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public int GetSize()
        {
            var ret = cbg_StreamFile_GetSize(selfPtr);
            return ret;
        }
        
        public int GetCurrentPosition()
        {
            var ret = cbg_StreamFile_GetCurrentPosition(selfPtr);
            return ret;
        }
        
        public int Read(int size)
        {
            var ret = cbg_StreamFile_Read(selfPtr, size);
            return ret;
        }
        
        public Int8Array GetTempBuffer()
        {
            var ret = cbg_StreamFile_GetTempBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        public int GetTempBufferSize()
        {
            var ret = cbg_StreamFile_GetTempBufferSize(selfPtr);
            return ret;
        }
        
        public bool GetIsInPackage()
        {
            var ret = cbg_StreamFile_GetIsInPackage(selfPtr);
            return ret;
        }
        
        public bool Reload()
        {
            var ret = cbg_StreamFile_Reload(selfPtr);
            return ret;
        }
        
        ~StreamFile()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_StreamFile_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class StaticFile
    {
        private static Dictionary<IntPtr, WeakReference<StaticFile>> cacheRepo = new Dictionary<IntPtr, WeakReference<StaticFile>>();
        
        internal static StaticFile TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                StaticFile cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_StaticFile_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new StaticFile(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<StaticFile>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StaticFile_GetBuffer(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StaticFile_GetPath(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StaticFile_GetSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_GetIsInPackage(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_StaticFile_Release(IntPtr selfPtr);
        
        
        internal StaticFile(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public Int8Array GetBuffer()
        {
            var ret = cbg_StaticFile_GetBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        public string GetPath()
        {
            var ret = cbg_StaticFile_GetPath(selfPtr);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        public int GetSize()
        {
            var ret = cbg_StaticFile_GetSize(selfPtr);
            return ret;
        }
        
        public bool GetIsInPackage()
        {
            var ret = cbg_StaticFile_GetIsInPackage(selfPtr);
            return ret;
        }
        
        public bool Reload()
        {
            var ret = cbg_StaticFile_Reload(selfPtr);
            return ret;
        }
        
        ~StaticFile()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_StaticFile_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class File
    {
        private static Dictionary<IntPtr, WeakReference<File>> cacheRepo = new Dictionary<IntPtr, WeakReference<File>>();
        
        internal static File TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                File cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_File_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new File(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<File>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_File_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_File_CreateStaticFile(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_File_CreateStreamFile(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootDirectory(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootPackageWithPassword(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.LPWStr)] string password);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootPackage(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_File_ClearRootDirectories(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_Exists(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_Pack(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string srcPath, [MarshalAs(UnmanagedType.LPWStr)] string dstPath);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_PackWithPassword(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string srcPath, [MarshalAs(UnmanagedType.LPWStr)] string dstPath, [MarshalAs(UnmanagedType.LPWStr)] string password);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_File_Release(IntPtr selfPtr);
        
        
        internal File(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public static File GetInstance()
        {
            var ret = cbg_File_GetInstance();
            return File.TryGetFromCache(ret);
        }
        
        public StaticFile CreateStaticFile(string path)
        {
            var ret = cbg_File_CreateStaticFile(selfPtr, path);
            return StaticFile.TryGetFromCache(ret);
        }
        
        public StreamFile CreateStreamFile(string path)
        {
            var ret = cbg_File_CreateStreamFile(selfPtr, path);
            return StreamFile.TryGetFromCache(ret);
        }
        
        public bool AddRootDirectory(string path)
        {
            var ret = cbg_File_AddRootDirectory(selfPtr, path);
            return ret;
        }
        
        public bool AddRootPackageWithPassword(string path, string password)
        {
            var ret = cbg_File_AddRootPackageWithPassword(selfPtr, path, password);
            return ret;
        }
        
        public bool AddRootPackage(string path)
        {
            var ret = cbg_File_AddRootPackage(selfPtr, path);
            return ret;
        }
        
        public void ClearRootDirectories()
        {
            cbg_File_ClearRootDirectories(selfPtr);
        }
        
        public bool Exists(string path)
        {
            var ret = cbg_File_Exists(selfPtr, path);
            return ret;
        }
        
        public bool Pack(string srcPath, string dstPath)
        {
            var ret = cbg_File_Pack(selfPtr, srcPath, dstPath);
            return ret;
        }
        
        public bool PackWithPassword(string srcPath, string dstPath, string password)
        {
            var ret = cbg_File_PackWithPassword(selfPtr, srcPath, dstPath, password);
            return ret;
        }
        
        ~File()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_File_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Easing
    {
        private static Dictionary<IntPtr, WeakReference<Easing>> cacheRepo = new Dictionary<IntPtr, WeakReference<Easing>>();
        
        internal static Easing TryGetFromCache(IntPtr native)
        {
            if(native == null) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Easing cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Easing_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Easing(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Easing>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Easing_GetEasing(int easing, float t);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Easing_Release(IntPtr selfPtr);
        
        
        internal Easing(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        public static void GetEasing(EasingType easing, float t)
        {
            cbg_Easing_GetEasing((int)easing, t);
        }
        
        ~Easing()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Easing_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
}
