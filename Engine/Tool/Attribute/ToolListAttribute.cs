using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ToolListAttribute : ToolAttributeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string ListElementPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedItemPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string AddMethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string RemoveMethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedItemIndexPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="listElementPropertyName"></param>
        /// <param name="selectedItemPropertyName"></param>
        /// <param name="addMethodName"></param>
        /// <param name="removeMethodName"></param>
        /// <param name="selectedItemIndexPropertyName"></param>
        public ToolListAttribute(string name = null, string listElementPropertyName = null, string selectedItemPropertyName = null, string addMethodName = null, string removeMethodName = null, string selectedItemIndexPropertyName = null)
            : base(name)
        {
            ListElementPropertyName = listElementPropertyName;
            SelectedItemPropertyName = selectedItemPropertyName;
            AddMethodName = addMethodName;
            RemoveMethodName = removeMethodName;
            SelectedItemIndexPropertyName = selectedItemIndexPropertyName;
        }
    }
}
