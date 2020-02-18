using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// テクスチャを描画するコンポーネント
    /// </summary>
    [Serializable]
    public sealed class TextureComponent : AljectComponent, IDrawComponent
    {
        private readonly RenderedSprite sprite;
        /// <summary>
        /// 描画範囲を取得または設定する
        /// </summary>
        public RectF Src { get => sprite.Src; set => sprite.Src = value; }
        /// <summary>
        /// 描画するテクスチャを取得または設定する
        /// </summary>
        public Texture2D Texture { get => sprite.Texture; set => sprite.Texture = value; }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public TextureComponent()
        {
            sprite = RenderedSprite.Create();
        }
        /// <summary>
        /// 描画を実行する
        /// </summary>
        public void Draw()
        {
            Engine.Renderer.DrawSprite(sprite);
        }
        Component IDrawComponent.AsComponent() => this;
    }
}
