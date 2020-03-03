using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// Altseed2の中枢を担うクラス
    /// </summary>
    public static class EngineCore
    {
        /// <summary>
        /// エンジンを初期化する
        /// </summary>
        /// <param name="title">ウィンドウ左上に表示される文字列</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">設定</param>
        /// <returns>初期化に成功したらtrue、それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            if (Core.Initialize(title, width, height, config ?? new Configuration()))
            {
                Keyboard = Keyboard.GetInstance();
                Mouse = Mouse.GetInstance();
                Joystick = Joystick.GetInstance();
                File = File.GetInstance();
                Graphics = Graphics.GetInstance();
                Renderer = Renderer.GetInstance();
                Sound = SoundMixer.GetInstance();
                Log = Log.GetInstance();
                Resources = Resources.GetInstance();

                return true;
            }
            return false;
        }

        /// <summary>
        /// イベントを実行する
        /// </summary>
        /// <returns>イベントの実行が出来たらtrue、それ以外でfalse</returns>
        public static bool DoEvents()
        {
            Graphics.DoEvents();
            return Core.GetInstance().DoEvent();
        }

        /// <summary>
        /// エンジンの終了処理を行う
        /// </summary>
        public static void Terminate()
        {
            Core.Terminate();
        }

        /// <summary>
        /// ファイルを管理するクラス取得します。
        /// </summary>
        public static File File { get; private set; }

        /// <summary>
        /// キーボードを管理するクラス取得します。
        /// </summary>
        public static Keyboard Keyboard { get; private set; }

        /// <summary>
        /// マウスを管理するクラス取得します。
        /// </summary>
        public static Mouse Mouse { get; private set; }

        ///// <summary>
        ///// ジョイスティックを管理するクラス取得します。
        ///// </summary>
        public static Joystick Joystick { get; private set; }

        /// <summary>
        /// グラフィックのクラス取得します。
        /// </summary>
        public static Graphics Graphics { get; private set; }

        /// <summary>
        /// ログを管理するクラス取得します。
        /// </summary>
        public static Log Log { get; private set; }

        /// <summary>
        /// レンダラのクラス取得します。
        /// </summary>
        public static Renderer Renderer { get; private set; }

        /// <summary>
        /// 音を管理するクラス取得します。
        /// </summary>
        public static SoundMixer Sound { get; private set; }

        /// <summary>
        /// リソースを管理するクラス取得します。
        /// </summary>
        public static Resources Resources { get; private set; }
    }
}
