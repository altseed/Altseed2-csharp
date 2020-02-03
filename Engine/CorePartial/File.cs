using System;
using System.IO;

namespace Altseed
{
    /// <summary>
    /// ファイルを制御するクラス
    /// </summary>
    public partial class File
    {
        /// <summary>
        /// 指定したパスからファイルを読み取り<see cref="StaticFile"/>を返す
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は不正な文字が含まれていた</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>の長さが260字以上またはファイル名が248字以上</exception>
        /// <exception cref="SystemException">ファイルの読み込みに失敗したまたはファイルが破損していた</exception>
        /// <returns><paramref name="path"/>で指定されたファイルのデータを持つ<see cref="StaticFile"/>のインスタンス</returns>
        public StaticFile CreateStaticFilePublic(string path)
        {
            var ex = IOHelper.IsCompatiblePath(path);
            if (ex != null) throw ex;
            return CreateStaticFile(path) ?? throw new SystemException("ファイルの読み込みに失敗またはファイルが破損していました\nログ参照");
        }
        /// <summary>
        /// 指定したパスからファイルを読み取り<see cref="StaticFile"/>を返す
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="file">読み込んだファイルの結果</param>
        /// <returns><paramref name="file"/>を読み込めたらtrue，それ以外でfalse</returns>
        public bool TryCreateStaticFile(string path, out StreamFile file)
        {
            if (IOHelper.IsCompatiblePath(path) != null)
            {
                file = null;
                return false;
            }
            file = CreateStreamFile(path);
            return file != null;
        }
        /// <summary>
        /// 指定したパスからファイルを読み取り<see cref="StreamFile"/>を返す
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる又は不正な文字が含まれていた</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>の長さが260字以上またはファイル名が248字以上</exception>
        /// <exception cref="SystemException">ファイルの読み込みに失敗したまたはファイルが破損していた</exception>
        /// <returns><paramref name="path"/>で指定されたファイルのデータを持つ<see cref="StreamFile"/>のインスタンス</returns>
        public StreamFile CreateStreamFilePublic(string path)
        {
            var ex = IOHelper.IsCompatiblePath(path);
            if (ex != null) throw ex;
            return CreateStreamFile(path) ?? throw new SystemException("ファイルの読み込みに失敗またはファイルが破損していました\nログ参照");
        }
        /// <summary>
        /// 指定したパスからファイルを読み取り<see cref="StreamFile"/>を返す
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="file">読み込んだファイルの結果</param>
        /// <returns><paramref name="file"/>を読み込めたらtrue，それ以外でfalse</returns>
        public bool TryCreateStreamFile(string path, out StreamFile file)
        {
            if (IOHelper.IsCompatiblePath(path) != null)
            {
                file = null;
                return false;
            }
            file = CreateStreamFile(path);
            return file != null;
        }
    }
}
