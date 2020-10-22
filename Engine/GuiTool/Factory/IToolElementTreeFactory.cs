using System.Collections.Generic;
using Altseed2.GuiTool.Repository;

namespace Altseed2.GuiTool.Factory
{
    public interface IToolElementTreeFactory
    {
        GuiInfoRepository GuiInfoRepository { get; }
        IEnumerable<ToolElement> CreateToolElements(object source);
    }
}
