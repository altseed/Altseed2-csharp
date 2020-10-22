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
    public partial class ToolElementManager
    {

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
            var factory = new ToolElementFactory();

            foreach (var info in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                try
                {
                    if (System.Attribute.IsDefined(info, typeof(ToolHiddenAttribute)))
                        continue;

                    if (factory.FromPropertyMetadata(info, source) is {} element)
                    {
                        res[info.Name] = element;
                    }
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
            var factory = new ToolElementFactory();

            foreach (var info in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                System.Attribute[] attributes = System.Attribute.GetCustomAttributes(info, typeof(System.Attribute));
                foreach (System.Attribute attribute in attributes)
                {
                    if (!(attribute is ToolAttributeBase toolAttribute))
                    {
                        continue;
                    }

                    try
                    {
                        if (factory.FromPropertyAttribute(toolAttribute, info, source) is {} element)
                        {
                            res[toolAttribute.Name ?? info.Name] = element;
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
                    if (!(attribute is ToolCommandAttributeBase commandAttribute))
                    {
                        continue;
                    }

                    try
                    {
                        if (factory.FromMethodAttribute(commandAttribute, info, source) is {} element)
                        {
                            res[commandAttribute.Name ?? info.Name] = element;
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

            var factory = new ToolElementFactory();
            foreach (var (name, objectMapping) in objectMappings)
            {
                try
                {
                    res[name] = factory.FromObjectMapping(source, objectMapping);
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