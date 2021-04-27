using System;
namespace Altseed2.Tools
{
    [AttributeUsage(AttributeTargets.Class)]
    class SubCommandAttribute : Attribute
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public CoreModules CoreModules { get; private set; }

        public SubCommandAttribute(int width, int height, CoreModules modules)
        {
            Width = width;
            Height = height;
            CoreModules = modules;
        }
    }
}
