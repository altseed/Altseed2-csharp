using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="bool"/>向けチェックボックス
    /// </summary>
    public class BoolToolElement : ToolElement
    {
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="source">バインディング対象オブジェクト</param>
        /// <param name="propertyName">バインディング対象プロパティ名</param>
        public BoolToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!typeof(bool).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がbool型ではありません");
            }
        }

        /// <inheritdoc/>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            bool flag = (bool)PropertyInfo.GetValue(Source);
            if (Engine.Tool.Checkbox(Name, ref flag))
            {
                PropertyInfo.SetValue(Source, flag);
            }
        }

        /// <summary>
        /// <see cref="MemberGuiInfo"/>から<see cref="BoolToolElement"/>を作成します。
        /// </summary>
        /// <param name="source">バインディング対象</param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static BoolToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            return new BoolToolElement(guiInfo.Name, source, guiInfo.PropertyName);
        }
    }
}
