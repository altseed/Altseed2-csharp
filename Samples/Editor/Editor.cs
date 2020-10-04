using Altseed2;

class Editor
{
    public static void Main(string[] args)
    {
        var config = new Configuration()
        {
            WaitVSync = true,
        };

        Altseed2.Editor.Initialize("AltseedEditor", 1280, 960, config);

        while (Engine.DoEvents())
        {
            Altseed2.Editor.Update();
        }

        Altseed2.Editor.Terminate();
    }
}