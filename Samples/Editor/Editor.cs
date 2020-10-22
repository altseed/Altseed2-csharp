using Altseed2;
using Altseed2.NodeEditor.View;

class NodeEditor
{
    public static void Main(string[] args)
    {
        var config = new Configuration()
        {
            WaitVSync = true,
        };

        NodeEditorHost.Initialize("AltseedEditor", 1280, 960, config);

        while (Engine.DoEvents())
        {
            NodeEditorHost.Update();
        }

        NodeEditorHost.Terminate();
    }
}