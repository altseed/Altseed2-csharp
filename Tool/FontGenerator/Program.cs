using System;

namespace Altseed2.Tool.FontGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("Font Generator", 400, 600, new Configuration() { EnabledCoreModules = CoreModules.Default | CoreModules.Tool, IsResizable = false });

            string input = "";
            int samplingSize = 64;
            string charactersTextFilePath = "";
            string msg = "";
            while (Engine.DoEvents())
            {
                if (Engine.Tool.BeginFullScreen(0))
                {
                    var tmp = Engine.Tool.InputText("Input Font File", input, 2048, ToolInputTextFlags.None);
                    if (tmp != null) input = tmp;

                    if (Engine.Tool.SmallButton("Open Font File"))
                        input = Engine.Tool.OpenDialog("ttf,otf", "");

                    Engine.Tool.SliderInt("Sampling Size", ref samplingSize, 1, 1024, "%d", ToolSliderFlags.None);

                    tmp = Engine.Tool.InputText("Characters Text File", charactersTextFilePath, 2048, ToolInputTextFlags.None);
                    if (tmp != null) charactersTextFilePath = tmp;

                    if (Engine.Tool.SmallButton("Open Characters Text File"))
                        charactersTextFilePath = Engine.Tool.OpenDialog("txt", "");

                    if (Engine.Tool.Button("Save A2F File", new Vector2F()))
                    {
                        if (!System.IO.File.Exists(input))
                        {
                            msg = "Not Exists Font File.";
                            goto fail;
                        }

                        if (!System.IO.File.Exists(charactersTextFilePath))
                        {
                            msg = "Not Exists Characters Text File.";
                            goto fail;
                        }

                        var output = Engine.Tool.SaveDialog("a2f", "");

                        if (output != "")
                        {
                            if (!output.EndsWith(".a2f")) output += ".a2f";

                            var characters = System.IO.File.ReadAllText(charactersTextFilePath);
                            var res = Font.GenerateFontFile(input, output, characters, samplingSize);

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
