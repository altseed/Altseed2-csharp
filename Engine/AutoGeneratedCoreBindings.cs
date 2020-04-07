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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Runtime.Serialization;

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
    /// 描画方法を表します。
    /// </summary>
    [Serializable]
    public enum GraphicsDeviceType : int
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
        /// <see cref="Altseed.StaticFile"/>を表す
        /// </summary>
        StaticFile,
        /// <summary>
        /// <see cref="Altseed.StreamFile"/>を表す
        /// </summary>
        StreamFile,
        /// <summary>
        /// <see cref="Altseed.Texture2D"/>を表す
        /// </summary>
        Texture2D,
        /// <summary>
        /// <see cref="Altseed.Font"/>を表す
        /// </summary>
        Font,
        /// <summary>
        /// <see cref="Altseed.Sound"/>を表す
        /// </summary>
        Sound,
        MAX,
    }
    
    /// <summary>
    /// キーボードのキーの種類を表します。
    /// </summary>
    [Serializable]
    public enum Keys : int
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
        MAX,
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
    public enum MouseButtons : int
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
        /// PlayStation4のジョイスティック
        /// </summary>
        PS4 = 8200,
        /// <summary>
        /// XBOX360のジョイスティック
        /// </summary>
        XBOX360 = 8199,
        /// <summary>
        /// NintendoSwitchの左ジョイスティック
        /// </summary>
        JoyconL = 8198,
        /// <summary>
        /// NintendoSwitchの右ジョイスティック
        /// </summary>
        JoyconR = 8197,
    }
    
    /// <summary>
    /// ジョイスティックのボタンの種類を表します。
    /// </summary>
    [Serializable]
    public enum JoystickButtonType : int
    {
        /// <summary>
        /// スタートボタン
        /// </summary>
        Start,
        /// <summary>
        /// セレクトボタン
        /// </summary>
        Select,
        /// <summary>
        /// ホームボタン
        /// </summary>
        Home,
        /// <summary>
        /// リリースボタン
        /// </summary>
        Release,
        /// <summary>
        /// キャプチャーボタン
        /// </summary>
        Capture,
        /// <summary>
        /// 左十字キー上
        /// </summary>
        LeftUp,
        /// <summary>
        /// 左十字キー下
        /// </summary>
        LeftDown,
        /// <summary>
        /// 左十字キー左
        /// </summary>
        LeftLeft,
        /// <summary>
        /// 左十字キー右
        /// </summary>
        LeftRight,
        /// <summary>
        /// 左
        /// </summary>
        LeftPush,
        /// <summary>
        /// 右十字キー上
        /// </summary>
        RightUp,
        /// <summary>
        /// 右十字キー右
        /// </summary>
        RightRight,
        /// <summary>
        /// 右十字キー左
        /// </summary>
        RightLeft,
        /// <summary>
        /// 右十字キー下
        /// </summary>
        RightDown,
        /// <summary>
        /// 右
        /// </summary>
        RightPush,
        /// <summary>
        /// Lボタン1
        /// </summary>
        L1,
        /// <summary>
        /// Rボタン1
        /// </summary>
        R1,
        /// <summary>
        /// Lボタン2
        /// </summary>
        L2,
        /// <summary>
        /// Rボタン2
        /// </summary>
        R2,
        /// <summary>
        /// Lボタン3
        /// </summary>
        L3,
        /// <summary>
        /// Rボタン3
        /// </summary>
        R3,
        /// <summary>
        /// 左スタートボタン
        /// </summary>
        LeftStart,
        /// <summary>
        /// 右スタートボタン
        /// </summary>
        RightStart,
        Max,
    }
    
    /// <summary>
    /// ジョイスティックの軸の種類を表します。
    /// </summary>
    [Serializable]
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
    
    [Serializable]
    public enum DeviceType : int
    {
    }
    
    [Serializable]
    public enum ShaderStageType : int
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
    /// 
    /// </summary>
    [Serializable]
    public enum RenderTargetCareType : int
    {
        /// <summary>
        /// クリアしない
        /// </summary>
        DontCare,
        /// <summary>
        /// クリアする
        /// </summary>
        Clear,
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
    
    [Serializable]
    public enum ToolTreeNode : int
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
    [Serializable]
    public enum ToolInputText : int
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
        /// （値が変更されるたびにではなく）Enterが押されたときに `true` を返します。 `IsItemDeactivatedAfterEdit()` 関数を調べることを検討してください。
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
    [Serializable]
    public enum ToolColorEdit : int
    {
        None = 0,
        /// <summary>
        /// `ColorEdit, ColorPicker, ColorButton`: Alphaコンポーネントを無視します（入力ポインターから3つのコンポーネントのみを読み取ります）。
        /// </summary>
        NoAlpha = 2,
        /// <summary>
        /// `ColorEdit`: 色付きの正方形をクリックしたときにピッカーを無効にします。
        /// </summary>
        NoPicker = 4,
        /// <summary>
        /// `ColorEdit`: 入力/小さなプレビューを右クリックしたときのオプションメニューの切り替えを無効にします。
        /// </summary>
        NoOptions = 8,
        /// <summary>
        /// `ColorEdit, ColorPicker`: 入力の横にある色付きの正方形プレビューを無効にします。 （例：入力のみを表示する）
        /// </summary>
        NoSmallPreview = 16,
        /// <summary>
        /// `ColorEdit, ColorPicker: 入力スライダー/テキストウィジェットを無効にします（たとえば、小さなプレビューの色付きの四角形のみを表示します）。
        /// </summary>
        NoInputs = 32,
        /// <summary>
        /// `ColorEdit, ColorPicker, ColorButton`: プレビューをホバーするときにツールチップを無効にします。
        /// </summary>
        NoTooltip = 64,
        /// <summary>
        /// `ColorEdit, ColorPicker`: インラインテキストラベルの表示を無効にします（ラベルは引き続きツールチップとピッカーに転送されます）。
        /// </summary>
        NoLabel = 128,
        /// <summary>
        /// `ColorPicker`: ピッカーの右側の大きなカラープレビューを無効にし、代わりに小さな色付きの正方形プレビューを使用します。
        /// </summary>
        NoSidePreview = 256,
        /// <summary>
        /// `ColorEdit`: ドラッグアンドドロップターゲットを無効にします。 `ColorButton`: ドラッグアンドドロップソースを無効にします。
        /// </summary>
        NoDragDrop = 512,
        /// <summary>
        /// `ColorEdit, ColorPicker`: ピッカーに垂直アルファバー/グラデーションを表示します。
        /// </summary>
        AlphaBar = 65536,
        /// <summary>
        /// `ColorEdit, ColorPicker, ColorButton`: プレビューを不透明ではなく、チェッカーボード上の透明色として表示します。
        /// </summary>
        AlphaPreview = 131072,
        /// <summary>
        /// `ColorEdit, ColorPicker, ColorButton`: 不透明ではなく、半不透明/半市松模様を表示します。
        /// </summary>
        AlphaPreviewHalf = 262144,
        /// <summary>
        /// `(WIP) ColorEdit`: 現在、RGBAエディションで0.0f..1.0fの制限のみを無効にします（注：おそらくFloatフラグも使用したいでしょう）。
        /// </summary>
        HDR = 524288,
        /// <summary>
        /// `ColorEdit`: RGB/HSV/Hexの_display_タイプをオーバーライドします。 `ColorPicker`: 1つ以上のRGB/HSV/Hexを使用して任意の組み合わせを選択します。
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
        /// `ColorEdit, ColorPicker, ColorButton`: 0..255としてフォーマットされた_display_値。
        /// </summary>
        Uint8 = 8388608,
        /// <summary>
        /// `ColorEdit, ColorPicker, ColorButton`: _display_値は、0..255整数ではなく0.0f..1.0f浮動小数点としてフォーマットされます。 整数による値の往復はありません。
        /// </summary>
        Float = 16777216,
        /// <summary>
        /// `ColorPicker`: Hueのバー、Sat/Valueの長方形。
        /// </summary>
        PickerHueBar = 33554432,
        /// <summary>
        /// `ColorPicker`: Hueのホイール、Sat/Valueの三角形。
        /// </summary>
        PickerHueWheel = 67108864,
        /// <summary>
        /// `ColorEdit, ColorPicker`: RGB形式の入出力データ
        /// </summary>
        InputRGB = 134217728,
        /// <summary>
        /// `ColorEdit, ColorPicker`: HSV形式の入力および出力データ。
        /// </summary>
        InputHSV = 268435456,
        /// <summary>
        /// デフォルトオプション。 `SetColorEditOptions()` を使用して、アプリケーションのデフォルトを設定できます。 意図はおそらくあなたの呼び出しのほとんどでそれらをオーバーライドしたくないことです。 ユーザーがオプションメニューから選択できるようにするか、起動時に`SetColorEditOptions()`を1回呼び出します。
        /// </summary>
        OptionsDefault = 177209344,
    }
    
    [Serializable]
    public enum ToolSelectable : int
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
    [Serializable]
    public enum ToolWindow : int
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
        /// 描画背景色(`WindowBg`など)および外枠を無効にします。 `SetNextWindowBgAlpha(0.0f)`を使用する場合と同様です。
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
        /// 水平スクロールバーの表示を許可します（デフォルトではオフ）。 `Begin()`を呼び出す前に、`SetNextWindowContentSize(Vector2F(width, 0.0f));`を使用して幅を指定できます。
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
        /// 常に垂直スクロールバーを表示します（`ContentSize.Y < Size.Y`の場合でも）
        /// </summary>
        AlwaysVerticalScrollbar = 16384,
        /// <summary>
        /// 常に水平スクロールバーを表示します（`ContentSize.x < Size.x`であっても）
        /// </summary>
        AlwaysHorizontalScrollbar = 32768,
        /// <summary>
        /// 境界線のない子ウィンドウが`style.WindowPadding`を使用するようにします（境界線のない子ウィンドウではデフォルトで無視されるため、より便利です）
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
    [Serializable]
    public enum ToolTabBar : int
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
        /// マウスの中ボタンでタブを閉じる（p_open！= NULLで送信される）動作を無効にします。 `if（IsItemHovered（）&& IsMouseClicked（2））* p_open = false`を使用すると、ユーザー側でこの動作を再現できます。
        /// </summary>
        NoCloseWithMiddleMouseButton = 8,
        /// <summary>
        /// スクロールボタンを無効にする（フィッティングポリシーが`FittingPolicyScroll`の場合に適用）
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
    public enum ToolGlyphRanges : int
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
        private static extern bool cbg_Configuration_GetIsFullscreen(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetIsFullscreen(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetIsResizable(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetIsResizable(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Configuration_GetDeviceType(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetDeviceType(IntPtr selfPtr, int value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetWaitVSync(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetWaitVSync(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetConsoleLoggingEnabled(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetConsoleLoggingEnabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetFileLoggingEnabled(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetFileLoggingEnabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Configuration_GetLogFileName(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetLogFileName(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Configuration_GetToolEnabled(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Configuration_SetToolEnabled(IntPtr selfPtr, [MarshalAs(UnmanagedType.Bool)] bool value);
        
        
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
        public GraphicsDeviceType DeviceType
        {
            get
            {
                if (_DeviceType != null)
                {
                    return _DeviceType.Value;
                }
                var ret = cbg_Configuration_GetDeviceType(selfPtr);
                return (GraphicsDeviceType)ret;
            }
            set
            {
                _DeviceType = value;
                cbg_Configuration_SetDeviceType(selfPtr, (int)value);
            }
        }
        private GraphicsDeviceType? _DeviceType;
        
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
        
        /// <summary>
        /// ツール機能を使用するかどうかを取得または設定します。
        /// </summary>
        public bool ToolEnabled
        {
            get
            {
                if (_ToolEnabled != null)
                {
                    return _ToolEnabled.Value;
                }
                var ret = cbg_Configuration_GetToolEnabled(selfPtr);
                return ret;
            }
            set
            {
                _ToolEnabled = value;
                cbg_Configuration_SetToolEnabled(selfPtr, value);
            }
        }
        private bool? _ToolEnabled;
        
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Configuration()
        {
            selfPtr = cbg_Configuration_Constructor_0();
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_IsFullscreen = "S_IsFullscreen";
        private const string S_IsResizable = "S_IsResizable";
        private const string S_DeviceType = "S_DeviceType";
        private const string S_WaitVSync = "S_WaitVSync";
        private const string S_ConsoleLoggingEnabled = "S_ConsoleLoggingEnabled";
        private const string S_FileLoggingEnabled = "S_FileLoggingEnabled";
        private const string S_LogFileName = "S_LogFileName";
        private const string S_ToolEnabled = "S_ToolEnabled";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Configuration"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Configuration(SerializationInfo info, StreamingContext context) : this()
        {
            IsFullscreen = info.GetBoolean(S_IsFullscreen);
            IsResizable = info.GetBoolean(S_IsResizable);
            DeviceType = info.GetValue<GraphicsDeviceType>(S_DeviceType);
            WaitVSync = info.GetBoolean(S_WaitVSync);
            ConsoleLoggingEnabled = info.GetBoolean(S_ConsoleLoggingEnabled);
            FileLoggingEnabled = info.GetBoolean(S_FileLoggingEnabled);
            LogFileName = info.GetString(S_LogFileName);
            ToolEnabled = info.GetBoolean(S_ToolEnabled);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_IsFullscreen, IsFullscreen);
            info.AddValue(S_IsResizable, IsResizable);
            info.AddValue(S_DeviceType, DeviceType);
            info.AddValue(S_WaitVSync, WaitVSync);
            info.AddValue(S_ConsoleLoggingEnabled, ConsoleLoggingEnabled);
            info.AddValue(S_FileLoggingEnabled, FileLoggingEnabled);
            info.AddValue(S_LogFileName, LogFileName);
            info.AddValue(S_ToolEnabled, ToolEnabled);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Configuration(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Configuration(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        #endregion
        
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
    [Serializable]
    internal sealed partial class Int8Array : ISerializable, ICacheKeeper<Int8Array>
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Count = "S_Count";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Int8Array"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Int8Array(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Count, Count);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="Int8Array(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Int8Array.Count"/></param>
        private void Int8Array_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Int8Array>> ICacheKeeper<Int8Array>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Int8Array>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Int8Array>.Release(IntPtr native) => cbg_Int8Array_Release(native);
        #endregion
        
        #endregion
        
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Count = "S_Count";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Int32Array"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Int32Array(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Count, Count);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="Int32Array(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Int32Array.Count"/></param>
        private void Int32Array_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Int32Array>> ICacheKeeper<Int32Array>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Int32Array>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Int32Array>.Release(IntPtr native) => cbg_Int32Array_Release(native);
        #endregion
        
        #endregion
        
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
        private static extern void cbg_VertexArray_SetAt(IntPtr selfPtr, int index, Vertex value);
        
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
        public void SetAt(int index, Vertex value)
        {
            cbg_VertexArray_SetAt(selfPtr, index, value);
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Count = "S_Count";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="VertexArray"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private VertexArray(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Count, Count);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="VertexArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="VertexArray.Count"/></param>
        private void VertexArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<VertexArray>> ICacheKeeper<VertexArray>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<VertexArray>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<VertexArray>.Release(IntPtr native) => cbg_VertexArray_Release(native);
        #endregion
        
        #endregion
        
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Count = "S_Count";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="FloatArray"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private FloatArray(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Count, Count);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="FloatArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="FloatArray.Count"/></param>
        private void FloatArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<FloatArray>> ICacheKeeper<FloatArray>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<FloatArray>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<FloatArray>.Release(IntPtr native) => cbg_FloatArray_Release(native);
        #endregion
        
        #endregion
        
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
        
        private static Dictionary<IntPtr, WeakReference<Vector2FArray>> cacheRepo = new Dictionary<IntPtr, WeakReference<Vector2FArray>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_Clear(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_Resize(IntPtr selfPtr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Vector2FArray_GetData(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_Assign(IntPtr selfPtr, IntPtr ptr, int size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_CopyTo(IntPtr selfPtr, IntPtr ptr);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Vector2FArray_GetAt(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_SetAt(IntPtr selfPtr, int index, Vector2F value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Vector2FArray_Create(int size);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Vector2FArray_GetCount(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Vector2FArray_Release(IntPtr selfPtr);
        
        #endregion
        
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
        public void Clear()
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
        
        public IntPtr GetData()
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
        public Vector2F GetAt(int index)
        {
            var ret = cbg_Vector2FArray_GetAt(selfPtr, index);
            return ret;
        }
        
        /// <summary>
        /// インデックスアクセス
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="value">値</param>
        public void SetAt(int index, Vector2F value)
        {
            cbg_Vector2FArray_SetAt(selfPtr, index, value);
        }
        
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="size">要素数</param>
        public static Vector2FArray Create(int size)
        {
            var ret = cbg_Vector2FArray_Create(size);
            return Vector2FArray.TryGetFromCache(ret);
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_Count = "S_Count";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Vector2FArray"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Vector2FArray(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Count, Count);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="Vector2FArray(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Count"><see cref="Vector2FArray.Count"/></param>
        private void Vector2FArray_Unsetter_Deserialize(SerializationInfo info, out int Count)
        {
            Count = info.GetInt32(S_Count);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Vector2FArray>> ICacheKeeper<Vector2FArray>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Vector2FArray>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Vector2FArray>.Release(IntPtr native) => cbg_Vector2FArray_Release(native);
        #endregion
        
        #endregion
        
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
    /// カーソルを表します。
    /// </summary>
    public sealed partial class Cursor
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Cursor>> cacheRepo = new Dictionary<IntPtr, WeakReference<Cursor>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Cursor_Create([MarshalAs(UnmanagedType.LPWStr)] string path, Vector2I hot);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Cursor_Release(IntPtr selfPtr);
        
        #endregion
        
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
    public sealed partial class Mouse
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
        private static extern int cbg_Mouse_GetMouseButtonState(IntPtr selfPtr, int button);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetCursorImage(IntPtr selfPtr, IntPtr cursor);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Mouse_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetPosition(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Mouse_GetCursorMode(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Mouse_SetCursorMode(IntPtr selfPtr, int value);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Mouse_GetWheel(IntPtr selfPtr);
        
        
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
        public ButtonState GetMouseButtonState(MouseButtons button)
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
    public sealed partial class Joystick
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
        private static extern void cbg_Joystick_Vibrate(IntPtr selfPtr, int index, float frequency, float amplitude);
        
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
        internal ButtonState GetButtonStateByIndex(int joystickIndex, int buttonIndex)
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
        internal ButtonState GetButtonStateByType(int joystickIndex, JoystickButtonType type)
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
        internal float GetAxisStateByIndex(int joystickIndex, int axisIndex)
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
        internal float GetAxisStateByType(int joystickIndex, JoystickAxisType type)
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
        /// 指定したジョイスティックコントローラーを振動させます
        /// </summary>
        /// <param name="index">ジョイスティックのインデックス</param>
        /// <param name="frequency">周波数</param>
        /// <param name="amplitude">振幅</param>
        public void Vibrate(int index, float frequency, float amplitude)
        {
            cbg_Joystick_Vibrate(selfPtr, index, frequency, amplitude);
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
    internal sealed partial class Graphics
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
        private static extern IntPtr cbg_Graphics_GetBuiltinShader(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern Color cbg_Graphics_GetClearColor(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Graphics_SetClearColor(IntPtr selfPtr, Color value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Graphics_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Graphics(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        /// クリア色を取得または設定します。
        /// </summary>
        public Color ClearColor
        {
            get
            {
                if (_ClearColor != null)
                {
                    return _ClearColor.Value;
                }
                var ret = cbg_Graphics_GetClearColor(selfPtr);
                return ret;
            }
            set
            {
                _ClearColor = value;
                cbg_Graphics_SetClearColor(selfPtr, value);
            }
        }
        private Color? _ClearColor;
        
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
        internal bool BeginFrame()
        {
            var ret = cbg_Graphics_BeginFrame(selfPtr);
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
        
        private static ConcurrentDictionary<IntPtr, WeakReference<TextureBase>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<TextureBase>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_TextureBase_Save(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_TextureBase_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_TextureBase_Release(IntPtr selfPtr);
        
        #endregion
        
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
        /// png画像として保存します
        /// </summary>
        /// <param name="path">保存先</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>成功したか否か</returns>
        public bool Save(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_TextureBase_Save(selfPtr, path);
            return ret;
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_Size = "S_Size";
        #endregion
        
        private SerializationInfo seInfo;
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="TextureBase"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected TextureBase(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Size, Size);
            
            OnGetObjectData(info, context);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="TextureBase(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private virtual IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Size"><see cref="TextureBase.Size"/></param>
        protected private void TextureBase_Unsetter_Deserialize(SerializationInfo info, out Vector2I Size)
        {
            Size = info.GetValue<Vector2I>(S_Size);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<TextureBase>> ICacheKeeper<TextureBase>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<TextureBase>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<TextureBase>.Release(IntPtr native) => cbg_TextureBase_Release(native);
        #endregion
        
        #endregion
        
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            
            var ptr = Call_GetPtr(seInfo);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
            
            OnDeserialize_Method(sender);
            
            seInfo = null;
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>中で実行される
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        partial void OnDeserialize_Method(object sender);
        
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
        
        private static ConcurrentDictionary<IntPtr, WeakReference<Texture2D>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Texture2D>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Texture2D_Load([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Texture2D_Reload(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Texture2D_GetPath(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Texture2D_Release(IntPtr selfPtr);
        
        #endregion
        
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
        private const string S_Path = "S_Path";
        #endregion
        
        private SerializationInfo seInfo;
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Texture2D"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
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
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Path, Path);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Texture2D(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Path"><see cref="Texture2D.Path"/></param>
        private void Texture2D_Unsetter_Deserialize(SerializationInfo info, out string Path)
        {
            Path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Texture2D>> ICacheKeeper<Texture2D>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Texture2D>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Texture2D>.Release(IntPtr native) => cbg_Texture2D_Release(native);
        #endregion
        
        #endregion
        
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        protected override void OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            
            var ptr = Call_GetPtr(seInfo);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
            base.OnDeserialization(sender);
            
            OnDeserialize_Method(sender);
            
            seInfo = null;
        }
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>中で実行される
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        partial void OnDeserialize_Method(object sender);
        
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
        
        private static Dictionary<IntPtr, WeakReference<RenderTexture>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderTexture>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderTexture_Create(Vector2I size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderTexture_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderTexture(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        public static RenderTexture Create(Vector2I size)
        {
            var ret = cbg_RenderTexture_Create(size);
            return RenderTexture.TryGetFromCache(ret);
        }
        
        #region ISerialiable
        #region SerializeName
        #endregion
        
        private SerializationInfo seInfo;
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderTexture"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
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
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderTexture(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderTexture>> ICacheKeeper<RenderTexture>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<RenderTexture>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<RenderTexture>.Release(IntPtr native) => cbg_RenderTexture_Release(native);
        #endregion
        
        #endregion
        
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        protected override void OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            
            var ptr = Call_GetPtr(seInfo);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            base.OnDeserialization(sender);
            
            OnDeserialize_Method(sender);
            
            seInfo = null;
        }
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>中で実行される
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        partial void OnDeserialize_Method(object sender);
        
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
    public sealed partial class Material
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
        private static extern void cbg_Material_SetVector4F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Vector4F value);
        
        [DllImport("Altseed_Core")]
        private static extern Matrix44F cbg_Material_GetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetMatrix44F(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, Matrix44F value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Material_GetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetTexture(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string key, IntPtr value);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Material_GetShader(IntPtr selfPtr, int shaderStage);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_SetShader(IntPtr selfPtr, IntPtr shader);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Material_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Material(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public Material()
        {
            selfPtr = cbg_Material_Constructor_0();
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="Vector4F"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="Vector4F"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="Vector4F"/>のインスタンス</returns>
        public Vector4F GetVector4F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_Material_GetVector4F(selfPtr, key);
            return ret;
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="Vector4F"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="Vector4F"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="Vector4F"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetVector4F(string key, Vector4F value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_Material_SetVector4F(selfPtr, key, value);
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="Matrix44F"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="Matrix44F"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="Matrix44F"/>のインスタンス</returns>
        public Matrix44F GetMatrix44F(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_Material_GetMatrix44F(selfPtr, key);
            return ret;
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="Matrix44F"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="Matrix44F"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="Matrix44F"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetMatrix44F(string key, Matrix44F value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_Material_SetMatrix44F(selfPtr, key, value);
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="TextureBase"/>のインスタンスを取得する
        /// </summary>
        /// <param name="key">検索する<see cref="TextureBase"/>のインスタンスの名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を名前として持つ<see cref="TextureBase"/>のインスタンス</returns>
        public TextureBase GetTexture(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            var ret = cbg_Material_GetTexture(selfPtr, key);
            return TextureBase.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 指定した名前を持つ<see cref="TextureBase"/>の値を設定する
        /// </summary>
        /// <param name="key">検索する<see cref="TextureBase"/>のインスタンスの名前</param>
        /// <param name="value">設定する<see cref="TextureBase"/>のインスタンスの値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        public void SetTexture(string key, TextureBase value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "引数がnullです");
            cbg_Material_SetTexture(selfPtr, key, value != null ? value.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// 指定した種類のシェーダを取得する
        /// </summary>
        /// <param name="shaderStage">検索するシェーダのタイプ</param>
        /// <returns><paramref name="shaderStage"/>に一致するタイプのシェーダ</returns>
        public Shader GetShader(ShaderStageType shaderStage)
        {
            var ret = cbg_Material_GetShader(selfPtr, (int)shaderStage);
            return Shader.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// シェーダを設定する
        /// </summary>
        /// <param name="shader">設定するシェーダ</param>
        public void SetShader(Shader shader)
        {
            cbg_Material_SetShader(selfPtr, shader != null ? shader.selfPtr : IntPtr.Zero);
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
    internal sealed partial class Renderer
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
        private static extern void cbg_Renderer_DrawText(IntPtr selfPtr, IntPtr text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_DrawPolygon(IntPtr selfPtr, IntPtr polygon);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_Render(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_SetCamera(IntPtr selfPtr, IntPtr commandList);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Renderer_ResetCamera(IntPtr selfPtr);
        
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
        /// コマンドリストを描画します。
        /// </summary>
        public void Render()
        {
            cbg_Renderer_Render(selfPtr);
        }
        
        /// <summary>
        /// 使用するカメラを設定します。
        /// </summary>
        /// <param name="commandList">描画するカメラ</param>
        internal void SetCamera(RenderedCamera commandList)
        {
            cbg_Renderer_SetCamera(selfPtr, commandList != null ? commandList.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// 使用するカメラの設定をリセットします。
        /// </summary>
        public void ResetCamera()
        {
            cbg_Renderer_ResetCamera(selfPtr);
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
    public sealed partial class CommandList
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
        private static extern IntPtr cbg_CommandList_GetScreenTexture(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_CommandList_SetRenderTarget(IntPtr selfPtr, IntPtr target, RenderPassParameter renderPassParameter);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_CommandList_RenderToRenderTarget(IntPtr selfPtr, IntPtr material);
        
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
        
        public RenderTexture GetScreenTexture()
        {
            var ret = cbg_CommandList_GetScreenTexture(selfPtr);
            return RenderTexture.TryGetFromCache(ret);
        }
        
        public void SetRenderTarget(RenderTexture target, RenderPassParameter renderPassParameter)
        {
            cbg_CommandList_SetRenderTarget(selfPtr, target != null ? target.selfPtr : IntPtr.Zero, renderPassParameter);
        }
        
        public void RenderToRenderTarget(Material material)
        {
            cbg_CommandList_RenderToRenderTarget(selfPtr, material != null ? material.selfPtr : IntPtr.Zero);
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
    /// 描画されるオブジェクトの基本クラスを表します
    /// </summary>
    [Serializable]
    internal partial class Rendered : ISerializable, ICacheKeeper<Rendered>
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
        private static extern Matrix44F cbg_Rendered_GetTransform(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Rendered_SetTransform(IntPtr selfPtr, Matrix44F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Rendered_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Rendered(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Transform = "S_Transform";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Rendered"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Rendered(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            Transform = info.GetValue<Matrix44F>(S_Transform);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Transform, Transform);
            
            OnGetObjectData(info, context);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Rendered(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Rendered(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private virtual IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Rendered>> ICacheKeeper<Rendered>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Rendered>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Rendered>.Release(IntPtr native) => cbg_Rendered_Release(native);
        #endregion
        
        #endregion
        
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
        private static extern void cbg_RenderedSprite_SetSrc(IntPtr selfPtr, RectF value);
        
        
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
        public TextureBase Texture
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
                cbg_RenderedSprite_SetSrc(selfPtr, value);
            }
        }
        private RectF? _Src;
        
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_Texture = "S_Texture";
        private const string S_Src = "S_Src";
        private const string S_Material = "S_Material";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedSprite"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private RenderedSprite(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            Texture = info.GetValue<TextureBase>(S_Texture);
            Src = info.GetValue<RectF>(S_Src);
            Material = info.GetValue<Material>(S_Material);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Material, Material);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedSprite(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedSprite(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedSprite>> ICacheKeeper<RenderedSprite>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<RenderedSprite>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<RenderedSprite>.Release(IntPtr native) => cbg_RenderedSprite_Release(native);
        #endregion
        
        #endregion
        
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
        
        private static Dictionary<IntPtr, WeakReference<RenderedText>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedText>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedText_Create();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedText_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedText_GetText(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_SetText(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedText_GetFont(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_SetFont(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_RenderedText_GetWeight(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_SetWeight(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        private static extern Color cbg_RenderedText_GetColor(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_SetColor(IntPtr selfPtr, Color value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedText_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderedText(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
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
                var ret = cbg_RenderedText_GetMaterial(selfPtr);
                return Material.TryGetFromCache(ret);
            }
            set
            {
                _Material = value;
                cbg_RenderedText_SetMaterial(selfPtr, value != null ? value.selfPtr : IntPtr.Zero);
            }
        }
        private Material _Material;
        
        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        public string Text
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
        public Font Font
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
        public float Weight
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
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
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
        /// テキストを作成します。
        /// </summary>
        public static RenderedText Create()
        {
            var ret = cbg_RenderedText_Create();
            return RenderedText.TryGetFromCache(ret);
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_Material = "S_Material";
        private const string S_Text = "S_Text";
        private const string S_Font = "S_Font";
        private const string S_Weight = "S_Weight";
        private const string S_Color = "S_Color";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedText"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private RenderedText(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            Material = info.GetValue<Material>(S_Material);
            Text = info.GetString(S_Text);
            Font = info.GetValue<Font>(S_Font);
            Weight = info.GetSingle(S_Weight);
            Color = info.GetValue<Color>(S_Color);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            info.AddValue(S_Material, Material);
            info.AddValue(S_Text, Text);
            info.AddValue(S_Font, Font);
            info.AddValue(S_Weight, Weight);
            info.AddValue(S_Color, Color);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedText(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedText(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedText>> ICacheKeeper<RenderedText>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<RenderedText>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<RenderedText>.Release(IntPtr native) => cbg_RenderedText_Release(native);
        #endregion
        
        #endregion
        
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
        
        private static Dictionary<IntPtr, WeakReference<RenderedPolygon>> cacheRepo = new Dictionary<IntPtr, WeakReference<RenderedPolygon>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedPolygon_Create();
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_SetVertexesByVector2F(IntPtr selfPtr, IntPtr vertexes);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedPolygon_GetVertexes(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_SetVertexes(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedPolygon_GetTexture(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_SetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern RectF cbg_RenderedPolygon_GetSrc(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_SetSrc(IntPtr selfPtr, RectF value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedPolygon_GetMaterial(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_SetMaterial(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedPolygon_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderedPolygon(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// 頂点情報を取得または設定します。
        /// </summary>
        public VertexArray Vertexes
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
        public TextureBase Texture
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
        public RectF Src
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
        public Material Material
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
        public static RenderedPolygon Create()
        {
            var ret = cbg_RenderedPolygon_Create();
            return RenderedPolygon.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 頂点情報
        /// </summary>
        public void SetVertexesByVector2F(Vector2FArray vertexes)
        {
            cbg_RenderedPolygon_SetVertexesByVector2F(selfPtr, vertexes != null ? vertexes.selfPtr : IntPtr.Zero);
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_Vertexes = "S_Vertexes";
        private const string S_Texture = "S_Texture";
        private const string S_Src = "S_Src";
        private const string S_Material = "S_Material";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedPolygon"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private RenderedPolygon(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            Vertexes = info.GetValue<VertexArray>(S_Vertexes);
            Texture = info.GetValue<TextureBase>(S_Texture);
            Src = info.GetValue<RectF>(S_Src);
            Material = info.GetValue<Material>(S_Material);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            info.AddValue(S_Vertexes, Vertexes);
            info.AddValue(S_Texture, Texture);
            info.AddValue(S_Src, Src);
            info.AddValue(S_Material, Material);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedPolygon(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedPolygon(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedPolygon>> ICacheKeeper<RenderedPolygon>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<RenderedPolygon>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<RenderedPolygon>.Release(IntPtr native) => cbg_RenderedPolygon_Release(native);
        #endregion
        
        #endregion
        
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
    /// カメラのクラス
    /// </summary>
    [Serializable]
    internal sealed partial class RenderedCamera : Rendered, ISerializable, ICacheKeeper<RenderedCamera>
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
        private static extern IntPtr cbg_RenderedCamera_Create();
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_RenderedCamera_GetCenterOffset(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedCamera_SetCenterOffset(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RenderedCamera_GetTargetTexture(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedCamera_SetTargetTexture(IntPtr selfPtr, IntPtr value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RenderedCamera_Release(IntPtr selfPtr);
        
        #endregion
        
        internal RenderedCamera(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// CenterOffsetを取得または設定します。
        /// </summary>
        public Vector2F CenterOffset
        {
            get
            {
                if (_CenterOffset != null)
                {
                    return _CenterOffset.Value;
                }
                var ret = cbg_RenderedCamera_GetCenterOffset(selfPtr);
                return ret;
            }
            set
            {
                _CenterOffset = value;
                cbg_RenderedCamera_SetCenterOffset(selfPtr, value);
            }
        }
        private Vector2F? _CenterOffset;
        
        /// <summary>
        /// TargetTextureを取得または設定します。
        /// </summary>
        public RenderTexture TargetTexture
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
        /// RenderedCameraを作成します。
        /// </summary>
        public static RenderedCamera Create()
        {
            var ret = cbg_RenderedCamera_Create();
            return RenderedCamera.TryGetFromCache(ret);
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_CenterOffset = "S_CenterOffset";
        private const string S_TargetTexture = "S_TargetTexture";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="RenderedCamera"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private RenderedCamera(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            CenterOffset = info.GetValue<Vector2F>(S_CenterOffset);
            TargetTexture = info.GetValue<RenderTexture>(S_TargetTexture);
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            info.AddValue(S_CenterOffset, CenterOffset);
            info.AddValue(S_TargetTexture, TargetTexture);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedCamera(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="RenderedCamera(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        protected private override IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<RenderedCamera>> ICacheKeeper<RenderedCamera>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<RenderedCamera>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<RenderedCamera>.Release(IntPtr native) => cbg_RenderedCamera_Release(native);
        #endregion
        
        #endregion
        
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
        
        private static Dictionary<IntPtr, WeakReference<BuiltinShader>> cacheRepo = new Dictionary<IntPtr, WeakReference<BuiltinShader>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_BuiltinShader_Create(IntPtr selfPtr, int type);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_BuiltinShader_Release(IntPtr selfPtr);
        
        #endregion
        
        internal BuiltinShader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
    /// シェーダ
    /// </summary>
    [Serializable]
    public sealed partial class Shader : ISerializable, ICacheKeeper<Shader>
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
        private static extern IntPtr cbg_Shader_Create([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string code, int shaderStage);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Shader_GetStageType(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Shader_GetCode(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Shader_GetName(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Shader_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Shader(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        public ShaderStageType StageType
        {
            get
            {
                var ret = cbg_Shader_GetStageType(selfPtr);
                return (ShaderStageType)ret;
            }
        }
        
        /// <summary>
        /// インスタンス生成に使用したコードを取得します
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
        /// 名前を取得します
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
        /// コードをコンパイルしてシェーダを生成する
        /// </summary>
        /// <param name="name">シェーダの名前</param>
        /// <param name="code">コンパイルするコード</param>
        /// <param name="shaderStage"></param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="code"/>のいずれかがnull</exception>
        /// <returns>コンパイルの結果生成されたシェーダ</returns>
        public static Shader Create(string name, string code, ShaderStageType shaderStage)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "引数がnullです");
            if (code == null) throw new ArgumentNullException(nameof(code), "引数がnullです");
            var ret = cbg_Shader_Create(name, code, (int)shaderStage);
            return Shader.TryGetFromCache(ret);
        }
        
        #region ISerialiable
        #region SerializeName
        private const string S_StageType = "S_StageType";
        private const string S_Code = "S_Code";
        private const string S_Name = "S_Name";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Shader"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Shader(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandling(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_StageType, StageType);
            info.AddValue(S_Code, Code);
            info.AddValue(S_Name, Name);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="Shader(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="StageType"><see cref="Shader.StageType"/></param>
        /// <param name="Code"><see cref="Shader.Code"/></param>
        /// <param name="Name"><see cref="Shader.Name"/></param>
        private void Shader_Unsetter_Deserialize(SerializationInfo info, out ShaderStageType StageType, out string Code, out string Name)
        {
            StageType = info.GetValue<ShaderStageType>(S_StageType);
            Code = info.GetString(S_Code);
            Name = info.GetString(S_Name);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Shader>> ICacheKeeper<Shader>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Shader>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Shader>.Release(IntPtr native) => cbg_Shader_Release(native);
        #endregion
        
        #endregion
        
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
    [Serializable]
    public sealed partial class Font : ISerializable, ICacheKeeper<Font>, IDeserializationCallback
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
        private static extern IntPtr cbg_Font_LoadDynamicFont([MarshalAs(UnmanagedType.LPWStr)] string path, int size);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_LoadStaticFont([MarshalAs(UnmanagedType.LPWStr)] string path);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_GenerateFontFile([MarshalAs(UnmanagedType.LPWStr)] string dynamicFontPath, [MarshalAs(UnmanagedType.LPWStr)] string staticFontPath, int size, [MarshalAs(UnmanagedType.LPWStr)] string characters);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetGlyph(IntPtr selfPtr, int character);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetFontTexture(IntPtr selfPtr, int index);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetKerning(IntPtr selfPtr, int c1, int c2);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Font_CalcTextureSize(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text, int direction, [MarshalAs(UnmanagedType.Bool)] bool isEnableKerning);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_CreateImageFont(IntPtr baseFont);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Font_AddImageGlyph(IntPtr selfPtr, int character, IntPtr texture);
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetImageGlyph(IntPtr selfPtr, int character);
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetAscent(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetDescent(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern int cbg_Font_GetLineGap(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Font_GetIsStaticFont(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Font_GetPath(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Font_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Font(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
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
        /// StaticFontか否か
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
        /// 動的にフォントを生成します
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
        /// 静的にフォントを生成します
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
        /// a2fフォントを生成します
        /// </summary>
        /// <param name="dynamicFontPath">読み込むtruetypeフォントのパス</param>
        /// <param name="staticFontPath">生成するa2fフォントのパス</param>
        /// <param name="size">フォントのサイズ</param>
        /// <param name="characters">フォント化させる文字列</param>
        /// <exception cref="ArgumentNullException"><paramref name="dynamicFontPath"/>, <paramref name="staticFontPath"/>のいずれかがnull</exception>
        /// <returns>生成できたか否か</returns>
        public static bool GenerateFontFile(string dynamicFontPath, string staticFontPath, int size, string characters)
        {
            if (dynamicFontPath == null) throw new ArgumentNullException(nameof(dynamicFontPath), "引数がnullです");
            if (staticFontPath == null) throw new ArgumentNullException(nameof(staticFontPath), "引数がnullです");
            var ret = cbg_Font_GenerateFontFile(dynamicFontPath, staticFontPath, size, characters);
            return ret;
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
        
        /// <summary>
        /// テクスチャ追加対応フォントを生成します
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
        /// テクスチャ文字を追加する
        /// </summary>
        /// <param name="character">文字</param>
        /// <param name="texture">テクスチャ</param>
        internal void AddImageGlyph(int character, Texture2D texture)
        {
            cbg_Font_AddImageGlyph(selfPtr, character, texture != null ? texture.selfPtr : IntPtr.Zero);
        }
        
        /// <summary>
        /// テクスチャ文字を取得する
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
        private const string S_Size = "S_Size";
        private const string S_IsStaticFont = "S_IsStaticFont";
        #endregion
        
        private SerializationInfo seInfo;
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Font"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Font(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_Size, Size);
            info.AddValue(S_IsStaticFont, IsStaticFont);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Font(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Size"><see cref="Font.Size"/></param>
        /// <param name="IsStaticFont"><see cref="Font.IsStaticFont"/></param>
        private void Font_Unsetter_Deserialize(SerializationInfo info, out int Size, out bool IsStaticFont)
        {
            Size = info.GetInt32(S_Size);
            IsStaticFont = info.GetBoolean(S_IsStaticFont);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Font>> ICacheKeeper<Font>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Font>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Font>.Release(IntPtr native) => cbg_Font_Release(native);
        #endregion
        
        #endregion
        
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            
            var ptr = Call_GetPtr(seInfo);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
            
            OnDeserialize_Method(sender);
            
            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization(object)"/>中で実行される
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        partial void OnDeserialize_Method(object sender);
        
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
    
    public sealed partial class Tool
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
        private static extern void cbg_Tool_NewFrame(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Render(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Dummy(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_Text(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextUnformatted(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextWrapped(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_TextColored(IntPtr selfPtr, Vector4F color, [MarshalAs(UnmanagedType.LPWStr)] string text);
        
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
        private static extern bool cbg_Tool_Button(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);
        
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
        private static extern bool cbg_Tool_InvisibleButton(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size);
        
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
        private static extern bool cbg_Tool_VSliderInt(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref int value, int valueMin, int valueMax);
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Tool_VSliderFloat(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [In, Out] ref float value, float valueMin, float valueMax);
        
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
        private static extern bool cbg_Tool_BeginChild(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string label, Vector2F size, [MarshalAs(UnmanagedType.Bool)] bool border, int flags);
        
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
        private static extern void cbg_Tool_SetWindowSize(IntPtr selfPtr, Vector2F size);
        
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
        private static extern void cbg_Tool_SetNextWindowContentSize(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextWindowSize(IntPtr selfPtr, Vector2F size);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Tool_SetNextWindowPos(IntPtr selfPtr, Vector2F pos);
        
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
        /// 
        /// </summary>
        public void Dummy(Vector2F size)
        {
            cbg_Tool_Dummy(selfPtr, size);
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
        public void TextColored(Vector4F color, string text)
        {
            cbg_Tool_TextColored(selfPtr, color, text);
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
        public bool Button(string label, Vector2F size)
        {
            var ret = cbg_Tool_Button(selfPtr, label, size);
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
        public bool InvisibleButton(string label, Vector2F size)
        {
            var ret = cbg_Tool_InvisibleButton(selfPtr, label, size);
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
        public bool VSliderInt(string label, Vector2F size, ref int value, int valueMin, int valueMax)
        {
            var ret = cbg_Tool_VSliderInt(selfPtr, label, size, ref value, valueMin, valueMax);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool VSliderFloat(string label, Vector2F size, ref float value, float valueMin, float valueMax)
        {
            var ret = cbg_Tool_VSliderFloat(selfPtr, label, size, ref value, valueMin, valueMax);
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
        public bool BeginChild(string label, Vector2F size, bool border, ToolWindow flags)
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
        public void SetNextWindowSize(Vector2F size)
        {
            cbg_Tool_SetNextWindowSize(selfPtr, size);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SetNextWindowPos(Vector2F pos)
        {
            cbg_Tool_SetNextWindowPos(selfPtr, pos);
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
    [Serializable]
    public sealed partial class StreamFile : ISerializable, ICacheKeeper<StreamFile>, IDeserializationCallback
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
        private static extern IntPtr cbg_StreamFile_GetPath(IntPtr selfPtr);
        
        
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
        
        #region ISerialiable
        #region SerializeName
        private const string S_CurrentPosition = "S_CurrentPosition";
        #endregion
        
        private SerializationInfo seInfo;
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="StreamFile"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private StreamFile(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            info.AddValue(S_CurrentPosition, CurrentPosition);
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="StreamFile(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="OnDeserialization(object)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="CurrentPosition"><see cref="StreamFile.CurrentPosition"/></param>
        private void StreamFile_Unsetter_Deserialize(SerializationInfo info, out int CurrentPosition)
        {
            CurrentPosition = info.GetInt32(S_CurrentPosition);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<StreamFile>> ICacheKeeper<StreamFile>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<StreamFile>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<StreamFile>.Release(IntPtr native) => cbg_StreamFile_Release(native);
        #endregion
        
        #endregion
        
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            
            var ptr = Call_GetPtr(seInfo);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
            
            OnDeserialize_Method(sender);
            
            seInfo = null;
        }
        /// <summary>
        /// <see cref="IDeserializationCallback.OnDeserialization(object)"/>中で実行される
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        partial void OnDeserialize_Method(object sender);
        
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
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="StaticFile"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private StaticFile(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
            
            OnDeserialize_Constructor(info, context);
        }
        
        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            
            
            OnGetObjectData(info, context);
        }
        
        /// <summary>
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="StaticFile(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="StaticFile(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<StaticFile>> ICacheKeeper<StaticFile>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<StaticFile>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<StaticFile>.Release(IntPtr native) => cbg_StaticFile_Release(native);
        #endregion
        
        #endregion
        
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
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>追加処理がうまくいったらtrue，それ以外でfalse</returns>
        public bool AddRootDirectory(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_File_AddRootDirectory(selfPtr, path);
            return ret;
        }
        
        /// <summary>
        /// ファイルパッケージをパスワード有りで読み込む
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
        /// ファイルパッケージをパスワード無しで読み込む
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
        /// 指定したディレクトリのファイルをパックする
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
        /// 指定したディレクトリのファイルをパスワード付きでパックする
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
        
        private static ConcurrentDictionary<IntPtr, WeakReference<Sound>> cacheRepo = new ConcurrentDictionary<IntPtr, WeakReference<Sound>>();
        
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
        private static extern IntPtr cbg_Sound_GetPath(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Sound_GetIsDecompressed(IntPtr selfPtr);
        
        
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
        /// 音源を解凍するかどうかを取得する
        /// </summary>
        internal bool IsDecompressed
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
        /// <param name="isDecompressed">音を再生する前にデータを全て解凍するか?</param>
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
        private const string S_LoopStartingPoint = "S_LoopStartingPoint";
        private const string S_LoopEndPoint = "S_LoopEndPoint";
        private const string S_IsLoopingMode = "S_IsLoopingMode";
        private const string S_Path = "S_Path";
        private const string S_IsDecompressed = "S_IsDecompressed";
        #endregion
        
        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Sound"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private Sound(SerializationInfo info, StreamingContext context)
        {
            var ptr = Call_GetPtr(info);
            
            if (ptr == IntPtr.Zero) throw new SerializationException("インスタンス生成に失敗しました");
            CacheHelper.CacheHandlingConcurrent(this, ptr);
            
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
        /// <see cref="ISerializable.GetObjectData(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        partial void OnGetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>内で実行
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        partial void OnDeserialize_Constructor(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>内で呼び出される
        /// デシリアライズ時にselfPtrを取得する操作をここに必ず書くこと
        /// </summary>
        /// <param name="ptr"/>selfPtrとなる値 初期値である<see cref="IntPtr.Zero"/>のままだと<see cref="SerializationException"/>がスローされる
        /// <param name="info"/>シリアライズされたデータを格納するオブジェクト</param>
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info);
        /// <summary>
        /// 呼び出し禁止
        /// </summary>
        private IntPtr Call_GetPtr(SerializationInfo info)
        {
            var ptr = IntPtr.Zero;
            Deserialize_GetPtr(ref ptr, info);
            return ptr;
        }
        
        /// <summary>
        /// <see cref="Sound(SerializationInfo, StreamingContext)"/>でデシリアライズされなかったオブジェクトを呼び出す
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="Path"><see cref="Sound.Path"/></param>
        /// <param name="IsDecompressed"><see cref="Sound.IsDecompressed"/></param>
        private void Sound_Unsetter_Deserialize(SerializationInfo info, out string Path, out bool IsDecompressed)
        {
            Path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
            IsDecompressed = info.GetBoolean(S_IsDecompressed);
        }
        
        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Sound>> ICacheKeeper<Sound>.CacheRepo => cacheRepo;
        IntPtr ICacheKeeper<Sound>.Self { get => selfPtr; set => selfPtr = value; }
        void ICacheKeeper<Sound>.Release(IntPtr native) => cbg_Sound_Release(native);
        #endregion
        
        #endregion
        
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
        /// <param name="volume">音量(0.0〜1.0)</param>
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
    public sealed partial class Log
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
        /// <see cref="LogLevel.Warning"/>でログを出力します。
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
        
        private static Dictionary<IntPtr, WeakReference<Window>> cacheRepo = new Dictionary<IntPtr, WeakReference<Window>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Window_GetInstance();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Window_GetTitle(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Window_SetTitle(IntPtr selfPtr, [MarshalAs(UnmanagedType.LPWStr)] string value);
        
        
        [DllImport("Altseed_Core")]
        private static extern Vector2I cbg_Window_GetSize(IntPtr selfPtr);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Window_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Window(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// ウィンドウに表示するタイトルを取得または設定します
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public string Title
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
        public Vector2I Size
        {
            get
            {
                var ret = cbg_Window_GetSize(selfPtr);
                return ret;
            }
        }
        
        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns>使用するインスタンス</returns>
        internal static Window GetInstance()
        {
            var ret = cbg_Window_GetInstance();
            return Window.TryGetFromCache(ret);
        }
        
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
    public partial class Collider
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<Collider>> cacheRepo = new Dictionary<IntPtr, WeakReference<Collider>>();
        
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
        
        internal IntPtr selfPtr = IntPtr.Zero;
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_Collider_Constructor_0();
        
        [DllImport("Altseed_Core")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool cbg_Collider_GetIsCollidedWith(IntPtr selfPtr, IntPtr collider);
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_Collider_GetPosition(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Collider_SetPosition(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_Collider_GetRotation(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_Collider_SetRotation(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_Collider_Release(IntPtr selfPtr);
        
        #endregion
        
        internal Collider(MemoryHandle handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        /// <summary>
        /// コライダの位置情報を取得または設定します。
        /// </summary>
        public Vector2F Position
        {
            get
            {
                if (_Position != null)
                {
                    return _Position.Value;
                }
                var ret = cbg_Collider_GetPosition(selfPtr);
                return ret;
            }
            set
            {
                _Position = value;
                cbg_Collider_SetPosition(selfPtr, value);
            }
        }
        private Vector2F? _Position;
        
        /// <summary>
        /// コライダの回転情報を取得または設定します。
        /// </summary>
        public float Rotation
        {
            get
            {
                if (_Rotation != null)
                {
                    return _Rotation.Value;
                }
                var ret = cbg_Collider_GetRotation(selfPtr);
                return ret;
            }
            set
            {
                _Rotation = value;
                cbg_Collider_SetRotation(selfPtr, value);
            }
        }
        private float? _Rotation;
        
        internal Collider()
        {
            selfPtr = cbg_Collider_Constructor_0();
        }
        
        /// <summary>
        /// 指定したコライダとの衝突判定を行います。
        /// </summary>
        public bool GetIsCollidedWith(Collider collider)
        {
            var ret = cbg_Collider_GetIsCollidedWith(selfPtr, collider != null ? collider.selfPtr : IntPtr.Zero);
            return ret;
        }
        
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
    public partial class CircleCollider : Collider
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<CircleCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<CircleCollider>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_CircleCollider_Constructor_0();
        
        [DllImport("Altseed_Core")]
        private static extern float cbg_CircleCollider_GetRadius(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_CircleCollider_SetRadius(IntPtr selfPtr, float value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_CircleCollider_Release(IntPtr selfPtr);
        
        #endregion
        
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
        
        public CircleCollider()
        {
            selfPtr = cbg_CircleCollider_Constructor_0();
        }
        
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
    public partial class RectangleCollider : Collider
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<RectangleCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<RectangleCollider>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_RectangleCollider_Constructor_0();
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_RectangleCollider_GetSize(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RectangleCollider_SetSize(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern Vector2F cbg_RectangleCollider_GetCenterPosition(IntPtr selfPtr);
        [DllImport("Altseed_Core")]
        private static extern void cbg_RectangleCollider_SetCenterPosition(IntPtr selfPtr, Vector2F value);
        
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_RectangleCollider_Release(IntPtr selfPtr);
        
        #endregion
        
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
        
        public RectangleCollider()
        {
            selfPtr = cbg_RectangleCollider_Constructor_0();
        }
        
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
    public partial class PolygonCollider : Collider
    {
        #region unmanaged
        
        private static Dictionary<IntPtr, WeakReference<PolygonCollider>> cacheRepo = new Dictionary<IntPtr, WeakReference<PolygonCollider>>();
        
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
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_PolygonCollider_Constructor_0();
        
        [DllImport("Altseed_Core")]
        private static extern IntPtr cbg_PolygonCollider_GetVertexes(IntPtr selfPtr);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_PolygonCollider_SetVertexes(IntPtr selfPtr, IntPtr vertexes);
        
        [DllImport("Altseed_Core")]
        private static extern void cbg_PolygonCollider_Release(IntPtr selfPtr);
        
        #endregion
        
        internal PolygonCollider(MemoryHandle handle) : base(handle)
        {
            selfPtr = handle.selfPtr;
        }
        
        public PolygonCollider()
        {
            selfPtr = cbg_PolygonCollider_Constructor_0();
        }
        
        /// <summary>
        /// 多角形コライダの頂点の座標を取得します。
        /// </summary>
        internal Vector2FArray GetVertexes()
        {
            var ret = cbg_PolygonCollider_GetVertexes(selfPtr);
            return Vector2FArray.TryGetFromCache(ret);
        }
        
        /// <summary>
        /// 多角形コライダの頂点の座標を設定します。
        /// </summary>
        internal void SetVertexes(Vector2FArray vertexes)
        {
            cbg_PolygonCollider_SetVertexes(selfPtr, vertexes != null ? vertexes.selfPtr : IntPtr.Zero);
        }
        
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
