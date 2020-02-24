﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public sealed partial class StreamFile : ISerializable
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion

        private string path;

        private StreamFile(SerializationInfo info, StreamingContext context)
        {
            var path = info.GetString(S_Path);
            var ptr = cbg_StreamFile_Create(path);

            if (ptr == IntPtr.Zero) throw new SerializationException("読み込みに失敗しました");

            selfPtr = ptr;
            cacheRepo.TryAdd(ptr, new WeakReference<StreamFile>(this));
            this.path = path;
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

            result.path = path;
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
            if (IOHelper.CheckLoadPath(path) == null && (result = Create(path)) != null)
            {
                result.path = path;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_Path, path);
        }
    }
}
