using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;

namespace Altseed2
{
    /// <summary>
    /// キャッシュを使用するクラス
    /// </summary>
    /// <typeparam name="TClass">クラスの型</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface ICacheKeeper<TClass> where TClass : class
    {
        /// <summary>
        /// キャッシュをためておくディクショナリを取得します。
        /// </summary>
        internal IDictionary<IntPtr, WeakReference<TClass>> CacheRepo { get; }
        /// <summary>
        /// 自身のポインタを取得または設定します。
        /// </summary>
        internal IntPtr Self { get; set; }
        /// <summary>
        /// <see cref="Release(IntPtr)"/>を抑制するかどうかを取得します。
        /// </summary>
        internal bool SurpressReleasing { get; }
        /// <summary>
        /// キャッシュを開放します。
        /// </summary>
        /// <param name="native">開放するオブジェクトのポインタ</param>
        internal void Release(IntPtr native);
    }

    /// <summary>
    /// キャッシュの制御を行うクラス
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class CacheHelper
    {
        /// <summary>
        /// キャッシュ制御を行います。
        /// </summary>
        /// <typeparam name="TClass">キャッシュ制御を行うクラス</typeparam>
        /// <param name="obj">キャッシュ制御を行うクラスのインスタンス</param>
        /// <param name="native"><paramref name="obj"/>に登録するポインタ</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/>または<paramref name="native"/>がnull</exception>
        internal static void CacheHandling<TClass>(TClass obj, IntPtr native) where TClass : class, ICacheKeeper<TClass>
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (native == IntPtr.Zero) throw new ArgumentNullException(nameof(native), "引数がnullです");

            if (obj.CacheRepo.ContainsKey(native))
            {
                obj.CacheRepo[native].TryGetTarget(out var cacheSet);
                if (cacheSet != null)
                {
                    if (!obj.SurpressReleasing) obj.Release(native);
                    obj.Self = native;
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
        internal static void CacheHandlingConcurrent<TClass>(TClass obj, IntPtr native) where TClass : class, ICacheKeeper<TClass>
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "引数がnullです");
            if (native == IntPtr.Zero) throw new ArgumentNullException(nameof(native), "引数がnullです");

            ConcurrentDictionary<IntPtr, WeakReference<TClass>> cacheRepo;

            try
            {
                cacheRepo = (ConcurrentDictionary<IntPtr, WeakReference<TClass>>)obj.CacheRepo;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("スレッドセーフなキャッシュ保存ディクショナリを取得できませんでした", nameof(cacheRepo));
            }


            if (cacheRepo.ContainsKey(native))
            {
                cacheRepo[native].TryGetTarget(out var cacheSet);
                if (cacheSet != null)
                {
                    if (!obj.SurpressReleasing) obj.Release(native);
                    obj.Self = native;
                    return;
                }
                else cacheRepo.TryRemove(native, out _);
            }

            cacheRepo.TryAdd(native, new WeakReference<TClass>(obj));

            obj.Self = native;
        }
    }
}
