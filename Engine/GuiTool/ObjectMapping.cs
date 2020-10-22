using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMapping
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolElementType ToolElementType { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> Options { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolElementType"></param>
        /// <param name="name"></param>
        /// <param name="propertyName"></param>
        /// <param name="options"></param>
        public ObjectMapping(ToolElementType toolElementType, string name, string propertyName, Dictionary<string, object> options)
        {
            ToolElementType = toolElementType;
            Name = name;
            PropertyName = propertyName;
            Options = options ?? new Dictionary<string, object>();
        }
    }
}