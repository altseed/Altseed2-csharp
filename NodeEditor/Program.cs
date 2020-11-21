using Altseed2.NodeEditor.View;
using System;

namespace Altseed2.NodeEditor
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
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
}
