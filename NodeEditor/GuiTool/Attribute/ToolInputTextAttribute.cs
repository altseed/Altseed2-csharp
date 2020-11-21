using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolInputTextAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int MaxLength { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsMultiLine { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isMultiLine"></param>
        /// <param name="maxLength"></param>
        public ToolInputTextAttribute(string name = null, bool isMultiLine = false, int maxLength = 1024)
            : base(name)
        {
            IsMultiLine = isMultiLine;
            MaxLength = maxLength;
        }
    }
}
