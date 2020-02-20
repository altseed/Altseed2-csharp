using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    [Serializable]
    internal enum SceneStatus : int
    {
        Free,
        FadingIn,
        StartUpdating,
        Updated,
        FadingOut,
        StopUpdating,
        Disposed,
        WaitDisposed
    }
}