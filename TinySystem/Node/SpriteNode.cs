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
        public readonly RenderedSprite _Sprite;

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
        public Texture2D Texture
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
            var matAncestor = Matrix44F.GetIdentity();
            foreach (var n in EnumerateAncestor())
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
