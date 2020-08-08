# NuGet パッケージ更新方法

# nuspec ファイルを更新しパッケージを取得

`Nuget\Altseed2.nuspec` を開き、バージョン番号を更新する。

```
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd">
    <metadata>
        <id>Altseed2</id>
        <version>0.0.3-alpha</version> // <- ココ！
        <title>Altseed2</title>
        <authors>Altseed</authors>
```

version の値は適切にインクリメントする。

それを commit & push して CI でのパッケージ生成が完了するのを待って `nuget.zip` をダウンロードし解凍。

# NuGet に提出

1. NuGet Gallery にログインする。
1. https://www.nuget.org/packages/manage/upload
1. `nuget.zip` の中の .nuget ファイルをアップロード
1. Submit !!
