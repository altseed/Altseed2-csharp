using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    [Serializable]
    public class CameraNode : Node
    {
        private readonly RenderedCamera _Camera;
        internal RenderedCamera RenderedCamera => _Camera;

        /// <summary>
        /// 描画対象とする <see cref="DrawnNode"/> のグループを取得または設定します。
        /// </summary>
        public int Group
        {
            get => _Group;
            set
            {
                if (_Group == value) return;
                var old = _Group;
                _Group = value;

                if (Status == RegisterStatus.Registered)
                    Engine.UpdateCameraNodeGroup(this, old);

            }
        }
        private int _Group = 0;

        public CameraNode()
        {
            _Camera = RenderedCamera.Create();
        }

        /// <summary>
        /// 変形行列を取得または設定します。
        /// </summary>
        public Matrix44F Transform
        {
            get => _Camera.Transform;
            set
            {
                if (value == _Camera.Transform) return;
                _Camera.Transform = value;
            }
        }

        /// <summary>
        /// 描画先のテクスチャを取得または設定します。
        /// </summary>
        public RenderTexture TargetTexture
        {
            get => _Camera.TargetTexture;
            set
            {
                if (value == _Camera.TargetTexture) return;
                _Camera.TargetTexture = value;
            }
        }

        #region Node

        protected internal override void Registered()
        {
            base.Registered();
            Engine.RegisterCameraNode(this);
        }

        protected internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterCameraNode(this);
        }

        #endregion
    }
}
