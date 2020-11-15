using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolPathAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int MaxLength { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Filter { get; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultPath { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirectory { get; }

        /// <summary>
        /// 
        /// </summary>
        public string RootDirectoryPathPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isDirectory"></param>
        /// <param name="filter"></param>
        /// <param name="defaultPath"></param>
        /// <param name="maxLength"></param>
        /// <param name="rootDirectoryPathPropertyName"></param>
        public ToolPathAttribute(string name = null, bool isDirectory = false, string filter = "", string defaultPath = "", int maxLength = 1024, string rootDirectoryPathPropertyName = null)
            : base(name)
        {
            MaxLength = maxLength;
            Filter = filter;
            DefaultPath = defaultPath;
            IsDirectory = isDirectory;
            RootDirectoryPathPropertyName = rootDirectoryPathPropertyName;
        }
    }
}
