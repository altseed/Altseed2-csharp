using System;

namespace Altseed
{
    [Serializable]
    internal enum SceneStatus : byte
    {
        Free,
        FadingIn,
        StartUpdating,
        Updated,
        FadingOut,
        StopUpdating,
        WaitDisposed,
        Disposed,
        UnKnown
    }
}