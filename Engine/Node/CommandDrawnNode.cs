using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// <see cref="CommandList"/>を呼び出すことで描画するノードを表します。
    /// </summary>
    [Serializable]
    public class CommandDrawnNode : Node, IDrawn
    {
        #region IDrawn
        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup;
            set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;

                if (IsRegistered)
                    Engine.UpdateDrawnCameraGroup(this, old);
            }
        }
        private ulong _CameraGroup;

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public int ZOrder {
            get => _ZOrder;
            set
            {
                if (value == _ZOrder) return;

                var old = _ZOrder;
                _ZOrder = value;

                if (IsRegistered)
                    Engine.UpdateDrawnZOrder(this, old);
            }
        }
        private int _ZOrder;

        #endregion
        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
        }

        /// <inheritdoc/>
        public override void FlushQueue()
        {
            base.FlushQueue();
            // TODO
            // this.UpdateIsDrawnActuallyOfDescendants();
        }

        #endregion

        /// <summary>
        /// 描画時に実行されます．
        /// </summary>
        /// <param name="commandList">現在の<see cref="CommandList"/></param>
        protected virtual void Draw(CommandList commandList) { }

        void IDrawn.Draw()
        {
            Draw(Engine.Graphics.CommandList);
        }
    }
}
