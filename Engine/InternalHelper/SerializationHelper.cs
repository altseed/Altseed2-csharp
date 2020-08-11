using System;
using System.Runtime.Serialization;

namespace Altseed2
{
    internal static class SerializationHelper
    {
        /// <summary>
        /// <see cref="SerializationInfo"/>から指定した名前を持つ要素を取得します。
        /// </summary>
        /// <typeparam name="T">取得する要素の型</typeparam>
        /// <param name="info">要素を取り出す<see cref="SerializationInfo"/>のインスタンス</param>
        /// <param name="name">取り出す要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>または<paramref name="name"/>がnull</exception>
        /// <exception cref="InvalidCastException">取り出した要素を<typeparamref name="T"/>にキャストできなかった</exception>
        /// <exception cref="SerializationException"><paramref name="name"/>を持つ要素が見つからなかった</exception>
        /// <returns><paramref name="info"/>に格納されている<paramref name="name"/>を持つ要素</returns>
        internal static T GetValue<T>(this SerializationInfo info, string name)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            return (T)info.GetValue(name, typeof(T));
        }
    }
}
