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
        Right
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
        Bottom
    }

    /// <summary>
    /// テキストを描画するノードのクラス
    /// </summary>
    [Serializable]
    public class TextNode : TransformNode, ICullableDrawn
    {
        private readonly RenderedText _RenderedText;

        #region IDrawn

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawText(_RenderedText);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedText.Id;

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
        /// この先祖の<see cref="IsDrawn">を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>

        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion

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

        public override Matrix44F AbsoluteTransform => _RenderedText.Transform;

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

                if (IsAutoAdjustSize) AdjustSize();
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

                if (IsAutoAdjustSize) AdjustSize();
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

                if (IsAutoAdjustSize) AdjustSize();
            }
        }

        /// <summary>
        /// 行間をピクセル単位で取得または設定します。
        /// Nullの時、フォント標準の行間を指定します。
        /// </summary>
        public float? LineGap
        {
            get => _LineGap;
            set
            {
                if (_LineGap == value) return;
                _LineGap = value;
                _RenderedText.LineGap = value ?? Font?.LineGap ?? 0;

                if (IsAutoAdjustSize) AdjustSize();
            }
        }
        private float? _LineGap = null;

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
        /// カーニングの有無を取得または設定します。
        /// </summary>
        public bool IsEnableKerning
        {
            get => _RenderedText.IsEnableKerning;
            set
            {
                if (_RenderedText.IsEnableKerning == value) return;
                _RenderedText.IsEnableKerning = value;

                if (IsAutoAdjustSize) AdjustSize();
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

                if (IsAutoAdjustSize) AdjustSize();
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
                if (value == _HorizontalAlignment)
                    return;

                _HorizontalAlignment = value;
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
            }
        }
        private VerticalAlignment _VerticalAlignment = VerticalAlignment.Top;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TextNode()
        {
            _RenderedText = RenderedText.Create();
        }

        internal override void UpdateInheritedTransform()
        {
            var mat = Matrix44F.Identity;
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    mat *= Matrix44F.GetTranslation2D(new Vector2F((Size.X - _RenderedText.TextureSize.X) / 2, 0));
                    break;
                case HorizontalAlignment.Right:
                    mat *= Matrix44F.GetTranslation2D(new Vector2F(Size.X - _RenderedText.TextureSize.X, 0));
                    break;
                default:
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    break;
                case VerticalAlignment.Center:
                    mat *= Matrix44F.GetTranslation2D(new Vector2F(0, (Size.Y - _RenderedText.TextureSize.Y) / 2));
                    break;
                case VerticalAlignment.Bottom:
                    mat *= Matrix44F.GetTranslation2D(new Vector2F(0, Size.Y - _RenderedText.TextureSize.Y));
                    break;
                default:
                    break;
            }

            _RenderedText.Transform = CalcInheritedTransform() * mat;
        }

        public override void AdjustSize()
        {
            Size = _RenderedText.TextureSize;
        }
    }
}
