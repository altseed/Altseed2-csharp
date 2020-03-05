using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Altseed.Test
{
    class TestCore
    {
        public int Duration { get; set; } = 200;
        private string _TestName;

        public void Init([CallerMemberName]string testName = "")
        {
            _TestName = testName;
            Assert.True(Engine.Initialize($"Altseed2 C# EngineTest:{testName}", 800, 600, new Configuration()));
            Engine.FramerateMode = FramerateMode.Variable;
            Engine.TargetFPS = 60;
        }

        public void LoopBody(Action<int> beforeUpdateAction, Action<int> afterUpdateAction)
        {
            int count = 0;
            while (Engine.DoEvents() && count++ < Duration)
            {
                Engine.WindowTitle = $"Altseed2 C# EngineTest:{_TestName} ({count:D3}/{Duration:D3}) FPS:{Engine.CurrentFPS}";
                beforeUpdateAction?.Invoke(count);

                Assert.True(Engine.Update());

                beforeUpdateAction?.Invoke(count);
            }
        }

        public void End()
        {
            Engine.Terminate();
        }
    }
}
