using System;

namespace Altseed
{
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
        /// 文字の太さを取得または設定します。(0 ~ 255)
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
        internal override void Draw()
        {
            _RenderedText.Transform = CalcInheritedTransform();
            Engine.Renderer.DrawText(_RenderedText);
        }
    }
}
