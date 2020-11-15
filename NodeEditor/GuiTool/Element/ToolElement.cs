using System;
using System.Reflection;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ToolElement
    {
        private readonly WeakReference<object> source;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public ToolElement(string name, object source, string propertyName)
        {
            Name = name;
            this.source = new WeakReference<object>(source);
            PropertyName = propertyName;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 
        /// </summary>
        public object Source
        {
            get
            {
                if (source.TryGetTarget(out var res))
                    return res;
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetProperty(PropertyName);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
