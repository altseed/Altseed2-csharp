using System;

namespace Altseed
{
    /// <summary>
    /// テクスチャを描画する<see cref="DrawnAlject"/>のクラス
    /// </summary>
    [Serializable]
    public class TextureAlject : DrawnAlject
    {
        private readonly TextureComponent textureComponent;

        /// <summary>
        /// 回転角度(度数法)を取得または設定する
        /// </summary>
        public override float Angle
        {
            get => textureComponent.Angle;
            set { textureComponent.Angle = value; }
        }

        /// <summary>
        /// 回転の中心となる座標を取得または設定する
        /// </summary>
        public Vector2F CenterPosition
        {
            get => textureComponent.CenterPosition;
            set { textureComponent.CenterPosition = value; }
        }

        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public override Vector2F Position
        {
            get => textureComponent.Position;
            set { textureComponent.Position = value; }
        }

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public override Vector2F Scale
        {
            get => textureComponent.Scale;
            set { textureComponent.Scale = value; }
        }

        /// <summary>
        /// 描画するテクスチャの領域を取得または設定する
        /// </summary>
        public RectF Src
        {
            get => textureComponent.Src;
            set { textureComponent.Src = value; }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定する
        /// </summary>
        public Texture2D Texture
        {
            get => textureComponent.Texture;
            set { textureComponent.Texture = value; }
        }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public TextureAlject()
        {
            textureComponent = new TextureComponent();
            AddComponent(textureComponent);
        }
    }
}
