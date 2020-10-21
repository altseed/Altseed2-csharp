using Altseed2;

class NodeEditor
{
    public static void Main(string[] args)
    {
        var config = new Configuration()
        {
            WaitVSync = true,
        };

        Editor.Initialize("AltseedEditor", 1280, 960, config);

        while (Engine.DoEvents())
        {
            Editor.Update();
        }

        Editor.Terminate();
    }
}