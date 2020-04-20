using System;

namespace Altseed.Tool.FontGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("Font Generator", 400, 600, new Configuration() { ToolEnabled = true, IsResizable = false });

            string input = "";
            int size = 20;
            string charactersTextFilePath = "";
            string msg = "";
            while (Engine.DoEvents())
            {
                if (Engine.Tool.BeginFullScreen(0))
                {
                    var tmp = Engine.Tool.InputText("Input TTF File", input, 2048, ToolInputText.None);
                    if (tmp != null) input = tmp;

                    if (Engine.Tool.SmallButton("Open TTF File"))
                        input = Engine.Tool.OpenDialog("ttf", "");

                    Engine.Tool.SliderInt("Font Size", ref size, 1, 1, 1024);

                    tmp = Engine.Tool.InputText("Characters Text File", charactersTextFilePath, 2048, ToolInputText.None);
                    if (tmp != null) charactersTextFilePath = tmp;

                    if (Engine.Tool.SmallButton("Open Characters Text File"))
                        charactersTextFilePath = Engine.Tool.OpenDialog("txt", "");

                    if (Engine.Tool.Button("Save A2F File", new Vector2F()))
                    {
                        var output = Engine.Tool.SaveDialog("a2f", "");
                        
                        if (output != null)
                        {
                            if (!output.EndsWith(".a2f")) output += ".a2f";

                            if (!System.IO.File.Exists(charactersTextFilePath))
                            {
                                msg = "Not Exists Characters Text File.";
                            }
                            var characters = System.IO.File.ReadAllText(charactersTextFilePath);
                            var res = Font.GenerateFontFile(input, output, size, characters);

                            if (res)
                                msg = "Success!";
                            else
                                msg = "Fail to Generate A2F File";
                        }
                    }

                    Engine.Tool.Text(msg);

                    Engine.Tool.End();
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
