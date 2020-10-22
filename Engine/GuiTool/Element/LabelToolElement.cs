using System;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class LabelToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        public LabelToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!(PropertyInfo?.CanRead ?? false))
            {
                throw new ArgumentException("参照先から読み取れません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            string text = PropertyInfo.GetValue(Source)?.ToString() ?? "none";
            Engine.Tool.LabelText(Name, text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static LabelToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            return new LabelToolElement(guiInfo.Name, source, guiInfo.PropertyName);
        }
    }
}
