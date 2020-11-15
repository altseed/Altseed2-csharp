using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class ToolCommandAttributeBase : Attribute
    {
        public string Name { get; }

        public ToolCommandAttributeBase(string name = null)
        {
            Name = name;
        }
    }
}
