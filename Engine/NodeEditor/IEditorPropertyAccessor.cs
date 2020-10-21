namespace Altseed2
{
    // TODO: データの更新に関するプロパティと、GUIの描画に関するプロパティは別のインターフェースに分けたい
    internal interface IEditorPropertyAccessor
    {
        object Selected { get; set; }
        float MenuHeight { get; }
    }
}
