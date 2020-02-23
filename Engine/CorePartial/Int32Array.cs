using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    public partial class Int32Array
    {

        /// <summary>
        /// <see cref="int"/>型の配列に変換する
        /// </summary>
        /// <returns>このインスタンスのデータと等しい<see cref="int"/>配列のインスタンス</returns>
        public int[] ToIntArray()
        {
            //未実装
            throw new NotImplementedException();

            var array = new int[Count];
            Marshal.Copy(selfPtr, array, 0, Count);
            return array;
        }

        /// <summary>
        /// <see cref="int"/>型の配列から<see cref="Int32Array"/>に型変換する
        /// </summary>
        /// <param name="array">データを格納する<see cref="int"/>型の配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="SystemException">インスタンスの生成に失敗した</exception>
        /// <returns><paramref name="array"/>と同じデータを格納する<see cref="Int32Array"/>のインスタンス</returns>
        public static Int32Array FromIntArray(int[] array)
        {
            //未実装
            throw new NotImplementedException();

            if (array == null) throw new ArgumentNullException("引数がnullです", nameof(array));

            var size = Marshal.SizeOf(default(int)) * array.Length;
            var result = new Int32Array(new MemoryHandle(Marshal.AllocCoTaskMem(size)));

            Marshal.Copy(array, 0, result.selfPtr, array.Length);

            return result;
        }

        public static explicit operator int[](Int32Array a) => a.ToIntArray();
    }
}
