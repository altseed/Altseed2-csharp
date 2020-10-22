using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolTextureBaseAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ToolTextureBaseAttribute(string name = null)
            : base(name)
        {
        }
    }
}
