using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public abstract class DrawnNode : Node
    {
        /// <summary>
        /// 変形行列を取得または設定します。
        /// </summary>
        protected internal virtual Matrix44F Transform
        {
            get => _Transform;
            set { _Transform = value; }
        }
        [NonSerialized]
        private Matrix44F _Transform = Matrix44F.Identity;

        internal abstract void Draw();

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
                UpdateTransform();
            }
        }
        private float _Angle = 0.0f;

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
                UpdateTransform();
            }
        }
        private Vector2F _Position = new Vector2F();

        /// <summary>
        /// 回転の中心となる座標を取得または設定します。
        /// </summary>
        public virtual Vector2F CenterPosition
        {
            get => _CenterPosition;
            set
            {
                if (_CenterPosition == value) return;
                _CenterPosition = value;
                UpdateTransform();
            }
        }
        private Vector2F _CenterPosition = new Vector2F();

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
                UpdateTransform();
            }
        }
        private Vector2F _Scale = new Vector2F(1.0f, 1.0f);

        /// <summary>
        /// 左右を反転するかどうかを取得または設定します。
        /// </summary>
        public virtual bool TurnLR
        {
            get => _TurnLR;
            set
            {
                if (value == _TurnLR) return;
                _TurnLR = value;
                UpdateTransform();
            }
        }
        private bool _TurnLR = false;

        /// <summary>
        /// 上下を反転するかどうかを取得または設定します。
        /// </summary>
        public virtual bool TurnUL
        {
            get => _TurnUL;
            set
            {
                if (value == _TurnUL) return;
                _TurnUL = value;
                UpdateTransform();
            }
        }
        private bool _TurnUL = false;

        //TODO: Color

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public virtual int ZOrder { get; set; }

        /// <summary>
        /// このノードを描画するカメラを取得または設定します。
        /// </summary>
        public uint CameraGroup
        {
            get => _CameraGroup;
            set
            {
                if (_CameraGroup == value) return;
                _CameraGroup = value;
                Engine.UpdateCameraGroup(this);
            }
        }
        private uint _CameraGroup = 0;

        protected void UpdateTransform()
        {
            var scale = Scale * new Vector2F(TurnLR ? -1 : 1, TurnUL ? -1 : 1);

            Transform = MathHelper.CalcTransform(Position, CenterPosition, MathHelper.DegreeToRadian(Angle), scale);
        }

        internal Matrix44F CalcInheritedTransform()
        {
            var mat = Transform;
            for (var n = Parent; !(n is RootNode); n = n.Parent)
            {
                if (n is DrawnNode d)
                    mat = d.Transform * mat;
            }
            return mat;
        }

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
