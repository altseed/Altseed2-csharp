using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Altseed
{
    public static class Engine
    {
        /// <summary>
        /// 現在処理している<see cref="Scene"/>を取得する
        /// </summary>
        public static Scene CurrentScene { get; private set; }
        public static bool Initialize(string title, int width, int height, CoreOption option)
        {
            if (Core.Initialize(title, width, height, ref option))
            {
                Keyboard = Keyboard.GetInstance();
                CurrentScene = new Scene();
                return true;
            }
            return false;
        }

        public static bool DoEvents()
        {
            return Core.GetInstance().DoEvent();
        }

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
        /// <summary>
        /// シーンを即変更する
        /// </summary>
        /// <param name="scene">変更先のシーン</param>
        /// <exception cref="ArgumentNullException"><paramref name="scene"/>がnull</exception>
        internal static void ChangeScene(Scene scene)
        {
            CurrentScene = scene ?? throw new ArgumentNullException("次のシーンがnullです", nameof(scene));
        }

        public static Keyboard Keyboard { get; private set; }
    }
}
