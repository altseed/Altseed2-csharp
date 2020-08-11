using System;

namespace Altseed2
{
    /// <summary>
    /// カメラとして機能するノードのクラス
    /// </summary>
    [Serializable]
    public class CameraNode : Node
    {
        private readonly RenderedCamera _Camera;
        internal RenderedCamera RenderedCamera => _Camera;

        private bool _RequireCalcTransform = true;

        /// <summary>
        /// 描画対象のグループを取得または設定します。
        /// </summary>
        public int Group
        {
            get => _Group;
            set
            {
                if (_Group == value) return;

                if (value <= 0) Engine.Log.Warn(LogCategory.Engine, $"{GetType()} のGroupの値が小さすぎます。");
                if (value >= Engine.MaxCameraGroupCount) Engine.Log.Warn(LogCategory.Engine, $"{GetType()} のGroupの値が大きすぎます。");

                var old = _Group;
                _Group = value;

                if (Status == RegisteredStatus.Registered)
                    Engine.UpdateCameraNodeGroup(this, old);

            }
        }
        private int _Group = 0;

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
        public CameraNode()
        {
            _Camera = RenderedCamera.Create();

            ClearColor = new Color(50, 50, 50);
            IsColorCleared = false;
        }

        /// <summary>
        /// 描画領域の回転角（度数法）を取得または設定します。
        /// </summary>
        public float Angle
        {
            get => _Angle;
            set
            {
                if (_Angle == value) return;

                _Angle = value;
                _RequireCalcTransform = true;
            }
        }
        private float _Angle = 0.0f;

        /// <summary>
        /// 描画領域の座標を取得または設定します。
        /// </summary>
        public Vector2F Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;

                _Position = value;
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _Position = new Vector2F();

        /// <summary>
        /// 描画領域の中心座標をピクセル単位で取得または設定します。
        /// </summary>
        public Vector2F CenterPosition
        {
            get => _CenterPosition;
            set
            {
                if (_CenterPosition == value) return;

                _CenterPosition = value;
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _CenterPosition;

        /// <summary>
        /// 描画領域の拡大率を取得または設定します。
        /// </summary>
        public Vector2F Scale
        {
            get => _Scale;
            set
            {
                if (value == _Scale) return;

                _Scale = value;
                _RequireCalcTransform = true;
            }
        }
        private protected Vector2F _Scale = new Vector2F(1.0f, 1.0f);

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
            if (_RequireCalcTransform || _TargetSize != (TargetTexture?.Size ?? Engine.WindowSize))
            {
                _TargetSize = (TargetTexture?.Size ?? Engine.WindowSize);

                RenderedCamera.ViewMatrix =
                Matrix44F.GetTranslation2D(CenterPosition - _TargetSize / 2)
                * Matrix44F.GetScale2D(new Vector2F(1f, 1f) / Scale)
                * Matrix44F.GetRotationZ(-Angle)
                * Matrix44F.GetTranslation2D(-Position);
                // NOTE: DrawnNodeのTransformとは逆

                _RequireCalcTransform = false;
            }

            base.Update();
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
