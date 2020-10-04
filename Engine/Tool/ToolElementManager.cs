using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
    public class ToolElementManager
    {

        /// <summary>
        /// 
        /// </summary>
        public class ObjectMapping
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
            public ObjectMapping(ToolElementType toolElementType, string name, string propertyName, Dictionary<string, object> options)
            {
                ToolElementType = toolElementType;
                Name = name;
                PropertyName = propertyName;
                Options = options ?? new Dictionary<string, object>();
            }
        }

        private static Dictionary<Type, List<ObjectMapping>> objectMappings = new Dictionary<Type, List<ObjectMapping>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="objectMappings"></param>
        /// <returns></returns>
        public static bool AddObjectMapping(Type type, IEnumerable<ObjectMapping> objectMappings)
        {
            foreach (var objectMapping in objectMappings)
            {
                try
                {
                    _ = type.GetProperty(objectMapping.PropertyName);
                }
                catch
                {
                    return false;
                }
            }
            ToolElementManager.objectMappings[type] = objectMappings.ToList();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ClearObjectMappings()
        {
            objectMappings.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<ToolElement> CreateToolElements(object source)
        {
            if (source == null)
                return Enumerable.Empty<ToolElement>();

            Dictionary<string, ToolElement> res = new Dictionary<string, ToolElement>();

            if (System.Attribute.IsDefined(source.GetType(), typeof(ToolAutoAttribute)))
            {
                foreach (var (name, toolElement) in CreateToolElementsAuto(source))
                {
                    res[name] = toolElement;
                }
            }

            foreach (var (name, toolElement) in CreateToolElementsFromPropetyAttributes(source))
            {
                res[name] = toolElement;
            }

            foreach (var (name, toolElement) in CreateToolElementsFromObjectMappings(source))
            {
                res[name] = toolElement;
            }

            return res.Values.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static Dictionary<string, ToolElement> CreateToolElementsAuto(object source)
        {
            Dictionary<string, ToolElement> res = new Dictionary<string, ToolElement>();

            foreach (var info in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                try
                {
                    if (System.Attribute.IsDefined(info, typeof(ToolHiddenAttribute)))
                        continue;

                    if (!info.CanWrite)
                    {
                        res[info.Name] = new LabelToolElement(info.Name, source, info.Name);
                        continue;
                    }

                    if (info.PropertyType == typeof(bool))
                        res[info.Name] = new BoolToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(Color))
                        res[info.Name] = new ColorToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(Enum))
                        res[info.Name] = new EnumToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(float))
                        res[info.Name] = new FloatToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(Font))
                        res[info.Name] = new FontToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(string))
                    {
                        if (info.CanWrite)
                            res[info.Name] = new InputTextToolElement(info.Name, source, info.Name);
                    }
                    else if (info.PropertyType == typeof(int))
                        res[info.Name] = new IntToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(IList))
                        res[info.Name] = new ListToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(TextureBase))
                        res[info.Name] = new TextureBaseToolElement(info.Name, source, info.Name);
                    else if (info.PropertyType == typeof(Vector2F))
                        res[info.Name] = new Vector2FToolElement(info.Name, source, info.Name);
                }
                catch (Exception e)
                {
                    Engine.Log.Error(LogCategory.User, e.Message);
                    Engine.Log.Error(LogCategory.User, e.StackTrace);
                }
            }

            return res;
        }

        private static Dictionary<string, ToolElement> CreateToolElementsFromPropetyAttributes(object source)
        {
            Dictionary<string, ToolElement> res = new Dictionary<string, ToolElement>();

            foreach (var info in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                System.Attribute[] attributes = System.Attribute.GetCustomAttributes(info, typeof(System.Attribute));
                foreach (System.Attribute attribute in attributes)
                {
                    try
                    {
                        switch (attribute)
                        {
                            case ToolBoolAttribute toolBoolAttribute:
                                res[toolBoolAttribute.Name ?? info.Name] = new BoolToolElement(toolBoolAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolColorAttribute toolColorAttribute:
                                res[toolColorAttribute.Name ?? info.Name] = new ColorToolElement(toolColorAttribute.Name ?? info.Name, source, info.Name, toolColorAttribute.Flags);
                                break;
                            case ToolEnumAttribute toolEnumAttribute:
                                res[toolEnumAttribute.Name ?? info.Name] = new EnumToolElement(toolEnumAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolFloatAttribute toolFloatAttribute:
                                res[toolFloatAttribute.Name ?? info.Name] = new FloatToolElement(toolFloatAttribute.Name ?? info.Name, source, info.Name, toolFloatAttribute.Speed, toolFloatAttribute.Min, toolFloatAttribute.Max);
                                break;
                            case ToolFontAttribute toolFontAttribute:
                                res[toolFontAttribute.Name ?? info.Name] = new FontToolElement(toolFontAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolGroupAttribute toolGroupAttribute:
                                res[toolGroupAttribute.Name ?? info.Name] = new GroupToolElement(toolGroupAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolInputTextAttribute toolInputTextAttribute:
                                res[toolInputTextAttribute.Name ?? info.Name] = new InputTextToolElement(toolInputTextAttribute.Name ?? info.Name, source, info.Name, toolInputTextAttribute.IsMultiLine, toolInputTextAttribute.MaxLength);
                                break;
                            case ToolIntAttribute toolIntAttribute:
                                res[toolIntAttribute.Name ?? info.Name] = new IntToolElement(toolIntAttribute.Name ?? info.Name, source, info.Name, toolIntAttribute.Speed, toolIntAttribute.Min, toolIntAttribute.Max);
                                break;
                            case ToolLabelAttribute toolLabelAttribute:
                                res[toolLabelAttribute.Name ?? info.Name] = new LabelToolElement(toolLabelAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolListAttribute toolListAttribute:
                                res[toolListAttribute.Name ?? info.Name] = new ListToolElement(toolListAttribute.Name ?? info.Name, source, info.Name, toolListAttribute.ListElementPropertyName, toolListAttribute.SelectedItemPropertyName, toolListAttribute.AddMethodName, toolListAttribute.RemoveMethodName);
                                break;
                            case ToolPathAttribute toolPathAttribute:
                                res[toolPathAttribute.Name ?? info.Name] = new PathToolElement(toolPathAttribute.Name ?? info.Name, source, info.Name, toolPathAttribute.IsDirectory, toolPathAttribute.Filter, toolPathAttribute.DefaultPath, toolPathAttribute.MaxLength, toolPathAttribute.RootDirectoryPathPropertyName);
                                break;
                            case ToolTextureBaseAttribute toolTextureBaseAttribute:
                                res[toolTextureBaseAttribute.Name ?? info.Name] = new TextureBaseToolElement(toolTextureBaseAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolVector2FAttribute toolVector2FAttribute:
                                res[toolVector2FAttribute.Name ?? info.Name] = new Vector2FToolElement(toolVector2FAttribute.Name ?? info.Name, source, info.Name, toolVector2FAttribute.Speed, toolVector2FAttribute.Min, toolVector2FAttribute.Max);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Engine.Log.Error(LogCategory.User, e.Message);
                        Engine.Log.Error(LogCategory.User, e.StackTrace);
                    }
                }
            }

            foreach (var info in source.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                System.Attribute[] attributes = System.Attribute.GetCustomAttributes(info, typeof(System.Attribute));
                foreach (System.Attribute attribute in attributes)
                {
                    try
                    {
                        switch (attribute)
                        {
                            case ToolButtonAttribute toolButtonAttribute:
                                res[toolButtonAttribute.Name ?? info.Name] = new ButtonToolElement(toolButtonAttribute.Name ?? info.Name, source, info.Name);
                                break;
                            case ToolUserAttribute toolUserAttribute:
                                res[toolUserAttribute.Name ?? info.Name] = new UserToolElement(toolUserAttribute.Name ?? info.Name, source, info.Name);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Engine.Log.Error(LogCategory.User, e.Message);
                        Engine.Log.Error(LogCategory.User, e.StackTrace);
                    }
                }
            }

            return res;
        }

        private static Dictionary<string, ToolElement> CreateToolElementsFromObjectMappings(object source)
        {
            Dictionary<string, ToolElement> res = new Dictionary<string, ToolElement>();
            Dictionary<string, ObjectMapping> GetObjectMappings(Type type)
            {
                var objectMappings = new Dictionary<string, ObjectMapping>();
                if (type.BaseType != null)
                {
                    var baseMappings = GetObjectMappings(type.BaseType);
                    foreach (var item in baseMappings)
                    {
                        objectMappings[item.Key] = item.Value;
                    }
                }

                foreach (var interface_ in type.GetInterfaces())
                {
                    var interfaceMappings = GetObjectMappings(type.BaseType);
                    foreach (var item in interfaceMappings)
                    {
                        objectMappings[item.Key] = item.Value;
                    }
                }

                if (ToolElementManager.objectMappings.ContainsKey(type))
                {
                    var temp = ToolElementManager.objectMappings[type].ToDictionary(obj => obj.Name, obj => obj);

                    foreach (var item in temp)
                    {
                        objectMappings[item.Key] = temp[item.Key];
                    }
                }

                return objectMappings;
            }
            var type = source.GetType();
            var objectMappings = GetObjectMappings(type);

            foreach (var (name, objectMapping) in objectMappings)
            {
                try
                {
                    ToolElement toolElement = null;
                    switch (objectMapping.ToolElementType)
                    {
                        case ToolElementType.Bool:
                            toolElement = BoolToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Color:
                            toolElement = ColorToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Group:
                            toolElement = GroupToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.InputText:
                            toolElement = InputTextToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Int:
                            toolElement = IntToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Label:
                            toolElement = LabelToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.List:
                            toolElement = ListToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Path:
                            toolElement = PathToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Vector2F:
                            toolElement = Vector2FToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Float:
                            toolElement = FloatToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.TextureBase:
                            toolElement = TextureBaseToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Font:
                            toolElement = FontToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Enum:
                            toolElement = EnumToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.Button:
                            toolElement = ButtonToolElement.Create(source, objectMapping);
                            break;
                        case ToolElementType.User:
                            toolElement = UserToolElement.Create(source, objectMapping);
                            break;
                        default:
                            Engine.Log.Error(LogCategory.User, $"{objectMapping.ToolElementType} is not defined.");
                            break;
                    }
                    res[name] = toolElement;
                }
                catch (Exception e)
                {
                    Engine.Log.Error(LogCategory.User, e.Message);
                    Engine.Log.Error(LogCategory.User, e.StackTrace);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetAltseed2DefaultObjectMapping()
        {
            objectMappings.Add(typeof(TransformNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Vector2F, "Position", "Position", null),
                    new ObjectMapping(ToolElementType.Vector2F, "CenterPosition", "CenterPosition", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Scale", "Scale", new Dictionary<string, object>() { { "speed", 0.1f }, { "min", 0f}, {"max", 1f} }),
                    new ObjectMapping(ToolElementType.Float, "Angle", "Angle", new Dictionary<string, object>() { {"min", -180f}, {"max", 180f} }),
                    new ObjectMapping(ToolElementType.Bool, "HorizontalFlip", "HorizontalFlip", null),
                    new ObjectMapping(ToolElementType.Bool, "VerticalFlip", "VerticalFlip", null),
                });

            objectMappings.Add(typeof(TextNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.InputText, "Text", "Text", null),
                    new ObjectMapping(ToolElementType.Font, "Font", "Font", null),
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Bool, "IsEnableKerning", "IsEnableKerning", null),
                    new ObjectMapping(ToolElementType.Float, "CharacterSpace", "CharacterSpace", null),
                    new ObjectMapping(ToolElementType.Float, "Weight", "Weight", null),
                    new ObjectMapping(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new ObjectMapping(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                    new ObjectMapping(ToolElementType.Enum, "WritingDirection", "WritingDirection", null),
                });

            objectMappings.Add(typeof(SpriteNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.TextureBase, "Texture", "Texture", null),
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new ObjectMapping(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                });

            objectMappings.Add(typeof(ShapeNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.TextureBase, "Texture", "Texture", null),
                    new ObjectMapping(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new ObjectMapping(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                });

            objectMappings.Add(typeof(ArcNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Float, "Radius", "Radius", null),
                    new ObjectMapping(ToolElementType.Float, "StartDegree", "StartDegree", new Dictionary<string, object>() { { "min", -180f }, {"max", 180f } }),
                    new ObjectMapping(ToolElementType.Float, "EndDegree", "EndDegree", new Dictionary<string, object>() { { "min", -180f }, {"max", 180f } }),
                    new ObjectMapping(ToolElementType.Int, "VertNum", "VertNum", new Dictionary<string, object>() { { "min", 3 }, {"max", 500 } }),
                });

            objectMappings.Add(typeof(CircleNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Float, "Radius", "Radius", null),
                    new ObjectMapping(ToolElementType.Int, "VertNum", "VertNum", new Dictionary<string, object>() { { "min", 3 }, {"max", 500 } }),
                });

            objectMappings.Add(typeof(LineNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Float, "Thickness", "Thickness", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Point1", "Point1", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Point2", "Point2", null),
                });

            objectMappings.Add(typeof(RectangleNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Vector2F, "RectangleSize", "RectangleSize", null),
                });

            objectMappings.Add(typeof(TriangleNode),
                new List<ObjectMapping>
                {
                    new ObjectMapping(ToolElementType.Color, "Color", "Color", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Point1", "Point1", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Point2", "Point2", null),
                    new ObjectMapping(ToolElementType.Vector2F, "Point3", "Point3", null),
                });
        }
    }
}