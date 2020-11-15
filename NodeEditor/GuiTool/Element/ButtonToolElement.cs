using System;
using System.Reflection;

namespace Altseed2
{
    /// <summary>
    /// メソッド実行ボタン
    /// </summary>
    public class ButtonToolElement : ToolElement
    {
        /// <summary>
        /// メソッド名
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// MethodNameに対する<see cref="System.Reflection.MethodInfo"/>
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
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="source">バインディング対象オブジェクト</param>
        /// <param name="methodName">バインディング対象プロパティ名</param>
        public ButtonToolElement(string name, object source, string methodName) : base(name, source, null)
        {
            MethodName = methodName;
            if (MethodInfo?.GetParameters().Length != 0)
            {
                throw new ArgumentException("参照するメソッドに引数を入れることはできません");
            }
        }

        /// <inheritdoc/>
        public override void Update()
        {
            base.Update();

            if (Source == null || MethodInfo == null) return;

            if (Engine.Tool.Button(Name))
            {
                MethodInfo?.Invoke(Source, new object[] { });
            }
        }

        /// <summary>
        /// <see cref="ToolElementTreeFactory.ObjectMapping"/>から<see cref="BoolToolElement"/>を作成します。
        /// </summary>
        /// <param name="source">バインディング対象</param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static ButtonToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            return new ButtonToolElement(guiInfo.Name, source, guiInfo.PropertyName);
        }
    }
}
