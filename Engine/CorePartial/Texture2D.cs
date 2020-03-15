using System;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public partial class Texture2D : ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion

        private SerializationInfo seInfo;

        /// <summary>
        /// シリアライズされたデータをもとに<see cref="Texture2D"/>のインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected Texture2D(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
        }

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

        /// <summary>
        /// シリアライズするデータを設定します。
        /// </summary>
        /// <param name="info">シリアライズされるデータを格納するオブジェクト</param>
        /// <param name="context">送信先のデータ</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_Path, GetPath());
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info, context);

        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        protected virtual void OnDeserialization(object sender)
        {
            if (seInfo == null) return;

            var path = seInfo.GetString(S_Path);
            var ptr = cbg_Texture2D_Load(path);

            if (ptr == IntPtr.Zero) throw new SerializationException("読み込みに失敗しました");

            selfPtr = ptr;
            if (!cacheRepo.ContainsKey(ptr)) cacheRepo.Add(ptr, new WeakReference<Texture2D>(this));

            seInfo = null;
        }
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization(sender);
    }
}
