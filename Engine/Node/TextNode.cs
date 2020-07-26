using System;

namespace Altseed2
{
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

        /// <summary>
        /// 手動
        /// </summary>
        Manual,
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

        /// <summary>
        /// 手動
        /// </summary>
        Manual,
    }

    /// <summary>
    /// テキストを描画するノードのクラス
    /// </summary>
    [Serializable]
    public class TextNode : TransformNode, ICullableDrawn
    {
        private readonly RenderedText _RenderedText;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TextNode()
        {
            _RenderedText = RenderedText.Create();
        }

        #region IDrawn

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawText(_RenderedText);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedText.Id;

        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup; set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;
                Engine.UpdateDrawnCameraGroup(this, old);
            }
        }
        private ulong _CameraGroup;

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public int ZOrder
        {
            get => _ZOrder;
            set
            {
                if (value == _ZOrder) return;

                var old = _ZOrder;
                _ZOrder = value;

                Engine.UpdateDrawnZOrder(this, old);
            }
        }
        private int _ZOrder;

        /// <summary>
        /// このノードを描画するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn
        {
            get => _IsDrawn;
            set
            {
                if (_IsDrawn == value) return;
                _IsDrawn = value;
                this.UpdateIsDrawnActuallyOfDescendants();

            }
        }
        private bool _IsDrawn = true;

        /// <summary>
        /// 先祖の<see cref="IsDrawn">を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
        }

        internal override Matrix44F AbsoluteTransform
        {
            get => _RenderedText.Transform;
            set
            {
                if (_RenderedText.Transform == value) return;
                _RenderedText.Transform = value;
            }
        }

        #endregion

        #region RenderedText

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _RenderedText.Color;
            set
            {
                if (_RenderedText.Color == value) return;
                _RenderedText.Color = value;
            }
        }

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlendMode BlendMode
        {
            get => _RenderedText.BlendMode;
            set
            {
                if (_RenderedText.BlendMode == value) return;
                _RenderedText.BlendMode = value;
            }
        }

        /// <summary>
        /// 描画する文字列を取得または設定します。
        /// </summary>
        public string Text
        {
            get => _RenderedText.Text;
            set
            {
                if (_RenderedText.Text == value) return;

                _RenderedText.Text = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 文字列の描画に使用するフォントを取得または設定します。
        /// </summary>
        public Font Font
        {
            get => _RenderedText.Font;
            set
            {
                if (_RenderedText.Font == value) return;

                _RenderedText.Font = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 文字の描画に使用するマテリアルを取得または設定します。
        /// </summary>
        public Material MaterialGlyph
        {
            get => _RenderedText.MaterialGlyph;
            set
            {
                if (_RenderedText.MaterialGlyph == value) return;
                _RenderedText.MaterialGlyph = value;
            }
        }

        /// <summary>
        /// 文字テクスチャの描画に使用するマテリアルを取得または設定します。
        /// </summary>
        public Material MaterialImage
        {
            get => _RenderedText.MaterialImage;
            set
            {
                if (_RenderedText.MaterialImage == value) return;
                _RenderedText.MaterialImage = value;
            }
        }

        /// <summary>
        /// 文字の太さを取得または設定します。
        /// </summary>
        public float Weight
        {
            get => _RenderedText.Weight;
            set
            {
                if (_RenderedText.Weight == value) return;

                _RenderedText.Weight = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 字間をピクセル単位で取得または設定します。
        /// </summary>
        public float CharacterSpace
        {
            get => _RenderedText.CharacterSpace;
            set
            {
                if (_RenderedText.CharacterSpace == value) return;

                _RenderedText.CharacterSpace = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 行間をピクセル単位で取得または設定します。
        /// Nullを指定するとフォント標準の行間を使用します。
        /// </summary>
        public float? LineGap
        {
            get => _LineGap;
            set
            {
                if (_LineGap == value) return;

                var gap = value ?? Font?.LineGap ?? 0;
                _LineGap = gap;
                _RenderedText.LineGap = gap;
                _RequireCalcTransform = true;
            }
        }
        private float? _LineGap = null;

        /// <summary>
        /// カーニングの有無を取得または設定します。
        /// </summary>
        public bool IsEnableKerning
        {
            get => _RenderedText.IsEnableKerning;
            set
            {
                if (_RenderedText.IsEnableKerning == value) return;

                _RenderedText.IsEnableKerning = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 行の方向を取得または設定します。
        /// </summary>
        public WritingDirection WritingDirection
        {
            get => _RenderedText.WritingDirection;
            set
            {
                if (_RenderedText.WritingDirection == value) return;

                _RenderedText.WritingDirection = value;
                _RequireCalcTransform = true;
            }
        }

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
                _RequireCalcTransform = true;
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
                _RequireCalcTransform = true;
            }
        }
        private VerticalAlignment _VerticalAlignment = VerticalAlignment.Top;

        #endregion

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public override Vector2F ContentSize => _RenderedText.TextureSize;

        internal void CalcCenterPosition()
        {
            var centerPosition = CenterPosition;
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    centerPosition.X = 0;
                    break;
                case HorizontalAlignment.Center:
                    centerPosition.X = (Size.X - _RenderedText.TextureSize.X) / 2f;
                    break;
                case HorizontalAlignment.Right:
                    centerPosition.X = Size.X - _RenderedText.TextureSize.X;
                    break;
                default:
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    centerPosition.Y = 0;
                    break;
                case VerticalAlignment.Center:
                    centerPosition.Y = (Size.Y - _RenderedText.TextureSize.Y) / 2f;
                    break;
                case VerticalAlignment.Bottom:
                    centerPosition.Y = Size.Y - _RenderedText.TextureSize.Y;
                    break;
                default:
                    break;
            }
        }

        private protected override void CalcTransform()
        {
            CalcCenterPosition();
            base.CalcTransform();
        }
    }
}
