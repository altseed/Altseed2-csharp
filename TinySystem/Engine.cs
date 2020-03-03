using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{

    /// <summary>
    /// Altseed2 のエンジンを表します。
    /// </summary>
    public static class Engine
    {

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
                //CurrentScene = new Scene()
                //{
                //    Status = SceneStatus.Updated
                //};
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
        public static void Update()
        {
            //CurrentScene.Update();
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
        public static Renderer Renderer => Altseed.EngineCore.Renderer;

        /// <summary>
        /// 音を管理するクラス取得します。
        /// </summary>
        public static SoundMixer Sound => Altseed.EngineCore.Sound;

        /// <summary>
        /// リソースを管理するクラス取得します。
        /// </summary>
        public static Resources Resources => Altseed.EngineCore.Resources;

        #endregion

    }
}
