using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public abstract class DrawnNode : Node, IDeserializationCallback
    {
        /// <summary>
        /// 変形行列を取得または設定します。
        /// </summary>
        protected internal Matrix44F Transform { get => _Transform; set { _Transform = value; } }
        [NonSerialized]
        private Matrix44F _Transform = Matrix44F.Identity;

        internal abstract void Draw();
        // NOTE: 実際はここでRendererを叩くよりも、
        //       描画対象をどこかに積み、後で
        //       まとめて描画するほうが良いかも

        /// <summary>
        /// 角度(度数法)を取得または設定します。
        /// </summary>
        public virtual float Angle
        {
            get => _Angle;
            set
            {
                if (_Angle == value) return;
                _Angle = value;
                _MatAngle = Matrix44F.GetRotationZ((float)(value * Math.PI / 180d));
                UpdateTransform();
            }
        }
        private float _Angle = 0.0f;
        /// <summary>
        /// <see cref="Angle"/>分の回転を表す行列を取得または設定します。
        /// </summary>
        [NonSerialized]
        protected internal Matrix44F _MatAngle = Matrix44F.Identity;

        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        public virtual Vector2F Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;
                _Position = value;
                _MatPosition = Matrix44F.GetTranslation2D(value);
                UpdateTransform();
            }
        }
        private Vector2F _Position = new Vector2F();
        /// <summary>
        /// <see cref="Position"/>分の平行移動を表す行列を取得または設定します。
        /// </summary>
        [NonSerialized]
        protected internal Matrix44F _MatPosition = Matrix44F.Identity;

        /// <summary>
        /// 回転の中心となる座標を取得または設定します。
        /// </summary>
        public virtual Vector2F CenterPosition
        {
            get => _CenterPosition;
            set
            {
                if (_CenterPosition == value) return;
                _MatCenterPosition = Matrix44F.GetTranslation2D(value);
                _MatCenterPositionInv = Matrix44F.GetTranslation2D(-value);

                _CenterPosition = value;
            }
        }
        private Vector2F _CenterPosition = new Vector2F();
        /// <summary>
        /// <see cref="CenterPosition"/>分の平行移動を表す行列を取得または設定します。
        /// </summary>
        [NonSerialized]
        protected internal Matrix44F _MatCenterPosition = Matrix44F.Identity;
        /// <summary>
        /// <see cref="CenterPosition"/>のマイナス分の平行移動を表す行列を取得または設定します。
        /// </summary>
        [NonSerialized]
        protected internal Matrix44F _MatCenterPositionInv = Matrix44F.Identity;

        /// <summary>
        /// 拡大率を取得または設定します。
        /// </summary>
        public virtual Vector2F Scale
        {
            get => _Scale;
            set
            {
                if (value == _Scale) return;
                _Scale = value;
                _MatScale = Matrix44F.GetScale2D(value);
                UpdateTransform();
            }
        }
        private Vector2F _Scale = new Vector2F(1.0f, 1.0f);
        /// <summary>
        /// <see cref="Scale"/>分の拡大率を表す行列を取得または設定します。
        /// </summary>
        [NonSerialized]
        protected internal Matrix44F _MatScale = Matrix44F.Identity;

        //TODO: TurnLR
        //TODO: TurnUL
        //TODO: Color

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public virtual int ZOrder { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        protected DrawnNode() : base() { }

        /// <summary>
        /// <see cref="Transform"/>を更新する
        /// </summary>
        protected internal abstract void UpdateTransform();

        #region Node

        protected internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawnNode(this);
        }

        protected internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawnNode(this);
        }

        #endregion

        #region Deserialization

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在サポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            _MatAngle = Matrix44F.GetRotationZ(_Angle);
            _MatCenterPosition = Matrix44F.GetTranslation2D(_CenterPosition);
            _MatCenterPositionInv = Matrix44F.GetTranslation2D(-_CenterPosition);
            _MatPosition = Matrix44F.GetTranslation2D(_Position);
            _MatScale = Matrix44F.GetScale2D(_Scale);
            UpdateTransform();
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);

        #endregion
    }
}
