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
    /// 描画方法を表します。
    /// </summary>
    [Serializable]
    public enum GraphicsDevice : int
    {
        /// <summary>
        /// 実行環境をもとに自動選択
        /// </summary>
        Default,
        /// <summary>
        /// DirectX
        /// </summary>
        DirectX,
        /// <summary>
        /// Metal
        /// </summary>
        Metal,
        /// <summary>
        /// Vulkan
        /// </summary>
        Vulkan,
    }
    
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
        Sound = 128,
        Default = 191,
    }
    
    /// <summary>
    /// フレームレートモード
    /// </summary>
    [Serializable]
    public enum FramerateMode : int
    {
        /// <summary>
        /// 可変フレームレート
        /// </summary>
        Variable,
        /// <summary>
        /// 固定フレームレート
        /// </summary>
        Constant,
    }
    
    /// <summary>
    /// リソースの種類を表します。
    /// </summary>
    [Serializable]
    public enum ResourceType : int
    {
        /// <summary>
        /// <see cref="Altseed2.StaticFile"/>を表す
        /// </summary>
        StaticFile,
        /// <summary>
        /// <see cref="Altseed2.StreamFile"/>を表す
        /// </summary>
        StreamFile,
        /// <summary>
        /// <see cref="Altseed2.Texture2D"/>を表す
        /// </summary>
        Texture2D,
        /// <summary>
        /// <see cref="Altseed2.Font"/>を表す
        /// </summary>
        Font,
        /// <summary>
        /// <see cref="Altseed2.Sound"/>を表す
        /// </summary>
        Sound,
    }
    
    /// <summary>
    /// キーボードのキーの種類を表します。
    /// </summary>
    [Serializable]
    public enum Key : int
    {
        /// <summary>
        /// 未知のキー
        /// </summary>
        Unknown,
        Space,
        Apostrophe,
        Comma,
        Minus,
        Period,
        Slash,
        /// <summary>
        /// テンキーの0
        /// </summary>
        Num0,
        /// <summary>
        /// テンキーの1
        /// </summary>
        Num1,
        /// <summary>
        /// テンキーの2
        /// </summary>
        Num2,
        /// <summary>
        /// テンキーの3
        /// </summary>
        Num3,
        /// <summary>
        /// テンキーの4
        /// </summary>
        Num4,
        /// <summary>
        /// テンキーの5
        /// </summary>
        Num5,
        /// <summary>
        /// テンキーの6
        /// </summary>
        Num6,
        /// <summary>
        /// テンキーの7
        /// </summary>
        Num7,
        /// <summary>
        /// テンキーの8
        /// </summary>
        Num8,
        /// <summary>
        /// テンキーの9
        /// </summary>
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
        /// <summary>
        /// 矢印キー右
        /// </summary>
        Right,
        /// <summary>
        /// 矢印キー左
        /// </summary>
        Left,
        /// <summary>
        /// 矢印キー下
        /// </summary>
        Down,
        /// <summary>
        /// 矢印キー上
        /// </summary>
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
        /// <summary>
        /// 左側のShiftキー
        /// </summary>
        LeftShift,
        /// <summary>
        /// 左側のCtrlキー
        /// </summary>
        LeftControl,
        /// <summary>
        /// 左側のAltキー
        /// </summary>
        LeftAlt,
        /// <summary>
        /// 左側のWinキー
        /// </summary>
        LeftWin,
        /// <summary>
        /// 右側のShiftキー
        /// </summary>
        RightShift,
        /// <summary>
        /// 右側のCtrlキー
        /// </summary>
        RightControl,
        /// <summary>
        /// 右側のAltキー
        /// </summary>
        RightAlt,
        /// <summary>
        /// 右側のWinキー
        /// </summary>
        RightWin,
        Menu,
        Last,
    }
    
    /// <summary>
    /// ボタンの押下状態を表します。
    /// </summary>
    [Serializable]
    public enum ButtonState : int
    {
        /// <summary>
        /// ボタンが押されていない状態
        /// </summary>
        Free = 0,
        /// <summary>
        /// ボタンが押された瞬間の状態
        /// </summary>
        Push = 1,
        /// <summary>
        /// ボタンが押されている状態
        /// </summary>
        Hold = 3,
        /// <summary>
        /// ボタンが話された瞬間の状態
        /// </summary>
        Release = 2,
    }
    
    /// <summary>
    /// マウスのボタンの種類を表します。
    /// </summary>
    [Serializable]
    public enum MouseButton : int
    {
        /// <summary>
        /// 左ボタン
        /// </summary>
        ButtonLeft = 0,
        /// <summary>
        /// 中央ボタン
        /// </summary>
        ButtonRight = 1,
        /// <summary>
        /// 右ボタン
        /// </summary>
        ButtonMiddle = 2,
        /// <summary>
        /// サブボタン1
        /// </summary>
        SubButton1 = 3,
        /// <summary>
        /// サブボタン2
        /// </summary>
        SubButton2 = 4,
        /// <summary>
        /// サブボタン3
        /// </summary>
        SubButton3 = 5,
        /// <summary>
        /// サブボタン4
        /// </summary>
        SubButton4 = 6,
        /// <summary>
        /// サブボタン5
        /// </summary>
        SubButton5 = 7,
    }
    
    /// <summary>
    /// カーソルの状態を表します。
    /// </summary>
    [Serializable]
    public enum CursorMode : int
    {
        /// <summary>
        /// 通常の状態
        /// </summary>
        Normal = 212993,
        /// <summary>
        /// 隠れている状態
        /// </summary>
        Hidden = 212994,
        /// <summary>
        /// 使用できない状態
        /// </summary>
        Disable = 212995,
    }
    
    /// <summary>
    /// ジョイスティックの種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickType : int
    {
        /// <summary>
        /// 未知の種類のジョイスティック
        /// </summary>
        Other = 0,
        /// <summary>
        /// PlayStation DualShock3
        /// </summary>
        DualShock3 = 616,
        /// <summary>
        /// PlayStation DualShock4
        /// </summary>
        DualShock4 = 1476,
        /// <summary>
        /// PlayStation DualShock4Slim
        /// </summary>
        DualShock4Slim = 2508,
        /// <summary>
        /// XBOX360のジョイスティック
        /// </summary>
        XBOX360 = 654,
        /// <summary>
        /// NintendoSwitch 左のJon-Con
        /// </summary>
        JoyconL = 8198,
        /// <summary>
        /// NintendoSwitch 右のJon-Con
        /// </summary>
        JoyconR = 8199,
        /// <summary>
        /// NintendoSwitch ProController
        /// </summary>
        ProController = 8201,
    }
    
    /// <summary>
    /// ジョイスティックのボタンの種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickButton : int
    {
        /// <summary>
        /// 右側下ボタン
        /// </summary>
        RightDown = 0,
        /// <summary>
        /// 右側右ボタン
        /// </summary>
        RightRight = 1,
        /// <summary>
        /// 右側左ボタン
        /// </summary>
        RightLeft = 2,
        /// <summary>
        /// 右側上ボタン
        /// </summary>
        RightUp = 3,
        /// <summary>
        /// Lボタン
        /// </summary>
        LeftBumper = 4,
        /// <summary>
        /// Rボタン
        /// </summary>
        RightBumper = 5,
        /// <summary>
        /// 戻るボタン
        /// </summary>
        Back = 6,
        /// <summary>
        /// スタートボタン
        /// </summary>
        Start = 7,
        /// <summary>
        /// ガイドボタン
        /// </summary>
        Guide = 8,
        /// <summary>
        /// 左スティック押し込み
        /// </summary>
        LeftThumb = 9,
        /// <summary>
        /// 右スティック押し込み
        /// </summary>
        RightThumb = 10,
        /// <summary>
        /// 十字キー上
        /// </summary>
        DPadUp = 11,
        /// <summary>
        /// 十字キー右
        /// </summary>
        DPadRight = 12,
        /// <summary>
        /// 十字キー下
        /// </summary>
        DPadDown = 13,
        /// <summary>
        /// 十字キー左
        /// </summary>
        DPadLeft = 14,
    }
    
    /// <summary>
    /// ジョイスティックの軸の種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickAxis : int
    {
        /// <summary>
        /// 左スティック横
        /// </summary>
        LeftX = 0,
        /// <summary>
        /// 左スティック縦
        /// </summary>
        LeftY = 1,
        /// <summary>
        /// 右スティック横
        /// </summary>
        RightX = 2,
        /// <summary>
        /// 右スティック縦
        /// </summary>
        RightY = 3,
        /// <summary>
        /// 左トリガー
        /// </summary>
        LeftTrigger = 4,
        /// <summary>
        /// 右トリガー
        /// </summary>
        RightTrigger = 5,
    }
    
    [Serializable]
    public enum ShaderStage : int
    {
        Vertex,
        Pixel,
    }
    
    /// <summary>
    /// ビルド済みシェーダの種類を表します
    /// </summary>
    [Serializable]
    public enum BuiltinShaderType : int
    {
        SpriteUnlitVS,
        SpriteUnlitPS,
        FontUnlitPS,
    }
    
    /// <summary>
    /// テキストの描画方向
    /// </summary>
    [Serializable]
    public enum WritingDirection : int
    {
        /// <summary>
        /// 縦書き
        /// </summary>
        Vertical,
        /// <summary>
        /// 横書き
        /// </summary>
        Horizontal,
    }
    
    /// <summary>
    /// テクスチャをフィルタリングする方法を表します。
    /// </summary>
    [Serializable]
    public enum TextureFilter : int
    {
        Nearest,
        Linear,
    }
    
    /// <summary>
    /// テクスチャをサンプリングする方法を表します。
    /// </summary>
    [Serializable]
    public enum TextureWrapMode : int
    {
        Clamp,
        Repeat,
    }
    
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
    
    [Serializable]
    public enum BlendEquation : int
    {
        Add,
        Sub,
        ReverseSub,
        Min,
        Max,
    }
    
    [Serializable]
    public enum BlendFunction : int
    {
        Zero,
        One,
        SrcColor,
        OneMinusSrcColor,
        SrcAlpha,
        OneMinusSrcAlpha,
        DstAlpha,
        OneMinusDstAlpha,
        DstColor,
        OneMinusDstColor,
    }
    
    /// <summary>
    /// ツール機能の使用方法(描画位置)
    /// </summary>
    [Serializable]
    public enum ToolUsage : int
    {
        /// <summary>
        /// 画面の上に表示
        /// </summary>
        Overwrapped = 0,
        /// <summary>
        /// 画面を表示せずにツールのみ表示
        /// </summary>
        Main = 1,
    }
    
    /// <summary>
    /// ツール機能で使用する方向
    /// </summary>
    [Serializable]
    public enum ToolDir : int
    {
        None = -1,
        /// <summary>
        /// 左方向
        /// </summary>
        Left = 0,
        /// <summary>
        /// 右方向
        /// </summary>
        Right = 1,
        /// <summary>
        /// 上方向
        /// </summary>
        Up = 2,
        /// <summary>
        /// 下方向
        /// </summary>
        Down = 3,
    }
    
    /// <summary>
    /// バイナリ演算子を使用して複数の値を結合しないでください
    /// </summary>
    [Serializable]
    public enum ToolCond : int
    {
        None = 0,
        /// <summary>
        /// 常に変数を設定します
        /// </summary>
        Always = 1,
        /// <summary>
        /// ランタイムセッションごとに変数を1回設定します（成功した最初の呼び出しのみ）
        /// </summary>
        Once = 2,
        /// <summary>
        /// オブジェクト/ウィンドウに永続的に保存されたデータがない場合（.iniファイルにエントリがない場合）、変数を設定します
        /// </summary>
        FirstUseEver = 4,
        /// <summary>
        /// オブジェクト/ウィンドウが非表示/非アクティブになった後（または初めて）表示される場合は、変数を設定します
        /// </summary>
        Appearing = 8,
    }
    
    /// <summary>
    /// ツール機能のTreeNodeに適用する設定を表します。
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolTreeNodeFlags : int
    {
        None = 0,
        /// <summary>
        /// Draw as selected
        /// </summary>
        Selected = 1,
        /// <summary>
        /// 
        /// </summary>
        Framed = 2,
        /// <summary>
        /// 
        /// </summary>
        AllowItemOverlap = 4,
        /// <summary>
        /// 
        /// </summary>
        NoTreePushOnOpen = 8,
        /// <summary>
        /// 
        /// </summary>
        NoAutoOpenOnLog = 16,
        /// <summary>
        /// 
        /// </summary>
        DefaultOpen = 32,
        /// <summary>
        /// 
        /// </summary>
        OpenOnDoubleClick = 64,
        /// <summary>
        /// 
        /// </summary>
        OpenOnArrow = 128,
        /// <summary>
        /// 
        /// </summary>
        Leaf = 256,
        /// <summary>
        /// 
        /// </summary>
        Bullet = 512,
        /// <summary>
        /// 
        /// </summary>
        FramePadding = 1024,
        /// <summary>
        /// 
        /// </summary>
        SpanAvailWidth = 2048,
        /// <summary>
        /// 
        /// </summary>
        SpanFullWidth = 4096,
        /// <summary>
        /// 
        /// </summary>
        NavLeftJumpsBackHere = 8192,
        CollapsingHeader = 26,
    }
    
    /// <summary>
    /// ツール機能においてインプットされるテキストの設定を表します
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolInputTextFlags : int
    {
        None = 0,
        /// <summary>
        /// 0123456789.+-*/ を許可します。
        /// </summary>
        CharsDecimal = 1,
        /// <summary>
        /// 0123456789ABCDEFabcdef を許可します
        /// </summary>
        CharsHexadecimal = 2,
        /// <summary>
        /// a..z を A..Z に変換します
        /// </summary>
        CharsUppercase = 4,
        /// <summary>
        /// スペースとタブを除外します
        /// </summary>
        CharsNoBlank = 8,
        /// <summary>
        /// 最初にマウスフォーカスしたときにテキスト全体を選択します
        /// </summary>
        AutoSelectAll = 16,
        /// <summary>
        /// （値が変更されるたびにではなく）Enterが押されたときに 'true' を返します。 'IsItemDeactivatedAfterEdit()' 関数を調べることを検討してください。
        /// </summary>
        EnterReturnsTrue = 32,
        /// <summary>
        /// Tabキーを押したときのコールバック（完了処理のため）
        /// </summary>
        CallbackCompletion = 64,
        /// <summary>
        /// 上下矢印を押すとコールバック（履歴処理用）
        /// </summary>
        CallbackHistory = 128,
        /// <summary>
        /// 各反復でのコールバック。 ユーザーコードは、カーソル位置を照会し、テキストバッファーを変更できます。
        /// </summary>
        CallbackAlways = 256,
        /// <summary>
        /// 置換または破棄する文字入力のコールバック。 'EventChar'を変更して置換または破棄するか、コールバックで1を返して破棄します。
        /// </summary>
        CallbackCharFilter = 512,
        /// <summary>
        /// Tabキーを押すと、テキストフィールドに'\t'という文字が入力されます。
        /// </summary>
        AllowTabInput = 1024,
        /// <summary>
        /// 複数行モードでは、Enterでフォーカスを外し、Ctrl + Enterで新しい行を追加します（デフォルトは反対です：Ctrl + Enterでフォーカスを外し、Enterで行を追加します）。
        /// </summary>
        CtrlEnterForNewLine = 2048,
        /// <summary>
        /// カーソルの水平方向のフォローを無効にする
        /// </summary>
        NoHorizontalScroll = 4096,
        /// <summary>
        /// インサートモード
        /// </summary>
        AlwaysInsertMode = 8192,
        /// <summary>
        /// 読み取り専用モード
        /// </summary>
        ReadOnly = 16384,
        /// <summary>
        /// パスワードモード。すべての文字を'*'として表示します。
        /// </summary>
        Password = 32768,
        /// <summary>
        /// 元に戻す/やり直しを無効にします。 アクティブな間は入力テキストがテキストデータを所有していることに注意してください。独自の元に戻す/やり直しスタックを提供する場合は、たとえば ClearActiveID（）を呼び出します。
        /// </summary>
        NoUndoRedo = 65536,
        /// <summary>
        /// 0123456789.+-*/eE (科学表記法の入力) を許可します
        /// </summary>
        CharsScientific = 131072,
        /// <summary>
        /// バッファ容量のコールバックはリクエストを変更し（'buf_size 'パラメータ値を超えて）、文字列が大きくなります。 文字列のサイズを変更する必要がある場合に通知します（サイズのキャッシュを保持する文字列タイプの場合）。 コールバックで新しいBufSizeが提供され、それを尊重する必要があります。
        /// </summary>
        CallbackResize = 262144,
    }
    
    /// <summary>
    /// ツール機能における色の設定を表します
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolColorEditFlags : int
    {
        None = 0,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': Alphaコンポーネントを無視します（入力ポインターから3つのコンポーネントのみを読み取ります）。
        /// </summary>
        NoAlpha = 2,
        /// <summary>
        /// 'ColorEdit': 色付きの正方形をクリックしたときにピッカーを無効にします。
        /// </summary>
        NoPicker = 4,
        /// <summary>
        /// 'ColorEdit': 入力/小さなプレビューを右クリックしたときのオプションメニューの切り替えを無効にします。
        /// </summary>
        NoOptions = 8,
        /// <summary>
        /// 'ColorEdit, ColorPicker': 入力の横にある色付きの正方形プレビューを無効にします。 （例：入力のみを表示する）
        /// </summary>
        NoSmallPreview = 16,
        /// <summary>
        /// 'ColorEdit, ColorPicker: 入力スライダー/テキストウィジェットを無効にします（たとえば、小さなプレビューの色付きの四角形のみを表示します）。
        /// </summary>
        NoInputs = 32,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': プレビューをホバーするときにツールチップを無効にします。
        /// </summary>
        NoTooltip = 64,
        /// <summary>
        /// 'ColorEdit, ColorPicker': インラインテキストラベルの表示を無効にします（ラベルは引き続きツールチップとピッカーに転送されます）。
        /// </summary>
        NoLabel = 128,
        /// <summary>
        /// 'ColorPicker': ピッカーの右側の大きなカラープレビューを無効にし、代わりに小さな色付きの正方形プレビューを使用します。
        /// </summary>
        NoSidePreview = 256,
        /// <summary>
        /// 'ColorEdit': ドラッグアンドドロップターゲットを無効にします。 'ColorButton': ドラッグアンドドロップソースを無効にします。
        /// </summary>
        NoDragDrop = 512,
        /// <summary>
        /// 'ColorEdit, ColorPicker': ピッカーに垂直アルファバー/グラデーションを表示します。
        /// </summary>
        AlphaBar = 65536,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': プレビューを不透明ではなく、チェッカーボード上の透明色として表示します。
        /// </summary>
        AlphaPreview = 131072,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': 不透明ではなく、半不透明/半市松模様を表示します。
        /// </summary>
        AlphaPreviewHalf = 262144,
        /// <summary>
        /// '(WIP) ColorEdit': 現在、RGBAエディションで0.0f..1.0fの制限のみを無効にします（注：おそらくFloatフラグも使用したいでしょう）。
        /// </summary>
        HDR = 524288,
        /// <summary>
        /// 'ColorEdit': RGB/HSV/Hexの_display_タイプをオーバーライドします。 'ColorPicker': 1つ以上のRGB/HSV/Hexを使用して任意の組み合わせを選択します。
        /// </summary>
        DisplayRGB = 1048576,
        /// <summary>
        /// 
        /// </summary>
        DisplayHSV = 2097152,
        /// <summary>
        /// 
        /// </summary>
        DisplayHex = 4194304,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': 0..255としてフォーマットされた_display_値。
        /// </summary>
        Uint8 = 8388608,
        /// <summary>
        /// 'ColorEdit, ColorPicker, ColorButton': _display_値は、0..255整数ではなく0.0f..1.0f浮動小数点としてフォーマットされます。 整数による値の往復はありません。
        /// </summary>
        Float = 16777216,
        /// <summary>
        /// 'ColorPicker': Hueのバー、Sat/Valueの長方形。
        /// </summary>
        PickerHueBar = 33554432,
        /// <summary>
        /// 'ColorPicker': Hueのホイール、Sat/Valueの三角形。
        /// </summary>
        PickerHueWheel = 67108864,
        /// <summary>
        /// 'ColorEdit, ColorPicker': RGB形式の入出力データ
        /// </summary>
        InputRGB = 134217728,
        /// <summary>
        /// 'ColorEdit, ColorPicker': HSV形式の入力および出力データ。
        /// </summary>
        InputHSV = 268435456,
        /// <summary>
        /// デフォルトオプション。 'SetColorEditOptions()' を使用して、アプリケーションのデフォルトを設定できます。 意図はおそらくあなたの呼び出しのほとんどでそれらをオーバーライドしたくないことです。 ユーザーがオプションメニューから選択できるようにするか、起動時に'SetColorEditOptions()'を1回呼び出します。
        /// </summary>
        OptionsDefault = 177209344,
    }
    
    /// <summary>
    /// ツール機能のSelectableに適用する設定を表します。
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolSelectableFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// このボタンをクリックしても、親ポップアップウィンドウは閉じません
        /// </summary>
        DontClosePopups = 1,
        /// <summary>
        /// 選択可能なフレームはすべての列にまたがることができます（テキストは現在の列に収まります）
        /// </summary>
        SpanAllColumns = 2,
        /// <summary>
        /// ダブルクリックした場合もプレスイベントを生成
        /// </summary>
        AllowDoubleClick = 4,
        /// <summary>
        /// 選択できません、グレー表示されたテキストを表示します
        /// </summary>
        Disabled = 8,
        /// <summary>
        /// (WIP) ヒットテストにより、後続のウィジェットがこのウィジェットとオーバーラップできるようにします
        /// </summary>
        AllowItemOverlap = 16,
    }
    
    /// <summary>
    /// ツール機能のウィンドウにおける設定を表します
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolWindowFlags : int
    {
        None = 0,
        /// <summary>
        /// タイトルバーを無効にする
        /// </summary>
        NoTitleBar = 1,
        /// <summary>
        /// 右下のグリップを使ったユーザーのサイズ変更を無効にします
        /// </summary>
        NoResize = 2,
        /// <summary>
        /// ユーザーがウィンドウを移動できないようにする
        /// </summary>
        NoMove = 4,
        /// <summary>
        /// スクロールバーを無効にします（ウィンドウはマウスまたはプログラムでスクロールできます）
        /// </summary>
        NoScrollbar = 8,
        /// <summary>
        /// ユーザーがマウスホイールで垂直にスクロールできないようにします。 子ウィンドウでは、NoScrollbarも設定されていない限り、マウスホイールは親に転送されます。
        /// </summary>
        NoScrollWithMouse = 16,
        /// <summary>
        /// ユーザー折りたたみウィンドウをダブルクリックして無効にします
        /// </summary>
        NoCollapse = 32,
        /// <summary>
        /// フレームごとにコンテンツごとにウィンドウのサイズを変更します
        /// </summary>
        AlwaysAutoResize = 64,
        /// <summary>
        /// 描画背景色('WindowBg'など)および外枠を無効にします。 'SetNextWindowBgAlpha(0.0f)'を使用する場合と同様です。
        /// </summary>
        NoBackground = 128,
        /// <summary>
        /// .iniファイルの設定をロード/保存しない
        /// </summary>
        NoSavedSettings = 256,
        /// <summary>
        /// パススルーでテストをホバリング、キャッチマウスを無効にします。
        /// </summary>
        NoMouseInputs = 512,
        /// <summary>
        /// メニューバーがあります
        /// </summary>
        MenuBar = 1024,
        /// <summary>
        /// 水平スクロールバーの表示を許可します（デフォルトではオフ）。 'Begin()'を呼び出す前に、'SetNextWindowContentSize(Vector2F(width, 0.0f));'を使用して幅を指定できます。
        /// </summary>
        HorizontalScrollbar = 2048,
        /// <summary>
        /// 非表示から表示状態に移行するときにフォーカスを取得できないようにします
        /// </summary>
        NoFocusOnAppearing = 4096,
        /// <summary>
        /// フォーカスを取得するときにウィンドウを前面に移動することを無効にします（たとえば、クリックするか、プログラムでフォーカスを与える）
        /// </summary>
        NoBringToFrontOnFocus = 8192,
        /// <summary>
        /// 常に垂直スクロールバーを表示します（'ContentSize.Y &lt; Size.Y'の場合でも）
        /// </summary>
        AlwaysVerticalScrollbar = 16384,
        /// <summary>
        /// 常に水平スクロールバーを表示します（'ContentSize.x &lt; Size.x'であっても）
        /// </summary>
        AlwaysHorizontalScrollbar = 32768,
        /// <summary>
        /// 境界線のない子ウィンドウが'style.WindowPadding'を使用するようにします（境界線のない子ウィンドウではデフォルトで無視されるため、より便利です）
        /// </summary>
        AlwaysUseWindowPadding = 65536,
        /// <summary>
        /// ウィンドウ内にゲームパッド/キーボードナビゲーションはありません
        /// </summary>
        NoNavInputs = 262144,
        /// <summary>
        /// ゲームパッド/キーボードナビゲーションでこのウィンドウにフォーカスしない（たとえば、CTRL + TABでスキップ）
        /// </summary>
        NoNavFocus = 524288,
        /// <summary>
        /// ###演算子の使用を避けるために、IDに影響を与えずにタイトルに'*'を追加します。 タブ/ドッキングコンテキストで使用する場合、クロージャーでタブが選択され、クロージャーは1フレーム延期され、コードがちらつきなしに（確認ポップアップなどを使用して）クロージャーをキャンセルできるようにします。
        /// </summary>
        UnsavedDocument = 1048576,
        NoNav = 786432,
        NoDecoration = 43,
        NoInputs = 786944,
    }
    
    /// <summary>
    /// ツール機能のタブバーにおける設定を表します
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolTabBarFlags : int
    {
        None = 0,
        /// <summary>
        /// タブを手動でドラッグして並べ替えることができます+リストの最後に新しいタブが追加されます
        /// </summary>
        Reorderable = 1,
        /// <summary>
        /// 新しいタブが表示されたら自動的に選択する
        /// </summary>
        AutoSelectNewTabs = 2,
        /// <summary>
        /// ボタンを無効にしてタブリストポップアップを開きます
        /// </summary>
        TabListPopupButton = 4,
        /// <summary>
        /// マウスの中ボタンでタブを閉じる（p_open！= NULLで送信される）動作を無効にします。 'if（IsItemHovered（）&amp;&amp; IsMouseClicked（2））* p_open = false'を使用すると、ユーザー側でこの動作を再現できます。
        /// </summary>
        NoCloseWithMiddleMouseButton = 8,
        /// <summary>
        /// スクロールボタンを無効にする（フィッティングポリシーが'FittingPolicyScroll'の場合に適用）
        /// </summary>
        NoTabListScrollingButtons = 16,
        /// <summary>
        /// タブをホバーするときにツールチップを無効にする
        /// </summary>
        NoTooltip = 32,
        /// <summary>
        /// 収まらないタブのサイズを変更する
        /// </summary>
        FittingPolicyResizeDown = 64,
        /// <summary>
        /// タブが収まらない場合にスクロールボタンを追加する
        /// </summary>
        FittingPolicyScroll = 128,
        FittingPolicyMask = 192,
        FittingPolicyDefault = 64,
    }
    
    /// <summary>
    /// ツール機能を使ってフォントを読み込む際の範囲を指定します。ビット演算は行わないでください。
    /// </summary>
    [Serializable]
    public enum ToolGlyphRange : int
    {
        Default,
        /// <summary>
        /// キリル文字
        /// </summary>
        Cyrillic,
        /// <summary>
        /// 日本語
        /// </summary>
        Japanese,
        /// <summary>
        /// 繁体字中国語
        /// </summary>
        ChineseFull,
        /// <summary>
        /// 簡体字中国語
        /// </summary>
        ChineseSimplifiedCommon,
        /// <summary>
        /// 韓国語
        /// </summary>
        Korean,
        /// <summary>
        /// タイ語
        /// </summary>
        Thai,
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum ToolFocused : int
    {
        None,
        /// <summary>
        /// 
        /// </summary>
        ChildWindows,
        /// <summary>
        /// 
        /// </summary>
        RootWindow,
        /// <summary>
        /// 
        /// </summary>
        AnyWindow,
        /// <summary>
        /// 
        /// </summary>
        RootAndChildWindows,
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum ToolColor : int
    {
        /// <summary>
        /// 
        /// </summary>
        Text,
        /// <summary>
        /// 
        /// </summary>
        TextDisabled,
        /// <summary>
        /// 
        /// </summary>
        WindowBg,
        /// <summary>
        /// 
        /// </summary>
        ChildBg,
        /// <summary>
        /// 
        /// </summary>
        PopupBg,
        /// <summary>
        /// 
        /// </summary>
        Border,
        /// <summary>
        /// 
        /// </summary>
        BorderShadow,
        /// <summary>
        /// 
        /// </summary>
        FrameBg,
        /// <summary>
        /// 
        /// </summary>
        FrameBgHovered,
        /// <summary>
        /// 
        /// </summary>
        FrameBgActive,
        /// <summary>
        /// 
        /// </summary>
        TitleBg,
        /// <summary>
        /// 
        /// </summary>
        TitleBgActive,
        /// <summary>
        /// 
        /// </summary>
        TitleBgCollapsed,
        /// <summary>
        /// 
        /// </summary>
        MenuBarBg,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarBg,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarGrab,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarGrabHovered,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarGrabActive,
        /// <summary>
        /// 
        /// </summary>
        CheckMark,
        /// <summary>
        /// 
        /// </summary>
        SliderGrab,
        /// <summary>
        /// 
        /// </summary>
        SliderGrabActive,
        /// <summary>
        /// 
        /// </summary>
        Button,
        /// <summary>
        /// 
        /// </summary>
        ButtonHovered,
        /// <summary>
        /// 
        /// </summary>
        ButtonActive,
        /// <summary>
        /// 
        /// </summary>
        Header,
        /// <summary>
        /// 
        /// </summary>
        HeaderHovered,
        /// <summary>
        /// 
        /// </summary>
        HeaderActive,
        /// <summary>
        /// 
        /// </summary>
        Separator,
        /// <summary>
        /// 
        /// </summary>
        SeparatorHovered,
        /// <summary>
        /// 
        /// </summary>
        SeparatorActive,
        /// <summary>
        /// 
        /// </summary>
        ResizeGrip,
        /// <summary>
        /// 
        /// </summary>
        ResizeGripHovered,
        /// <summary>
        /// 
        /// </summary>
        ResizeGripActive,
        /// <summary>
        /// 
        /// </summary>
        Tab,
        /// <summary>
        /// 
        /// </summary>
        TabHovered,
        /// <summary>
        /// 
        /// </summary>
        TabActive,
        /// <summary>
        /// 
        /// </summary>
        TabUnfocused,
        /// <summary>
        /// 
        /// </summary>
        TabUnfocusedActive,
        /// <summary>
        /// 
        /// </summary>
        PlotLines,
        /// <summary>
        /// 
        /// </summary>
        PlotLinesHovered,
        /// <summary>
        /// 
        /// </summary>
        PlotHistogram,
        /// <summary>
        /// 
        /// </summary>
        PlotHistogramHovered,
        /// <summary>
        /// 
        /// </summary>
        TextSelectedBg,
        /// <summary>
        /// 
        /// </summary>
        DragDropTarget,
        /// <summary>
        /// 
        /// </summary>
        NavHighlight,
        /// <summary>
        /// 
        /// </summary>
        NavWindowingHighlight,
        /// <summary>
        /// 
        /// </summary>
        NavWindowingDimBg,
        /// <summary>
        /// 
        /// </summary>
        ModalWindowDimBg,
        /// <summary>
        /// 
        /// </summary>
        COUNT,
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum ToolStyleVar : int
    {
        /// <summary>
        /// 
        /// </summary>
        Alpha,
        /// <summary>
        /// 
        /// </summary>
        WindowPadding,
        /// <summary>
        /// 
        /// </summary>
        WindowRounding,
        /// <summary>
        /// 
        /// </summary>
        WindowBorderSize,
        /// <summary>
        /// 
        /// </summary>
        WindowMinSize,
        /// <summary>
        /// 
        /// </summary>
        WindowTitleAlign,
        /// <summary>
        /// 
        /// </summary>
        ChildRounding,
        /// <summary>
        /// 
        /// </summary>
        ChildBorderSize,
        /// <summary>
        /// 
        /// </summary>
        PopupRounding,
        /// <summary>
        /// 
        /// </summary>
        PopupBorderSize,
        /// <summary>
        /// 
        /// </summary>
        FramePadding,
        /// <summary>
        /// 
        /// </summary>
        FrameRounding,
        /// <summary>
        /// 
        /// </summary>
        FrameBorderSize,
        /// <summary>
        /// 
        /// </summary>
        ItemSpacing,
        /// <summary>
        /// 
        /// </summary>
        ItemInnerSpacing,
        /// <summary>
        /// 
        /// </summary>
        IndentSpacing,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarSize,
        /// <summary>
        /// 
        /// </summary>
        ScrollbarRounding,
        /// <summary>
        /// 
        /// </summary>
        GrabMinSize,
        /// <summary>
        /// 
        /// </summary>
        GrabRounding,
        /// <summary>
        /// 
        /// </summary>
        TabRounding,
        /// <summary>
        /// 
        /// </summary>
        ButtonTextAlign,
        /// <summary>
        /// 
        /// </summary>
        SelectableTextAlign,
        /// <summary>
        /// 
        /// </summary>
        COUNT,
    }
    
    /// <summary>
    /// ツール機能のBeginComboに適用する設定を表します。
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolComboFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        PopupAlignLeft,
        /// <summary>
        /// 
        /// </summary>
        HeightSmall,
        /// <summary>
        /// 
        /// </summary>
        HeightRegular,
        /// <summary>
        /// 
        /// </summary>
        HeightLarge,
        /// <summary>
        /// 
        /// </summary>
        HeightLargest,
        /// <summary>
        /// 
        /// </summary>
        NoArrowButton,
        /// <summary>
        /// 
        /// </summary>
        NoPreview,
        /// <summary>
        /// 
        /// </summary>
        HeightMask_,
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    [Serializable]
    public enum ToolHoveredFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        ChildWindows,
        /// <summary>
        /// 
        /// </summary>
        RootWindow,
        /// <summary>
        /// 
        /// </summary>
        AnyWindow,
        /// <summary>
        /// 
        /// </summary>
        AllowWhenBlockedByPopup,
        /// <summary>
        /// 
        /// </summary>
        AllowWhenBlockedByActiveItem,
        /// <summary>
        /// 
        /// </summary>
        AllowWhenOverlapped,
        /// <summary>
        /// 
        /// </summary>
        AllowWhenDisabled,
        /// <summary>
        /// 
        /// </summary>
        RectOnly,
        /// <summary>
        /// 
        /// </summary>
        RootAndChildWindows,
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
    /// Altseed2 の設定を表すクラス
    /// </summary>
    [Serializable]
    public sealed partial class Configuration : ISerializable
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Configuration>> cacheRepo = new Dictionary<IntPtr, WeakReference<Configuration>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// C++のCoreとの仲介を担うクラス
    /// </summary>
    internal sealed partial class Core
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Core>> cacheRepo = new Dictionary<IntPtr, WeakReference<Core>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Core_GetBaseObjectCount(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_PrintAllBaseObjectName(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_Initialize([MarshalAs(UnmanagedType.LPWStr)] string title, int width, int height, IntPtr config);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Core_DoEvent(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_Terminate();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Core_GetInstance();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Core_GetDeltaSecond(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Core_GetCurrentFPS(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Core_GetTargetFPS(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Core_SetTargetFPS(IntPtr selfPtr, float value);
        
        
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
        internal float TargetFPS
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
        /// 内部オブジェクトの数を取得します。
        /// </summary>
        /// <returns>数</returns>
        internal int GetBaseObjectCount()
        {
            var ret = cbg_Core_GetBaseObjectCount(selfPtr);
            return ret;
        }
        
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
    /// 8ビット整数の配列のクラスを表します。
    /// </summary>
    [Serializable]
    internal sealed partial class Int8Array : ISerializable, ICacheKeeper<Int8Array>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Int8Array>> cacheRepo = new Dictionary<IntPtr, WeakReference<Int8Array>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                internal static  Vector2FArray TryGetFromCache(IntPtr native)
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
    /// リソースのクラスを表します。
    /// </summary>
    internal sealed partial class Resources
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Resources>> cacheRepo = new Dictionary<IntPtr, WeakReference<Resources>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// カーソルを表します。
    /// </summary>
    public sealed partial class Cursor
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Cursor>> cacheRepo = new Dictionary<IntPtr, WeakReference<Cursor>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  Cursor TryGetFromCache(IntPtr native)
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
        /// <returns>指定したpng画像を読み込んだ<see cref="Cursor"/>のインスタンス</returns>
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
    /// キーボードを表します。
    /// </summary>
    public sealed partial class Keyboard
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Keyboard>> cacheRepo = new Dictionary<IntPtr, WeakReference<Keyboard>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Keyboard_GetKeyState(IntPtr selfPtr, int key);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Keyboard_GetInstance();
        
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
        /// キーの状態を取得します。
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>ボタンの押下状態</returns>
        public ButtonState GetKeyState(Key key)
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Mouse_GetInstance();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Mouse_GetMouseButtonState(IntPtr selfPtr, int button);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetCursorImage(IntPtr selfPtr, IntPtr cursor);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Mouse_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetPosition(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Mouse_GetCursorMode(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Mouse_SetCursorMode(IntPtr selfPtr, int value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Mouse_GetWheel(IntPtr selfPtr);
        
        
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
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Mouse GetInstance()
        {
            var ret = cbg_Mouse_GetInstance();
            return Mouse.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// マウスボタンの状態を取得します。
        /// </summary>
        /// <param name="button">状態を取得するマウスのボタン</param>
        /// <returns>マウスボタンの状態</returns>
        public ButtonState GetMouseButtonState(MouseButton button)
        {
            var ret = cbg_Mouse_GetMouseButtonState(selfPtr, (int)button);
            return (ButtonState)ret;
        }
        
        /// <summary>
        /// カーソル画像をセットします。
        /// </summary>
        /// <param name="cursor">状態を取得するマウスのボタン</param>
        public void SetCursorImage(Cursor cursor)
        {
            cbg_Mouse_SetCursorImage(selfPtr, cursor != null ? cursor.selfPtr : IntPtr.Zero);
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
    /// ジョイスティックコントローラを表します。
    /// </summary>
    public partial class JoystickInfo
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<JoystickInfo>> cacheRepo = new Dictionary<IntPtr, WeakReference<JoystickInfo>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  JoystickInfo TryGetFromCache(IntPtr native)
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Joystick_GetInstance();
        
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
        /// <returns>使用するインスタンス</returns>
        internal static Joystick GetInstance()
        {
            var ret = cbg_Joystick_GetInstance();
            return Joystick.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定したジョイスティックが存在しているかどうかを取得します。
        /// </summary>
        /// <param name="joystickIndex">ジョイスティックのインデックス</param>
        /// <returns>指定したジョイスティックが存在したらtrue，存在していなかったらfalse</returns>
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
    /// グラフィックの制御を行うクラス
    /// </summary>
    public sealed partial class Graphics
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Graphics>> cacheRepo = new Dictionary<IntPtr, WeakReference<Graphics>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Graphics_GetInstance();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Graphics_BeginFrame(IntPtr selfPtr, RenderPassParameter renderPassParmeter);
        
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
        internal bool BeginFrame(RenderPassParameter renderPassParmeter)
        {
            var ret = cbg_Graphics_BeginFrame(selfPtr, renderPassParmeter);
            return ret;
        }
        
        /// <summary>
        /// 描画を終了します。
        /// </summary>
        /// <returns>正常に終了した場合は　true 。それ以外の場合は false。</returns>
        internal bool EndFrame()
        {
            var ret = cbg_Graphics_EndFrame(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// イベントを処理します。
        /// </summary>
        /// <returns>正常に処理した場合は　true 。それ以外の場合は false。</returns>
        internal bool DoEvents()
        {
            var ret = cbg_Graphics_DoEvents(selfPtr);
            return ret;
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
    /// テクスチャのベースクラス
    /// </summary>
    [Serializable]
    public partial class TextureBase : ISerializable, ICacheKeeper<TextureBase>, IDeserializationCallback
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<TextureBase>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<TextureBase>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  TextureBase TryGetFromCache(IntPtr native)
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
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new TextureBase(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<TextureBase>(newObject));
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
        /// <returns>処理に成功したらtrue，それ以外でfalse</returns>
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
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);
            
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
    /// テクスチャのクラス
    /// </summary>
    [Serializable]
    public sealed partial class Texture2D : TextureBase, ISerializable, ICacheKeeper<Texture2D>, IDeserializationCallback
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Texture2D>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static new Texture2D TryGetFromCache(IntPtr native)
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
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new Texture2D(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<Texture2D>(newObject));
            return newObject;
        }
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Texture2D_Load([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Texture2D_Reload(IntPtr selfPtr);
        
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
        /// 指定したファイルからテクスチャを読み込みます。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>テクスチャ</returns>
        public static Texture2D Load(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
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
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);
            
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
    /// ポストエフェクトやカメラにおける描画先のクラス
    /// </summary>
    [Serializable]
    public sealed partial class RenderTexture : TextureBase, ISerializable, ICacheKeeper<RenderTexture>, IDeserializationCallback
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderTexture>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderTexture>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static new RenderTexture TryGetFromCache(IntPtr native)
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
        /// <returns>sizeとformatを持つRenderTextureの新しいインスタンス</returns>
        public static RenderTexture Create(Vector2I size, TextureFormat format)
        {
            var ret = cbg_RenderTexture_Create(size, (int)format);
            return RenderTexture.TryGetFromCache(ret);
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
    /// マテリアル
    /// </summary>
    [Serializable]
    public sealed partial class Material : ISerializable, ICacheKeeper<Material>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Material>> cacheRepo = new Dictionary<IntPtr, WeakReference<Material>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        private static extern void cbg_Material_SetShader(IntPtr selfPtr, IntPtr shader);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_Material_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Material_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Material(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
    /// レンダラのクラス
    /// </summary>
    internal sealed partial class Renderer
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Renderer>> cacheRepo = new Dictionary<IntPtr, WeakReference<Renderer>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Renderer_GetInstance();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawSprite(IntPtr selfPtr, IntPtr sprite);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawText(IntPtr selfPtr, IntPtr text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawPolygon(IntPtr selfPtr, IntPtr polygon);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_DrawIBPolygon(IntPtr selfPtr, IntPtr polygon);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_Render(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_SetCamera(IntPtr selfPtr, IntPtr camera);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_ResetCamera(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Renderer_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// ポリゴンを描画します。
        /// </summary>
        /// <param name="polygon">描画する<see cref="RenderedPolygon"/>のインスタンス</param>
        internal void DrawPolygon(RenderedPolygon polygon)
        {
            cbg_Renderer_DrawPolygon(selfPtr, polygon != null ? polygon.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// IBが編集可能なポリゴンを描画します。
        /// </summary>
        /// <param name="polygon">描画する<see cref="RenderedIBPolygon"/>のインスタンス</param>
        internal void DrawIBPolygon(RenderedIBPolygon polygon)
        {
            cbg_Renderer_DrawIBPolygon(selfPtr, polygon != null ? polygon.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// コマンドリストを描画します。
        /// </summary>
        internal void Render()
        {
            cbg_Renderer_Render(selfPtr);
        }
        
        /// <summary>
        /// 使用するカメラを設定します。
        /// </summary>
        /// <param name="camera">描画するカメラ</param>
        internal void SetCamera(RenderedCamera camera)
        {
            cbg_Renderer_SetCamera(selfPtr, camera != null ? camera.selfPtr : IntPtr.Zero);
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
    /// コマンドリストのクラス
    /// </summary>
    public sealed partial class CommandList
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CommandList>> cacheRepo = new Dictionary<IntPtr, WeakReference<CommandList>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_CommandList_GetScreenTexture(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_SetRenderTarget(IntPtr selfPtr, IntPtr target, RenderPassParameter renderPassParameter);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_RenderToRenderTexture(IntPtr selfPtr, IntPtr material, IntPtr target, RenderPassParameter renderPassparameter);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_RenderToRenderTarget(IntPtr selfPtr, IntPtr material);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CommandList_CopyTexture(IntPtr selfPtr, IntPtr src, IntPtr dst);
        
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
        
        /// <summary>
        /// スクリーンに表示されている内容をテクスチャとして取得します。
        /// </summary>
        /// <returns>スクリーンに表示されている内容を反映したテクスチャ</returns>
        public RenderTexture GetScreenTexture()
        {
            var ret = cbg_CommandList_GetScreenTexture(selfPtr);
            return RenderTexture.TryGetFromCache(ret);
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
        /// <param name="renderPassparameter">描画に使用する設定</param>
        public void RenderToRenderTexture(Material material, RenderTexture target, RenderPassParameter renderPassparameter)
        {
            cbg_CommandList_RenderToRenderTexture(selfPtr, material != null ? material.selfPtr : IntPtr.Zero, target != null ? target.selfPtr : IntPtr.Zero, renderPassparameter);
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
    /// 描画されるオブジェクトの基本クラスを表します
    /// </summary>
    [Serializable]
    internal partial class Rendered : ISerializable, ICacheKeeper<Rendered>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Rendered>> cacheRepo = new Dictionary<IntPtr, WeakReference<Rendered>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// スプライトのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedSprite : Rendered, ISerializable, ICacheKeeper<RenderedSprite>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedSprite>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedSprite>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_Create();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RectF cbg_RenderedSprite_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetSrc(IntPtr selfPtr, RectF value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedSprite_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Color cbg_RenderedSprite_GetColor(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetColor(IntPtr selfPtr, Color value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedSprite_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedSprite_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);
        
        
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
        private const string S_Texture = "S_Texture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Src = "S_Src";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Material = "S_Material";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Color = "S_Color";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
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
            
            var Texture = info.GetValue<TextureBase>(S_Texture);
            ((IDeserializationCallback)Texture)?.OnDeserialization(null);
            this.Texture = Texture;
            Src = info.GetValue<RectF>(S_Src);
            Material = info.GetValue<Material>(S_Material);
            Color = info.GetValue<Color>(S_Color);
            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            
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
            
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Material, Material);
            info.AddValue(S_Color, Color);
            info.AddValue(S_AlphaBlend, AlphaBlend);
            
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
                internal static new RenderedText TryGetFromCache(IntPtr native)
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
        private static extern IntPtr cbg_RenderedText_GetText(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedText_GetFont(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetFont(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_RenderedText_GetWeight(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetWeight(IntPtr selfPtr, float value);
        
        
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
        private static extern Vector2F cbg_RenderedText_GetTextureSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Color cbg_RenderedText_GetColor(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetColor(IntPtr selfPtr, Color value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedText_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedText_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);
        
        
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
        /// 文字の太さを取得または設定します。(0 ~ 255)
        /// </summary>
        internal float Weight
        {
            get
            {
                if (_Weight != null)
                {
                    return _Weight.Value;
                }
                var ret = cbg_RenderedText_GetWeight(selfPtr);
                return ret;
            }
            set
            {
                _Weight = value;
                cbg_RenderedText_SetWeight(selfPtr, value);
            }
        }
        private float? _Weight;
        
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
        
        /// <summary>
        /// テキストを描画したときのサイズを取得します
        /// </summary>
        internal Vector2F TextureSize
        {
            get
            {
                var ret = cbg_RenderedText_GetTextureSize(selfPtr);
                return ret;
            }
        }
        
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
        private const string S_MaterialGlyph = "S_MaterialGlyph";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_MaterialImage = "S_MaterialImage";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Text = "S_Text";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Font = "S_Font";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Weight = "S_Weight";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_IsEnableKerning = "S_IsEnableKerning";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_WritingDirection = "S_WritingDirection";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_CharacterSpace = "S_CharacterSpace";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_LineGap = "S_LineGap";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Color = "S_Color";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
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
            
            MaterialGlyph = info.GetValue<Material>(S_MaterialGlyph);
            MaterialImage = info.GetValue<Material>(S_MaterialImage);
            Text = info.GetString(S_Text);
            var Font = info.GetValue<Font>(S_Font);
            ((IDeserializationCallback)Font)?.OnDeserialization(null);
            this.Font = Font;
            Weight = info.GetSingle(S_Weight);
            IsEnableKerning = info.GetBoolean(S_IsEnableKerning);
            WritingDirection = info.GetValue<WritingDirection>(S_WritingDirection);
            CharacterSpace = info.GetSingle(S_CharacterSpace);
            LineGap = info.GetSingle(S_LineGap);
            Color = info.GetValue<Color>(S_Color);
            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            
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
            
            info.AddValue(S_MaterialGlyph, MaterialGlyph);
            info.AddValue(S_MaterialImage, MaterialImage);
            info.AddValue(S_Text, Text);
            info.AddValue(S_Font, Font);
            info.AddValue(S_Weight, Weight);
            info.AddValue(S_IsEnableKerning, IsEnableKerning);
            info.AddValue(S_WritingDirection, WritingDirection);
            info.AddValue(S_CharacterSpace, CharacterSpace);
            info.AddValue(S_LineGap, LineGap);
            info.AddValue(S_Color, Color);
            info.AddValue(S_AlphaBlend, AlphaBlend);
            
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
                internal static new RenderedPolygon TryGetFromCache(IntPtr native)
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
        private static extern void cbg_RenderedPolygon_CreateVertexesByVector2F(IntPtr selfPtr, IntPtr vertexes);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_OverwriteVertexesColor(IntPtr selfPtr, Color color);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetVertexes(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RectF cbg_RenderedPolygon_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetSrc(IntPtr selfPtr, RectF value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedPolygon_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedPolygon_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedPolygon_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);
        
        
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
        internal void CreateVertexesByVector2F(Vector2FArray vertexes)
        {
            cbg_RenderedPolygon_CreateVertexesByVector2F(selfPtr, vertexes != null ? vertexes.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// 頂点情報
        /// </summary>
        public void OverwriteVertexesColor(Color color)
        {
            cbg_RenderedPolygon_OverwriteVertexesColor(selfPtr, color);
        }
        
        
        #region ISerialiable
        
        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Vertexes = "S_Vertexes";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Texture = "S_Texture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Src = "S_Src";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Material = "S_Material";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
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
            
            Vertexes = info.GetValue<VertexArray>(S_Vertexes);
            var Texture = info.GetValue<TextureBase>(S_Texture);
            ((IDeserializationCallback)Texture)?.OnDeserialization(null);
            this.Texture = Texture;
            Src = info.GetValue<RectF>(S_Src);
            Material = info.GetValue<Material>(S_Material);
            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            
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
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Material, Material);
            info.AddValue(S_AlphaBlend, AlphaBlend);
            
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
    /// IndexBufferを設定可能なポリゴンのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedIBPolygon : Rendered, ISerializable, ICacheKeeper<RenderedIBPolygon>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RenderedIBPolygon>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedIBPolygon>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static new RenderedIBPolygon TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                RenderedIBPolygon cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RenderedIBPolygon_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new RenderedIBPolygon(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RenderedIBPolygon>(newObject);
            return newObject;
        }
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedIBPolygon_Create();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_CreateVertexesByVector2F(IntPtr selfPtr, IntPtr vertexes);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_OverwriteVertexesColor(IntPtr selfPtr, Color color);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetDefaultIndexBuffer(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedIBPolygon_GetBuffers(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetBuffers(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedIBPolygon_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetVertexes(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedIBPolygon_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern RectF cbg_RenderedIBPolygon_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetSrc(IntPtr selfPtr, RectF value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RenderedIBPolygon_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern AlphaBlend cbg_RenderedIBPolygon_GetAlphaBlend(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_SetAlphaBlend(IntPtr selfPtr, AlphaBlend value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedIBPolygon_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedIBPolygon(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
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
                var ret = cbg_RenderedIBPolygon_GetVertexes(selfPtr);
                return VertexArray.TryGetFromCache(ret);
            }
            set
            {
                _Vertexes = value;
                cbg_RenderedIBPolygon_SetVertexes(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private VertexArray _Vertexes;
        
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
                var ret = cbg_RenderedIBPolygon_GetTexture(selfPtr);
                return TextureBase.TryGetFromCache(ret);
            }
            set
            {
                _Texture = value;
                cbg_RenderedIBPolygon_SetTexture(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private TextureBase _Texture;
        
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
                var ret = cbg_RenderedIBPolygon_GetSrc(selfPtr);
                return ret;
            }
            set
            {
                _Src = value;
                cbg_RenderedIBPolygon_SetSrc(selfPtr, value);
            }
        }
        private RectF? _Src;
        
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
                var ret = cbg_RenderedIBPolygon_GetMaterial(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _Material = value;
                cbg_RenderedIBPolygon_SetMaterial(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _Material;
        
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
                var ret = cbg_RenderedIBPolygon_GetAlphaBlend(selfPtr);
                return ret;
            }
            set
            {
                _AlphaBlend = value;
                cbg_RenderedIBPolygon_SetAlphaBlend(selfPtr, value);
            }
        }
        private AlphaBlend? _AlphaBlend;
        
        /// <summary>
        /// ポリゴンを作成します。
        /// </summary>
        internal static RenderedIBPolygon Create()
        {
            var ret = cbg_RenderedIBPolygon_Create();
            return RenderedIBPolygon.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 頂点情報
        /// </summary>
        internal void CreateVertexesByVector2F(Vector2FArray vertexes)
        {
            cbg_RenderedIBPolygon_CreateVertexesByVector2F(selfPtr, vertexes != null ? vertexes.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// 頂点情報
        /// </summary>
        public void OverwriteVertexesColor(Color color)
        {
            cbg_RenderedIBPolygon_OverwriteVertexesColor(selfPtr, color);
        }
        
        
        #region ISerialiable
        
        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Buffers = "S_Buffers";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Vertexes = "S_Vertexes";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Texture = "S_Texture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Src = "S_Src";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Material = "S_Material";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_AlphaBlend = "S_AlphaBlend";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedIBPolygon"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private RenderedIBPolygon(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);
            
            Buffers = info.GetValue<Int32Array>(S_Buffers);
            Vertexes = info.GetValue<VertexArray>(S_Vertexes);
            var Texture = info.GetValue<TextureBase>(S_Texture);
            ((IDeserializationCallback)Texture)?.OnDeserialization(null);
            this.Texture = Texture;
            Src = info.GetValue<RectF>(S_Src);
            Material = info.GetValue<Material>(S_Material);
            AlphaBlend = info.GetValue<AlphaBlend>(S_AlphaBlend);
            
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
            
            info.AddValue(S_Buffers, Buffers);
            info.AddValue(S_Vertexes, Vertexes);
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Material, Material);
            info.AddValue(S_AlphaBlend, AlphaBlend);
            
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
        /// <see cref="RenderedIBPolygon(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        
        /// <summary>
        /// <see cref="RenderedIBPolygon(SerializationInfo, StreamingContext)"/>内で呼び出される
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
        IDictionary<IntPtr, WeakReference<RenderedIBPolygon>> ICacheKeeper<RenderedIBPolygon>.CacheRepo => cacheRepo;
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RenderedIBPolygon>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RenderedIBPolygon>.Release(IntPtr native) => cbg_RenderedIBPolygon_Release(native);
        
        #endregion
        
        #endregion
        
        /// <summary>
        /// <see cref="RenderedIBPolygon"/>のインスタンスを削除します。
        /// </summary>
        ~RenderedIBPolygon()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RenderedIBPolygon_Release(selfPtr);
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
                internal static  RenderedCamera TryGetFromCache(IntPtr native)
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
        private static extern Matrix44F cbg_RenderedCamera_GetViewMatrix(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RenderedCamera_SetViewMatrix(IntPtr selfPtr, Matrix44F value);
        
        
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
        private static extern void cbg_RenderedCamera_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RenderedCamera(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        private const string S_ViewMatrix = "S_ViewMatrix";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_TargetTexture = "S_TargetTexture";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_RenderPassParameter = "S_RenderPassParameter";
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
            
            ViewMatrix = info.GetValue<Matrix44F>(S_ViewMatrix);
            var TargetTexture = info.GetValue<RenderTexture>(S_TargetTexture);
            ((IDeserializationCallback)TargetTexture)?.OnDeserialization(null);
            this.TargetTexture = TargetTexture;
            RenderPassParameter = info.GetValue<RenderPassParameter>(S_RenderPassParameter);
            
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
            
            info.AddValue(S_ViewMatrix, ViewMatrix);
            info.AddValue(S_TargetTexture, TargetTexture);
            info.AddValue(S_RenderPassParameter, RenderPassParameter);
            
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
    /// 組み込みシェーダの取得を行うクラス
    /// </summary>
    public sealed partial class BuiltinShader
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<BuiltinShader>> cacheRepo = new Dictionary<IntPtr, WeakReference<BuiltinShader>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  BuiltinShader TryGetFromCache(IntPtr native)
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
        /// <returns><paramref name="type"/>に対応した種類の組み込みの<see cref="Shader"/>のインスタンス</returns>
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
    /// シェーダのコンパイル結果を表すクラス
    /// </summary>
    internal sealed partial class ShaderCompileResult
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<ShaderCompileResult>> cacheRepo = new Dictionary<IntPtr, WeakReference<ShaderCompileResult>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  ShaderCompileResult TryGetFromCache(IntPtr native)
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
        private static extern int cbg_Shader_GetStageType(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_GetCode(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Shader_GetName(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Shader_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Shader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        /// コードをコンパイルしてシェーダを生成します。
        /// </summary>
        /// <param name="name">シェーダの名前</param>
        /// <param name="code">コンパイルするコード</param>
        /// <param name="shaderStage"></param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="code"/>のいずれかがnull</exception>
        /// <returns>コンパイルの結果生成されたシェーダ</returns>
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
        /// <param name="shaderStage"></param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="path"/>のいずれかがnull</exception>
        /// <returns>コンパイルの結果生成されたシェーダ</returns>
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
        private const string S_StageType = "S_StageType";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Code = "S_Code";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Name = "S_Name";
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
            
            info.AddValue(S_StageType, StageType);
            info.AddValue(S_Code, Code);
            info.AddValue(S_Name, Name);
            
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
        /// <param name="StageType"><see cref="Shader.StageType"/></param>
        /// <param name="Code"><see cref="Shader.Code"/></param>
        /// <param name="Name"><see cref="Shader.Name"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Shader_Unsetter_Deserialize(SerializationInfo info, out ShaderStage StageType, out string Code, out string Name)
        {
            StageType = info.GetValue<ShaderStage>(S_StageType);
            Code = info.GetString(S_Code);
            Name = info.GetString(S_Name);
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
        private static extern Vector2I cbg_Glyph_GetOffset(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Glyph_GetGlyphWidth(IntPtr selfPtr);
        
        
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
        public Vector2I Offset
        {
            get
            {
                var ret = cbg_Glyph_GetOffset(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// 文字の幅を取得します。
        /// </summary>
        public int GlyphWidth
        {
            get
            {
                var ret = cbg_Glyph_GetGlyphWidth(selfPtr);
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
        private static extern IntPtr cbg_Font_LoadDynamicFont([MarshalAs(UnmanagedType.LPWStr)] string path, int size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_LoadStaticFont([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_GenerateFontFile([MarshalAs(UnmanagedType.LPWStr)] string dynamicFontPath, [MarshalAs(UnmanagedType.LPWStr)] string staticFontPath, int size, [MarshalAs(UnmanagedType.LPWStr)] string characters);
        
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
        private static extern IntPtr cbg_Font_CreateImageFont(IntPtr baseFont);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Font_AddImageGlyph(IntPtr selfPtr, int character, IntPtr texture);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Font_GetImageGlyph(IntPtr selfPtr, int character);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetAscent(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetDescent(IntPtr selfPtr);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Font_GetLineGap(IntPtr selfPtr);
        
        
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
        
        /// <summary>
        /// フォントのサイズを取得します。
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
        /// フォントのベースラインからトップラインまでの距離を取得します。
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
        /// フォントのベースラインからボトムラインまでの距離を取得します。
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
        /// フォントの行間の距離を取得します。
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
        /// フォントファイルを読み込んでFontの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <param name="size">フォントのサイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns><paramref name="path"/>の指定するファイルから生成されたフォント</returns>
        public static Font LoadDynamicFont(string path, int size)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Font_LoadDynamicFont(path, size);
            return Font.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// FontGeneratorで生成したフォントを読み込んでFontの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns><paramref name="path"/>の指定するファイルから生成されたフォント</returns>
        public static Font LoadStaticFont(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Font_LoadStaticFont(path);
            return Font.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// a2fフォントを生成します。
        /// </summary>
        /// <param name="dynamicFontPath">読み込むtruetypeフォントのパス</param>
        /// <param name="staticFontPath">生成するa2fフォントのパス</param>
        /// <param name="size">フォントのサイズ</param>
        /// <param name="characters">フォント化させる文字列</param>
        /// <exception cref="ArgumentNullException"><paramref name="dynamicFontPath"/>, <paramref name="staticFontPath"/>のいずれかがnull</exception>
        /// <returns>生成できたらtrue，それ以外でfalse</returns>
        public static bool GenerateFontFile(string dynamicFontPath, string staticFontPath, int size, string characters)
        {
            if (dynamicFontPath == null) throw new ArgumentNullException(nameof(dynamicFontPath), "引数がnullです");
            if (staticFontPath == null) throw new ArgumentNullException(nameof(staticFontPath), "引数がnullです");
            var ret = cbg_Font_GenerateFontFile(dynamicFontPath, staticFontPath, size, characters);
            return ret;
        }
        
        /// <summary>
        /// 文字情報を取得します。
        /// </summary>
        /// <param name="character">文字</param>
        /// <returns>文字</returns>
        public Glyph GetGlyph(int character)
        {
            var ret = cbg_Font_GetGlyph(selfPtr, character);
            return Glyph.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定した文字のテクスチャを取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>テクスチャ</returns>
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
        /// <returns>カーニング</returns>
        public int GetKerning(int c1, int c2)
        {
            var ret = cbg_Font_GetKerning(selfPtr, c1, c2);
            return ret;
        }
        
        /// <summary>
        /// テクスチャ追加対応フォントを生成します。
        /// </summary>
        /// <param name="baseFont">ベースとなるフォント</param>
        /// <exception cref="ArgumentNullException"><paramref name="baseFont"/>がnull</exception>
        /// <returns>テクスチャ追加対応フォント</returns>
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
        internal void AddImageGlyph(int character, Texture2D texture)
        {
            cbg_Font_AddImageGlyph(selfPtr, character, texture != null ? texture.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// テクスチャ文字を取得します。
        /// </summary>
        /// <param name="character">文字</param>
        /// <returns>テクスチャ文字</returns>
        public Texture2D GetImageGlyph(int character)
        {
            var ret = cbg_Font_GetImageGlyph(selfPtr, character);
            return Texture2D.TryGetFromCache(ret);
        }
        
        
        #region ISerialiable
        
        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Size = "S_Size";
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
            
            info.AddValue(S_Size, Size);
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
        /// <param name="Size"><see cref="Font.Size"/></param>
        /// <param name="IsStaticFont"><see cref="Font.IsStaticFont"/></param>
        /// <param name="Path"><see cref="Font.Path"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Font_Unsetter_Deserialize(SerializationInfo info, out int Size, out bool IsStaticFont, out string Path)
        {
            Size = info.GetInt32(S_Size);
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
    /// カリングのクラス
    /// </summary>
    internal sealed partial class CullingSystem
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CullingSystem>> cacheRepo = new Dictionary<IntPtr, WeakReference<CullingSystem>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  CullingSystem TryGetFromCache(IntPtr native)
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
        private static extern void cbg_CullingSystem_Register(IntPtr selfPtr, IntPtr rendered);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_Unregister(IntPtr selfPtr, IntPtr rendered);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_CullingSystem_UpdateAABB(IntPtr selfPtr);
        
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
        /// <returns>使用するインスタンス</returns>
        internal static CullingSystem GetInstance()
        {
            var ret = cbg_CullingSystem_GetInstance();
            return CullingSystem.TryGetFromCache(ret);
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
        /// Renderedをカリングシステムから登録解除します。
        /// </summary>
        /// <param name="rendered">登録解除するRendered</param>
        internal void Unregister(Rendered rendered)
        {
            cbg_CullingSystem_Unregister(selfPtr, rendered != null ? rendered.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// RenderedのAABBを更新します。
        /// </summary>
        internal void UpdateAABB()
        {
            cbg_CullingSystem_UpdateAABB(selfPtr);
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
    /// imguiのツール処理を行うクラス
    /// </summary>
    public sealed partial class Tool
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Tool>> cacheRepo = new Dictionary<IntPtr, WeakReference<Tool>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetInstance();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_AddFontFromFileTTF(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path, float sizePixels, int ranges);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Begin(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_End(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NewFrame(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Render(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Dummy(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Text(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextUnformatted(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextWrapped(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextColored(IntPtr selfPtr, Color color, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TextDisabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BulletText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LabelText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CollapsingHeader(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNode(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_TreeNodeEx(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_TreePop(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextItemOpen(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool isOpen, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Button(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_CheckBox(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool isChecked);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_RadioButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool active);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_RadioButton_2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int v, int v_button);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ArrowButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int dir);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InvisibleButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ListBox(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int current, [MarshalAs(UnmanagedType.LPWStr)] string items, int popupMaxHeightInItems);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Selectable(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] [In, Out] ref bool selected, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string input, int maxLength, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputTextWithHint(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string hint, [MarshalAs(UnmanagedType.LPWStr)] string input, int maxLength, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_InputTextMultiline(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string input, int maxLength, Vector2F size, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputInt4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_InputFloat4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderInt4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderFloat4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr array, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SliderAngle(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float angle);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref int value, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref float value, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int value, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float value, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragIntRange2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int currentMin, [In, Out] ref int currentMax, float speed, int valueMin, int valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_DragFloatRange2(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref float currentMin, [In, Out] ref float currentMax, float speed, float valueMin, float valueMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorEdit3(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref Color color, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorEdit4(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref Color color, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_OpenPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopup(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupModal(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndPopup(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginChild(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [MarshalAs(UnmanagedType.Bool)] bool border, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndChild(IntPtr selfPtr);
        
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
        private static extern bool cbg_Tool_BeginMenu(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.Bool)] bool enabled);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndMenu(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_MenuItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string shortcut, [MarshalAs(UnmanagedType.Bool)] bool selected, [MarshalAs(UnmanagedType.Bool)] bool enabled);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabBar(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTabBar(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginTabItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTabItem(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Indent(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Unindent(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Separator(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetTooltip(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BeginTooltip(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndTooltip(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NewLine(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SameLine(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushTextWrapPos(IntPtr selfPtr, float wrapLocalPosX);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopTextWrapPos(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushItemWidth(IntPtr selfPtr, float width);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopItemWidth(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushButtonRepeat(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool repeat);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopButtonRepeat(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Columns(IntPtr selfPtr, int count, [MarshalAs(UnmanagedType.Bool)] bool border);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_NextColumn(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushID(IntPtr selfPtr, int id);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopID(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemActive(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemHovered(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollHere(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTextLineHeight(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetFontSize(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetWindowSize(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowSize(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMousePosValid(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDragging(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsMouseDoubleClicked(IntPtr selfPtr, int button);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetMouseDragDelta(IntPtr selfPtr, int button);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ResetMouseDragDelta(IntPtr selfPtr, int button);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowContentSize(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowSize(IntPtr selfPtr, Vector2F size, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextWindowPos(IntPtr selfPtr, Vector2F pos, int cond);
        
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
        private static extern Vector2F cbg_Tool_GetWindowPos(IntPtr selfPtr);
        
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
        private static extern void cbg_Tool_SetWindowPosWithCond(IntPtr selfPtr, Vector2F pos, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowSizeWithCond(IntPtr selfPtr, Vector2F pos, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowCollapsedWithCond(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool collapsed, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFocus(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFontScale(IntPtr selfPtr, float scale);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowPosByName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, Vector2F pos, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowSizeByName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, Vector2F pos, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowCollapsedByName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool collapsed, int cond);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetWindowFocusByName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name);
        
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
        private static extern void cbg_Tool_SetScrollX(IntPtr selfPtr, float scrollX);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollY(IntPtr selfPtr, float scrollY);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollHereX(IntPtr selfPtr, float centerXRatio);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollHereY(IntPtr selfPtr, float centerYRatio);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollFromPosX(IntPtr selfPtr, float localX, float centerXRatio);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetScrollFromPosY(IntPtr selfPtr, float localY, float centerYRatio);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleColor(IntPtr selfPtr, int idx, Color col);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopStyleColor(IntPtr selfPtr, int count);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleVarFloat(IntPtr selfPtr, int idx, float val);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushStyleVarVector2F(IntPtr selfPtr, int idx, Vector2F val);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopStyleVar(IntPtr selfPtr, int count);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Color cbg_Tool_GetStyleColor(IntPtr selfPtr, int idx);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetFontTexUvWhitePixel(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetNextItemWidth(IntPtr selfPtr, float itemWidth);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_CalcItemWidth(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushAllowKeyboardFocus(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool allowKeyboardFocus);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PopAllowKeyboardFocus(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Spacing(IntPtr selfPtr);
        
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
        private static extern void cbg_Tool_SetCursorPos(IntPtr selfPtr, Vector2F localPos);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetCursorStartPos(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_Tool_GetCursorScreenPos(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_AlignTextToFramePadding(IntPtr selfPtr);
        
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
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_SmallButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Image(IntPtr selfPtr, IntPtr texture, Vector2F size, Vector2F uv0, Vector2F uv1, Color tintColor, Color borderColor);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ImageButton(IntPtr selfPtr, IntPtr texture, Vector2F size, Vector2F uv0, Vector2F uv1, int framePadding, Color tintColor, Color borderColor);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ProgressBar(IntPtr selfPtr, float fraction, Vector2F sizeArg, [MarshalAs(UnmanagedType.LPWStr)] string overlay);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_Bullet(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_BeginCombo(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [MarshalAs(UnmanagedType.LPWStr)] string previewValue, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_EndCombo(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_Combo(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, [In, Out] ref int current_item, [MarshalAs(UnmanagedType.LPWStr)] string items, int popupMaxHeightInItems);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ColorButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string descId, [In, Out] ref Color col, int flags, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColorEditOptions(IntPtr selfPtr, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTreeNodeToLabelSpacing(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_ListBoxHeader(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string flags, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ListBoxFooter(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PlotLines(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr values, int valuesCount, int valuesOffset, [MarshalAs(UnmanagedType.LPWStr)] string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PlotHistogram(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, IntPtr values, int valuesCount, int valuesOffset, [MarshalAs(UnmanagedType.LPWStr)] string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ValueBool(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, [MarshalAs(UnmanagedType.Bool)] bool b);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ValueInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, int v);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_ValueFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string prefix, float v, [MarshalAs(UnmanagedType.LPWStr)] string floatFormat);
        
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
        private static extern bool cbg_Tool_BeginPopupContextItem(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string strId, int mouseButton);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupContextWindow(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string strId, int mouseButton, [MarshalAs(UnmanagedType.Bool)] bool alsoOverItems);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupContextVoid(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string strId, int mouseButton);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_BeginPopupModalEx(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Bool)] [Out] out bool isOpen, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_OpenPopupOnItemClick(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string strId, int mouseButton);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsPopupOpen(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string strId);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_CloseCurrentPopup(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColumnIndex(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetColumnWidth(IntPtr selfPtr, int columnIndex);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColumnWidth(IntPtr selfPtr, int columnIndex, float width);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetColumnOffset(IntPtr selfPtr, int columnIndex);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetColumnOffset(IntPtr selfPtr, int columnIndex, float offsetX);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern int cbg_Tool_GetColumnsCount(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetTabItemClosed(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string tabOrDockedWindowLabel);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_PushClipRect(IntPtr selfPtr, Vector2F clipRectMin, Vector2F clipRectMax, [MarshalAs(UnmanagedType.Bool)] bool intersectWithCurrentClipRect);
        
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
        private static extern bool cbg_Tool_IsItemHoveredWithFlags(IntPtr selfPtr, int flags);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemFocused(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_IsItemClicked(IntPtr selfPtr, int mouseButton);
        
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
        private static extern void cbg_Tool_IsRectVisible(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_IsRectVisibleVector2F2(IntPtr selfPtr, Vector2F rectMin, Vector2F rectMax);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern float cbg_Tool_GetTime(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Tool_GetClipboardText(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SetClipboardText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_LoadIniSettingsFromDisk(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string iniFilename);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_Tool_SaveIniSettingsToDisk(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string iniFilename);
        
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
        
        /// <summary>
        /// パスからフォントを読み込みます。パックされたファイルは非対応です。
        /// </summary>
        public bool AddFontFromFileTTF(string path, float sizePixels, ToolGlyphRange ranges)
        {
            var ret = cbg_Tool_AddFontFromFileTTF(selfPtr, path, sizePixels, (int)ranges);
            return ret;
        }
        
        /// <summary>
        /// 'End()' を呼び出してください。
        /// </summary>
        public bool Begin(string name, ToolWindowFlags flags)
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
        internal void NewFrame()
        {
            cbg_Tool_NewFrame(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal void Render()
        {
            cbg_Tool_Render(selfPtr);
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
        /// テキストを生成します。
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void Text(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_Text(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void TextUnformatted(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_TextUnformatted(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void TextWrapped(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_TextWrapped(selfPtr, text);
        }
        
        /// <summary>
        /// 色付きテキストを生成します。
        /// </summary>
        /// <param name="color">テキストの色</param>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void TextColored(Color color, string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_TextColored(selfPtr, color, text);
        }
        
        /// <summary>
        /// 灰字のテキストを生成します。
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void TextDisabled(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_TextDisabled(selfPtr, text);
        }
        
        /// <summary>
        /// 箇条書きテキストを生成します。
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>がnull</exception>
        public void BulletText(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_BulletText(selfPtr, text);
        }
        
        /// <summary>
        /// 横にラベルの付いたテキストを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="text">横に表示するラベルのテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="text"/>のいずれかがnull</exception>
        public void LabelText(string label, string text)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (text == null) throw new ArgumentNullException(nameof(text), "引数がnullです");
            cbg_Tool_LabelText(selfPtr, label, text);
        }
        
        /// <summary>
        /// 折り畳み式のヘッダを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool CollapsingHeader(string label, ToolTreeNodeFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_CollapsingHeader(selfPtr, label, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool TreeNode(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_TreeNode(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// ツリーのノードを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool TreeNodeEx(string label, ToolTreeNodeFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_TreeNodeEx(selfPtr, label, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// TreeNodeのツリーを開きます。
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
        /// ボタンを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool Button(string label, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Button(selfPtr, label, size);
            return ret;
        }
        
        /// <summary>
        /// チェックボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="isChecked">チェックされているかどうか</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool CheckBox(string label, ref bool isChecked)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_CheckBox(selfPtr, label, ref isChecked);
            return ret;
        }
        
        /// <summary>
        /// ラジオボタンを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="active">チェックが入っているかどうか</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool RadioButton(string label, bool active)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_RadioButton(selfPtr, label, active);
            return ret;
        }
        
        internal bool RadioButton_2(string label, ref int v, int v_button)
        {
            var ret = cbg_Tool_RadioButton_2(selfPtr, label, ref v, v_button);
            return ret;
        }
        
        /// <summary>
        /// 矢印ボタンを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="dir">矢印の向き</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool ArrowButton(string label, ToolDir dir)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ArrowButton(selfPtr, label, (int)dir);
            return ret;
        }
        
        /// <summary>
        /// 見えないボタンを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="size">サイズ</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool InvisibleButton(string label, Vector2F size)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InvisibleButton(selfPtr, label, size);
            return ret;
        }
        
        /// <summary>
        /// リストボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="current">選択中のアイテムのインデックス -1で選択無し</param>
        /// <param name="items">タブ文字を用いて分割したアイテム</param>
        /// <param name="popupMaxHeightInItems">一度に表示されるアイテムの個数</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>アイテムがクリックされたらtrue，それ以外でfalse</returns>
        public bool ListBox(string label, ref int current, string items, int popupMaxHeightInItems)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ListBox(selfPtr, label, ref current, items, popupMaxHeightInItems);
            return ret;
        }
        
        /// <summary>
        /// 選択式のテキストを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <param name="selected">選択されているかどうか</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool Selectable(string label, ref bool selected, ToolSelectableFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Selectable(selfPtr, label, ref selected, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// テキストを入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="maxLength">処理するテキストの最大長</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="input"/>のいずれかがnull</exception>
        /// <returns>入力されたテキスト</returns>
        public string InputText(string label, string input, int maxLength, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputText(selfPtr, label, input, maxLength, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// ヒント付きのテキスト入力ボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="hint">インプットされている文字列長が0の時に表示されるヒント</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="maxLength">処理するテキストの最大長</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="hint"/>, <paramref name="input"/>のいずれかがnull</exception>
        /// <returns>入力されたテキスト</returns>
        public string InputTextWithHint(string label, string hint, string input, int maxLength, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (hint == null) throw new ArgumentNullException(nameof(hint), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputTextWithHint(selfPtr, label, hint, input, maxLength, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// 複数行のテキストが入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="input">入力するテキスト</param>
        /// <param name="maxLength">処理するテキストの最大長</param>
        /// <param name="size">サイズ</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>, <paramref name="input"/>のいずれかがnull</exception>
        /// <returns>入力されたテキスト</returns>
        public string InputTextMultiline(string label, string input, int maxLength, Vector2F size, ToolInputTextFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            if (input == null) throw new ArgumentNullException(nameof(input), "引数がnullです");
            var ret = cbg_Tool_InputTextMultiline(selfPtr, label, input, maxLength, size, (int)flags);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// 1つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputInt(string label, ref int value)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt(selfPtr, label, ref value);
            return ret;
        }
        
        /// <summary>
        /// 2つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        internal bool InputInt2(string label, Int32Array array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt2(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 3つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        internal bool InputInt3(string label, Int32Array array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt3(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 4つの整数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        internal bool InputInt4(string label, Int32Array array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputInt4(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 1つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputFloat(string label, ref float value)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputFloat(selfPtr, label, ref value);
            return ret;
        }
        
        /// <summary>
        /// 2つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputFloat2(string label, FloatArray array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputFloat2(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 3つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputFloat3(string label, FloatArray array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputFloat3(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 4つの小数が入力可能なボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="array">扱う値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        internal bool InputFloat4(string label, FloatArray array)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_InputFloat4(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero);
            return ret;
        }
        
        /// <summary>
        /// 1つのスライドで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <param name="speed">スライドで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderInt(string label, ref int value, float speed, int valueMin, int valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_SliderInt(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderInt2(string label, Int32Array array, float speed, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_SliderInt2(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderInt3(string label, Int32Array array, float speed, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_SliderInt3(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderInt4(string label, Int32Array array, float speed, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_SliderInt4(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 1つのスライドで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <param name="speed">スライドで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderFloat(string label, ref float value, float speed, float valueMin, float valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_SliderFloat(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderFloat2(string label, FloatArray array, float speed, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_SliderFloat2(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderFloat3(string label, FloatArray array, float speed, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_SliderFloat3(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal bool SliderFloat4(string label, FloatArray array, float speed, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_SliderFloat4(selfPtr, label, array != null ? array.selfPtr : IntPtr.Zero, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// スライドで値が増減する，角度を扱うバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="angle">扱う角度の値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderAngle(string label, ref float angle)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_SliderAngle(selfPtr, label, ref angle);
            return ret;
        }
        
        /// <summary>
        /// スライドで値が増減する縦バーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="size">サイズ</param>
        /// <param name="value">扱う値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool VSliderInt(string label, Vector2F size, ref int value, int valueMin, int valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_VSliderInt(selfPtr, label, size, ref value, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// スライドで値が増減する縦バーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="size">サイズ</param>
        /// <param name="value">扱う値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool VSliderFloat(string label, Vector2F size, ref float value, float valueMin, float valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_VSliderFloat(selfPtr, label, size, ref value, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 1つのドラッグで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <param name="speed">ドラッグで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool DragInt(string label, ref int value, float speed, int valueMin, int valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_DragInt(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 1つのドラッグで値が増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="value">扱う値</param>
        /// <param name="speed">ドラッグで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool DragFloat(string label, ref float value, float speed, float valueMin, float valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_DragFloat(selfPtr, label, ref value, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 2つのドラッグで値が増減するバーを生成します
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="currentMin">扱う値のうち小さい方</param>
        /// <param name="currentMax">扱う値のうち大きい方</param>
        /// <param name="speed">ドラッグで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool DragIntRange2(string label, ref int currentMin, ref int currentMax, float speed, int valueMin, int valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_DragIntRange2(selfPtr, label, ref currentMin, ref currentMax, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 2つのドラッグで値が増減するバーを生成します
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="currentMin">扱う値のうち小さい方</param>
        /// <param name="currentMax">扱う値のうち大きい方</param>
        /// <param name="speed">ドラッグで増減する値</param>
        /// <param name="valueMin">最小値</param>
        /// <param name="valueMax">最大値</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool DragFloatRange2(string label, ref float currentMin, ref float currentMax, float speed, float valueMin, float valueMax)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_DragFloatRange2(selfPtr, label, ref currentMin, ref currentMax, speed, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 色を入力するツールを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="color">扱う色</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool ColorEdit3(string label, ref Color color, ToolColorEditFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorEdit3(selfPtr, label, ref color, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 色を入力するツールを生成します。
        /// </summary>
        /// <param name="label">横に表示するラベルのテキスト</param>
        /// <param name="color">扱う色</param>
        /// <param name="flags">適用する設定</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool ColorEdit4(string label, ref Color color, ToolColorEditFlags flags)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_ColorEdit4(selfPtr, label, ref color, (int)flags);
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
        /// 'EndPopup()' を呼び出してください
        /// </summary>
        public bool BeginPopup(string label)
        {
            var ret = cbg_Tool_BeginPopup(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// 'EndPopup()' を呼び出してください
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
        /// 'EndChild()' を呼び出してください
        /// </summary>
        public bool BeginChild(string label, Vector2F size, bool border, ToolWindowFlags flags)
        {
            var ret = cbg_Tool_BeginChild(selfPtr, label, size, border, (int)flags);
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
        /// 'EndMenuBar()' を呼び出してください
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
        /// 'EndMenu()' を呼び出してください
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
        /// 'EndTabBar()' を呼び出してください
        /// </summary>
        public bool BeginTabBar(string label, ToolTabBarFlags flags)
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
        /// 'EndTabItem()' を呼び出してください
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
        /// 次の要素を右にずらします。
        /// </summary>
        public void Indent()
        {
            cbg_Tool_Indent(selfPtr);
        }
        
        /// <summary>
        /// 右にずらすインデントを1つ分打消します。
        /// </summary>
        public void Unindent()
        {
            cbg_Tool_Unindent(selfPtr);
        }
        
        /// <summary>
        /// 仕切りを生成します。
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
        /// 'EndTooltip()' を呼び出してください
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
        public void SetWindowSize(Vector2F size)
        {
            cbg_Tool_SetWindowSize(selfPtr, size);
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
        public void SetNextWindowContentSize(Vector2F size)
        {
            cbg_Tool_SetNextWindowContentSize(selfPtr, size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowSize(Vector2F size, ToolCond cond)
        {
            cbg_Tool_SetNextWindowSize(selfPtr, size, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowPos(Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetNextWindowPos(selfPtr, pos, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsWindowAppearing()
        {
            var ret = cbg_Tool_IsWindowAppearing(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsWindowCollapsed()
        {
            var ret = cbg_Tool_IsWindowCollapsed(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsWindowFocused(ToolFocused flags)
        {
            var ret = cbg_Tool_IsWindowFocused(selfPtr, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsWindowHovered(ToolFocused flags)
        {
            var ret = cbg_Tool_IsWindowHovered(selfPtr, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetWindowPos()
        {
            var ret = cbg_Tool_GetWindowPos(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowCollapsed(bool collapsed, ToolCond cond)
        {
            cbg_Tool_SetNextWindowCollapsed(selfPtr, collapsed, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowFocus()
        {
            cbg_Tool_SetNextWindowFocus(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowBgAlpha(float alpha)
        {
            cbg_Tool_SetNextWindowBgAlpha(selfPtr, alpha);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowPosWithCond(Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetWindowPosWithCond(selfPtr, pos, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowSizeWithCond(Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetWindowSizeWithCond(selfPtr, pos, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowCollapsedWithCond(bool collapsed, ToolCond cond)
        {
            cbg_Tool_SetWindowCollapsedWithCond(selfPtr, collapsed, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowFocus()
        {
            cbg_Tool_SetWindowFocus(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowFontScale(float scale)
        {
            cbg_Tool_SetWindowFontScale(selfPtr, scale);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowPosByName(string name, Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetWindowPosByName(selfPtr, name, pos, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowSizeByName(string name, Vector2F pos, ToolCond cond)
        {
            cbg_Tool_SetWindowSizeByName(selfPtr, name, pos, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowCollapsedByName(string name, bool collapsed, ToolCond cond)
        {
            cbg_Tool_SetWindowCollapsedByName(selfPtr, name, collapsed, (int)cond);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetWindowFocusByName(string name)
        {
            cbg_Tool_SetWindowFocusByName(selfPtr, name);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetContentRegionMax()
        {
            var ret = cbg_Tool_GetContentRegionMax(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetContentRegionAvail()
        {
            var ret = cbg_Tool_GetContentRegionAvail(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetWindowContentRegionMin()
        {
            var ret = cbg_Tool_GetWindowContentRegionMin(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetWindowContentRegionMax()
        {
            var ret = cbg_Tool_GetWindowContentRegionMax(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetWindowContentRegionWidth()
        {
            var ret = cbg_Tool_GetWindowContentRegionWidth(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetScrollX()
        {
            var ret = cbg_Tool_GetScrollX(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetScrollY()
        {
            var ret = cbg_Tool_GetScrollY(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetScrollMaxX()
        {
            var ret = cbg_Tool_GetScrollMaxX(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetScrollMaxY()
        {
            var ret = cbg_Tool_GetScrollMaxY(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollX(float scrollX)
        {
            cbg_Tool_SetScrollX(selfPtr, scrollX);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollY(float scrollY)
        {
            cbg_Tool_SetScrollY(selfPtr, scrollY);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollHereX(float centerXRatio)
        {
            cbg_Tool_SetScrollHereX(selfPtr, centerXRatio);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollHereY(float centerYRatio)
        {
            cbg_Tool_SetScrollHereY(selfPtr, centerYRatio);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollFromPosX(float localX, float centerXRatio)
        {
            cbg_Tool_SetScrollFromPosX(selfPtr, localX, centerXRatio);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetScrollFromPosY(float localY, float centerYRatio)
        {
            cbg_Tool_SetScrollFromPosY(selfPtr, localY, centerYRatio);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushStyleColor(ToolColor idx, Color col)
        {
            cbg_Tool_PushStyleColor(selfPtr, (int)idx, col);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopStyleColor(int count)
        {
            cbg_Tool_PopStyleColor(selfPtr, count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushStyleVarFloat(ToolStyleVar idx, float val)
        {
            cbg_Tool_PushStyleVarFloat(selfPtr, (int)idx, val);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushStyleVarVector2F(ToolStyleVar idx, Vector2F val)
        {
            cbg_Tool_PushStyleVarVector2F(selfPtr, (int)idx, val);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopStyleVar(int count)
        {
            cbg_Tool_PopStyleVar(selfPtr, count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Color GetStyleColor(ToolColor idx)
        {
            var ret = cbg_Tool_GetStyleColor(selfPtr, (int)idx);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetFontTexUvWhitePixel()
        {
            var ret = cbg_Tool_GetFontTexUvWhitePixel(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextItemWidth(float itemWidth)
        {
            cbg_Tool_SetNextItemWidth(selfPtr, itemWidth);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float CalcItemWidth()
        {
            var ret = cbg_Tool_CalcItemWidth(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushAllowKeyboardFocus(bool allowKeyboardFocus)
        {
            cbg_Tool_PushAllowKeyboardFocus(selfPtr, allowKeyboardFocus);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopAllowKeyboardFocus()
        {
            cbg_Tool_PopAllowKeyboardFocus(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Spacing()
        {
            cbg_Tool_Spacing(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void BeginGroup()
        {
            cbg_Tool_BeginGroup(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndGroup()
        {
            cbg_Tool_EndGroup(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetCursorPos()
        {
            var ret = cbg_Tool_GetCursorPos(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetCursorPos(Vector2F localPos)
        {
            cbg_Tool_SetCursorPos(selfPtr, localPos);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetCursorStartPos()
        {
            var ret = cbg_Tool_GetCursorStartPos(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetCursorScreenPos()
        {
            var ret = cbg_Tool_GetCursorScreenPos(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void AlignTextToFramePadding()
        {
            cbg_Tool_AlignTextToFramePadding(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetTextLineHeightWithSpacing()
        {
            var ret = cbg_Tool_GetTextLineHeightWithSpacing(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetFrameHeight()
        {
            var ret = cbg_Tool_GetFrameHeight(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetFrameHeightWithSpacing()
        {
            var ret = cbg_Tool_GetFrameHeightWithSpacing(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 小さなボタンを生成します。
        /// </summary>
        /// <param name="label">表示するテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool SmallButton(string label)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_SmallButton(selfPtr, label);
            return ret;
        }
        
        /// <summary>
        /// 画像表示ボックスを生成します。
        /// </summary>
        /// <param name="texture">表示するテクスチャ</param>
        /// <param name="size">サイズ</param>
        /// <param name="uv0">テクスチャのUV値(0~1)</param>
        /// <param name="uv1">テクスチャのUV値(0~1)</param>
        /// <param name="tintColor">テクスチャの色</param>
        /// <param name="borderColor">縁の色</param>
        public void Image(TextureBase texture, Vector2F size, Vector2F uv0, Vector2F uv1, Color tintColor, Color borderColor)
        {
            cbg_Tool_Image(selfPtr, texture != null ? texture.selfPtr : IntPtr.Zero, size, uv0, uv1, tintColor, borderColor);
        }
        
        /// <summary>
        /// ボタンとして機能する画像表示ボックスを生成します。
        /// </summary>
        /// <param name="texture">表示するテクスチャ</param>
        /// <param name="size">サイズ</param>
        /// <param name="uv0">テクスチャのUV値(0~1)</param>
        /// <param name="uv1">テクスチャのUV値(0~1)</param>
        /// <param name="framePadding">縁の太さ</param>
        /// <param name="tintColor">テクスチャの色</param>
        /// <param name="borderColor">縁の色</param>
        /// <returns>クリックされたらtrue，それ以外でfalse</returns>
        public bool ImageButton(TextureBase texture, Vector2F size, Vector2F uv0, Vector2F uv1, int framePadding, Color tintColor, Color borderColor)
        {
            var ret = cbg_Tool_ImageButton(selfPtr, texture != null ? texture.selfPtr : IntPtr.Zero, size, uv0, uv1, framePadding, tintColor, borderColor);
            return ret;
        }
        
        /// <summary>
        /// プログレスバーを生成します。
        /// </summary>
        /// <param name="fraction">進行度(0.0~1.0)</param>
        /// <param name="sizeArg">サイズ</param>
        /// <param name="overlay">表示されるテキスト</param>
        /// <exception cref="ArgumentNullException"><paramref name="overlay"/>がnull</exception>
        public void ProgressBar(float fraction, Vector2F sizeArg, string overlay)
        {
            if (overlay == null) throw new ArgumentNullException(nameof(overlay), "引数がnullです");
            cbg_Tool_ProgressBar(selfPtr, fraction, sizeArg, overlay);
        }
        
        /// <summary>
        /// 点を生成します。
        /// </summary>
        public void Bullet()
        {
            cbg_Tool_Bullet(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void BeginCombo(string label, string previewValue, ToolComboFlags flags)
        {
            cbg_Tool_BeginCombo(selfPtr, label, previewValue, (int)flags);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndCombo()
        {
            cbg_Tool_EndCombo(selfPtr);
        }
        
        /// <summary>
        /// コンボボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルのテキスト</param>
        /// <param name="current_item">選択されているアイテムのインデックス -1で選択無し</param>
        /// <param name="items">タブ文字を用いて分割したアイテム</param>
        /// <param name="popupMaxHeightInItems">一度に表示する最大アイテム数</param>
        /// <exception cref="ArgumentNullException"><paramref name="label"/>がnull</exception>
        /// <returns>いずれかのアイテムがクリックされたらtrue，それ以外でfalse</returns>
        public bool Combo(string label, ref int current_item, string items, int popupMaxHeightInItems)
        {
            if (label == null) throw new ArgumentNullException(nameof(label), "引数がnullです");
            var ret = cbg_Tool_Combo(selfPtr, label, ref current_item, items, popupMaxHeightInItems);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ColorButton(string descId, ref Color col, ToolColorEditFlags flags, Vector2F size)
        {
            var ret = cbg_Tool_ColorButton(selfPtr, descId, ref col, (int)flags, size);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetColorEditOptions(ToolColorEditFlags flags)
        {
            cbg_Tool_SetColorEditOptions(selfPtr, (int)flags);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetTreeNodeToLabelSpacing()
        {
            var ret = cbg_Tool_GetTreeNodeToLabelSpacing(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ListBoxHeader(string flags, Vector2F size)
        {
            var ret = cbg_Tool_ListBoxHeader(selfPtr, flags, size);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void ListBoxFooter()
        {
            cbg_Tool_ListBoxFooter(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal void PlotLines(string label, FloatArray values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride)
        {
            cbg_Tool_PlotLines(selfPtr, label, values != null ? values.selfPtr : IntPtr.Zero, valuesCount, valuesOffset, overlayText, scaleMin, scaleMax, graphSize, stride);
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal void PlotHistogram(string label, FloatArray values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride)
        {
            cbg_Tool_PlotHistogram(selfPtr, label, values != null ? values.selfPtr : IntPtr.Zero, valuesCount, valuesOffset, overlayText, scaleMin, scaleMax, graphSize, stride);
        }
        
        /// <summary>
        /// boolの値を表示する
        /// </summary>
        /// <param name="prefix">表示するテキスト</param>
        /// <param name="b">表示するboolの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="prefix"/>がnull</exception>
        public void ValueBool(string prefix, bool b)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            cbg_Tool_ValueBool(selfPtr, prefix, b);
        }
        
        /// <summary>
        /// intの値を表示する
        /// </summary>
        /// <param name="prefix">表示するテキスト</param>
        /// <param name="v">表示するintの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="prefix"/>がnull</exception>
        public void ValueInt(string prefix, int v)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            cbg_Tool_ValueInt(selfPtr, prefix, v);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix">表示するテキスト</param>
        /// <param name="v">表示するfloatの値</param>
        /// <param name="floatFormat">使用するフォーマット</param>
        /// <exception cref="ArgumentNullException"><paramref name="prefix"/>, <paramref name="floatFormat"/>のいずれかがnull</exception>
        public void ValueFloat(string prefix, float v, string floatFormat)
        {
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "引数がnullです");
            if (floatFormat == null) throw new ArgumentNullException(nameof(floatFormat), "引数がnullです");
            cbg_Tool_ValueFloat(selfPtr, prefix, v, floatFormat);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool BeginMainMenuBar()
        {
            var ret = cbg_Tool_BeginMainMenuBar(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void EndMainMenuBar()
        {
            cbg_Tool_EndMainMenuBar(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool BeginPopupContextItem(string strId, int mouseButton)
        {
            var ret = cbg_Tool_BeginPopupContextItem(selfPtr, strId, mouseButton);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool BeginPopupContextWindow(string strId, int mouseButton, bool alsoOverItems)
        {
            var ret = cbg_Tool_BeginPopupContextWindow(selfPtr, strId, mouseButton, alsoOverItems);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool BeginPopupContextVoid(string strId, int mouseButton)
        {
            var ret = cbg_Tool_BeginPopupContextVoid(selfPtr, strId, mouseButton);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool BeginPopupModalEx(string name, out bool isOpen, ToolWindowFlags flags)
        {
            var ret = cbg_Tool_BeginPopupModalEx(selfPtr, name, out isOpen, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool OpenPopupOnItemClick(string strId, int mouseButton)
        {
            var ret = cbg_Tool_OpenPopupOnItemClick(selfPtr, strId, mouseButton);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsPopupOpen(string strId)
        {
            var ret = cbg_Tool_IsPopupOpen(selfPtr, strId);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void CloseCurrentPopup()
        {
            cbg_Tool_CloseCurrentPopup(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int GetColumnIndex()
        {
            var ret = cbg_Tool_GetColumnIndex(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetColumnWidth(int columnIndex)
        {
            var ret = cbg_Tool_GetColumnWidth(selfPtr, columnIndex);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetColumnWidth(int columnIndex, float width)
        {
            cbg_Tool_SetColumnWidth(selfPtr, columnIndex, width);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetColumnOffset(int columnIndex)
        {
            var ret = cbg_Tool_GetColumnOffset(selfPtr, columnIndex);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetColumnOffset(int columnIndex, float offsetX)
        {
            cbg_Tool_SetColumnOffset(selfPtr, columnIndex, offsetX);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int GetColumnsCount()
        {
            var ret = cbg_Tool_GetColumnsCount(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetTabItemClosed(string tabOrDockedWindowLabel)
        {
            cbg_Tool_SetTabItemClosed(selfPtr, tabOrDockedWindowLabel);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PushClipRect(Vector2F clipRectMin, Vector2F clipRectMax, bool intersectWithCurrentClipRect)
        {
            cbg_Tool_PushClipRect(selfPtr, clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void PopClipRect()
        {
            cbg_Tool_PopClipRect(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetItemDefaultFocus()
        {
            cbg_Tool_SetItemDefaultFocus(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetKeyboardFocusHere(int offset)
        {
            cbg_Tool_SetKeyboardFocusHere(selfPtr, offset);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemHoveredWithFlags(ToolHoveredFlags flags)
        {
            var ret = cbg_Tool_IsItemHoveredWithFlags(selfPtr, (int)flags);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemFocused()
        {
            var ret = cbg_Tool_IsItemFocused(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemClicked(int mouseButton)
        {
            var ret = cbg_Tool_IsItemClicked(selfPtr, mouseButton);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemVisible()
        {
            var ret = cbg_Tool_IsItemVisible(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemEdited()
        {
            var ret = cbg_Tool_IsItemEdited(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemActivated()
        {
            var ret = cbg_Tool_IsItemActivated(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemDeactivated()
        {
            var ret = cbg_Tool_IsItemDeactivated(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemDeactivatedAfterEdit()
        {
            var ret = cbg_Tool_IsItemDeactivatedAfterEdit(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnyItemHovered()
        {
            var ret = cbg_Tool_IsAnyItemHovered(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnyItemActive()
        {
            var ret = cbg_Tool_IsAnyItemActive(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnyItemFocused()
        {
            var ret = cbg_Tool_IsAnyItemFocused(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetItemRectMin()
        {
            var ret = cbg_Tool_GetItemRectMin(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetItemRectMax()
        {
            var ret = cbg_Tool_GetItemRectMax(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2F GetItemRectSize()
        {
            var ret = cbg_Tool_GetItemRectSize(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetItemAllowOverlap()
        {
            cbg_Tool_SetItemAllowOverlap(selfPtr);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void IsRectVisible(Vector2F size)
        {
            cbg_Tool_IsRectVisible(selfPtr, size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void IsRectVisibleVector2F2(Vector2F rectMin, Vector2F rectMax)
        {
            cbg_Tool_IsRectVisibleVector2F2(selfPtr, rectMin, rectMax);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float GetTime()
        {
            var ret = cbg_Tool_GetTime(selfPtr);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string GetClipboardText()
        {
            var ret = cbg_Tool_GetClipboardText(selfPtr);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetClipboardText(string text)
        {
            cbg_Tool_SetClipboardText(selfPtr, text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void LoadIniSettingsFromDisk(string iniFilename)
        {
            cbg_Tool_LoadIniSettingsFromDisk(selfPtr, iniFilename);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SaveIniSettingsToDisk(string iniFilename)
        {
            cbg_Tool_SaveIniSettingsToDisk(selfPtr, iniFilename);
        }
        
        /// <summary>
        /// 1つの開くファイルを選択するダイアログを開きます。
        /// </summary>
        /// <param name="filter">読み込むファイルの拡張子のフィルタ</param>
        /// <param name="defaultPath">ファイルダイアログの初期位置のパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="filter"/>, <paramref name="defaultPath"/>のいずれかがnull</exception>
        /// <returns>読み込むファイルのパス</returns>
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
        /// <returns>読み込むファイルのパス</returns>
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
        /// <returns>保存するファイルのパス</returns>
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
        /// <returns>選択するフォルダのパス</returns>
        public string PickFolder(string defaultPath)
        {
            if (defaultPath == null) throw new ArgumentNullException(nameof(defaultPath), "引数がnullです");
            var ret = cbg_Tool_PickFolder(selfPtr, defaultPath);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ret);
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
        private static extern IntPtr cbg_StreamFile_GetTempBuffer(IntPtr selfPtr);
        
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
        internal string Path
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
        /// <returns>pathで読み込むファイルを格納する<see cref="StreamFile"/>の新しいインスタンスを生成します。</returns>
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
        private static extern IntPtr cbg_StaticFile_GetBuffer(IntPtr selfPtr);
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_StaticFile_Reload(IntPtr selfPtr);
        
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
        /// <returns>pathで読み込んだファイルを格納する<see cref="StaticFile"/>の新しいインスタンスを生成します。</returns>
        public static StaticFile Create(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
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
    /// ファイル制御を行うクラス
    /// </summary>
    public sealed partial class File
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<File>> cacheRepo = new Dictionary<IntPtr, WeakReference<File>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>追加処理がうまくいったらtrue，それ以外でfalse</returns>
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
        /// <returns>読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
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
        /// <returns>読み込み処理がうまくいったらtrue，それ以外でfalse</returns>
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
        /// <returns>pathの示すファイルが存在していたらtrue，それ以外でfalse</returns>
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
        /// <returns>パック処理がうまくいったらtrue，それ以外でfalse</returns>
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
        /// <returns>パック処理がうまくいったらtrue，それ以外でfalse</returns>
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
    /// 音源のクラス
    /// </summary>
    [Serializable]
    public sealed partial class Sound : ISerializable, ICacheKeeper<Sound>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static ConcurrentDictionary<IntPtr, WeakReference<Sound>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Sound>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    cacheRepo.TryRemove(native, out _);
                }
            }
        
            var newObject = new Sound(new MemoryHandle(native));
            cacheRepo.TryAdd(native, new WeakReference<Sound>(newObject));
            return newObject;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_Sound_Load([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool isDecompressed);
        
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
        /// <returns>読み込んだ音源データ</returns>
        public static Sound Load(string path, bool isDecompressed)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Sound_Load(path, isDecompressed);
            return Sound.TryGetFromCache(ret);
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
            CacheHelper.CacheHandlingOnDeserializationConcurrent(this, ptr);
            
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
        /// <returns>再生中の音のID</returns>
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
        /// <returns>IDに対応する音が再生中であるかどうか</returns>
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
        /// <param name="volume">音量(0.0〜1.0)</param>
        public void SetVolume(int id, float volume)
        {
            cbg_SoundMixer_SetVolume(selfPtr, id, volume);
        }
        
        /// <summary>
        /// 指定した音をフェードインさせます。
        /// </summary>
        /// <param name="id"></param>
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
        /// <param name="targetedVolume">変更後の音量(0.0〜1.0)</param>
        public void Fade(int id, float second, float targetedVolume)
        {
            cbg_SoundMixer_Fade(selfPtr, id, second, targetedVolume);
        }
        
        /// <summary>
        /// 再生速度を変更するかを取得します。
        /// </summary>
        /// <param name="id">音のID</param>
        /// <returns>再生速度を変更するかどうか</returns>
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
        /// <returns>本来の速度の何倍で再生されているかどうか</returns>
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
        internal void GetSpectrum(int id, FloatArray spectrums, FFTWindow window)
        {
            cbg_SoundMixer_GetSpectrum(selfPtr, id, spectrums != null ? spectrums.selfPtr : IntPtr.Zero, (int)window);
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
    /// ログを出力するクラス
    /// </summary>
    public sealed partial class Log
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Log>> cacheRepo = new Dictionary<IntPtr, WeakReference<Log>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    
    internal sealed partial class Window
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Window>> cacheRepo = new Dictionary<IntPtr, WeakReference<Window>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  Window TryGetFromCache(IntPtr native)
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
        /// <returns>使用するインスタンス</returns>
        internal static Window GetInstance()
        {
            var ret = cbg_Window_GetInstance();
            return Window.TryGetFromCache(ret);
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
    /// コライダの抽象基本クラスです
    /// </summary>
    [Serializable]
    public partial class Collider : ISerializable, ICacheKeeper<Collider>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<Collider>> cacheRepo = new Dictionary<IntPtr, WeakReference<Collider>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static  Collider TryGetFromCache(IntPtr native)
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
        
        /// <summary>
        /// 指定したコライダとの衝突判定を行います。
        /// </summary>
        public bool GetIsCollidedWith(Collider collider)
        {
            var ret = cbg_Collider_GetIsCollidedWith(selfPtr, collider != null ? collider.selfPtr : IntPtr.Zero);
            return ret;
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
    /// 円形コライダのクラス
    /// </summary>
    [Serializable]
    public partial class CircleCollider : Collider, ISerializable, ICacheKeeper<CircleCollider>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<CircleCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<CircleCollider>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static new CircleCollider TryGetFromCache(IntPtr native)
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
    /// 矩形コライダのクラス
    /// </summary>
    [Serializable]
    public partial class RectangleCollider : Collider, ISerializable, ICacheKeeper<RectangleCollider>
    {
        #region unmanaged
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static Dictionary<IntPtr, WeakReference<RectangleCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<RectangleCollider>>();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
                internal static new RectangleCollider TryGetFromCache(IntPtr native)
        {
            if(native == IntPtr.Zero) return null;
        
            if(cacheRepo.ContainsKey(native))
            {
                RectangleCollider cacheRet;
                cacheRepo[native].TryGetTarget(out cacheRet);
                if(cacheRet != null)
                {
                    cbg_RectangleCollider_Release(native);
                    return cacheRet;
                }
                else
                {
                    cacheRepo.Remove(native);
                }
            }
        
            var newObject = new RectangleCollider(new MemoryHandle(native));
            cacheRepo[native] = new WeakReference<RectangleCollider>(newObject);
            return newObject;
        }
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern IntPtr cbg_RectangleCollider_Create();
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_RectangleCollider_GetSize(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RectangleCollider_SetSize(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern Vector2F cbg_RectangleCollider_GetCenterPosition(IntPtr selfPtr);
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RectangleCollider_SetCenterPosition(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed2_Core")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static extern void cbg_RectangleCollider_Release(IntPtr selfPtr);
        
        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal RectangleCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 矩形コライダの幅・高さを取得または設定します。
        /// </summary>
        public Vector2F Size
        {
            get
            {
                if (_Size != null)
                {
                    return _Size.Value;
                }
                var ret = cbg_RectangleCollider_GetSize(selfPtr);
                return ret;
            }
            set
            {
                _Size = value;
                cbg_RectangleCollider_SetSize(selfPtr, value);
            }
        }
        private Vector2F? _Size;
        
        /// <summary>
        /// 矩形コライダの中心の位置を取得または設定します。
        /// </summary>
        public Vector2F CenterPosition
        {
            get
            {
                if (_CenterPosition != null)
                {
                    return _CenterPosition.Value;
                }
                var ret = cbg_RectangleCollider_GetCenterPosition(selfPtr);
                return ret;
            }
            set
            {
                _CenterPosition = value;
                cbg_RectangleCollider_SetCenterPosition(selfPtr, value);
            }
        }
        private Vector2F? _CenterPosition;
        
        /// <summary>
        /// 矩形コライダを作成します。
        /// </summary>
        public static RectangleCollider Create()
        {
            var ret = cbg_RectangleCollider_Create();
            return RectangleCollider.TryGetFromCache(ret);
        }
        
        
        #region ISerialiable
        
        #region SerializeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_Size = "S_Size";
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const string S_CenterPosition = "S_CenterPosition";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RectangleCollider"/>のインスタンスを生成します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected RectangleCollider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = selfPtr;
            if (ptr == IntPtr.Zero) ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingOnDeserialization(this, ptr);
            
            Size = info.GetValue<Vector2F>(S_Size);
            CenterPosition = info.GetValue<Vector2F>(S_CenterPosition);
            
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
            
            info.AddValue(S_Size, Size);
            info.AddValue(S_CenterPosition, CenterPosition);
            
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
        /// <see cref="RectangleCollider(SerializationInfo, StreamingContext)"/>内で実行します。
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        
        /// <summary>
        /// <see cref="RectangleCollider(SerializationInfo, StreamingContext)"/>内で呼び出される
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
        IDictionary<IntPtr, WeakReference<RectangleCollider>> ICacheKeeper<RectangleCollider>.CacheRepo => cacheRepo;
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        IntPtr ICacheKeeper<RectangleCollider>.Self
        {
            get => selfPtr;
            set
            {
                selfPtr = value;
            }
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ICacheKeeper<RectangleCollider>.Release(IntPtr native) => cbg_RectangleCollider_Release(native);
        
        #endregion
        
        #endregion
        
        /// <summary>
        /// <see cref="RectangleCollider"/>のインスタンスを削除します。
        /// </summary>
        ~RectangleCollider()
        {
            lock (this) 
            {
                if (selfPtr != IntPtr.Zero)
                {
                    cbg_RectangleCollider_Release(selfPtr);
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
                internal static new PolygonCollider TryGetFromCache(IntPtr native)
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
    
}
