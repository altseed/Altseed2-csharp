using System;

namespace Altseed2
{
    /// <summary>
    /// <see cref="Color"/>向けUI
    /// </summary>
    public class ColorToolElement : ToolElement
    {
        /// <summary>
        ///　
        /// </summary>
        public ToolColorEditFlags Flags { get; }

        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="source">バインディング対象オブジェクト</param>
        /// <param name="propertyName">バインディング対象プロパティ名</param>
        /// <param name="flags"></param>
        public ColorToolElement(string name, object source, string propertyName, ToolColorEditFlags flags = ToolColorEditFlags.AlphaBar) : base(name, source, propertyName)
        {
            Flags = flags;

            if (!typeof(Color).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がColor型ではありません");
            }
        }

        /// <inheritdoc/>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            Color color = (Color)PropertyInfo.GetValue(Source);
            if (Engine.Tool.ColorEdit4(Name, ref color, Flags))
            {
                PropertyInfo.SetValue(Source, color);
            }
        }

        /// <summary>
        /// <see cref="ToolElementTreeFactory.ObjectMapping"/>から<see cref="ColorToolElement"/>を作成します。
        /// </summary>
        /// <param name="source">バインディング対象</param>
        /// <param name="guiInfo"></param>
        /// <returns></returns>
        public static ColorToolElement Create(object source, MemberGuiInfo guiInfo)
        {
            var flags = guiInfo.Options.ContainsKey("flags") ? (ToolColorEditFlags)guiInfo.Options["flags"] : ToolColorEditFlags.AlphaBar;
            return new ColorToolElement(guiInfo.Name, source, guiInfo.PropertyName, flags);
        }
    }
}
