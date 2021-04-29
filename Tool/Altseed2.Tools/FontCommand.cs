using System;

using CommandLine;

namespace Altseed2.Tools
{
    [Verb("font")]
    [SubCommand(1, 1, CoreModules.Graphics | CoreModules.File)]
    public class FontCommand : ISubCommand
    {
        [Option('s', "src", HelpText = "Source Font File", Required = true)]
        public string SrcPath { get; set; }

        [Option('o', "output", HelpText = "Target a2f Path", Required = true)]
        public string DstPath { get; set; }

        [Option('c', "chars", HelpText = "Characters to Generate", Required = true)]
        public string Characters { get; set; }

        [Option("size", Default = Font.DefaultSamplingSize, HelpText = "Sampling Size", Required = false)]
        public int SamplingSize { get; set; }

        void ISubCommand.Run()
        {
            if (!System.IO.File.Exists(SrcPath))
            {
                throw new Exception($"File {SrcPath} is not found.");
            }

            if (DstPath is null || DstPath == "")
            {
                throw new Exception($"Output '{DstPath}' is invalid.");
            }

            var dst = DstPath.EndsWith(".a2f") ? DstPath : $"{DstPath}.a2f";

            if (!Font.GenerateFontFile(SrcPath, dst, Characters, SamplingSize))
            {
                throw new Exception($"Failed to generate font file from '{SrcPath}' to '{dst}'");
            }
        }
    }
}
