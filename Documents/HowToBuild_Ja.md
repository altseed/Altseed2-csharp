# ビルド手順

## 必須

- .netframework 4.8 (Windows only)

[Download](https://dotnet.microsoft.com/download/visual-studio-sdks)

- .NET SDK 3.0.100

[Download](https://dotnet.microsoft.com/download/dotnet-core/3.0)

- その他: [Coreのdocument](Core/documents/development/HowToBuild_Ja.md)を参照

## Build

### コアの取得

- Windows の場合： `Scripts/Pull.bat` を実行します。

- macOS の場合： `git submodule update --init` を実行して、サブモジュールを更新します。

### コアをビルド

次のスクリプトを実行します。

- Windows の場合： `Scripts/BuildCore.bat`
- macOS の場合： `Scripts/BuildCore_Mac.sh`

### バインディングを生成

スクリプト `Scripts/generate_bindings.py` を実行します。

### エンジンをビルド

#### Windows(Visual Studio)
`Alseed2.sln` を開き Engine をビルドします。

#### Mac(CLI)

Debug
```shell
dotnet build
```
Release
```shell
dotnet build -c Release
```
detail: 
[dotnet build - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-build)