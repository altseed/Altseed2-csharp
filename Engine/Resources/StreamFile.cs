using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    /// <summary>
    /// 段階的に読み込んだファイルのクラス
    /// </summary>
    [Serializable]
    public class StreamFile : ISerializable
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion
        private readonly CoreStreamFile core;
        private readonly string path;
        /// <summary>
        /// 現在読み込んでいる位置を取得する
        /// </summary>
        public int CurrentPosition => core.GetCurrentPosition();
        /// <summary>
        /// ファイルパッケージの中にあるかどうかを取得する
        /// </summary>
        public bool IsInPackage => core.GetIsInPackage();
        /// <summary>
        /// ファイルの大きさを取得する
        /// </summary>
        public int Size => core.GetSize();
        /// <summary>
        /// 読み込まれたデータを取得する
        /// ※現在未実装
        /// </summary>
        public byte[] TempBuffer => throw new NotImplementedException();
        /// <summary>
        /// 読み込まれたデータのサイズを取得する
        /// </summary>
        public int TempBufferSize => core.GetTempBufferSize();
        internal StreamFile(CoreStreamFile coreStreamFile, string path)
        {
            this.path = path ?? throw new ArgumentNullException("引数がnullです", nameof(path));
            core = coreStreamFile ?? throw new ArgumentNullException("引数がnullです", nameof(coreStreamFile));
        }
        /// <summary>
        /// シリアライズされた情報をもとに新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected StreamFile(SerializationInfo info, StreamingContext context)
        {
            path = info.GetString(S_Path) ?? throw new SerializationException("デシリアライズに失敗しました");
            try
            {
                core = Engine.File.CreateCoreStreamFileStrict(path);
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
            info.AddValue(S_Path, path);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
    }
}
