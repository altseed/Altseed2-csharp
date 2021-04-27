using System;
using CommandLine;

namespace Altseed2.Tools
{
    [Verb("file")]
    [SubCommand(1, 1, CoreModules.File)]
    class FileCommand : ISubCommand
    {
        [Option('s', "src", HelpText = "Source Directory", Required = true)]
        public string SrcPath { get; set; }

        [Option('o', "output", HelpText = "Target Package Path", Required = true)]
        public string DstPath { get; set; }

        [Option('p', "password", HelpText = "Password (Optional)", Required = false, Default = null)]
        public string Password { get; set; }

        void ISubCommand.Run()
        {
            if (!System.IO.Directory.Exists(SrcPath))
            {
                throw new Exception($"Directory {SrcPath} is not found.");
            }

            
            if (DstPath is null || DstPath == "")
            {
                throw new Exception($"Output '{DstPath}' is invalid.");
            }


            var dst = DstPath.EndsWith(".pack") ? DstPath : $"{DstPath}.pack";

            if (Password is null)
            {
                if (!Engine.File.Pack(SrcPath, dst))
                {
                    throw new Exception($"Failed to pack '{SrcPath}' to '{dst}'.");
                }
            }
            else
            {
                if (!Engine.File.PackWithPassword(SrcPath, dst, Password))
                {
                    throw new Exception($"Failed to pack '{SrcPath}' to '{dst}' with password.");
                }
            }
        }

    }
}
