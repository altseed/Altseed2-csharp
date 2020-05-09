using System;

namespace Altseed
{
    [Serializable]
    public class TransitionNode : Node
    {


        #region トランジション用のポストエフェクト
        private class PostEffectNodeForTransition : PostEffectNode
        {
            internal Material Material;

            internal Node OldNode;
            internal Node NewNode;

            internal float FadeOutDuration;
            internal float FadeInDuration;

            private float _TransitionTime;

            internal PostEffectNodeForTransition()
            {
                DrawingOrder = 3000;
            }

            protected override void OnAdded()
            {
                _TransitionTime = 0.0f;
            }

            protected override void OnUpdate()
            {
                if (_TransitionTime < FadeOutDuration)
                {
                    if ((_TransitionTime += Engine.DeltaSecond) >= FadeOutDuration)
                    {
                        var parentNode = OldNode.Parent;
                        parentNode.RemoveChildNode(OldNode);
                        parentNode.AddChildNode(NewNode);
                    }
                }

                else if (_TransitionTime < FadeOutDuration + FadeInDuration)
                {
                    if ((_TransitionTime += Engine.DeltaSecond) >= FadeOutDuration + FadeInDuration)
                    {
                        Parent.RemoveChildNode(this);
                    }
                }
            }

            protected override void Draw(RenderTexture src)
            {
                Material.SetTexture("mainTex", src);
                Material.SetVector4F("_TransitionTime", new Vector4F(_TransitionTime, 0, 0, 0));
                RenderToRenderTarget(Material);
            }
        }
        #endregion



        private PostEffectNodeForTransition _PostEffectNode;

        /// <summary>
        /// フェードアウトに要する時間を取得または設定します。
        /// </summary>
        public float FadeOutDuration
        {
            get => _PostEffectNode.FadeOutDuration;
            set => _PostEffectNode.FadeOutDuration = value;
        }

        /// <summary>
        /// フェードインに要する時間を取得または設定します。
        /// </summary>
        public float FadeInDuration
        {
            get => _PostEffectNode.FadeInDuration;
            set => _PostEffectNode.FadeInDuration = value;
        }

        /// <summary>
        /// トランジション用のポストエフェクトに使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => _PostEffectNode.Material;
            set
            {
                if (_PostEffectNode.Material == value) return;
                _PostEffectNode.Material = value;
            }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TransitionNode()
        {
            _PostEffectNode = new PostEffectNodeForTransition();
        }

        /// <summary>
        /// トランジションを開始します
        /// </summary>
        public void StartTransition(Node oldNode, Node newNode)
        {
            _PostEffectNode.OldNode = oldNode;
            _PostEffectNode.NewNode = newNode;

            AddChildNode(_PostEffectNode);
        }
    }
}
