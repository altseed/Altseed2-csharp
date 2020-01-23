using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using asd;

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
            var o = option.toAsd();
            if (Core.Initialize(title, width, height, ref o))
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

    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;

        internal asd.CoreOption toAsd()
        {
            return new asd.CoreOption()
            {
                IsFullscreenMode = this.IsFullscreenMode,
                IsResizable = this.IsResizable,
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DI
    {
        public int X;
        public int Y;

        internal asd.Vector2DI toAsd()
        {
            return new asd.Vector2DI()
            {
                X = this.X,
                Y = this.Y,
            };
        }
    }
}
