using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed.TinySystem
{

    /// <summary>
    /// Altseed2 のエンジンを表します。
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// 現在処理している<see cref="Scene"/>取得します。
        /// </summary>
        public static Scene CurrentScene { get; private set; }

        /// <summary>
        /// 次に控えているシーン取得します。
        /// </summary>
        internal static Scene NextScene { get; private set; }


        /// <summary>
        /// エンジンを初期化します。
        /// </summary>
        /// <param name="title">ウィンドウタイトル</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">設定</param>
        /// <returns>初期化に成功したらtrue、それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            if (EngineCore.Initialize(title, width, height, config ?? new Configuration()))
            {
                CurrentScene = new Scene()
                {
                    Status = SceneStatus.Updated
                };
                return true;
            }
            return false;
        }

        /// <summary>
        /// システムイベントを処理します。
        /// </summary>
        public static bool DoEvents()
        {
            return EngineCore.DoEvents();
        }

        /// <summary>
        /// エンジンを更新します。
        /// </summary>
        public static bool Update()
        {
            if (!Graphics.BeginFrame()) return false;

            CurrentScene.Update();

            var cmdList = Graphics.CommandList;
            cmdList.SetRenderTargetWithScreen();

            Renderer.Render(cmdList);
            if (!Graphics.EndFrame()) return false;
            return true;
        }

        /// <summary>
        /// エンジンを終了します。
        /// </summary>
        public static void Terminate()
        {
            EngineCore.Terminate();
        }

        #region Modules

        /// <summary>
        /// ファイルを管理するクラス取得します。
        /// </summary>
        public static File File => Altseed.EngineCore.File;

        /// <summary>
        /// キーボードを管理するクラス取得します。
        /// </summary>
        public static Keyboard Keyboard => Altseed.EngineCore.Keyboard;

        /// <summary>
        /// マウスを管理するクラス取得します。
        /// </summary>
        public static Mouse Mouse => Altseed.EngineCore.Mouse;

        ///// <summary>
        ///// ジョイスティックを管理するクラス取得します。
        ///// </summary>
        public static Joystick Joystick => Altseed.EngineCore.Joystick;

        /// <summary>
        /// グラフィックのクラス取得します。
        /// </summary>
        public static Graphics Graphics => Altseed.EngineCore.Graphics;

        /// <summary>
        /// ログを管理するクラス取得します。
        /// </summary>
        public static Log Log => Altseed.EngineCore.Log;

        /// <summary>
        /// レンダラのクラス取得します。
        /// </summary>
        internal static Renderer Renderer => Altseed.EngineCore.Renderer;

        /// <summary>
        /// 音を管理するクラス取得します。
        /// </summary>
        public static SoundMixer Sound => Altseed.EngineCore.Sound;

        /// <summary>
        /// リソースを管理するクラス取得します。
        /// </summary>
        internal static Resources Resources => Altseed.EngineCore.Resources;

        #endregion

        /// <summary>
        /// ウインドウのタイトルを取得または設定します。
        /// </summary>
        public static string WindowTitle
        {
            get => EngineCore.Window.Title;
            set { EngineCore.Window.Title = value; }
        }

        /// <summary>
        /// フレームレートの制御方法を取得または設定します。
        /// </summary>
        public static FramerateMode FramerateMode
        {
            get => EngineCore.Core.FramerateMode;
            set { EngineCore.Core.FramerateMode = value; }
        }

        /// <summary>
        /// 目標フレームレートを取得または設定します。
        /// </summary>
        public static float TargetFPS
        {
            get => EngineCore.Core.TargetFPS;
            set { EngineCore.Core.TargetFPS = value; }
        }

        /// <summary>
        /// 現在のFPSを取得します。
        /// </summary>
        public static float CurrentFPS => EngineCore.Core.CurrentFPS;

        /// <summary>
        /// 前のフレームからの経過時間(秒)を取得します。
        /// </summary>
        public static float DeltaSecond => EngineCore.Core.DeltaSecond;

    }
}
