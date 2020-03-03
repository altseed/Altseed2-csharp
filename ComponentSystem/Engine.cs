using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Altseed.ComponentSystem
{
    public sealed class Engine
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
        /// エンジンを初期化する
        /// </summary>
        /// <param name="title">ウィンドウ左上に表示される文字列</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="config">設定</param>
        /// <returns>初期化に成功したらtrue、それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            if (Altseed.EngineCore.Initialize(title, width, height, config ?? new Configuration()))
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
        /// イベントを実行する
        /// </summary>
        /// <returns>イベントの実行が出来たらtrue、それ以外でfalse</returns>
        public static bool DoEvents()
        {
            return Altseed.EngineCore.DoEvents();
        }

        public static void Update()
        {
            CurrentScene.Update();
        }

        /// <summary>
        /// エンジンの終了処理を行う
        /// </summary>
        public static void Terminate()
        {
            Altseed.EngineCore.Terminate();
        }

        #region ChangeScene

        /// <summary>
        /// シーンを即変更する
        /// </summary>
        /// <param name="nextScene">変更先のシーン</param>
        /// <exception cref="ArgumentNullException"><paramref name="nextScene"/>がnull</exception>
        /// <exception cref="InvalidOperationException">既に他のシーンの変更処理を実行中</exception>
        public static void ChangeScene(Scene nextScene)
        {
            StartSceneChange(nextScene);
            OnFadeOutFinished();
            OnFadeInFinished();
        }

        /// <summary>
        /// シーンを変更する
        /// </summary>
        /// <param name="nextScene">変更先のシーン</param>
        /// <exception cref="ArgumentNullException"><paramref name="nextScene"/>がnull</exception>
        /// <exception cref="InvalidOperationException">既に他のシーンの変更処理を実行中</exception>
        public static void ChangeSceneWithTransition(Scene nextScene)
        {
            StartSceneChange(nextScene);
            // 
            // 未実装
            // ToDo:描画処理のトリガー引き
            //
            throw new NotImplementedException("このメソッドは未だ実装中です");
        }

        /*
         * ChangeSceneWithTransition
         * →OnFadeOutFinished
         * →OnFadeInFinished
         * の順で呼び出されるのを想定
         * 
         * SceneのOn〇〇メソッドの呼び出しは初代の物を参考に
         * 
         * シーン遷移処理(描画)は主にChangeSceneWithTransition - OnFadeOutfinishedの間でやる想定
         */

        //ここでNextSceneを設定
        /// <summary>
        /// シーンチェンジを開始する
        /// </summary>
        /// <param name="nextScene">変更先のシーン</param>
        /// <exception cref="ArgumentNullException"><paramref name="nextScene"/>がnull</exception>
        /// <exception cref="InvalidOperationException">既に他のシーンの変更処理を実行中</exception>
        internal static void StartSceneChange(Scene nextScene)
        {
            if (nextScene == null) throw new ArgumentNullException("次のシーンがnullです", nameof(nextScene));
            if (!(CurrentScene.Status == SceneStatus.Updated || CurrentScene.Status == SceneStatus.WaitDisposed || CurrentScene.Status == SceneStatus.Disposed))
                throw new InvalidOperationException("シーン変更処理中です");

            CurrentScene.RaiseOnTransitionBegin();
            nextScene.RaiseOnRegistered();
            NextScene = nextScene;
        }

        //ここで {Alject.IsInherited = true} のオブジェクトの引継ぎが発生
        /// <summary>
        /// フェードアウト終了時に実行
        /// </summary>
        /// <exception cref="InvalidOperationException"><paramref name="NextScene"/>がnull</exception>
        internal static void OnFadeOutFinished()
        {
            if (NextScene == null) throw new InvalidOperationException("次のシーンがnullです");
            CurrentScene.RaiseOnStopUpdating();
            Scene.InheritObjects(CurrentScene, NextScene);
            NextScene.RaiseOnStartUpdating();
        }

        //ここでCurrentSceneの変更
        /// <summary>
        /// フェードイン終了時に実行
        /// </summary>
        /// <param name="NextScene">変更先のシーン</param>
        /// <exception cref="InvalidOperationException"><paramref name="NextScene"/>がnull</exception>
        internal static void OnFadeInFinished()
        {
            if (NextScene == null) throw new InvalidOperationException("次のシーンがnullです");
            CurrentScene.RaiseOnUnRegistered();
            NextScene.RaiseOnTransitionFinished();
            CurrentScene = NextScene;
            NextScene = null;
        }
        #endregion

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
