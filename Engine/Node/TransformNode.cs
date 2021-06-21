using System;

namespace Altseed2
{
    /// <summary>
    /// 変形行列を備えたノードのクラス
    /// </summary>
    [Serializable]
    public class TransformNode : Node
    {
        /// <summary>
        /// <see cref="TransformNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public TransformNode()
        {
            if (Engine.Config.VisibleTransformInfo)
                _TransformNodeInfo = new TransformNodeInfo(this);
        }

        internal Matrix44F Transform
        {
            get => Transfomer?.Transform ?? _Transform;
            set
            {
                if (Transfomer == null)
                    _Transform = value;
            }
        }
        [NonSerialized]
        private Matrix44F _Transform = Matrix44F.Identity;

        private protected bool _RequireCalcTransform = true;

        /// <summary>
        /// 先祖の変形を加味した変形行列を取得します。
        /// </summary>
        public virtual Matrix44F InheritedTransform
        {
            get => Transfomer?.InheritedTransform ?? _InheritedTransform;
            private protected set
            {
                // 継承先も必ずbase.InheritedTransform = valueするように
                if (Transfomer == null)
                {
                    _InheritedTransform = value;
                    _AbsoluteTransform = value;
                    _TransformNodeInfo?.Update();
                }
                else
                {
                    Transfomer.InheritedTransform = value;
                    Transfomer.TransformerNodeInfo?.Update();
                }
            }
        }
        private Matrix44F _InheritedTransform = Matrix44F.Identity;

        /// <summary>
        /// 先祖の変形および<see cref="CenterPosition"/>を加味した最終的な変形行列を取得します。
        /// </summary>
        public Matrix44F AbsoluteTransform
        {
            get => Transfomer?.AbsoluteTransform ?? _AbsoluteTransform;
            set
            {
                _AbsoluteTransform = value;
            }
        }
        private Matrix44F _AbsoluteTransform = Matrix44F.Identity;

        internal TransformerNode Transfomer { get; set; }

        /// <summary>
        /// 角度(度数法)を取得または設定します。
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
        /// 座標を取得または設定します。
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
        /// 中心となる座標をピクセル単位で取得または設定します。
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
        /// 拡大率を取得または設定します。
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
        private Vector2F _Scale = new Vector2F(1.0f, 1.0f);

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public virtual Vector2F ContentSize { get; }

        /// <summary>
        /// 左右を反転するかどうかを取得または設定します。
        /// </summary>
        public bool HorizontalFlip
        {
            get => _HorizontalFlip;
            set
            {
                if (value == _HorizontalFlip) return;

                _HorizontalFlip = value;
                _RequireCalcTransform = true;
            }
        }
        private bool _HorizontalFlip = false;

        /// <summary>
        /// 上下を反転するかどうかを取得または設定します。
        /// </summary>
        public bool VerticalFlip
        {
            get => _VerticalFlip;
            set
            {
                if (value == _VerticalFlip) return;

                _VerticalFlip = value;
                _RequireCalcTransform = true;
            }
        }
        private bool _VerticalFlip = false;

        internal override void Registered()
        {
            UpdateTransform();
            base.Registered();
        }

        internal override void Update()
        {
            if (_RequireCalcTransform || (Transfomer?.RequireCalcTransform ?? false))
                UpdateTransform();

            base.Update();
        }

        /// <summary>
        /// <see cref="InheritedTransform"/>を再計算します。
        /// 直近先祖の<see cref="InheritedTransform"/>も考慮した上で最終的な変形を計算し、
        /// 既存の子孫ノードにも伝播します。
        /// </summary>
        private void UpdateTransform()
        {
            if (Transfomer == null)
                CalcTransform();

            var ancestor = GetAncestorSpecificNode<TransformNode>();
            PropagateTransform(this, ancestor?.InheritedTransform ?? Matrix44F.Identity);
        }

        /// <summary>
        /// <see cref="Transform"/> を再計算します。
        /// </summary>
        private protected virtual void CalcTransform()
        {
            var scale = Scale * new Vector2F(HorizontalFlip ? -1 : 1, VerticalFlip ? -1 : 1);

            Transform = MathHelper.CalcTransform(Position, MathHelper.DegreeToRadian(Angle), scale);

            _RequireCalcTransform = false;
        }

        /// <summary>
        /// 子孫ノードのうち<see cref="TransformNode"/>に対して変換行列を伝播させます。
        /// </summary>
        private void PropagateTransform(Node node, Matrix44F matrix)
        {
            if (node is TransformNode s)
            {
                matrix = matrix * s.Transform;
                s.InheritedTransform = matrix;
            }

            foreach (var child in node.Children)
            {
                PropagateTransform(child, matrix);
            }
        }

        /// <summary>
        /// 変形に関する情報
        /// </summary>
        private TransformNodeInfo _TransformNodeInfo { get; }

        public bool VisibleTransformNodeInfo { get; set; } = Engine.Config.VisibleTransformInfo;

        internal void DrawTransformInfo()
        {
            if (!VisibleTransformNodeInfo) return;

            if (Transfomer == null)
            {
                _TransformNodeInfo?.Draw();
            }
            else
            {
                Transfomer.TransformerNodeInfo?.Draw();
            }
        }
    }
}
