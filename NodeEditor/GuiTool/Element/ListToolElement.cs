using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public string SelectedItemIndexPropertyName { get; }

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
        public PropertyInfo SelectedItemIndexPropertyInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetProperty(SelectedItemIndexPropertyName);
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
        public ListToolElement(string name, object source, string propertyName, string listElementPropertyName = null, string selectedItemPropertyName = null, string addMethodName = null, string removeMethodName = null, string selectedItemIndexPropertyName = null) : base(name, source, propertyName)
        {
            ListElementPropertyName = listElementPropertyName;
            SelectedItemPropertyName = selectedItemPropertyName;
            AddMethodName = addMethodName;
            RemoveMethodName = removeMethodName;
            SelectedItemIndexPropertyName = selectedItemIndexPropertyName;

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

            if (SelectedItemIndexPropertyName != null && !typeof(int).IsAssignableFrom(SelectedItemIndexPropertyInfo?.PropertyType))
            {
                throw new ArgumentException("SelectedIndexItemがint型ではありません");
            }

            SelectedItemIndexPropertyInfo?.SetValue(Source, current);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            IList list = (IList)PropertyInfo.GetValue(Source);

            if (list == null)
                return;

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

                SelectedItemIndexPropertyInfo?.SetValue(Source, current);
            }

            if (AddMethodInfo != null && Engine.Tool.SmallButton("+"))
            {
                AddMethodInfo?.Invoke(Source, new object[] { Current });
                if (RemoveMethodInfo != null)
                    Engine.Tool.SameLine(0, -1);
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
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static ListToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var listElementPropertyName = guiInfo.Options.ContainsKey("listElementPropertyName") ? (string)guiInfo.Options["listElementPropertyName"] : null;
            var selectedItemPropertyName = guiInfo.Options.ContainsKey("selectedItemPropertyName") ? (string)guiInfo.Options["selectedItemPropertyName"] : null;
            var addMethodName = guiInfo.Options.ContainsKey("addMethodName") ? (string)guiInfo.Options["addMethodName"] : null;
            var removeMethodName = guiInfo.Options.ContainsKey("removeMethodName") ? (string)guiInfo.Options["removeMethodName"] : null;
            var selectedItemIndexPropertyName = guiInfo.Options.ContainsKey("selectedItemIndexPropertyName") ? (string)guiInfo.Options["selectedItemIndexPropertyName"] : null;
            return new ListToolElement(guiInfo.Name, source, guiInfo.PropertyName, listElementPropertyName, selectedItemPropertyName, addMethodName, removeMethodName, selectedItemIndexPropertyName);
        }
    }
}
