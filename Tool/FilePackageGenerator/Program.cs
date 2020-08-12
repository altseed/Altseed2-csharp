using System;

namespace Altseed2.Tool.FilePackageGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("File Package Generator", 400, 600, new Configuration() { ToolEnabled = true, IsResizable = false });

            string input = "";
            string password = "";
            string msg = "";
            while (Engine.DoEvents())
            {
                if (Engine.Tool.BeginFullScreen(0))
                {
                    var tmp = Engine.Tool.InputText("Input Directory", input, 2048, ToolInputTextFlags.None);
                    if (tmp != null) input = tmp;

                    if (Engine.Tool.SmallButton("Open Directory"))
                        input = Engine.Tool.PickFolder("");

                    tmp = Engine.Tool.InputText("Input Password", password, 128, ToolInputTextFlags.None);
                    if (tmp != null) password = tmp;

                    if (Engine.Tool.Button("Pack", new Vector2F()))
                    {
                        if (!System.IO.Directory.Exists(input))
                        {
                            msg = "Not Exists Input Directory.";
                            goto fail;
                        }

                        var output = Engine.Tool.SaveDialog("pack", "");

                        if (output != "")
                        {
                            if (!output.EndsWith(".pack")) output += ".pack";

                            bool res = false;
                            if (password == "")
                                res = Engine.File.Pack(input, output);
                            else
                                res = Engine.File.PackWithPassword(input, output, password);

                            if (res)
                                msg = "Success!";
                            else
                                msg = "Fail to Generate A2F File";
                        }
                    }

                    fail:
                    Engine.Tool.Text(msg);
                    Engine.Tool.End();
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
