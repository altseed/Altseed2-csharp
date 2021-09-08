// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//   このファイルは自動生成されました。
//   このファイルへの変更は消失することがあります。
//
//   THIS FILE IS AUTO GENERATED.
//   YOUR COMMITMENT ON THIS FILE WILL BE WIPED.
//
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Altseed2
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    struct MemoryHandle
    {
        public IntPtr selfPtr;
        public MemoryHandle(IntPtr p)
        {
            this.selfPtr = p;
        }
    }

    /// <summary>
    /// 音のスペクトル解析に使用する窓関数
    /// </summary>
    [Serializable]
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
    [Serializable]
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
    [Serializable]
    public enum LogCategory : int
    {
        Core = 0,
        Graphics = 1,
        Engine = 2,
        User = 3,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ShaderStage : int
    {
        Vertex = 0,
        Pixel = 1,
    }

    /// <summary>
    /// リソースの種類を表します。
    /// </summary>
    [Serializable]
    public enum ResourceType : int
    {
        StaticFile = 0,
        StreamFile = 1,
        Texture2D = 2,
        Font = 3,
        Sound = 4,
        MAX = 5,
    }

    /// <summary>
    /// テクスチャをサンプリングする方法を表します。
    /// </summary>
    [Serializable]
    public enum TextureWrapMode : int
    {
        Clamp = 0,
        Repeat = 1,
    }

    /// <summary>
    /// テクスチャをフィルタリングする方法を表します。
    /// </summary>
    [Serializable]
    public enum TextureFilter : int
    {
        Nearest = 0,
        Linear = 1,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum TextureFormat : int
    {
        R8G8B8A8_UNORM = 0,
        R16G16B16A16_FLOAT = 1,
        R32G32B32A32_FLOAT = 2,
        R8G8B8A8_UNORM_SRGB = 3,
        R16G16_FLOAT = 4,
        R8_UNORM = 5,
        D32 = 12,
        D32S8 = 13,
        D24S8 = 14,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum BlendEquation : int
    {
        Add = 0,
        Sub = 1,
        ReverseSub = 2,
        Min = 3,
        Max = 4,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum BlendFunction : int
    {
        Zero = 0,
        One = 1,
        SrcColor = 2,
        OneMinusSrcColor = 3,
        SrcAlpha = 4,
        OneMinusSrcAlpha = 5,
        DstAlpha = 6,
        OneMinusDstAlpha = 7,
        DstColor = 8,
        OneMinusDstColor = 9,
    }

    /// <summary>
    /// 描画方法を表します。
    /// </summary>
    [Serializable]
    public enum GraphicsDevice : int
    {
        Default = 0,
        DirectX12 = 1,
        Metal = 2,
        Vulkan = 3,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum CoreModules : int
    {
        None = 0,
        Window = 1,
        File = 2,
        Keyboard = 4,
        Mouse = 8,
        Joystick = 16,
        Graphics = 32,
        Tool = 64,
        RequireGraphics = 96,
        RequireWindow = 125,
        Sound = 128,
        Default = 191,
        RequireFile = 226,
    }

    /// <summary>
    /// フレームレートモード
    /// </summary>
    [Serializable]
    public enum FramerateMode : int
    {
        Variable = 0,
        Constant = 1,
    }

    /// <summary>
    /// ビルド済みシェーダの種類を表します
    /// </summary>
    [Serializable]
    public enum BuiltinShaderType : int
    {
        SpriteUnlitVS = 0,
        SpriteUnlitPS = 1,
        FontUnlitPS = 2,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum RenderTargetCareType : int
    {
        DontCare = 0,
        Clear = 1,
    }

    /// <summary>
    /// テキストの描画方向
    /// </summary>
    [Serializable]
    public enum WritingDirection : int
    {
        Vertical = 0,
        Horizontal = 1,
    }

    /// <summary>
    /// ボタンの押下状態を表します。
    /// </summary>
    [Serializable]
    public enum ButtonState : int
    {
        Free = 0,
        Push = 1,
        Release = 2,
        Hold = 3,
    }

    /// <summary>
    /// ジョイスティックの種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickType : int
    {
        Other = 0,
        DualShock3 = 616,
        XBOX360 = 654,
        DualShock4 = 1476,
        DualShock4Slim = 2508,
        JoyconL = 8198,
        JoyconR = 8199,
        ProController = 8201,
    }

    /// <summary>
    /// ジョイスティックのボタンの種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickButton : int
    {
        RightDown = 0,
        RightRight = 1,
        RightLeft = 2,
        RightUp = 3,
        LeftBumper = 4,
        RightBumper = 5,
        Back = 6,
        Start = 7,
        Guide = 8,
        LeftThumb = 9,
        RightThumb = 10,
        DPadUp = 11,
        DPadRight = 12,
        DPadDown = 13,
        DPadLeft = 14,
    }

    /// <summary>
    /// ジョイスティックの軸の種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickAxis : int
    {
        LeftX = 0,
        LeftY = 1,
        RightX = 2,
        RightY = 3,
        LeftTrigger = 4,
        RightTrigger = 5,
    }

    /// <summary>
    /// キーボードのキーの種類を表します。
    /// </summary>
    [Serializable]
    public enum Key : int
    {
        Unknown = 0,
        Space = 1,
        Apostrophe = 2,
        Comma = 3,
        Minus = 4,
        Period = 5,
        Slash = 6,
        Num0 = 7,
        Num1 = 8,
        Num2 = 9,
        Num3 = 10,
        Num4 = 11,
        Num5 = 12,
        Num6 = 13,
        Num7 = 14,
        Num8 = 15,
        Num9 = 16,
        Semicolon = 17,
        Equal = 18,
        A = 19,
        B = 20,
        C = 21,
        D = 22,
        E = 23,
        F = 24,
        G = 25,
        H = 26,
        I = 27,
        J = 28,
        K = 29,
        L = 30,
        M = 31,
        N = 32,
        O = 33,
        P = 34,
        Q = 35,
        R = 36,
        S = 37,
        T = 38,
        U = 39,
        V = 40,
        W = 41,
        X = 42,
        Y = 43,
        Z = 44,
        LeftBracket = 45,
        Backslash = 46,
        RightBracket = 47,
        GraveAccent = 48,
        World1 = 49,
        World2 = 50,
        Escape = 51,
        Enter = 52,
        Tab = 53,
        Backspace = 54,
        Insert = 55,
        Delete = 56,
        Right = 57,
        Left = 58,
        Down = 59,
        Up = 60,
        PageUp = 61,
        PageDown = 62,
        Home = 63,
        End = 64,
        CapsLock = 65,
        ScrollLock = 66,
        NumLock = 67,
        PrintScreen = 68,
        Pause = 69,
        F1 = 70,
        F2 = 71,
        F3 = 72,
        F4 = 73,
        F5 = 74,
        F6 = 75,
        F7 = 76,
        F8 = 77,
        F9 = 78,
        F10 = 79,
        F11 = 80,
        F12 = 81,
        F13 = 82,
        F14 = 83,
        F15 = 84,
        F16 = 85,
        F17 = 86,
        F18 = 87,
        F19 = 88,
        F20 = 89,
        F21 = 90,
        F22 = 91,
        F23 = 92,
        F24 = 93,
        F25 = 94,
        Keypad0 = 95,
        Keypad1 = 96,
        Keypad2 = 97,
        Keypad3 = 98,
        Keypad4 = 99,
        Keypad5 = 100,
        Keypad6 = 101,
        Keypad7 = 102,
        Keypad8 = 103,
        Keypad9 = 104,
        KeypadDecimal = 105,
        KeypadDivide = 106,
        KeypadMultiply = 107,
        KeypadSubstract = 108,
        KeypadAdd = 109,
        KeypadEnter = 110,
        KeypadEqual = 111,
        LeftShift = 112,
        LeftControl = 113,
        LeftAlt = 114,
        LeftWin = 115,
        RightShift = 116,
        RightControl = 117,
        RightAlt = 118,
        RightWin = 119,
        Menu = 120,
        Last = 121,
        MAX = 122,
    }

    /// <summary>
    /// マウスのボタンの種類を表します。
    /// </summary>
    [Serializable]
    public enum MouseButton : int
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
    [Serializable]
    public enum CursorMode : int
    {
        Normal = 212993,
        Hidden = 212994,
        Disable = 212995,
    }

    /// <summary>
    /// ツール機能を使ってフォントを読み込む際の範囲を指定します。ビット演算は行わないでください。
    /// </summary>
    [Serializable]
    public enum ToolGlyphRange : int
    {
        Default = 0,
        Cyrillic = 1,
        Japanese = 2,
        ChineseFull = 3,
        ChineseSimplifiedCommon = 4,
        Korean = 5,
        Thai = 6,
    }

    /// <summary>
    /// ツール機能の使用方法(描画位置)
    /// </summary>
    [Serializable]
    public enum ToolUsage : int
    {
        Overwrapped = 0,
        Main = 1,
    }

    /// <summary>
    /// ツール機能のウィンドウにおける設定を表します
    /// </summary>
    [Serializable]
    public enum ToolWindowFlags : int
    {
        None = 0,
        NoTitleBar = 1,
        NoResize = 2,
        NoMove = 4,
        NoScrollbar = 8,
        NoScrollWithMouse = 16,
        NoCollapse = 32,
        NoDecoration = 43,
        AlwaysAutoResize = 64,
        NoBackground = 128,
        NoSavedSettings = 256,
        NoMouseInputs = 512,
        MenuBar = 1024,
        HorizontalScrollbar = 2048,
        NoFocusOnAppearing = 4096,
        NoBringToFrontOnFocus = 8192,
        AlwaysVerticalScrollbar = 16384,
        AlwaysHorizontalScrollbar = 32768,
        AlwaysUseWindowPadding = 65536,
        NoNavInputs = 262144,
        NoNavFocus = 524288,
        NoNav = 786432,
        NoInputs = 786944,
        UnsavedDocument = 1048576,
        NoDocking = 2097152,
        NavFlattened = 8388608,
        ChildWindow = 16777216,
        Tooltip = 33554432,
        Popup = 67108864,
        Modal = 134217728,
        ChildMenu = 268435456,
        DockNodeHost = 536870912,
    }

    /// <summary>
    /// ツール機能においてインプットされるテキストの設定を表します
    /// </summary>
    [Serializable]
    public enum ToolInputTextFlags : int
    {
        None = 0,
        CharsDecimal = 1,
        CharsHexadecimal = 2,
        CharsUppercase = 4,
        CharsNoBlank = 8,
        AutoSelectAll = 16,
        EnterReturnsTrue = 32,
        CallbackCompletion = 64,
        CallbackHistory = 128,
        CallbackAlways = 256,
        CallbackCharFilter = 512,
        AllowTabInput = 1024,
        CtrlEnterForNewLine = 2048,
        NoHorizontalScroll = 4096,
        AlwaysInsertMode = 8192,
        ReadOnly = 16384,
        Password = 32768,
        NoUndoRedo = 65536,
        CharsScientific = 131072,
        CallbackResize = 262144,
        CallbackEdit = 524288,
        Multiline = 1048576,
        NoMarkEdited = 2097152,
    }

    /// <summary>
    /// ツール機能のTreeNodeに適用する設定を表します。
    /// </summary>
    [Serializable]
    public enum ToolTreeNodeFlags : int
    {
        None = 0,
        Selected = 1,
        Framed = 2,
        AllowItemOverlap = 4,
        NoTreePushOnOpen = 8,
        NoAutoOpenOnLog = 16,
        CollapsingHeader = 26,
        DefaultOpen = 32,
        OpenOnDoubleClick = 64,
        OpenOnArrow = 128,
        Leaf = 256,
        Bullet = 512,
        FramePadding = 1024,
        SpanAvailWidth = 2048,
        SpanFullWidth = 4096,
        NavLeftJumpsBackHere = 8192,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolPopupFlags : int
    {
        None = 0,
        MouseButtonLeft = 0,
        MouseButtonRight = 1,
        MouseButtonMiddle = 2,
        NoOpenOverExistingPopup = 32,
        NoOpenOverItems = 64,
        AnyPopupId = 128,
        AnyPopupLevel = 256,
        AnyPopup = 384,
    }

    /// <summary>
    /// ツール機能のSelectableに適用する設定を表します。
    /// </summary>
    [Serializable]
    public enum ToolSelectableFlags : int
    {
        None = 0,
        DontClosePopups = 1,
        SpanAllColumns = 2,
        AllowDoubleClick = 4,
        Disabled = 8,
        AllowItemOverlap = 16,
    }

    /// <summary>
    /// ツール機能のBeginComboに適用する設定を表します。
    /// </summary>
    [Serializable]
    public enum ToolComboFlags : int
    {
        None = 0,
        PopupAlignLeft = 1,
        HeightSmall = 2,
        HeightRegular = 4,
        HeightLarge = 8,
        HeightLargest = 16,
        NoArrowButton = 32,
        NoPreview = 64,
    }

    /// <summary>
    /// ツール機能のタブバーにおける設定を表します
    /// </summary>
    [Serializable]
    public enum ToolTabBarFlags : int
    {
        None = 0,
        Reorderable = 1,
        AutoSelectNewTabs = 2,
        TabListPopupButton = 4,
        NoCloseWithMiddleMouseButton = 8,
        NoTabListScrollingButtons = 16,
        NoTooltip = 32,
        FittingPolicyResizeDown = 64,
        FittingPolicyScroll = 128,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolTabItemFlags : int
    {
        None = 0,
        UnsavedDocument = 1,
        SetSelected = 2,
        NoCloseWithMiddleMouseButton = 4,
        NoPushId = 8,
        NoTooltip = 16,
        NoReorder = 32,
        Leading = 64,
        Trailing = 128,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolFocusedFlags : int
    {
        None = 0,
        ChildWindows = 1,
        RootWindow = 2,
        RootAndChildWindows = 3,
        AnyWindow = 4,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolHoveredFlags : int
    {
        None = 0,
        ChildWindows = 1,
        RootWindow = 2,
        RootAndChildWindows = 3,
        AnyWindow = 4,
        AllowWhenBlockedByPopup = 8,
        AllowWhenBlockedByActiveItem = 32,
        AllowWhenOverlapped = 64,
        RectOnly = 104,
        AllowWhenDisabled = 128,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolDockNodeFlags : int
    {
        None = 0,
        KeepAliveOnly = 1,
        NoDockingInCentralNode = 4,
        PassthruCentralNode = 8,
        NoSplit = 16,
        NoResize = 32,
        AutoHideTabBar = 64,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolDragDropFlags : int
    {
        None = 0,
        SourceNoPreviewTooltip = 1,
        SourceNoDisableHover = 2,
        SourceNoHoldToOpenOthers = 4,
        SourceAllowNullID = 8,
        SourceExtern = 16,
        SourceAutoExpirePayload = 32,
        AcceptBeforeDelivery = 1024,
        AcceptNoDrawDefaultRect = 2048,
        AcceptPeekOnly = 3072,
        AcceptNoPreviewTooltip = 4096,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolDataType : int
    {
        S8 = 0,
        U8 = 1,
        S16 = 2,
        U16 = 3,
        S32 = 4,
        U32 = 5,
        S64 = 6,
        U64 = 7,
        Float = 8,
        Double = 9,
        COUNT = 10,
    }

    /// <summary>
    /// ツール機能で使用する方向
    /// </summary>
    [Serializable]
    public enum ToolDir : int
    {
        None = -1,
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        COUNT = 5,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolKey : int
    {
        Tab = 0,
        LeftArrow = 1,
        RightArrow = 2,
        UpArrow = 3,
        DownArrow = 4,
        PageUp = 5,
        PageDown = 6,
        Home = 7,
        End = 8,
        Insert = 9,
        Delete = 10,
        Backspace = 11,
        Space = 12,
        Enter = 13,
        Escape = 14,
        KeyPadEnter = 15,
        A = 16,
        C = 17,
        V = 18,
        X = 19,
        Y = 20,
        Z = 21,
        COUNT = 22,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolKeyModFlags : int
    {
        None = 0,
        Ctrl = 1,
        Shift = 2,
        Alt = 4,
        Super = 8,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolNavInput : int
    {
        Activate = 0,
        Cancel = 1,
        Input = 2,
        Menu = 3,
        DpadLeft = 4,
        DpadRight = 5,
        DpadUp = 6,
        DpadDown = 7,
        LStickLeft = 8,
        LStickRight = 9,
        LStickUp = 10,
        LStickDown = 11,
        FocusPrev = 12,
        FocusNext = 13,
        TweakSlow = 14,
        TweakFast = 15,
        COUNT = 16,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolConfigFlags : int
    {
        None = 0,
        NavEnableKeyboard = 1,
        NavEnableGamepad = 2,
        NavEnableSetMousePos = 4,
        NavNoCaptureKeyboard = 8,
        NoMouse = 16,
        NoMouseCursorChange = 32,
        DockingEnable = 64,
        ViewportsEnable = 1024,
        DpiEnableScaleViewports = 16384,
        DpiEnableScaleFonts = 32768,
        IsSRGB = 1048576,
        IsTouchScreen = 2097152,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolBackendFlags : int
    {
        None = 0,
        HasGamepad = 1,
        HasMouseCursors = 2,
        HasSetMousePos = 4,
        RendererHasVtxOffset = 8,
        PlatformHasViewports = 1024,
        HasMouseHoveredViewport = 2048,
        RendererHasViewports = 4096,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolCol : int
    {
        Text = 0,
        TextDisabled = 1,
        WindowBg = 2,
        ChildBg = 3,
        PopupBg = 4,
        Border = 5,
        BorderShadow = 6,
        FrameBg = 7,
        FrameBgHovered = 8,
        FrameBgActive = 9,
        TitleBg = 10,
        TitleBgActive = 11,
        TitleBgCollapsed = 12,
        MenuBarBg = 13,
        ScrollbarBg = 14,
        ScrollbarGrab = 15,
        ScrollbarGrabHovered = 16,
        ScrollbarGrabActive = 17,
        CheckMark = 18,
        SliderGrab = 19,
        SliderGrabActive = 20,
        Button = 21,
        ButtonHovered = 22,
        ButtonActive = 23,
        Header = 24,
        HeaderHovered = 25,
        HeaderActive = 26,
        Separator = 27,
        SeparatorHovered = 28,
        SeparatorActive = 29,
        ResizeGrip = 30,
        ResizeGripHovered = 31,
        ResizeGripActive = 32,
        Tab = 33,
        TabHovered = 34,
        TabActive = 35,
        TabUnfocused = 36,
        TabUnfocusedActive = 37,
        DockingPreview = 38,
        DockingEmptyBg = 39,
        PlotLines = 40,
        PlotLinesHovered = 41,
        PlotHistogram = 42,
        PlotHistogramHovered = 43,
        TextSelectedBg = 44,
        DragDropTarget = 45,
        NavHighlight = 46,
        NavWindowingHighlight = 47,
        NavWindowingDimBg = 48,
        ModalWindowDimBg = 49,
        COUNT = 50,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolStyleVar : int
    {
        Alpha = 0,
        WindowPadding = 1,
        WindowRounding = 2,
        WindowBorderSize = 3,
        WindowMinSize = 4,
        WindowTitleAlign = 5,
        ChildRounding = 6,
        ChildBorderSize = 7,
        PopupRounding = 8,
        PopupBorderSize = 9,
        FramePadding = 10,
        FrameRounding = 11,
        FrameBorderSize = 12,
        ItemSpacing = 13,
        ItemInnerSpacing = 14,
        IndentSpacing = 15,
        ScrollbarSize = 16,
        ScrollbarRounding = 17,
        GrabMinSize = 18,
        GrabRounding = 19,
        TabRounding = 20,
        ButtonTextAlign = 21,
        SelectableTextAlign = 22,
        COUNT = 23,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolButtonFlags : int
    {
        None = 0,
        MouseButtonLeft = 1,
        MouseButtonRight = 2,
        MouseButtonMiddle = 4,
    }

    /// <summary>
    /// ツール機能における色の設定を表します
    /// </summary>
    [Serializable]
    public enum ToolColorEditFlags : int
    {
        None = 0,
        NoAlpha = 2,
        NoPicker = 4,
        NoOptions = 8,
        NoSmallPreview = 16,
        NoInputs = 32,
        NoTooltip = 64,
        NoLabel = 128,
        NoSidePreview = 256,
        NoDragDrop = 512,
        NoBorder = 1024,
        AlphaBar = 65536,
        AlphaPreview = 131072,
        AlphaPreviewHalf = 262144,
        HDR = 524288,
        DisplayRGB = 1048576,
        DisplayHSV = 2097152,
        DisplayHex = 4194304,
        DisplayMask = 7340032,
        Uint8 = 8388608,
        Float = 16777216,
        DataTypeMask = 25165824,
        PickerHueBar = 33554432,
        PickerHueWheel = 67108864,
        PickerMask = 100663296,
        InputRGB = 134217728,
        OptionsDefault = 177209344,
        InputHSV = 268435456,
        InputMask = 402653184,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolSliderFlags : int
    {
        None = 0,
        AlwaysClamp = 16,
        Logarithmic = 32,
        NoRoundToFormat = 64,
        NoInput = 128,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolMouseButton : int
    {
        Left = 0,
        Right = 1,
        Middle = 2,
        COUNT = 5,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolMouseCursor : int
    {
        None = -1,
        Arrow = 0,
        TextInput = 2,
        ResizeAll = 3,
        ResizeNS = 4,
        ResizeEW = 5,
        ResizeNESW = 6,
        ResizeNWSE = 7,
        Hand = 8,
        NotAllowed = 9,
        COUNT = 10,
    }

    /// <summary>
    /// バイナリ演算子を使用して複数の値を結合しないでください
    /// </summary>
    [Serializable]
    public enum ToolCond : int
    {
        None = 0,
        Always = 1,
        Once = 2,
        FirstUseEver = 4,
        Appearing = 8,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolDrawCornerFlags : int
    {
        None = 0,
        TopLeft = 1,
        TopRight = 2,
        Top = 3,
        BotLeft = 4,
        Left = 5,
        BotRight = 8,
        Right = 10,
        Bot = 12,
        All = 15,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolDrawListFlags : int
    {
        None = 0,
        AntiAliasedLines = 1,
        AntiAliasedLinesUseTex = 2,
        AntiAliasedFill = 4,
        AllowVtxOffset = 8,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolFontAtlasFlags : int
    {
        None = 0,
        NoPowerOfTwoHeight = 1,
        NoMouseCursors = 2,
        NoBakedLines = 4,
    }

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public enum ToolViewportFlags : int
    {
        None = 0,
        NoDecoration = 1,
        NoTaskBarIcon = 2,
        NoFocusOnAppearing = 4,
        NoFocusOnClick = 8,
        NoInputs = 16,
        NoRendererClear = 32,
        TopMost = 64,
        Minimized = 128,
        NoAutoMerge = 256,
        CanHostOtherWindows = 512,
    }

    /// <summary>
    /// 8ビット整数の配列のクラスを表します。
    /// </summary>
    [Serializable]
    internal sealed partial class Int8Array : ISerializable, ICacheKeeper<Int8Array>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Int8Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int8Array>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Int8Array TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_Resize(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Int8Array_GetData(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_Assign(IntPtr selfPtr, IntPtr ptr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_CopyTo(IntPtr selfPtr, IntPtr ptr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern byte cbg_Int8Array_GetAt(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_SetAt(IntPtr selfPtr, int index, byte value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Int8Array_Create(int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Int8Array_GetCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int8Array_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        internal void Clear()
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

        internal IntPtr GetData()
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
        internal byte GetAt(int index)
        {
            var ret = cbg_Int8Array_GetAt(selfPtr, index);
            return ret;
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        internal void SetAt(int index, byte value)
        {
            cbg_Int8Array_SetAt(selfPtr, index, value);
        }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        internal static Int8Array Create(int size)
        {
            var ret = cbg_Int8Array_Create(size);
            return Int8Array.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Count = "S_Count";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Int8Array"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Int8Array(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Count, Count);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Int8Array.Count"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Int8Array_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Int8Array>> ICacheKeeper<Int8Array>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Int8Array>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Int8Array>.Release(IntPtr native) => cbg_Int8Array_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Int8Array"/>のインスタンスを削除します。
        /// </summary>
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
    [Serializable]
    internal sealed partial class Int32Array : ISerializable, ICacheKeeper<Int32Array>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Int32Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int32Array>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Int32Array TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_Resize(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Int32Array_GetData(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_Assign(IntPtr selfPtr, IntPtr ptr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_CopyTo(IntPtr selfPtr, IntPtr ptr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Int32Array_GetAt(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_SetAt(IntPtr selfPtr, int index, int value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Int32Array_Create(int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Int32Array_GetCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Int32Array_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        internal void Clear()
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

        internal IntPtr GetData()
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
        internal int GetAt(int index)
        {
            var ret = cbg_Int32Array_GetAt(selfPtr, index);
            return ret;
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        internal void SetAt(int index, int value)
        {
            cbg_Int32Array_SetAt(selfPtr, index, value);
        }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        internal static Int32Array Create(int size)
        {
            var ret = cbg_Int32Array_Create(size);
            return Int32Array.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Count = "S_Count";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Int32Array"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Int32Array(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Count, Count);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Int32Array.Count"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Int32Array_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Int32Array>> ICacheKeeper<Int32Array>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Int32Array>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Int32Array>.Release(IntPtr native) => cbg_Int32Array_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Int32Array"/>のインスタンスを削除します。
        /// </summary>
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
    [Serializable]
    internal sealed partial class VertexArray : ISerializable, ICacheKeeper<VertexArray>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<VertexArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<VertexArray>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  VertexArray TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_Resize(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_VertexArray_GetData(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_CopyTo(IntPtr selfPtr, IntPtr ptr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vertex cbg_VertexArray_GetAt(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_SetAt(IntPtr selfPtr, int index, Vertex value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_VertexArray_Create(int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_VertexArray_GetCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_VertexArray_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        internal void Clear()
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

        internal IntPtr GetData()
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
        internal Vertex GetAt(int index)
        {
            var ret = cbg_VertexArray_GetAt(selfPtr, index);
            return ret;
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        internal void SetAt(int index, Vertex value)
        {
            cbg_VertexArray_SetAt(selfPtr, index, value);
        }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        internal static VertexArray Create(int size)
        {
            var ret = cbg_VertexArray_Create(size);
            return VertexArray.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Count = "S_Count";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="VertexArray"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private VertexArray(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Count, Count);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="VertexArray.Count"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void VertexArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<VertexArray>> ICacheKeeper<VertexArray>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<VertexArray>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<VertexArray>.Release(IntPtr native) => cbg_VertexArray_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="VertexArray"/>のインスタンスを削除します。
        /// </summary>
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
    [Serializable]
    internal sealed partial class FloatArray : ISerializable, ICacheKeeper<FloatArray>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<FloatArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<FloatArray>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  FloatArray TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_Resize(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_FloatArray_GetData(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_CopyTo(IntPtr selfPtr, IntPtr ptr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_FloatArray_GetAt(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_SetAt(IntPtr selfPtr, int index, float value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_FloatArray_Create(int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_FloatArray_GetCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_FloatArray_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        internal void Clear()
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

        internal IntPtr GetData()
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
        internal float GetAt(int index)
        {
            var ret = cbg_FloatArray_GetAt(selfPtr, index);
            return ret;
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        internal void SetAt(int index, float value)
        {
            cbg_FloatArray_SetAt(selfPtr, index, value);
        }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        internal static FloatArray Create(int size)
        {
            var ret = cbg_FloatArray_Create(size);
            return FloatArray.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Count = "S_Count";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="FloatArray"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private FloatArray(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Count, Count);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="FloatArray.Count"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void FloatArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<FloatArray>> ICacheKeeper<FloatArray>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<FloatArray>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<FloatArray>.Release(IntPtr native) => cbg_FloatArray_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="FloatArray"/>のインスタンスを削除します。
        /// </summary>
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
    /// 2次元ベクトルの配列のクラスを表します。
    /// </summary>
    [Serializable]
    internal sealed partial class Vector2FArray : ISerializable, ICacheKeeper<Vector2FArray>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Vector2FArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<Vector2FArray>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Vector2FArray TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                Vector2FArray cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Vector2FArray_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new Vector2FArray(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Vector2FArray>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_Resize(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Vector2FArray_GetData(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_CopyTo(IntPtr selfPtr, IntPtr ptr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Vector2FArray_GetAt(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_SetAt(IntPtr selfPtr, int index, Vector2F value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Vector2FArray_Create(int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Vector2FArray_GetCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Vector2FArray_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Vector2FArray(MemoryHandle handle)
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
                var ret = cbg_Vector2FArray_GetCount(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// データをクリアします。
        /// </summary>
        internal void Clear()
        {
            cbg_Vector2FArray_Clear(selfPtr);
        }

        /// <summary>
        /// サイズを変更します。
        /// </summary>
        /// <param name="size">要素数</param>
        public void Resize(int size)
        {
            cbg_Vector2FArray_Resize(selfPtr, size);
        }

        internal IntPtr GetData()
        {
            var ret = cbg_Vector2FArray_GetData(selfPtr);
            return ret;
        }

        public void Assign(IntPtr ptr, int size)
        {
            cbg_Vector2FArray_Assign(selfPtr, ptr, size);
        }

        /// <summary>
        /// データを指定したポインタにコピーします。
        /// </summary>
        /// <param name="ptr">ポインタ</param>
        public void CopyTo(IntPtr ptr)
        {
            cbg_Vector2FArray_CopyTo(selfPtr, ptr);
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        internal Vector2F GetAt(int index)
        {
            var ret = cbg_Vector2FArray_GetAt(selfPtr, index);
            return ret;
        }

        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        internal void SetAt(int index, Vector2F value)
        {
            cbg_Vector2FArray_SetAt(selfPtr, index, value);
        }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        internal static Vector2FArray Create(int size)
        {
            var ret = cbg_Vector2FArray_Create(size);
            return Vector2FArray.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Count = "S_Count";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Vector2FArray"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Vector2FArray(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Count, Count);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Vector2FArray.Count"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Vector2FArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Vector2FArray>> ICacheKeeper<Vector2FArray>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Vector2FArray>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Vector2FArray>.Release(IntPtr native) => cbg_Vector2FArray_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Vector2FArray"/>のインスタンスを削除します。
        /// </summary>
        ~Vector2FArray()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Vector2FArray_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// ログを出力するクラス
    /// </summary>
    public sealed partial class Log
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Log>> cacheRepo = new Dictionary<IntPtr, WeakReference<Log>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Log TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Log_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Write(IntPtr selfPtr, int category, int level, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Trace(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Debug(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Info(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Warn(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Error(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Critical(IntPtr selfPtr, int category, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_SetLevel(IntPtr selfPtr, int category, int level);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Log_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <see cref="LogLevel.Trace"/>でログを出力します。
        /// </summary>
        public void Trace(LogCategory category, string message)
        {
            cbg_Log_Trace(selfPtr, (int)category, message);
        }

        /// <summary>
        /// <see cref="LogLevel.Debug"/>でログを出力します。
        /// </summary>
        public void Debug(LogCategory category, string message)
        {
            cbg_Log_Debug(selfPtr, (int)category, message);
        }

        /// <summary>
        /// <see cref="LogLevel.Info"/>でログを出力します。
        /// </summary>
        public void Info(LogCategory category, string message)
        {
            cbg_Log_Info(selfPtr, (int)category, message);
        }

        /// <summary>
        /// <see cref="LogLevel.Warn"/>でログを出力します。
        /// </summary>
        public void Warn(LogCategory category, string message)
        {
            cbg_Log_Warn(selfPtr, (int)category, message);
        }

        /// <summary>
        /// <see cref="LogLevel.Error"/>でログを出力します。
        /// </summary>
        public void Error(LogCategory category, string message)
        {
            cbg_Log_Error(selfPtr, (int)category, message);
        }

        /// <summary>
        /// <see cref="LogLevel.Critical"/>でログを出力します。
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

        /// <summary>
        /// <see cref="Log"/>のインスタンスを削除します。
        /// </summary>
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

    /// <summary>
    /// C++のCoreとの仲介を担うクラス
    /// </summary>
    internal sealed partial class Core
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Core>> cacheRepo = new Dictionary<IntPtr, WeakReference<Core>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Core TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_PrintAllBaseObjectName(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_Initialize([MarshalAs(UnmanagedType.LPWStr)] string title, int width, int height, IntPtr config);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_Terminate();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Core_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_DoEvent(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Core_GetBaseObjectCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Core_GetDeltaSecond(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Core_GetCurrentFPS(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Core_GetTargetFPS(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_SetTargetFPS(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Core_GetFramerateMode(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_SetFramerateMode(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Core(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        internal int BaseObjectCount
        {
            get
            {
                var ret = cbg_Core_GetBaseObjectCount(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 前のフレームからの経過時間(秒)を取得します。
        /// </summary>
        internal float DeltaSecond
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
        internal float CurrentFPS
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
        internal int TargetFPS
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
        private int? _TargetFPS;

        /// <summary>
        /// フレームレートモードを取得または設定します。デフォルトでは可変フレームレートです。
        /// </summary>
        internal FramerateMode FramerateMode
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
        /// 全ての内部オブジェクトの名前を出力します。
        /// </summary>
        internal void PrintAllBaseObjectName()
        {
            cbg_Core_PrintAllBaseObjectName(selfPtr);
        }

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        /// <param name="title">ウィンドウの左上に表示されるウィンドウん名</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">初期化時の設定</param>
        internal static bool Initialize(string title, int width, int height, Configuration config)
        {
            var ret = cbg_Core_Initialize(title, width, height, config != null ? config.selfPtr : IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// 終了処理を行います。
        /// </summary>
        internal static void Terminate()
        {
            cbg_Core_Terminate();
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Core GetInstance()
        {
            var ret = cbg_Core_GetInstance();
            return Core.TryGetFromCache(ret);
        }

        /// <summary>
        /// イベントを実行します。
        /// </summary>
        internal bool DoEvent()
        {
            var ret = cbg_Core_DoEvent(selfPtr);
            return ret;
        }

        /// <summary>
        /// <see cref="Core"/>のインスタンスを削除します。
        /// </summary>
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
    ///
    /// </summary>
    internal sealed partial class Window
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Window>> cacheRepo = new Dictionary<IntPtr, WeakReference<Window>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Window TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                Window cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Window_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new Window(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Window>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Window_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Window_DoEvent(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Window_GetTitle(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Window_SetTitle(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_Window_GetSize(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Window_SetSize(IntPtr selfPtr, Vector2I value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Window_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Window(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// ウィンドウに表示するタイトルを取得または設定します
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        internal string Title
        {
            get
            {
                if (_Title != null)
                {
                    return _Title;
                }
                var ret = cbg_Window_GetTitle(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
            set
            {
                _Title = value ?? throw new ArgumentNullException(nameof(value), "設定しようとした値がnullです");
                cbg_Window_SetTitle(selfPtr, value);
            }
        }
        private string _Title;

        /// <summary>
        /// ウィンドウサイズを取得します
        /// </summary>
        internal Vector2I Size
        {
            get
            {
                if (_Size != null)
                {
                    return _Size.Value;
                }
                var ret = cbg_Window_GetSize(selfPtr);
                return ret;
            }
            set
            {
                _Size = value;
                cbg_Window_SetSize(selfPtr, value);
            }
        }
        private Vector2I? _Size;

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Window GetInstance()
        {
            var ret = cbg_Window_GetInstance();
            return Window.TryGetFromCache(ret);
        }

        public bool DoEvent()
        {
            var ret = cbg_Window_DoEvent(selfPtr);
            return ret;
        }

        /// <summary>
        /// <see cref="Window"/>のインスタンスを削除します。
        /// </summary>
        ~Window()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Window_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// シェーダのコンパイル結果を表すクラス
    /// </summary>
    internal sealed partial class ShaderCompileResult
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<ShaderCompileResult>> cacheRepo = new Dictionary<IntPtr, WeakReference<ShaderCompileResult>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  ShaderCompileResult TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                ShaderCompileResult cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_ShaderCompileResult_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new ShaderCompileResult(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<ShaderCompileResult>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ShaderCompileResult_GetValue(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ShaderCompileResult_GetMessage(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ShaderCompileResult_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ShaderCompileResult(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// コンパイルに失敗した場合はnull
        /// </summary>
        internal Shader Value
        {
            get
            {
                var ret = cbg_ShaderCompileResult_GetValue(selfPtr);
                return Shader.TryGetFromCache(ret);
            }
        }

        /// <summary>
        /// コンパイル結果のメッセージ
        /// </summary>
        internal string Message
        {
            get
            {
                var ret = cbg_ShaderCompileResult_GetMessage(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// <see cref="ShaderCompileResult"/>のインスタンスを削除します。
        /// </summary>
        ~ShaderCompileResult()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_ShaderCompileResult_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// シェーダ
    /// </summary>
    [Serializable]
    public sealed partial class Shader : ISerializable, ICacheKeeper<Shader>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Shader>> cacheRepo = new Dictionary<IntPtr, WeakReference<Shader>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Shader TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_Compile([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string code, int shaderStage);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_CompileFromFile([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string path, int shaderStage);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Shader_GetUniformSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_GetCode(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_GetName(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Shader_GetStageType(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Shader_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Shader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public int UniformSize
        {
            get
            {
                var ret = cbg_Shader_GetUniformSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// インスタンス生成に使用したコードを取得します。
        /// </summary>
        public string Code
        {
            get
            {
                var ret = cbg_Shader_GetCode(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// 名前を取得します。
        /// </summary>
        public string Name
        {
            get
            {
                var ret = cbg_Shader_GetName(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// シェーダの種類を取得します。
        /// </summary>
        public ShaderStage StageType
        {
            get
            {
                var ret = cbg_Shader_GetStageType(selfPtr);
                return (ShaderStage)ret;
            }
        }

        /// <summary>
        /// コードをコンパイルしてシェーダを生成します。
        /// </summary>
        /// <param name="name">シェーダの名前</param>
        /// <param name="code">コンパイルするコード</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="code"/>のいずれかがnull</exception>
        internal static ShaderCompileResult Compile(string name, string code, ShaderStage shaderStage)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            if (code == null) throw new ArgumentNullException(nameof(code), "引数がnullです");
            var ret = cbg_Shader_Compile(name, code, (int)shaderStage);
            return ShaderCompileResult.TryGetFromCache(ret);
        }

        /// <summary>
        /// ファイルからコードをコンパイルしてシェーダを生成します。
        /// </summary>
        /// <param name="name">シェーダの名前</param>
        /// <param name="path">コンパイルするコードのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="path"/>のいずれかがnull</exception>
        internal static ShaderCompileResult CompileFromFile(string name, string path, ShaderStage shaderStage)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Shader_CompileFromFile(name, path, (int)shaderStage);
            return ShaderCompileResult.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Code = "S_Code";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Name = "S_Name";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_StageType = "S_StageType";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Shader"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Shader(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Code, Code);
            info.AddValue(S_Name, Name);
            info.AddValue(S_StageType, StageType);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Code"><see cref="Shader.Code"/></param>
        /// <param name="Name"><see cref="Shader.Name"/></param>
        /// <param name="StageType"><see cref="Shader.StageType"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Shader_Unsetter_Deserialize(SerializationInfo info, out string Code, out string Name, out ShaderStage StageType)
        {
            Code = info.GetString(S_Code);
            Name = info.GetString(S_Name);
            StageType = info.GetValue<ShaderStage>(S_StageType);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Shader>> ICacheKeeper<Shader>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Shader>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Shader>.Release(IntPtr native) => cbg_Shader_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Shader"/>のインスタンスを削除します。
        /// </summary>
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
    /// リソースのクラスを表します。
    /// </summary>
    internal sealed partial class Resources
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Resources>> cacheRepo = new Dictionary<IntPtr, WeakReference<Resources>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Resources TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Resources_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Resources_GetResourcesCount(IntPtr selfPtr, int type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Resources_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Resources_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Resources_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Resources(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Resources GetInstance()
        {
            var ret = cbg_Resources_GetInstance();
            return Resources.TryGetFromCache(ret);
        }

        /// <summary>
        /// 指定した種類のリソースの個数を返します。
        /// </summary>
        /// <param name="type">個数を検索するリソースの種類</param>
        internal int GetResourcesCount(ResourceType type)
        {
            var ret = cbg_Resources_GetResourcesCount(selfPtr, (int)type);
            return ret;
        }

        /// <summary>
        /// 登録されたリソースをすべて削除します。
        /// </summary>
        internal void Clear()
        {
            cbg_Resources_Clear(selfPtr);
        }

        /// <summary>
        /// リソースの再読み込みを行います。
        /// </summary>
        internal void Reload()
        {
            cbg_Resources_Reload(selfPtr);
        }

        /// <summary>
        /// <see cref="Resources"/>のインスタンスを削除します。
        /// </summary>
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
    /// テクスチャのベースクラス
    /// </summary>
    [Serializable]
    public partial class TextureBase : ISerializable, ICacheKeeper<TextureBase>, IDeserializationCallback
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<TextureBase>> cacheRepo = new Dictionary<IntPtr, WeakReference<TextureBase>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  TextureBase TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                TextureBase cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_TextureBase_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new TextureBase(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<TextureBase>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_TextureBase_Save(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_TextureBase_GetSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_TextureBase_GetWrapMode(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_TextureBase_SetWrapMode(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_TextureBase_GetFilterType(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_TextureBase_SetFilterType(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_TextureBase_GetFormat(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_TextureBase_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal TextureBase(MemoryHandle handle)
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
                var ret = cbg_TextureBase_GetSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// テクスチャをサンプリングする方法を取得または設定します。
        /// </summary>
        public TextureWrapMode WrapMode
        {
            get
            {
                if (_WrapMode != null)
                {
                    return _WrapMode.Value;
                }
                var ret = cbg_TextureBase_GetWrapMode(selfPtr);
                return (TextureWrapMode)ret;
            }
            set
            {
                _WrapMode = value;
                cbg_TextureBase_SetWrapMode(selfPtr, (int)value);
            }
        }
        private TextureWrapMode? _WrapMode;

        /// <summary>
        /// テクスチャをフィルタリングする方法を取得または設定します。
        /// </summary>
        public TextureFilter FilterType
        {
            get
            {
                if (_FilterType != null)
                {
                    return _FilterType.Value;
                }
                var ret = cbg_TextureBase_GetFilterType(selfPtr);
                return (TextureFilter)ret;
            }
            set
            {
                _FilterType = value;
                cbg_TextureBase_SetFilterType(selfPtr, (int)value);
            }
        }
        private TextureFilter? _FilterType;

        /// <summary>
        /// テクスチャのフォーマットを取得します。
        /// </summary>
        public TextureFormat Format
        {
            get
            {
                var ret = cbg_TextureBase_GetFormat(selfPtr);
                return (TextureFormat)ret;
            }
        }

        /// <summary>
        /// png画像として保存します。
        /// </summary>
        /// <param name="path">保存先</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public bool Save(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_TextureBase_Save(selfPtr, path);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Size = "S_Size";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_WrapMode = "S_WrapMode";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_FilterType = "S_FilterType";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Format = "S_Format";
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="TextureBase"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected TextureBase(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            seInfo = info;

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Size, Size);
            info.AddValue(S_WrapMode, WrapMode);
            info.AddValue(S_FilterType, FilterType);
            info.AddValue(S_Format, Format);

            OnGetObjectData(info, context);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="TextureBase(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>内で呼び出されます。
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private virtual IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Size"><see cref="TextureBase.Size"/></param>
        /// <param name="Format"><see cref="TextureBase.Format"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private void TextureBase_Unsetter_Deserialize(SerializationInfo info, out Vector2I Size, out TextureFormat Format)
        {
            Size = info.GetValue<Vector2I>(S_Size);
            Format = info.GetValue<TextureFormat>(S_Format);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<TextureBase>> ICacheKeeper<TextureBase>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<TextureBase>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<TextureBase>.Release(IntPtr native) => cbg_TextureBase_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返します。</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var ptr = Call_GetPtr(seInfo);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            WrapMode = seInfo.GetValue<TextureWrapMode>(S_WrapMode);
            FilterType = seInfo.GetValue<TextureFilter>(S_FilterType);

            OnDeserialize_Method(sender);

            seInfo = null;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>中で実行されます。
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Method(object sender);

        /// <summary>
        /// <see cref="TextureBase"/>のインスタンスを削除します。
        /// </summary>
        ~TextureBase()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_TextureBase_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    public partial class MaterialPropertyBlock
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<MaterialPropertyBlock>> cacheRepo = new Dictionary<IntPtr, WeakReference<MaterialPropertyBlock>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  MaterialPropertyBlock TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                MaterialPropertyBlock cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_MaterialPropertyBlock_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new MaterialPropertyBlock(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<MaterialPropertyBlock>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector4F cbg_MaterialPropertyBlock_GetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlock_SetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Vector4F value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_MaterialPropertyBlock_GetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlock_SetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Matrix44F value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_MaterialPropertyBlock_GetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlock_SetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, IntPtr value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlock_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal MaterialPropertyBlock(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public Vector4F GetVector4F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlock_GetVector4F(selfPtr, key);
            return ret;
        }

        public void SetVector4F(string key, Vector4F value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_MaterialPropertyBlock_SetVector4F(selfPtr, key, value);
        }

        public Matrix44F GetMatrix44F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlock_GetMatrix44F(selfPtr, key);
            return ret;
        }

        public void SetMatrix44F(string key, Matrix44F value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_MaterialPropertyBlock_SetMatrix44F(selfPtr, key, value);
        }

        public TextureBase GetTexture(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlock_GetTexture(selfPtr, key);
            return TextureBase.TryGetFromCache(ret);
        }

        public void SetTexture(string key, TextureBase value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_MaterialPropertyBlock_SetTexture(selfPtr, key, value != null ? value.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// <see cref="MaterialPropertyBlock"/>のインスタンスを削除します。
        /// </summary>
        ~MaterialPropertyBlock()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_MaterialPropertyBlock_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    public partial class MaterialPropertyBlockCollection
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<MaterialPropertyBlockCollection>> cacheRepo = new Dictionary<IntPtr, WeakReference<MaterialPropertyBlockCollection>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  MaterialPropertyBlockCollection TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                MaterialPropertyBlockCollection cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_MaterialPropertyBlockCollection_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new MaterialPropertyBlockCollection(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<MaterialPropertyBlockCollection>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlockCollection_Add(IntPtr selfPtr, IntPtr block);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlockCollection_Clear(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector4F cbg_MaterialPropertyBlockCollection_GetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_MaterialPropertyBlockCollection_GetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_MaterialPropertyBlockCollection_GetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MaterialPropertyBlockCollection_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal MaterialPropertyBlockCollection(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public void Add(MaterialPropertyBlock block)
        {
            cbg_MaterialPropertyBlockCollection_Add(selfPtr, block != null ? block.selfPtr : IntPtr.Zero);
        }

        public void Clear()
        {
            cbg_MaterialPropertyBlockCollection_Clear(selfPtr);
        }

        public Vector4F GetVector4F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlockCollection_GetVector4F(selfPtr, key);
            return ret;
        }

        public Matrix44F GetMatrix44F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlockCollection_GetMatrix44F(selfPtr, key);
            return ret;
        }

        public TextureBase GetTexture(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_MaterialPropertyBlockCollection_GetTexture(selfPtr, key);
            return TextureBase.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="MaterialPropertyBlockCollection"/>のインスタンスを削除します。
        /// </summary>
        ~MaterialPropertyBlockCollection()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_MaterialPropertyBlockCollection_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// マテリアル
    /// </summary>
    [Serializable]
    public sealed partial class Material : ISerializable, ICacheKeeper<Material>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Material>> cacheRepo = new Dictionary<IntPtr, WeakReference<Material>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Material TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Material_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector4F cbg_Material_GetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Vector4F value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_Material_GetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Matrix44F value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Material_GetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, IntPtr value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Material_GetShader(IntPtr selfPtr, int shaderStage);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetShader(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_Material_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Material_GetPropertyBlock(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Material(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public Shader Shader
        {
            set
            {
                cbg_Material_SetShader(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }

        /// <summary>
        /// 描画時のアルファブレンドを取得または設定します。
        /// </summary>
        public AlphaBlend AlphaBlend
        {
            get
            {
                if (_AlphaBlend != null)
                {
                    return _AlphaBlend.Value;
                }
                var ret = cbg_Material_GetAlphaBlend(selfPtr);
                return ret;
            }
            set
            {
                _AlphaBlend = value;
                cbg_Material_SetAlphaBlend(selfPtr, value);
            }
        }
        private AlphaBlend? _AlphaBlend;

        public MaterialPropertyBlock PropertyBlock
        {
            get
            {
                var ret = cbg_Material_GetPropertyBlock(selfPtr);
                return MaterialPropertyBlock.TryGetFromCache(ret);
            }
        }

        /// <summary>
        /// マテリアルを生成する
        /// </summary>
        public static Material Create()
        {
            var ret = cbg_Material_Create();
            return Material.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Material"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Material(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_AlphaBlend, AlphaBlend);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Material(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Material(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Material>> ICacheKeeper<Material>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Material>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Material>.Release(IntPtr native) => cbg_Material_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Material"/>のインスタンスを削除します。
        /// </summary>
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
    /// テクスチャのクラス
    /// </summary>
    [Serializable]
    public sealed partial class Texture2D : TextureBase, ISerializable, ICacheKeeper<Texture2D>, IDeserializationCallback
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new Dictionary<IntPtr, WeakReference<Texture2D>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new Texture2D TryGetFromCache(IntPtr native)
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

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Texture2D_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Texture2D_Load([MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Texture2D_Create(Vector2I size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Texture2D_GetPath(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Texture2D_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Texture2D(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 読み込んだファイルのパスを取得します。
        /// </summary>
        internal string Path
        {
            get
            {
                var ret = cbg_Texture2D_GetPath(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// 再読み込みを行います。
        /// </summary>
        public bool Reload()
        {
            var ret = cbg_Texture2D_Reload(selfPtr);
            return ret;
        }

        /// <summary>
        /// 指定したファイルからテクスチャを読み込みます。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static Texture2D Load(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Texture2D_Load(path);
            return Texture2D.TryGetFromCache(ret);
        }

        public static Texture2D Create(Vector2I size)
        {
            var ret = cbg_Texture2D_Create(size);
            return Texture2D.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Path = "S_Path";
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Texture2D"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Texture2D(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            seInfo = info;

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_Path, Path);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Texture2D(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>内で呼び出されます。
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Path"><see cref="Texture2D.Path"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Texture2D_Unsetter_Deserialize(SerializationInfo info, out string Path)
        {
            Path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Texture2D>> ICacheKeeper<Texture2D>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Texture2D>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Texture2D>.Release(IntPtr native) => cbg_Texture2D_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返します。</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(seInfo);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            base.OnDeserialization(sender);

            OnDeserialize_Method(sender);

            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>中で実行されます。
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Method(object sender);

        /// <summary>
        /// <see cref="Texture2D"/>のインスタンスを削除します。
        /// </summary>
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
    /// 組み込みシェーダの取得を行うクラス
    /// </summary>
    public sealed partial class BuiltinShader
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<BuiltinShader>> cacheRepo = new Dictionary<IntPtr, WeakReference<BuiltinShader>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  BuiltinShader TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                BuiltinShader cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_BuiltinShader_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new BuiltinShader(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<BuiltinShader>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_Create(IntPtr selfPtr, int type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetDownsampleShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetSepiaShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetGrayScaleShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetGaussianBlurShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetHighLuminanceShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetLightBloomShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_BuiltinShader_GetTextureMixShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_BuiltinShader_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal BuiltinShader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        internal string DownsampleShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetDownsampleShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string SepiaShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetSepiaShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string GrayScaleShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetGrayScaleShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string GaussianBlurShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetGaussianBlurShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string HighLuminanceShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetHighLuminanceShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string LightBloomShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetLightBloomShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        internal string TextureMixShader
        {
            get
            {
                var ret = cbg_BuiltinShader_GetTextureMixShader(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// シェーダを取得します。
        /// </summary>
        /// <param name="type">シェーダの種類</param>
        public Shader Create(BuiltinShaderType type)
        {
            var ret = cbg_BuiltinShader_Create(selfPtr, (int)type);
            return Shader.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="BuiltinShader"/>のインスタンスを削除します。
        /// </summary>
        ~BuiltinShader()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_BuiltinShader_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// コマンドリストのクラス
    /// </summary>
    public sealed partial class CommandList
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CommandList>> cacheRepo = new Dictionary<IntPtr, WeakReference<CommandList>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  CommandList TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CommandList_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_SetRenderTarget(IntPtr selfPtr, IntPtr target, RenderPassParameter renderPassParameter);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_RenderToRenderTexture(IntPtr selfPtr, IntPtr material, IntPtr target, RenderPassParameter renderPassParameter);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_RenderToRenderTarget(IntPtr selfPtr, IntPtr material);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_CopyTexture(IntPtr selfPtr, IntPtr src, IntPtr dst);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_SaveRenderTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, IntPtr texture);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CommandList_GetScreenTexture(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_CommandList_GetScreenTextureFormat(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_SetScreenTextureFormat(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal CommandList(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public RenderTexture ScreenTexture
        {
            get
            {
                var ret = cbg_CommandList_GetScreenTexture(selfPtr);
                return RenderTexture.TryGetFromCache(ret);
            }
        }

        /// <summary>
        /// GetScreenTextureで取得するテクスチャのフォーマットを取得または設定します。
        /// </summary>
        public TextureFormat ScreenTextureFormat
        {
            get
            {
                if (_ScreenTextureFormat != null)
                {
                    return _ScreenTextureFormat.Value;
                }
                var ret = cbg_CommandList_GetScreenTextureFormat(selfPtr);
                return (TextureFormat)ret;
            }
            set
            {
                _ScreenTextureFormat = value;
                cbg_CommandList_SetScreenTextureFormat(selfPtr, (int)value);
            }
        }
        private TextureFormat? _ScreenTextureFormat;

        public static CommandList Create()
        {
            var ret = cbg_CommandList_Create();
            return CommandList.TryGetFromCache(ret);
        }

        /// <summary>
        /// 描画する対象のテクスチャを設定します。
        /// </summary>
        /// <param name="target">描画先のテクスチャ</param>
        /// <param name="renderPassParameter">描画に使用する設定</param>
        public void SetRenderTarget(RenderTexture target, RenderPassParameter renderPassParameter)
        {
            cbg_CommandList_SetRenderTarget(selfPtr, target != null ? target.selfPtr : IntPtr.Zero, renderPassParameter);
        }

        /// <summary>
        /// 指定したテクスチャに描画を行います。
        /// </summary>
        /// <param name="material">描画に使用するマテリアル</param>
        /// <param name="target">描画先のテクスチャ</param>
        public void RenderToRenderTexture(Material material, RenderTexture target, RenderPassParameter renderPassParameter)
        {
            cbg_CommandList_RenderToRenderTexture(selfPtr, material != null ? material.selfPtr : IntPtr.Zero, target != null ? target.selfPtr : IntPtr.Zero, renderPassParameter);
        }

        /// <summary>
        /// 設定されたターゲットに描画を行います。
        /// </summary>
        /// <param name="material">描画に使用するマテリアル</param>
        public void RenderToRenderTarget(Material material)
        {
            cbg_CommandList_RenderToRenderTarget(selfPtr, material != null ? material.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// テクスチャの内容をコピーします。
        /// </summary>
        /// <param name="src">コピーするテクスチャ</param>
        /// <param name="dst">コピー先のテクスチャ</param>
        /// <exception cref="ArgumentNullException"><paramref name="src"/>, <paramref name="dst"/>のいずれかがnull</exception>
        public void CopyTexture(RenderTexture src, RenderTexture dst)
        {
            if (src == null) throw new ArgumentNullException(nameof(src), "引数がnullです");
            if (dst == null) throw new ArgumentNullException(nameof(dst), "引数がnullです");
            cbg_CommandList_CopyTexture(selfPtr, src != null ? src.selfPtr : IntPtr.Zero, dst != null ? dst.selfPtr : IntPtr.Zero);
        }

        public void SaveRenderTexture(string path, RenderTexture texture)
        {
            cbg_CommandList_SaveRenderTexture(selfPtr, path, texture != null ? texture.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// <see cref="CommandList"/>のインスタンスを削除します。
        /// </summary>
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
    /// グラフィックの制御を行うクラス
    /// </summary>
    public sealed partial class Graphics
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Graphics TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Graphics_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_BeginFrame(IntPtr selfPtr, RenderPassParameter renderPassParameter);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_EndFrame(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_DoEvents(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Graphics_Terminate();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Graphics_SaveScreenshot(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Graphics_GetCommandList(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Graphics_GetBuiltinShader(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// 組み込みのシェーダを取得します。
        /// </summary>
        internal BuiltinShader BuiltinShader
        {
            get
            {
                var ret = cbg_Graphics_GetBuiltinShader(selfPtr);
                return BuiltinShader.TryGetFromCache(ret);
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Graphics GetInstance()
        {
            var ret = cbg_Graphics_GetInstance();
            return Graphics.TryGetFromCache(ret);
        }

        /// <summary>
        /// 描画を開始します。
        /// </summary>
        internal bool BeginFrame(RenderPassParameter renderPassParameter)
        {
            var ret = cbg_Graphics_BeginFrame(selfPtr, renderPassParameter);
            return ret;
        }

        /// <summary>
        /// 描画を終了します。
        /// </summary>
        internal bool EndFrame()
        {
            var ret = cbg_Graphics_EndFrame(selfPtr);
            return ret;
        }

        /// <summary>
        /// イベントを処理します。
        /// </summary>
        internal bool DoEvents()
        {
            var ret = cbg_Graphics_DoEvents(selfPtr);
            return ret;
        }

        public static void Terminate()
        {
            cbg_Graphics_Terminate();
        }

        /// <summary>
        /// スクリーンショットを保存します。
        /// </summary>
        /// <param name="path">出力先のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public void SaveScreenshot(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            cbg_Graphics_SaveScreenshot(selfPtr, path);
        }

        /// <summary>
        /// <see cref="Graphics"/>のインスタンスを削除します。
        /// </summary>
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
    /// Altseed2 の設定を表すクラス
    /// </summary>
    [Serializable]
    public sealed partial class Configuration : ISerializable
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Configuration>> cacheRepo = new Dictionary<IntPtr, WeakReference<Configuration>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Configuration TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Configuration_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetIsFullscreen(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetIsFullscreen(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetIsResizable(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetIsResizable(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Configuration_GetDeviceType(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetDeviceType(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetWaitVSync(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetWaitVSync(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Configuration_GetEnabledCoreModules(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetEnabledCoreModules(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetConsoleLoggingEnabled(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetConsoleLoggingEnabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetFileLoggingEnabled(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetFileLoggingEnabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Configuration_GetLogFileName(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetLogFileName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Configuration_GetToolSettingFileName(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_SetToolSettingFileName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Configuration_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Configuration(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 全画面モードかどうかを取得または設定します。
        /// </summary>
        public bool IsFullscreen
        {
            get
            {
                if (_IsFullscreen != null)
                {
                    return _IsFullscreen.Value;
                }
                var ret = cbg_Configuration_GetIsFullscreen(selfPtr);
                return ret;
            }
            set
            {
                _IsFullscreen = value;
                cbg_Configuration_SetIsFullscreen(selfPtr, value);
            }
        }
        private bool? _IsFullscreen;

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
        /// 描画方法を取得または設定します。
        /// </summary>
        public GraphicsDevice DeviceType
        {
            get
            {
                if (_DeviceType != null)
                {
                    return _DeviceType.Value;
                }
                var ret = cbg_Configuration_GetDeviceType(selfPtr);
                return (GraphicsDevice)ret;
            }
            set
            {
                _DeviceType = value;
                cbg_Configuration_SetDeviceType(selfPtr, (int)value);
            }
        }
        private GraphicsDevice? _DeviceType;

        /// <summary>
        /// 垂直同期信号を待つかどうかを取得または設定します。
        /// </summary>
        public bool WaitVSync
        {
            get
            {
                if (_WaitVSync != null)
                {
                    return _WaitVSync.Value;
                }
                var ret = cbg_Configuration_GetWaitVSync(selfPtr);
                return ret;
            }
            set
            {
                _WaitVSync = value;
                cbg_Configuration_SetWaitVSync(selfPtr, value);
            }
        }
        private bool? _WaitVSync;

        /// <summary>
        /// 初期化するモジュールを指定します。
        /// </summary>
        public CoreModules EnabledCoreModules
        {
            get
            {
                if (_EnabledCoreModules != null)
                {
                    return _EnabledCoreModules.Value;
                }
                var ret = cbg_Configuration_GetEnabledCoreModules(selfPtr);
                return (CoreModules)ret;
            }
            set
            {
                _EnabledCoreModules = value;
                cbg_Configuration_SetEnabledCoreModules(selfPtr, (int)value);
            }
        }
        private CoreModules? _EnabledCoreModules;

        /// <summary>
        /// ログをコンソールに出力するかどうかを取得または設定します。
        /// </summary>
        public bool ConsoleLoggingEnabled
        {
            get
            {
                if (_ConsoleLoggingEnabled != null)
                {
                    return _ConsoleLoggingEnabled.Value;
                }
                var ret = cbg_Configuration_GetConsoleLoggingEnabled(selfPtr);
                return ret;
            }
            set
            {
                _ConsoleLoggingEnabled = value;
                cbg_Configuration_SetConsoleLoggingEnabled(selfPtr, value);
            }
        }
        private bool? _ConsoleLoggingEnabled;

        /// <summary>
        /// ログをファイルに出力するかどうかを取得または設定します。
        /// </summary>
        public bool FileLoggingEnabled
        {
            get
            {
                if (_FileLoggingEnabled != null)
                {
                    return _FileLoggingEnabled.Value;
                }
                var ret = cbg_Configuration_GetFileLoggingEnabled(selfPtr);
                return ret;
            }
            set
            {
                _FileLoggingEnabled = value;
                cbg_Configuration_SetFileLoggingEnabled(selfPtr, value);
            }
        }
        private bool? _FileLoggingEnabled;

        /// <summary>
        /// ログファイル名を取得または設定します。
        /// </summary>
        public string LogFileName
        {
            get
            {
                if (_LogFileName != null)
                {
                    return _LogFileName;
                }
                var ret = cbg_Configuration_GetLogFileName(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
            set
            {
                _LogFileName = value;
                cbg_Configuration_SetLogFileName(selfPtr, value);
            }
        }
        private string _LogFileName;

        public string ToolSettingFileName
        {
            get
            {
                if (_ToolSettingFileName != null)
                {
                    return _ToolSettingFileName;
                }
                var ret = cbg_Configuration_GetToolSettingFileName(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
            set
            {
                _ToolSettingFileName = value;
                cbg_Configuration_SetToolSettingFileName(selfPtr, value);
            }
        }
        private string _ToolSettingFileName;


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsFullscreen = "S_IsFullscreen";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsResizable = "S_IsResizable";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_DeviceType = "S_DeviceType";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_WaitVSync = "S_WaitVSync";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_EnabledCoreModules = "S_EnabledCoreModules";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_ConsoleLoggingEnabled = "S_ConsoleLoggingEnabled";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_FileLoggingEnabled = "S_FileLoggingEnabled";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_LogFileName = "S_LogFileName";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_ToolSettingFileName = "S_ToolSettingFileName";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Configuration"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Configuration(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            selfPtr = Call_GetPtr(info);
            if (selfPtr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");

            IsFullscreen = info.GetBoolean(S_IsFullscreen);
            IsResizable = info.GetBoolean(S_IsResizable);
            DeviceType = info.GetValue<GraphicsDevice>(S_DeviceType);
            WaitVSync = info.GetBoolean(S_WaitVSync);
            EnabledCoreModules = info.GetValue<CoreModules>(S_EnabledCoreModules);
            ConsoleLoggingEnabled = info.GetBoolean(S_ConsoleLoggingEnabled);
            FileLoggingEnabled = info.GetBoolean(S_FileLoggingEnabled);
            LogFileName = info.GetString(S_LogFileName);
            ToolSettingFileName = info.GetString(S_ToolSettingFileName);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_IsFullscreen, IsFullscreen);
            info.AddValue(S_IsResizable, IsResizable);
            info.AddValue(S_DeviceType, DeviceType);
            info.AddValue(S_WaitVSync, WaitVSync);
            info.AddValue(S_EnabledCoreModules, EnabledCoreModules);
            info.AddValue(S_ConsoleLoggingEnabled, ConsoleLoggingEnabled);
            info.AddValue(S_FileLoggingEnabled, FileLoggingEnabled);
            info.AddValue(S_LogFileName, LogFileName);
            info.AddValue(S_ToolSettingFileName, ToolSettingFileName);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Configuration(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Configuration(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }


        #endregion

        /// <summary>
        /// <see cref="Configuration"/>のインスタンスを削除します。
        /// </summary>
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
    /// ファイル制御を行うクラス
    /// </summary>
    public sealed partial class File
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<File>> cacheRepo = new Dictionary<IntPtr, WeakReference<File>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  File TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_File_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootDirectory(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootPackageWithPassword(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.LPWStr)] string password);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_AddRootPackage(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_File_ClearRootDirectories(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_Exists(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_Pack(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string srcPath, [MarshalAs(UnmanagedType.LPWStr)] string dstPath);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_File_PackWithPassword(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string srcPath, [MarshalAs(UnmanagedType.LPWStr)] string dstPath, [MarshalAs(UnmanagedType.LPWStr)] string password);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_File_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal File(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static File GetInstance()
        {
            var ret = cbg_File_GetInstance();
            return File.TryGetFromCache(ret);
        }

        /// <summary>
        /// ファイル読み込み時に自動的に保管されるディレクトリを追加します。
        /// </summary>
        /// <param name="path">追加するディレクトリ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public bool AddRootDirectory(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_File_AddRootDirectory(selfPtr, path);
            return ret;
        }

        /// <summary>
        /// ファイルパッケージをパスワード有りで読み込みます。
        /// </summary>
        /// <param name="path">読み込むファイルパッケージのパス</param>
        /// <param name="password">読み込むファイルパッケージのパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>, <paramref name="password"/>のいずれかがnull</exception>
        public bool AddRootPackageWithPassword(string path, string password)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            if (password == null) throw new ArgumentNullException(nameof(password), "引数がnullです");
            var ret = cbg_File_AddRootPackageWithPassword(selfPtr, path, password);
            return ret;
        }

        /// <summary>
        /// ファイルパッケージをパスワード無しで読み込みます。
        /// </summary>
        /// <param name="path">読み込むファイルパッケージのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public bool AddRootPackage(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
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
        public bool Exists(string path)
        {
            var ret = cbg_File_Exists(selfPtr, path);
            return ret;
        }

        /// <summary>
        /// 指定したディレクトリのファイルをパックします。
        /// </summary>
        /// <param name="srcPath">パックするファイルのディレクトリ</param>
        /// <param name="dstPath">パックされたファイル名</param>
        /// <exception cref="ArgumentNullException"><paramref name="srcPath"/>, <paramref name="dstPath"/>のいずれかがnull</exception>
        public bool Pack(string srcPath, string dstPath)
        {
            if (srcPath == null) throw new ArgumentNullException(nameof(srcPath), "引数がnullです");
            if (dstPath == null) throw new ArgumentNullException(nameof(dstPath), "引数がnullです");
            var ret = cbg_File_Pack(selfPtr, srcPath, dstPath);
            return ret;
        }

        /// <summary>
        /// 指定したディレクトリのファイルをパスワード付きでパックします。
        /// </summary>
        /// <param name="srcPath">パックするファイルのディレクトリ</param>
        /// <param name="dstPath">パックされたファイル名</param>
        /// <param name="password">かけるパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="srcPath"/>, <paramref name="dstPath"/>, <paramref name="password"/>のいずれかがnull</exception>
        public bool PackWithPassword(string srcPath, string dstPath, string password)
        {
            if (srcPath == null) throw new ArgumentNullException(nameof(srcPath), "引数がnullです");
            if (dstPath == null) throw new ArgumentNullException(nameof(dstPath), "引数がnullです");
            if (password == null) throw new ArgumentNullException(nameof(password), "引数がnullです");
            var ret = cbg_File_PackWithPassword(selfPtr, srcPath, dstPath, password);
            return ret;
        }

        /// <summary>
        /// <see cref="File"/>のインスタンスを削除します。
        /// </summary>
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
    /// 一度でファイルを読み取るクラス
    /// </summary>
    [Serializable]
    public sealed partial class StaticFile : ISerializable, ICacheKeeper<StaticFile>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<StaticFile>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<StaticFile>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StaticFile_Create([MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StaticFile_GetInt8ArrayBuffer(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StaticFile_GetPath(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_StaticFile_GetSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_GetIsInPackage(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_StaticFile_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal StaticFile(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        internal Int8Array Int8ArrayBuffer
        {
            get
            {
                var ret = cbg_StaticFile_GetInt8ArrayBuffer(selfPtr);
                return Int8Array.TryGetFromCache(ret);
            }
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
        /// 指定ファイルを読み込んだ<see cref="StaticFile"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static StaticFile Create(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_StaticFile_Create(path);
            return StaticFile.TryGetFromCache(ret);
        }

        /// <summary>
        /// 再読み込みを行います。
        /// </summary>
        public bool Reload()
        {
            var ret = cbg_StaticFile_Reload(selfPtr);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Path = "S_Path";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="StaticFile"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private StaticFile(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Path, Path);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="StaticFile(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="StaticFile(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="StaticFile(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Path"><see cref="StaticFile.Path"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void StaticFile_Unsetter_Deserialize(SerializationInfo info, out string Path)
        {
            Path = info.GetString(S_Path);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<StaticFile>> ICacheKeeper<StaticFile>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<StaticFile>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<StaticFile>.Release(IntPtr native) => cbg_StaticFile_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="StaticFile"/>のインスタンスを削除します。
        /// </summary>
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
    /// プロファイラのクラス
    /// </summary>
    public sealed partial class Profiler
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Profiler>> cacheRepo = new Dictionary<IntPtr, WeakReference<Profiler>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Profiler TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                Profiler cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Profiler_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new Profiler(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Profiler>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Profiler_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_BeginBlock(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string _filename, int _line, Color color);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_EndBlock(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_StartCapture(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_StopCapture(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_StartListen(IntPtr selfPtr, int port);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_DumpToFileAndStopCapture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Profiler_GetIsProfilerRunning(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Profiler_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Profiler(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public bool IsProfilerRunning
        {
            get
            {
                var ret = cbg_Profiler_GetIsProfilerRunning(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Profiler GetInstance()
        {
            var ret = cbg_Profiler_GetInstance();
            return Profiler.TryGetFromCache(ret);
        }

        /// <summary>
        /// 測定するブロックを開始します。
        /// </summary>
        /// <param name="name">ブロックの名称</param>
        /// <param name="_filename">ブロックが位置するファイル名</param>
        /// <param name="_line">ブロックが位置する行数</param>
        /// <param name="color">ブロックの色</param>
        public void BeginBlock(string name, string _filename, int _line, Color color)
        {
            cbg_Profiler_BeginBlock(selfPtr, name, _filename, _line, color);
        }

        /// <summary>
        /// 測定するブロックを終了します。
        /// </summary>
        public void EndBlock()
        {
            cbg_Profiler_EndBlock(selfPtr);
        }

        /// <summary>
        /// 測定を開始します。
        /// </summary>
        public void StartCapture()
        {
            cbg_Profiler_StartCapture(selfPtr);
        }

        /// <summary>
        /// 測定を終了します。
        /// </summary>
        public void StopCapture()
        {
            cbg_Profiler_StopCapture(selfPtr);
        }

        /// <summary>
        /// リモートから状態を監視します。
        /// </summary>
        /// <param name="port">通信に使用するポート</param>
        public void StartListen(int port)
        {
            cbg_Profiler_StartListen(selfPtr, port);
        }

        /// <summary>
        /// 測定を終了し、結果を出力します。
        /// </summary>
        /// <param name="path">出力先</param>
        public void DumpToFileAndStopCapture(string path)
        {
            cbg_Profiler_DumpToFileAndStopCapture(selfPtr, path);
        }

        /// <summary>
        /// <see cref="Profiler"/>のインスタンスを削除します。
        /// </summary>
        ~Profiler()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Profiler_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// ポストエフェクトやカメラにおける描画先のクラス
    /// </summary>
    [Serializable]
    public sealed partial class RenderTexture : TextureBase, ISerializable, ICacheKeeper<RenderTexture>, IDeserializationCallback
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderTexture>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderTexture>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new RenderTexture TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                RenderTexture cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderTexture_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new RenderTexture(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderTexture>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderTexture_Create(Vector2I size, int format);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_RenderTexture_Save(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_RenderTexture_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderTexture_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderTexture(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 指定したサイズとフォーマットを持つRenderTextureの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="size">サイズ</param>
        /// <param name="format">テクスチャのフォーマット</param>
        public static RenderTexture Create(Vector2I size, TextureFormat format)
        {
            var ret = cbg_RenderTexture_Create(size, (int)format);
            return RenderTexture.TryGetFromCache(ret);
        }

        public bool Save(string path)
        {
            var ret = cbg_RenderTexture_Save(selfPtr, path);
            return ret;
        }

        public bool Reload()
        {
            var ret = cbg_RenderTexture_Reload(selfPtr);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderTexture"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderTexture(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            seInfo = info;

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);


            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderTexture(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>内で呼び出されます。
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<RenderTexture>> ICacheKeeper<RenderTexture>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderTexture>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderTexture>.Release(IntPtr native) => cbg_RenderTexture_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返します。</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(seInfo);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            base.OnDeserialization(sender);

            OnDeserialize_Method(sender);

            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>中で実行されます。
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Method(object sender);

        /// <summary>
        /// <see cref="RenderTexture"/>のインスタンスを削除します。
        /// </summary>
        ~RenderTexture()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderTexture_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 文字情報
    /// </summary>
    public sealed partial class Glyph
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<Glyph>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Glyph>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_Glyph_GetTextureSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Glyph_GetTextureIndex(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_Glyph_GetPosition(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_Glyph_GetSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Glyph_GetOffset(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Glyph_GetAdvance(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Glyph_GetScale(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Glyph_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Glyph(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 文字テクスチャのサイズを取得します。
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
        /// 文字テクスチャのインデックスを取得します。
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
        /// 文字の座標を取得します。
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
        /// 文字のサイズを取得します。
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
        /// 文字のオフセットを取得します。
        /// </summary>
        public Vector2F Offset
        {
            get
            {
                var ret = cbg_Glyph_GetOffset(selfPtr);
                return ret;
            }
        }

        public float Advance
        {
            get
            {
                var ret = cbg_Glyph_GetAdvance(selfPtr);
                return ret;
            }
        }

        public float Scale
        {
            get
            {
                var ret = cbg_Glyph_GetScale(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// <see cref="Glyph"/>のインスタンスを削除します。
        /// </summary>
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
    [Serializable]
    public sealed partial class Font : ISerializable, ICacheKeeper<Font>, IDeserializationCallback
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<Font>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Font>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_GetGlyph(IntPtr selfPtr, int character);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_GetFontTexture(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetKerning(IntPtr selfPtr, int c1, int c2);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_LoadDynamicFont([MarshalAs(UnmanagedType.LPWStr)] string path, int samplingSize);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_LoadStaticFont([MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_CreateImageFont(IntPtr baseFont);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_GenerateFontFile([MarshalAs(UnmanagedType.LPWStr)] string dynamicFontPath, [MarshalAs(UnmanagedType.LPWStr)] string staticFontPath, int samplingSize, [MarshalAs(UnmanagedType.LPWStr)] string characters);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Font_AddImageGlyph(IntPtr selfPtr, int character, IntPtr texture);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_GetImageGlyph(IntPtr selfPtr, int character);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetSamplingSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Font_GetAscent(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Font_GetDescent(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Font_GetLineGap(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Font_GetEmSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_GetIsStaticFont(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_GetPath(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Font_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Font(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public int SamplingSize
        {
            get
            {
                var ret = cbg_Font_GetSamplingSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// フォントのベースラインからトップラインまでの距離を取得します。
        /// </summary>
        public float Ascent
        {
            get
            {
                var ret = cbg_Font_GetAscent(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// フォントのベースラインからボトムラインまでの距離を取得します。
        /// </summary>
        public float Descent
        {
            get
            {
                var ret = cbg_Font_GetDescent(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// フォントの行間の距離を取得します。
        /// </summary>
        public float LineGap
        {
            get
            {
                var ret = cbg_Font_GetLineGap(selfPtr);
                return ret;
            }
        }

        public float EmSize
        {
            get
            {
                var ret = cbg_Font_GetEmSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// StaticFontかどうかを取得します。
        /// </summary>
        public bool IsStaticFont
        {
            get
            {
                var ret = cbg_Font_GetIsStaticFont(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 読み込んだファイルのパスを取得します。
        /// </summary>
        public string Path
        {
            get
            {
                var ret = cbg_Font_GetPath(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// 文字情報を取得します。
        /// </summary>
        /// <param name="character">文字</param>
        public Glyph GetGlyph(int character)
        {
            var ret = cbg_Font_GetGlyph(selfPtr, character);
            return Glyph.TryGetFromCache(ret);
        }

        /// <summary>
        /// 指定した文字のテクスチャを取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        public Texture2D GetFontTexture(int index)
        {
            var ret = cbg_Font_GetFontTexture(selfPtr, index);
            return Texture2D.TryGetFromCache(ret);
        }

        /// <summary>
        /// カーニングを取得します。
        /// </summary>
        /// <param name="c1">文字1</param>
        /// <param name="c2">文字2</param>
        public int GetKerning(int c1, int c2)
        {
            var ret = cbg_Font_GetKerning(selfPtr, c1, c2);
            return ret;
        }

        /// <summary>
        /// FontGeneratorで生成したフォントを読み込んでFontの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static Font LoadStaticFont(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Font_LoadStaticFont(path);
            return Font.TryGetFromCache(ret);
        }

        /// <summary>
        /// テクスチャ追加対応フォントを生成します。
        /// </summary>
        /// <param name="baseFont">ベースとなるフォント</param>
        /// <exception cref="ArgumentNullException"><paramref name="baseFont"/>がnull</exception>
        public static Font CreateImageFont(Font baseFont)
        {
            if (baseFont == null) throw new ArgumentNullException(nameof(baseFont), "引数がnullです");
            var ret = cbg_Font_CreateImageFont(baseFont != null ? baseFont.selfPtr : IntPtr.Zero);
            return Font.TryGetFromCache(ret);
        }

        /// <summary>
        /// テクスチャ文字を追加します。
        /// </summary>
        /// <param name="character">文字</param>
        /// <param name="texture">テクスチャ</param>
        internal void AddImageGlyph(int character, TextureBase texture)
        {
            cbg_Font_AddImageGlyph(selfPtr, character, texture != null ? texture.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// テクスチャ文字を取得します。
        /// </summary>
        /// <param name="character">文字</param>
        public TextureBase GetImageGlyph(int character)
        {
            var ret = cbg_Font_GetImageGlyph(selfPtr, character);
            return TextureBase.TryGetFromCache(ret);
        }

        public bool Reload()
        {
            var ret = cbg_Font_Reload(selfPtr);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_SamplingSize = "S_SamplingSize";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsStaticFont = "S_IsStaticFont";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Path = "S_Path";
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Font"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Font(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            seInfo = info;

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_SamplingSize, SamplingSize);
            info.AddValue(S_IsStaticFont, IsStaticFont);
            info.AddValue(S_Path, Path);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Font(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>内で呼び出されます。
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="SamplingSize"><see cref="Font.SamplingSize"/></param>
        /// <param name="IsStaticFont"><see cref="Font.IsStaticFont"/></param>
        /// <param name="Path"><see cref="Font.Path"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Font_Unsetter_Deserialize(SerializationInfo info, out int SamplingSize, out bool IsStaticFont, out string Path)
        {
            SamplingSize = info.GetInt32(S_SamplingSize);
            IsStaticFont = info.GetBoolean(S_IsStaticFont);
            Path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Font>> ICacheKeeper<Font>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Font>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Font>.Release(IntPtr native) => cbg_Font_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返します。</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var ptr = Call_GetPtr(seInfo);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);


            OnDeserialize_Method(sender);

            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>中で実行されます。
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Method(object sender);

        /// <summary>
        /// <see cref="Font"/>のインスタンスを削除します。
        /// </summary>
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

    /// <summary>
    ///
    /// </summary>
    public partial class ImageFont
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<ImageFont>> cacheRepo = new Dictionary<IntPtr, WeakReference<ImageFont>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  ImageFont TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                ImageFont cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_ImageFont_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new ImageFont(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<ImageFont>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ImageFont_GetGlyph(IntPtr selfPtr, int character);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ImageFont_GetFontTexture(IntPtr selfPtr, int index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_ImageFont_GetKerning(IntPtr selfPtr, int c1, int c2);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ImageFont_AddImageGlyph(IntPtr selfPtr, int character, IntPtr texture);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ImageFont_GetImageGlyph(IntPtr selfPtr, int character);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_ImageFont_GetSamplingSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_ImageFont_GetAscent(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_ImageFont_GetDescent(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_ImageFont_GetLineGap(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_ImageFont_GetEmSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_ImageFont_GetIsStaticFont(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ImageFont_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ImageFont(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public int SamplingSize
        {
            get
            {
                var ret = cbg_ImageFont_GetSamplingSize(selfPtr);
                return ret;
            }
        }

        public float Ascent
        {
            get
            {
                var ret = cbg_ImageFont_GetAscent(selfPtr);
                return ret;
            }
        }

        public float Descent
        {
            get
            {
                var ret = cbg_ImageFont_GetDescent(selfPtr);
                return ret;
            }
        }

        public float LineGap
        {
            get
            {
                var ret = cbg_ImageFont_GetLineGap(selfPtr);
                return ret;
            }
        }

        public float EmSize
        {
            get
            {
                var ret = cbg_ImageFont_GetEmSize(selfPtr);
                return ret;
            }
        }

        public bool IsStaticFont
        {
            get
            {
                var ret = cbg_ImageFont_GetIsStaticFont(selfPtr);
                return ret;
            }
        }

        public Glyph GetGlyph(int character)
        {
            var ret = cbg_ImageFont_GetGlyph(selfPtr, character);
            return Glyph.TryGetFromCache(ret);
        }

        public Texture2D GetFontTexture(int index)
        {
            var ret = cbg_ImageFont_GetFontTexture(selfPtr, index);
            return Texture2D.TryGetFromCache(ret);
        }

        public int GetKerning(int c1, int c2)
        {
            var ret = cbg_ImageFont_GetKerning(selfPtr, c1, c2);
            return ret;
        }

        public void AddImageGlyph(int character, TextureBase texture)
        {
            cbg_ImageFont_AddImageGlyph(selfPtr, character, texture != null ? texture.selfPtr : IntPtr.Zero);
        }

        public TextureBase GetImageGlyph(int character)
        {
            var ret = cbg_ImageFont_GetImageGlyph(selfPtr, character);
            return TextureBase.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="ImageFont"/>のインスタンスを削除します。
        /// </summary>
        ~ImageFont()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_ImageFont_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// カリングのクラス
    /// </summary>
    internal sealed partial class CullingSystem
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CullingSystem>> cacheRepo = new Dictionary<IntPtr, WeakReference<CullingSystem>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  CullingSystem TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                CullingSystem cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_CullingSystem_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new CullingSystem(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<CullingSystem>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CullingSystem_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_CullingSystem_Initialize();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Terminate();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Register(IntPtr selfPtr, IntPtr rendered);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_UpdateAABB(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Cull(IntPtr selfPtr, RectF rect);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Unregister(IntPtr selfPtr, IntPtr rendered);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_CullingSystem_GetDrawingRenderedCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CullingSystem_GetDrawingRenderedIds(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal CullingSystem(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 描画されているRenderedの個数を取得します。
        /// </summary>
        internal int DrawingRenderedCount
        {
            get
            {
                var ret = cbg_CullingSystem_GetDrawingRenderedCount(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 描画されているRenderedのIdの配列を取得します。
        /// </summary>
        internal Int32Array DrawingRenderedIds
        {
            get
            {
                var ret = cbg_CullingSystem_GetDrawingRenderedIds(selfPtr);
                return Int32Array.TryGetFromCache(ret);
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static CullingSystem GetInstance()
        {
            var ret = cbg_CullingSystem_GetInstance();
            return CullingSystem.TryGetFromCache(ret);
        }

        public static bool Initialize()
        {
            var ret = cbg_CullingSystem_Initialize();
            return ret;
        }

        public static void Terminate()
        {
            cbg_CullingSystem_Terminate();
        }

        /// <summary>
        /// Renderedをカリングシステムに登録します。
        /// </summary>
        /// <param name="rendered">登録するRendered</param>
        internal void Register(Rendered rendered)
        {
            cbg_CullingSystem_Register(selfPtr, rendered != null ? rendered.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// RenderedのAABBを更新します。
        /// </summary>
        internal void UpdateAABB()
        {
            cbg_CullingSystem_UpdateAABB(selfPtr);
        }

        public void Cull(RectF rect)
        {
            cbg_CullingSystem_Cull(selfPtr, rect);
        }

        /// <summary>
        /// Renderedをカリングシステムから登録解除します。
        /// </summary>
        /// <param name="rendered">登録解除するRendered</param>
        internal void Unregister(Rendered rendered)
        {
            cbg_CullingSystem_Unregister(selfPtr, rendered != null ? rendered.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// <see cref="CullingSystem"/>のインスタンスを削除します。
        /// </summary>
        ~CullingSystem()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_CullingSystem_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 描画されるオブジェクトの基本クラスを表します
    /// </summary>
    [Serializable]
    internal partial class Rendered : ISerializable, ICacheKeeper<Rendered>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Rendered>> cacheRepo = new Dictionary<IntPtr, WeakReference<Rendered>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Rendered TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_Rendered_GetTransform(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Rendered_SetTransform(IntPtr selfPtr, Matrix44F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Rendered_GetId(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Rendered_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Rendered(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 変換行列を取得または設定します。
        /// </summary>
        internal Matrix44F Transform
        {
            get
            {
                if (_Transform != null)
                {
                    return _Transform.Value;
                }
                var ret = cbg_Rendered_GetTransform(selfPtr);
                return ret;
            }
            set
            {
                _Transform = value;
                cbg_Rendered_SetTransform(selfPtr, value);
            }
        }
        private Matrix44F? _Transform;

        /// <summary>
        /// BaseObjectのIdを取得します。
        /// </summary>
        internal int Id
        {
            get
            {
                var ret = cbg_Rendered_GetId(selfPtr);
                return ret;
            }
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Transform = "S_Transform";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Rendered"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Rendered(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            Transform = info.GetValue<Matrix44F>(S_Transform);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Transform, Transform);

            OnGetObjectData(info, context);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Rendered(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Rendered(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private virtual IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Rendered>> ICacheKeeper<Rendered>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Rendered>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Rendered>.Release(IntPtr native) => cbg_Rendered_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Rendered"/>のインスタンスを削除します。
        /// </summary>
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
    /// カメラのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedCamera : ISerializable, ICacheKeeper<RenderedCamera>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedCamera>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedCamera>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  RenderedCamera TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedCamera_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedCamera_GetTargetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedCamera_SetTargetTexture(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RenderPassParameter cbg_RenderedCamera_GetRenderPassParameter(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedCamera_SetRenderPassParameter(IntPtr selfPtr, RenderPassParameter value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_RenderedCamera_GetProjectionMatrix(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_RenderedCamera_GetViewMatrix(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedCamera_SetViewMatrix(IntPtr selfPtr, Matrix44F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedCamera_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedCamera(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// TargetTextureを取得または設定します。
        /// </summary>
        internal RenderTexture TargetTexture
        {
            get
            {
                if (_TargetTexture != null)
                {
                    return _TargetTexture;
                }
                var ret = cbg_RenderedCamera_GetTargetTexture(selfPtr);
                return RenderTexture.TryGetFromCache(ret);
            }
            set
            {
                _TargetTexture = value;
                cbg_RenderedCamera_SetTargetTexture(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private RenderTexture _TargetTexture;

        /// <summary>
        /// RenderPassParameterを取得または設定します。
        /// </summary>
        internal RenderPassParameter RenderPassParameter
        {
            get
            {
                if (_RenderPassParameter != null)
                {
                    return _RenderPassParameter.Value;
                }
                var ret = cbg_RenderedCamera_GetRenderPassParameter(selfPtr);
                return ret;
            }
            set
            {
                _RenderPassParameter = value;
                cbg_RenderedCamera_SetRenderPassParameter(selfPtr, value);
            }
        }
        private RenderPassParameter? _RenderPassParameter;

        public Matrix44F ProjectionMatrix
        {
            get
            {
                var ret = cbg_RenderedCamera_GetProjectionMatrix(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// RenderPassParameterを取得または設定します。
        /// </summary>
        internal Matrix44F ViewMatrix
        {
            get
            {
                if (_ViewMatrix != null)
                {
                    return _ViewMatrix.Value;
                }
                var ret = cbg_RenderedCamera_GetViewMatrix(selfPtr);
                return ret;
            }
            set
            {
                _ViewMatrix = value;
                cbg_RenderedCamera_SetViewMatrix(selfPtr, value);
            }
        }
        private Matrix44F? _ViewMatrix;

        /// <summary>
        /// RenderedCameraを作成します。
        /// </summary>
        internal static RenderedCamera Create()
        {
            var ret = cbg_RenderedCamera_Create();
            return RenderedCamera.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_TargetTexture = "S_TargetTexture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_RenderPassParameter = "S_RenderPassParameter";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_ViewMatrix = "S_ViewMatrix";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedCamera"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderedCamera(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            var TargetTexture = info.GetValue<RenderTexture>(S_TargetTexture);
            ((IDeserializationCallback)TargetTexture)?.OnDeserialization(null);
            this.TargetTexture = TargetTexture;
            RenderPassParameter = info.GetValue<RenderPassParameter>(S_RenderPassParameter);
            ViewMatrix = info.GetValue<Matrix44F>(S_ViewMatrix);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_TargetTexture, TargetTexture);
            info.AddValue(S_RenderPassParameter, RenderPassParameter);
            info.AddValue(S_ViewMatrix, ViewMatrix);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedCamera(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedCamera(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<RenderedCamera>> ICacheKeeper<RenderedCamera>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderedCamera>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderedCamera>.Release(IntPtr native) => cbg_RenderedCamera_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="RenderedCamera"/>のインスタンスを削除します。
        /// </summary>
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
    /// スプライトのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedSprite : Rendered, ISerializable, ICacheKeeper<RenderedSprite>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedSprite>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedSprite>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new RenderedSprite TryGetFromCache(IntPtr native)
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

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedSprite_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RectF cbg_RenderedSprite_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetSrc(IntPtr selfPtr, RectF value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Color cbg_RenderedSprite_GetColor(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetColor(IntPtr selfPtr, Color value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetTexture(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetMaterial(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedSprite(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 描画時のアルファブレンドを取得または設定します。
        /// </summary>
        internal AlphaBlend AlphaBlend
        {
            get
            {
                if (_AlphaBlend != null)
                {
                    return _AlphaBlend.Value;
                }
                var ret = cbg_RenderedSprite_GetAlphaBlend(selfPtr);
                return ret;
            }
            set
            {
                _AlphaBlend = value;
                cbg_RenderedSprite_SetAlphaBlend(selfPtr, value);
            }
        }
        private AlphaBlend? _AlphaBlend;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        internal RectF Src
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
                cbg_RenderedSprite_SetSrc(selfPtr, value);
            }
        }
        private RectF? _Src;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        internal Color Color
        {
            get
            {
                if (_Color != null)
                {
                    return _Color.Value;
                }
                var ret = cbg_RenderedSprite_GetColor(selfPtr);
                return ret;
            }
            set
            {
                _Color = value;
                cbg_RenderedSprite_SetColor(selfPtr, value);
            }
        }
        private Color? _Color;

        /// <summary>
        /// テクスチャを取得または設定します。
        /// </summary>
        internal TextureBase Texture
        {
            get
            {
                if (_Texture != null)
                {
                    return _Texture;
                }
                var ret = cbg_RenderedSprite_GetTexture(selfPtr);
                return TextureBase.TryGetFromCache(ret);
            }
            set
            {
                _Texture = value;
                cbg_RenderedSprite_SetTexture(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private TextureBase _Texture;

        /// <summary>
        /// マテリアルを取得または設定します。
        /// </summary>
        internal Material Material
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
        internal static RenderedSprite Create()
        {
            var ret = cbg_RenderedSprite_Create();
            return RenderedSprite.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Src = "S_Src";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Color = "S_Color";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Texture = "S_Texture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Material = "S_Material";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedSprite"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderedSprite(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            Src = info.GetValue<RectF>(S_Src);
            Color = info.GetValue<Color>(S_Color);
            var Texture = info.GetValue<TextureBase>(S_Texture);
            ((IDeserializationCallback)Texture)?.OnDeserialization(null);
            this.Texture = Texture;
            Material = info.GetValue<Material>(S_Material);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_AlphaBlend, AlphaBlend);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Material, Material);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedSprite(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedSprite(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<RenderedSprite>> ICacheKeeper<RenderedSprite>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderedSprite>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderedSprite>.Release(IntPtr native) => cbg_RenderedSprite_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="RenderedSprite"/>のインスタンスを削除します。
        /// </summary>
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
    /// テキストのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedText : Rendered, ISerializable, ICacheKeeper<RenderedText>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedText>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedText>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new RenderedText TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                RenderedText cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderedText_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new RenderedText(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderedText>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedText_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_GetMaterialGlyph(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetMaterialGlyph(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_GetMaterialImage(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetMaterialImage(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Color cbg_RenderedText_GetColor(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetColor(IntPtr selfPtr, Color value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_GetFont(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetFont(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_GetText(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_RenderedText_GetIsEnableKerning(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetIsEnableKerning(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_RenderedText_GetWritingDirection(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetWritingDirection(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_RenderedText_GetCharacterSpace(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetCharacterSpace(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_RenderedText_GetLineGap(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetLineGap(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_RenderedText_GetFontSize(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetFontSize(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_RenderedText_GetRenderingSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedText(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 描画時のアルファブレンドを取得または設定します。
        /// </summary>
        internal AlphaBlend AlphaBlend
        {
            get
            {
                if (_AlphaBlend != null)
                {
                    return _AlphaBlend.Value;
                }
                var ret = cbg_RenderedText_GetAlphaBlend(selfPtr);
                return ret;
            }
            set
            {
                _AlphaBlend = value;
                cbg_RenderedText_SetAlphaBlend(selfPtr, value);
            }
        }
        private AlphaBlend? _AlphaBlend;

        /// <summary>
        /// 文字の描画に使用するマテリアルを取得または設定します。
        /// </summary>
        internal Material MaterialGlyph
        {
            get
            {
                if (_MaterialGlyph != null)
                {
                    return _MaterialGlyph;
                }
                var ret = cbg_RenderedText_GetMaterialGlyph(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _MaterialGlyph = value;
                cbg_RenderedText_SetMaterialGlyph(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _MaterialGlyph;

        /// <summary>
        /// テクスチャ文字の描画に使用するマテリアルを取得または設定します。
        /// </summary>
        internal Material MaterialImage
        {
            get
            {
                if (_MaterialImage != null)
                {
                    return _MaterialImage;
                }
                var ret = cbg_RenderedText_GetMaterialImage(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _MaterialImage = value;
                cbg_RenderedText_SetMaterialImage(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _MaterialImage;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        internal Color Color
        {
            get
            {
                if (_Color != null)
                {
                    return _Color.Value;
                }
                var ret = cbg_RenderedText_GetColor(selfPtr);
                return ret;
            }
            set
            {
                _Color = value;
                cbg_RenderedText_SetColor(selfPtr, value);
            }
        }
        private Color? _Color;

        /// <summary>
        /// フォントを取得または設定します。
        /// </summary>
        internal Font Font
        {
            get
            {
                if (_Font != null)
                {
                    return _Font;
                }
                var ret = cbg_RenderedText_GetFont(selfPtr);
                return Font.TryGetFromCache(ret);
            }
            set
            {
                _Font = value;
                cbg_RenderedText_SetFont(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Font _Font;

        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        internal string Text
        {
            get
            {
                if (_Text != null)
                {
                    return _Text;
                }
                var ret = cbg_RenderedText_GetText(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
            set
            {
                _Text = value;
                cbg_RenderedText_SetText(selfPtr, value);
            }
        }
        private string _Text;

        /// <summary>
        /// カーニングの有無を取得または設定します。
        /// </summary>
        internal bool IsEnableKerning
        {
            get
            {
                if (_IsEnableKerning != null)
                {
                    return _IsEnableKerning.Value;
                }
                var ret = cbg_RenderedText_GetIsEnableKerning(selfPtr);
                return ret;
            }
            set
            {
                _IsEnableKerning = value;
                cbg_RenderedText_SetIsEnableKerning(selfPtr, value);
            }
        }
        private bool? _IsEnableKerning;

        /// <summary>
        /// 行の方向を取得または設定します。
        /// </summary>
        internal WritingDirection WritingDirection
        {
            get
            {
                if (_WritingDirection != null)
                {
                    return _WritingDirection.Value;
                }
                var ret = cbg_RenderedText_GetWritingDirection(selfPtr);
                return (WritingDirection)ret;
            }
            set
            {
                _WritingDirection = value;
                cbg_RenderedText_SetWritingDirection(selfPtr, (int)value);
            }
        }
        private WritingDirection? _WritingDirection;

        /// <summary>
        /// 字間をピクセル単位で取得または設定します。
        /// </summary>
        internal float CharacterSpace
        {
            get
            {
                if (_CharacterSpace != null)
                {
                    return _CharacterSpace.Value;
                }
                var ret = cbg_RenderedText_GetCharacterSpace(selfPtr);
                return ret;
            }
            set
            {
                _CharacterSpace = value;
                cbg_RenderedText_SetCharacterSpace(selfPtr, value);
            }
        }
        private float? _CharacterSpace;

        /// <summary>
        /// 行間をピクセル単位で取得または設定します。
        /// </summary>
        internal float LineGap
        {
            get
            {
                if (_LineGap != null)
                {
                    return _LineGap.Value;
                }
                var ret = cbg_RenderedText_GetLineGap(selfPtr);
                return ret;
            }
            set
            {
                _LineGap = value;
                cbg_RenderedText_SetLineGap(selfPtr, value);
            }
        }
        private float? _LineGap;

        internal float FontSize
        {
            get
            {
                if (_FontSize != null)
                {
                    return _FontSize.Value;
                }
                var ret = cbg_RenderedText_GetFontSize(selfPtr);
                return ret;
            }
            set
            {
                _FontSize = value;
                cbg_RenderedText_SetFontSize(selfPtr, value);
            }
        }
        private float? _FontSize;

        public Vector2F RenderingSize
        {
            get
            {
                var ret = cbg_RenderedText_GetRenderingSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// テキストを作成します。
        /// </summary>
        internal static RenderedText Create()
        {
            var ret = cbg_RenderedText_Create();
            return RenderedText.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_MaterialGlyph = "S_MaterialGlyph";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_MaterialImage = "S_MaterialImage";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Color = "S_Color";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Font = "S_Font";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Text = "S_Text";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsEnableKerning = "S_IsEnableKerning";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_WritingDirection = "S_WritingDirection";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_CharacterSpace = "S_CharacterSpace";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_LineGap = "S_LineGap";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_FontSize = "S_FontSize";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedText"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderedText(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            MaterialGlyph = info.GetValue<Material>(S_MaterialGlyph);
            MaterialImage = info.GetValue<Material>(S_MaterialImage);
            Color = info.GetValue<Color>(S_Color);
            var Font = info.GetValue<Font>(S_Font);
            ((IDeserializationCallback)Font)?.OnDeserialization(null);
            this.Font = Font;
            Text = info.GetString(S_Text);
            IsEnableKerning = info.GetBoolean(S_IsEnableKerning);
            WritingDirection = info.GetValue<WritingDirection>(S_WritingDirection);
            CharacterSpace = info.GetSingle(S_CharacterSpace);
            LineGap = info.GetSingle(S_LineGap);
            FontSize = info.GetSingle(S_FontSize);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_AlphaBlend, AlphaBlend);
            info.AddValue(S_MaterialGlyph, MaterialGlyph);
            info.AddValue(S_MaterialImage, MaterialImage);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Font, Font);
            info.AddValue(S_Text, Text);
            info.AddValue(S_IsEnableKerning, IsEnableKerning);
            info.AddValue(S_WritingDirection, WritingDirection);
            info.AddValue(S_CharacterSpace, CharacterSpace);
            info.AddValue(S_LineGap, LineGap);
            info.AddValue(S_FontSize, FontSize);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedText(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedText(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<RenderedText>> ICacheKeeper<RenderedText>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderedText>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderedText>.Release(IntPtr native) => cbg_RenderedText_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="RenderedText"/>のインスタンスを削除します。
        /// </summary>
        ~RenderedText()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderedText_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// ポリゴンのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedPolygon : Rendered, ISerializable, ICacheKeeper<RenderedPolygon>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedPolygon>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedPolygon>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new RenderedPolygon TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                RenderedPolygon cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderedPolygon_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new RenderedPolygon(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderedPolygon>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_CreateVertexesByVector2F(IntPtr selfPtr, IntPtr vectors);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_OverwriteVertexesColor(IntPtr selfPtr, Color color);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetDefaultIndexBuffer(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedPolygon_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetBuffers(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetBuffers(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetVertexes(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RectF cbg_RenderedPolygon_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetSrc(IntPtr selfPtr, RectF value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetTexture(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetMaterial(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedPolygon(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 描画時のアルファブレンドを取得または設定します。
        /// </summary>
        internal AlphaBlend AlphaBlend
        {
            get
            {
                if (_AlphaBlend != null)
                {
                    return _AlphaBlend.Value;
                }
                var ret = cbg_RenderedPolygon_GetAlphaBlend(selfPtr);
                return ret;
            }
            set
            {
                _AlphaBlend = value;
                cbg_RenderedPolygon_SetAlphaBlend(selfPtr, value);
            }
        }
        private AlphaBlend? _AlphaBlend;

        /// <summary>
        /// 頂点情報を取得または設定します。
        /// </summary>
        internal VertexArray Vertexes
        {
            get
            {
                if (_Vertexes != null)
                {
                    return _Vertexes;
                }
                var ret = cbg_RenderedPolygon_GetVertexes(selfPtr);
                return VertexArray.TryGetFromCache(ret);
            }
            set
            {
                _Vertexes = value;
                cbg_RenderedPolygon_SetVertexes(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private VertexArray _Vertexes;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        internal RectF Src
        {
            get
            {
                if (_Src != null)
                {
                    return _Src.Value;
                }
                var ret = cbg_RenderedPolygon_GetSrc(selfPtr);
                return ret;
            }
            set
            {
                _Src = value;
                cbg_RenderedPolygon_SetSrc(selfPtr, value);
            }
        }
        private RectF? _Src;

        /// <summary>
        /// テクスチャを取得または設定します。
        /// </summary>
        internal TextureBase Texture
        {
            get
            {
                if (_Texture != null)
                {
                    return _Texture;
                }
                var ret = cbg_RenderedPolygon_GetTexture(selfPtr);
                return TextureBase.TryGetFromCache(ret);
            }
            set
            {
                _Texture = value;
                cbg_RenderedPolygon_SetTexture(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private TextureBase _Texture;

        /// <summary>
        /// マテリアルを取得または設定します。
        /// </summary>
        internal Material Material
        {
            get
            {
                if (_Material != null)
                {
                    return _Material;
                }
                var ret = cbg_RenderedPolygon_GetMaterial(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _Material = value;
                cbg_RenderedPolygon_SetMaterial(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _Material;

        /// <summary>
        /// ポリゴンを作成します。
        /// </summary>
        internal static RenderedPolygon Create()
        {
            var ret = cbg_RenderedPolygon_Create();
            return RenderedPolygon.TryGetFromCache(ret);
        }

        /// <summary>
        /// 頂点情報
        /// </summary>
        internal void CreateVertexesByVector2F(Vector2FArray vectors)
        {
            cbg_RenderedPolygon_CreateVertexesByVector2F(selfPtr, vectors != null ? vectors.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// 頂点情報
        /// </summary>
        internal void OverwriteVertexesColor(Color color)
        {
            cbg_RenderedPolygon_OverwriteVertexesColor(selfPtr, color);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Buffers = "S_Buffers";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Vertexes = "S_Vertexes";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Src = "S_Src";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Texture = "S_Texture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Material = "S_Material";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedPolygon"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderedPolygon(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            Buffers = info.GetValue<Int32Array>(S_Buffers);
            Vertexes = info.GetValue<VertexArray>(S_Vertexes);
            Src = info.GetValue<RectF>(S_Src);
            var Texture = info.GetValue<TextureBase>(S_Texture);
            ((IDeserializationCallback)Texture)?.OnDeserialization(null);
            this.Texture = Texture;
            Material = info.GetValue<Material>(S_Material);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_AlphaBlend, AlphaBlend);
            info.AddValue(S_Buffers, Buffers);
            info.AddValue(S_Vertexes, Vertexes);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Material, Material);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedPolygon(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="RenderedPolygon(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<RenderedPolygon>> ICacheKeeper<RenderedPolygon>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderedPolygon>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderedPolygon>.Release(IntPtr native) => cbg_RenderedPolygon_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="RenderedPolygon"/>のインスタンスを削除します。
        /// </summary>
        ~RenderedPolygon()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderedPolygon_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// レンダラのクラス
    /// </summary>
    internal sealed partial class Renderer
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Renderer>> cacheRepo = new Dictionary<IntPtr, WeakReference<Renderer>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Renderer TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Renderer_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Renderer_Initialize(IntPtr window, IntPtr graphics, IntPtr cullingSystem);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_Terminate();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawPolygon(IntPtr selfPtr, IntPtr polygon);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawSprite(IntPtr selfPtr, IntPtr sprite);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawText(IntPtr selfPtr, IntPtr text);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_Render(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_ResetCamera(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_SetCamera(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Renderer(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        internal RenderedCamera Camera
        {
            set
            {
                cbg_Renderer_SetCamera(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Renderer GetInstance()
        {
            var ret = cbg_Renderer_GetInstance();
            return Renderer.TryGetFromCache(ret);
        }

        public static bool Initialize(Window window, Graphics graphics, CullingSystem cullingSystem)
        {
            var ret = cbg_Renderer_Initialize(window != null ? window.selfPtr : IntPtr.Zero, graphics != null ? graphics.selfPtr : IntPtr.Zero, cullingSystem != null ? cullingSystem.selfPtr : IntPtr.Zero);
            return ret;
        }

        public static void Terminate()
        {
            cbg_Renderer_Terminate();
        }

        /// <summary>
        /// ポリゴンを描画します。
        /// </summary>
        /// <param name="polygon">描画する<see cref="RenderedPolygon"/>のインスタンス</param>
        internal void DrawPolygon(RenderedPolygon polygon)
        {
            cbg_Renderer_DrawPolygon(selfPtr, polygon != null ? polygon.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// スプライトを描画します。
        /// </summary>
        /// <param name="sprite">描画する<see cref="RenderedSprite"/>のインスタンス</param>
        internal void DrawSprite(RenderedSprite sprite)
        {
            cbg_Renderer_DrawSprite(selfPtr, sprite != null ? sprite.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// テキストを描画します。
        /// </summary>
        /// <param name="text">描画する<see cref="RenderedText"/>のインスタンス</param>
        internal void DrawText(RenderedText text)
        {
            cbg_Renderer_DrawText(selfPtr, text != null ? text.selfPtr : IntPtr.Zero);
        }

        /// <summary>
        /// コマンドリストを描画します。
        /// </summary>
        internal void Render()
        {
            cbg_Renderer_Render(selfPtr);
        }

        /// <summary>
        /// 使用するカメラの設定をリセットします。
        /// </summary>
        internal void ResetCamera()
        {
            cbg_Renderer_ResetCamera(selfPtr);
        }

        /// <summary>
        /// <see cref="Renderer"/>のインスタンスを削除します。
        /// </summary>
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
    ///
    /// </summary>
    public partial class ShaderCompiler
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<ShaderCompiler>> cacheRepo = new Dictionary<IntPtr, WeakReference<ShaderCompiler>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  ShaderCompiler TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                ShaderCompiler cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_ShaderCompiler_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new ShaderCompiler(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<ShaderCompiler>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ShaderCompiler_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_ShaderCompiler_Initialize(IntPtr graphics, IntPtr file);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ShaderCompiler_Terminate();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ShaderCompiler_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ShaderCompiler(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        public static ShaderCompiler GetInstance()
        {
            var ret = cbg_ShaderCompiler_GetInstance();
            return ShaderCompiler.TryGetFromCache(ret);
        }

        public static bool Initialize(Graphics graphics, File file)
        {
            var ret = cbg_ShaderCompiler_Initialize(graphics != null ? graphics.selfPtr : IntPtr.Zero, file != null ? file.selfPtr : IntPtr.Zero);
            return ret;
        }

        public static void Terminate()
        {
            cbg_ShaderCompiler_Terminate();
        }

        /// <summary>
        /// <see cref="ShaderCompiler"/>のインスタンスを削除します。
        /// </summary>
        ~ShaderCompiler()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_ShaderCompiler_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 段階的にファイルを読み取るクラス
    /// </summary>
    [Serializable]
    public sealed partial class StreamFile : ISerializable, ICacheKeeper<StreamFile>, IDeserializationCallback
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<StreamFile>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<StreamFile>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StreamFile_Create([MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_StreamFile_Read(IntPtr selfPtr, int size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_StreamFile_GetSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_StreamFile_GetCurrentPosition(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StreamFile_GetInt8ArrayTempBuffer(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_StreamFile_GetTempBufferSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StreamFile_GetIsInPackage(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_StreamFile_GetPath(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_StreamFile_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        internal Int8Array Int8ArrayTempBuffer
        {
            get
            {
                var ret = cbg_StreamFile_GetInt8ArrayTempBuffer(selfPtr);
                return Int8Array.TryGetFromCache(ret);
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
        /// 読み込んだファイルのパスを取得します。
        /// </summary>
        public string Path
        {
            get
            {
                var ret = cbg_StreamFile_GetPath(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// 指定ファイルを読み込む<see cref="StreamFile"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static StreamFile Create(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_StreamFile_Create(path);
            return StreamFile.TryGetFromCache(ret);
        }

        /// <summary>
        /// 指定した分ファイルを読み込みます。
        /// </summary>
        /// <param name="size">この処理で読み込むデータサイズ</param>
        public int Read(int size)
        {
            var ret = cbg_StreamFile_Read(selfPtr, size);
            return ret;
        }

        /// <summary>
        /// 再読み込みを行います。
        /// </summary>
        public bool Reload()
        {
            var ret = cbg_StreamFile_Reload(selfPtr);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_CurrentPosition = "S_CurrentPosition";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Path = "S_Path";
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="StreamFile"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private StreamFile(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            seInfo = info;

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_CurrentPosition, CurrentPosition);
            info.AddValue(S_Path, Path);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="StreamFile(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>内で呼び出されます。
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="CurrentPosition"><see cref="StreamFile.CurrentPosition"/></param>
        /// <param name="Path"><see cref="StreamFile.Path"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void StreamFile_Unsetter_Deserialize(SerializationInfo info, out int CurrentPosition, out string Path)
        {
            CurrentPosition = info.GetInt32(S_CurrentPosition);
            Path = info.GetString(S_Path);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<StreamFile>> ICacheKeeper<StreamFile>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<StreamFile>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<StreamFile>.Release(IntPtr native) => cbg_StreamFile_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返します。</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var ptr = Call_GetPtr(seInfo);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);


            OnDeserialize_Method(sender);

            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization"/>中で実行されます。
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Method(object sender);

        /// <summary>
        /// <see cref="StreamFile"/>のインスタンスを削除します。
        /// </summary>
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
    /// カーソルを表します。
    /// </summary>
    public sealed partial class Cursor
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Cursor>> cacheRepo = new Dictionary<IntPtr, WeakReference<Cursor>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Cursor TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                Cursor cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Cursor_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new Cursor(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Cursor>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Cursor_Create([MarshalAs(UnmanagedType.LPWStr)] string path, Vector2I hot);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Cursor_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Cursor(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 指定したpng画像を読み込んだ<see cref="Cursor"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むpng画像のパス</param>
        /// <param name="hot">カーソルのクリック判定座標を指定します。カーソル画像はここが中心となります。</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static Cursor Create(string path, Vector2I hot)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Cursor_Create(path, hot);
            return Cursor.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="Cursor"/>のインスタンスを削除します。
        /// </summary>
        ~Cursor()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Cursor_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// ジョイスティックコントローラを表します。
    /// </summary>
    public partial class JoystickInfo
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<JoystickInfo>> cacheRepo = new Dictionary<IntPtr, WeakReference<JoystickInfo>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  JoystickInfo TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                JoystickInfo cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_JoystickInfo_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new JoystickInfo(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<JoystickInfo>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_JoystickInfo_IsJoystickType(IntPtr selfPtr, int type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_JoystickInfo_GetName(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetButtonCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetAxisCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_JoystickInfo_GetIsGamepad(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_JoystickInfo_GetGamepadName(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_JoystickInfo_GetGUID(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetBustype(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetVendor(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetProduct(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_JoystickInfo_GetVersion(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_JoystickInfo_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal JoystickInfo(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// ジョイスティックの名前を取得します。
        /// </summary>
        public string Name
        {
            get
            {
                var ret = cbg_JoystickInfo_GetName(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        public int ButtonCount
        {
            get
            {
                var ret = cbg_JoystickInfo_GetButtonCount(selfPtr);
                return ret;
            }
        }

        public int AxisCount
        {
            get
            {
                var ret = cbg_JoystickInfo_GetAxisCount(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// ジョイスティックがGamepadとして使えるかどうかを取得します。
        /// </summary>
        public bool IsGamepad
        {
            get
            {
                var ret = cbg_JoystickInfo_GetIsGamepad(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// ジョイスティックがGamepadとして使える時、その名前を取得します。
        /// </summary>
        public string GamepadName
        {
            get
            {
                var ret = cbg_JoystickInfo_GetGamepadName(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        public string GUID
        {
            get
            {
                var ret = cbg_JoystickInfo_GetGUID(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        public int Bustype
        {
            get
            {
                var ret = cbg_JoystickInfo_GetBustype(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 製造者IDを取得します。
        /// </summary>
        public int Vendor
        {
            get
            {
                var ret = cbg_JoystickInfo_GetVendor(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 製品IDを取得します。
        /// </summary>
        public int Product
        {
            get
            {
                var ret = cbg_JoystickInfo_GetProduct(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// ジョイスティックのバージョンを取得します。
        /// </summary>
        public int Version
        {
            get
            {
                var ret = cbg_JoystickInfo_GetVersion(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 指定したジョイスティックの種類に合致するかどうかを取得します。
        /// </summary>
        public bool IsJoystickType(JoystickType type)
        {
            var ret = cbg_JoystickInfo_IsJoystickType(selfPtr, (int)type);
            return ret;
        }

        /// <summary>
        /// <see cref="JoystickInfo"/>のインスタンスを削除します。
        /// </summary>
        ~JoystickInfo()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_JoystickInfo_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// ジョイスティックを表すクラス
    /// </summary>
    public sealed partial class Joystick
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Joystick>> cacheRepo = new Dictionary<IntPtr, WeakReference<Joystick>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Joystick TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Joystick_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Joystick_RefreshInputState(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Joystick_IsPresent(IntPtr selfPtr, int joystickIndex);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Joystick_GetJoystickInfo(IntPtr selfPtr, int joystickIndex);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Joystick_GetButtonStateByIndex(IntPtr selfPtr, int joystickIndex, int buttonIndex);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Joystick_GetButtonStateByType(IntPtr selfPtr, int joystickIndex, int type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Joystick_GetAxisStateByIndex(IntPtr selfPtr, int joystickIndex, int axisIndex);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Joystick_GetAxisStateByType(IntPtr selfPtr, int joystickIndex, int type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Joystick_GetConnectedJoystickCount(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Joystick_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Joystick(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 接続されているジョイスティックの数を取得します。
        /// </summary>
        public int ConnectedJoystickCount
        {
            get
            {
                var ret = cbg_Joystick_GetConnectedJoystickCount(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Joystick GetInstance()
        {
            var ret = cbg_Joystick_GetInstance();
            return Joystick.TryGetFromCache(ret);
        }

        public void RefreshInputState()
        {
            cbg_Joystick_RefreshInputState(selfPtr);
        }

        /// <summary>
        /// 指定したジョイスティックが存在しているかどうかを取得します。
        /// </summary>
        /// <param name="joystickIndex">ジョイスティックのインデックス</param>
        public bool IsPresent(int joystickIndex)
        {
            var ret = cbg_Joystick_IsPresent(selfPtr, joystickIndex);
            return ret;
        }

        /// <summary>
        /// 指定したジョイスティックの情報を取得します。
        /// </summary>
        /// <param name="joystickIndex">ジョイスティックのインデックス</param>
        public JoystickInfo GetJoystickInfo(int joystickIndex)
        {
            var ret = cbg_Joystick_GetJoystickInfo(selfPtr, joystickIndex);
            return JoystickInfo.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="Joystick"/>のインスタンスを削除します。
        /// </summary>
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
    /// キーボードを表します。
    /// </summary>
    public sealed partial class Keyboard
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Keyboard>> cacheRepo = new Dictionary<IntPtr, WeakReference<Keyboard>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Keyboard TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Keyboard_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Keyboard_RefleshKeyStates(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Keyboard_GetKeyState(IntPtr selfPtr, int key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Keyboard_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Keyboard(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Keyboard GetInstance()
        {
            var ret = cbg_Keyboard_GetInstance();
            return Keyboard.TryGetFromCache(ret);
        }

        public void RefleshKeyStates()
        {
            cbg_Keyboard_RefleshKeyStates(selfPtr);
        }

        /// <summary>
        /// キーの状態を取得します。
        /// </summary>
        /// <param name="key">キー</param>
        public ButtonState GetKeyState(Key key)
        {
            var ret = cbg_Keyboard_GetKeyState(selfPtr, (int)key);
            return (ButtonState)ret;
        }

        /// <summary>
        /// <see cref="Keyboard"/>のインスタンスを削除します。
        /// </summary>
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
    public sealed partial class Mouse
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Mouse>> cacheRepo = new Dictionary<IntPtr, WeakReference<Mouse>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Mouse TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Mouse_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_RefreshInputState(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Mouse_GetMouseButtonState(IntPtr selfPtr, int button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Mouse_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetPosition(IntPtr selfPtr, Vector2F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Mouse_GetWheel(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Mouse_GetCursorMode(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetCursorMode(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetCursorImage(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
                cbg_Mouse_SetPosition(selfPtr, value);
            }
        }
        private Vector2F? _Position;

        /// <summary>
        /// マウスホイールの回転量を取得します。
        /// </summary>
        public float Wheel
        {
            get
            {
                var ret = cbg_Mouse_GetWheel(selfPtr);
                return ret;
            }
        }

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

        public Cursor CursorImage
        {
            set
            {
                cbg_Mouse_SetCursorImage(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Mouse GetInstance()
        {
            var ret = cbg_Mouse_GetInstance();
            return Mouse.TryGetFromCache(ret);
        }

        public void RefreshInputState()
        {
            cbg_Mouse_RefreshInputState(selfPtr);
        }

        /// <summary>
        /// マウスボタンの状態を取得します。
        /// </summary>
        /// <param name="button">状態を取得するマウスのボタン</param>
        public ButtonState GetMouseButtonState(MouseButton button)
        {
            var ret = cbg_Mouse_GetMouseButtonState(selfPtr, (int)button);
            return (ButtonState)ret;
        }

        /// <summary>
        /// <see cref="Mouse"/>のインスタンスを削除します。
        /// </summary>
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
    /// 映像を再生するクラス
    /// </summary>
    public partial class MediaPlayer
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<MediaPlayer>> cacheRepo = new Dictionary<IntPtr, WeakReference<MediaPlayer>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  MediaPlayer TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                MediaPlayer cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_MediaPlayer_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new MediaPlayer(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<MediaPlayer>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_MediaPlayer_Play(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool isLoopingMode);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_MediaPlayer_WriteToRenderTexture(IntPtr selfPtr, IntPtr target);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_MediaPlayer_Load([MarshalAs(UnmanagedType.LPWStr)] string path);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2I cbg_MediaPlayer_GetSize(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_MediaPlayer_GetCurrentFrame(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_MediaPlayer_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal MediaPlayer(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 映像の大きさを取得します。
        /// </summary>
        public Vector2I Size
        {
            get
            {
                var ret = cbg_MediaPlayer_GetSize(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 映像の現在のフレーム番号を取得します。
        /// </summary>
        public int CurrentFrame
        {
            get
            {
                var ret = cbg_MediaPlayer_GetCurrentFrame(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 映像を再生します。
        /// </summary>
        /// <param name="isLoopingMode">ループ再生するか?</param>
        public bool Play(bool isLoopingMode)
        {
            var ret = cbg_MediaPlayer_Play(selfPtr, isLoopingMode);
            return ret;
        }

        /// <summary>
        /// 現在の映像のフレームをテクスチャに書き込みます。映像とテクスチャは同じサイズである必要があります。
        /// </summary>
        /// <param name="target">テクスチャ</param>
        public bool WriteToRenderTexture(RenderTexture target)
        {
            var ret = cbg_MediaPlayer_WriteToRenderTexture(selfPtr, target != null ? target.selfPtr : IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// 映像を読み込みます。
        /// </summary>
        /// <param name="path">パス(パッケージ内の映像は読み込めません。)</param>
        public static MediaPlayer Load(string path)
        {
            var ret = cbg_MediaPlayer_Load(path);
            return MediaPlayer.TryGetFromCache(ret);
        }

        /// <summary>
        /// <see cref="MediaPlayer"/>のインスタンスを削除します。
        /// </summary>
        ~MediaPlayer()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_MediaPlayer_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// コライダの抽象基本クラスです
    /// </summary>
    [Serializable]
    public partial class Collider : ISerializable, ICacheKeeper<Collider>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Collider>> cacheRepo = new Dictionary<IntPtr, WeakReference<Collider>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Collider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                Collider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_Collider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new Collider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<Collider>(newObject);
            return newObject;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Collider_GetIsCollidedWith(IntPtr selfPtr, IntPtr collider);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Collider_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Collider_SetPosition(IntPtr selfPtr, Vector2F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Collider_GetRotation(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Collider_SetRotation(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Matrix44F cbg_Collider_GetTransform(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Collider_SetTransform(IntPtr selfPtr, Matrix44F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Collider_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Collider(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Transform = "S_Transform";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Collider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Collider(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            Transform = info.GetValue<Matrix44F>(S_Transform);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_Transform, Transform);

            OnGetObjectData(info, context);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Collider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Collider(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private virtual IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Collider>> ICacheKeeper<Collider>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Collider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Collider>.Release(IntPtr native) => cbg_Collider_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Collider"/>のインスタンスを削除します。
        /// </summary>
        ~Collider()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_Collider_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 図形コライダのクラス
    /// </summary>
    [Serializable]
    public partial class ShapeCollider : Collider, ISerializable, ICacheKeeper<ShapeCollider>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<ShapeCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<ShapeCollider>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new ShapeCollider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                ShapeCollider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_ShapeCollider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new ShapeCollider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<ShapeCollider>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ShapeCollider_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_ShapeCollider_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ShapeCollider_SetVertexes(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_ShapeCollider_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ShapeCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 頂点座標を取得または設定します。
        /// </summary>
        internal Vector2FArray Vertexes
        {
            get
            {
                if (_Vertexes != null)
                {
                    return _Vertexes;
                }
                var ret = cbg_ShapeCollider_GetVertexes(selfPtr);
                return Vector2FArray.TryGetFromCache(ret);
            }
            set
            {
                _Vertexes = value;
                cbg_ShapeCollider_SetVertexes(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Vector2FArray _Vertexes;


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Vertexes = "S_Vertexes";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="ShapeCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ShapeCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            Vertexes = info.GetValue<Vector2FArray>(S_Vertexes);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_Vertexes, Vertexes);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="ShapeCollider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="ShapeCollider(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<ShapeCollider>> ICacheKeeper<ShapeCollider>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<ShapeCollider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<ShapeCollider>.Release(IntPtr native) => cbg_ShapeCollider_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="ShapeCollider"/>のインスタンスを削除します。
        /// </summary>
        ~ShapeCollider()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_ShapeCollider_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 多角形コライダのクラス
    /// </summary>
    [Serializable]
    public partial class PolygonCollider : Collider, ISerializable, ICacheKeeper<PolygonCollider>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<PolygonCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<PolygonCollider>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new PolygonCollider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                PolygonCollider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_PolygonCollider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new PolygonCollider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<PolygonCollider>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_PolygonCollider_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_PolygonCollider_SetDefaultIndexBuffer(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_PolygonCollider_GetBuffers(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_PolygonCollider_SetBuffers(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_PolygonCollider_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_PolygonCollider_SetVertexes(IntPtr selfPtr, IntPtr value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_PolygonCollider_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal PolygonCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 多角形コライダを作成します。
        /// </summary>
        public static PolygonCollider Create()
        {
            var ret = cbg_PolygonCollider_Create();
            return PolygonCollider.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="PolygonCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected PolygonCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);


            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);


            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="PolygonCollider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="PolygonCollider(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<PolygonCollider>> ICacheKeeper<PolygonCollider>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<PolygonCollider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<PolygonCollider>.Release(IntPtr native) => cbg_PolygonCollider_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="PolygonCollider"/>のインスタンスを削除します。
        /// </summary>
        ~PolygonCollider()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_PolygonCollider_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 線分コライダのクラス
    /// </summary>
    [Serializable]
    public partial class EdgeCollider : Collider, ISerializable, ICacheKeeper<EdgeCollider>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<EdgeCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<EdgeCollider>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new EdgeCollider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                EdgeCollider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_EdgeCollider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new EdgeCollider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<EdgeCollider>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_EdgeCollider_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_EdgeCollider_GetPoint1(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_EdgeCollider_SetPoint1(IntPtr selfPtr, Vector2F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_EdgeCollider_GetPoint2(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_EdgeCollider_SetPoint2(IntPtr selfPtr, Vector2F value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_EdgeCollider_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal EdgeCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 線分コライダの端点1を取得または設定します。
        /// </summary>
        public Vector2F Point1
        {
            get
            {
                if (_Point1 != null)
                {
                    return _Point1.Value;
                }
                var ret = cbg_EdgeCollider_GetPoint1(selfPtr);
                return ret;
            }
            set
            {
                _Point1 = value;
                cbg_EdgeCollider_SetPoint1(selfPtr, value);
            }
        }
        private Vector2F? _Point1;

        /// <summary>
        /// 線分コライダの端点2を取得または設定します。
        /// </summary>
        public Vector2F Point2
        {
            get
            {
                if (_Point2 != null)
                {
                    return _Point2.Value;
                }
                var ret = cbg_EdgeCollider_GetPoint2(selfPtr);
                return ret;
            }
            set
            {
                _Point2 = value;
                cbg_EdgeCollider_SetPoint2(selfPtr, value);
            }
        }
        private Vector2F? _Point2;

        /// <summary>
        /// 線分コライダを作成します。
        /// </summary>
        public static EdgeCollider Create()
        {
            var ret = cbg_EdgeCollider_Create();
            return EdgeCollider.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Point1 = "S_Point1";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Point2 = "S_Point2";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="EdgeCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected EdgeCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            Point1 = info.GetValue<Vector2F>(S_Point1);
            Point2 = info.GetValue<Vector2F>(S_Point2);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_Point1, Point1);
            info.AddValue(S_Point2, Point2);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="EdgeCollider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="EdgeCollider(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<EdgeCollider>> ICacheKeeper<EdgeCollider>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<EdgeCollider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<EdgeCollider>.Release(IntPtr native) => cbg_EdgeCollider_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="EdgeCollider"/>のインスタンスを削除します。
        /// </summary>
        ~EdgeCollider()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_EdgeCollider_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 円形コライダのクラス
    /// </summary>
    [Serializable]
    public partial class CircleCollider : Collider, ISerializable, ICacheKeeper<CircleCollider>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CircleCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<CircleCollider>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new CircleCollider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;

            if(cacheRepo.ContainsKey(native))
            {
                CircleCollider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_CircleCollider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }

            var newObject = new CircleCollider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<CircleCollider>(newObject);
            return newObject;
        }

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CircleCollider_Create();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_CircleCollider_GetRadius(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CircleCollider_SetRadius(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CircleCollider_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal CircleCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// 円形コライダの半径を取得または設定します。
        /// </summary>
        public float Radius
        {
            get
            {
                if (_Radius != null)
                {
                    return _Radius.Value;
                }
                var ret = cbg_CircleCollider_GetRadius(selfPtr);
                return ret;
            }
            set
            {
                _Radius = value;
                cbg_CircleCollider_SetRadius(selfPtr, value);
            }
        }
        private float? _Radius;

        /// <summary>
        /// 円形コライダを作成します。
        /// </summary>
        public static CircleCollider Create()
        {
            var ret = cbg_CircleCollider_Create();
            return CircleCollider.TryGetFromCache(ret);
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Radius = "S_Radius";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="CircleCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CircleCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            Radius = info.GetSingle(S_Radius);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(S_Radius, Radius);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="CircleCollider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="CircleCollider(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<CircleCollider>> ICacheKeeper<CircleCollider>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<CircleCollider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<CircleCollider>.Release(IntPtr native) => cbg_CircleCollider_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="CircleCollider"/>のインスタンスを削除します。
        /// </summary>
        ~CircleCollider()
        {
            lock (this)
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_CircleCollider_Release(selfPtr);
                    selfPtr = IntPtr.Zero;
                }
            }
        }
    }

    /// <summary>
    /// 音源のクラス
    /// </summary>
    [Serializable]
    public sealed partial class Sound : ISerializable, ICacheKeeper<Sound>
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Sound>> cacheRepo = new Dictionary<IntPtr, WeakReference<Sound>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Sound TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Sound_Load([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool isDecompressed);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Sound_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Sound_GetLoopStartingPoint(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Sound_SetLoopStartingPoint(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Sound_GetLoopEndPoint(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Sound_SetLoopEndPoint(IntPtr selfPtr, float value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Sound_GetIsLoopingMode(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Sound_SetIsLoopingMode(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Sound_GetLength(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Sound_GetPath(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Sound_GetIsDecompressed(IntPtr selfPtr);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Sound_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// 読み込んだファイルのパスを取得します。
        /// </summary>
        internal string Path
        {
            get
            {
                var ret = cbg_Sound_GetPath(selfPtr);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
            }
        }

        /// <summary>
        /// 音源が解凍されているかどうかを取得します。
        /// </summary>
        public bool IsDecompressed
        {
            get
            {
                var ret = cbg_Sound_GetIsDecompressed(selfPtr);
                return ret;
            }
        }

        /// <summary>
        /// 音声ファイルを読み込みます。
        /// </summary>
        /// <param name="path">読み込む音声ファイルのパス</param>
        /// <param name="isDecompressed">ロード時に全て解凍しておくかどうか</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static Sound Load(string path, bool isDecompressed)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Sound_Load(path, isDecompressed);
            return Sound.TryGetFromCache(ret);
        }

        public bool Reload()
        {
            var ret = cbg_Sound_Reload(selfPtr);
            return ret;
        }


        #region ISerialiable

        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_LoopStartingPoint = "S_LoopStartingPoint";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_LoopEndPoint = "S_LoopEndPoint";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsLoopingMode = "S_IsLoopingMode";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Path = "S_Path";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsDecompressed = "S_IsDecompressed";
        #endregion

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Sound"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Sound(SerializationInfo info, StreamingContext context) : this(new MemoryHandle(IntPtr.Zero))
        {
            var ptr = Call_GetPtr(info);

            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);

            LoopStartingPoint = info.GetSingle(S_LoopStartingPoint);
            LoopEndPoint = info.GetSingle(S_LoopEndPoint);
            IsLoopingMode = info.GetBoolean(S_IsLoopingMode);

            OnDeserialize_Constructor(info, context);
        }

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");

            info.AddValue(S_LoopStartingPoint, LoopStartingPoint);
            info.AddValue(S_LoopEndPoint, LoopEndPoint);
            info.AddValue(S_IsLoopingMode, IsLoopingMode);
            info.AddValue(S_Path, Path);
            info.AddValue(S_IsDecompressed, IsDecompressed);

            OnGetObjectData(info, context);
        }

        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行されます。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr">selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる</param>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);

        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }

        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Path"><see cref="Sound.Path"/></param>
        /// <param name="IsDecompressed"><see cref="Sound.IsDecompressed"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Sound_Unsetter_Deserialize(SerializationInfo info, out string Path, out bool IsDecompressed)
        {
            Path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
            IsDecompressed = info.GetBoolean(S_IsDecompressed);
        }

        #region ICacheKeeper

        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<IntPtr, WeakReference<Sound>> ICacheKeeper<Sound>.CacheRepo => cacheRepo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<Sound>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<Sound>.Release(IntPtr native) => cbg_Sound_Release(native);

        #endregion

        #endregion

        /// <summary>
        /// <see cref="Sound"/>のインスタンスを削除します。
        /// </summary>
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

    /// <summary>
    /// 音源を操作するクラス
    /// </summary>
    public sealed partial class SoundMixer
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<SoundMixer>> cacheRepo = new Dictionary<IntPtr, WeakReference<SoundMixer>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  SoundMixer TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_SoundMixer_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_SoundMixer_Play(IntPtr selfPtr, IntPtr sound);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_SoundMixer_GetIsPlaying(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_StopAll(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Stop(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Pause(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Resume(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_SetVolume(IntPtr selfPtr, int id, float volume);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_FadeIn(IntPtr selfPtr, int id, float second);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_FadeOut(IntPtr selfPtr, int id, float second);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Fade(IntPtr selfPtr, int id, float second, float targetedVolume);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_SoundMixer_GetIsPlaybackSpeedEnabled(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_SetIsPlaybackSpeedEnabled(IntPtr selfPtr, int id, [MarshalAs(UnmanagedType.Bool)] bool isPlaybackSpeedEnabled);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_SoundMixer_GetPlaybackSpeed(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_SetPlaybackSpeed(IntPtr selfPtr, int id, float playbackSpeed);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_SoundMixer_GetPanningPosition(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_SetPanningPosition(IntPtr selfPtr, int id, float panningPosition);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_SoundMixer_GetPlaybackPosition(IntPtr selfPtr, int id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_SetPlaybackPosition(IntPtr selfPtr, int id, float position);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_GetSpectrum(IntPtr selfPtr, int id, IntPtr spectrums, int window);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Reload(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_SoundMixer_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <exception cref="ArgumentNullException"><paramref name="sound"/>がnull</exception>
        public int Play(Sound sound)
        {
            if (sound == null) throw new ArgumentNullException(nameof(sound), "引数がnullです");
            var ret = cbg_SoundMixer_Play(selfPtr, sound != null ? sound.selfPtr : IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// 指定した音が再生中であるかを取得します。
        /// </summary>
        /// <param name="id">音のID</param>
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
        /// <param name="volume">音量(0.0～1.0)</param>
        public void SetVolume(int id, float volume)
        {
            cbg_SoundMixer_SetVolume(selfPtr, id, volume);
        }

        /// <summary>
        /// 指定した音をフェードインさせます。
        /// </summary>
        /// <param name="second">フェードインに使用する時間(秒)</param>
        public void FadeIn(int id, float second)
        {
            cbg_SoundMixer_FadeIn(selfPtr, id, second);
        }

        /// <summary>
        /// 指定した音をフェードアウトさせます。
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
        /// <param name="targetedVolume">変更後の音量(0.0～1.0)</param>
        public void Fade(int id, float second, float targetedVolume)
        {
            cbg_SoundMixer_Fade(selfPtr, id, second, targetedVolume);
        }

        /// <summary>
        /// 再生速度を変更するかを取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        public bool GetIsPlaybackSpeedEnabled(int id)
        {
            var ret = cbg_SoundMixer_GetIsPlaybackSpeedEnabled(selfPtr, id);
            return ret;
        }

        /// <summary>
        /// 再生速度を変更するかを設定します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <param name="isPlaybackSpeedEnabled">再生速度を変更するかどうか</param>
        public void SetIsPlaybackSpeedEnabled(int id, bool isPlaybackSpeedEnabled)
        {
            cbg_SoundMixer_SetIsPlaybackSpeedEnabled(selfPtr, id, isPlaybackSpeedEnabled);
        }

        /// <summary>
        /// 再生速度を取得します。
        /// </summary>
        /// <param name="id">音のID</param>
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
        internal void GetSpectrum(int id, FloatArray spectrums, FFTWindow window)
        {
            cbg_SoundMixer_GetSpectrum(selfPtr, id, spectrums != null ? spectrums.selfPtr : IntPtr.Zero, (int)window);
        }

        public void Reload()
        {
            cbg_SoundMixer_Reload(selfPtr);
        }

        /// <summary>
        /// <see cref="SoundMixer"/>のインスタンスを削除します。
        /// </summary>
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
    /// imguiのツール処理を行うクラス
    /// </summary>
    public sealed partial class Tool
    {
        #region unmanaged

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Tool>> cacheRepo = new Dictionary<IntPtr, WeakReference<Tool>>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  Tool TryGetFromCache(IntPtr native)
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetInstance();

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NewFrame(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Render(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_AddFontFromFileTTF(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, float sizePixels, int ranges);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ListBox(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int current, [MarshalAs(UnmanagedType.LPWStr)] string items_separated_by_tabs, int popup_max_height_in_items);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string input, int max_length, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputTextWithHint(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string hint, [MarshalAs(UnmanagedType.LPWStr)] string input, int max_length, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputTextMultiline(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string input, int max_length, Vector2F size, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorEdit3_char16p_FloatArray_ToolColorEditFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr col, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorEdit4_char16p_FloatArray_ToolColorEditFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr col, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Image(IntPtr selfPtr, IntPtr texture, Vector2F size, Vector2F uv0, Vector2F uv1, Color tint_col, Color border_col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ImageButton(IntPtr selfPtr, IntPtr texture, Vector2F size, Vector2F uv0, Vector2F uv1, int frame_padding, Color bg_col, Color tint_col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Combo(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int current_item, [MarshalAs(UnmanagedType.LPWStr)] string items_separated_by_tabs, int popup_max_height_in_items);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PlotLines(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr values, int values_count, int values_offset, [MarshalAs(UnmanagedType.LPWStr)] string overlay_text, float scale_min, float scale_max, Vector2F graph_size, int stride);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PlotHistogram(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr values, int values_count, int values_offset, [MarshalAs(UnmanagedType.LPWStr)] string overlay_text, float scale_min, float scale_max, Vector2F graph_size, int stride);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTime(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetMainViewportID(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMainViewportPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMainViewportSize(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMainViewportWorkPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMainViewportWorkSize(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_DockSpace(IntPtr selfPtr, int id, Vector2F size, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginDockHost(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F offset);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowDemoWindowNoCloseButton(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowAboutWindowNoCloseButton(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowMetricsWindowNoCloseButton(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Begin_char16p_ToolWindowFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Begin_char16p_boolp_ToolWindowFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupModal_char16p_ToolWindowFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupModal_char16p_boolp_ToolWindowFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabItem_char16p_ToolTabItemFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabItem_char16p_boolp_ToolTabItemFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_OpenDialog(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string defaultPath);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_OpenDialogMultiple(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string defaultPath);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_SaveDialog(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string filter, [MarshalAs(UnmanagedType.LPWStr)] string defaultPath);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_PickFolder(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string defaultPath);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowDemoWindow(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowAboutWindow(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowMetricsWindow(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ShowStyleSelector(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowFontSelector(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ShowUserGuide(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetVersion(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_End(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginChild_char16p_Vector2F_C_bool_ToolWindowFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, Vector2F size, [MarshalAs(UnmanagedType.Bool)] bool border, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginChild_int_Vector2F_C_bool_ToolWindowFlags(IntPtr selfPtr, int id, Vector2F size, [MarshalAs(UnmanagedType.Bool)] bool border, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndChild(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsWindowAppearing(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsWindowCollapsed(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsWindowFocused(IntPtr selfPtr, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsWindowHovered(IntPtr selfPtr, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetWindowDpiScale(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetWindowPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetWindowSize(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetWindowWidth(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetWindowHeight(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowPos(IntPtr selfPtr, Vector2F pos, int cond, Vector2F pivot);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowSize(IntPtr selfPtr, Vector2F size, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowContentSize(IntPtr selfPtr, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowCollapsed(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool collapsed, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowFocus(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowBgAlpha(IntPtr selfPtr, float alpha);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowViewport(IntPtr selfPtr, int viewport_id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowPos_Vector2F_C_ToolCond(IntPtr selfPtr, Vector2F pos, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowPos_char16p_Vector2F_C_ToolCond(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, Vector2F pos, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowSize_Vector2F_C_ToolCond(IntPtr selfPtr, Vector2F size, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowSize_char16p_Vector2F_C_ToolCond(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, Vector2F size, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowCollapsed_bool_ToolCond(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool collapsed, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowCollapsed_char16p_bool_ToolCond(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool collapsed, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFocus_(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFocus_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFontScale(IntPtr selfPtr, float scale);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetContentRegionMax(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetContentRegionAvail(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetWindowContentRegionMin(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetWindowContentRegionMax(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetWindowContentRegionWidth(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetScrollX(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetScrollY(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetScrollMaxX(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetScrollMaxY(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollX(IntPtr selfPtr, float scroll_x);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollY(IntPtr selfPtr, float scroll_y);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollHereX(IntPtr selfPtr, float center_x_ratio);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollHereY(IntPtr selfPtr, float center_y_ratio);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollFromPosX(IntPtr selfPtr, float local_x, float center_x_ratio);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollFromPosY(IntPtr selfPtr, float local_y, float center_y_ratio);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopFont(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleColor_ToolCol_int(IntPtr selfPtr, int idx, int col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleColor_ToolCol_Vector4F_C(IntPtr selfPtr, int idx, Vector4F col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopStyleColor(IntPtr selfPtr, int count);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleVar_ToolStyleVar_float(IntPtr selfPtr, int idx, float val);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleVar_ToolStyleVar_Vector2F_C(IntPtr selfPtr, int idx, Vector2F val);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopStyleVar(IntPtr selfPtr, int count);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetFontSize(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetFontTexUvWhitePixel(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColorU32_ToolCol_float(IntPtr selfPtr, int idx, float alpha_mul);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColorU32_Vector4F_C(IntPtr selfPtr, Vector4F col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColorU32_int(IntPtr selfPtr, int col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushItemWidth(IntPtr selfPtr, float item_width);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopItemWidth(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextItemWidth(IntPtr selfPtr, float item_width);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_CalcItemWidth(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushTextWrapPos(IntPtr selfPtr, float wrap_local_pos_x);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopTextWrapPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushAllowKeyboardFocus(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool allow_keyboard_focus);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopAllowKeyboardFocus(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushButtonRepeat(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool repeat);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopButtonRepeat(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Separator(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SameLine(IntPtr selfPtr, float offset_from_start_x, float spacing);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NewLine(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Spacing(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Dummy(IntPtr selfPtr, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Indent(IntPtr selfPtr, float indent_w);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Unindent(IntPtr selfPtr, float indent_w);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BeginGroup(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndGroup(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetCursorPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetCursorPosX(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetCursorPosY(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetCursorPos(IntPtr selfPtr, Vector2F local_pos);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetCursorPosX(IntPtr selfPtr, float local_x);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetCursorPosY(IntPtr selfPtr, float local_y);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetCursorStartPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetCursorScreenPos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetCursorScreenPos(IntPtr selfPtr, Vector2F pos);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_AlignTextToFramePadding(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTextLineHeight(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTextLineHeightWithSpacing(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetFrameHeight(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetFrameHeightWithSpacing(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushID_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushID_char16p_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id_begin, [MarshalAs(UnmanagedType.LPWStr)] string str_id_end);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushID_int(IntPtr selfPtr, int int_id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopID(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetID_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetID_char16p_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id_begin, [MarshalAs(UnmanagedType.LPWStr)] string str_id_end);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextUnformatted(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string text_end);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Text(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextColored(IntPtr selfPtr, Vector4F col, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextDisabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextWrapped(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LabelText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BulletText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Button(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SmallButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InvisibleButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, Vector2F size, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ArrowButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int dir);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Checkbox(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool v);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_RadioButton_char16p_bool(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool active);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_RadioButton_char16p_intp_int(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v, int v_button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ProgressBar(IntPtr selfPtr, float fraction, Vector2F size_arg, [MarshalAs(UnmanagedType.LPWStr)] string overlay);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Bullet(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginCombo(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string preview_value, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndCombo(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float v, float v_speed, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloatRange2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float v_current_min, [In, Out] ref float v_current_max, float v_speed, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, [MarshalAs(UnmanagedType.LPWStr)] string format_max, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v, float v_speed, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_speed, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragIntRange2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v_current_min, [In, Out] ref int v_current_max, float v_speed, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, [MarshalAs(UnmanagedType.LPWStr)] string format_max, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float v, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderAngle(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float v_rad, float v_degrees_min, float v_degrees_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref float v, float v_min, float v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref int v, int v_min, int v_max, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float v, float step, float step_fast, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, [MarshalAs(UnmanagedType.LPWStr)] string format, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v, int step, int step_fast, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr v, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorPicker3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr col, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorPicker4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr col, int flags, [In, Out] ref float ref_col);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColorEditOptions(IntPtr selfPtr, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNode_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNode_char16p_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNodeEx_char16p_ToolTreeNodeFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNodeEx_char16p_ToolTreeNodeFlags_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int flags, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TreePush(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TreePop(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTreeNodeToLabelSpacing(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CollapsingHeader_char16p_ToolTreeNodeFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CollapsingHeader_char16p_boolp_ToolTreeNodeFlags(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_open, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextItemOpen(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool is_open, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Selectable_char16p_bool_ToolSelectableFlags_Vector2F_C(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool selected, int flags, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Selectable_char16p_boolp_ToolSelectableFlags_Vector2F_C(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_selected, int flags, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ListBoxHeader_char16p_Vector2F_C(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ListBoxHeader_char16p_int_int(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int items_count, int height_in_items);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ListBoxFooter(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Value_char16p_bool(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, [MarshalAs(UnmanagedType.Bool)] bool b);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Value_char16p_int(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, int v);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Value_char16p_float_char16p(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, float v, [MarshalAs(UnmanagedType.LPWStr)] string float_format);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginMenuBar(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndMenuBar(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginMainMenuBar(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndMainMenuBar(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginMenu(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool enabled);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndMenu(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_MenuItem_char16p_char16p_bool_bool(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string shortcut, [MarshalAs(UnmanagedType.Bool)] bool selected, [MarshalAs(UnmanagedType.Bool)] bool enabled);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_MenuItem_char16p_char16p_boolp_bool(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string shortcut, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool p_selected, [MarshalAs(UnmanagedType.Bool)] bool enabled);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BeginTooltip(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTooltip(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetTooltip(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndPopup(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_OpenPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int popup_flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_OpenPopupOnItemClick(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int popup_flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_CloseCurrentPopup(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupContextItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int popup_flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupContextWindow(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int popup_flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupContextVoid(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int popup_flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsPopupOpen(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Columns(IntPtr selfPtr, int count, [MarshalAs(UnmanagedType.LPWStr)] string id, [MarshalAs(UnmanagedType.Bool)] bool border);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NextColumn(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColumnIndex(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetColumnWidth(IntPtr selfPtr, int column_index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColumnWidth(IntPtr selfPtr, int column_index, float width);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetColumnOffset(IntPtr selfPtr, int column_index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColumnOffset(IntPtr selfPtr, int column_index, float offset_x);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColumnsCount(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabBar(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string str_id, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTabBar(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTabItem(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TabItemButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetTabItemClosed(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string tab_or_docked_window_label);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowDockID(IntPtr selfPtr, int dock_id, int cond);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetWindowDockID(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsWindowDocked(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogToTTY(IntPtr selfPtr, int auto_open_depth);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogToFile(IntPtr selfPtr, int auto_open_depth, [MarshalAs(UnmanagedType.LPWStr)] string filename);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogToClipboard(IntPtr selfPtr, int auto_open_depth);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogFinish(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogButtons(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LogText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginDragDropSource(IntPtr selfPtr, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndDragDropSource(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginDragDropTarget(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndDragDropTarget(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushClipRect(IntPtr selfPtr, Vector2F clip_rect_min, Vector2F clip_rect_max, [MarshalAs(UnmanagedType.Bool)] bool intersect_with_current_clip_rect);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopClipRect(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetItemDefaultFocus(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetKeyboardFocusHere(IntPtr selfPtr, int offset);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemHovered(IntPtr selfPtr, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemActive(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemFocused(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemClicked(IntPtr selfPtr, int mouse_button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemVisible(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemEdited(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemActivated(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemDeactivated(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemDeactivatedAfterEdit(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemToggledOpen(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsAnyItemHovered(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsAnyItemActive(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsAnyItemFocused(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetItemRectMin(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetItemRectMax(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetItemRectSize(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetItemAllowOverlap(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsRectVisible_Vector2F_C(IntPtr selfPtr, Vector2F size);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsRectVisible_Vector2F_C_Vector2F_C(IntPtr selfPtr, Vector2F rect_min, Vector2F rect_max);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetFrameCount(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetStyleColorName(IntPtr selfPtr, int idx);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_CalcListClipping(IntPtr selfPtr, int items_count, float items_height, [In, Out] ref int out_items_display_start, [In, Out] ref int out_items_display_end);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginChildFrame(IntPtr selfPtr, int id, Vector2F size, int flags);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndChildFrame(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_CalcTextSize(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string text_end, [MarshalAs(UnmanagedType.Bool)] bool hide_text_after_double_hash, float wrap_width);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector4F cbg_Tool_ColorConvertU32ToFloat4(IntPtr selfPtr, int in_);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_ColorConvertFloat4ToU32(IntPtr selfPtr, Vector4F in_);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetKeyIndex(IntPtr selfPtr, int imgui_key);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsKeyDown(IntPtr selfPtr, int user_key_index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsKeyPressed(IntPtr selfPtr, int user_key_index, [MarshalAs(UnmanagedType.Bool)] bool repeat);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsKeyReleased(IntPtr selfPtr, int user_key_index);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetKeyPressedAmount(IntPtr selfPtr, int key_index, float repeat_delay, float rate);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_CaptureKeyboardFromApp(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool want_capture_keyboard_value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDown(IntPtr selfPtr, int button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseClicked(IntPtr selfPtr, int button, [MarshalAs(UnmanagedType.Bool)] bool repeat);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseReleased(IntPtr selfPtr, int button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDoubleClicked(IntPtr selfPtr, int button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseHoveringRect(IntPtr selfPtr, Vector2F r_min, Vector2F r_max, [MarshalAs(UnmanagedType.Bool)] bool clip);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsAnyMouseDown(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMousePos(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMousePosOnOpeningCurrentPopup(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDragging(IntPtr selfPtr, int button, float lock_threshold);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMouseDragDelta(IntPtr selfPtr, int button, float lock_threshold);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ResetMouseDragDelta(IntPtr selfPtr, int button);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetMouseCursor(IntPtr selfPtr, int cursor_type);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_CaptureMouseFromApp(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool want_capture_mouse_value);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetClipboardText(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetClipboardText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LoadIniSettingsFromDisk(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string ini_filename);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SaveIniSettingsToDisk(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string ini_filename);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_UpdatePlatformWindows(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_DestroyPlatformWindows(IntPtr selfPtr);

        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetToolUsage(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetToolUsage(IntPtr selfPtr, int value);


        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Release(IntPtr selfPtr);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Tool(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }

        /// <summary>
        /// ツールの使用方法を取得または設定します。
        /// </summary>
        public ToolUsage ToolUsage
        {
            get
            {
                if (_ToolUsage != null)
                {
                    return _ToolUsage.Value;
                }
                var ret = cbg_Tool_GetToolUsage(selfPtr);
                return (ToolUsage)ret;
            }
            set
            {
                _ToolUsage = value;
                cbg_Tool_SetToolUsage(selfPtr, (int)value);
            }
        }
        private ToolUsage? _ToolUsage;

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        internal static Tool GetInstance()
        {
            var ret = cbg_Tool_GetInstance();
            return Tool.TryGetFromCache(ret);
        }

        public void NewFrame()
        {
            cbg_Tool_NewFrame(selfPtr);
        }

        public void Render()
        {
            cbg_Tool_Render(selfPtr);
        }

        /// <summary>
        /// パスからフォントを読み込みます。パックされたファイルは非対応です。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public bool AddFontFromFileTTF(string path, float sizePixels, ToolGlyphRange ranges)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Tool_AddFontFromFileTTF(selfPtr, path, sizePixels, (int)ranges);
            return ret;
        }

        /// <summary>
        /// リストボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="current">選択中のアイテムのインデックス -1で選択無し</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="items_separated_by_tabs"/>のいずれかがnull</exception>
        public bool ListBox(string label, ref int current, string items_separated_by_tabs, int popup_max_height_in_items)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (items_separated_by_tabs == null) throw new ArgumentNullException(nameof(items_separated_by_tabs), "引数がnullです");
            var ret = cbg_Tool_ListBox(selfPtr, label, ref current, items_separated_by_tabs, popup_max_height_in_items);
            return ret;
        }

        /// <summary>
        /// テキストを入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="input"/>のいずれかがnull</exception>
        public string InputText(string label, string input, int max_length, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputText(selfPtr, label, input, max_length, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// ヒント付きのテキスト入力ボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="hint">インプットされている文字列長が0の時に表示されるヒント</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="hint"/>, <paramref name="input"/>のいずれかがnull</exception>
        public string InputTextWithHint(string label, string hint, string input, int max_length, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (hint == null) throw new ArgumentNullException(nameof(hint), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputTextWithHint(selfPtr, label, hint, input, max_length, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// 複数行のテキストが入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="size">サイズ</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="input"/>のいずれかがnull</exception>
        public string InputTextMultiline(string label, string input, int max_length, Vector2F size, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputTextMultiline(selfPtr, label, input, max_length, size, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// 色を入力するツールを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool ColorEdit3(string label, FloatArray col, ToolColorEditFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorEdit3_char16p_FloatArray_ToolColorEditFlags(selfPtr, label, col != null ? col.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        /// <summary>
        /// 色を入力するツールを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool ColorEdit4(string label, FloatArray col, ToolColorEditFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorEdit4_char16p_FloatArray_ToolColorEditFlags(selfPtr, label, col != null ? col.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        /// <summary>
        /// 画像表示ボックスを生成します。
        /// </summary>
        /// <param name="texture">表示するテクスチャ</param>
        /// <param name="size">サイズ</param>
        /// <param name="uv0">テクスチャのUV値(0~1)</param>
        /// <param name="uv1">テクスチャのUV値(0~1)</param>
        public void Image(TextureBase texture, Vector2F size, Vector2F uv0, Vector2F uv1, Color tint_col, Color border_col)
        {
            cbg_Tool_Image(selfPtr, texture != null ? texture.selfPtr : IntPtr.Zero, size, uv0, uv1, tint_col, border_col);
        }

        /// <summary>
        /// ボタンとして機能する画像表示ボックスを生成します。
        /// </summary>
        /// <param name="texture">表示するテクスチャ</param>
        /// <param name="size">サイズ</param>
        /// <param name="uv0">テクスチャのUV値(0~1)</param>
        /// <param name="uv1">テクスチャのUV値(0~1)</param>
        public bool ImageButton(TextureBase texture, Vector2F size, Vector2F uv0, Vector2F uv1, int frame_padding, Color bg_col, Color tint_col)
        {
            var ret = cbg_Tool_ImageButton(selfPtr, texture != null ? texture.selfPtr : IntPtr.Zero, size, uv0, uv1, frame_padding, bg_col, tint_col);
            return ret;
        }

        /// <summary>
        /// コンボボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルのテキスト</param>
        /// <param name="current_item">選択されているアイテムのインデックス -1で選択無し</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="items_separated_by_tabs"/>のいずれかがnull</exception>
        public bool Combo(string label, ref int current_item, string items_separated_by_tabs, int popup_max_height_in_items)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (items_separated_by_tabs == null) throw new ArgumentNullException(nameof(items_separated_by_tabs), "引数がnullです");
            var ret = cbg_Tool_Combo(selfPtr, label, ref current_item, items_separated_by_tabs, popup_max_height_in_items);
            return ret;
        }

        internal void PlotLines(string label, FloatArray values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2F graph_size, int stride)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (overlay_text == null) throw new ArgumentNullException(nameof(overlay_text), "引数がnullです");
            cbg_Tool_PlotLines(selfPtr, label, values != null ? values.selfPtr : IntPtr.Zero, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
        }

        internal void PlotHistogram(string label, FloatArray values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2F graph_size, int stride)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (overlay_text == null) throw new ArgumentNullException(nameof(overlay_text), "引数がnullです");
            cbg_Tool_PlotHistogram(selfPtr, label, values != null ? values.selfPtr : IntPtr.Zero, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
        }

        public float GetTime()
        {
            var ret = cbg_Tool_GetTime(selfPtr);
            return ret;
        }

        public int GetMainViewportID()
        {
            var ret = cbg_Tool_GetMainViewportID(selfPtr);
            return ret;
        }

        public Vector2F GetMainViewportPos()
        {
            var ret = cbg_Tool_GetMainViewportPos(selfPtr);
            return ret;
        }

        public Vector2F GetMainViewportSize()
        {
            var ret = cbg_Tool_GetMainViewportSize(selfPtr);
            return ret;
        }

        public Vector2F GetMainViewportWorkPos()
        {
            var ret = cbg_Tool_GetMainViewportWorkPos(selfPtr);
            return ret;
        }

        public Vector2F GetMainViewportWorkSize()
        {
            var ret = cbg_Tool_GetMainViewportWorkSize(selfPtr);
            return ret;
        }

        public void DockSpace(int id, Vector2F size, ToolDockNodeFlags flags)
        {
            cbg_Tool_DockSpace(selfPtr, id, size, (int)flags);
        }

        public bool BeginDockHost(string label, Vector2F offset)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_BeginDockHost(selfPtr, label, offset);
            return ret;
        }

        public void ShowDemoWindowNoCloseButton()
        {
            cbg_Tool_ShowDemoWindowNoCloseButton(selfPtr);
        }

        public void ShowAboutWindowNoCloseButton()
        {
            cbg_Tool_ShowAboutWindowNoCloseButton(selfPtr);
        }

        public void ShowMetricsWindowNoCloseButton()
        {
            cbg_Tool_ShowMetricsWindowNoCloseButton(selfPtr);
        }

        /// <summary>
        /// 'End()' を呼び出してください。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        public bool Begin(string name, ToolWindowFlags flags)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            var ret = cbg_Tool_Begin_char16p_ToolWindowFlags(selfPtr, name, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'End()' を呼び出してください。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        public bool Begin(string name, ref bool p_open, ToolWindowFlags flags)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            var ret = cbg_Tool_Begin_char16p_boolp_ToolWindowFlags(selfPtr, name, ref p_open, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'EndPopup()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        public bool BeginPopupModal(string name, ToolWindowFlags flags)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            var ret = cbg_Tool_BeginPopupModal_char16p_ToolWindowFlags(selfPtr, name, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'EndPopup()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        public bool BeginPopupModal(string name, ref bool p_open, ToolWindowFlags flags)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            var ret = cbg_Tool_BeginPopupModal_char16p_boolp_ToolWindowFlags(selfPtr, name, ref p_open, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'EndTabItem()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool BeginTabItem(string label, ToolTabItemFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_BeginTabItem_char16p_ToolTabItemFlags(selfPtr, label, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'EndTabItem()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool BeginTabItem(string label, ref bool p_open, ToolTabItemFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_BeginTabItem_char16p_boolp_ToolTabItemFlags(selfPtr, label, ref p_open, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つの開くファイルを選択するダイアログを開きます。
        /// </summary>
        /// <param name="filter">読み込むファイルの拡張子のフィルタ</param>
        /// <param name="defaultPath">ファイルダイアログの初期位置のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="filter"/>, <paramref name="defaultPath"/>のいずれかがnull</exception>
        public string OpenDialog(string filter, string defaultPath)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), "引数がnullです");
            if (defaultPath == null) throw new ArgumentNullException(nameof(defaultPath), "引数がnullです");
            var ret = cbg_Tool_OpenDialog(selfPtr, filter, defaultPath);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// 複数の開くファイルを選択するダイアログを開きます。
        /// </summary>
        /// <param name="filter">読み込むファイルの拡張子のフィルタ</param>
        /// <param name="defaultPath">ファイルダイアログの初期位置のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="filter"/>, <paramref name="defaultPath"/>のいずれかがnull</exception>
        public string OpenDialogMultiple(string filter, string defaultPath)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), "引数がnullです");
            if (defaultPath == null) throw new ArgumentNullException(nameof(defaultPath), "引数がnullです");
            var ret = cbg_Tool_OpenDialogMultiple(selfPtr, filter, defaultPath);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// 保存するファイルを選択するダイアログを開きます。
        /// </summary>
        /// <param name="filter">保存するファイルの拡張子のフィルタ</param>
        /// <param name="defaultPath">ファイルダイアログの初期位置のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="filter"/>, <paramref name="defaultPath"/>のいずれかがnull</exception>
        public string SaveDialog(string filter, string defaultPath)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), "引数がnullです");
            if (defaultPath == null) throw new ArgumentNullException(nameof(defaultPath), "引数がnullです");
            var ret = cbg_Tool_SaveDialog(selfPtr, filter, defaultPath);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        /// <summary>
        /// フォルダを選択するダイアログを開きます。
        /// </summary>
        /// <param name="defaultPath">ファイルダイアログの初期位置のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="defaultPath"/>がnull</exception>
        public string PickFolder(string defaultPath)
        {
            if (defaultPath == null) throw new ArgumentNullException(nameof(defaultPath), "引数がnullです");
            var ret = cbg_Tool_PickFolder(selfPtr, defaultPath);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        public void ShowDemoWindow(ref bool p_open)
        {
            cbg_Tool_ShowDemoWindow(selfPtr, ref p_open);
        }

        public void ShowAboutWindow(ref bool p_open)
        {
            cbg_Tool_ShowAboutWindow(selfPtr, ref p_open);
        }

        public void ShowMetricsWindow(ref bool p_open)
        {
            cbg_Tool_ShowMetricsWindow(selfPtr, ref p_open);
        }

        public bool ShowStyleSelector(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ShowStyleSelector(selfPtr, label);
            return ret;
        }

        public void ShowFontSelector(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            cbg_Tool_ShowFontSelector(selfPtr, label);
        }

        public void ShowUserGuide()
        {
            cbg_Tool_ShowUserGuide(selfPtr);
        }

        public string GetVersion()
        {
            var ret = cbg_Tool_GetVersion(selfPtr);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        public void End()
        {
            cbg_Tool_End(selfPtr);
        }

        /// <summary>
        /// 'EndChild()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>がnull</exception>
        public bool BeginChild(string str_id, Vector2F size, bool border, ToolWindowFlags flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginChild_char16p_Vector2F_C_bool_ToolWindowFlags(selfPtr, str_id, size, border, (int)flags);
            return ret;
        }

        /// <summary>
        /// 'EndChild()' を呼び出してください
        /// </summary>
        public bool BeginChild(int id, Vector2F size, bool border, ToolWindowFlags flags)
        {
            var ret = cbg_Tool_BeginChild_int_Vector2F_C_bool_ToolWindowFlags(selfPtr, id, size, border, (int)flags);
            return ret;
        }

        public void EndChild()
        {
            cbg_Tool_EndChild(selfPtr);
        }

        public bool IsWindowAppearing()
        {
            var ret = cbg_Tool_IsWindowAppearing(selfPtr);
            return ret;
        }

        public bool IsWindowCollapsed()
        {
            var ret = cbg_Tool_IsWindowCollapsed(selfPtr);
            return ret;
        }

        public bool IsWindowFocused(ToolFocusedFlags flags)
        {
            var ret = cbg_Tool_IsWindowFocused(selfPtr, (int)flags);
            return ret;
        }

        public bool IsWindowHovered(ToolHoveredFlags flags)
        {
            var ret = cbg_Tool_IsWindowHovered(selfPtr, (int)flags);
            return ret;
        }

        public float GetWindowDpiScale()
        {
            var ret = cbg_Tool_GetWindowDpiScale(selfPtr);
            return ret;
        }

        public Vector2F GetWindowPos()
        {
            var ret = cbg_Tool_GetWindowPos(selfPtr);
            return ret;
        }

        public Vector2F GetWindowSize()
        {
            var ret = cbg_Tool_GetWindowSize(selfPtr);
            return ret;
        }

        public float GetWindowWidth()
        {
            var ret = cbg_Tool_GetWindowWidth(selfPtr);
            return ret;
        }

        public float GetWindowHeight()
        {
            var ret = cbg_Tool_GetWindowHeight(selfPtr);
            return ret;
        }

        public void SetNextWindowPos(Vector2F pos, ToolCond cond, Vector2F pivot)
        {
            cbg_Tool_SetNextWindowPos(selfPtr, pos, (int)cond, pivot);
        }

        public void SetNextWindowSize(Vector2F size, ToolCond cond)
        {
            cbg_Tool_SetNextWindowSize(selfPtr, size, (int)cond);
        }

        public void SetNextWindowContentSize(Vector2F size)
        {
            cbg_Tool_SetNextWindowContentSize(selfPtr, size);
        }

        public void SetNextWindowCollapsed(bool collapsed, ToolCond cond)
        {
            cbg_Tool_SetNextWindowCollapsed(selfPtr, collapsed, (int)cond);
        }

        public void SetNextWindowFocus()
        {
            cbg_Tool_SetNextWindowFocus(selfPtr);
        }

        public void SetNextWindowBgAlpha(float alpha)
        {
            cbg_Tool_SetNextWindowBgAlpha(selfPtr, alpha);
        }

        public void SetNextWindowViewport(int viewport_id)
        {
            cbg_Tool_SetNextWindowViewport(selfPtr, viewport_id);
        }

        public void SetWindowPos(Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetWindowPos_Vector2F_C_ToolCond(selfPtr, pos, (int)cond);
        }

        public void SetWindowPos(string name, Vector2F pos, ToolCond cond)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            cbg_Tool_SetWindowPos_char16p_Vector2F_C_ToolCond(selfPtr, name, pos, (int)cond);
        }

        public void SetWindowSize(Vector2F size, ToolCond cond)
        {
            cbg_Tool_SetWindowSize_Vector2F_C_ToolCond(selfPtr, size, (int)cond);
        }

        public void SetWindowSize(string name, Vector2F size, ToolCond cond)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            cbg_Tool_SetWindowSize_char16p_Vector2F_C_ToolCond(selfPtr, name, size, (int)cond);
        }

        public void SetWindowCollapsed(bool collapsed, ToolCond cond)
        {
            cbg_Tool_SetWindowCollapsed_bool_ToolCond(selfPtr, collapsed, (int)cond);
        }

        public void SetWindowCollapsed(string name, bool collapsed, ToolCond cond)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            cbg_Tool_SetWindowCollapsed_char16p_bool_ToolCond(selfPtr, name, collapsed, (int)cond);
        }

        public void SetWindowFocus()
        {
            cbg_Tool_SetWindowFocus_(selfPtr);
        }

        public void SetWindowFocus(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            cbg_Tool_SetWindowFocus_char16p(selfPtr, name);
        }

        public void SetWindowFontScale(float scale)
        {
            cbg_Tool_SetWindowFontScale(selfPtr, scale);
        }

        public Vector2F GetContentRegionMax()
        {
            var ret = cbg_Tool_GetContentRegionMax(selfPtr);
            return ret;
        }

        public Vector2F GetContentRegionAvail()
        {
            var ret = cbg_Tool_GetContentRegionAvail(selfPtr);
            return ret;
        }

        public Vector2F GetWindowContentRegionMin()
        {
            var ret = cbg_Tool_GetWindowContentRegionMin(selfPtr);
            return ret;
        }

        public Vector2F GetWindowContentRegionMax()
        {
            var ret = cbg_Tool_GetWindowContentRegionMax(selfPtr);
            return ret;
        }

        public float GetWindowContentRegionWidth()
        {
            var ret = cbg_Tool_GetWindowContentRegionWidth(selfPtr);
            return ret;
        }

        public float GetScrollX()
        {
            var ret = cbg_Tool_GetScrollX(selfPtr);
            return ret;
        }

        public float GetScrollY()
        {
            var ret = cbg_Tool_GetScrollY(selfPtr);
            return ret;
        }

        public float GetScrollMaxX()
        {
            var ret = cbg_Tool_GetScrollMaxX(selfPtr);
            return ret;
        }

        public float GetScrollMaxY()
        {
            var ret = cbg_Tool_GetScrollMaxY(selfPtr);
            return ret;
        }

        public void SetScrollX(float scroll_x)
        {
            cbg_Tool_SetScrollX(selfPtr, scroll_x);
        }

        public void SetScrollY(float scroll_y)
        {
            cbg_Tool_SetScrollY(selfPtr, scroll_y);
        }

        public void SetScrollHereX(float center_x_ratio)
        {
            cbg_Tool_SetScrollHereX(selfPtr, center_x_ratio);
        }

        public void SetScrollHereY(float center_y_ratio)
        {
            cbg_Tool_SetScrollHereY(selfPtr, center_y_ratio);
        }

        public void SetScrollFromPosX(float local_x, float center_x_ratio)
        {
            cbg_Tool_SetScrollFromPosX(selfPtr, local_x, center_x_ratio);
        }

        public void SetScrollFromPosY(float local_y, float center_y_ratio)
        {
            cbg_Tool_SetScrollFromPosY(selfPtr, local_y, center_y_ratio);
        }

        public void PopFont()
        {
            cbg_Tool_PopFont(selfPtr);
        }

        public void PushStyleColor(ToolCol idx, int col)
        {
            cbg_Tool_PushStyleColor_ToolCol_int(selfPtr, (int)idx, col);
        }

        public void PushStyleColor(ToolCol idx, Vector4F col)
        {
            cbg_Tool_PushStyleColor_ToolCol_Vector4F_C(selfPtr, (int)idx, col);
        }

        public void PopStyleColor(int count)
        {
            cbg_Tool_PopStyleColor(selfPtr, count);
        }

        public void PushStyleVar(ToolStyleVar idx, float val)
        {
            cbg_Tool_PushStyleVar_ToolStyleVar_float(selfPtr, (int)idx, val);
        }

        public void PushStyleVar(ToolStyleVar idx, Vector2F val)
        {
            cbg_Tool_PushStyleVar_ToolStyleVar_Vector2F_C(selfPtr, (int)idx, val);
        }

        public void PopStyleVar(int count)
        {
            cbg_Tool_PopStyleVar(selfPtr, count);
        }

        public float GetFontSize()
        {
            var ret = cbg_Tool_GetFontSize(selfPtr);
            return ret;
        }

        public Vector2F GetFontTexUvWhitePixel()
        {
            var ret = cbg_Tool_GetFontTexUvWhitePixel(selfPtr);
            return ret;
        }

        public int GetColorU32(ToolCol idx, float alpha_mul)
        {
            var ret = cbg_Tool_GetColorU32_ToolCol_float(selfPtr, (int)idx, alpha_mul);
            return ret;
        }

        public int GetColorU32(Vector4F col)
        {
            var ret = cbg_Tool_GetColorU32_Vector4F_C(selfPtr, col);
            return ret;
        }

        public int GetColorU32(int col)
        {
            var ret = cbg_Tool_GetColorU32_int(selfPtr, col);
            return ret;
        }

        public void PushItemWidth(float item_width)
        {
            cbg_Tool_PushItemWidth(selfPtr, item_width);
        }

        public void PopItemWidth()
        {
            cbg_Tool_PopItemWidth(selfPtr);
        }

        public void SetNextItemWidth(float item_width)
        {
            cbg_Tool_SetNextItemWidth(selfPtr, item_width);
        }

        public float CalcItemWidth()
        {
            var ret = cbg_Tool_CalcItemWidth(selfPtr);
            return ret;
        }

        public void PushTextWrapPos(float wrap_local_pos_x)
        {
            cbg_Tool_PushTextWrapPos(selfPtr, wrap_local_pos_x);
        }

        public void PopTextWrapPos()
        {
            cbg_Tool_PopTextWrapPos(selfPtr);
        }

        public void PushAllowKeyboardFocus(bool allow_keyboard_focus)
        {
            cbg_Tool_PushAllowKeyboardFocus(selfPtr, allow_keyboard_focus);
        }

        public void PopAllowKeyboardFocus()
        {
            cbg_Tool_PopAllowKeyboardFocus(selfPtr);
        }

        public void PushButtonRepeat(bool repeat)
        {
            cbg_Tool_PushButtonRepeat(selfPtr, repeat);
        }

        public void PopButtonRepeat()
        {
            cbg_Tool_PopButtonRepeat(selfPtr);
        }

        /// <summary>
        /// 仕切りを生成します。
        /// </summary>
        public void Separator()
        {
            cbg_Tool_Separator(selfPtr);
        }

        public void SameLine(float offset_from_start_x, float spacing)
        {
            cbg_Tool_SameLine(selfPtr, offset_from_start_x, spacing);
        }

        public void NewLine()
        {
            cbg_Tool_NewLine(selfPtr);
        }

        public void Spacing()
        {
            cbg_Tool_Spacing(selfPtr);
        }

        /// <summary>
        /// 空白を生成します。
        /// </summary>
        /// <param name="size">空白のサイズ</param>
        public void Dummy(Vector2F size)
        {
            cbg_Tool_Dummy(selfPtr, size);
        }

        /// <summary>
        /// 次の要素を右にずらします。
        /// </summary>
        public void Indent(float indent_w)
        {
            cbg_Tool_Indent(selfPtr, indent_w);
        }

        /// <summary>
        /// 右にずらすインデントを1つ分打消します。
        /// </summary>
        public void Unindent(float indent_w)
        {
            cbg_Tool_Unindent(selfPtr, indent_w);
        }

        public void BeginGroup()
        {
            cbg_Tool_BeginGroup(selfPtr);
        }

        public void EndGroup()
        {
            cbg_Tool_EndGroup(selfPtr);
        }

        public Vector2F GetCursorPos()
        {
            var ret = cbg_Tool_GetCursorPos(selfPtr);
            return ret;
        }

        public float GetCursorPosX()
        {
            var ret = cbg_Tool_GetCursorPosX(selfPtr);
            return ret;
        }

        public float GetCursorPosY()
        {
            var ret = cbg_Tool_GetCursorPosY(selfPtr);
            return ret;
        }

        public void SetCursorPos(Vector2F local_pos)
        {
            cbg_Tool_SetCursorPos(selfPtr, local_pos);
        }

        public void SetCursorPosX(float local_x)
        {
            cbg_Tool_SetCursorPosX(selfPtr, local_x);
        }

        public void SetCursorPosY(float local_y)
        {
            cbg_Tool_SetCursorPosY(selfPtr, local_y);
        }

        public Vector2F GetCursorStartPos()
        {
            var ret = cbg_Tool_GetCursorStartPos(selfPtr);
            return ret;
        }

        public Vector2F GetCursorScreenPos()
        {
            var ret = cbg_Tool_GetCursorScreenPos(selfPtr);
            return ret;
        }

        public void SetCursorScreenPos(Vector2F pos)
        {
            cbg_Tool_SetCursorScreenPos(selfPtr, pos);
        }

        public void AlignTextToFramePadding()
        {
            cbg_Tool_AlignTextToFramePadding(selfPtr);
        }

        public float GetTextLineHeight()
        {
            var ret = cbg_Tool_GetTextLineHeight(selfPtr);
            return ret;
        }

        public float GetTextLineHeightWithSpacing()
        {
            var ret = cbg_Tool_GetTextLineHeightWithSpacing(selfPtr);
            return ret;
        }

        public float GetFrameHeight()
        {
            var ret = cbg_Tool_GetFrameHeight(selfPtr);
            return ret;
        }

        public float GetFrameHeightWithSpacing()
        {
            var ret = cbg_Tool_GetFrameHeightWithSpacing(selfPtr);
            return ret;
        }

        public void PushID(string str_id)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            cbg_Tool_PushID_char16p(selfPtr, str_id);
        }

        public void PushID(string str_id_begin, string str_id_end)
        {
            if (str_id_begin == null) throw new ArgumentNullException(nameof(str_id_begin), "引数がnullです");
            if (str_id_end == null) throw new ArgumentNullException(nameof(str_id_end), "引数がnullです");
            cbg_Tool_PushID_char16p_char16p(selfPtr, str_id_begin, str_id_end);
        }

        public void PushID(int int_id)
        {
            cbg_Tool_PushID_int(selfPtr, int_id);
        }

        public void PopID()
        {
            cbg_Tool_PopID(selfPtr);
        }

        public int GetID(string str_id)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_GetID_char16p(selfPtr, str_id);
            return ret;
        }

        public int GetID(string str_id_begin, string str_id_end)
        {
            if (str_id_begin == null) throw new ArgumentNullException(nameof(str_id_begin), "引数がnullです");
            if (str_id_end == null) throw new ArgumentNullException(nameof(str_id_end), "引数がnullです");
            var ret = cbg_Tool_GetID_char16p_char16p(selfPtr, str_id_begin, str_id_end);
            return ret;
        }

        public void TextUnformatted(string text, string text_end)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            if (text_end == null) throw new ArgumentNullException(nameof(text_end), "引数がnullです");
            cbg_Tool_TextUnformatted(selfPtr, text, text_end);
        }

        /// <summary>
        /// テキストを生成します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fmt"/>がnull</exception>
        public void Text(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_Text(selfPtr, fmt);
        }

        /// <summary>
        /// 色付きテキストを生成します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fmt"/>がnull</exception>
        public void TextColored(Vector4F col, string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_TextColored(selfPtr, col, fmt);
        }

        /// <summary>
        /// 灰字のテキストを生成します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fmt"/>がnull</exception>
        public void TextDisabled(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_TextDisabled(selfPtr, fmt);
        }

        public void TextWrapped(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_TextWrapped(selfPtr, fmt);
        }

        /// <summary>
        /// 横にラベルの付いたテキストを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="fmt"/>のいずれかがnull</exception>
        public void LabelText(string label, string fmt)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_LabelText(selfPtr, label, fmt);
        }

        /// <summary>
        /// 箇条書きテキストを生成します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fmt"/>がnull</exception>
        public void BulletText(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_BulletText(selfPtr, fmt);
        }

        /// <summary>
        /// ボタンを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool Button(string label, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Button(selfPtr, label, size);
            return ret;
        }

        /// <summary>
        /// 小さなボタンを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool SmallButton(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_SmallButton(selfPtr, label);
            return ret;
        }

        /// <summary>
        /// 見えないボタンを生成します。
        /// </summary>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>がnull</exception>
        public bool InvisibleButton(string str_id, Vector2F size, ToolButtonFlags flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_InvisibleButton(selfPtr, str_id, size, (int)flags);
            return ret;
        }

        /// <summary>
        /// 矢印ボタンを生成します。
        /// </summary>
        /// <param name="dir">矢印の向き</param>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>がnull</exception>
        public bool ArrowButton(string str_id, ToolDir dir)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_ArrowButton(selfPtr, str_id, (int)dir);
            return ret;
        }

        public bool Checkbox(string label, ref bool v)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Checkbox(selfPtr, label, ref v);
            return ret;
        }

        /// <summary>
        /// ラジオボタンを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="active">チェックが入っているかどうか</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool RadioButton(string label, bool active)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_RadioButton_char16p_bool(selfPtr, label, active);
            return ret;
        }

        /// <summary>
        /// ラジオボタンを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool RadioButton(string label, ref int v, int v_button)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_RadioButton_char16p_intp_int(selfPtr, label, ref v, v_button);
            return ret;
        }

        /// <summary>
        /// プログレスバーを生成します。
        /// </summary>
        /// <param name="fraction">進行度(0.0~1.0)</param>
        /// <param name="overlay">表示されるテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="overlay"/>がnull</exception>
        public void ProgressBar(float fraction, Vector2F size_arg, string overlay)
        {
            if (overlay == null) throw new ArgumentNullException(nameof(overlay), "引数がnullです");
            cbg_Tool_ProgressBar(selfPtr, fraction, size_arg, overlay);
        }

        /// <summary>
        /// 点を生成します。
        /// </summary>
        public void Bullet()
        {
            cbg_Tool_Bullet(selfPtr);
        }

        public bool BeginCombo(string label, string preview_value, ToolComboFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (preview_value == null) throw new ArgumentNullException(nameof(preview_value), "引数がnullです");
            var ret = cbg_Tool_BeginCombo(selfPtr, label, preview_value, (int)flags);
            return ret;
        }

        public void EndCombo()
        {
            cbg_Tool_EndCombo(selfPtr);
        }

        /// <summary>
        /// 1つのドラッグで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool DragFloat(string label, ref float v, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragFloat(selfPtr, label, ref v, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragFloat2(string label, FloatArray v, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragFloat2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragFloat3(string label, FloatArray v, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragFloat3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragFloat4(string label, FloatArray v, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragFloat4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 2つのドラッグで値が増減するバーを生成します
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>, <paramref name="format_max"/>のいずれかがnull</exception>
        public bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min, float v_max, string format, string format_max, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            if (format_max == null) throw new ArgumentNullException(nameof(format_max), "引数がnullです");
            var ret = cbg_Tool_DragFloatRange2(selfPtr, label, ref v_current_min, ref v_current_max, v_speed, v_min, v_max, format, format_max, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つのドラッグで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool DragInt(string label, ref int v, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragInt(selfPtr, label, ref v, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragInt2(string label, Int32Array v, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragInt2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragInt3(string label, Int32Array v, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragInt3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool DragInt4(string label, Int32Array v, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_DragInt4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_speed, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 2つのドラッグで値が増減するバーを生成します
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>, <paramref name="format_max"/>のいずれかがnull</exception>
        public bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min, int v_max, string format, string format_max, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            if (format_max == null) throw new ArgumentNullException(nameof(format_max), "引数がnullです");
            var ret = cbg_Tool_DragIntRange2(selfPtr, label, ref v_current_min, ref v_current_max, v_speed, v_min, v_max, format, format_max, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つのスライドで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool SliderFloat(string label, ref float v, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderFloat(selfPtr, label, ref v, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderFloat2(string label, FloatArray v, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderFloat2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderFloat3(string label, FloatArray v, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderFloat3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderFloat4(string label, FloatArray v, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderFloat4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// スライドで値が増減する，角度を扱うバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool SliderAngle(string label, ref float v_rad, float v_degrees_min, float v_degrees_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderAngle(selfPtr, label, ref v_rad, v_degrees_min, v_degrees_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つのスライドで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool SliderInt(string label, ref int v, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderInt(selfPtr, label, ref v, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderInt2(string label, Int32Array v, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderInt2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderInt3(string label, Int32Array v, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderInt3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        internal bool SliderInt4(string label, Int32Array v, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_SliderInt4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// スライドで値が増減する縦バーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool VSliderFloat(string label, Vector2F size, ref float v, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_VSliderFloat(selfPtr, label, size, ref v, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// スライドで値が増減する縦バーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool VSliderInt(string label, Vector2F size, ref int v, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_VSliderInt(selfPtr, label, size, ref v, v_min, v_max, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        public bool InputFloat(string label, ref float v, float step, float step_fast, string format, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_InputFloat(selfPtr, label, ref v, step, step_fast, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 2つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        internal bool InputFloat2(string label, FloatArray v, string format, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_InputFloat2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 3つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        internal bool InputFloat3(string label, FloatArray v, string format, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_InputFloat3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 4つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="format"/>のいずれかがnull</exception>
        internal bool InputFloat4(string label, FloatArray v, string format, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (format == null) throw new ArgumentNullException(nameof(format), "引数がnullです");
            var ret = cbg_Tool_InputFloat4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, format, (int)flags);
            return ret;
        }

        /// <summary>
        /// 1つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool InputInt(string label, ref int v, int step, int step_fast, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt(selfPtr, label, ref v, step, step_fast, (int)flags);
            return ret;
        }

        /// <summary>
        /// 2つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputInt2(string label, Int32Array v, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt2(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        /// <summary>
        /// 3つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputInt3(string label, Int32Array v, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt3(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        /// <summary>
        /// 4つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputInt4(string label, Int32Array v, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt4(selfPtr, label, v != null ? v.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        internal bool ColorPicker3(string label, FloatArray col, ToolColorEditFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorPicker3(selfPtr, label, col != null ? col.selfPtr : IntPtr.Zero, (int)flags);
            return ret;
        }

        internal bool ColorPicker4(string label, FloatArray col, ToolColorEditFlags flags, ref float ref_col)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorPicker4(selfPtr, label, col != null ? col.selfPtr : IntPtr.Zero, (int)flags, ref ref_col);
            return ret;
        }

        public void SetColorEditOptions(ToolColorEditFlags flags)
        {
            cbg_Tool_SetColorEditOptions(selfPtr, (int)flags);
        }

        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool TreeNode(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_TreeNode_char16p(selfPtr, label);
            return ret;
        }

        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>, <paramref name="fmt"/>のいずれかがnull</exception>
        public bool TreeNode(string str_id, string fmt)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            var ret = cbg_Tool_TreeNode_char16p_char16p(selfPtr, str_id, fmt);
            return ret;
        }

        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool TreeNodeEx(string label, ToolTreeNodeFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_TreeNodeEx_char16p_ToolTreeNodeFlags(selfPtr, label, (int)flags);
            return ret;
        }

        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>, <paramref name="fmt"/>のいずれかがnull</exception>
        public bool TreeNodeEx(string str_id, ToolTreeNodeFlags flags, string fmt)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            var ret = cbg_Tool_TreeNodeEx_char16p_ToolTreeNodeFlags_char16p(selfPtr, str_id, (int)flags, fmt);
            return ret;
        }

        public void TreePush(string str_id)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            cbg_Tool_TreePush(selfPtr, str_id);
        }

        /// <summary>
        /// TreeNodeのツリーを開きます。
        /// </summary>
        public void TreePop()
        {
            cbg_Tool_TreePop(selfPtr);
        }

        public float GetTreeNodeToLabelSpacing()
        {
            var ret = cbg_Tool_GetTreeNodeToLabelSpacing(selfPtr);
            return ret;
        }

        /// <summary>
        /// 折り畳み式のヘッダを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool CollapsingHeader(string label, ToolTreeNodeFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_CollapsingHeader_char16p_ToolTreeNodeFlags(selfPtr, label, (int)flags);
            return ret;
        }

        /// <summary>
        /// 折り畳み式のヘッダを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool CollapsingHeader(string label, ref bool p_open, ToolTreeNodeFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_CollapsingHeader_char16p_boolp_ToolTreeNodeFlags(selfPtr, label, ref p_open, (int)flags);
            return ret;
        }

        public void SetNextItemOpen(bool is_open, ToolCond cond)
        {
            cbg_Tool_SetNextItemOpen(selfPtr, is_open, (int)cond);
        }

        /// <summary>
        /// 選択式のテキストを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="selected">選択されているかどうか</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool Selectable(string label, bool selected, ToolSelectableFlags flags, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Selectable_char16p_bool_ToolSelectableFlags_Vector2F_C(selfPtr, label, selected, (int)flags, size);
            return ret;
        }

        /// <summary>
        /// 選択式のテキストを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool Selectable(string label, ref bool p_selected, ToolSelectableFlags flags, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Selectable_char16p_boolp_ToolSelectableFlags_Vector2F_C(selfPtr, label, ref p_selected, (int)flags, size);
            return ret;
        }

        public bool ListBoxHeader(string label, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ListBoxHeader_char16p_Vector2F_C(selfPtr, label, size);
            return ret;
        }

        public bool ListBoxHeader(string label, int items_count, int height_in_items)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ListBoxHeader_char16p_int_int(selfPtr, label, items_count, height_in_items);
            return ret;
        }

        public void ListBoxFooter()
        {
            cbg_Tool_ListBoxFooter(selfPtr);
        }

        public void Value(string prefix, bool b)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            cbg_Tool_Value_char16p_bool(selfPtr, prefix, b);
        }

        public void Value(string prefix, int v)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            cbg_Tool_Value_char16p_int(selfPtr, prefix, v);
        }

        public void Value(string prefix, float v, string float_format)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            if (float_format == null) throw new ArgumentNullException(nameof(float_format), "引数がnullです");
            cbg_Tool_Value_char16p_float_char16p(selfPtr, prefix, v, float_format);
        }

        /// <summary>
        /// 'EndMenuBar()' を呼び出してください
        /// </summary>
        public bool BeginMenuBar()
        {
            var ret = cbg_Tool_BeginMenuBar(selfPtr);
            return ret;
        }

        public void EndMenuBar()
        {
            cbg_Tool_EndMenuBar(selfPtr);
        }

        public bool BeginMainMenuBar()
        {
            var ret = cbg_Tool_BeginMainMenuBar(selfPtr);
            return ret;
        }

        public void EndMainMenuBar()
        {
            cbg_Tool_EndMainMenuBar(selfPtr);
        }

        /// <summary>
        /// 'EndMenu()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        public bool BeginMenu(string label, bool enabled)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_BeginMenu(selfPtr, label, enabled);
            return ret;
        }

        public void EndMenu()
        {
            cbg_Tool_EndMenu(selfPtr);
        }

        public bool MenuItem(string label, string shortcut, bool selected, bool enabled)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (shortcut == null) throw new ArgumentNullException(nameof(shortcut), "引数がnullです");
            var ret = cbg_Tool_MenuItem_char16p_char16p_bool_bool(selfPtr, label, shortcut, selected, enabled);
            return ret;
        }

        public bool MenuItem(string label, string shortcut, ref bool p_selected, bool enabled)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (shortcut == null) throw new ArgumentNullException(nameof(shortcut), "引数がnullです");
            var ret = cbg_Tool_MenuItem_char16p_char16p_boolp_bool(selfPtr, label, shortcut, ref p_selected, enabled);
            return ret;
        }

        /// <summary>
        /// 'EndTooltip()' を呼び出してください
        /// </summary>
        public void BeginTooltip()
        {
            cbg_Tool_BeginTooltip(selfPtr);
        }

        public void EndTooltip()
        {
            cbg_Tool_EndTooltip(selfPtr);
        }

        public void SetTooltip(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_SetTooltip(selfPtr, fmt);
        }

        /// <summary>
        /// 'EndPopup()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>がnull</exception>
        public bool BeginPopup(string str_id, ToolWindowFlags flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginPopup(selfPtr, str_id, (int)flags);
            return ret;
        }

        public void EndPopup()
        {
            cbg_Tool_EndPopup(selfPtr);
        }

        public void OpenPopup(string str_id, ToolPopupFlags popup_flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            cbg_Tool_OpenPopup(selfPtr, str_id, (int)popup_flags);
        }

        public void OpenPopupOnItemClick(string str_id, ToolPopupFlags popup_flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            cbg_Tool_OpenPopupOnItemClick(selfPtr, str_id, (int)popup_flags);
        }

        public void CloseCurrentPopup()
        {
            cbg_Tool_CloseCurrentPopup(selfPtr);
        }

        public bool BeginPopupContextItem(string str_id, ToolPopupFlags popup_flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginPopupContextItem(selfPtr, str_id, (int)popup_flags);
            return ret;
        }

        public bool BeginPopupContextWindow(string str_id, ToolPopupFlags popup_flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginPopupContextWindow(selfPtr, str_id, (int)popup_flags);
            return ret;
        }

        public bool BeginPopupContextVoid(string str_id, ToolPopupFlags popup_flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginPopupContextVoid(selfPtr, str_id, (int)popup_flags);
            return ret;
        }

        public bool IsPopupOpen(string str_id, ToolPopupFlags flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_IsPopupOpen(selfPtr, str_id, (int)flags);
            return ret;
        }

        public void Columns(int count, string id, bool border)
        {
            if (id == null) throw new ArgumentNullException(nameof(id), "引数がnullです");
            cbg_Tool_Columns(selfPtr, count, id, border);
        }

        public void NextColumn()
        {
            cbg_Tool_NextColumn(selfPtr);
        }

        public int GetColumnIndex()
        {
            var ret = cbg_Tool_GetColumnIndex(selfPtr);
            return ret;
        }

        public float GetColumnWidth(int column_index)
        {
            var ret = cbg_Tool_GetColumnWidth(selfPtr, column_index);
            return ret;
        }

        public void SetColumnWidth(int column_index, float width)
        {
            cbg_Tool_SetColumnWidth(selfPtr, column_index, width);
        }

        public float GetColumnOffset(int column_index)
        {
            var ret = cbg_Tool_GetColumnOffset(selfPtr, column_index);
            return ret;
        }

        public void SetColumnOffset(int column_index, float offset_x)
        {
            cbg_Tool_SetColumnOffset(selfPtr, column_index, offset_x);
        }

        public int GetColumnsCount()
        {
            var ret = cbg_Tool_GetColumnsCount(selfPtr);
            return ret;
        }

        /// <summary>
        /// 'EndTabBar()' を呼び出してください
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="str_id"/>がnull</exception>
        public bool BeginTabBar(string str_id, ToolTabBarFlags flags)
        {
            if (str_id == null) throw new ArgumentNullException(nameof(str_id), "引数がnullです");
            var ret = cbg_Tool_BeginTabBar(selfPtr, str_id, (int)flags);
            return ret;
        }

        public void EndTabBar()
        {
            cbg_Tool_EndTabBar(selfPtr);
        }

        public void EndTabItem()
        {
            cbg_Tool_EndTabItem(selfPtr);
        }

        public bool TabItemButton(string label, ToolTabItemFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_TabItemButton(selfPtr, label, (int)flags);
            return ret;
        }

        public void SetTabItemClosed(string tab_or_docked_window_label)
        {
            if (tab_or_docked_window_label == null) throw new ArgumentNullException(nameof(tab_or_docked_window_label), "引数がnullです");
            cbg_Tool_SetTabItemClosed(selfPtr, tab_or_docked_window_label);
        }

        public void SetNextWindowDockID(int dock_id, ToolCond cond)
        {
            cbg_Tool_SetNextWindowDockID(selfPtr, dock_id, (int)cond);
        }

        public int GetWindowDockID()
        {
            var ret = cbg_Tool_GetWindowDockID(selfPtr);
            return ret;
        }

        public bool IsWindowDocked()
        {
            var ret = cbg_Tool_IsWindowDocked(selfPtr);
            return ret;
        }

        public void LogToTTY(int auto_open_depth)
        {
            cbg_Tool_LogToTTY(selfPtr, auto_open_depth);
        }

        public void LogToFile(int auto_open_depth, string filename)
        {
            if (filename == null) throw new ArgumentNullException(nameof(filename), "引数がnullです");
            cbg_Tool_LogToFile(selfPtr, auto_open_depth, filename);
        }

        public void LogToClipboard(int auto_open_depth)
        {
            cbg_Tool_LogToClipboard(selfPtr, auto_open_depth);
        }

        public void LogFinish()
        {
            cbg_Tool_LogFinish(selfPtr);
        }

        public void LogButtons()
        {
            cbg_Tool_LogButtons(selfPtr);
        }

        public void LogText(string fmt)
        {
            if (fmt == null) throw new ArgumentNullException(nameof(fmt), "引数がnullです");
            cbg_Tool_LogText(selfPtr, fmt);
        }

        public bool BeginDragDropSource(ToolDragDropFlags flags)
        {
            var ret = cbg_Tool_BeginDragDropSource(selfPtr, (int)flags);
            return ret;
        }

        public void EndDragDropSource()
        {
            cbg_Tool_EndDragDropSource(selfPtr);
        }

        public bool BeginDragDropTarget()
        {
            var ret = cbg_Tool_BeginDragDropTarget(selfPtr);
            return ret;
        }

        public void EndDragDropTarget()
        {
            cbg_Tool_EndDragDropTarget(selfPtr);
        }

        public void PushClipRect(Vector2F clip_rect_min, Vector2F clip_rect_max, bool intersect_with_current_clip_rect)
        {
            cbg_Tool_PushClipRect(selfPtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect);
        }

        public void PopClipRect()
        {
            cbg_Tool_PopClipRect(selfPtr);
        }

        public void SetItemDefaultFocus()
        {
            cbg_Tool_SetItemDefaultFocus(selfPtr);
        }

        public void SetKeyboardFocusHere(int offset)
        {
            cbg_Tool_SetKeyboardFocusHere(selfPtr, offset);
        }

        public bool IsItemHovered(ToolHoveredFlags flags)
        {
            var ret = cbg_Tool_IsItemHovered(selfPtr, (int)flags);
            return ret;
        }

        public bool IsItemActive()
        {
            var ret = cbg_Tool_IsItemActive(selfPtr);
            return ret;
        }

        public bool IsItemFocused()
        {
            var ret = cbg_Tool_IsItemFocused(selfPtr);
            return ret;
        }

        public bool IsItemClicked(ToolMouseButton mouse_button)
        {
            var ret = cbg_Tool_IsItemClicked(selfPtr, (int)mouse_button);
            return ret;
        }

        public bool IsItemVisible()
        {
            var ret = cbg_Tool_IsItemVisible(selfPtr);
            return ret;
        }

        public bool IsItemEdited()
        {
            var ret = cbg_Tool_IsItemEdited(selfPtr);
            return ret;
        }

        public bool IsItemActivated()
        {
            var ret = cbg_Tool_IsItemActivated(selfPtr);
            return ret;
        }

        public bool IsItemDeactivated()
        {
            var ret = cbg_Tool_IsItemDeactivated(selfPtr);
            return ret;
        }

        public bool IsItemDeactivatedAfterEdit()
        {
            var ret = cbg_Tool_IsItemDeactivatedAfterEdit(selfPtr);
            return ret;
        }

        public bool IsItemToggledOpen()
        {
            var ret = cbg_Tool_IsItemToggledOpen(selfPtr);
            return ret;
        }

        public bool IsAnyItemHovered()
        {
            var ret = cbg_Tool_IsAnyItemHovered(selfPtr);
            return ret;
        }

        public bool IsAnyItemActive()
        {
            var ret = cbg_Tool_IsAnyItemActive(selfPtr);
            return ret;
        }

        public bool IsAnyItemFocused()
        {
            var ret = cbg_Tool_IsAnyItemFocused(selfPtr);
            return ret;
        }

        public Vector2F GetItemRectMin()
        {
            var ret = cbg_Tool_GetItemRectMin(selfPtr);
            return ret;
        }

        public Vector2F GetItemRectMax()
        {
            var ret = cbg_Tool_GetItemRectMax(selfPtr);
            return ret;
        }

        public Vector2F GetItemRectSize()
        {
            var ret = cbg_Tool_GetItemRectSize(selfPtr);
            return ret;
        }

        public void SetItemAllowOverlap()
        {
            cbg_Tool_SetItemAllowOverlap(selfPtr);
        }

        public bool IsRectVisible(Vector2F size)
        {
            var ret = cbg_Tool_IsRectVisible_Vector2F_C(selfPtr, size);
            return ret;
        }

        public bool IsRectVisible(Vector2F rect_min, Vector2F rect_max)
        {
            var ret = cbg_Tool_IsRectVisible_Vector2F_C_Vector2F_C(selfPtr, rect_min, rect_max);
            return ret;
        }

        public int GetFrameCount()
        {
            var ret = cbg_Tool_GetFrameCount(selfPtr);
            return ret;
        }

        public string GetStyleColorName(ToolCol idx)
        {
            var ret = cbg_Tool_GetStyleColorName(selfPtr, (int)idx);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        public void CalcListClipping(int items_count, float items_height, ref int out_items_display_start, ref int out_items_display_end)
        {
            cbg_Tool_CalcListClipping(selfPtr, items_count, items_height, ref out_items_display_start, ref out_items_display_end);
        }

        public bool BeginChildFrame(int id, Vector2F size, ToolWindowFlags flags)
        {
            var ret = cbg_Tool_BeginChildFrame(selfPtr, id, size, (int)flags);
            return ret;
        }

        public void EndChildFrame()
        {
            cbg_Tool_EndChildFrame(selfPtr);
        }

        public Vector2F CalcTextSize(string text, string text_end, bool hide_text_after_double_hash, float wrap_width)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            if (text_end == null) throw new ArgumentNullException(nameof(text_end), "引数がnullです");
            var ret = cbg_Tool_CalcTextSize(selfPtr, text, text_end, hide_text_after_double_hash, wrap_width);
            return ret;
        }

        public Vector4F ColorConvertU32ToFloat4(int in_)
        {
            var ret = cbg_Tool_ColorConvertU32ToFloat4(selfPtr, in_);
            return ret;
        }

        public int ColorConvertFloat4ToU32(Vector4F in_)
        {
            var ret = cbg_Tool_ColorConvertFloat4ToU32(selfPtr, in_);
            return ret;
        }

        public int GetKeyIndex(ToolKey imgui_key)
        {
            var ret = cbg_Tool_GetKeyIndex(selfPtr, (int)imgui_key);
            return ret;
        }

        public bool IsKeyDown(int user_key_index)
        {
            var ret = cbg_Tool_IsKeyDown(selfPtr, user_key_index);
            return ret;
        }

        public bool IsKeyPressed(int user_key_index, bool repeat)
        {
            var ret = cbg_Tool_IsKeyPressed(selfPtr, user_key_index, repeat);
            return ret;
        }

        public bool IsKeyReleased(int user_key_index)
        {
            var ret = cbg_Tool_IsKeyReleased(selfPtr, user_key_index);
            return ret;
        }

        public int GetKeyPressedAmount(int key_index, float repeat_delay, float rate)
        {
            var ret = cbg_Tool_GetKeyPressedAmount(selfPtr, key_index, repeat_delay, rate);
            return ret;
        }

        public void CaptureKeyboardFromApp(bool want_capture_keyboard_value)
        {
            cbg_Tool_CaptureKeyboardFromApp(selfPtr, want_capture_keyboard_value);
        }

        public bool IsMouseDown(ToolMouseButton button)
        {
            var ret = cbg_Tool_IsMouseDown(selfPtr, (int)button);
            return ret;
        }

        public bool IsMouseClicked(ToolMouseButton button, bool repeat)
        {
            var ret = cbg_Tool_IsMouseClicked(selfPtr, (int)button, repeat);
            return ret;
        }

        public bool IsMouseReleased(ToolMouseButton button)
        {
            var ret = cbg_Tool_IsMouseReleased(selfPtr, (int)button);
            return ret;
        }

        public bool IsMouseDoubleClicked(ToolMouseButton button)
        {
            var ret = cbg_Tool_IsMouseDoubleClicked(selfPtr, (int)button);
            return ret;
        }

        public bool IsMouseHoveringRect(Vector2F r_min, Vector2F r_max, bool clip)
        {
            var ret = cbg_Tool_IsMouseHoveringRect(selfPtr, r_min, r_max, clip);
            return ret;
        }

        public bool IsAnyMouseDown()
        {
            var ret = cbg_Tool_IsAnyMouseDown(selfPtr);
            return ret;
        }

        public Vector2F GetMousePos()
        {
            var ret = cbg_Tool_GetMousePos(selfPtr);
            return ret;
        }

        public Vector2F GetMousePosOnOpeningCurrentPopup()
        {
            var ret = cbg_Tool_GetMousePosOnOpeningCurrentPopup(selfPtr);
            return ret;
        }

        public bool IsMouseDragging(ToolMouseButton button, float lock_threshold)
        {
            var ret = cbg_Tool_IsMouseDragging(selfPtr, (int)button, lock_threshold);
            return ret;
        }

        public Vector2F GetMouseDragDelta(ToolMouseButton button, float lock_threshold)
        {
            var ret = cbg_Tool_GetMouseDragDelta(selfPtr, (int)button, lock_threshold);
            return ret;
        }

        public void ResetMouseDragDelta(ToolMouseButton button)
        {
            cbg_Tool_ResetMouseDragDelta(selfPtr, (int)button);
        }

        public void SetMouseCursor(ToolMouseCursor cursor_type)
        {
            cbg_Tool_SetMouseCursor(selfPtr, (int)cursor_type);
        }

        public void CaptureMouseFromApp(bool want_capture_mouse_value)
        {
            cbg_Tool_CaptureMouseFromApp(selfPtr, want_capture_mouse_value);
        }

        public string GetClipboardText()
        {
            var ret = cbg_Tool_GetClipboardText(selfPtr);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }

        public void SetClipboardText(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_SetClipboardText(selfPtr, text);
        }

        public void LoadIniSettingsFromDisk(string ini_filename)
        {
            if (ini_filename == null) throw new ArgumentNullException(nameof(ini_filename), "引数がnullです");
            cbg_Tool_LoadIniSettingsFromDisk(selfPtr, ini_filename);
        }

        public void SaveIniSettingsToDisk(string ini_filename)
        {
            if (ini_filename == null) throw new ArgumentNullException(nameof(ini_filename), "引数がnullです");
            cbg_Tool_SaveIniSettingsToDisk(selfPtr, ini_filename);
        }

        public void UpdatePlatformWindows()
        {
            cbg_Tool_UpdatePlatformWindows(selfPtr);
        }

        public void DestroyPlatformWindows()
        {
            cbg_Tool_DestroyPlatformWindows(selfPtr);
        }

        /// <summary>
        /// <see cref="Tool"/>のインスタンスを削除します。
        /// </summary>
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

}
