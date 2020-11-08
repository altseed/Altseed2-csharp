using System;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 画面遷移を行うノードのクラス
    /// </summary>
    [Serializable]
    public class TransitionNode : Node
    {
        private bool _OnTransition;

        /// <summary>
        /// トランジションによって取り除かれるノード
        /// </summary>
        public Node PrevNode { get; private set; }

        /// <summary>
        /// トランジションによって追加されるノード
        /// </summary>
        public Node NextNode { get; private set; }

        /// <summary>
        /// トランジションが始まってからノードが入れ替わるまでの期間
        /// </summary>
        public float ClosingDuration
        {
            get => _ClosingDuration;
            set
            {
                if (!_OnTransition) _ClosingDuration = value;
                else Engine.Log.Error(LogCategory.Engine, "Cannot set value during transition.");
            }
        }
        private float _ClosingDuration;

        /// <summary>
        /// ノードが入れ替わってからトランジションが終わるまでの期間
        /// </summary>
        public float OpeningDuration
        {
            get => _OpeningDuration;
            set
            {
                if (!_OnTransition) _OpeningDuration = value;
                else Engine.Log.Error(LogCategory.Engine, "Cannot set value during transition.");
            }
        }
        private float _OpeningDuration;

        /// <summary>
        /// トランジションを行うコルーチン
        /// </summary>
        private IEnumerator<int> _Coroutine;

        /// <summary>
        /// <see cref="TransitionNode"/>の新しいインスタンスを作成します。
        /// </summary>
        public TransitionNode()
        {
            _OnTransition = false;

            PrevNode = null;
            NextNode = null;
        }

        /// <summary>
        /// トランジションを開始します。
        /// </summary>
        public void StartTransition(Node prevNode, Node nextNode)
        {
            if (!_OnTransition)
            {
                _Coroutine = GetCoroutine();

                PrevNode = prevNode;
                NextNode = nextNode;
            }
            else Engine.Log.Error(LogCategory.Engine, "Cannot start during transition.");
        }

        internal override void Update()
        {
            base.Update();
            _OnTransition = _Coroutine?.MoveNext() ?? false;
        }

        internal virtual void TransitionBegin()
        {
            OnTransitionBegin();
        }

        internal virtual void Closing(float progress)
        {
            OnClosing(progress);
        }

        internal virtual void NodeSwapping()
        {
            OnNodeSwapping();
        }

        internal virtual void NodeSwapped()
        {
            OnNodeSwapped();
        }

        internal virtual void Opening(float progress)
        {
            OnOpening(progress);
        }

        internal virtual void TransitionEnd()
        {
            OnTransitionEnd();
        }

        /// <summary>
        /// ノードが入れ替わる前の処理を記述します。
        /// </summary>
        /// <param name="progress">0.0f ~ 1.0fの範囲で、ノードが入れ替わるまでの進行度を受け取ります。</param>
        protected virtual void OnClosing(float progress) { }

        /// <summary>
        /// ノードが入れ替わった後の処理を記述します。
        /// </summary>
        /// <param name="progress">0.0f ~ 1.0fの範囲で、ノードが入れ替わった後の進行度を受け取ります。</param>
        protected virtual void OnOpening(float progress) { }

        /// <summary>
        /// ノードが入れ替わる直前の処理を記述します。
        /// </summary>
        protected virtual void OnNodeSwapping() { }

        /// <summary>
        /// ノードが入れ替わった直後の処理を記述します。
        /// </summary>
        protected virtual void OnNodeSwapped() { }

        /// <summary>
        /// トランジションが開始する瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionBegin() { }

        /// <summary>
        /// トランジションが終了する直前の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionEnd() { }

        /// <summary>
        /// トランジションを行うコルーチン
        /// </summary>
        private IEnumerator<int> GetCoroutine()
        {
            // トランジションの開始
            TransitionBegin();
            yield return 0;

            // ノードが入れ替わる前の処理
            for (float time = 0.0f; time < ClosingDuration; time += Engine.DeltaSecond)
            {
                Closing(MathF.Min(1.0f, time / ClosingDuration));
                yield return 0;
            }

            // ノードが入れ替わる直前の処理
            NodeSwapping();
            yield return 0;

            // ノードの入れ替え
            var parentNode = PrevNode.Parent;
            parentNode.RemoveChildNode(PrevNode);
            parentNode.AddChildNode(NextNode);

            // ノードが入れ替わった直後の処理
            NodeSwapped();
            yield return 0;

            // ノードが入れ替わった後の処理
            for (float time = 0.0f; time < OpeningDuration; time += Engine.DeltaSecond)
            {
                Opening(MathF.Min(1.0f, time / OpeningDuration));
                yield return 0;
            }

            // トランジションの終了
            Parent.RemoveChildNode(this);
            TransitionEnd();
        }
    }
}