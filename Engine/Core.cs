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
    
    /// <summary>
    /// イージングの種類を表す
    /// </summary>
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
    
    /// <summary>
    /// リソースの種類を表す
    /// </summary>
    public enum ResourceType : int
    {
        StaticFile,
        StreamFile,
        Texture2D,
        Font,
        MAX,
    }
    
    /// <summary>
    /// キーボードのキーの種類を表す
    /// </summary>
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
    
    /// <summary>
    /// マウスのボタンの種類を表す
    /// </summary>
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
    
    /// <summary>
    /// カーソルの状態を表す
    /// </summary>
    public enum CursorMode : int
    {
        Normal = 212993,
        Hidden = 212994,
        Disable = 212995,
    }
    
    /// <summary>
    /// ジョイスティックの種類を表す
    /// </summary>
    public enum JoystickType : int
    {
        Other = 0,
        PS4 = 8200,
        XBOX360 = 8199,
        JoyconL = 8198,
        JoyconR = 8197,
    }
    
    /// <summary>
    /// ジョイスティックのボタンの種類を表す
    /// </summary>
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
    
    /// <summary>
    /// ジョイスティックの軸の種類を表す
    /// </summary>
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
    
    /// <summary>
    /// イージングのクラス
    /// </summary>
    public partial class Easing
    {
        private static Dictionary<IntPtr, WeakReference<Easing>> cacheRepo = new Dictionary<IntPtr, WeakReference<Easing>>();
        
        internal static Easing TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="easing"></param>
        /// <param name="t"></param>
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
    
    /// <summary>
    /// C++のCoreとの仲介を担うクラス
    /// </summary>
    public partial class Core
    {
        private static Dictionary<IntPtr, WeakReference<Core>> cacheRepo = new Dictionary<IntPtr, WeakReference<Core>>();
        
        internal static Core TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// 初期化処理を行う
        /// </summary>
        /// <param name="title">ウィンドウの左上に表示されるウィンドウん名</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="option">使用するコアのオプション</param>
        /// <returns>初期化処理がうまくいったらtrue，それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, ref CoreOption option)
        {
            var ret = cbg_Core_Initialize(title, width, height, ref option);
            return ret;
        }
        
        /// <summary>
        /// イベントを実行する
        /// </summary>
        /// <returns>イベントが進行出来たらtrue，それ以外でfalse</returns>
        public bool DoEvent()
        {
            var ret = cbg_Core_DoEvent(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 終了処理を行う
        /// </summary>
        public static void Terminate()
        {
            cbg_Core_Terminate();
        }
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Core GetInstance()
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
    
    /// <summary>
    /// 8ビット整数の配列のクラス
    /// </summary>
    public partial class Int8Array
    {
        private static Dictionary<IntPtr, WeakReference<Int8Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int8Array>>();
        
        internal static Int8Array TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// 指定したインスタンスにデータをコピーする
        /// </summary>
        /// <param name="array">コピー先のインスタンス</param>
        /// <param name="size">コピーするデータ量</param>
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
    
    /// <summary>
    /// 32ビット整数の配列のクラス
    /// </summary>
    public partial class Int32Array
    {
        private static Dictionary<IntPtr, WeakReference<Int32Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int32Array>>();
        
        internal static Int32Array TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Int32Array cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Int32Array_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Int32Array(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Int32Array>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_CopyTo(IntPtr selfPtr, IntPtr array, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_Release(IntPtr selfPtr);
        
        
        internal Int32Array(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 指定したインスタンスにデータをコピーする
        /// </summary>
        /// <param name="array">コピー先のインスタンス</param>
        /// <param name="size">コピーするデータ量</param>
        public void CopyTo(Int32Array array, int size)
        {
            cbg_Int32Array_CopyTo(selfPtr, array != null ? array.selfPtr : IntPtr.Zero, size);
        }
        
        ~Int32Array()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Int32Array_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// リソースのクラス
    /// </summary>
    public partial class Resources
    {
        private static Dictionary<IntPtr, WeakReference<Resources>> cacheRepo = new Dictionary<IntPtr, WeakReference<Resources>>();
        
        internal static Resources TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Resources GetInstance()
        {
            var ret = cbg_Resources_GetInstance();
            return Resources.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定した種類のリソースの個数を返す
        /// </summary>
        /// <param name="type">個数を検索するリソースの種類</param>
        /// <returns>指定した種類のリソースの個数</returns>
        public int GetResourcesCount(ResourceType type)
        {
            var ret = cbg_Resources_GetResourcesCount(selfPtr, (int)type);
            return ret;
        }
        
        /// <summary>
        /// 登録されたリソースをすべて削除する
        /// </summary>
        public void Clear()
        {
            cbg_Resources_Clear(selfPtr);
        }
        
        /// <summary>
        /// リソースの再読み込みを行う
        /// </summary>
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
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
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
            if(native == IntPtr.Zero) return null;
        
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
        private static extern IntPtr cbg_Mouse_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Mouse_GetWheel(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Mouse_GetMouseButtonState(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Mouse_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetPosition(IntPtr selfPtr, ref Vector2F value);
        
        
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
        
        /// <summary>
        /// マウスカーソルの座標を取得または設定します。
        /// </summary>
        public Vector2F Position
        {
            get
            {
                if (_Position != null)
                {
                    return _Position.Value;
                }
                var ret = cbg_Mouse_GetPosition(selfPtr);
                return ret;
            }
            set
            {
                _Position = value;
                cbg_Mouse_SetPosition(selfPtr, ref value);
            }
        }
        private Vector2F? _Position;
        
        /// <summary>
        /// カーソルのモードを取得または設定する
        /// </summary>
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
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Mouse GetInstance()
        {
            var ret = cbg_Mouse_GetInstance();
            return Mouse.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// マウスホイールの回転量を取得します。
        /// </summary>
        /// <returns>マウスカーソルの回転量</returns>
        public float GetWheel()
        {
            var ret = cbg_Mouse_GetWheel(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// マウスボタンの状態を取得します。
        /// </summary>
        /// <param name="button">状態を取得するマウスのボタン</param>
        /// <returns>マウスボタンの状態</returns>
        public ButtonState GetMouseButtonState(MouseButtons button)
        {
            var ret = cbg_Mouse_GetMouseButtonState(selfPtr, (int)button);
            return (ButtonState)ret;
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
    
    /// <summary>
    /// ジョイスティックを表すクラス
    /// </summary>
    public partial class Joystick
    {
        private static Dictionary<IntPtr, WeakReference<Joystick>> cacheRepo = new Dictionary<IntPtr, WeakReference<Joystick>>();
        
        internal static Joystick TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Joystick_IsPresent(IntPtr selfPtr, int joystickIndex);
        
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
        
        /// <summary>
        /// 指定したジョイスティックが親であるかどうかを取得する
        /// </summary>
        /// <param name="joystickIndex">ジョイスティックのインデックス</param>
        /// <returns>指定したジョイスティックが親であったらtrue，それ以外でfalse</returns>
        public bool IsPresent(int joystickIndex)
        {
            var ret = cbg_Joystick_IsPresent(selfPtr, joystickIndex);
            return ret;
        }
        
        /// <summary>
        /// インプットの状態をリセットする
        /// </summary>
        public void RefreshInputState()
        {
            cbg_Joystick_RefreshInputState(selfPtr);
        }
        
        /// <summary>
        /// 接続の状態をリセットする
        /// </summary>
        public void RefreshConnectedState()
        {
            cbg_Joystick_RefreshConnectedState(selfPtr);
        }
        
        /// <summary>
        /// ボタンの状態をインデックスで取得する
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="buttonIndex">状態を検索するボタンのインデックス</param>
        /// <returns>指定インデックスのボタンの状態</returns>
        public ButtonState GetButtonStateByIndex(int joystickIndex, int buttonIndex)
        {
            var ret = cbg_Joystick_GetButtonStateByIndex(selfPtr, joystickIndex, buttonIndex);
            return (ButtonState)ret;
        }
        
        /// <summary>
        /// ボタンの状態を種類から取得する
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索するボタンの種類</param>
        /// <returns>指定種類のボタンの状態</returns>
        public ButtonState GetButtonStateByType(int joystickIndex, JoystickButtonType type)
        {
            var ret = cbg_Joystick_GetButtonStateByType(selfPtr, joystickIndex, (int)type);
            return (ButtonState)ret;
        }
        
        /// <summary>
        /// 指定インデックスのジョイスティックの種類を取得する
        /// </summary>
        /// <param name="index">種類を取得するジョイスティックのインデックス</param>
        /// <returns>指定インデックスのジョイスティックの種類</returns>
        public JoystickType GetJoystickType(int index)
        {
            var ret = cbg_Joystick_GetJoystickType(selfPtr, index);
            return (JoystickType)ret;
        }
        
        /// <summary>
        /// 軸の状態をインデックスで取得する
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="axisIndex">状態を検索する軸のインデックス</param>
        /// <returns>指定インデックスの軸の状態</returns>
        public float GetAxisStateByIndex(int joystickIndex, int axisIndex)
        {
            var ret = cbg_Joystick_GetAxisStateByIndex(selfPtr, joystickIndex, axisIndex);
            return ret;
        }
        
        /// <summary>
        /// 軸の状態を軸の種類で取得する
        /// </summary>
        /// <param name="joystickIndex">検索するジョイスティックのインデックス</param>
        /// <param name="type">状態を検索する軸の種類</param>
        /// <returns>指定種類の軸の状態</returns>
        public float GetAxisStateByType(int joystickIndex, JoystickAxisType type)
        {
            var ret = cbg_Joystick_GetAxisStateByType(selfPtr, joystickIndex, (int)type);
            return ret;
        }
        
        /// <summary>
        /// ジョイスティックの名前を取得する
        /// </summary>
        /// <param name="index">名前を検索するジョイスティックのインデックス</param>
        /// <returns>指定したインデックスのジョイスティックの名前</returns>
        public string GetJoystickName(int index)
        {
            var ret = cbg_Joystick_GetJoystickName(selfPtr, index);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// 振動の状態をリセットする
        /// </summary>
        public void RefreshVibrateState()
        {
            cbg_Joystick_RefreshVibrateState(selfPtr);
        }
        
        /// <summary>
        /// 振動を設定する
        /// </summary>
        /// <param name="index">ジョイスティックのインデックス</param>
        /// <param name="high_freq"></param>
        /// <param name="low_freq"></param>
        /// <param name="high_amp"></param>
        /// <param name="low_amp"></param>
        /// <param name="life_time"></param>
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
    
    /// <summary>
    /// グラフィックの制御を行うクラス
    /// </summary>
    public partial class Graphics
    {
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();
        
        internal static Graphics TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_DoEvents(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Graphics_GetCommandList(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);
        
        
        internal Graphics(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// コマンドリストを取得する
        /// </summary>
        public CommandList CommandList
        {
            get
            {
                var ret = cbg_Graphics_GetCommandList(selfPtr);
                return CommandList.TryGetFromCache(ret);
            }
        }
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Graphics GetInstance()
        {
            var ret = cbg_Graphics_GetInstance();
            return Graphics.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 描画を開始します。
        /// </summary>
        /// <returns>正常に開始した場合は　true 。それ以外の場合は false。</returns>
        public bool BeginFrame()
        {
            var ret = cbg_Graphics_BeginFrame(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 描画を終了します。
        /// </summary>
        /// <returns>正常に終了した場合は　true 。それ以外の場合は false。</returns>
        public bool EndFrame()
        {
            var ret = cbg_Graphics_EndFrame(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// イベントを処理します。
        /// </summary>
        /// <returns>正常に処理した場合は　true 。それ以外の場合は false。</returns>
        public bool DoEvents()
        {
            var ret = cbg_Graphics_DoEvents(selfPtr);
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
    
    /// <summary>
    /// 2Dテクスチャのクラス
    /// </summary>
    public partial class Texture2D
    {
        private static Dictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new Dictionary<IntPtr, WeakReference<Texture2D>>();
        
        internal static Texture2D TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        private static extern IntPtr cbg_Texture2D_Load([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Texture2D_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Texture2D_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Texture2D_Release(IntPtr selfPtr);
        
        
        internal Texture2D(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// テクスチャの大きさ(ピクセル)を取得する
        /// </summary>
        public Vector2I Size
        {
            get
            {
                var ret = cbg_Texture2D_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 指定したファイルからテクスチャを読み込みます。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>テクスチャ</returns>
        public static Texture2D Load(string path)
        {
            var ret = cbg_Texture2D_Load(path);
            return Texture2D.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 再読み込みを行う
        /// </summary>
        /// <returns>再読み込みに成功したら true。それ以外の場合は false</returns>
        public bool Reload()
        {
            var ret = cbg_Texture2D_Reload(selfPtr);
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
    
    /// <summary>
    /// レンダラのクラス
    /// </summary>
    public partial class Renderer
    {
        private static Dictionary<IntPtr, WeakReference<Renderer>> cacheRepo = new Dictionary<IntPtr, WeakReference<Renderer>>();
        
        internal static Renderer TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Renderer cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Renderer_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Renderer(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Renderer>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Renderer_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Reset(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Render(IntPtr selfPtr, IntPtr commandList);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Renderer_CreateSprite(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Release(IntPtr selfPtr);
        
        
        internal Renderer(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Renderer GetInstance()
        {
            var ret = cbg_Renderer_GetInstance();
            return Renderer.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// レンダラをリセットします。
        /// </summary>
        public void Reset()
        {
            cbg_Renderer_Reset(selfPtr);
        }
        
        /// <summary>
        /// コマンドリストを描画します。
        /// </summary>
        /// <param name="commandList">コマンドリスト</param>
        public void Render(CommandList commandList)
        {
            cbg_Renderer_Render(selfPtr, commandList != null ? commandList.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// スプライトを作成します。
        /// </summary>
        /// <returns>スプライト</returns>
        public RenderedSprite CreateSprite()
        {
            var ret = cbg_Renderer_CreateSprite(selfPtr);
            return RenderedSprite.TryGetFromCache(ret);
        }
        
        ~Renderer()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Renderer_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// コマンドリストのクラス
    /// </summary>
    public partial class CommandList
    {
        private static Dictionary<IntPtr, WeakReference<CommandList>> cacheRepo = new Dictionary<IntPtr, WeakReference<CommandList>>();
        
        internal static CommandList TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                CommandList cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_CommandList_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new CommandList(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<CommandList>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_CommandList_SetRenderTargetWithScreen(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_CommandList_Release(IntPtr selfPtr);
        
        
        internal CommandList(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// ？
        /// </summary>
        public void SetRenderTargetWithScreen()
        {
            cbg_CommandList_SetRenderTargetWithScreen(selfPtr);
        }
        
        ~CommandList()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_CommandList_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// スプライトのクラス
    /// </summary>
    public partial class RenderedSprite
    {
        private static Dictionary<IntPtr, WeakReference<RenderedSprite>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedSprite>>();
        
        internal static RenderedSprite TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                RenderedSprite cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderedSprite_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new RenderedSprite(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderedSprite>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedSprite_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern RectF cbg_RenderedSprite_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetSrc(IntPtr selfPtr, ref RectF value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_Release(IntPtr selfPtr);
        
        
        internal RenderedSprite(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// テクスチャを取得または設定する
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                if (_Texture != null)
                {
                    return _Texture;
                }
                var ret = cbg_RenderedSprite_GetTexture(selfPtr);
                return Texture2D.TryGetFromCache(ret);
            }
            set
            {
                _Texture = value;
                cbg_RenderedSprite_SetTexture(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Texture2D _Texture;
        
        /// <summary>
        /// 描画範囲を取得または設定する
        /// </summary>
        public RectF Src
        {
            get
            {
                if (_Src != null)
                {
                    return _Src.Value;
                }
                var ret = cbg_RenderedSprite_GetSrc(selfPtr);
                return ret;
            }
            set
            {
                _Src = value;
                cbg_RenderedSprite_SetSrc(selfPtr, ref value);
            }
        }
        private RectF? _Src;
        
        ~RenderedSprite()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderedSprite_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// 段階的にファイルを読み取るクラス
    /// </summary>
    public partial class StreamFile
    {
        private static Dictionary<IntPtr, WeakReference<StreamFile>> cacheRepo = new Dictionary<IntPtr, WeakReference<StreamFile>>();
        
        internal static StreamFile TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        private static extern int cbg_StreamFile_Read(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StreamFile_GetTempBuffer(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetCurrentPosition(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StreamFile_GetTempBufferSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_GetIsInPackage(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_StreamFile_Release(IntPtr selfPtr);
        
        
        internal StreamFile(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 読み込むファイルのデータサイズを取得する
        /// </summary>
        public int Size
        {
            get
            {
                var ret = cbg_StreamFile_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 現在読み込んでいるファイル上の位置を取得する
        /// </summary>
        public int CurrentPosition
        {
            get
            {
                var ret = cbg_StreamFile_GetCurrentPosition(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 現在読み込んでいるファイルのデータサイズを取得する
        /// </summary>
        public int TempBufferSize
        {
            get
            {
                var ret = cbg_StreamFile_GetTempBufferSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 読み込むファイルがファイルパッケージ内に格納されているかどうかを取得する
        /// </summary>
        public bool IsInPackage
        {
            get
            {
                var ret = cbg_StreamFile_GetIsInPackage(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 指定した分ファイルを読み込む
        /// </summary>
        /// <param name="size">この処理で読み込むデータサイズ</param>
        /// <returns>読み込まれたデータサイズ</returns>
        public int Read(int size)
        {
            var ret = cbg_StreamFile_Read(selfPtr, size);
            return ret;
        }
        
        /// <summary>
        /// 現在読み込んでいるファイルのデータを取得する
        /// </summary>
        /// <returns>現在読み込んでいるファイルのデータ</returns>
        public Int8Array GetTempBuffer()
        {
            var ret = cbg_StreamFile_GetTempBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 再読み込みを行う
        /// </summary>
        /// <returns>再読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
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
    
    /// <summary>
    /// 一度でファイルを読み取るクラス
    /// </summary>
    public partial class StaticFile
    {
        private static Dictionary<IntPtr, WeakReference<StaticFile>> cacheRepo = new Dictionary<IntPtr, WeakReference<StaticFile>>();
        
        internal static StaticFile TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StaticFile_GetPath(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_StaticFile_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_GetIsInPackage(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_StaticFile_Release(IntPtr selfPtr);
        
        
        internal StaticFile(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 読み込んだファイルのパスを取得する
        /// </summary>
        public string Path
        {
            get
            {
                var ret = cbg_StaticFile_GetPath(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }
        
        /// <summary>
        /// 読み込んだファイルのデータサイズを取得する
        /// </summary>
        public int Size
        {
            get
            {
                var ret = cbg_StaticFile_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 読み込んだファイルがファイルパッケージ内に格納されているかどうかを取得する
        /// </summary>
        public bool IsInPackage
        {
            get
            {
                var ret = cbg_StaticFile_GetIsInPackage(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 読み込んだファイルのデータを取得する
        /// </summary>
        /// <returns>読み込んだファイルのデータ</returns>
        public Int8Array GetBuffer()
        {
            var ret = cbg_StaticFile_GetBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 再読み込みを行う
        /// </summary>
        /// <returns>再読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
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
    
    /// <summary>
    /// ファイル制御を行うクラス
    /// </summary>
    public partial class File
    {
        private static Dictionary<IntPtr, WeakReference<File>> cacheRepo = new Dictionary<IntPtr, WeakReference<File>>();
        
        internal static File TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
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
        
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static File GetInstance()
        {
            var ret = cbg_File_GetInstance();
            return File.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定ファイルを読み込んだStaticFileの新しいインスタンスを生成する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>pathで読み込んだファイルを格納するStaticFileの新しいインスタンスを生成する</returns>
        internal StaticFile CreateStaticFile(string path)
        {
            var ret = cbg_File_CreateStaticFile(selfPtr, path);
            return StaticFile.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定ファイルを読み込むStreamFileの新しいインスタンスを生成する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>pathで読み込むファイルを格納するStreamFileの新しいインスタンスを生成する</returns>
        internal StreamFile CreateStreamFile(string path)
        {
            var ret = cbg_File_CreateStreamFile(selfPtr, path);
            return StreamFile.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// ファイル読み込み時に自動的に保管されるディレクトリを追加する
        /// </summary>
        /// <param name="path">追加するディレクトリ</param>
        /// <returns>追加処理がうまくいったらtrue，それ以外でfalse</returns>
        public bool AddRootDirectory(string path)
        {
            var ret = cbg_File_AddRootDirectory(selfPtr, path);
            return ret;
        }
        
        /// <summary>
        /// ファイルパッケージをパスワード有りで読み込む
        /// </summary>
        /// <param name="path">読み込むファイルパッケージのパス</param>
        /// <param name="password">読み込むファイルパッケージのパスワード</param>
        /// <returns>読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
        public bool AddRootPackageWithPassword(string path, string password)
        {
            var ret = cbg_File_AddRootPackageWithPassword(selfPtr, path, password);
            return ret;
        }
        
        /// <summary>
        /// ファイルパッケージをパスワード無しで読み込む
        /// </summary>
        /// <param name="path">読み込むファイルパッケージのパス</param>
        /// <returns>読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
        public bool AddRootPackage(string path)
        {
            var ret = cbg_File_AddRootPackage(selfPtr, path);
            return ret;
        }
        
        /// <summary>
        /// 追加されたディレクトリやファイルパッケージをすべて削除する
        /// </summary>
        public void ClearRootDirectories()
        {
            cbg_File_ClearRootDirectories(selfPtr);
        }
        
        /// <summary>
        /// 指定したファイルが存在するかどうかを検索する
        /// </summary>
        /// <param name="path">存在を確認するファイルのパス</param>
        /// <returns>pathの示すファイルが存在していたらtrue，それ以外でfalse</returns>
        public bool Exists(string path)
        {
            var ret = cbg_File_Exists(selfPtr, path);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="dstPath"></param>
        /// <returns></returns>
        public bool Pack(string srcPath, string dstPath)
        {
            var ret = cbg_File_Pack(selfPtr, srcPath, dstPath);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="dstPath"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
    
    /// <summary>
    /// 音源のクラス
    /// </summary>
    public partial class Sound
    {
        private static Dictionary<IntPtr, WeakReference<Sound>> cacheRepo = new Dictionary<IntPtr, WeakReference<Sound>>();
        
        internal static Sound TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Sound cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Sound_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Sound(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Sound>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Sound_GetLoopStartingPoint(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Sound_SetLoopStartingPoint(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Sound_GetLoopEndPoint(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Sound_SetLoopEndPoint(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Sound_GetIsLoopingMode(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Sound_SetIsLoopingMode(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Sound_GetLength(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Sound_Release(IntPtr selfPtr);
        
        
        internal Sound(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// ループ開始地点(秒)を取得または設定する
        /// </summary>
        public float LoopStartingPoint
        {
            get
            {
                if (_LoopStartingPoint != null)
                {
                    return _LoopStartingPoint.Value;
                }
                var ret = cbg_Sound_GetLoopStartingPoint(selfPtr);
                return ret;
            }
            set
            {
                _LoopStartingPoint = value;
                cbg_Sound_SetLoopStartingPoint(selfPtr, value);
            }
        }
        private float? _LoopStartingPoint;
        
        /// <summary>
        /// ループ終了地点(秒)を取得または設定する
        /// </summary>
        public float LoopEndPoint
        {
            get
            {
                if (_LoopEndPoint != null)
                {
                    return _LoopEndPoint.Value;
                }
                var ret = cbg_Sound_GetLoopEndPoint(selfPtr);
                return ret;
            }
            set
            {
                _LoopEndPoint = value;
                cbg_Sound_SetLoopEndPoint(selfPtr, value);
            }
        }
        private float? _LoopEndPoint;
        
        /// <summary>
        /// ループするかどうかを取得または設定する
        /// </summary>
        public bool IsLoopingMode
        {
            get
            {
                if (_IsLoopingMode != null)
                {
                    return _IsLoopingMode.Value;
                }
                var ret = cbg_Sound_GetIsLoopingMode(selfPtr);
                return ret;
            }
            set
            {
                _IsLoopingMode = value;
                cbg_Sound_SetIsLoopingMode(selfPtr, value);
            }
        }
        private bool? _IsLoopingMode;
        
        /// <summary>
        /// 音源の長さ(秒)を取得する
        /// </summary>
        public float Length
        {
            get
            {
                var ret = cbg_Sound_GetLength(selfPtr);
                return ret;
            }
        }
        
        ~Sound()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Sound_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class SoundMixer
    {
        private static Dictionary<IntPtr, WeakReference<SoundMixer>> cacheRepo = new Dictionary<IntPtr, WeakReference<SoundMixer>>();
        
        internal static SoundMixer TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                SoundMixer cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_SoundMixer_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new SoundMixer(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<SoundMixer>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_SoundMixer_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_SoundMixer_CreateSound(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool isDecompressed);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_SoundMixer_Play(IntPtr selfPtr, IntPtr sound);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_SoundMixer_GetIsPlaying(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_StopAll(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Stop(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Pause(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Resume(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Seek(IntPtr selfPtr, int id, float position);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_SetVolume(IntPtr selfPtr, int id, float volume);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_FadeIn(IntPtr selfPtr, int id, float second);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_FadeOut(IntPtr selfPtr, int id, float second);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Fade(IntPtr selfPtr, int id, float second, float targetedVolume);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_SoundMixer_GetIsPlaybackSpeedEnabled(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_SetIsPlaybackSpeedEnabled(IntPtr selfPtr, int id, [MarshalAs(UnmanagedType.Bool)] bool isPlaybackSpeedEnabled);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_SoundMixer_GetPlaybackSpeed(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_SetPlaybackSpeed(IntPtr selfPtr, int id, float playbackSpeed);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_SoundMixer_GetPanningPosition(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_SetPanningPosition(IntPtr selfPtr, int id, float panningPosition);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_SoundMixer_GetPlaybackPercent(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Release(IntPtr selfPtr);
        
        
        internal SoundMixer(MemoryHandle handle)
        {
            this.selfPtr = handle.selfPtr;
        }
        
        internal static SoundMixer GetInstance()
        {
            var ret = cbg_SoundMixer_GetInstance();
            return SoundMixer.TryGetFromCache(ret);
        }
        
        public Sound CreateSound(string path, bool isDecompressed)
        {
            var ret = cbg_SoundMixer_CreateSound(selfPtr, path, isDecompressed);
            return Sound.TryGetFromCache(ret);
        }
        
        public int Play(Sound sound)
        {
            var ret = cbg_SoundMixer_Play(selfPtr, sound != null ? sound.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        public bool GetIsPlaying(int id)
        {
            var ret = cbg_SoundMixer_GetIsPlaying(selfPtr, id);
            return ret;
        }
        
        public void StopAll()
        {
            cbg_SoundMixer_StopAll(selfPtr);
        }
        
        public void Stop(int id)
        {
            cbg_SoundMixer_Stop(selfPtr, id);
        }
        
        public void Pause(int id)
        {
            cbg_SoundMixer_Pause(selfPtr, id);
        }
        
        public void Resume(int id)
        {
            cbg_SoundMixer_Resume(selfPtr, id);
        }
        
        public void Seek(int id, float position)
        {
            cbg_SoundMixer_Seek(selfPtr, id, position);
        }
        
        public void SetVolume(int id, float volume)
        {
            cbg_SoundMixer_SetVolume(selfPtr, id, volume);
        }
        
        public void FadeIn(int id, float second)
        {
            cbg_SoundMixer_FadeIn(selfPtr, id, second);
        }
        
        public void FadeOut(int id, float second)
        {
            cbg_SoundMixer_FadeOut(selfPtr, id, second);
        }
        
        public void Fade(int id, float second, float targetedVolume)
        {
            cbg_SoundMixer_Fade(selfPtr, id, second, targetedVolume);
        }
        
        public bool GetIsPlaybackSpeedEnabled(int id)
        {
            var ret = cbg_SoundMixer_GetIsPlaybackSpeedEnabled(selfPtr, id);
            return ret;
        }
        
        public void SetIsPlaybackSpeedEnabled(int id, bool isPlaybackSpeedEnabled)
        {
            cbg_SoundMixer_SetIsPlaybackSpeedEnabled(selfPtr, id, isPlaybackSpeedEnabled);
        }
        
        public float GetPlaybackSpeed(int id)
        {
            var ret = cbg_SoundMixer_GetPlaybackSpeed(selfPtr, id);
            return ret;
        }
        
        public void SetPlaybackSpeed(int id, float playbackSpeed)
        {
            cbg_SoundMixer_SetPlaybackSpeed(selfPtr, id, playbackSpeed);
        }
        
        public float GetPanningPosition(int id)
        {
            var ret = cbg_SoundMixer_GetPanningPosition(selfPtr, id);
            return ret;
        }
        
        public void SetPanningPosition(int id, float panningPosition)
        {
            cbg_SoundMixer_SetPanningPosition(selfPtr, id, panningPosition);
        }
        
        public float GetPlaybackPercent(int id)
        {
            var ret = cbg_SoundMixer_GetPlaybackPercent(selfPtr, id);
            return ret;
        }
        
        ~SoundMixer()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_SoundMixer_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
}
