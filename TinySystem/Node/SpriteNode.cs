using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed.TinySystem
{
    /// <summary>
    /// スプライトを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : DrawnNode
    {
        public readonly RenderedSprite _Sprite;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _Sprite.Src;
            set { _Sprite.Src = value; }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public Texture2D Texture
        {
            get => _Sprite.Texture;
            set { _Sprite.Texture = value; }
        }

        /// <summary>
        /// 変換行列を取得または設定します。
        /// </summary>
        public Matrix44F Transform
        {
            get => _Sprite.Transform;
            set { _Sprite.Transform = value; }
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
            Engine.Renderer.DrawSprite(_Sprite);
        }
    }
}
