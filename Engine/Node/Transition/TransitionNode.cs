using System;
using System.Collections.Generic;

namespace Altseed
{
    [Serializable]
    public class TransitionNode : Node
    {
        /// <summary>
        /// トランジションによって取り除かれるノード
        /// </summary>
        protected readonly Node OldNode;

        /// <summary>
        /// トランジションによって追加されるノード
        /// </summary>
        protected readonly Node NewNode;

        /// <summary>
        /// トランジションを行うコルーチン
        /// </summary>
        private readonly IEnumerator<int> _Coroutine;

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
            _Coroutine.MoveNext();
        }

        /// <summary>
        /// ノードが入れ替わる前の処理を記述します。
        /// </summary>
        protected virtual void OnClosing(float progress) { }

        /// <summary>
        /// ノードが入れ替わった後の処理を記述します。
        /// </summary>
        protected virtual void OnOpening(float progress) { }

        /// <summary>
        /// ノードが入れ替わる瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnNodeSwapped() { }

        /// <summary>
        /// トランジションが開始する瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionBegin() { }

        /// <summary>
        /// トランジションが終了する瞬間の処理を記述します。
        /// </summary>
        protected virtual void OnTransitionEnd() { }

        /// <summary>
        /// トランジションを行うコルーチン
        /// </summary>
        private IEnumerator<int> GetCoroutine(float closingDuration, float openingDuration)
        {
            // トランジションの開始
            OnTransitionBegin();
            yield return 0;

            // ノードが入れ替わる前の処理
            for(float time = 0.0f;  time < closingDuration; time += Engine.DeltaSecond)
            {
                OnClosing(MathF.Min(1.0f, time / closingDuration));
                yield return 0;
            }

            // ノードの入れ替え
            var parentNode = OldNode.Parent;
            parentNode.RemoveChildNode(OldNode);
            parentNode.AddChildNode(NewNode);

            // ノードが入れ替わるの処理
            OnNodeSwapped();
            yield return 0;

            // ノードが入れ替わった後の処理
            for(float time = 0.0f; time < openingDuration; time += Engine.DeltaSecond)
            {
                OnOpening(MathF.Min(1.0f, time / openingDuration));
                yield return 0;
            }

            // トランジションの終了
            Parent.RemoveChildNode(this);
            OnTransitionEnd();
        }
    }
}