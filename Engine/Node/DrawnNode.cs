using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    [Serializable]
    public abstract class DrawnNode : Node
    {
        protected internal Matrix44F Transform { get; set; } = Matrix44F.GetIdentity();

        internal abstract void Draw();
        // NOTE: 実際はここでRendererを叩くよりも、
        //       描画対象をどこかに積み、後で
        //       まとめて描画するほうが良いかも

        /// <summary>
        /// 角度を取得または設定する
        /// </summary>
        public virtual float Angle
        {
            get => _Angle;
            set
            {
                if (_Angle == value) return;
                _Angle = value;
                _MatAngle.SetRotationZ((float)(value * Math.PI / 180d));
                UpdateTransform();
            }
        }
        [NonSerialized]
        private float _Angle = 0.0f;
        [NonSerialized]
        protected internal Matrix44F _MatAngle = Matrix44F.GetIdentity();

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
                _MatPosition.SetTranslation(value.X, value.Y, 0.0f);
                UpdateTransform();
            }
        }
        [NonSerialized]
        private Vector2F _Position = new Vector2F();
        [NonSerialized]
        protected internal Matrix44F _MatPosition = Matrix44F.GetIdentity();

        /// <summary>
        /// 回転の中心となる座標を取得または設定する
        /// </summary>
        public virtual Vector2F CenterPosition
        {
            get => _CenterPosition;
            set
            {
                if (_CenterPosition == value) return;
                _MatCenterPosition.SetTranslation(value.X, value.Y, 0.0f);
                _MatCenterPositionInv.SetTranslation(-value.X, -value.Y, 0.0f);

                _CenterPosition = value;
            }
        }
        [NonSerialized]
        private Vector2F _CenterPosition = new Vector2F();
        [NonSerialized]
        protected internal Matrix44F _MatCenterPosition = Matrix44F.GetIdentity();
        protected internal Matrix44F _MatCenterPositionInv = Matrix44F.GetIdentity();

        /// <summary>
        /// 拡大率を取得または設定する
        /// </summary>
        public virtual Vector2F Scale
        {
            get => _scale;
            set
            {
                if (value == _scale) return;
                _scale = value;
                _MatScale.SetScale(value.X, value.Y, 1.0f);
                UpdateTransform();
            }
        }
        [NonSerialized]
        private Vector2F _scale = new Vector2F(1.0f, 1.0f);
        [NonSerialized]
        protected internal Matrix44F _MatScale = Matrix44F.GetIdentity();

        //TODO: TurnLR
        //TODO: TurnUL
        //TODO: Color

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public virtual int ZOrder { get; set; }

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
    }
}
