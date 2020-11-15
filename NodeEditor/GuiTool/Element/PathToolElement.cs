using System;
using System.Reflection;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class PathToolElement : ToolElement
    {
        int MaxLength { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Filter { get; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultPath { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirectory { get; }

        /// <summary>
        /// 
        /// </summary>
        public string RootDirectoryPathPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo RootDirectoryPathPropertyInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetProperty(RootDirectoryPathPropertyName);
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
        /// <param name="isDirectory"></param>
        /// <param name="filter"></param>
        /// <param name="defaultPath"></param>
        /// <param name="maxLength"></param>
        /// <param name="rootDirectoryPathPropertyName"></param>
        public PathToolElement(string name, object source, string propertyName, bool isDirectory = false, string filter = "", string defaultPath = "", int maxLength = 1024, string rootDirectoryPathPropertyName = null) : base(name, source, propertyName)
        {
            MaxLength = maxLength;
            Filter = filter;
            DefaultPath = defaultPath;
            IsDirectory = isDirectory;
            RootDirectoryPathPropertyName = rootDirectoryPathPropertyName;

            if (!typeof(string).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がstring型ではありません");
            }

            if (RootDirectoryPathPropertyName != null && !typeof(string).IsAssignableFrom(RootDirectoryPathPropertyInfo?.PropertyType))
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

            string path = (string)PropertyInfo.GetValue(Source);
            if (path == null)
                path = "";
            string newPath;
            if ((newPath = Engine.Tool.InputText(Name, path, MaxLength, ToolInputTextFlags.None)) != null)
            {
                PropertyInfo.SetValue(Source, newPath);
            }

            if (Engine.Tool.SmallButton("..."))
            {
                if (IsDirectory && (newPath = Engine.Tool.PickFolder(DefaultPath)) != null)
                {
                    SetPath(newPath);
                }
                else if ((newPath = Engine.Tool.OpenDialog(Filter, DefaultPath)) != null)
                {
                    SetPath(newPath);
                }
            }
        }

        private void SetPath(string newPath)
        {
            try
            {
                if (RootDirectoryPathPropertyInfo != null)
                {
                    var uri = new Uri((string)RootDirectoryPathPropertyInfo.GetValue(Source));
                    var newPathUri = new Uri(newPath);
                    newPath = uri.MakeRelativeUri(newPathUri).ToString();
                }
                PropertyInfo.SetValue(Source, newPath);
            }
            catch (Exception e)
            {
                Engine.Log.Error(LogCategory.User, e.Message);
                Engine.Log.Error(LogCategory.User, e.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static PathToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var isDirectory = guiInfo.Options.ContainsKey("isDirectory") ? (bool)guiInfo.Options["isDirectory"] : false;
            var filter = guiInfo.Options.ContainsKey("filter") ? (string)guiInfo.Options["filter"] : "";
            var defaultPath = guiInfo.Options.ContainsKey("defaultPath") ? (string)guiInfo.Options["defaultPath"] : "";
            var maxLength = guiInfo.Options.ContainsKey("maxLength") ? (int)guiInfo.Options["maxLength"] : 1024;
            var rootDirectoryPathPropertyName = guiInfo.Options.ContainsKey("rootDirectoryPathPropertyName") ? (string)guiInfo.Options["rootDirectoryPathPropertyName"] : null;
            return new PathToolElement(guiInfo.Name, source, guiInfo.PropertyName, isDirectory, filter, defaultPath, maxLength, rootDirectoryPathPropertyName);
        }
    }
}
