using System;
using System.Runtime.Serialization;

namespace Altseed.TinySystem
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class TextureNode : DrawnNode, IDeserializationCallback
    {
        public readonly RenderedSprite sprite;

        /// <summary>
        /// 回転角度(度数法)を取得または設定する
        /// </summary>
        public float Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                M_angle.SetRotationZ((float)(value * Math.PI / 180d));
                UpdateTransport();
            }
        }
        [NonSerialized]
        private float _angle;
        [NonSerialized]
        private Matrix44F M_angle = Matrix44F.GetIdentity();

        /*/// <summary>
        /// <see cref="Transform"/>に使用される座標の値を取得または設定する
        /// </summary>
        internal Vector2F AbsolutePosition { get => _absolutePosition; set => _absolutePosition = value; }
        [NonSerialized]
        private Vector2F _absolutePosition;*/

        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public Vector2F Position
        {
            get => _position;
            set
            {
                _position = value;
                M_position.SetTranslation(value.X, value.Y, 0.0f);
                UpdateTransport();
            }
        }
        [NonSerialized]
        private Vector2F _position;
        [NonSerialized]
        private Matrix44F M_position = Matrix44F.GetIdentity();

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public Vector2F Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                M_scale.SetScale(value.X, value.Y, 1.0f);
                UpdateTransport();
            }
        }
        [NonSerialized]
        private Vector2F _scale = new Vector2F(1.0f, 1.0f);
        [NonSerialized]
        private Matrix44F M_scale = Matrix44F.GetIdentity();

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => sprite.Src;
            set
            {
                sprite.Src = value;
                _src = value;
            }
        }
        [NonSerialized]
        private RectF? _src;

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public Texture2D Texture
        {
            get => sprite.Texture;
            set
            {
                sprite.Texture = value;
                if (value == null) _src = null;
                else if (_src == null) Src = new RectF(0, 0, Texture.Size.X, Texture.Size.Y);
            }
        }

        /// <summary>
        /// 変換行列を取得または設定します。
        /// </summary>
        internal Matrix44F Transform
        {
            get => sprite.Transform;
            set { sprite.Transform = value; }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TextureNode()
        {
            sprite = RenderedSprite.Create();
            var transform = new Matrix44F();
            transform.SetIdentity();
            Transform = transform;
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal override void Draw()
        {
            Engine.Renderer.DrawSprite(sprite);
        }

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在サポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            var values = Transform.Values;
            if (Texture != null) _src = sprite.Src;
            _angle = (float)(Math.Acos(values[0, 0]) * 180 / Math.PI);
            _position = new Vector2F(values[0, 3], values[1, 3]);
            _scale = new Vector2F(values[0, 0], values[1, 1]);
            M_position.SetTranslation(_position.X, _position.Y, 0.0f);
            M_angle.SetRotationZ(_angle);
            M_scale.SetScale(_scale.X, _scale.Y, 1.0f);
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
        private void UpdateTransport()
        {
            Transform = Matrix44F.GetIdentity() * M_position * M_angle * M_scale;
        }
    }
}
