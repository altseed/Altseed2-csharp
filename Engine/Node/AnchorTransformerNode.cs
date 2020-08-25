using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// アンカー機能の計算方法を指定します。
    /// </summary>
    [Serializable]
    public enum AnchorMode
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
        /// ContentSizeのまま表示します
        /// </summary>
        ContentSize,
    }

    /// <summary>
    /// 水平方向の配置
    /// </summary>
    [Serializable]
    public enum HorizontalAlignment
    {
        /// <summary>
        /// 左揃え
        /// </summary>
        Left,

        /// <summary>
        /// 中央揃え
        /// </summary>
        Center,

        /// <summary>
        /// 右揃え
        /// </summary>
        Right,
    }

    /// <summary>
    /// 垂直方向の配置
    /// </summary>
    [Serializable]
    public enum VerticalAlignment
    {
        /// <summary>
        /// 上揃え
        /// </summary>
        Top,

        /// <summary>
        /// 中央揃え
        /// </summary>
        Center,

        /// <summary>
        /// 下揃え
        /// </summary>
        Bottom,
    }


    /// <summary>
    /// アンカーによって変形するノードのクラス
    /// </summary>
    [Serializable]
    public class AnchorTransformerNode : TransformerNode
    {
        /// <inheritdoc/>
        public override Matrix44F Transform
        {
            get
            {
                if (!RequireCalcTransform)
                    return _Transform;

                var scale = Scale * new Vector2F(HorizontalFlip ? -1 : 1, VerticalFlip ? -1 : 1);
                var offset
                    = ((Parent?.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode)?.Size ?? default) * AnchorMin;

                _Transform = Matrix44F.GetTranslation2D(offset) * MathHelper.CalcTransform(Position, MathHelper.DegreeToRadian(Angle), scale) * Matrix44F.GetTranslation2D(-CenterPosition);
                RequireCalcTransform = false;

                return _Transform;
            }
        }
        private Matrix44F _Transform = Matrix44F.Identity;

        /// <summary>
        /// 先祖の変形を加味した変形行列を取得します。
        /// </summary>
        public override Matrix44F InheritedTransform
        {
            get => _InheritedTransform;
            set
            {
                _InheritedTransform = value;
            }
        }
        private Matrix44F _InheritedTransform = Matrix44F.Identity;

        /// <summary>
        /// 先祖の変形および<see cref="AnchorMode"/>を加味した最終的な変形行列を取得します。
        /// </summary>
        public override Matrix44F AbsoluteTransform => InheritedTransform * CalcInternalTransform();

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
                RequireCalcTransform = true;
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
                RequireCalcTransform = true;

                UpdateMargin();
            }
        }
        private Vector2F _Position = new Vector2F();

        private void SetPositionDirectly(Vector2F position)
        {
            _Position = position;
            RequireCalcTransform = true;
        }

        /// <summary>
        /// 中心となる座標をピクセル単位で取得または設定します。
        /// </summary>
        public Vector2F CenterPosition
        {
            get => Pivot * Size;
            set
            {
                if (Pivot * Size == value) return;

                if (Size.X == 0 || Size.Y == 0)
                {
                    Engine.Log.Warn(LogCategory.Engine, "AnchorTransform Pivot: Size include zero　element.");
                    return;
                }

                Pivot = value / Size;
            }
        }

        /// <summary>
        /// 中心となる座標を[0, 1]で取得または設定します。
        /// </summary>
        public Vector2F Pivot
        {
            get => _Pivot;
            set
            {
                if (_Pivot == value) return;

                _Pivot = value;
                RequireCalcTransform = true;
            }
        }
        private Vector2F _Pivot;

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
                RequireCalcTransform = true;

                UpdateMargin();
                ApplySizeChanged();
            }
        }
        private Vector2F _Size = new Vector2F(1f, 1f);

        private void SetSizeDirectly(Vector2F size)
        {
            _Size = size;
            RequireCalcTransform = true;
        }

        /// <summary>
        /// <see cref="Size" />の左上から親ノードの<see cref="Size" />の左上までの距離
        /// </summary>
        public Vector2F LeftTop
        {
            get => _LeftTop;
            set
            {
                if (_LeftTop == value) return;

                _LeftTop = value;
                UpdateMargin();
            }
        }
        private Vector2F _LeftTop = new Vector2F(0f, 0f);

        /// <summary>
        /// <see cref="Size" />の右下から親ノードの<see cref="Size" />の右下までの距離
        /// </summary>
        public Vector2F RightBottom
        {
            get => _RightBottom;
            set
            {
                if (_RightBottom == value) return;

                _RightBottom = value;
                UpdateMargin();
            }
        }
        private Vector2F _RightBottom = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカー(左上)を取得または設定します。
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

                UpdateMargin();
                RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMin = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカー(右下)を取得または設定します。
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

                UpdateMargin();
                RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMax = new Vector2F(1f, 1f);

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
                RequireCalcTransform = true;
            }
        }
        private Vector2F _Scale = new Vector2F(1.0f, 1.0f);

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
                RequireCalcTransform = true;
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
                RequireCalcTransform = true;
            }
        }
        private bool _VerticalFlip = false;

        /// <summary>
        /// サイズとコンテンツの関係を取得または設定します。
        /// </summary>
        public AnchorMode AnchorMode
        {
            get => _AnchorMode;
            set
            {
                if (_AnchorMode == value) return;

                _AnchorMode = value;
                RequireCalcTransform = true;
            }
        }
        private AnchorMode _AnchorMode = AnchorMode.ContentSize;

        /// <summary>
        /// 水平方向の配置
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get => _HorizontalAlignment;
            set
            {
                if (value == _HorizontalAlignment) return;

                _HorizontalAlignment = value;
                RequireCalcTransform = true;
            }
        }
        private HorizontalAlignment _HorizontalAlignment = HorizontalAlignment.Left;

        /// <summary>
        /// 垂直方向の配置
        /// </summary>
        public VerticalAlignment VerticalAlignment
        {
            get => _VerticalAlignment;
            set
            {
                if (value == _VerticalAlignment)
                    return;

                _VerticalAlignment = value;
                RequireCalcTransform = true;
            }
        }
        private VerticalAlignment _VerticalAlignment = VerticalAlignment.Top;

        private void ApplySizeChanged()
        {
            if (Status != RegisteredStatus.Registered) return;

            foreach (var child in Parent.Children)
            {
                ApplySizeChanged(child);
            }
        }

        /// <summary>
        /// <see cref="Size"/>変更時に、直下の<see cref="AnchorTransformerNode"/>を持つ<see cref="TransformNode"/>に対して
        /// <see cref="LeftTop"/>/<see cref="RightBottom"/>/<see cref="AnchorMax"/>/<see cref="AnchorMin"/>を用いて
        /// <see cref="Size"/>/<see cref="Position"/>を更新します。
        /// </summary>
        private void ApplySizeChanged(Node node)
        {
            if (node is TransformNode t && t.Transfomer is AnchorTransformerNode transformer)
            {
                var parentTransformer = t.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode;
                var anchorDistance = (parentTransformer?.Size ?? new Vector2F()) * (transformer.AnchorMax - transformer.AnchorMin);

                transformer.SetSizeDirectly(anchorDistance + transformer.LeftTop - transformer.RightBottom);
                transformer.SetPositionDirectly(transformer.Size * transformer.Pivot - transformer.LeftTop);
            }

            foreach (var child in node.Children)
            {
                ApplySizeChanged(child);
            }
        }

        private protected void UpdateMargin()
        {
            if (Status == RegisteredStatus.Free) return;

            // Margin の更新
            var anchorDistance = ((Parent?.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode)?.Size ?? new Vector2F()) * (AnchorMax - AnchorMin);
            _LeftTop = Pivot * Size - Position;
            _RightBottom = anchorDistance + _LeftTop - _Size;
        }

        private Matrix44F CalcInternalTransform()
        {
            if (!(Parent is TransformNode))
                return Matrix44F.Identity;

            var res = Matrix44F.Identity;
            var relativeSize = Size;
            var contentSize = (Parent as TransformNode).ContentSize;
            switch (AnchorMode)
            {
                case AnchorMode.Fill:
                    res *= Matrix44F.GetScale2D(Size / contentSize);
                    break;

                case AnchorMode.KeepAspect:
                    if (Size.X / Size.Y > contentSize.X / contentSize.Y)
                        relativeSize.X = contentSize.X * Size.Y / contentSize.Y;
                    else
                        relativeSize.Y = contentSize.Y * Size.X / contentSize.X;

                    res *= Matrix44F.GetScale2D(relativeSize / contentSize);
                    break;

                case AnchorMode.ContentSize:
                    break;

                default: throw new InvalidOperationException(nameof(AnchorMode));
            }

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    res = Matrix44F.GetTranslation2D(new Vector2F((Size.X - relativeSize.X) / 2, 0)) * res;
                    break;
                case HorizontalAlignment.Right:
                    res = Matrix44F.GetTranslation2D(new Vector2F(Size.X - relativeSize.X, 0)) * res;
                    break;
                default:
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    break;
                case VerticalAlignment.Center:
                    res = Matrix44F.GetTranslation2D(new Vector2F(0, (Size.Y - relativeSize.Y) / 2)) * res;
                    break;
                case VerticalAlignment.Bottom:
                    res = Matrix44F.GetTranslation2D(new Vector2F(0, Size.Y - relativeSize.Y)) * res;
                    break;
                default:
                    break;
            }

            return res;
        }

        #region Node

        internal override void Registered()
        {
            base.Registered();

            UpdateMargin();
        }

        internal override void Unregistered()
        {
            base.Unregistered();
        }

        #endregion
    }
}
