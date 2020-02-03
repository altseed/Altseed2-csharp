using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Altseed
{
    /// <summary>
    /// 読み込んだファイルのクラス
    /// </summary>
    [Serializable]
    public partial class StaticFile : ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion
        public byte[] Buffer
        {
            get
            {
                if (_buffer == null) _buffer = GetBufferFromIntPtr(selfPtr) ?? new byte[0];
                return _buffer;
            }
        }
        private byte[] _buffer;
        public IntPtr Data => selfPtr;
        /// <summary>
        /// ファイルパッケージの中にあるかどうかを取得する
        /// </summary>
        public bool IsInPackage => GetIsInPackage();
        /// <summary>
        /// ファイルパスを取得する
        /// </summary>
        public string Path => GetPath();
        /// <summary>
        /// ファイルの大きさを取得する
        /// </summary>
        public int Size => GetSize();
        /// <summary>
        /// シリアライズされた情報をもとに新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされた情報を格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected StaticFile(SerializationInfo info, StreamingContext context)
        {

        }
        private byte[] GetBufferFromIntPtr(IntPtr selfPtr)
        {
            var b = cbg_StaticFile_GetBuffer(selfPtr);
            var array = new byte[Size];
            Marshal.Copy(b, array, 0, Size);
            return array;
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

        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされておらず，常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {

        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
    }
}
