using System;
using System.Runtime.Serialization;

namespace Altseed
{
    public class TextNode : DrawnNode, IDeserializationCallback
    {
        private readonly RenderedText renderedText;

        /// <summary>
        /// 描画する文字列を取得または設定します。
        /// </summary>
        public string Text
        {
            get => renderedText.Text;
            set
            {
                if (renderedText.Text == value) return;
                renderedText.Text = value;
            }
        }

        /// <summary>
        /// 文字列の描画に使用するフォントを取得または設定します。
        /// </summary>
        public Font Font
        {
            get => renderedText.Font;
            set
            {
                if (renderedText.Font == value) return;
                renderedText.Font = value;
            }
        }

        public Material Material
        {
            get => renderedText.Material;
            set
            {
                if (renderedText.Material == value) return;
                renderedText.Material = value;
            }
        }

        /// <summary>
        /// 文字の太さを取得または設定します。(0 ~ 255)
        /// </summary>
        public float Weight
        {
            get => renderedText.Weight;
            set
            {
                if (renderedText.Weight == value) return;
                renderedText.Weight = value;
            }
        }

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => renderedText.Color;
            set
            {
                if (renderedText.Color == value) return;
                renderedText.Color = value;
            }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TextNode()
        {
            renderedText = RenderedText.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal override void Draw()
        {
            UpdateTransform(); // TODO:変更時のみにする（親ノードでの変更に注意）
            Engine.Renderer.DrawText(renderedText);
        }

        protected internal override void UpdateTransform()
        {
            var matAncestor = Matrix44F.Identity;
            foreach (var n in EnumerateAncestor())
            {
                if (n is DrawnNode d)
                {
                    matAncestor = d.Transform * matAncestor;
                }
            }
            var mat = _MatCenterPosition * _MatPosition * _MatAngle * _MatScale * _MatCenterPositionInv;

            renderedText.Transform = matAncestor * mat;
            Transform = mat;
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
