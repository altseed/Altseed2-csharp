using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public partial class StaticFile
    {
        public byte[] Buffer
        {
            get { return GetBuffer().ToArray(); }
        }
    }

    public partial class StreamFile
    {
        public byte[] TempBuffer
        {
            get { return GetTempBuffer().ToArray(); }
        }
    }
}
