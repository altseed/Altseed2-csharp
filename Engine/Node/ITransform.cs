using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    internal interface IFixedTransform
    {
        internal Matrix44F Transform { get; }
    }

    internal interface ITransform
    {
        internal Matrix44F Transform { get; set; }
    }
}
