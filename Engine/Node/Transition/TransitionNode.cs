using System;
using System.Collections;

namespace Altseed
{
    [Serializable]
    public class TransitionNode : Node
    {
        /// <summary>
        /// トランジションによって取り除かれるノード
        /// </summary>
        protected Node OldNode { get; }

        /// <summary>
        /// トランジションによって追加されるノード
        /// </summary>
        protected Node NewNode { get; }

        /// <summary>
        /// トランジションが始まってからノードが入れ替わるまでの期間
        /// </summary>
        protected float ClosingDuration { get; }

        /// <summary>
        /// トランジションが始まってからノードが入れ替わるまでの期間
        /// </summary>
        protected float OpeningDuration { get; }

        /// <summary>
        /// トランジションが始まってからの時間
        /// </summary>
        protected float TransitionTime { get; private set; }

        /// <summary>
        /// トランジションを行うコルーチン
        /// </summary>
        private readonly IEnumerator _Coroutine;

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

            ClosingDuration = closingDuration;
            OpeningDuration = openingDuration;

            _Coroutine = GetCoroutine();
        }

        protected override void OnUpdate()
        {
            _Coroutine.MoveNext();
            TransitionTime += Engine.DeltaSecond;
        }

        /// <summary>
        /// ノードが入れ替わる前の処理を記述します。
        /// </summary>
        protected virtual void OnClosing() { }

        /// <summary>
        /// ノードが入れ替わった後の処理を記述します。
        /// </summary>
        protected virtual void OnOpening() { }

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
        private IEnumerator GetCoroutine()
        {
            OnTransitionBegin();
            yield return null;

            while (TransitionTime < ClosingDuration)
            {
                OnClosing();
                yield return null;
            }

            var parentNode = OldNode.Parent;
            parentNode.RemoveChildNode(OldNode);
            parentNode.AddChildNode(NewNode);

            OnNodeSwapped();
            yield return null;

            while (TransitionTime < ClosingDuration + OpeningDuration)
            {
                OnOpening();
                yield return null;
            }

            Parent.RemoveChildNode(this);
            OnTransitionEnd();
        }
    }
}
