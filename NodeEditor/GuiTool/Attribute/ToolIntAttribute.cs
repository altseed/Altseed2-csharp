using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolIntAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Min { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Max { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speed"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public ToolIntAttribute(string name = null, float speed = 1, int min = -100, int max = 100)
            : base(name)
        {
            Speed = speed;
            Min = min;
            Max = max;
        }
    }
}
