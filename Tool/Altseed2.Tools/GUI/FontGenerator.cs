using System;
namespace Altseed2.Tools.GUI
{
    public class FontGenerator : IGuiApp
    {
        string input = "";
        int samplingSize = Font.DefaultSamplingSize;
        string charactersTextFilePath = "";
        string msg = "";

        public FontGenerator() { }

        string IGuiApp.Msg => msg;

        void IGuiApp.DrawImGui()
        {
            var tmp = Engine.Tool.InputText("Input Font File", input, 2048, ToolInputTextFlags.None);
            if (tmp != null) input = tmp;

            if (Engine.Tool.SmallButton("Open Font File"))
            {
                input = Engine.Tool.OpenDialog("ttf,otf", "") ?? "";
            }

            Engine.Tool.SliderInt("Sampling Size", ref samplingSize, 1, 1024, "%d", ToolSliderFlags.None);

            tmp = Engine.Tool.InputText("Characters Text File", charactersTextFilePath, 2048, ToolInputTextFlags.None);
            if (tmp != null)
            {
                charactersTextFilePath = tmp;
            }

            if (Engine.Tool.SmallButton("Open Characters Text File"))
            {
                charactersTextFilePath = Engine.Tool.OpenDialog("txt", "") ?? "";
            }

            if (Engine.Tool.Button("Save A2F File", new Vector2F()))
            {
                if (!System.IO.File.Exists(input))
                {
                    msg = $"Font file '{input}' not found.";
                    return;
                }

                if (!System.IO.File.Exists(charactersTextFilePath))
                {
                    msg = $"Characters text file '{charactersTextFilePath}' not found.";
                    return;
                }

                var output = Engine.Tool.SaveDialog("a2f", "") ?? "";

                if (output != "")
                {
                    if (!output.EndsWith(".a2f")) output += ".a2f";

                    var characters = System.IO.File.ReadAllText(charactersTextFilePath);
                    var res = Font.GenerateFontFile(input, output, characters, samplingSize);

                    msg = res ?$"Success!" : $"Fail to generate A2F file";
                }
            }
        }
    }
}
