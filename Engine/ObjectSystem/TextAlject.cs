using System;

namespace Altseed
{
    /// <summary>
    /// テキストを描画する<see cref="DrawnAlject"/>のクラス
    /// </summary>
    [Serializable]
    public class TextAlject : DrawnAlject
    {
        private readonly TextComponent textComponent;

        /// <summary>
        /// 角度を取得または設定する
        /// </summary>
        public override float Angle
        {
            get => textComponent.Angle; 
            set { textComponent.Angle = value; }
        }

        /// <summary>
        /// 描画するフォントを取得または設定する
        /// </summary>
        public Font Font
        {
            get => textComponent.Font;
            set { textComponent.Font = value; }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定する
        /// </summary>
        public Material Material
        {
            get => textComponent.Material;
            set { textComponent.Material = value; }
        }

        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public override Vector2F Position
        {
            get => textComponent.Position;
            set { textComponent.Position = value; }
        }

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public override Vector2F Scale
        {
            get => textComponent.Scale;
            set { textComponent.Scale = value; }
        }

        /// <summary>
        /// テキストを取得または設定する
        /// </summary>
        public string Text
        {
            get => textComponent.Text;
            set { textComponent.Text = value; }
        }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public TextAlject()
        {
            textComponent = new TextComponent();
            AddComponent(textComponent);
        }
    }
}
