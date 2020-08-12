using CommandLine;

using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2.TestForMacLinux
{
    public class Options
    {
        [Option('f', "filter", Separator = ',', Required = false)]
        public IEnumerable<string> Filter { get; set; }
    }
}
