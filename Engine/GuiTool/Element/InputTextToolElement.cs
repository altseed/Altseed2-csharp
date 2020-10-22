using System;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class InputTextToolElement : ToolElement
    {
        int MaxLength { get; }
        bool IsMultiLine { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="isMultiLine"></param>
        /// <param name="maxLength"></param>
        public InputTextToolElement(string name, object source, string propertyName, bool isMultiLine = false, int maxLength = 1024) : base(name, source, propertyName)
        {
            IsMultiLine = isMultiLine;
            MaxLength = maxLength;

            if (!typeof(string).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がstring型ではありません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            string text = (string)PropertyInfo.GetValue(Source);
            if (text == null)
                text = "";
            string newStr;
            if (IsMultiLine)
            {
                if ((newStr = Engine.Tool.InputTextMultiline(Name, text, MaxLength, new Vector2F(-1, -1), ToolInputTextFlags.None)) != null)
                {
                    PropertyInfo.SetValue(Source, newStr);
                }
            }
            else if ((newStr = Engine.Tool.InputText(Name, text, MaxLength, ToolInputTextFlags.None)) != null)
            {
                PropertyInfo.SetValue(Source, newStr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static InputTextToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var isMultiLine = guiInfo.Options.ContainsKey("isMultiLine") ? (bool)guiInfo.Options["isMultiLine"] : false;
            var maxLength = guiInfo.Options.ContainsKey("maxLength") ? (int)guiInfo.Options["maxLength"] : 1024;
            return new InputTextToolElement(guiInfo.Name, source, guiInfo.PropertyName, isMultiLine, maxLength);
        }
    }
}
