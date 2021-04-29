using System;
using System.Collections.Generic;
using System.Linq;

using CommandLine;

namespace Altseed2.Tools
{
    [Verb("gui")]
    [SubCommand(600, 600, CoreModules.Default | CoreModules.Tool)]
    public class GUICommand : ISubCommand
    {
        void ISubCommand.Run()
        {
            var apps = new List<(string, GUI.IGuiApp)> {
                ("font", new GUI.FontGenerator()),
                ("file", new GUI.FilePackageGenerator()),
            };

            var current = 0;

            while(Engine.DoEvents())
            {
                var app = apps[current].Item2;

                if (Engine.Tool.BeginFullScreen(0))
                {
                    if (Engine.Tool.BeginTabBar("Apps", ToolTabBarFlags.None))
                    {
                        for (int i = 0; i < apps.Count; i++)
                        {
                            if (Engine.Tool.BeginTabItem(apps[i].Item1, ToolTabItemFlags.None))
                            {
                                current = i;
                                Engine.Tool.EndTabItem();
                            }
                        }

                        Engine.Tool.EndTabBar();
                    }


                    app.DrawImGui();

                    Engine.Tool.Text(app.Msg);

                    Engine.Tool.End();
                }

                Engine.Update();
            }
        }
    }
}
