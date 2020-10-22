using System;

namespace Altseed2
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class ToolAttributeBase : Attribute
    {
        public string Name { get; }

        public ToolAttributeBase(string name)
        {
            Name = name;
        }
    }
}
