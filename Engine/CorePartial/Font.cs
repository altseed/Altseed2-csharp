using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public partial class Font : ISerializable
    {
        [Serializable]
        private enum FontType : int
        {
            Dynamic,
            Static
        }
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_Path = "S_Path";
        private const string S_Size = "S_Size";
        private const string S_Type = "S_Type";
        #endregion

        private string path;
        private FontType type;

        /// <summary>
        /// シリアライズされたデータをもとにインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Font(SerializationInfo info, StreamingContext context)
        {
            path = info.GetString(S_Path);
            type = info.GetValue<FontType>(S_Type);

            var ptr = IntPtr.Zero;
            switch (type)
            {
                case FontType.Dynamic:
                    var size = info.GetInt32(S_Size);
                    var color = info.GetValue<Color>(S_Color);
                    ptr = cbg_Font_LoadDynamicFont(path, size, ref color);
                    break;
                case FontType.Static:
                    ptr = cbg_Font_LoadStaticFont(path);
                    break;
            }

            if (ptr == IntPtr.Zero) throw new SerializationException("フォントの生成に失敗しました");

            selfPtr = ptr;
            cacheRepo.TryAdd(ptr, new WeakReference<Font>(this));
        }

        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            info.AddValue(S_Path, path);
            info.AddValue(S_Type, type, typeof(FontType));
            if (type == FontType.Dynamic)
            {
                info.AddValue(S_Size, Size);
                info.AddValue(S_Color, Color, typeof(Color));
            }
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

        /// <summary>
        /// 動的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="color">フォントの色</param>
        /// <returns>動的に生成されるフォント</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定したファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SystemException">ファイルが破損していたまたは読み込みに失敗した</exception>
        public static Font LoadDynamicFontStrict(string path, int size, Color color)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException("サイズは正の値にしてください", nameof(size));
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            var result = LoadDynamicFont(path, size, ref color) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
            result.path = path;
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
            result.path = path;
            result.type = FontType.Static;
            return result;
        }

        /// <summary>
        /// 動的にフォントを読み込む
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="color">フォントの色</param>
        /// <param name="result">動的に生成されるフォント 生成できなかったらnull</param>
        /// <returns><paramref name="result"/>を生成出来たらtrue，それ以外でfalse</returns>
        public static bool TryLoadDynamicFont(string path, int size, Color color, out Font result)
        {
            if (size > 0 && IOHelper.CheckLoadPath(path) == null && (result = LoadDynamicFont(path, size, ref color)) != null)
            {
                result.path = path;
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
                result.path = path;
                result.type = FontType.Static;
                return true;
            }
            result = null;
            return false;
        }
    }
}
