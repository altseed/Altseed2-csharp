using System;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class IntToolElement : ToolElement
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
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="speed"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public IntToolElement(string name, object source, string propertyName, float speed = 1, int min = -100, int max = 100) : base(name, source, propertyName)
        {
            Speed = speed;
            Min = min;
            Max = max;

            if (!typeof(int).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がint型ではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            int num = (int)PropertyInfo.GetValue(Source);
            if (Engine.Tool.DragInt(Name, ref num, Speed, Min, Max, "%d", ToolSliderFlags.None))
            {
                PropertyInfo.SetValue(Source, num);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static IntToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var speed = guiInfo.Options.ContainsKey("speed") ? (float)guiInfo.Options["speed"] : 1;
            var min = guiInfo.Options.ContainsKey("min") ? (int)guiInfo.Options["min"] : -100;
            var max = guiInfo.Options.ContainsKey("max") ? (int)guiInfo.Options["max"] : 100;
            return new IntToolElement(guiInfo.Name, source, guiInfo.PropertyName, speed, min, max);
        }
    }
}
