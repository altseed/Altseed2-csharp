using System;

namespace Altseed
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : DrawnNode
    {
        private readonly RenderedSprite _Sprite;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _Sprite.Src;
            set
            {
                if (_Sprite.Src == value) return;
                _Sprite.Src = value;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => _Sprite.Texture;
            set
            {
                if (_Sprite.Texture == value) return;
                _Sprite.Texture = value;

                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します
        /// </summary>
        public Material Material
        {
            get => _Sprite.Material;
            set
            {
                if (_Sprite.Material == value) return;

                _Sprite.Material = value;
                //TODO: Src
            }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteNode()
        {
            _Sprite = RenderedSprite.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal override void Draw()
        {
            UpdateTransform(); // TODO:変更時のみにする（親ノードでの変更に注意）
            Engine.Renderer.DrawSprite(_Sprite);
        }

        protected internal override void UpdateTransform()
        {
            var matAncestor = Matrix44F.Identity;
            foreach (var n in EnumerateAncestors())
            {
                if (n is DrawnNode d)
                {
                    matAncestor = d.Transform * matAncestor;
                }
            }
            var mat = _MatCenterPosition * _MatPosition * _MatAngle * _MatScale * _MatCenterPositionInv;

            _Sprite.Transform = matAncestor * mat;
            Transform = mat;
        }
    }
}
