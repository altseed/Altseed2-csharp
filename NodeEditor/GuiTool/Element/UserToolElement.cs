using System;
using System.Reflection;

namespace Altseed2
{
    /// <summary>
    /// 
    /// </summary>
    public class UserToolElement : ToolElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo MethodInfo
        {
            get
            {
                try
                {
                    return Source?.GetType().GetMethod(MethodName);
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
        /// <param name="methodName"></param>
        public UserToolElement(string name, object source, string methodName) : base(name, source, null)
        {
            MethodName = methodName;
            if (MethodInfo?.GetParameters().Length != 0)
            {
                throw new ArgumentException("参照するメソッドに引数を入れることはできません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            base.Update();
            Engine.Tool.PushID(MethodInfo.GetHashCode());
            MethodInfo?.Invoke(Source, new object[] { });
            Engine.Tool.PopID();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static UserToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            return new UserToolElement(guiInfo.Name, source, guiInfo.PropertyName);
        }
    }
}
