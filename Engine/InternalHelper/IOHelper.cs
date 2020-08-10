using System;
using System.IO;

namespace Altseed2
{
    internal static class IOHelper
    {
        private static char[] InvalidChars => _invalidChars ??= Path.GetInvalidPathChars();
        private static char[] _invalidChars;
        /// <summary>
        /// <see cref="ArgumentException"/>
        /// <see cref="ArgumentNullException"/>
        /// <see cref="PathTooLongException"/>
        /// <see cref="FileNotFoundException"/>
        /// </summary>
        internal static Exception CheckLoadPath(string path)
        {
            if (path == null) return new ArgumentNullException(nameof(path), "引数がnullです");
            if (string.IsNullOrWhiteSpace(path)) return new ArgumentException("パスが空白文字のみからなります", nameof(path));
            if (ContainsInvalidChar(path)) return new ArgumentException("パスに不正な文字が含まれています", nameof(path));
            if (IsTooLongPath(path)) return new PathTooLongException("パスが長すぎます");
            if (!Engine.File.Exists(path)) return new FileNotFoundException($"指定したパスのファイルが見つかりませんでした\nパス：{path}", path);
            return null;
        }
        /// <summary>
        /// <see cref="ArgumentException"/>
        /// <see cref="ArgumentNullException"/>
        /// <see cref="PathTooLongException"/>
        /// <see cref="DirectoryNotFoundException"/>
        /// </summary>
        internal static Exception CheckSavePath(string path)
        {
            if (path == null) return new ArgumentNullException(nameof(path), "引数がnullです");
            if (string.IsNullOrWhiteSpace(path)) return new ArgumentException("パスが空白文字のみからなります", nameof(path));
            if (ContainsInvalidChar(path)) return new ArgumentException("パスに不正な文字が含まれています", nameof(path));
            if (IsTooLongPath(path)) return new PathTooLongException("パスが長すぎます");
            if (!Directory.Exists(Path.GetDirectoryName(path))) return new DirectoryNotFoundException($"指定したパスのディレクトリが見つかりませんでした\nディレクトリ：{Path.GetDirectoryName(path)}");
            return null;
        }
        internal static bool ContainsInvalidChar(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            return path.IndexOfAny(InvalidChars) >= 0;
        }
        internal static bool IsTooLongPath(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path), "引数がnullです");
            if (path.Length >= 260) return true;
            return Path.GetFileName(path).Length >= 246;
        }
    }
}
