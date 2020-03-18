using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public class CameraNode : Node
    {
        private readonly RenderedCamera _Camera;

        internal RenderedCamera RenderedCamera => _Camera;

        /// <summary>
        /// 描画対象とする <see cref="DrawnNode"/> のグループを取得または設定します。
        /// </summary>
        public uint Group
        {
            get => _Group;
            set
            {
                if (Status != RegisterStatus.Free) throw new NotImplementedException();

                if (_Group == value) return;
                _Group = value;
            }
        }
        private uint _Group = 0;

        public CameraNode()
        {
            _Camera = RenderedCamera.Create();
        }

        public Matrix44F Transform
        {
            get => _Camera.Transform;
            set
            {
                if (value == _Camera.Transform) return;
                _Camera.Transform = value;
            }
        }

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
