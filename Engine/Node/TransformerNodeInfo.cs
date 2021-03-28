using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    [Serializable]
    public abstract class TransformerNodeInfo
    {
        protected TransformerNode _TransformerNode;

        public TransformerNodeInfo(TransformerNode transformerNode)
        {
            _TransformerNode = transformerNode;
        }

        internal protected virtual void Update()
        {

        }

        internal protected virtual void Draw()
        {

        }
    }
}
