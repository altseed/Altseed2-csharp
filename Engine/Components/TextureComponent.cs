using System;
using System.Runtime.Serialization;

namespace Altseed
{
    /// <summary>
    /// テクスチャの描画を扱うコンポーネント
    /// </summary>
    [Serializable]
    public class TextureComponent : DrawnComponent, IDeserializationCallback
    {
        public readonly RenderedSprite sprite;

        /// <summary>
        /// <see cref="Transform"/>に使用される座標の値を取得または設定する
        /// </summary>
        internal Vector2F AbsolutePosition
        {
            get => _absolutePosition;
            set
            {
                _absolutePosition = value;
                M_absolutePosition.SetTranslation(value.X, value.Y, 0.0f);
                UpdateTransport();
            }
        }
        [NonSerialized]
        private Vector2F _absolutePosition;
        [NonSerialized]
        private Matrix44F M_absolutePosition = Matrix44F.GetIdentity();

        /// <summary>
        /// 回転角度(度数法)を取得または設定する
        /// </summary>
        public override float Angle
        {
            get => _angle;
            set
            {
                if (_angle != value)
                {
                    _angle = value;
                    M_angle.SetRotationZ((float)(value * Math.PI / 180d));
                    UpdateTransport();
                }
            }
        }
        private float _angle;
        [NonSerialized]
        private Matrix44F M_angle = Matrix44F.GetIdentity();

        /// <summary>
        /// 回転の中心となる座標を取得または設定する
        /// </summary>
        public Vector2F CenterPosition
        {
            get => _centerPosition;
            set
            {
                if (_centerPosition != value)
                {
                    _centerPosition = value;
                    M_centerPosition.SetTranslation(-value.X, -value.Y, 0.0f);
                    AbsolutePosition = _position + _centerPosition;
                }
            }
        }
        private Vector2F _centerPosition;
        [NonSerialized]
        private Matrix44F M_centerPosition = Matrix44F.GetIdentity();

        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public override Vector2F Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    AbsolutePosition = _position + _centerPosition;
                }
            }
        }
        private Vector2F _position;

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public override Vector2F Scale
        {
            get => _scale;
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    M_scale.SetScale(value.X, value.Y, 1.0f);
                    UpdateTransport();
                }
            }
        }
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
                if (_src != value)
                {
                    sprite.Src = value;
                    _src = value;
                }
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
                if (value != sprite.Texture)
                {
                    sprite.Texture = value;
                    if (value == null) _src = null;
                    else if (_src == null) Src = new RectF(0, 0, Texture.Size.X, Texture.Size.Y);
                }
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
        public TextureComponent()
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
            if (Texture != null) _src = sprite.Src;
            _absolutePosition = _position + _centerPosition;
            M_absolutePosition.SetTranslation(_absolutePosition.X, _absolutePosition.Y, 0.0f);
            M_angle.SetRotationZ(_angle);
            M_centerPosition.SetTranslation(_centerPosition.X, _centerPosition.Y, 0.0f);
            M_scale.SetScale(_scale.X, _scale.Y, 1.0f);
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
        private void UpdateTransport() => Transform = M_absolutePosition * M_angle * M_scale * M_centerPosition;
    }
}
