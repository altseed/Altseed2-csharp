using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    public partial class Int8Array
    {
        /// <summary>
        /// <see cref="byte"/>型の配列に変換する
        /// </summary>
        /// <returns>このインスタンスのデータと等しい<see cref="byte"/>配列のインスタンス</returns>
        public byte[] ToByteArray()
        {
            var array = new byte[Count];
            Marshal.Copy(selfPtr, array, 0, Count);
            return array;
        }

        /// <summary>
        /// <see cref="byte"/>型の配列から<see cref="Int8Array"/>に型変換する
        /// </summary>
        /// <param name="array">データを格納する<see cref="byte"/>型の配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="SystemException">インスタンスの生成に失敗した</exception>
        /// <returns><paramref name="array"/>と同じデータを格納する<see cref="Int8Array"/>のインスタンス</returns>
        public static Int8Array FromByteArray(byte[] array)
        {
            if (array == null) throw new ArgumentNullException("引数がnullです", nameof(array));

            var size = Marshal.SizeOf(default(byte)) * array.Length;
            var result = new Int8Array(new MemoryHandle(new IntPtr(size)));

            Marshal.Copy(array, 0, result.selfPtr, array.Length);

            return result;
        }

        public static explicit operator byte[](Int8Array a) => a.ToByteArray();
    }
}
