using System;
using System.Runtime.Serialization;

namespace Altseed.TinySystem
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : DrawnNode, IDeserializationCallback
    {
        public readonly RenderedSprite sprite;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => sprite.Src;
            set
            {
                if (sprite.Src == value) return;
                sprite.Src = value;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public Texture2D Texture
        {
            get => sprite.Texture;
            set
            {
                if (sprite.Texture == value) return;
                sprite.Texture = value;

                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
            }
        }

        // TODO: Matrial

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteNode()
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

        protected internal override void UpdateTransform()
        {
            var mat = _MatPosition * _MatAngle * _MatScale;
            // TODO: CenterPosition
            // TODO: Parent Transform

            sprite.Transform = mat;
        }

        #region Serialization

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在サポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            throw new NotImplementedException();
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);

        #endregion
    }
}
