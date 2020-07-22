namespace Altseed2
{
    public abstract class DrawnNode : TransformNode,ICullableDrawn
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
                    Engine.UpdateDrawnZOrder(this, old);
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
                    Engine.UpdateDrawnCameraGroup(this, old);
            }
        }
        private ulong _CameraGroup = 0;

        /// <summary>
        /// カリング用ID
        /// </summary>
        internal virtual int CullingId => -1;

        int ICullableDrawn.CullingId => throw new System.NotImplementedException();

        bool ICullableDrawn.IsDrawn => throw new System.NotImplementedException();

        bool ICullableDrawn.IsDrawnActually { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        ulong IDrawn.CameraGroup { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        int IDrawn.ZOrder => throw new System.NotImplementedException();

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
            Engine.RegisterDrawn(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            UpdateDescendantsIsDrawnActually();
            Engine.UnregisterDrawn(this);
        }

        void IDrawn.Draw()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
