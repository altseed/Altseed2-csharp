using System;

namespace Altseed
{
    [Serializable]
    public class TransitionNode : Node
    {
        /// <summary>
        /// トランジションの状態
        /// </summary>
        private enum TransitionState
        {
            Closing,
            Opening
        }

        /// <summary>
        /// トランジションによって取り除かれるノード
        /// </summary>
        protected Node OldNode { get; }

        /// <summary>
        /// トランジションによって追加されるノード
        /// </summary>
        protected Node NewNode { get; }

        /// <summary>
        /// トランジションが始まってからの時間
        /// </summary>
        protected float TransitionTime { get; private set; }

        /// <summary>
        /// トランジションの状態
        /// </summary>
        private TransitionState State;

        /// <summary>
        /// 新しいインスタンスを作成します。
        /// </summary>
        /// <param name="oldNode">トランジションによって取り除かれるノード</param>
        /// <param name="newNode">トランジションによって追加されるノード</param>
        /// <param name="duration">トランジションの期間</param>
        public TransitionNode(Node oldNode, Node newNode)
        {
            OldNode = oldNode;
            NewNode = newNode;
        }

        protected override void OnUpdate()
        {
            switch(State)
            {
                case TransitionState.Closing:
                    OnClosing();
                    break;

                case TransitionState.Opening:
                    OnOpening();
                    break;

                default:
                    throw new NotImplementedException();
            }

            TransitionTime += Engine.DeltaSecond;
        }

        /// <summary>
        /// ノードを入れ替えます。
        /// </summary>
        protected void SwapNode()
        {
            if(State == TransitionState.Closing)
            {
                var parentNode = OldNode.Parent;
                parentNode.RemoveChildNode(OldNode);
                parentNode.AddChildNode(NewNode);

                OnNodeSwapped();

                State = TransitionState.Opening;
            }
        }

        /// <summary>
        /// トランジションを終了します。
        /// </summary>
        protected void FinishTransition()
        {
            SwapNode();
            Parent.RemoveChildNode(this);
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
    }
}
