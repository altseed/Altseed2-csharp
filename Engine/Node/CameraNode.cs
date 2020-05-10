using System;

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

        public Color ClearColor
        {
            get => _ClearColor;
            set
            {
                if (_ClearColor == value) return;
                _ClearColor = value;
                _Camera.RenderPassParameter = new RenderPassParameter(_ClearColor, _IsColorCleared, true);
            }
        }
        private Color _ClearColor;

        public bool IsColorCleared
        {
            get => _IsColorCleared;
            set
            {
                if (_IsColorCleared == value) return;
                _IsColorCleared = value;
                _Camera.RenderPassParameter = new RenderPassParameter(_ClearColor, _IsColorCleared, true);
            }
        }
        private bool _IsColorCleared;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public CameraNode()
        {
            _Camera = RenderedCamera.Create();

            ClearColor = new Color(50, 50, 50);
            IsColorCleared = false;
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
