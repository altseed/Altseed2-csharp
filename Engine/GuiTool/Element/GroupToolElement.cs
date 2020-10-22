using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupToolElement : ToolElement
    {
        List<ToolElement> ToolElements { get; set; }

        WeakReference<object> Target { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public GroupToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            object target = PropertyInfo?.GetValue(source);
            if (target != null)
            {
                Target = new WeakReference<object>(target);
                ToolElements = ToolElementManager.CreateToolElements(target).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            if ((Target == null && PropertyInfo?.GetValue(Source) != null) ||
                (Target != null && (!Target.TryGetTarget(out var target) || target != PropertyInfo?.GetValue(Source))))
            {
                object t = PropertyInfo?.GetValue(Source);
                Target = new WeakReference<object>(t);
                ToolElements = ToolElementManager.CreateToolElements(t).ToList();
            }

            if (Engine.Tool.CollapsingHeader(Name, ToolTreeNodeFlags.CollapsingHeader | ToolTreeNodeFlags.Framed | ToolTreeNodeFlags.FramePadding))
            {
                foreach (var toolElement in ToolElements ?? Enumerable.Empty<ToolElement>())
                {
                    Engine.Tool.PushID(toolElement.GetHashCode());
                    toolElement.Update();
                    Engine.Tool.PopID();
                }
                Engine.Tool.Spacing();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static GroupToolElement Create(object source, ObjectMapping objectMapping)
        {
            return new GroupToolElement(objectMapping.Name, source, objectMapping.PropertyName);
        }
    }
}
