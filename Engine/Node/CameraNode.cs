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
        public uint Id
        {
            get;
            set;
        }

        public CameraNode()
        {
            _Camera = RenderedCamera.Create();
        }

        public Matrix44F Transform
        {
            get => _Camera.Transform;
            set
            {
                //if (value == _Camera.Transform) return;
                value = _Camera.Transform;
            }
        }

        public RenderTexture TargetTexture
        {
            get => _Camera.TargetTexture;
            set {
                if (value == _Camera.TargetTexture) return;
                value = _Camera.TargetTexture;
            }
        }
    }
}
