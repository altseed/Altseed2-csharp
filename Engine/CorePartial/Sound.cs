using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public sealed partial class Sound : ISerializable, ICacheKeeper<Sound>
    {
        #region SerializeName
        private const string S_IsDecompressed = "S_IsDecompressed";
        private const string S_IsLoopingMode = "S_IsLoopingMode";
        private const string S_LoopStaringPoint = "S_LoopStaringPoint";
        private const string S_LoopEndPoint = "S_LoopEndPoint";
        private const string S_Path = "S_Path";
        #endregion

        private Sound(SerializationInfo info, StreamingContext context)
        {
            var path = info.GetString(S_Path);
            var isDecompressed = info.GetBoolean(S_IsDecompressed);

            var ptr = cbg_Sound_Load(path, isDecompressed);
            if (ptr == IntPtr.Zero) throw new SerializationException("読み込みに失敗しました");

            CacheHelper.CacheHandlingConcurrent(this, ptr);

            LoopStartingPoint = info.GetSingle(S_LoopStaringPoint);
            LoopEndPoint = info.GetSingle(S_LoopEndPoint);
            IsLoopingMode = info.GetBoolean(S_IsLoopingMode);
        }

        #region ICacheKeeper
        IDictionary<IntPtr, WeakReference<Sound>> ICacheKeeper<Sound>.CacheRepo => cacheRepo;

        IntPtr ICacheKeeper<Sound>.Self { get => selfPtr; set => selfPtr = value; }

        void ICacheKeeper<Sound>.Release(IntPtr native) => cbg_Sound_Release(native);
        #endregion

        /// <summary>
        /// 指定パスから音源を読み込む
        /// </summary>
        /// <param name="path">読み込む音源のパス</param>
        /// <param name="isDecompressed">一気に解凍するかどうか</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなる、または使用出来ない文字を含んでいる</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定された音源が見つからない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定するパスが見つからない</exception>
        /// <exception cref="SystemException">音源が破損または読み込みに失敗</exception>
        /// <returns><paramref name="path"/>をパスに持つ音源のデータを格納した<see cref="Sound"/>の新しいインスタンス</returns>
        public static Sound LoadStrict(string path, bool isDecompressed)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex != null) throw ex;
            var result = Load(path, isDecompressed) ?? throw new SystemException("ファイルが破損しているか読み込みに失敗しました");
            return result;
        }

        /// <summary>
        /// 指定パスから音源を読み込む
        /// </summary>
        /// <param name="path">読み込む音源のパス</param>
        /// <param name="isDecompressed">一気に解凍するかどうか</param>
        /// <param name="result"><paramref name="path"/>をパスに持つ音源のデータを格納した<see cref="Sound"/>の新しいインスタンス 読み込めなかったらnull</param>
        /// <returns><paramref name="result"/>を正常に読み込めたらtrue、それ以外でfalse</returns>
        public static bool TryLoad(string path, bool isDecompressed, out Sound result)
        {
            var ex = IOHelper.CheckLoadPath(path);
            if (ex == null && (result = Load(path, isDecompressed)) != null) return true;
            result = null;
            return false;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_Path, GetPath());
            info.AddValue(S_IsDecompressed, GetIsDecompressed());
            info.AddValue(S_LoopStaringPoint, LoopStartingPoint);
            info.AddValue(S_LoopEndPoint, LoopEndPoint);
            info.AddValue(S_IsLoopingMode, IsLoopingMode);
        }
    }

    public partial class SoundMixer
    {
        public float[] GetSpectrumData(int id,　int dataNum, FFTWindow window)
        {
            if((dataNum & (dataNum - 1)) != 0) return null;
            var fa = FloatArray.Create(dataNum);
            GetSpectrumData(id, fa, window);
            return fa.ToArray();
        }
    }
}
