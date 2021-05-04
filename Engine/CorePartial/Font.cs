using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed2
{
    public partial class Font
    {
        #region SerializeName
        private const string S_Textures = "S_Textures";
        #endregion

        public const int DefaultSamplingSize = 64;

        private Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            Font_Unsetter_Deserialize(info, out var samplingSize, out var isStatic, out var path);
            ptr = isStatic ? cbg_Font_LoadStaticFont(path) : cbg_Font_LoadDynamicFont(path, samplingSize);
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Textures, textures);
        }

        partial void OnDeserialize_Method(object sender)
        {
            textures = seInfo.GetValue<Dictionary<int, Texture2D>>(S_Textures);
            foreach (var t in textures) AddImageGlyph(t.Key, t.Value);
        }

        /// <summary>
        /// フォントファイルを読み込んでFontの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込むフォントのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static Font LoadDynamicFont(string path, int samplingSize = DefaultSamplingSize)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            var ret = cbg_Font_LoadDynamicFont(path, samplingSize);
            return Font.TryGetFromCache(ret);
        }

        /// <summary>
        /// a2fフォントを生成します。
        /// </summary>
        /// <param name="dynamicFontPath">読み込むtruetypeフォントのパス</param>
        /// <param name="staticFontPath">生成するa2fフォントのパス</param>
        /// <param name="characters">フォント化させる文字列</param>
        /// <exception cref="ArgumentNullException"><paramref name="dynamicFontPath"/>, <paramref name="staticFontPath"/>, <paramref name="characters"/>のいずれかがnull</exception>
        public static bool GenerateFontFile(string dynamicFontPath, string staticFontPath, string characters, int samplingSize = DefaultSamplingSize)
        {
            if (dynamicFontPath == null) throw new ArgumentNullException(nameof(dynamicFontPath), "引数がnullです");
            if (staticFontPath == null) throw new ArgumentNullException(nameof(staticFontPath), "引数がnullです");
            if (characters == null) throw new ArgumentNullException(nameof(characters), "引数がnullです");
            var ret = cbg_Font_GenerateFontFile(dynamicFontPath, staticFontPath, samplingSize, characters);
            return ret;
        }

        /// <summary>
        /// フォントファイルを読み込んで<see cref="Font"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="samplingSize">MSDFのサンプリングサイズ</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="samplingSize"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定したファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SystemException">ファイルが破損していたまたは読み込みに失敗した</exception>
        /// <returns><paramref name="path"/>の指定するファイルから生成されたフォント</returns>
        public static Font LoadDynamicFontStrict(string path, int samplingSize = DefaultSamplingSize)
        {
            if (samplingSize <= 0) throw new ArgumentOutOfRangeException(nameof(samplingSize), $"サイズは正の値にしてください\n実際の値：{samplingSize}");
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            return LoadDynamicFont(path, samplingSize) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
        }

        /// <summary>
        /// FontGeneratorで生成したフォントを読み込んでFontの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定したファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SystemException">ファイルが破損していたまたは読み込みに失敗した</exception>
        /// <returns><paramref name="path"/>の指定するファイルから生成されたフォント</returns>
        public static Font LoadStaticFontStrict(string path)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            return LoadStaticFont(path) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
        }

        /// <summary>
        /// テクスチャ文字を追加します。
        /// </summary>
        /// <param name="character">文字</param>
        /// <param name="texture">テクスチャ</param>
        public void AddImageGlyph(char character, Texture2D texture)
        {
            textures[character] = texture;
            AddImageGlyph((int)character, texture);
        }
    }
}
