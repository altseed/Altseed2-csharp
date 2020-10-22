using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public enum ToolElementType
    {
        /// <summary>
        /// 
        /// </summary>
        Bool,
        /// <summary>
        /// 
        /// </summary>
        Color,
        /// <summary>
        /// 
        /// </summary>
        Float,
        /// <summary>
        /// 
        /// </summary>
        Group,
        /// <summary>
        /// 
        /// </summary>
        InputText,
        /// <summary>
        /// 
        /// </summary>
        Int,
        /// <summary>
        /// 
        /// </summary>
        Label,
        /// <summary>
        /// 
        /// </summary>
        List,
        /// <summary>
        /// 
        /// </summary>
        Path,
        /// <summary>
        /// 
        /// </summary>
        Vector2F,
        /// <summary>
        /// 
        /// </summary>
        TextureBase,
        /// <summary>
        /// 
        /// </summary>
        Font,
        /// <summary>
        /// 
        /// </summary>
        Enum,
        /// <summary>
        /// 
        /// </summary>
        Button,
        /// <summary>
        /// 
        /// </summary>
        User,
    }

    /// <summary>
    /// 
    /// </summary>
    public class MemberGuiInfo
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
        public MemberGuiInfo(ToolElementType toolElementType, string name, string propertyName, Dictionary<string, object> options)
        {
            ToolElementType = toolElementType;
            Name = name;
            PropertyName = propertyName;
            Options = options ?? new Dictionary<string, object>();
        }
    }
}