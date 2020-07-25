using System;

namespace Altseed2
{
    internal interface ISized
    {
        Vector2F Size { get; }
    }

    /// <summary>
    /// 拡大率の自動計算方法を指定します。
    /// </summary>
    [Serializable]
    public enum ScalingMode
    {
        /// <summary>
        /// Size いっぱいに描画されるよう拡大率を計算します。ContentSize の縦横比は保持されません。
        /// </summary>
        Fill,

        /// <summary>
        /// ContentSize の縦横比は保持しつつ、Size に収まって描画されるよう拡大率を計算します。
        /// </summary>
        KeepAspect,

        /// <summary>
        /// SizeのほうをContentSizeに合わせて変更します。
        /// </summary>
        ContentSize,

        /// <summary>
        /// 拡大率を自動計算しません。
        /// </summary>
        Manual,
    }

    /// <summary>
    /// 変形行列を備えたノードのクラス
    /// </summary>
    [Serializable]
    public class TransformNode : Node
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TransformNode()
        {
            if (Engine.Config.VisibleTransformInfo)
                TransformNodeInfo = new TransformNodeInfo(this);
        }

        internal Matrix44F Transform
        {
            get => _Transform;
            set { _Transform = value; }
        }
        [NonSerialized]
        private Matrix44F _Transform = Matrix44F.Identity;

        private protected bool _RequireCalcTransform = true;

        /// <summary>
        /// 先祖の変形を加味した変形行列を取得します。
        /// </summary>
        internal virtual Matrix44F AbsoluteTransform { get; set; }

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
                UpdateMargin();
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
                UpdateMargin();
            }
        }
        private Vector2F _CenterPosition;

        /// <summary>
        /// 拡大率を取得または設定します。
        /// このプロパティを変更すると、 <see cref="ScalingMode"/> が <see cref="ScalingMode.Manual"/> に変更されます。
        /// </summary>
        public virtual Vector2F Scale
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
        /// 描画サイズを取得または設定します。
        /// </summary>
        public Vector2F Size
        {
            get => _Size;
            set
            {
                if (value == _Size) return;
                _Size = value;
                _RequireCalcTransform = true;
                UpdateMargin();

                //TransformNodeInfo?.UpdateSize();
                //TransformNodeInfo?.UpdatePivot();
            }
        }
        private Vector2F _Size = new Vector2F(1f, 1f);

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

        /// <summary>
        /// レイアウト自動計算機能を有効にするかどうかを取得または設定します。
        /// </summary>
        public bool AnchoringEnabled
        {
            get => _AnchoringEnabled; set
            {
                if (_AnchoringEnabled == value) return;

                _AnchoringEnabled = value;
                _RequireCalcTransform = true;
            }
        }
        private bool _AnchoringEnabled = false;

        private Vector2F _LeftTop = new Vector2F(0f, 0f);
        private Vector2F _RightBottom = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        public Vector2F AnchorMin
        {
            get => _AnchorMin;
            set
            {
                if (value == _AnchorMin) return;
                _AnchorMin = value;

                if (_AnchorMin.X < 0) _AnchorMin.X = 0;
                if (_AnchorMin.X > _AnchorMax.X) _AnchorMax.X = _AnchorMin.X;
                if (_AnchorMin.Y < 0) _AnchorMin.Y = 0;
                if (_AnchorMin.Y > _AnchorMax.Y) _AnchorMax.Y = _AnchorMin.Y;

                _RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMin = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        public Vector2F AnchorMax
        {
            get => _AnchorMax;
            set
            {
                if (value == _AnchorMax) return;
                _AnchorMax = value;

                if (_AnchorMax.X > 1) _AnchorMax.X = 1;
                if (_AnchorMax.X < _AnchorMin.X) _AnchorMin.X = _AnchorMax.X;
                if (_AnchorMax.Y > 1) _AnchorMin.Y = 1;
                if (_AnchorMax.Y < _AnchorMin.Y) _AnchorMin.Y = _AnchorMax.Y;

                _RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMax = new Vector2F(0f, 0f);

        /// <summary>
        /// 中心座標を取得または設定します。
        /// </summary>
        public Vector2F Pivot
        {
            get => CenterPosition / Size;
            set
            {

                CenterPosition = value * Size;
            }
        }

        internal override void Update()
        {
            if (_RequireCalcTransform)
            {
                CalcTransform();

                var ancestor = GetAncestorSpecificNode<TransformNode>();
                PropagateTransform(this, ancestor?.AbsoluteTransform ?? Matrix44F.Identity);
            }

            base.Update();
        }

        /// <summary>
        /// <see cref="Transform"/> を再計算します。
        /// </summary>
        private protected virtual void CalcTransform()
        {
            var ancestorSize = GetAncestorSpecificNode<ISized>()?.Size ?? new Vector2F();
            var anchorDiff = ancestorSize * (AnchorMax - AnchorMin);

            var position = Position;

            if (AnchoringEnabled)
            {
                _Position = CenterPosition - _LeftTop;

                var oldSize = Size;
                _Size = anchorDiff + _LeftTop - _RightBottom;
                if (AnchorMax.X == AnchorMin.X)
                    _Size.X = oldSize.X;
                if (AnchorMax.Y == AnchorMin.Y)
                    _Size.Y = oldSize.Y;
                _CenterPosition *= _Size / oldSize;

                position += AnchorMin * ancestorSize;
            }

            var scale = Scale * new Vector2F(HorizontalFlip ? -1 : 1, VerticalFlip ? -1 : 1);

            Transform = MathHelper.CalcTransform(position, CenterPosition, MathHelper.DegreeToRadian(Angle), scale);

            _RequireCalcTransform = false;
        }

        /// <summary>
        /// 子孫ノードのうち<see cref="TransformNode"/>に対して変換行列を伝播させます。
        /// </summary>
        private protected static void PropagateTransform(Node node, Matrix44F matrix)
        {
            if (node is TransformNode s)
            {
                if (s.AnchoringEnabled)
                    s.CalcTransform();

                matrix = matrix * s.Transform;
                s.AbsoluteTransform = matrix;
            }

            foreach (var child in node.Children)
            {
                PropagateTransform(child, matrix);
            }
        }

        private void UpdateMargin()
        {
            var ancestorSize = GetAncestorSpecificNode<ISized>()?.Size ?? new Vector2F();
            var anchorDiff = ancestorSize * (AnchorMax - AnchorMin);

            _RightBottom = anchorDiff - (Position + (new Vector2F(1, 1) - Pivot) * Size);
            _LeftTop = CenterPosition - Position;
        }

        /// <summary>
        /// 変形に関する情報
        /// </summary>
        TransformNodeInfo TransformNodeInfo { get; }

        internal void DrawTransformInfo()
        {
            TransformNodeInfo?.Draw();
        }

        private protected void CalcScale(ScalingMode scalingMode)
        {
            switch (scalingMode)
            {
                case ScalingMode.Fill:
                    _Scale = Size / ContentSize;
                    break;

                case ScalingMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > ContentSize.X / ContentSize.Y)
                        scale.X = ContentSize.X * Size.Y / ContentSize.Y;
                    else
                        scale.Y = ContentSize.Y * Size.X / ContentSize.X;

                    _Scale = scale / ContentSize;
                    break;

                case ScalingMode.ContentSize:
                    _Size = ContentSize;
                    break;

                case ScalingMode.Manual:
                    // 何もしない
                    break;
            }
        }
    }
}
