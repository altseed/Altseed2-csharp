using System;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class Vector2FToolElement : ToolElement
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
        public Vector2FToolElement(string name, object source, string propertyName, float speed = 1, float min = -1000, float max = 1000) : base(name, source, propertyName)
        {
            Speed = speed;
            Min = min;
            Max = max;

            if (!typeof(Vector2F).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がVector2Fではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            Vector2F vector = (Vector2F)PropertyInfo.GetValue(Source);
            float[] vectorArray =  new float[2] { vector.X, vector.Y };

            if (Engine.Tool.DragFloat2(Name, vectorArray, Speed, Min, Max, "%f", ToolSliderFlags.None))
            {
                vector.X = vectorArray[0];
                vector.Y = vectorArray[1];
                PropertyInfo.SetValue(Source, vector);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static Vector2FToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var speed = guiInfo.Options.ContainsKey("speed") ? (float)guiInfo.Options["speed"] : 1;
            var min = guiInfo.Options.ContainsKey("min") ? (float)guiInfo.Options["min"] : -1000;
            var max = guiInfo.Options.ContainsKey("max") ? (float)guiInfo.Options["max"] : 1000;
            return new Vector2FToolElement(guiInfo.Name, source, guiInfo.PropertyName, speed, min, max);
        }
    }
}
