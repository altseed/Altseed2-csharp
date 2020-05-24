using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            Texture2D_Unsetter_Deserialize(info, out var path);
            ptr = cbg_Texture2D_Load(path);
        }

        /// <summary>
        /// 非同期読み込みを行う
        /// </summary>
        /// <param name="path">読み込むパス</param>
        /// <returns></returns>
        public static async Task<Texture2D> LoadAsync(string path)
        {
            return await Task.Run(() => Load(path));
        }
    }

    public partial class RenderTexture
    {
        #region SerializeName
        private const string S_Size = "S_Size";
        #endregion

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            ptr = cbg_RenderTexture_Create(info.GetValue<Vector2I>(S_Size));
        }
    }
}
