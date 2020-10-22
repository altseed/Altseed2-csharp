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
        private readonly ToolElementFactory _toolElementFactory;

        public ToolElementManager()
        {
            _toolElementFactory = new ToolElementFactory(this);
        }

        public GuiInfoRepository GuiInfoRepository { get; } = new GuiInfoRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<ToolElement> CreateToolElements(object source)
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
        private Dictionary<string, ToolElement> CreateToolElementsAuto(object source)
        {
            Dictionary<string, ToolElement> res = new Dictionary<string, ToolElement>();

            foreach (var info in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                try
                {
                    if (System.Attribute.IsDefined(info, typeof(ToolHiddenAttribute)))
                        continue;

                    if (_toolElementFactory.FromPropertyMetadata(info, source) is {} element)
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

        private Dictionary<string, ToolElement> CreateToolElementsFromPropetyAttributes(object source)
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
                        if (_toolElementFactory.FromPropertyAttribute(toolAttribute, info, source) is {} element)
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
                        if (_toolElementFactory.FromMethodAttribute(commandAttribute, info, source) is {} element)
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

        private Dictionary<string, ToolElement> CreateToolElementsFromObjectMappings(object source)
        {
            return GuiInfoRepository.MappingsFromType(source.GetType())
                .Select(pair =>
                {
                    try
                    {
                        return (pair.Key, value: _toolElementFactory.FromObjectMapping(source, pair.Value));
                    }
                    catch (Exception e)
                    {
                        Engine.Log.Error(LogCategory.User, e.Message);
                        Engine.Log.Error(LogCategory.User, e.StackTrace);
                        return (pair.Key, value: null);
                    }
                })
                .Where(pair => pair.value != null)
                .ToDictionary(pair => pair.Key, pair => pair.value);
        }
    }
}