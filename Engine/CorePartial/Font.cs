using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public partial class Font : ISerializable, IDeserializationCallback, ICacheKeeper<Font>
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

        private readonly Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();
        private FontType type;

        /// <summary>
        /// シリアライズされたデータをもとにインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Font(SerializationInfo info, StreamingContext context)
        {
            var path = info.GetString(S_Path);
            type = info.GetValue<FontType>(S_Type);
            textures = info.GetValue<Dictionary<int, Texture2D>>(S_Textures);

            var ptr = IntPtr.Zero;
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

            CacheHelper.CacheHandlingConcurrent(this, ptr);
        }

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Font>> ICacheKeeper<Font>.CacheRepo => cacheRepo;
        
        IntPtr ICacheKeeper<Font>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<Font>.Release(IntPtr native) => cbg_Font_Release(native);
        #endregion

        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Path, GetPath().Substring(2));
            info.AddValue(S_Type, type, typeof(FontType));
            info.AddValue(S_Textures, textures);
            if (type == FontType.Dynamic) info.AddValue(S_Size, Size);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

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
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            foreach (var t in textures) AddImageGlyph(t.Key, t.Value);
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);

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
