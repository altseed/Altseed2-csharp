using System;

namespace Altseed
{
    public abstract class PostEffectNode : Node
    {
        private uint _CameraGroup = 0;

        /// <summary>
        /// このノードを描画するカメラを取得または設定します。
        /// </summary>
        public uint CameraGroup
        {
            get => _CameraGroup;
            set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;

                if (Status == RegisterStatus.Registered)
                {
                    Engine.UpdatePostEffectNodeCameraGroup(this, old);
                }
            }
        }

        private int _DrawingOrder = 0;

        /// <summary>
        /// PostEffectNodeが描画される順番。DrawnNodeを描画した後にまとめて描画されます。
        /// </summary>
        public int DrawingOrder
        {
            get => _DrawingOrder;
            set
            {
                if (_DrawingOrder == value) return;
                var old = _DrawingOrder;
                _DrawingOrder = value;
                if (Status == RegisterStatus.Registered)
                {
                    Engine.UpdatePostEffectNodeOrder(this, old);
                }
            }
        }

        public PostEffectNode() { }

        internal void CallDraw(RenderTexture src) => Draw(src);

        protected abstract void Draw(RenderTexture src);

        protected void RenderToRenderTarget(Material material) => Engine.Graphics.CommandList.RenderToRenderTarget(material);

        #region Node

        protected internal override void Registered()
        {
            base.Registered();
            Engine.RegisterPostEffectNode(this);
        }

        protected internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterPostEffectNode(this);
        }

        #endregion
    }
}