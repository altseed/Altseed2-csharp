using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Altseed2
{
    /// <summary>
    /// プロファイラのブロックを簡単に使用できるようにするクラス
    /// </summary>
    public struct ProfilerBlock : IDisposable
    {
        /// <summary>
        /// 測定を開始する。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="filepath"></param>
        /// <param name="line"></param>
        public ProfilerBlock(string name, Color color, [CallerFilePath] string filepath = null, [CallerLineNumber] int line = 0)
        {
            if(!Engine.Profiler.IsProfilerRunning)
            {
                return;
            }

            Engine.Profiler.BeginBlock(name, filepath, line, color);
        }

        /// <summary>
        /// 測定を終了する。
        /// </summary>
        public void Dispose()
        {
            if (!Engine.Profiler.IsProfilerRunning)
            {
                return;
            }

            Engine.Profiler.EndBlock();
        }
    }
}
