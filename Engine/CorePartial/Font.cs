using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class Font
    {
        [Serializable]
        private enum FontType : int
        {
            Dynamic,
            Static
        }

        #region SerializeName
        private const string S_Path = "S_Path";
        private const string S_Size = "S_Size";
        private const string S_Textures = "S_Textures";
        private const string S_Type = "S_Type";
        #endregion

        private Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();
        private FontType type;

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            var path = info.GetString(S_Path);
            type = info.GetValue<FontType>(S_Type);

            switch (type)
            {
                case FontType.Dynamic:
                    var size = info.GetInt32(S_Size);
                    ptr = cbg_Font_LoadDynamicFont(path, size);
                    break;
                case FontType.Static:
                    ptr = cbg_Font_LoadStaticFont(path);
                    break;
            }      
        }

        partial void OnGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(S_Path, Path.Substring(2));
            info.AddValue(S_Type, type, typeof(FontType));
            info.AddValue(S_Textures, textures);
            if (type == FontType.Dynamic) info.AddValue(S_Size, Size);      
        }

        partial void OnDeserialize_Method(object sender)
        {
            textures = seInfo.GetValue<Dictionary<int, Texture2D>>(S_Textures);
            foreach (var t in textures) AddImageGlyph(t.Key, t.Value);            
        }

        /// <summary>
        /// 動的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="size">フォントサイズ</param>
        /// <returns>動的に生成されるフォント</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定したファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SystemException">ファイルが破損していたまたは読み込みに失敗した</exception>
        public static Font LoadDynamicFontStrict(string path, int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException("サイズは正の値にしてください", nameof(size));
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            var result = LoadDynamicFont(path, size) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
            result.type = FontType.Dynamic;
            return result;
        }

        /// <summary>
        /// 静的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <returns>静的に生成されるフォント</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定したファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SystemException">ファイルが破損していたまたは読み込みに失敗した</exception>
        public static Font LoadStaticFontStrict(string path)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            var result = LoadStaticFont(path) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
            result.type = FontType.Static;
            return result;
        }

        /// <summary>
        /// 動的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="result">動的に生成されるフォント 生成できなかったらnull</param>
        /// <returns><paramref name="result"/>を生成出来たらtrue，それ以外でfalse</returns>
        public static bool TryLoadDynamicFont(string path, int size, out Font result)
        {
            if (size > 0 && IOHelper.CheckLoadPath(path) == null && (result = LoadDynamicFont(path, size)) != null)
            {
                result.type = FontType.Dynamic;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// 静的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="result">静的に生成されるフォント 生成できなかったらnull</param>
        /// <returns><paramref name="result"/>を生成出来たらtrue，それ以外でfalse</returns>
        public static bool TryLoadStaticFont(string path, out Font result)
        {
            if (IOHelper.CheckLoadPath(path) == null && (result = LoadStaticFont(path)) != null)
            {
                result.type = FontType.Static;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// テクスチャ文字を追加する
        /// </summary>
        /// <param name="character">文字</param>
        /// <param name="texture">テクスチャ</param>
        public void AddImageGlyph(char character, Texture2D texture)
        {
            if (textures.ContainsKey(character)) textures[character] = texture;
            else textures.Add(character, texture);
            AddImageGlyph((int)character, texture);
        }
    }
}
