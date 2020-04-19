using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public partial class Tool
    {
        public bool BeginFullScreen(int offset)
        {
            var pos = new Vector2F(0, offset);
            var size = Engine.Window.Size - pos;
            SetNextWindowSize(size, ToolCond.None);
            SetNextWindowPos(pos, ToolCond.None);

            var flags = ToolWindow.NoMove | ToolWindow.NoBringToFrontOnFocus
                | ToolWindow.NoResize | ToolWindow.NoScrollbar
                | ToolWindow.NoScrollbar | ToolWindow.NoTitleBar;

            //const float oldWindowRounding = ImGui::GetStyle().WindowRounding; ImGui::GetStyle().WindowRounding = 0;
            var visible = Begin(" ", flags);
            // ImGui::GetStyle().WindowRounding = oldWindowRounding;
            return visible;
        }
    }
}
