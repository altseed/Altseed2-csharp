using System;
namespace Altseed2.Tools.GUI
{
    public class FilePackageGenerator : IGuiApp
    {
        string input = "";
        string password = "";
        string msg = "";

        public FilePackageGenerator() { }

        string IGuiApp.Msg => msg;

        void IGuiApp.DrawImGui()
        {
            var tmp = Engine.Tool.InputText("Input Directory", input, 2048, ToolInputTextFlags.None);
            if (tmp != null)
            {
                input = tmp;
            }

            if (Engine.Tool.SmallButton("Open Directory"))
            {
                input = Engine.Tool.PickFolder("") ?? "";
            }

            tmp = Engine.Tool.InputText("Input Password", password, 128, ToolInputTextFlags.None);
            if (tmp != null)
            {
                password = tmp;
            }

            if (Engine.Tool.Button("Pack", new Vector2F()))
            {
                if (!System.IO.Directory.Exists(input))
                {
                    msg = "Not Exists Input Directory.";
                    return;
                }

                var output = Engine.Tool.SaveDialog("pack", "");

                if (output != "")
                {
                    if (!output.EndsWith(".pack"))
                    {
                        output += ".pack";
                    }

                    bool res;
                    if (password == "")
                    {
                        res = Engine.File.Pack(input, output);
                    }
                    else
                    {
                        res = Engine.File.PackWithPassword(input, output, password);
                    }

                    msg = res ? "Success!" : "Fail to Generate A2F File";
                }
            }
        }
    }
}
