using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    public partial class Texture2D
    {
        /// <summary>
        /// 指定パスからテクスチャを読み込む
        /// </summary>
        /// <param name="path">読み込むテクスチャのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる、または使用出来ない文字を含んでいる</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたテクスチャが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定するパスが見つからない</exception>
        /// <exception cref="SystemException">テクスチャが破損または読み込みに失敗</exception>
        /// <returns><paramref name="path"/>をパスに持つテクスチャのデータを格納した<see cref="Texture2D"/>の新しいインスタンス</returns>
        public static Texture2D LoadStrict(string path)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;

            return Load(path) ?? throw new SystemException("ファイルが破損していたまたは読み込みに失敗しました");
        }

        /// <summary>
        /// 指定パスからテクスチャを読み込む
        /// </summary>
        /// <param name="path">読み込むテクスチャのパス</param>
        /// <param name="result"><paramref name="path"/>をパスに持つテクスチャのデータを格納した<see cref="Texture2D"/>の新しいインスタンス 読み込めなかったらnull</param>
        /// <returns><paramref name="result"/>を正常に読み込めたらtrue、それ以外でfalse</returns>
        public static bool TryLoad(string path, out Texture2D result)
        {
            if (IOHelper.CheckLoadPath(path) == null && (result = Load(path)) != null) return true;
            else
            {
                result = null;
                return false;
            }
        }
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            var path = seInfo.GetString(S_Path);
            ptr = cbg_Texture2D_Load(path);
        }
    }
}
