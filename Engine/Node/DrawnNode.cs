namespace Altseed
{
    public abstract class DrawnNode : TransformNode
    {
        internal abstract void Draw();

        /// <summary>
        /// 描画するかどうかを取得または設定します。
        /// </summary>
        public virtual bool IsDrawn { get; set; } = true;

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public virtual int ZOrder
        {
            get => _ZOrder;
            set
            {
                if (_ZOrder == value) return;
                var old = _ZOrder;
                _ZOrder = value;

                if (Status == RegisterStatus.Registered)
                    Engine.UpdateDrawnNodeZOrder(this, old);
            }
        }
        private int _ZOrder = 0;

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
                    Engine.UpdateDrawnNodeCameraGroup(this, old);
            }
        }
        private uint _CameraGroup = 0;

        /// <summary>
        /// カリング用ID
        /// </summary>
        internal virtual int CullingId => -1;

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawnNode(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawnNode(this);
        }

        #endregion
    }
}
