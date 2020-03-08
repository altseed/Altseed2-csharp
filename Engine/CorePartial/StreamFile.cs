using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public sealed partial class StreamFile : ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_CurrentPosition = "S_CurrentPosition";
        private const string S_Path = "S_Path";
        #endregion

        private SerializationInfo seInfo;

        private StreamFile(SerializationInfo info, StreamingContext context)
        {
            var path = info.GetString(S_Path);
            var ptr = cbg_StreamFile_Create(path);

            if (ptr == IntPtr.Zero) throw new SerializationException("読み込みに失敗しました");

            selfPtr = ptr;
            cacheRepo.TryAdd(ptr, new WeakReference<StreamFile>(this));
            seInfo = info;
        }

        /// <summary>
        /// 指定パスからファイルを読み込む
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

        /// <summary>
        /// 指定パスからファイルを読み込む
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="result"><paramref name="path"/>をパスに持つファイルのデータを格納した<see cref="StreamFile"/>の新しいインスタンス 読み込めなかったらnull</param>
        /// <returns><paramref name="result"/>を正常に読み込めたらtrue、それ以外でfalse</returns>
        public static bool TryCreate(string path, out StreamFile result)
        {
            if (IOHelper.CheckLoadPath(path) == null && (result = Create(path)) != null) return true;
            else
            {
                result = null;
                return false;
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_Path, GetPath().Substring(2));
            info.AddValue(S_CurrentPosition, CurrentPosition);
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var position = seInfo.GetInt32(S_CurrentPosition);
            if (position > 0) Read(position);

            seInfo = null;
        }

        /// <summary>
        /// 指定したパスに保存する
        /// </summary>
        /// <param name="path">保存するパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は使用できない文字を使用している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>で指定したディレクトリが存在しない</exception>
        /// <exception cref="IOException">I/Oに失敗した</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="System.Security.SecurityException">アクセスが拒否された</exception>
        public void Save(string path)
        {
            using var stream = new FileStream(path, FileMode.Create);
            var buffer = TempBuffer;
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
