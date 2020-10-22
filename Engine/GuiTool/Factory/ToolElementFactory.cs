using System;
using System.Collections;
using System.Reflection;

namespace Altseed2.GuiTool.Factory
{
    internal class ToolElementFactory
    {
        public ToolElement FromPropertyMetadata(PropertyInfo info, object source)
        {
            if (!info.CanWrite)
            {
                return new LabelToolElement(info.Name, source, info.Name);
            }

            if (info.PropertyType == typeof(bool))
                return new BoolToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(Color))
                return new ColorToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(Enum))
                return new EnumToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(float))
                return new FloatToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(Font))
                return new FontToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(string))
            {
                if (info.CanWrite)
                    return new InputTextToolElement(info.Name, source, info.Name);
                return null;
            }

            if (info.PropertyType == typeof(int))
                return new IntToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(IList))
                return new ListToolElement(info.Name, source, info.Name);
            
            if (info.PropertyType == typeof(TextureBase))
                return new TextureBaseToolElement(info.Name, source, info.Name);

            if (info.PropertyType == typeof(Vector2F))
                return new Vector2FToolElement(info.Name, source, info.Name);

            return null;
        }

        public ToolElement FromPropertyAttribute(ToolAttributeBase attribute, PropertyInfo info, object source)
        {
            var elementName = attribute.Name ?? info.Name;

            return attribute switch
            {
                ToolBoolAttribute _ => new BoolToolElement(elementName, source, info.Name),
                ToolColorAttribute toolColorAttribute => new ColorToolElement(elementName, source, info.Name, toolColorAttribute.Flags),
                ToolEnumAttribute _ => new EnumToolElement(elementName, source, info.Name),
                ToolFloatAttribute toolFloatAttribute => new FloatToolElement(elementName, source, info.Name, toolFloatAttribute.Speed, toolFloatAttribute.Min, toolFloatAttribute.Max),
                ToolFontAttribute _ => new FontToolElement(elementName, source, info.Name),
                ToolGroupAttribute _ => new GroupToolElement(elementName, source, info.Name),
                ToolInputTextAttribute toolInputTextAttribute => new InputTextToolElement(elementName, source, info.Name, toolInputTextAttribute.IsMultiLine, toolInputTextAttribute.MaxLength),
                ToolIntAttribute toolIntAttribute => new IntToolElement(elementName, source, info.Name, toolIntAttribute.Speed, toolIntAttribute.Min, toolIntAttribute.Max),
                ToolLabelAttribute _ => new LabelToolElement(elementName, source, info.Name),
                ToolListAttribute toolListAttribute => new ListToolElement(
                    elementName, source, info.Name,
                    toolListAttribute.ListElementPropertyName,
                    toolListAttribute.SelectedItemPropertyName,
                    toolListAttribute.AddMethodName,
                    toolListAttribute.RemoveMethodName,
                    toolListAttribute.SelectedItemIndexPropertyName),
                ToolPathAttribute toolPathAttribute => new PathToolElement(elementName,
                    source,
                    info.Name,
                    toolPathAttribute.IsDirectory,
                    toolPathAttribute.Filter,
                    toolPathAttribute.DefaultPath,
                    toolPathAttribute.MaxLength,
                    toolPathAttribute.RootDirectoryPathPropertyName),
                ToolTextureBaseAttribute _ => new TextureBaseToolElement(elementName, source, info.Name),
                ToolVector2FAttribute toolVector2FAttribute => new Vector2FToolElement(elementName, source, info.Name, toolVector2FAttribute.Speed, toolVector2FAttribute.Min, toolVector2FAttribute.Max),
                _ => null,
            };
        }

        public ToolElement FromMethodAttribute(ToolCommandAttributeBase attribute, MethodInfo info, object source)
        {
            var commandName = attribute.Name ?? info.Name;
            return attribute switch
            {
                ToolButtonAttribute _ => new ButtonToolElement(commandName, source, info.Name),
                ToolUserAttribute _ => new UserToolElement(commandName, source, info.Name),
                _ => null
            };
        }

        public ToolElement FromObjectMapping(object source, MemberGuiInfo guiInfo)
        {
            ToolElement toolElement = guiInfo.ToolElementType switch
            {
                ToolElementType.Bool => BoolToolElement.Create(source, guiInfo),
                ToolElementType.Color => ColorToolElement.Create(source, guiInfo),
                ToolElementType.Group => GroupToolElement.Create(source, guiInfo),
                ToolElementType.InputText => InputTextToolElement.Create(source, guiInfo),
                ToolElementType.Int => IntToolElement.Create(source, guiInfo),
                ToolElementType.Label => LabelToolElement.Create(source, guiInfo),
                ToolElementType.List => ListToolElement.Create(source, guiInfo),
                ToolElementType.Path => PathToolElement.Create(source, guiInfo),
                ToolElementType.Vector2F => Vector2FToolElement.Create(source, guiInfo),
                ToolElementType.Float => FloatToolElement.Create(source, guiInfo),
                ToolElementType.TextureBase => TextureBaseToolElement.Create(source, guiInfo),
                ToolElementType.Font => FontToolElement.Create(source, guiInfo),
                ToolElementType.Enum => EnumToolElement.Create(source, guiInfo),
                ToolElementType.Button => ButtonToolElement.Create(source, guiInfo),
                ToolElementType.User => UserToolElement.Create(source, guiInfo),
                _ => null
            };

            if (toolElement is null)
            {
                Engine.Log.Error(LogCategory.User, $"{guiInfo.ToolElementType} is not defined.");
            }

            return toolElement;
        }
    }
}
