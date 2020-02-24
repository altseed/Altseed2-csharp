using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// スプライトを描画するコンポーネントを表します。
    /// </summary>
    [Serializable]
    public sealed class SpriteComponent : DrawnComponent
    {
        public readonly RenderedSprite sprite;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => sprite.Src;
            set { sprite.Src = value; }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public Texture2D Texture
        {
            get => sprite.Texture;
            set { sprite.Texture = value; }
        }

        /// <summary>
        /// 変換行列を取得または設定します。
        /// </summary>
        public Matrix44F Transform
        {
            get => sprite.Transform;
            set { sprite.Transform = value; }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteComponent()
        {
            sprite = RenderedSprite.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal override void Draw()
        {
            Engine.Renderer.DrawSprite(sprite);
        }
    }
}
