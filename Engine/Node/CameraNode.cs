using System;

namespace Altseed2
{
    /// <summary>
    /// カメラとして機能するノードのクラス
    /// </summary>
    [Serializable]
    public class CameraNode : TransformNode
    {
        private readonly RenderedCamera _Camera;
        internal RenderedCamera RenderedCamera => _Camera;

        /// <summary>
        /// 描画対象のグループを取得または設定します。
        /// </summary>
        public ulong Group
        {
            get => _Group;
            set
            {
                if (_Group == value) return;

                var old = _Group;
                _Group = value;

                if (Status == RegisteredStatus.Registered)
                    Engine.UpdateCameraNodeGroup(this, old);

            }
        }
        private ulong _Group = 0;

        /// <summary>
        /// 何も描画されていない部分の色を取得または設定します。
        /// </summary>
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

        /// <summary>
        /// 描画開始時に<see cref="ClearColor"/>で描画先を塗りつぶすかどうかを取得または設定します。
        /// </summary>
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
        /// <see cref="CameraNode"/>新しいインスタンスを生成します。
        /// </summary>
        /// <exception cref="InvalidOperationException">Graphics機能が初期化されていない。</exception>
        public CameraNode()
        {
            if (!Engine.Config.EnabledCoreModules.HasFlag(CoreModules.Graphics))
            {
                throw new InvalidOperationException("Graphics機能が初期化されていません。");
            }

            _Camera = RenderedCamera.Create();

            ClearColor = new Color(50, 50, 50);
            IsColorCleared = false;
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

        private Vector2I _TargetSize = default;

        internal override void Update()
        {
            base.Update();

            if (_TargetSize != (TargetTexture?.Size ?? Engine.WindowSize))
            {
                CalcTransform();
            }
        }

        private protected override void CalcTransform()
        {
            _TargetSize = (TargetTexture?.Size ?? Engine.WindowSize);

            RenderedCamera.ViewMatrix =
            Matrix44F.GetTranslation2D(CenterPosition - _TargetSize / 2)
            * Matrix44F.GetScale2D(new Vector2F(1f, 1f) / Scale)
            * Matrix44F.GetRotationZ(MathHelper.DegreeToRadian(-Angle))
            * Matrix44F.GetTranslation2D(-Position);
            // NOTE: DrawnNodeのTransformとは逆

            _RequireCalcTransform = false;

            base.CalcTransform();
        }

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterCameraNode(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterCameraNode(this);
        }

        #endregion
    }
}
