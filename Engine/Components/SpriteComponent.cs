using System;
using System.ComponentModel;

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
        /// 常に0.0fを返し，設定は不可能
        /// </summary>
        /// <exception cref="NotSupportedException">設定操作は保証されていない</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float Angle
        {
            get => 0.0f;
            set => throw new NotSupportedException("その操作は保証されていません");
        }

        /// <summary>
        /// 常に既定値を返し，設定は不可能
        /// </summary>
        /// <exception cref="NotSupportedException">設定操作は保証されていない</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Vector2F Position
        {
            get => default;
            set => throw new NotSupportedException("その操作は保証されていません");
        }

        /// <summary>
        /// 常に(1.0f, 1.0f)を返し，設定は不可能
        /// </summary>
        /// <exception cref="NotSupportedException">設定操作は保証されていない</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Vector2F Scale
        {
            get => new Vector2F(1.0f, 1.0f);
            set => throw new NotSupportedException("その操作は保証されていません");
        }

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
