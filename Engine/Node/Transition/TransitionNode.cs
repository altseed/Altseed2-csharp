using System;
using System.Collections.Generic;

namespace Altseed
{
    [Serializable]
    public class TransitionNode : Node
    {
        /// <summary>
        /// ノードが入れ替わる前の処理を設定します。
        /// トランジション中は設定することができません。
        /// </summary>
        public event Action<float> OnClosingEvent
        {
            add { if (!_IsTransitioning) _OnClosingEvent += value; }
            remove { if (!_IsTransitioning) _OnClosingEvent -= value; }
        }

        /// <summary>
        /// ノードが入れ替わった後の処理を設定します。
        /// トランジション中は設定することができません。
        /// </summary>
        public event Action<float> OnOpeningEvent
        {
            add { if (!_IsTransitioning) _OnOpeningEvent += value; }
            remove { if (!_IsTransitioning) _OnOpeningEvent -= value; }
        }

        /// <summary>
        /// ノードが入れ替わる瞬間の処理を設定します。
        /// トランジション中は設定することができません。
        /// </summary>
        public event Action OnNodeSwappedEvent
        {
            add { if (!_IsTransitioning) _OnNodeSwappedEvent += value; }
            remove { if (!_IsTransitioning) _OnNodeSwappedEvent -= value; }
        }

        /// <summary>
        /// トランジションが開始する瞬間の処理を取得または設定します。
        /// トランジション中は設定することができません。
        /// </summary>
        public event Action OnTransitionBeginEvent
        {
            add { if (!_IsTransitioning) _OnTransitionBeginEvent += value; }
            remove { if (!_IsTransitioning) _OnTransitionBeginEvent -= value; }
        }

        /// <summary>
        /// トランジションが終了する瞬間の処理を取得または設定します。
        /// トランジション中は設定することができません。
        /// </summary>
        public event Action OnTransitionEndEvent
        {
            add { if (!_IsTransitioning) _OnTransitionEndEvent += value; }
            remove { if (!_IsTransitioning) _OnTransitionEndEvent -= value; }
        }

        /// <summary>
        /// トランジションによって取り除かれるノード
        /// </summary>
        protected readonly Node OldNode;

        /// <summary>
        /// トランジションによって追加されるノード
        /// </summary>
        protected readonly Node NewNode;

        // トランジションが行われている最中か
        private bool _IsTransitioning;

        // イベント
        private event Action<float> _OnClosingEvent;
        private event Action<float> _OnOpeningEvent;
        private event Action _OnNodeSwappedEvent;
        private event Action _OnTransitionBeginEvent;
        private event Action _OnTransitionEndEvent;

        // コルーチン
        private readonly IEnumerator<object> _Coroutine;

        /// <summary>
        /// 新しいインスタンスを作成します。
        /// </summary>
        /// <param name="oldNode">トランジションによって取り除かれるノード</param>
        /// <param name="newNode">トランジションによって追加されるノード</param>
        /// <param name="closingDuration">トランジションが始まってからノードが入れ替わるまでの期間</param>
        /// <param name="openingDuration">トランジションが始まってからノードが入れ替わるまでの期間</param>
        public TransitionNode(Node oldNode, Node newNode, float closingDuration, float openingDuration)
        {
            OldNode = oldNode;
            NewNode = newNode;

            _Coroutine = GetCoroutine(closingDuration, openingDuration);
        }

        protected override void OnUpdate()
        {
            _Coroutine?.MoveNext();
        }

        /// <summary>
        /// ノードが入れ替わる前の処理を記述します。
        /// </summary>
        protected virtual void OnClosing(float progress) => _OnClosingEvent?.Invoke(progress);

        /// <summary>
        /// ノードが入れ替わった後の処理を記述します。
        /// </summary>
        protected virtual void OnOpening(float progress) => _OnOpeningEvent?.Invoke(progress);

        /// <summary>
        /// ノードが入れ替わる瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnNodeSwapped() => _OnNodeSwappedEvent?.Invoke();

        /// <summary>
        /// トランジションが開始する瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionBegin() => _OnTransitionBeginEvent?.Invoke();

        /// <summary>
        /// トランジションが終了する瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionEnd() => _OnTransitionEndEvent?.Invoke();

        // トランジションを行うコルーチン
        private IEnumerator<object> GetCoroutine(float closingDuration, float openingDuration)
        {
            // トランジションの開始
            _IsTransitioning = true;
            OnTransitionBegin();
            yield return null;

            // ノードが入れ替わる前の処理
            for(float time = 0.0f;  time < closingDuration; time += Engine.DeltaSecond)
            {
                OnClosing(MathF.Min(1.0f, time / closingDuration));
                yield return null;
            }

            // ノードの入れ替え
            var parentNode = OldNode.Parent;
            parentNode.RemoveChildNode(OldNode);
            parentNode.AddChildNode(NewNode);

            // ノードが入れ替わるの処理
            OnNodeSwapped();
            yield return null;

            // ノードが入れ替わった後の処理
            for(float time = 0.0f; time < openingDuration; time += Engine.DeltaSecond)
            {
                OnOpening(MathF.Min(1.0f, time / openingDuration));
                yield return null;
            }

            // トランジションの終了
            Parent.RemoveChildNode(this);
            OnTransitionEnd();
            _IsTransitioning = false;
        }
    }
}