using System;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public EnumToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!(PropertyInfo?.PropertyType.IsEnum ?? true))
            {
                throw new ArgumentException("参照先がEnumではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            int current = (int)PropertyInfo.GetValue(Source);
            if (Engine.Tool.Combo(Name, ref current, Enum.GetNames(PropertyInfo.PropertyType), -1))
            {
                PropertyInfo.SetValue(Source, current);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static EnumToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            return new EnumToolElement(guiInfo.Name, source, guiInfo.PropertyName);
        }
    }
}
