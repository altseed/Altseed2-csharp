# 開発方法

## Core を実装

まずは Core 側 に機能を実装します。 [この辺りを参考に](https://github.com/altseed/Altseed2/blob/master/documents/development/HowToDevelop_Ja.md)。

### Bindingを生成

[やはりこの辺りを参考に](https://github.com/altseed/Altseed2/blob/master/documents/development/HowToDevelop_Ja.md) 、Engine側に公開するメソッドなどについて Binding 定義を追加します。

正しく追加できたかを確認するため、Wrapper を生成したうえで、再度 Core をビルドします。ここでビルドができたらコミットして次に進みます。

### Engine側に取り込み

`git submodule update --init --force --merge --remote -- "Core"` などしてコアを取り込みます。ここで、このあとの記述と混ざらないようにするためいったんコミットしておきます。

### ビルド

[ビルド手順](HowToBuild_Ja.md) を参考に、

- Core のビルド
- Binding の生成
- Engine のビルド

を行います。

### 動作チェック

ここまでで追加したクラスやメソッドが IntelliSense から見えるか、実際にそれを呼び出すようなコードを書いてみて正常に実行できるかをチェックします。

### 単体テストの記述

既存のテストをマネしながら書く。
実行は `テストエクスプローラ` か `dotnet Test` で
