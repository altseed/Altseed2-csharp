using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Altseed
{
    /// <summary>
    /// キャッシュを使用するクラス
    /// </summary>
    /// <typeparam name="TClass">クラスの型</typeparam>
    internal interface IChacheKeeper<TClass> where TClass : class
    {
        /// <summary>
        /// キャッシュをためておくディクショナリを取得する
        /// </summary>
        internal IDictionary<IntPtr, WeakReference<TClass>> CacheRepo { get; }
        /// <summary>
        /// 自身のポインタを取得または設定する
        /// </summary>
        internal IntPtr Self { get; set; }
        /// <summary>
        /// キャッシュを開放する
        /// </summary>
        /// <param name="native">開放するオブジェクトのポインタ</param>
        internal void Release(IntPtr native);
    }

    /// <summary>
    /// キャッシュの制御を行うクラス
    /// </summary>
    internal static class CacheHelper
    {
        /// <summary>
        /// キャッシュ制御を行う
        /// </summary>
        /// <typeparam name="TClass">キャッシュ制御を行うクラス</typeparam>
        /// <param name="obj">キャッシュ制御を行うクラスのインスタンス</param>
        /// <param name="native"><paramref name="obj"/>に登録するポインタ</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="native"/>がnull</exception>
        internal static void CacheHandling<TClass>(TClass obj, IntPtr native) where TClass : class, IChacheKeeper<TClass>
        {
            if (obj == null) throw new ArgumentNullException("引数がnullです", nameof(obj));
            if (native == IntPtr.Zero) throw new ArgumentNullException("引数がnullです", nameof(native));

            if (obj.CacheRepo.ContainsKey(native))
            {
                obj.CacheRepo[native].TryGetTarget(out var cacheSet);
                if (cacheSet != null)
                {
                    cacheSet.Release(native);
                    return;
                }
                else obj.CacheRepo.Remove(native);
            }
            obj.CacheRepo[native] = new WeakReference<TClass>(obj);

            obj.Self = native;
        }

        /// <summary>
        /// キャッシュ制御をスレッドセーフに行う
        /// </summary>
        /// <typeparam name="TClass">キャッシュ制御を行うクラス</typeparam>
        /// <param name="obj">キャッシュ制御を行うクラスのインスタンス</param>
        /// <param name="native"><paramref name="obj"/>に登録するポインタ</param>
        /// <exception cref="ArgumentException">スレッドセーフなキャッシュ保存ディクショナリを取得できなかった</exception>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="native"/>がnull</exception>
        internal static void CacheHandlingConcurrent<TClass>(TClass obj, IntPtr native) where TClass : class, IChacheKeeper<TClass>
        {
            if (obj == null) throw new ArgumentNullException("引数がnullです", nameof(obj));
            if (native == IntPtr.Zero) throw new ArgumentNullException("引数がnullです", nameof(native));

            ConcurrentDictionary<IntPtr, WeakReference<TClass>> cacheRepo;

            try
            {
                cacheRepo = (ConcurrentDictionary<IntPtr, WeakReference<TClass>>)obj.CacheRepo;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("スレッドセーフなキャッシュ保存ディクショナリを取得できませんでした");
            }
           

            if (cacheRepo.ContainsKey(native))
            {
                cacheRepo[native].TryGetTarget(out var cacheSet);
                if (cacheSet != null)
                {
                    cacheSet.Release(native);
                    return;
                }
                else cacheRepo.TryRemove(native, out _);
            }

            cacheRepo.TryAdd(native, new WeakReference<TClass>(obj));

            obj.Self = native;
        }
    }
}
