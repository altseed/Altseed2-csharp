# ビルド手順

## 必須
- [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

- その他: [Coreのdocument](Core/documents/development/HowToBuild_Ja.md)を参照

## Build

### コアの取得

- Windows の場合： `Scripts/Pull.bat` を実行します。

- Mac/Linux の場合： `Scripts/Pull.sh` を実行します。

### コアをビルド

次のスクリプトを実行します。

- Windows の場合： `Scripts/BuildCore.bat`
- Mac/Linux の場合： `Scripts/BuildCore_Mac.sh`

### バインディングを生成

スクリプト `Scripts/generate_bindings.py` を実行します。

### エンジンをビルド

#### Visual Studio
`Alseed2.sln` を開き Engine をビルドします。

#### CLI

Debug
```shell
dotnet build Altseed2.sln
```
Release
```shell
dotnet build Altseed2.sln -c Release
```
detail: 
[dotnet build - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-build)
