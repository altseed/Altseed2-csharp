using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolLabelAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ToolLabelAttribute(string name = null)
            : base(name)
        {
        }
    }
}
