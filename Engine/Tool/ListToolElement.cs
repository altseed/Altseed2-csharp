using Altseed2;
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
    public class ListToolElement : ToolElement
    {
        private int current = -1;

        /// <summary>
        /// 
        /// </summary>
        public string ListElementPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedItemPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string AddMethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string RemoveMethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Current { get => current; set => current = value; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo SelectedItemPropertyInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetProperty(SelectedItemPropertyName);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo AddMethodInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetMethod(AddMethodName);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo RemoveMethodInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetMethod(RemoveMethodName);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="listElementPropertyName"></param>
        /// <param name="selectedItemPropertyName"></param>
        /// <param name="addMethodName"></param>
        /// <param name="removeMethodName"></param>
        public ListToolElement(string name, object source, string propertyName, string listElementPropertyName = null, string selectedItemPropertyName = null, string addMethodName = null, string removeMethodName = null) : base(name, source, propertyName)
        {
            ListElementPropertyName = listElementPropertyName;
            SelectedItemPropertyName = selectedItemPropertyName;
            AddMethodName = addMethodName;
            RemoveMethodName = removeMethodName;

            if (!typeof(IList).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がICollection型ではありません");
            }

            if (ListElementPropertyName != null && !typeof(string).IsAssignableFrom(PropertyInfo.PropertyType.GetGenericArguments()[0].GetProperty(ListElementPropertyName).PropertyType))
            {
                throw new ArgumentException("Listの各要素の表示名がstring型ではありません");
            }

            if (SelectedItemPropertyName != null && !(SelectedItemPropertyInfo?.PropertyType.IsAssignableFrom(PropertyInfo?.PropertyType.GetGenericArguments()[0]) ?? false))
            {
                throw new ArgumentException("SelectedItemにListの要素を代入することができません");
            }

            if (AddMethodName != null && (AddMethodInfo?.GetParameters().Length != 1 || !typeof(int).IsAssignableFrom(AddMethodInfo?.GetParameters()[0].ParameterType)))
            {
                throw new ArgumentException("AddMethodNameはvoid(int)のメソッドを指定してください");
            }

            if (RemoveMethodName != null && (RemoveMethodInfo?.GetParameters().Length != 1 || !typeof(int).IsAssignableFrom(RemoveMethodInfo?.GetParameters()[0].ParameterType)))
            {
                throw new ArgumentException("RemoveMethodNameはvoid(int)のメソッドを指定してください");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            IList list = (IList)PropertyInfo.GetValue(Source);
            List<string> names;
            if (ListElementPropertyName == null)
            {
                names = list.OfType<object>().Select(obj => obj.ToString()).ToList();
            }
            else
            {
                names = list.OfType<object>().Select(obj => (string)obj.GetType().GetProperty(ListElementPropertyName).GetValue(obj)).ToList();
            }

            if (Engine.Tool.ListBox(Name, ref current, names, names.Count))
            {
                if (current >= 0 && current < list.Count)
                    SelectedItemPropertyInfo?.SetValue(Source, list[current]);
            }

            if (AddMethodInfo != null && Engine.Tool.SmallButton("+"))
            {
                AddMethodInfo?.Invoke(Source, new object[] { Current });
                if (RemoveMethodInfo != null)
                    Engine.Tool.SameLine();
            }

            if (RemoveMethodInfo != null)
            {
                if (Engine.Tool.SmallButton("-"))
                {
                    RemoveMethodInfo?.Invoke(Source, new object[] { Current });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static ListToolElement Create(object source, ToolElementManager.ObjectMapping objectMapping)
        {
            var listElementPropertyName = objectMapping.Options.ContainsKey("listElementPropertyName") ? (string)objectMapping.Options["listElementPropertyName"] : null;
            var selectedItemPropertyName = objectMapping.Options.ContainsKey("selectedItemPropertyName") ? (string)objectMapping.Options["selectedItemPropertyName"] : null;
            var addMethodName = objectMapping.Options.ContainsKey("addMethodName") ? (string)objectMapping.Options["addMethodName"] : null;
            var removeMethodName = objectMapping.Options.ContainsKey("removeMethodName") ? (string)objectMapping.Options["removeMethodName"] : null;
            return new ListToolElement(objectMapping.Name, source, objectMapping.PropertyName, listElementPropertyName, selectedItemPropertyName, addMethodName, removeMethodName);
        }
    }
}
