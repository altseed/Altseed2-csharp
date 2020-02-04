using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    /// <summary>
    /// 一気に読み込んだファイルのクラス
    /// </summary>
    [Serializable]
    public class StaticFile : ISerializable
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion
        private readonly CoreStaticFile core;
        /// <summary>
        /// データを取得する
        /// ※現在未実装
        /// </summary>
        public byte[] Buffer => throw new NotImplementedException();
        /// <summary>
        /// このインスタンスのポインタを取得する
        /// </summary>
        public IntPtr Data => core.selfPtr;
        /// <summary>
        /// ファイルパッケージの中にあるかどうかを取得する
        /// </summary>
        public bool IsInPackage => core.GetIsInPackage();
        /// <summary>
        /// ファイルパスを取得する
        /// </summary>
        public string Path => core.GetPath();
        /// <summary>
        /// ファイルの大きさを取得する
        /// </summary>
        public int Size => core.GetSize();
        internal StaticFile(CoreStaticFile coreStaticFile)
        {
            core = coreStaticFile ?? throw new ArgumentNullException("引数がnullです", nameof(coreStaticFile));
        }
        /// <summary>
        /// シリアライズされた情報をもとに新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected StaticFile(SerializationInfo info, StreamingContext context)
        {
            try
            {
                core = Engine.File.CreateCoreStaticFileStrict(info.GetString(Path));
            }
            catch (Exception e)
            {
                throw new SerializationException("デシリアライズに失敗しました", e);
            }
        }
        /// <summary>
        /// シリアライズする情報を設定する
        /// </summary>
        /// <param name="info">シリアライズする情報を格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数(SerializationInfo)がnullです", nameof(info));
            info.AddValue(S_Path, Path);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
        /// <summary>
        /// 指定したパスにこのインスタンスのデータを保存する
        /// </summary>
        /// <param name="path">保存先のファイルパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空文字のみからなる，特定の拡張子を持つ，使用不可能な文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>で指定されたディレクトリが見つからない</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>に使用不可能な拡張子が含まれる</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="System.Security.SecurityException">アクセスが拒否された</exception>
        public void Save(string path)
        {
            var ex = IOHelper.CheckSavePath(path);
            if (ex != null) throw ex;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(Buffer, 0, Buffer.Length);
            }
        }
    }
}
