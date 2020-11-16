using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Altseed2
{
    public partial class StaticFile
    {
        /// <summary>
        /// 読み込まれたデータを取得します。
        /// </summary>
        public byte[] Buffer
        {
            get { return Int8ArrayBuffer.ToArray(); }
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            StaticFile_Unsetter_Deserialize(info, out var path);
            ptr = cbg_StaticFile_Create(path);
        }

        /// <summary>
        /// 指定パスからファイルを読み込みます。失敗した場合、例外が発生します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる、または使用出来ない文字を含んでいる</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定するパスが見つからない</exception>
        /// <exception cref="SystemException">ファイルが破損または読み込みに失敗</exception>
        /// <returns><paramref name="path"/>をパスに持つファイルのデータを格納した<see cref="StaticFile"/>の新しいインスタンス</returns>
        public static StaticFile CreateStrict(string path)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;

            return Create(path) ?? throw new SystemException("ファイルが破損していたまたは読み込みに失敗しました");
        }

        /// <summary>
        /// 非同期読み込みを行います。
        /// </summary>
        /// <param name="path">読み込むパス</param>
        /// <returns></returns>
        public static async Task<StaticFile> CreateAsync(string path)
        {
            return await Task.Run(() => Create(path));
        }
    }

    public partial class StreamFile
    {
        /// <summary>
        /// 現在読み込まれているデータを取得します。
        /// </summary>
        public byte[] TempBuffer
        {
            get { return Int8ArrayTempBuffer.ToArray(); }
        }

        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            StreamFile_Unsetter_Deserialize(info, out _, out var path);
            ptr = cbg_StreamFile_Create(path);
        }

        partial void OnDeserialize_Method(object sender)
        {
            StreamFile_Unsetter_Deserialize(seInfo, out var position, out _);
            if (position > 0) Read(position);
        }

        /// <summary>
        /// 指定パスからファイルを読み込みます。失敗した場合、例外が発生します。
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる、または使用出来ない文字を含んでいる</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定するパスが見つからない</exception>
        /// <exception cref="SystemException">ファイルが破損または読み込みに失敗</exception>
        /// <returns><paramref name="path"/>をパスに持つファイルのデータを格納した<see cref="StreamFile"/>の新しいインスタンス</returns>
        public static StreamFile CreateStrict(string path)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;

            var result = Create(path) ?? throw new SystemException("ファイルが破損していたまたは読み込みに失敗しました");

            return result;
        }
    }
}
