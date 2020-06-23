namespace Altseed2
{
    public abstract class DrawnNode : TransformNode
    {
        /// <summary>
        /// 描画するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn
        {
            get => isDrawn;
            set
            {
                if (isDrawn == value) return;
                isDrawn = value;
                UpdateDescendantsIsDrawnActually();
            }
        }
        private bool isDrawn = true;

        /// <summary>
        /// 親要素の <see cref="IsDrawn"/> も考慮して描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => isDrawnActually;
        private bool isDrawnActually = true;

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
        public ulong CameraGroup
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
        private ulong _CameraGroup = 0;

        /// <summary>
        /// カリング用ID
        /// </summary>
        internal virtual int CullingId => -1;

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal abstract void Draw();

        /// <summary>
        /// 自身と子孫ノードの IsDrawnActually プロパティを更新します。
        /// </summary>
        private void UpdateDescendantsIsDrawnActually()
        {
            isDrawnActually = isDrawn && (GetAncestorSpecificNode<DrawnNode>()?.isDrawnActually ?? true);
            foreach (var n in EnumerateDescendants())
            {
                if (n is DrawnNode d)
                {
                    d.isDrawnActually
                        = d.isDrawn && (d.GetAncestorSpecificNode<DrawnNode>()?.isDrawnActually ?? true);
                }
            }
        }

        #region Node

        internal override void Registered()
        {
            base.Registered();
            UpdateDescendantsIsDrawnActually();
            Engine.RegisterDrawnNode(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            UpdateDescendantsIsDrawnActually();
            Engine.UnregisterDrawnNode(this);
        }

        #endregion
    }
}
