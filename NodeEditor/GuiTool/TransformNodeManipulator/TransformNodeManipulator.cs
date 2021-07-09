using System;

namespace Altseed2
{
    [Serializable]
    abstract class TransformNodeManipulator
    {
        protected TransformNode _TransformNode;

        internal TransformNodeManipulator(TransformNode transformNode)
        {
            _TransformNode = transformNode;
        }

        internal abstract void Update();

        internal abstract void Draw();
    }
}