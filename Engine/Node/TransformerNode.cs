using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 親ノードの座標変形を制御するノード
    /// </summary>
    [Serializable]
    public class TransformerNode : Node
    {
        /// <summary>
        /// 親ノードにおける変形行列を取得します。
        /// </summary>
        public virtual Matrix44F Transform { get; } = Matrix44F.Identity;

        /// <summary>
        /// 親ノードにおける先祖の変形を加味した変形行列を設定します。
        /// </summary>
        public virtual Matrix44F InheritedTransform { get; set; } = Matrix44F.Identity;

        /// <summary>
        /// 親ノードにおける先祖の変形および<see cref="Rendered"/>への変形を加味した最終的な変形行列を取得します。
        /// </summary>
        public virtual Matrix44F AbsoluteTransform { get; set; } = Matrix44F.Identity;

        /// <summary>
        /// Transformを再度計算するか
        /// </summary>
        protected internal virtual bool RequireCalcTransform { get; set; } = true;

        internal override void Added(Node owner)
        {
            if (owner is TransformNode transformNode)
            {
                transformNode.Transfomer = this;
            }

            base.Added(owner);
        }
    }
}
