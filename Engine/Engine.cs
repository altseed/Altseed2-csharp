using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// Altseed2の中枢を担うクラス
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// 現在処理している<see cref="Scene"/>を取得する
        /// </summary>
        public static Scene CurrentScene { get => _currentScene; private set => _currentScene = value ?? throw new ArgumentNullException("設定するシーンがnullです", nameof(value)); }
        private static Scene _currentScene;
        /// <summary>
        /// 次に控えているシーンを取得する
        /// </summary>
        internal static Scene NextScene { get; private set; }

        /// <summary>
        /// エンジンを初期化する
        /// </summary>
        /// <param name="title">ウィンドウ左上に表示される文字列</param>
        /// <param name="width">ウィンドウの横幅</param>
        /// <param name="height">ウィンドウの縦幅</param>
        /// <param name="option">オプションのインスタンス</param>
        /// <returns>初期化に成功したらtrue，それ以外でfalse</returns>
        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            if (Core.Initialize(title, width, height, config ?? new Configuration()))
            {
                Keyboard = Keyboard.GetInstance();
                Mouse = Mouse.GetInstance();
                File = File.GetInstance();
                Graphics = Graphics.GetInstance();
                Renderer = Renderer.GetInstance();
                Sound = SoundMixer.GetInstance();
                Log = Log.GetInstance();
                Resources = Resources.GetInstance();
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
        /// <returns>イベントの実行が出来たらtrue，それ以外でfalse</returns>
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
        /// 更新処理を実行する
        /// </summary>
        public static void Update()
        {
            CurrentScene.Update();
        }

        #region ChangeScene

        /// <summary>
        /// シーンを即変更する
        /// </summary>
        /// <param name="nextScene">変更先のシーン</param>
        /// <exception cref="ArgumentNullException"><paramref name="nextScene"/>がnull</exception>
        /// <exception cref="InvalidOleVariantTypeException">既に他のシーンの変更処理を実行中</exception>
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
        /// <exception cref="InvalidOleVariantTypeException">既に他のシーンの変更処理を実行中</exception>
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
        /// <exception cref="InvalidOleVariantTypeException">既に他のシーンの変更処理を実行中</exception>
        internal static void StartSceneChange(Scene nextScene)
        {
            if (nextScene == null) throw new ArgumentNullException("次のシーンがnullです", nameof(nextScene));
            if (!(CurrentScene.Status == SceneStatus.Updated || CurrentScene.Status == SceneStatus.WaitDisposed || CurrentScene.Status == SceneStatus.Disposed)) throw new InvalidOleVariantTypeException("シーン変更処理中です");
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

        /// <summary>
        /// ファイルを管理するクラスを取得する
        /// </summary>
        public static File File { get; private set; }

        /// <summary>
        /// キーボードを管理するクラスを取得する
        /// </summary>
        public static Keyboard Keyboard { get; private set; }

        /// <summary>
        /// マウスを管理するクラスを取得する
        /// </summary>
        public static Mouse Mouse { get; private set; }

        ///// <summary>
        ///// ジョイスティックを管理するクラスを取得する
        ///// </summary>
        //public static Joystick Joystick { get; private set; }

        /// <summary>
        /// グラフィックのクラスを取得する
        /// </summary>
        public static Graphics Graphics { get; private set; }

        /// <summary>
        /// ログを管理するクラスを取得する
        /// </summary>
        public static Log Log { get; private set; }

        /// <summary>
        /// レンダラのクラスを取得する
        /// </summary>
        public static Renderer Renderer { get; private set; }

        /// <summary>
        /// 音を管理するクラスを取得する
        /// </summary>
        public static SoundMixer Sound { get; private set; }

        /// <summary>
        /// リソースを管理するクラスを取得する
        /// </summary>
        public static Resources Resources { get; private set; }
    }
}
