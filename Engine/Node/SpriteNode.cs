using System;

namespace Altseed
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : DrawnNode
    {
        private readonly RenderedSprite _RenderedSprite;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _RenderedSprite.Color;
            set
            {
                if (_RenderedSprite.Color == value) return;
                _RenderedSprite.Color = value;
            }
        }

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _RenderedSprite.Src;
            set
            {
                if (_RenderedSprite.Src == value) return;
                _RenderedSprite.Src = value;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => _RenderedSprite.Texture;
            set
            {
                if (_RenderedSprite.Texture == value) return;
                _RenderedSprite.Texture = value;

                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します
        /// </summary>
        public Material Material
        {
            get => _RenderedSprite.Material;
            set
            {
                if (_RenderedSprite.Material == value) return;

                _RenderedSprite.Material = value;
                //TODO: Src
            }
        }

        /// <summary>
        /// 描画モードを取得または設定します。
        /// </summary>
        public DrawMode Mode
        {
            get => _Mode;
            set
            {
                if (_Mode == value) return;

                _Mode = value;
            }
        }
        private DrawMode _Mode = DrawMode.Absolute;

        /// <summary>
        /// カリング用ID
        /// </summary>
        internal override int CullingId => _RenderedSprite.Id;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteNode()
        {
            _RenderedSprite = RenderedSprite.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal override void Draw()
        {
            Engine.Renderer.DrawSprite(_RenderedSprite);
        }

        internal override void UpdateInheritedTransform()
        {
            var mat = new Matrix44F();
            switch (Mode)
            {
                case DrawMode.Fill:
                    mat = Matrix44F.GetScale2D(Size / Src.Size);
                    break;
                case DrawMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > Src.Size.X / Src.Size.Y)
                        scale.X = Src.Size.X * Size.Y / Src.Size.Y;
                    else
                        scale.Y = Src.Size.Y * Size.X / Src.Size.X;

                    scale /= Src.Size;

                    mat = Matrix44F.GetScale2D(scale);
                    break;
                case DrawMode.Absolute:
                    mat = Matrix44F.Identity;
                    break;
                default:
                    break;
            }

            _RenderedSprite.Transform = CalcInheritedTransform() * mat;
        }

        public override void AdjustSize()
        {
            Size = Src.Size;
        }
    }
}
