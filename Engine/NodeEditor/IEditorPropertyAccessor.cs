using System;
using System.Reactive;

namespace Altseed2
{
    // TODO: データの更新に関するプロパティと、GUIの描画に関するプロパティは別のインターフェースに分けたい
    internal interface IEditorPropertyAccessor
    {
        object Selected { get; set; }
        float MenuHeight { get; }

        IObservable<Unit> OnSelectedNodeChanged { get; }

        TextureBaseToolElement TextureBrowserTarget { get; set; }
        FontToolElement FontBrowserTarget { get; set; }
    }
}
