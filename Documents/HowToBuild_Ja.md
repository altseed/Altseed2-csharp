## 必須
- .NET SDK 3.0.100

- その他: [Coreのdocument](Core/documents/development/HowToBuild_Ja.md)を参照

## Build

### Windows

いまのところ。Core周りのビルドとかも自動化したいよね。

1. `git submodule update --init --recursive` を実行
1. `Scripts/generate_bindings.py` を実行
1. `Core/scripts/GenerateProjects(_x64_).bat もしくは .sh`を実行
1. `Core/build/Altseed.sln` を開きビルド
1. `Alseed2.sln` を開きビルド


### Mac?

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