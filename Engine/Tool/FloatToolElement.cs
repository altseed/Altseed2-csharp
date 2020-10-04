using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class FloatToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// 
        /// </summary>
        public float Min { get; }

        /// <summary>
        /// 
        /// </summary>
        public float Max { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="speed"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public FloatToolElement(string name, object source, string propertyName, float speed = 1, float min = -100, float max = 100) : base(name, source, propertyName)
        {
            Speed = speed;
            Min = min;
            Max = max;

            if (!typeof(float).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がfloat型ではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            float num = (float)PropertyInfo.GetValue(Source);
            if (Engine.Tool.SliderFloat(Name, ref num, Speed, Min, Max))
            {
                PropertyInfo.SetValue(Source, num);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static FloatToolElement Create(object source, ToolElementManager.ObjectMapping objectMapping)
        {
            var speed = objectMapping.Options.ContainsKey("speed") ? (float)objectMapping.Options["speed"] : 1f;
            var min = objectMapping.Options.ContainsKey("min") ? (float)objectMapping.Options["min"] : -100f;
            var max = objectMapping.Options.ContainsKey("max") ? (float)objectMapping.Options["max"] : 100f;
            return new FloatToolElement(objectMapping.Name, source, objectMapping.PropertyName, speed, min, max);
        }
    }
}
