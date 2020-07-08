using System;

namespace Altseed2
{
    /// <summary>
    /// 描画方法
    /// </summary>
    [Serializable]
    public enum DrawMode
    {
        Fill,
        KeepAspect,
        Absolute,
    }

    /// <summary>
    /// 変形行列を備えたノードのクラス
    /// </summary>
    [Serializable]
    public abstract class TransformNode : Node
    {
        /// <summary>
        /// 変形行列を取得または設定します。
        /// </summary>
        internal virtual Matrix44F Transform
        {
            get => _Transform;
            set { _Transform = value; }
        }
        [NonSerialized]
        private Matrix44F _Transform = Matrix44F.Identity;

        /// <summary>
        /// 基準となる変形行列を取得します。
        /// </summary>
        public virtual Matrix44F AbsoluteTransform { get; }

        /// <summary>
        /// 角度(度数法)を取得または設定します。
        /// </summary>
        public virtual float Angle
        {
            get => _Angle;
            set
            {
                if (_Angle == value) return;
                _Angle = value;
                UpdateTransform();
            }
        }
        private float _Angle = 0.0f;

        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        public virtual Vector2F Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;
                _Position = value;
                UpdateTransform();
                SetAnchorMargin();
            }
        }
        private Vector2F _Position = new Vector2F();

        /// <summary>
        /// 回転の中心となる座標を[0,1]で取得または設定します。
        /// </summary>
        public virtual Vector2F Pivot
        {
            get => _Pivot;
            set
            {
                if (_Pivot == value) return;
                _Pivot = value;
                UpdateTransform();
                SetAnchorMargin();
            }
        }
        private Vector2F _Pivot = new Vector2F();

        /// <summary>
        /// 回転の中心となる座標をピクセル単位で取得または設定します。
        /// </summary>
        public virtual Vector2F CenterPosition
        {
            get => Pivot * Size;
            set
            {
                if (Size.X == 0 || Size.Y == 0)
                    return;
                Pivot = value / Size;
            }
        }

        /// <summary>
        /// 拡大率を取得または設定します。
        /// </summary>
        public virtual Vector2F Scale
        {
            get => _Scale;
            set
            {
                if (value == _Scale) return;
                _Scale = value;
                UpdateTransform();
            }
        }
        private Vector2F _Scale = new Vector2F(1.0f, 1.0f);

        /// <summary>
        /// コンテンツのサイズを取得または設定します。
        /// </summary>
        public virtual Vector2F Size
        {
            get => _Size;
            set
            {
                if (value == _Size) return;
                _Size = value;

                SetAnchorMargin();
                UpdateTransform();
                foreach (var descendant in EnumerateDescendants<DrawnNode>())
                {
                    descendant.UpdateSize();
                    descendant.UpdatePosition();
                    descendant.UpdateTransform();
                }
            }
        }
        private Vector2F _Size = new Vector2F(0f, 0f);

        private Vector2F _LeftTop = new Vector2F(0f, 0f);
        private Vector2F _RightBottom = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        public virtual Vector2F AnchorMin
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

                UpdateTransform();
                SetAnchorMargin();
            }
        }
        private Vector2F _AnchorMin = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカーを取得または設定します。
        /// </summary>
        public virtual Vector2F AnchorMax
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

                UpdateTransform();
                SetAnchorMargin();
            }
        }
        private Vector2F _AnchorMax = new Vector2F(0f, 0f);

        /// <summary>
        /// 左右を反転するかどうかを取得または設定します。
        /// </summary>
        public virtual bool HorizontalFlip
        {
            get => _HorizontalFlip;
            set
            {
                if (value == _HorizontalFlip) return;
                _HorizontalFlip = value;
                UpdateTransform();
            }
        }
        private bool _HorizontalFlip = false;

        /// <summary>
        /// 上下を反転するかどうかを取得または設定します。
        /// </summary>
        public virtual bool VerticalFlip
        {
            get => _VerticalFlip;
            set
            {
                if (value == _VerticalFlip) return;
                _VerticalFlip = value;
                UpdateTransform();
            }
        }
        private bool _VerticalFlip = false;

        /// <summary>
        /// <see cref="Transform"/>を更新する
        /// </summary>
        protected void UpdateTransform()
        {
            var scale = Scale * new Vector2F(HorizontalFlip ? -1 : 1, VerticalFlip ? -1 : 1);
            var position = Position +
                AnchorMin * (GetAncestorSpecificNode<TransformNode>()?.Size ?? new Vector2F());

            Transform = MathHelper.CalcTransform(position, Pivot * Size, MathHelper.DegreeToRadian(Angle), scale);
        }

        /// <summary>
        /// <see cref="Size"/>をコンテンツの大きさに合わせる
        /// </summary>
        public virtual void AdjustSize()
        {
            Size = default;
        }

        internal abstract void UpdateInheritedTransform();

        internal Matrix44F CalcInheritedTransform()
        {
            var mat = Transform;
            for (var n = Parent; !(n is RootNode); n = n.Parent)
            {
                if (n is TransformNode t)
                    mat = t.Transform * mat;
            }
            return mat;
        }

        private void SetAnchorMargin()
        {
            _RightBottom = GetAnchorDistance() - (Position + (new Vector2F(1, 1) - Pivot) * Size);
            _LeftTop = Size * Pivot - Position;
        }

        private void UpdatePosition()
        {
            _Position = Size * Pivot - _LeftTop;
        }

        private void UpdateSize()
        {
            var old = Size;
            _Size = GetAnchorDistance() + _LeftTop - _RightBottom;
            if (AnchorMax.X == AnchorMin.X)
                _Size.X = old.X;
            if (AnchorMax.Y == AnchorMin.Y)
                _Size.Y = old.Y;
        }

        private Vector2F GetAnchorDistance()
        {
            return (GetAncestorSpecificNode<TransformNode>()?.Size ?? new Vector2F()) * (AnchorMax - AnchorMin);
        }

        #region Node

        internal override void Added(Node owner)
        {
            base.Added(owner);

            SetAnchorMargin();
            UpdateTransform();
        }

        #endregion
    }
}
