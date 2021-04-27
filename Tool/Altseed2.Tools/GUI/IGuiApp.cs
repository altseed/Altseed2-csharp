using System;

namespace Altseed2.Tools.GUI
{
    interface IGuiApp
    {
        void DrawImGui();
        string Msg { get; }
    }
}
