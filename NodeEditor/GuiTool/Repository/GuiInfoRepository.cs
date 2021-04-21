using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed2.GuiTool.Repository
{
    public sealed class GuiInfoRepository
    {
        public readonly Dictionary<Type, List<MemberGuiInfo>> ObjectMappings = new Dictionary<Type, List<MemberGuiInfo>>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="objectMappings"></param>
        /// <returns></returns>
        public bool AddObjectMapping(Type type, IEnumerable<MemberGuiInfo> objectMappings)
        {
            var mappings = objectMappings.ToArray();

            foreach (var objectMapping in mappings)
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
            ObjectMappings[type] = mappings.ToList();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearObjectMappings()
        {
            ObjectMappings.Clear();
        }

        public void SetAltseed2DefaultObjectMapping()
        {
            ObjectMappings.Add(typeof(TransformNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Vector2F, "Position", "Position", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "CenterPosition", "CenterPosition", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Scale", "Scale", new Dictionary<string, object>() { { "speed", 0.1f }, { "min", 0f}, {"max", 1f} }),
                    new MemberGuiInfo(ToolElementType.Float, "Angle", "Angle", new Dictionary<string, object>() { {"min", -180f}, {"max", 180f} }),
                    new MemberGuiInfo(ToolElementType.Bool, "HorizontalFlip", "HorizontalFlip", null),
                    new MemberGuiInfo(ToolElementType.Bool, "VerticalFlip", "VerticalFlip", null),
                });

            ObjectMappings.Add(typeof(TextNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.InputText, "Text", "Text", null),
                    new MemberGuiInfo(ToolElementType.Font, "Font", "Font", null),
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Bool, "IsEnableKerning", "IsEnableKerning", null),
                    new MemberGuiInfo(ToolElementType.Float, "CharacterSpace", "CharacterSpace", null),
                    new MemberGuiInfo(ToolElementType.Float, "FontSize", "FontSize", null),
                    new MemberGuiInfo(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new MemberGuiInfo(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                    new MemberGuiInfo(ToolElementType.Enum, "WritingDirection", "WritingDirection", null),
                });

            ObjectMappings.Add(typeof(SpriteNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.TextureBase, "Texture", "Texture", null),
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new MemberGuiInfo(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                });

            ObjectMappings.Add(typeof(ShapeNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.TextureBase, "Texture", "Texture", null),
                    new MemberGuiInfo(ToolElementType.Int, "ZOrder", "ZOrder", null),
                    new MemberGuiInfo(ToolElementType.Bool, "IsDrawn", "IsDrawn", null),
                });

            ObjectMappings.Add(typeof(ArcNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Float, "Radius", "Radius", null),
                    new MemberGuiInfo(ToolElementType.Float, "StartDegree", "StartDegree", new Dictionary<string, object>() { { "min", -180f }, {"max", 180f } }),
                    new MemberGuiInfo(ToolElementType.Float, "EndDegree", "EndDegree", new Dictionary<string, object>() { { "min", -180f }, {"max", 180f } }),
                    new MemberGuiInfo(ToolElementType.Int, "VertNum", "VertNum", new Dictionary<string, object>() { { "min", 3 }, {"max", 500 } }),
                });

            ObjectMappings.Add(typeof(CircleNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Float, "Radius", "Radius", null),
                    new MemberGuiInfo(ToolElementType.Int, "VertNum", "VertNum", new Dictionary<string, object>() { { "min", 3 }, {"max", 500 } }),
                });

            ObjectMappings.Add(typeof(LineNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Float, "Thickness", "Thickness", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Point1", "Point1", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Point2", "Point2", null),
                });

            ObjectMappings.Add(typeof(RectangleNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "RectangleSize", "RectangleSize", null),
                });

            ObjectMappings.Add(typeof(TriangleNode),
                new List<MemberGuiInfo>
                {
                    new MemberGuiInfo(ToolElementType.Color, "Color", "Color", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Point1", "Point1", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Point2", "Point2", null),
                    new MemberGuiInfo(ToolElementType.Vector2F, "Point3", "Point3", null),
                });
        }

        public Dictionary<string, MemberGuiInfo> MappingsFromType(Type type)
        {
            var objectMappings = new Dictionary<string, MemberGuiInfo>();
            if (type.BaseType != null)
            {
                var baseMappings = MappingsFromType(type.BaseType);
                foreach (var item in baseMappings)
                {
                    objectMappings[item.Key] = item.Value;
                }
            }

            foreach (var interface_ in type.GetInterfaces())
            {
                var interfaceMappings = MappingsFromType(type.BaseType);
                foreach (var item in interfaceMappings)
                {
                    objectMappings[item.Key] = item.Value;
                }
            }

            if (ObjectMappings.ContainsKey(type))
            {
                var temp = ObjectMappings[type].ToDictionary(obj => obj.Name, obj => obj);

                foreach (var item in temp)
                {
                    objectMappings[item.Key] = temp[item.Key];
                }
            }

            return objectMappings;
        } 
    }
}
