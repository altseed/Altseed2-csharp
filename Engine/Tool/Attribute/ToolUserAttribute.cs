using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class ToolUserAttribute : ToolCommandAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ToolUserAttribute(string name = null)
            : base(name)
        {
        }
    }
}
