// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!                                          !!
// !!  THIS FILE IS AUTO GENERATED.            !!
// !!  YOUR COMMIT ON THI FILE WILL BE WIPED.  !!
// !!                                          !!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections.Concurrent;

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
    /// フレームレートモード
    /// </summary>
    public enum FramerateMode : int
    {
        Variable,
        Constant,
    }
    
    /// <summary>
    /// リソースの種類を表します。
    /// </summary>
    public enum ResourceType : int
    {
        StaticFile,
        StreamFile,
        Texture2D,
        Font,
        Sound,
        MAX,
    }
    
    /// <summary>
    /// キーボードのキーの種類を表します。
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
    /// マウスのボタンの種類を表します。
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
    /// カーソルの状態を表します。
    /// </summary>
    public enum CursorMode : int
    {
        Normal = 212993,
        Hidden = 212994,
        Disable = 212995,
    }
    
    /// <summary>
    /// ジョイスティックの種類を表します。
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
    /// ジョイスティックのボタンの種類を表します。
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
    /// ジョイスティックの軸の種類を表します。
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
    
    public enum BuildinShaderType : int
    {
        SpriteUnlitVS,
        SpriteUnlitPS,
        FontUnlitPS,
    }
    
    public enum WritingDirection : int
    {
        Vertical,
        Horizontal,
    }
    
    /// <summary>
    /// ImGuiで使用する方向
    /// </summary>
    public enum ToolDir : int
    {
        None = -1,
        Left = 0,
        Right = 2,
        Up = 2,
        Down = 3,
    }
    
    /// <summary>
    /// バイナリ演算子を使用して複数の値を結合しないでください
    /// </summary>
    public enum ToolCond : int
    {
        None = 0,
        Always = 1,
    }
    
    public enum ToolTreeNode : int
    {
        None = 0,
        Selected = 1,
    }
    
    public enum ToolInputText : int
    {
        None = 0,
        CharsDecimal = 1,
    }
    
    public enum ToolColorEdit : int
    {
        None = 0,
        NoAlpha = 2,
    }
    
    public enum ToolSelectable : int
    {
        None = 0,
    }
    
    public enum ToolWindow : int
    {
        None = 0,
        NoTitleBar = 1,
    }
    
    public enum ToolTabBar : int
    {
        None = 0,
        Reorderable = 1,
    }
    
    /// <summary>
    /// Tool機能を使ってフォントを読み込む際の範囲を指定します。ビット演算は行わないでください。
    /// </summary>
    public enum ToolGlyphRanges : int
    {
        Default,
        Cyrillic,
    }
    
    /// <summary>
    /// 音のスペクトル解析に使用する窓関数
    /// </summary>
    public enum FFTWindow : int
    {
        Rectangular,
        Triangle,
        Hamming,
        Hanning,
        Blackman,
        BlackmanHarris,
    }
    
    /// <summary>
    /// ログレベルを表します。
    /// </summary>
    public enum LogLevel : int
    {
        Trace = 0,
        Debug = 1,
        Info = 2,
        Warn = 3,
        Error = 4,
        Critical = 5,
        Off = 6,
    }
    
    /// <summary>
    /// ログの範囲を表します。
    /// </summary>
    public enum LogCategory : int
    {
        Engine = 1,
        User = 2,
    }
    
    /// <summary>
    /// Coreを初期化する際の設定を保持すクラス
    /// </summary>
    public partial class Configuration
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Configuration>> cacheRepo = new Dictionary<IntPtr, WeakReference<Configuration>>();
        
        internal static  Configuration TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Configuration cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Configuration_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Configuration(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Configuration>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Configuration_Constructor_0();
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetIsFullscreenMode(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetIsFullscreenMode(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetIsResizable(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetIsResizable(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetEnabledConsoleLogging(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetEnabledConsoleLogging(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetEnabledFileLogging(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetEnabledFileLogging(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Configuration_GetLogFilename(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetLogFilename(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Configuration(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 全画面モードかどうかを取得または設定します。
        /// </summary>
        public bool IsFullscreenMode
        {
            get
            {
                if (_IsFullscreenMode != null)
                {
                    return _IsFullscreenMode.Value;
                }
                var ret = cbg_Configuration_GetIsFullscreenMode(selfPtr);
                return ret;
            }
            set
            {
                _IsFullscreenMode = value;
                cbg_Configuration_SetIsFullscreenMode(selfPtr, value);
            }
        }
        private bool? _IsFullscreenMode;
        
        /// <summary>
        /// 画面サイズ可変かどうかを取得または設定します。
        /// </summary>
        public bool IsResizable
        {
            get
            {
                if (_IsResizable != null)
                {
                    return _IsResizable.Value;
                }
                var ret = cbg_Configuration_GetIsResizable(selfPtr);
                return ret;
            }
            set
            {
                _IsResizable = value;
                cbg_Configuration_SetIsResizable(selfPtr, value);
            }
        }
        private bool? _IsResizable;
        
        /// <summary>
        /// ログをコンソールに出力するかどうかを取得または設定します。
        /// </summary>
        public bool EnabledConsoleLogging
        {
            get
            {
                if (_EnabledConsoleLogging != null)
                {
                    return _EnabledConsoleLogging.Value;
                }
                var ret = cbg_Configuration_GetEnabledConsoleLogging(selfPtr);
                return ret;
            }
            set
            {
                _EnabledConsoleLogging = value;
                cbg_Configuration_SetEnabledConsoleLogging(selfPtr, value);
            }
        }
        private bool? _EnabledConsoleLogging;
        
        /// <summary>
        /// ログをファイルに出力するかどうかを取得または設定します。
        /// </summary>
        public bool EnabledFileLogging
        {
            get
            {
                if (_EnabledFileLogging != null)
                {
                    return _EnabledFileLogging.Value;
                }
                var ret = cbg_Configuration_GetEnabledFileLogging(selfPtr);
                return ret;
            }
            set
            {
                _EnabledFileLogging = value;
                cbg_Configuration_SetEnabledFileLogging(selfPtr, value);
            }
        }
        private bool? _EnabledFileLogging;
        
        /// <summary>
        /// ログファイル名を取得または設定します。
        /// </summary>
        public string LogFilename
        {
            get
            {
                if (_LogFilename != null)
                {
                    return _LogFilename;
                }
                var ret = cbg_Configuration_GetLogFilename(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
            set
            {
                _LogFilename = value;
                cbg_Configuration_SetLogFilename(selfPtr, value);
            }
        }
        private string _LogFilename;
        
        public Configuration()
        {
            selfPtr = cbg_Configuration_Constructor_0();
        }
        
        ~Configuration()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Configuration_Release(selfPtr);
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Core>> cacheRepo = new Dictionary<IntPtr, WeakReference<Core>>();
        
        internal static  Core TryGetFromCache(IntPtr native)
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
        private static extern bool cbg_Core_Initialize([MarshalAs(UnmanagedType.LPWStr)] string title, int width, int height, IntPtr config);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_DoEvent(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_Terminate();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Core_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Core_GetDeltaSecond(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Core_GetCurrentFPS(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Core_GetTargetFPS(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_SetTargetFPS(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Core_GetFramerateMode(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_SetFramerateMode(IntPtr selfPtr, int value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Core_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Core(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 前のフレームからの経過時間(秒)を取得します。
        /// </summary>
        public float DeltaSecond
        {
            get
            {
                var ret = cbg_Core_GetDeltaSecond(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 現在のFPSを取得します。
        /// </summary>
        public float CurrentFPS
        {
            get
            {
                var ret = cbg_Core_GetCurrentFPS(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 目標のFPSを取得または設定します。
        /// </summary>
        public float TargetFPS
        {
            get
            {
                if (_TargetFPS != null)
                {
                    return _TargetFPS.Value;
                }
                var ret = cbg_Core_GetTargetFPS(selfPtr);
                return ret;
            }
            set
            {
                _TargetFPS = value;
                cbg_Core_SetTargetFPS(selfPtr, value);
            }
        }
        private float? _TargetFPS;
        
        /// <summary>
        /// フレームレートモードを取得または設定します。デフォルトでは可変フレームレートです。
        /// </summary>
        public FramerateMode FramerateMode
        {
            get
            {
                if (_FramerateMode != null)
                {
                    return _FramerateMode.Value;
                }
                var ret = cbg_Core_GetFramerateMode(selfPtr);
                return (FramerateMode)ret;
            }
            set
            {
                _FramerateMode = value;
                cbg_Core_SetFramerateMode(selfPtr, (int)value);
            }
        }
        private FramerateMode? _FramerateMode;
        
        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        /// <param name="title">ウィンドウの左上に表示されるウィンドウん名</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">初期化時の設定</param>
        /// <returns>初期化処理がうまくいったらtrue，それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config)
        {
            var ret = cbg_Core_Initialize(title, width, height, config != null ? config.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// イベントを実行します。
        /// </summary>
        /// <returns>イベントが進行出来たらtrue，それ以外でfalse</returns>
        public bool DoEvent()
        {
            var ret = cbg_Core_DoEvent(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 終了処理を行います。
        /// </summary>
        public static void Terminate()
        {
            cbg_Core_Terminate();
        }
        
        /// <summary>
        /// インスタンスを取得します。
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
    /// 8ビット整数の配列のクラスを表します。
    /// </summary>
    public partial class Int8Array
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Int8Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int8Array>>();
        
        internal static  Int8Array TryGetFromCache(IntPtr native)
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
        private static extern void cbg_Int8Array_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_Resize(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Int8Array_GetData(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_Assign(IntPtr selfPtr, IntPtr ptr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_CopyTo(IntPtr selfPtr, IntPtr ptr);
        
        [DllImport("Altseed_Core")]
        private static extern byte cbg_Int8Array_GetAt(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_SetAt(IntPtr selfPtr, int index, byte value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Int8Array_Create(int size);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Int8Array_GetCount(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int8Array_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Int8Array(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 格納されている要素の数を取得します。
        /// </summary>
        public int Count
        {
            get
            {
                var ret = cbg_Int8Array_GetCount(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// データをクリアします。
        /// </summary>
        public void Clear()
        {
            cbg_Int8Array_Clear(selfPtr);
        }
        
        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">要素数</param>
        public void Resize(int size)
        {
            cbg_Int8Array_Resize(selfPtr, size);
        }
        
        public IntPtr GetData()
        {
            var ret = cbg_Int8Array_GetData(selfPtr);
            return ret;
        }
        
        public void Assign(IntPtr ptr, int size)
        {
            cbg_Int8Array_Assign(selfPtr, ptr, size);
        }
        
        /// <summary>
        /// データを指定したポインタにコピーします。
        /// </summary>
        /// <param name="ptr">ポインタ</param>
        public void CopyTo(IntPtr ptr)
        {
            cbg_Int8Array_CopyTo(selfPtr, ptr);
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        public byte GetAt(int index)
        {
            var ret = cbg_Int8Array_GetAt(selfPtr, index);
            return ret;
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        public void SetAt(int index, byte value)
        {
            cbg_Int8Array_SetAt(selfPtr, index, value);
        }
        
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        public static Int8Array Create(int size)
        {
            var ret = cbg_Int8Array_Create(size);
            return Int8Array.TryGetFromCache(ret);
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
    /// 32ビット整数の配列のクラスを表します。
    /// </summary>
    public partial class Int32Array
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Int32Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int32Array>>();
        
        internal static  Int32Array TryGetFromCache(IntPtr native)
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
        private static extern void cbg_Int32Array_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_Resize(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Int32Array_GetData(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_Assign(IntPtr selfPtr, IntPtr ptr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_CopyTo(IntPtr selfPtr, IntPtr ptr);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Int32Array_GetAt(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_SetAt(IntPtr selfPtr, int index, int value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Int32Array_Create(int size);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Int32Array_GetCount(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Int32Array_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Int32Array(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 格納されている要素の数を取得します。
        /// </summary>
        public int Count
        {
            get
            {
                var ret = cbg_Int32Array_GetCount(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// データをクリアします。
        /// </summary>
        public void Clear()
        {
            cbg_Int32Array_Clear(selfPtr);
        }
        
        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">要素数</param>
        public void Resize(int size)
        {
            cbg_Int32Array_Resize(selfPtr, size);
        }
        
        public IntPtr GetData()
        {
            var ret = cbg_Int32Array_GetData(selfPtr);
            return ret;
        }
        
        public void Assign(IntPtr ptr, int size)
        {
            cbg_Int32Array_Assign(selfPtr, ptr, size);
        }
        
        /// <summary>
        /// データを指定したポインタにコピーします。
        /// </summary>
        /// <param name="ptr">ポインタ</param>
        public void CopyTo(IntPtr ptr)
        {
            cbg_Int32Array_CopyTo(selfPtr, ptr);
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        public int GetAt(int index)
        {
            var ret = cbg_Int32Array_GetAt(selfPtr, index);
            return ret;
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        public void SetAt(int index, int value)
        {
            cbg_Int32Array_SetAt(selfPtr, index, value);
        }
        
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        public static Int32Array Create(int size)
        {
            var ret = cbg_Int32Array_Create(size);
            return Int32Array.TryGetFromCache(ret);
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
    /// 頂点データの配列のクラスを表します。
    /// </summary>
    public partial class VertexArray
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<VertexArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<VertexArray>>();
        
        internal static  VertexArray TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                VertexArray cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_VertexArray_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new VertexArray(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<VertexArray>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_Resize(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_VertexArray_GetData(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_CopyTo(IntPtr selfPtr, IntPtr ptr);
        
        [DllImport("Altseed_Core")]
        private static extern Vertex cbg_VertexArray_GetAt(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_SetAt(IntPtr selfPtr, int index, ref Vertex value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_VertexArray_Create(int size);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_VertexArray_GetCount(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_VertexArray_Release(IntPtr selfPtr);
        
        #endregion
        
        internal VertexArray(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 格納されている要素の数を取得します。
        /// </summary>
        public int Count
        {
            get
            {
                var ret = cbg_VertexArray_GetCount(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// データをクリアします。
        /// </summary>
        public void Clear()
        {
            cbg_VertexArray_Clear(selfPtr);
        }
        
        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">要素数</param>
        public void Resize(int size)
        {
            cbg_VertexArray_Resize(selfPtr, size);
        }
        
        public IntPtr GetData()
        {
            var ret = cbg_VertexArray_GetData(selfPtr);
            return ret;
        }
        
        public void Assign(IntPtr ptr, int size)
        {
            cbg_VertexArray_Assign(selfPtr, ptr, size);
        }
        
        /// <summary>
        /// データを指定したポインタにコピーします。
        /// </summary>
        /// <param name="ptr">ポインタ</param>
        public void CopyTo(IntPtr ptr)
        {
            cbg_VertexArray_CopyTo(selfPtr, ptr);
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        public Vertex GetAt(int index)
        {
            var ret = cbg_VertexArray_GetAt(selfPtr, index);
            return ret;
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        public void SetAt(int index, ref Vertex value)
        {
            cbg_VertexArray_SetAt(selfPtr, index, ref value);
        }
        
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        public static VertexArray Create(int size)
        {
            var ret = cbg_VertexArray_Create(size);
            return VertexArray.TryGetFromCache(ret);
        }
        
        ~VertexArray()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_VertexArray_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// 浮動小数点数の配列のクラスを表します。
    /// </summary>
    public partial class FloatArray
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<FloatArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<FloatArray>>();
        
        internal static  FloatArray TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                FloatArray cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_FloatArray_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new FloatArray(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<FloatArray>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_Resize(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_FloatArray_GetData(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_CopyTo(IntPtr selfPtr, IntPtr ptr);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_FloatArray_GetAt(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_SetAt(IntPtr selfPtr, int index, float value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_FloatArray_Create(int size);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_FloatArray_GetCount(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_FloatArray_Release(IntPtr selfPtr);
        
        #endregion
        
        internal FloatArray(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 格納されている要素の数を取得します。
        /// </summary>
        public int Count
        {
            get
            {
                var ret = cbg_FloatArray_GetCount(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// データをクリアします。
        /// </summary>
        public void Clear()
        {
            cbg_FloatArray_Clear(selfPtr);
        }
        
        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">要素数</param>
        public void Resize(int size)
        {
            cbg_FloatArray_Resize(selfPtr, size);
        }
        
        public IntPtr GetData()
        {
            var ret = cbg_FloatArray_GetData(selfPtr);
            return ret;
        }
        
        public void Assign(IntPtr ptr, int size)
        {
            cbg_FloatArray_Assign(selfPtr, ptr, size);
        }
        
        /// <summary>
        /// データを指定したポインタにコピーします。
        /// </summary>
        /// <param name="ptr">ポインタ</param>
        public void CopyTo(IntPtr ptr)
        {
            cbg_FloatArray_CopyTo(selfPtr, ptr);
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        public float GetAt(int index)
        {
            var ret = cbg_FloatArray_GetAt(selfPtr, index);
            return ret;
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        public void SetAt(int index, float value)
        {
            cbg_FloatArray_SetAt(selfPtr, index, value);
        }
        
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        public static FloatArray Create(int size)
        {
            var ret = cbg_FloatArray_Create(size);
            return FloatArray.TryGetFromCache(ret);
        }
        
        ~FloatArray()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_FloatArray_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// リソースのクラスを表します。
    /// </summary>
    public partial class Resources
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Resources>> cacheRepo = new Dictionary<IntPtr, WeakReference<Resources>>();
        
        internal static  Resources TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal Resources(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Resources GetInstance()
        {
            var ret = cbg_Resources_GetInstance();
            return Resources.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定した種類のリソースの個数を返します。
        /// </summary>
        /// <param name="type">個数を検索するリソースの種類</param>
        /// <returns>指定した種類のリソースの個数</returns>
        public int GetResourcesCount(ResourceType type)
        {
            var ret = cbg_Resources_GetResourcesCount(selfPtr, (int)type);
            return ret;
        }
        
        /// <summary>
        /// 登録されたリソースをすべて削除します。
        /// </summary>
        public void Clear()
        {
            cbg_Resources_Clear(selfPtr);
        }
        
        /// <summary>
        /// リソースの再読み込みを行います。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Keyboard>> cacheRepo = new Dictionary<IntPtr, WeakReference<Keyboard>>();
        
        internal static  Keyboard TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal Keyboard(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        /// インスタンスを取得します。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Mouse>> cacheRepo = new Dictionary<IntPtr, WeakReference<Mouse>>();
        
        internal static  Mouse TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal Mouse(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        /// カーソルのモードを取得または設定します。
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
        /// インスタンスを取得します。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Joystick>> cacheRepo = new Dictionary<IntPtr, WeakReference<Joystick>>();
        
        internal static  Joystick TryGetFromCache(IntPtr native)
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
        private static extern IntPtr cbg_Joystick_GetInstance();
        
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
        
        #endregion
        
        internal Joystick(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Joystick GetInstance()
        {
            var ret = cbg_Joystick_GetInstance();
            return Joystick.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定したジョイスティックが親であるかどうかを取得します。
        /// </summary>
        /// <param name="joystickIndex">ジョイスティックのインデックス</param>
        /// <returns>指定したジョイスティックが親であったらtrue，それ以外でfalse</returns>
        public bool IsPresent(int joystickIndex)
        {
            var ret = cbg_Joystick_IsPresent(selfPtr, joystickIndex);
            return ret;
        }
        
        /// <summary>
        /// インプットの状態をリセットします。
        /// </summary>
        public void RefreshInputState()
        {
            cbg_Joystick_RefreshInputState(selfPtr);
        }
        
        /// <summary>
        /// 接続の状態をリセットします。
        /// </summary>
        public void RefreshConnectedState()
        {
            cbg_Joystick_RefreshConnectedState(selfPtr);
        }
        
        /// <summary>
        /// ボタンの状態をインデックスで取得します。
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
        /// ボタンの状態を種類から取得します。
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
        /// 指定インデックスのジョイスティックの種類を取得します。
        /// </summary>
        /// <param name="index">種類を取得するジョイスティックのインデックス</param>
        /// <returns>指定インデックスのジョイスティックの種類</returns>
        public JoystickType GetJoystickType(int index)
        {
            var ret = cbg_Joystick_GetJoystickType(selfPtr, index);
            return (JoystickType)ret;
        }
        
        /// <summary>
        /// 軸の状態をインデックスで取得します。
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
        /// 軸の状態を軸の種類で取得します。
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
        /// ジョイスティックの名前を取得します。
        /// </summary>
        /// <param name="index">名前を検索するジョイスティックのインデックス</param>
        /// <returns>指定したインデックスのジョイスティックの名前</returns>
        public string GetJoystickName(int index)
        {
            var ret = cbg_Joystick_GetJoystickName(selfPtr, index);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// 振動の状態をリセットします。
        /// </summary>
        public void RefreshVibrateState()
        {
            cbg_Joystick_RefreshVibrateState(selfPtr);
        }
        
        /// <summary>
        /// 振動を設定します。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();
        
        internal static  Graphics TryGetFromCache(IntPtr native)
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
        private static extern IntPtr cbg_Graphics_GetBuildinShader(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Graphics(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// コマンドリストを取得します。
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
        /// ビルド済みシェーダを取得します。
        /// </summary>
        public BuildinShader BuildinShader
        {
            get
            {
                var ret = cbg_Graphics_GetBuildinShader(selfPtr);
                return BuildinShader.TryGetFromCache(ret);
            }
        }
        
        /// <summary>
        /// インスタンスを取得します。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new Dictionary<IntPtr, WeakReference<Texture2D>>();
        
        internal static  Texture2D TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal Texture2D(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// テクスチャの大きさ(ピクセル)を取得します。
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
        /// 再読み込みを行います。
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
    /// マテリアル
    /// </summary>
    public partial class Material
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Material>> cacheRepo = new Dictionary<IntPtr, WeakReference<Material>>();
        
        internal static  Material TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Material cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Material_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Material(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Material>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Material_Constructor_0();
        
        [DllImport("Altseed_Core")]
        private static extern Vector4F cbg_Material_GetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, ref Vector4F value);
        
        [DllImport("Altseed_Core")]
        private static extern Matrix44F cbg_Material_GetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, ref Matrix44F value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Material_GetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, IntPtr value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Material_GetShader(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetShader(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Material(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Shader Shader
        {
            get
            {
                if (_Shader != null)
                {
                    return _Shader;
                }
                var ret = cbg_Material_GetShader(selfPtr);
                return Shader.TryGetFromCache(ret);
            }
            set
            {
                _Shader = value;
                cbg_Material_SetShader(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Shader _Shader;
        
        /// <summary>
        /// 
        /// </summary>
        public Material()
        {
            selfPtr = cbg_Material_Constructor_0();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public Vector4F GetVector4F(string key)
        {
            var ret = cbg_Material_GetVector4F(selfPtr, key);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetVector4F(string key, ref Vector4F value)
        {
            cbg_Material_SetVector4F(selfPtr, key, ref value);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public Matrix44F GetMatrix44F(string key)
        {
            var ret = cbg_Material_GetMatrix44F(selfPtr, key);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetMatrix44F(string key, ref Matrix44F value)
        {
            cbg_Material_SetMatrix44F(selfPtr, key, ref value);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public Texture2D GetTexture(string key)
        {
            var ret = cbg_Material_GetTexture(selfPtr, key);
            return Texture2D.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetTexture(string key, Texture2D value)
        {
            cbg_Material_SetTexture(selfPtr, key, value != null ? value.selfPtr : IntPtr.Zero);
        }
        
        ~Material()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Material_Release(selfPtr);
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Renderer>> cacheRepo = new Dictionary<IntPtr, WeakReference<Renderer>>();
        
        internal static  Renderer TryGetFromCache(IntPtr native)
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
        private static extern void cbg_Renderer_DrawSprite(IntPtr selfPtr, IntPtr sprite);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Render(IntPtr selfPtr, IntPtr commandList);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_DrawPolygon(IntPtr selfPtr, IntPtr vertexBuffer, IntPtr indexBuffer, IntPtr texture, IntPtr material);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Renderer(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Renderer GetInstance()
        {
            var ret = cbg_Renderer_GetInstance();
            return Renderer.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// スプライトを描画します。
        /// </summary>
        public void DrawSprite(RenderedSprite sprite)
        {
            cbg_Renderer_DrawSprite(selfPtr, sprite != null ? sprite.selfPtr : IntPtr.Zero);
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
        /// ポリゴンを描画します
        /// </summary>
        /// <param name="vertexBuffer">頂点バッファ</param>
        /// <param name="indexBuffer"></param>
        /// <param name="texture">テクスチャ</param>
        /// <param name="material">マテリアル</param>
        public void DrawPolygon(VertexArray vertexBuffer, Int32Array indexBuffer, Texture2D texture, Material material)
        {
            cbg_Renderer_DrawPolygon(selfPtr, vertexBuffer != null ? vertexBuffer.selfPtr : IntPtr.Zero, indexBuffer != null ? indexBuffer.selfPtr : IntPtr.Zero, texture != null ? texture.selfPtr : IntPtr.Zero, material != null ? material.selfPtr : IntPtr.Zero);
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<CommandList>> cacheRepo = new Dictionary<IntPtr, WeakReference<CommandList>>();
        
        internal static  CommandList TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal CommandList(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
    
    public partial class Rendered
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Rendered>> cacheRepo = new Dictionary<IntPtr, WeakReference<Rendered>>();
        
        internal static  Rendered TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Rendered cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Rendered_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Rendered(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Rendered>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern void cbg_Rendered_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Rendered(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        ~Rendered()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Rendered_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// スプライトのクラス
    /// </summary>
    public partial class RenderedSprite : Rendered
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<RenderedSprite>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedSprite>>();
        
        internal static new RenderedSprite TryGetFromCache(IntPtr native)
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedSprite_Create();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedSprite_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern RectF cbg_RenderedSprite_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetSrc(IntPtr selfPtr, ref RectF value);
        
        
        [DllImport("Altseed_Core")]
        private static extern Matrix44F cbg_RenderedSprite_GetTransform(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetTransform(IntPtr selfPtr, ref Matrix44F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedSprite_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedSprite_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderedSprite(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// テクスチャを取得または設定します。
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
        /// 描画範囲を取得または設定します。
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
        
        /// <summary>
        /// 変換行列を取得または設定します。
        /// </summary>
        public Matrix44F Transform
        {
            get
            {
                if (_Transform != null)
                {
                    return _Transform.Value;
                }
                var ret = cbg_RenderedSprite_GetTransform(selfPtr);
                return ret;
            }
            set
            {
                _Transform = value;
                cbg_RenderedSprite_SetTransform(selfPtr, ref value);
            }
        }
        private Matrix44F? _Transform;
        
        /// <summary>
        /// マテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get
            {
                if (_Material != null)
                {
                    return _Material;
                }
                var ret = cbg_RenderedSprite_GetMaterial(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _Material = value;
                cbg_RenderedSprite_SetMaterial(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _Material;
        
        /// <summary>
        /// スプライトを作成します。
        /// </summary>
        public static RenderedSprite Create()
        {
            var ret = cbg_RenderedSprite_Create();
            return RenderedSprite.TryGetFromCache(ret);
        }
        
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
    /// カメラのクラス
    /// </summary>
    public partial class RenderedCamera : Rendered
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<RenderedCamera>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedCamera>>();
        
        internal static new RenderedCamera TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                RenderedCamera cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderedCamera_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new RenderedCamera(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderedCamera>(newObject);
            return newObject;
        }
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedCamera_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderedCamera(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        ~RenderedCamera()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderedCamera_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// ビルド済みシェーダの取得を行うクラス
    /// </summary>
    public partial class BuildinShader
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<BuildinShader>> cacheRepo = new Dictionary<IntPtr, WeakReference<BuildinShader>>();
        
        internal static  BuildinShader TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                BuildinShader cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_BuildinShader_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new BuildinShader(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<BuildinShader>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_BuildinShader_Create(IntPtr selfPtr, int type);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_BuildinShader_Release(IntPtr selfPtr);
        
        #endregion
        
        internal BuildinShader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// シェーダを取得します。
        /// </summary>
        /// <param name="type">シェーダの種類</param>
        /// <returns>シェーダ</returns>
        public Shader Create(BuildinShaderType type)
        {
            var ret = cbg_BuildinShader_Create(selfPtr, (int)type);
            return Shader.TryGetFromCache(ret);
        }
        
        ~BuildinShader()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_BuildinShader_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Shader
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Shader>> cacheRepo = new Dictionary<IntPtr, WeakReference<Shader>>();
        
        internal static  Shader TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Shader cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Shader_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Shader(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Shader>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern void cbg_Shader_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Shader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        ~Shader()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Shader_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// 文字情報
    /// </summary>
    public partial class Glyph
    {
        #region unmanaged
        
        private static ConcurrentDictionary<IntPtr, WeakReference<Glyph>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Glyph>>();
        
        internal static  Glyph TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Glyph cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Glyph_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new Glyph(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<Glyph>(newObject));
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Glyph_GetTextureSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Glyph_GetTextureIndex(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Glyph_GetPosition(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Glyph_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Glyph_GetOffset(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Glyph_GetGlyphWidth(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Glyph_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Glyph(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 文字テクスチャのサイズを取得する
        /// </summary>
        public Vector2I TextureSize
        {
            get
            {
                var ret = cbg_Glyph_GetTextureSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字テクスチャのインデックスを取得する
        /// </summary>
        public int TextureIndex
        {
            get
            {
                var ret = cbg_Glyph_GetTextureIndex(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字の座標を取得する
        /// </summary>
        public Vector2I Position
        {
            get
            {
                var ret = cbg_Glyph_GetPosition(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字のサイズを取得する
        /// </summary>
        public Vector2I Size
        {
            get
            {
                var ret = cbg_Glyph_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字のオフセットを取得する
        /// </summary>
        public Vector2I Offset
        {
            get
            {
                var ret = cbg_Glyph_GetOffset(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字の幅を取得する
        /// </summary>
        public int GlyphWidth
        {
            get
            {
                var ret = cbg_Glyph_GetGlyphWidth(selfPtr);
                return ret;
            }
        }
        
        ~Glyph()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Glyph_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    /// <summary>
    /// フォント
    /// </summary>
    public partial class Font
    {
        #region unmanaged
        
        private static ConcurrentDictionary<IntPtr, WeakReference<Font>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Font>>();
        
        internal static  Font TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Font cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Font_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new Font(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<Font>(newObject));
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_LoadDynamicFont([MarshalAs(UnmanagedType.LPWStr)] string path, int size, ref Color color);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_LoadStaticFont([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetGlyph(IntPtr selfPtr, int character);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetFontTexture(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetKerning(IntPtr selfPtr, int c1, int c2);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Font_CalcTextureSize(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text, int direction, [MarshalAs(UnmanagedType.Bool)] bool isEnableKerning);
        
        [DllImport("Altseed_Core")]
        private static extern Color cbg_Font_GetColor(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetAscent(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetDescent(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetLineGap(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Font_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Font(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// フォントの色を取得する
        /// </summary>
        public Color Color
        {
            get
            {
                var ret = cbg_Font_GetColor(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// フォントのサイズを取得する
        /// </summary>
        public int Size
        {
            get
            {
                var ret = cbg_Font_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// フォントのベースラインからトップラインまでの距離を取得する
        /// </summary>
        public int Ascent
        {
            get
            {
                var ret = cbg_Font_GetAscent(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// フォントのベースラインからボトムラインまでの距離を取得する
        /// </summary>
        public int Descent
        {
            get
            {
                var ret = cbg_Font_GetDescent(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// フォントの行間の距離を取得する
        /// </summary>
        public int LineGap
        {
            get
            {
                var ret = cbg_Font_GetLineGap(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 動的にフォントを生成します
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <param name="size">フォントのサイズ</param>
        /// <param name="color">フォントの色</param>
        /// <returns>フォント</returns>
        public static Font LoadDynamicFont(string path, int size, ref Color color)
        {
            var ret = cbg_Font_LoadDynamicFont(path, size, ref color);
            return Font.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 静的にフォントを生成します
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <returns>フォント</returns>
        public static Font LoadStaticFont(string path)
        {
            var ret = cbg_Font_LoadStaticFont(path);
            return Font.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 文字情報を取得する
        /// </summary>
        /// <param name="character">文字</param>
        /// <returns>文字</returns>
        public Glyph GetGlyph(int character)
        {
            var ret = cbg_Font_GetGlyph(selfPtr, character);
            return Glyph.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 文字列テクスチャを得る
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>テクスチャ</returns>
        public Texture2D GetFontTexture(int index)
        {
            var ret = cbg_Font_GetFontTexture(selfPtr, index);
            return Texture2D.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// カーニングを得る
        /// </summary>
        /// <param name="c1">文字1</param>
        /// <param name="c2">文字2</param>
        /// <returns>カーニング</returns>
        public int GetKerning(int c1, int c2)
        {
            var ret = cbg_Font_GetKerning(selfPtr, c1, c2);
            return ret;
        }
        
        /// <summary>
        /// テキストを描画したときのサイズを取得します
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="direction">文字列の方向</param>
        /// <param name="isEnableKerning">カーニングの有無</param>
        /// <returns>サイズ</returns>
        public Vector2I CalcTextureSize(string text, WritingDirection direction, bool isEnableKerning)
        {
            var ret = cbg_Font_CalcTextureSize(selfPtr, text, (int)direction, isEnableKerning);
            return ret;
        }
        
        ~Font()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Font_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
    public partial class Tool
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Tool>> cacheRepo = new Dictionary<IntPtr, WeakReference<Tool>>();
        
        internal static  Tool TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Tool cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Tool_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Tool(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Tool>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Tool_GetInstance();
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Begin(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, int flags);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_End(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Dummy(IntPtr selfPtr, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Text(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextUnformatted(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextWrapped(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextColored(IntPtr selfPtr, ref Vector4F color, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextDisabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_BulletText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_LabelText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CollapsingHeader(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNode(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNodeEx(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TreePop(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextItemOpen(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool isOpen, int cond);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Button(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CheckBox(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [Out] out bool isOpen);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_RadioButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool active);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ArrowButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int dir);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InvisibleButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Selectable(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool selected, int flags);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderAngle(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float angle);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, ref Vector2F size, [In, Out] ref int value, int valueMin, int valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, ref Vector2F size, [In, Out] ref float value, float valueMin, float valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_OpenPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupModal(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndPopup(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginChild(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, ref Vector2F size, [MarshalAs(UnmanagedType.Bool)] bool border, int flags);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndChild(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginMenuBar(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndMenuBar(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginMenu(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool enabled);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndMenu(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_MenuItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string shortcut, [MarshalAs(UnmanagedType.Bool)] bool selected, [MarshalAs(UnmanagedType.Bool)] bool enabled);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabBar(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndTabBar(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndTabItem(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Indent(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Unindent(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Separator(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetTooltip(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_BeginTooltip(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_EndTooltip(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_NewLine(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SameLine(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PushTextWrapPos(IntPtr selfPtr, float wrapLocalPosX);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PopTextWrapPos(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextItemWidth(IntPtr selfPtr, float width);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PushItemWidth(IntPtr selfPtr, float width);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PopItemWidth(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PushButtonRepeat(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool repeat);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PopButtonRepeat(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Columns(IntPtr selfPtr, int count, [MarshalAs(UnmanagedType.Bool)] bool border);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_NextColumn(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PushID(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_PopID(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemActive(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemHovered(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetScrollHere(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetScrollHereX(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetScrollHereY(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Tool_GetTextLineHeight(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Tool_GetFontSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Tool_GetWindowSize(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetWindowSize(IntPtr selfPtr, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMousePosValid(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDragging(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDoubleClicked(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Tool_GetMouseDragDelta(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_ResetMouseDragDelta(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextWindowContentSize(IntPtr selfPtr, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextWindowSize(IntPtr selfPtr, ref Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextWindowPos(IntPtr selfPtr, ref Vector2F pos);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Tool(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        internal static Tool GetInstance()
        {
            var ret = cbg_Tool_GetInstance();
            return Tool.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// `End()` を呼び出してください。
        /// </summary>
        public bool Begin(string name, ToolWindow flags)
        {
            var ret = cbg_Tool_Begin(selfPtr, name, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void End()
        {
            cbg_Tool_End(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Dummy(ref Vector2F size)
        {
            cbg_Tool_Dummy(selfPtr, ref size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Text(string text)
        {
            cbg_Tool_Text(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void TextUnformatted(string text)
        {
            cbg_Tool_TextUnformatted(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void TextWrapped(string text)
        {
            cbg_Tool_TextWrapped(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void TextColored(ref Vector4F color, string text)
        {
            cbg_Tool_TextColored(selfPtr, ref color, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void TextDisabled(string text)
        {
            cbg_Tool_TextDisabled(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void BulletText(string text)
        {
            cbg_Tool_BulletText(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void LabelText(string label, string text)
        {
            cbg_Tool_LabelText(selfPtr, label, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool CollapsingHeader(string label, ToolTreeNode flags)
        {
            var ret = cbg_Tool_CollapsingHeader(selfPtr, label, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool TreeNode(string label)
        {
            var ret = cbg_Tool_TreeNode(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool TreeNodeEx(string label, ToolTreeNode flags)
        {
            var ret = cbg_Tool_TreeNodeEx(selfPtr, label, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void TreePop()
        {
            cbg_Tool_TreePop(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextItemOpen(bool isOpen, ToolCond cond)
        {
            cbg_Tool_SetNextItemOpen(selfPtr, isOpen, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool Button(string label, ref Vector2F size)
        {
            var ret = cbg_Tool_Button(selfPtr, label, ref size);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool CheckBox(string label, out bool isOpen)
        {
            var ret = cbg_Tool_CheckBox(selfPtr, label, out isOpen);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool RadioButton(string label, bool active)
        {
            var ret = cbg_Tool_RadioButton(selfPtr, label, active);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ArrowButton(string label, ToolDir dir)
        {
            var ret = cbg_Tool_ArrowButton(selfPtr, label, (int)dir);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool InvisibleButton(string label, ref Vector2F size)
        {
            var ret = cbg_Tool_InvisibleButton(selfPtr, label, ref size);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool Selectable(string label, ref bool selected, ToolSelectable flags)
        {
            var ret = cbg_Tool_Selectable(selfPtr, label, ref selected, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool InputInt(string label, ref int value)
        {
            var ret = cbg_Tool_InputInt(selfPtr, label, ref value);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool InputFloat(string label, ref float value)
        {
            var ret = cbg_Tool_InputFloat(selfPtr, label, ref value);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool SliderInt(string label, ref int value, float speed, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_SliderInt(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool SliderFloat(string label, ref float value, float speed, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_SliderFloat(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool SliderAngle(string label, ref float angle)
        {
            var ret = cbg_Tool_SliderAngle(selfPtr, label, ref angle);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool VSliderInt(string label, ref Vector2F size, ref int value, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_VSliderInt(selfPtr, label, ref size, ref value, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool VSliderFloat(string label, ref Vector2F size, ref float value, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_VSliderFloat(selfPtr, label, ref size, ref value, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool DragInt(string label, ref int value, float speed, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_DragInt(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool DragFloat(string label, ref float value, float speed, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_DragFloat(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void OpenPopup(string label)
        {
            cbg_Tool_OpenPopup(selfPtr, label);
        }
        
        /// <summary>
        /// `EndPopup()` を呼び出してください
        /// </summary>
        public bool BeginPopup(string label)
        {
            var ret = cbg_Tool_BeginPopup(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// `EndPopup()` を呼び出してください
        /// </summary>
        public bool BeginPopupModal(string label)
        {
            var ret = cbg_Tool_BeginPopupModal(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndPopup()
        {
            cbg_Tool_EndPopup(selfPtr);
        }
        
        /// <summary>
        /// `EndChild()` を呼び出してください
        /// </summary>
        public bool BeginChild(string label, ref Vector2F size, bool border, ToolWindow flags)
        {
            var ret = cbg_Tool_BeginChild(selfPtr, label, ref size, border, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndChild()
        {
            cbg_Tool_EndChild(selfPtr);
        }
        
        /// <summary>
        /// `EndMenuBar()` を呼び出してください
        /// </summary>
        public bool BeginMenuBar()
        {
            var ret = cbg_Tool_BeginMenuBar(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndMenuBar()
        {
            cbg_Tool_EndMenuBar(selfPtr);
        }
        
        /// <summary>
        /// `EndMenu()` を呼び出してください
        /// </summary>
        public bool BeginMenu(string label, bool enabled)
        {
            var ret = cbg_Tool_BeginMenu(selfPtr, label, enabled);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndMenu()
        {
            cbg_Tool_EndMenu(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool MenuItem(string label, string shortcut, bool selected, bool enabled)
        {
            var ret = cbg_Tool_MenuItem(selfPtr, label, shortcut, selected, enabled);
            return ret;
        }
        
        /// <summary>
        /// `EndTabBar()` を呼び出してください
        /// </summary>
        public bool BeginTabBar(string label, ToolTabBar flags)
        {
            var ret = cbg_Tool_BeginTabBar(selfPtr, label, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndTabBar()
        {
            cbg_Tool_EndTabBar(selfPtr);
        }
        
        /// <summary>
        /// `EndTabItem()` を呼び出してください
        /// </summary>
        public bool BeginTabItem(string label)
        {
            var ret = cbg_Tool_BeginTabItem(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndTabItem()
        {
            cbg_Tool_EndTabItem(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Indent()
        {
            cbg_Tool_Indent(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Unindent()
        {
            cbg_Tool_Unindent(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Separator()
        {
            cbg_Tool_Separator(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetTooltip(string text)
        {
            cbg_Tool_SetTooltip(selfPtr, text);
        }
        
        /// <summary>
        /// `EndTooltip()` を呼び出してください
        /// </summary>
        public void BeginTooltip()
        {
            cbg_Tool_BeginTooltip(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndTooltip()
        {
            cbg_Tool_EndTooltip(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void NewLine()
        {
            cbg_Tool_NewLine(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SameLine()
        {
            cbg_Tool_SameLine(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushTextWrapPos(float wrapLocalPosX)
        {
            cbg_Tool_PushTextWrapPos(selfPtr, wrapLocalPosX);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopTextWrapPos()
        {
            cbg_Tool_PopTextWrapPos(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextItemWidth(float width)
        {
            cbg_Tool_SetNextItemWidth(selfPtr, width);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushItemWidth(float width)
        {
            cbg_Tool_PushItemWidth(selfPtr, width);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopItemWidth()
        {
            cbg_Tool_PopItemWidth(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushButtonRepeat(bool repeat)
        {
            cbg_Tool_PushButtonRepeat(selfPtr, repeat);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopButtonRepeat()
        {
            cbg_Tool_PopButtonRepeat(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Columns(int count, bool border)
        {
            cbg_Tool_Columns(selfPtr, count, border);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void NextColumn()
        {
            cbg_Tool_NextColumn(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushID(int id)
        {
            cbg_Tool_PushID(selfPtr, id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopID()
        {
            cbg_Tool_PopID(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemActive()
        {
            var ret = cbg_Tool_IsItemActive(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemHovered()
        {
            var ret = cbg_Tool_IsItemHovered(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollHere()
        {
            cbg_Tool_SetScrollHere(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollHereX()
        {
            cbg_Tool_SetScrollHereX(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollHereY()
        {
            cbg_Tool_SetScrollHereY(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetTextLineHeight()
        {
            var ret = cbg_Tool_GetTextLineHeight(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetFontSize()
        {
            var ret = cbg_Tool_GetFontSize(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetWindowSize()
        {
            var ret = cbg_Tool_GetWindowSize(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowSize(ref Vector2F size)
        {
            cbg_Tool_SetWindowSize(selfPtr, ref size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsMousePosValid()
        {
            var ret = cbg_Tool_IsMousePosValid(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsMouseDragging()
        {
            var ret = cbg_Tool_IsMouseDragging(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsMouseDoubleClicked(int button)
        {
            var ret = cbg_Tool_IsMouseDoubleClicked(selfPtr, button);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetMouseDragDelta(int button)
        {
            var ret = cbg_Tool_GetMouseDragDelta(selfPtr, button);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void ResetMouseDragDelta(int button)
        {
            cbg_Tool_ResetMouseDragDelta(selfPtr, button);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowContentSize(ref Vector2F size)
        {
            cbg_Tool_SetNextWindowContentSize(selfPtr, ref size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowSize(ref Vector2F size)
        {
            cbg_Tool_SetNextWindowSize(selfPtr, ref size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowPos(ref Vector2F pos)
        {
            cbg_Tool_SetNextWindowPos(selfPtr, ref pos);
        }
        
        ~Tool()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Tool_Release(selfPtr);
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
        #region unmanaged
        
        private static ConcurrentDictionary<IntPtr, WeakReference<StreamFile>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<StreamFile>>();
        
        internal static  StreamFile TryGetFromCache(IntPtr native)
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
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new StreamFile(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<StreamFile>(newObject));
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StreamFile_Create([MarshalAs(UnmanagedType.LPWStr)] string path);
        
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
        
        #endregion
        
        internal StreamFile(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 読み込むファイルのデータサイズを取得します。
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
        /// 現在読み込んでいるファイル上の位置を取得します。
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
        /// 現在読み込んでいるファイルのデータサイズを取得します。
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
        /// 読み込むファイルがファイルパッケージ内に格納されているかどうかを取得します。
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
        /// 指定ファイルを読み込むStreamFileの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>pathで読み込むファイルを格納するStreamFileの新しいインスタンスを生成します。</returns>
        public static StreamFile Create(string path)
        {
            var ret = cbg_StreamFile_Create(path);
            return StreamFile.TryGetFromCache(ret);
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
        /// 現在読み込んでいるファイルのデータを取得します。
        /// </summary>
        /// <returns>現在読み込んでいるファイルのデータ</returns>
        internal Int8Array GetTempBuffer()
        {
            var ret = cbg_StreamFile_GetTempBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 再読み込みを行います。
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
        #region unmanaged
        
        private static ConcurrentDictionary<IntPtr, WeakReference<StaticFile>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<StaticFile>>();
        
        internal static  StaticFile TryGetFromCache(IntPtr native)
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
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new StaticFile(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<StaticFile>(newObject));
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_StaticFile_Create([MarshalAs(UnmanagedType.LPWStr)] string path);
        
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
        
        #endregion
        
        internal StaticFile(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 読み込んだファイルのパスを取得します。
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
        /// 読み込んだファイルのデータサイズを取得します。
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
        /// 読み込んだファイルがファイルパッケージ内に格納されているかどうかを取得します。
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
        /// 指定ファイルを読み込んだStaticFileの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>pathで読み込んだファイルを格納するStaticFileの新しいインスタンスを生成します。</returns>
        public static StaticFile Create(string path)
        {
            var ret = cbg_StaticFile_Create(path);
            return StaticFile.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 読み込んだファイルのデータを取得します。
        /// </summary>
        /// <returns>読み込んだファイルのデータ</returns>
        internal Int8Array GetBuffer()
        {
            var ret = cbg_StaticFile_GetBuffer(selfPtr);
            return Int8Array.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 再読み込みを行います。
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<File>> cacheRepo = new Dictionary<IntPtr, WeakReference<File>>();
        
        internal static  File TryGetFromCache(IntPtr native)
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
        
        #endregion
        
        internal File(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static File GetInstance()
        {
            var ret = cbg_File_GetInstance();
            return File.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// ファイル読み込み時に自動的に保管されるディレクトリを追加します。
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
        /// 追加されたディレクトリやファイルパッケージをすべて削除します。
        /// </summary>
        public void ClearRootDirectories()
        {
            cbg_File_ClearRootDirectories(selfPtr);
        }
        
        /// <summary>
        /// 指定したファイルが存在するかどうかを検索します。
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
    /// 音声ファイルを読み込みます。
    /// </summary>
    public partial class Sound
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Sound>> cacheRepo = new Dictionary<IntPtr, WeakReference<Sound>>();
        
        internal static  Sound TryGetFromCache(IntPtr native)
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
        private static extern IntPtr cbg_Sound_Load([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool isDecompressed);
        
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
        
        #endregion
        
        internal Sound(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// ループ開始地点(秒)を取得または設定します。
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
        /// ループ終了地点(秒)を取得または設定します。
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
        /// ループするかどうかを取得または設定します。
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
        /// 音源の長さ(秒)を取得します。
        /// </summary>
        public float Length
        {
            get
            {
                var ret = cbg_Sound_GetLength(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isDecompressed"></param>
        /// <returns>読み込んだ音源データ</returns>
        public static Sound Load(string path, bool isDecompressed)
        {
            var ret = cbg_Sound_Load(path, isDecompressed);
            return Sound.TryGetFromCache(ret);
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
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<SoundMixer>> cacheRepo = new Dictionary<IntPtr, WeakReference<SoundMixer>>();
        
        internal static  SoundMixer TryGetFromCache(IntPtr native)
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
        private static extern float cbg_SoundMixer_GetPlaybackPosition(IntPtr selfPtr, int id);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_SetPlaybackPosition(IntPtr selfPtr, int id, float position);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_GetSpectrumData(IntPtr selfPtr, int id, IntPtr spectrums, int window);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_SoundMixer_Release(IntPtr selfPtr);
        
        #endregion
        
        internal SoundMixer(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        internal static SoundMixer GetInstance()
        {
            var ret = cbg_SoundMixer_GetInstance();
            return SoundMixer.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 音を再生します。
        /// </summary>
        /// <param name="sound">音源データ</param>
        /// <returns>再生中の音のID</returns>
        public int Play(Sound sound)
        {
            var ret = cbg_SoundMixer_Play(selfPtr, sound != null ? sound.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 指定した音が再生中であるかを取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>IDに対応する音が再生中であるか?</returns>
        public bool GetIsPlaying(int id)
        {
            var ret = cbg_SoundMixer_GetIsPlaying(selfPtr, id);
            return ret;
        }
        
        /// <summary>
        /// 再生中の音を全て停止します。
        /// </summary>
        public void StopAll()
        {
            cbg_SoundMixer_StopAll(selfPtr);
        }
        
        /// <summary>
        /// 指定した音の再生を停止します。
        /// </summary>
        /// <param name="id">音のID</param>
        public void Stop(int id)
        {
            cbg_SoundMixer_Stop(selfPtr, id);
        }
        
        /// <summary>
        /// 指定した音の再生を一時停止します。
        /// </summary>
        /// <param name="id">音のID</param>
        public void Pause(int id)
        {
            cbg_SoundMixer_Pause(selfPtr, id);
        }
        
        /// <summary>
        /// 指定した音の再生を再開します。
        /// </summary>
        /// <param name="id">音のID</param>
        public void Resume(int id)
        {
            cbg_SoundMixer_Resume(selfPtr, id);
        }
        
        /// <summary>
        /// 指定した音の音量を変更します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="volume">音量(0.0〜1.0</param>
        public void SetVolume(int id, float volume)
        {
            cbg_SoundMixer_SetVolume(selfPtr, id, volume);
        }
        
        /// <summary>
        /// 指定した音をフェードインさせる
        /// </summary>
        /// <param name="id"></param>
        /// <param name="second">フェードインに使用する時間(秒)</param>
        public void FadeIn(int id, float second)
        {
            cbg_SoundMixer_FadeIn(selfPtr, id, second);
        }
        
        /// <summary>
        /// 指定した音をフェードアウトさせる
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="second">フェードアウトに使用する時間(秒)</param>
        public void FadeOut(int id, float second)
        {
            cbg_SoundMixer_FadeOut(selfPtr, id, second);
        }
        
        /// <summary>
        /// 指定した音の音量を一定時間かけて変更します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="second">フェードに使用する時間(秒)</param>
        /// <param name="targetedVolume">変更後の音量(0.0〜1.0)</param>
        public void Fade(int id, float second, float targetedVolume)
        {
            cbg_SoundMixer_Fade(selfPtr, id, second, targetedVolume);
        }
        
        /// <summary>
        /// 再生速度を変更するかを取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>再生速度を変更するか?</returns>
        public bool GetIsPlaybackSpeedEnabled(int id)
        {
            var ret = cbg_SoundMixer_GetIsPlaybackSpeedEnabled(selfPtr, id);
            return ret;
        }
        
        /// <summary>
        /// 再生速度を変更するかを設定します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="isPlaybackSpeedEnabled">再生速度を変更するか?</param>
        public void SetIsPlaybackSpeedEnabled(int id, bool isPlaybackSpeedEnabled)
        {
            cbg_SoundMixer_SetIsPlaybackSpeedEnabled(selfPtr, id, isPlaybackSpeedEnabled);
        }
        
        /// <summary>
        /// 再生速度を取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>本来の速度の何倍で再生されているか?</returns>
        public float GetPlaybackSpeed(int id)
        {
            var ret = cbg_SoundMixer_GetPlaybackSpeed(selfPtr, id);
            return ret;
        }
        
        /// <summary>
        /// 再生速度を設定します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="playbackSpeed">変更後の再生速度</param>
        public void SetPlaybackSpeed(int id, float playbackSpeed)
        {
            cbg_SoundMixer_SetPlaybackSpeed(selfPtr, id, playbackSpeed);
        }
        
        /// <summary>
        /// パン位置を取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>パン位置 : 0.0で中央, -1.0で左, 1.0で右</returns>
        public float GetPanningPosition(int id)
        {
            var ret = cbg_SoundMixer_GetPanningPosition(selfPtr, id);
            return ret;
        }
        
        /// <summary>
        /// パン位置を設定します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="panningPosition">パン位置 : 0.0で中央, -1.0で左, 1.0で右</param>
        public void SetPanningPosition(int id, float panningPosition)
        {
            cbg_SoundMixer_SetPanningPosition(selfPtr, id, panningPosition);
        }
        
        /// <summary>
        /// 指定した音の再生位置を取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>現在の再生位置</returns>
        public float GetPlaybackPosition(int id)
        {
            var ret = cbg_SoundMixer_GetPlaybackPosition(selfPtr, id);
            return ret;
        }
        
        /// <summary>
        /// 指定した音の再生位置を変更します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="position">再生位置(秒)</param>
        public void SetPlaybackPosition(int id, float position)
        {
            cbg_SoundMixer_SetPlaybackPosition(selfPtr, id, position);
        }
        
        /// <summary>
        /// 再生中の音のスペクトル情報を取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="spectrums">音のスペクトル情報を格納するための配列</param>
        /// <param name="window">フーリエ変換に用いる窓関数</param>
        internal void GetSpectrumData(int id, FloatArray spectrums, FFTWindow window)
        {
            cbg_SoundMixer_GetSpectrumData(selfPtr, id, spectrums != null ? spectrums.selfPtr : IntPtr.Zero, (int)window);
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
    
    /// <summary>
    /// ログを出力するクラス
    /// </summary>
    public partial class Log
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Log>> cacheRepo = new Dictionary<IntPtr, WeakReference<Log>>();
        
        internal static  Log TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                Log cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Log_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new Log(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Log>(newObject);
            return newObject;
        }
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Log_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Write(IntPtr selfPtr, int category, int level, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Trace(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Debug(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Info(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Warn(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Error(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Critical(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_SetLevel(IntPtr selfPtr, int category, int level);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Log_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Log(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Log GetInstance()
        {
            var ret = cbg_Log_GetInstance();
            return Log.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// ログを出力します。
        /// </summary>
        public void Write(LogCategory category, LogLevel level, string message)
        {
            cbg_Log_Write(selfPtr, (int)category, (int)level, message);
        }
        
        /// <summary>
        /// ログレベルTraceでログを出力します。
        /// </summary>
        public void Trace(LogCategory category, string message)
        {
            cbg_Log_Trace(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルDebugでログを出力します。
        /// </summary>
        public void Debug(LogCategory category, string message)
        {
            cbg_Log_Debug(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルInfoでログを出力します。
        /// </summary>
        public void Info(LogCategory category, string message)
        {
            cbg_Log_Info(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルWarningでログを出力します。
        /// </summary>
        public void Warn(LogCategory category, string message)
        {
            cbg_Log_Warn(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルErrorでログを出力します。
        /// </summary>
        public void Error(LogCategory category, string message)
        {
            cbg_Log_Error(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルCriticalでログを出力します。
        /// </summary>
        public void Critical(LogCategory category, string message)
        {
            cbg_Log_Critical(selfPtr, (int)category, message);
        }
        
        /// <summary>
        /// ログレベルを設定します。
        /// </summary>
        public void SetLevel(LogCategory category, LogLevel level)
        {
            cbg_Log_SetLevel(selfPtr, (int)category, (int)level);
        }
        
        ~Log()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Log_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }
    
}
