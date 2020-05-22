using System;

namespace Altseed
{
    /// <summary>
    /// 水平方向の配置
    /// </summary>
    [Serializable]
    public enum HorizontalAlignment
    {
        Left,
        Center,
        Right
    }

    /// <summary>
    /// 垂直方向の配置
    /// </summary>
    [Serializable]
    public enum VerticalAlignment
    {
        Top,
        Center,
        Bottom
    }

    [Serializable]
    public class TextNode : DrawnNode
    {
        private readonly RenderedText _RenderedText;

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
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => _RenderedText.Material;
            set
            {
                if (_RenderedText.Material == value) return;
                _RenderedText.Material = value;
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
        /// カーニングの有無を取得または設定します。
        /// </summary>
        public bool IsEnableKerning
        {
            get => _RenderedText.IsEnableKerning;
            set
            {
                if (_RenderedText.IsEnableKerning == value) return;
                _RenderedText.IsEnableKerning = value;
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
        /// カリング用ID
        /// </summary>
        internal override int CullingId => _RenderedText.Id;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TextNode()
        {
            _RenderedText = RenderedText.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal protected override void Draw()
        {
            Engine.Renderer.DrawText(_RenderedText);
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
