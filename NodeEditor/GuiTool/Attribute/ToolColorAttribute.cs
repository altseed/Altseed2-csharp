using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolColorAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolColorEditFlags Flags { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        public ToolColorAttribute(string name = null, ToolColorEditFlags flags = ToolColorEditFlags.AlphaBar)
            : base(name)
        {
            Flags = flags;
        }
    }
}
