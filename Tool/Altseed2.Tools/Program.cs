using System;

using CommandLine;

namespace Altseed2.Tools
{
    class Program
    {
        static void RunSubCommand<T>(T cmd)
            where T : class, ISubCommand
        {
            var provider = (System.Reflection.ICustomAttributeProvider)typeof(T);
            var attrs = provider.GetCustomAttributes(typeof(SubCommandAttribute), false) as SubCommandAttribute[];

            if (attrs is null || attrs.Length == 0)
            {
                throw new Exception($"SubCommandAttribute needed");
            }

            var attr = attrs[0];

            if (!Engine.Initialize("Altseed2.Tool", attr.Width, attr.Height, new Configuration { EnabledCoreModules = attr.CoreModules, ToolSettingFileName = null }))
            {
                throw new Exception("Failed to initialize the Engine");
            }

            cmd.Run();

            Engine.Terminate();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<FileCommand, FontCommand, GUICommand>(args)
                .WithParsed<FileCommand>(RunSubCommand)
                .WithParsed<FontCommand>(RunSubCommand)
                .WithParsed<GUICommand>(RunSubCommand)
                .WithNotParsed(er => {
                    Console.WriteLine("Failed to parse arguments");
                });
        }
    }
}
