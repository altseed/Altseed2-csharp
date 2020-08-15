﻿using System;

namespace Altseed2
{
    //internal interface ISized
    //{
    //    Vector2F Size { get; }
    //}

    ///// <summary>
    ///// アンカー機能の計算方法を指定します。
    ///// </summary>
    //[Serializable]
    //public enum AnchorMode
    //{
    //    /// <summary>
    //    /// Size いっぱいに描画されるよう拡大率を計算します。ContentSize の縦横比は保持されません。
    //    /// </summary>
    //    Fill,

    //    /// <summary>
    //    /// ContentSize の縦横比は保持しつつ、Size に収まって描画されるよう拡大率を計算します。
    //    /// </summary>
    //    KeepAspect,

    //    /// <summary>
    //    /// アンカー機能を使用しません。
    //    /// </summary>
    //    Disabled,
    //}

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
            //if (Engine.Config.VisibleTransformInfo)
            //    _TransformNodeInfo = new TransformNodeInfo(this);
        }

        internal Matrix44F Transform
        {
            get => _Transform;
            set
            {
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
            get => _InheritedTransform;
            internal set
            {
                _InheritedTransform = value;
            }
        }
        private protected Matrix44F _InheritedTransform = Matrix44F.Identity;

        /// <summary>
        /// 先祖の変形および<see cref="CenterPosition"/>を加味した最終的な変形行列を取得します。
        /// </summary>
        public virtual Matrix44F AbsoluteTransform { get; }

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
        private protected Vector2F _Scale = new Vector2F(1.0f, 1.0f);

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

        #region Anchor

        /*

        /// <summary>
        /// レイアウト自動計算の方法を指定します。
        /// </summary>
        public AnchorMode AnchorMode
        {
            get => _AnchorMode;
            set
            {
                if (_AnchorMode == value) return;

                _AnchorMode = value;
                _RequireCalcTransform = true;
            }
        }
        private AnchorMode _AnchorMode = AnchorMode.Disabled;

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
                ApplySizeChanged();
            }
        }
        private Vector2F _Size = new Vector2F(1f, 1f);

        public Vector2F LeftTop
        {
            get => _LeftTop;
            set
            {
                if (_LeftTop == value) return;

                _LeftTop = value;
                if (AnchorMode != AnchorMode.Disabled) UpdateMargin();
            }
        }
        private Vector2F _LeftTop = new Vector2F(0f, 0f);

        public Vector2F RightBottom
        {
            get => _RightBottom;
            set
            {
                if (_RightBottom == value) return;

                _RightBottom = value;
                if (AnchorMode != AnchorMode.Disabled) UpdateMargin();
            }
        }
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

                UpdateMargin();
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

                UpdateMargin();
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMax = new Vector2F(1f, 1f);

        /// <summary>
        /// 中心座標を取得または設定します。
        /// </summary>
        public Vector2F Pivot
        {
            get => Size == Vector2F.Zero ? Vector2F.Zero : CenterPosition / Size;
            set
            {
                if (_Pivot == value) return;

                CenterPosition = value * Size;
                _Pivot = value;
            }
        }
        private Vector2F _Pivot = new Vector2F();


        private void ApplySizeChanged()
        {
            foreach (var child in _Children.CurrentCollection)
            {
                ApplySizeChanged(child);
            }
        }

        /// <summary>
        /// <see cref="Size"/>変更時に、直下の<see cref="TransformNode"/>に対して
        /// <see cref="LeftTop"/>/<see cref="RightBottom"/>/<see cref="AnchorMax"/>/<see cref="AnchorMin"/>を用いて
        /// <see cref="Size"/>/<see cref="Position"/>を更新します。
        /// </summary>
        private void ApplySizeChanged(Node node)
        {
            if (node is TransformNode t)
            {
                if (t.AnchorMode == AnchorMode.Disabled) return;

                var anchorDistance = this.Size * (t.AnchorMax - t.AnchorMin);

                t._Position = this.Size * t.AnchorMin - t.CenterPosition + t.LeftTop;
                t._Size = anchorDistance - t._LeftTop - t._RightBottom;
                t._RequireCalcTransform = true;
            }
            else
            {
                foreach (var child in node._Children.CurrentCollection)
                {
                    ApplySizeChanged(child);
                }
            }
        }

        private void UpdateMargin()
        {
            // CenterPosition の更新(Pivotを維持する)
            Pivot = _Pivot;

            // Margin の更新
            var anchorDistance = (GetAncestorSpecificNode<ISized>()?.Size ?? new Vector2F()) * (AnchorMax - AnchorMin);
            _LeftTop = Position - CenterPosition;
            _RightBottom = anchorDistance - _LeftTop - _Size;
        }

        private Matrix44F CalcScale()
        {
            switch (AnchorMode)
            {
                case AnchorMode.Fill:
                    return Matrix44F.GetScale2D(Size / ContentSize);

                case AnchorMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > ContentSize.X / ContentSize.Y)
                        scale.X = ContentSize.X * Size.Y / ContentSize.Y;
                    else
                        scale.Y = ContentSize.Y * Size.X / ContentSize.X;

                    scale /= ContentSize;

                    return Matrix44F.GetScale2D(scale);

                case AnchorMode.Disabled:
                    return Matrix44F.Identity;

                default: throw new InvalidOperationException(nameof(AnchorMode));
            }
        }

        */

        #endregion

        internal override void Registered()
        {
            UpdateTransform();
            base.Registered();
        }

        internal override void Update()
        {
            if (_RequireCalcTransform)
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

            //_TransformNodeInfo?.Update();
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

            foreach (var child in node._Children.CurrentCollection)
            {
                PropagateTransform(child, matrix);
            }
        }

        /// <summary>
        /// 変形に関する情報
        /// </summary>
        //private TransformNodeInfo _TransformNodeInfo { get; }

        //internal void DrawTransformInfo()
        //{
        //    _TransformNodeInfo?.Draw();
        //}
    }
}
