using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Altseed2.GuiTool.Factory;
using Altseed2.GuiTool.Repository;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class ToolElementManager
    {
        private static readonly ToolElementFactory ToolElementFactory = new ToolElementFactory();
        public static readonly GuiInfoRepository GuiInfoRepository = new GuiInfoRepository();
        
        /// <summary>
        /// 
        /// </summary>
        public static void SetAltseed2DefaultObjectMapping()
        {
            GuiInfoRepository.SetAltseed2DefaultObjectMapping();
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

                    if (ToolElementFactory.FromPropertyMetadata(info, source) is {} element)
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
                        if (ToolElementFactory.FromPropertyAttribute(toolAttribute, info, source) is {} element)
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
                        if (ToolElementFactory.FromMethodAttribute(commandAttribute, info, source) is {} element)
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
            var res = new Dictionary<string, ToolElement>();
            var objectMappings = GuiInfoRepository.MappingsFromType(source.GetType());

            foreach (var (name, objectMapping) in objectMappings)
            {
                try
                {
                    res[name] = ToolElementFactory.FromObjectMapping(source, objectMapping);
                }
                catch (Exception e)
                {
                    Engine.Log.Error(LogCategory.User, e.Message);
                    Engine.Log.Error(LogCategory.User, e.StackTrace);
                }
            }

            return res;
        }
    }
}