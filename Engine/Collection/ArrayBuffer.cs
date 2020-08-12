using System;
namespace Altseed2
{
    sealed class ArrayBuffer<T>
    {
        readonly int _Minimum;
        private T[] _Array;

        public ArrayBuffer(int minimum = 1)
        {
            _Minimum = minimum;
        }

        /// <summary>
        /// 長さ<paramref name="length"/>以上の配列を返す。
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public T[] GetAsArray(int length)
        {
            if (length < 1)
            {
                return _Array ??= new T[_Minimum];
            }

            if (_Array is null)
            {
                int i = _Minimum;
                while (i < length) i *= 2;
                _Array = new T[i];
            }
            else if (_Array.Length < length)
            {
                int i = _Array.Length * 2;
                while (i < length) i *= 2;
                _Array = new T[i];
            }

            return _Array;
        }

        /// <summary>
        /// 長さ<paramref name="length"/>のSpanを返す。
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public Span<T> GetAsSpan(int length)
        {
            return GetAsArray(length).AsSpan(0, Math.Max(length, 0));
        }
    }
}
