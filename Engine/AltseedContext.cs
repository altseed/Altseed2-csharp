using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Altseed2
{
    /// <summary>
    /// Altseed2における<see cref="SynchronizationContext"/>
    /// </summary>
    internal class AltseedContext : SynchronizationContext
    {
        private readonly struct Entry
        {
            private readonly SendOrPostCallback d;
            private readonly object state;

            internal Entry(SendOrPostCallback d, object state)
            {
                this.d = d ?? throw new ArgumentNullException(nameof(d), "引数がnullです");
                this.state = state;
            }

            internal void Invoke()
            {
                d.Invoke(state);
            }
        }

        private readonly ConcurrentQueue<Entry> actions = new ConcurrentQueue<Entry>();

        /// <summary>
        /// 溜められた処理の個数を取得します。
        /// </summary>
        public int Count => actions.Count;

        /// <summary>
        /// 更新されるかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated { get; set; } = true;

        public override void Post(SendOrPostCallback d, object state)
        {
            actions.Enqueue(new Entry(d, state));
        }

        /// <summary>
        /// 溜められた処理の実行を行います。
        /// </summary>
        public void Update()
        {
            if (!IsUpdated) return;
            
            var count = actions.Count;
            for (int i = 0; i < count; i++)
            {
                if (actions.TryDequeue(out var e)) e.Invoke();
            }
        }
    }
}
