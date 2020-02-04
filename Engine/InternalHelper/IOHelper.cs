using System;
using System.IO;
using System.Linq;

namespace Altseed
{
    internal static class IOHelper
    {
        private static char[] InvalidChars => _invalidChars ?? (_invalidChars = Path.GetInvalidPathChars());
        private static char[] _invalidChars;
        internal static Exception CheckLoadPath(string path)
        {
            if (path == null) return new ArgumentNullException("引数がnullです", nameof(path));
            if (string.IsNullOrWhiteSpace(path)) return new ArgumentException("パスが空白文字のみからなります", nameof(path));
            if (ContainsInvalidChar(path)) return new ArgumentException("パスに不正な文字が含まれています", nameof(path));
            if (IsTooLongPath(path)) return new PathTooLongException("パスが長すぎます");
            if (!Engine.File.Exists(path)) return new FileNotFoundException("指定したパスのファイルが見つかりませんでした", path);
            return null;
        } 
        internal static Exception CheckSavePath(string path)
        {
            if (path == null) return new ArgumentNullException("引数がnullです", nameof(path));
            if (string.IsNullOrWhiteSpace(path)) return new ArgumentException("パスが空白文字のみからなります", nameof(path));
            if (ContainsInvalidChar(path)) return new ArgumentException("パスに不正な文字が含まれています", nameof(path));
            if (IsTooLongPath(path)) return new PathTooLongException("パスが長すぎます");
            if (!Directory.Exists(Path.GetDirectoryName(path))) return new DirectoryNotFoundException($"指定したパスのディレクトリが見つかりませんでした：{Path.GetDirectoryName(path)}");
            return null;
        } 
        internal static bool ContainsInvalidChar(string path)
        {
            if (path == null) throw new ArgumentNullException("引数がnullです", nameof(path));
            for (int i = 0; i < path.Length; i++)
                if (InvalidChars.Contains(path[i]))
                    return true;
            return false;
        }
        internal static bool IsTooLongPath(string path)
        {
            if (path == null) throw new ArgumentNullException("引数がnullです", nameof(path));
            if (path.Length >= 260) return true;
            return Path.GetFileName(path).Length >= 246;
        }
    }
}
