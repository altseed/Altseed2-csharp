using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// CPU/GPUバッファ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Buffer<T> where T : struct
    {
        internal Buffer InternalBuffer { get; }

        /// <summary>
        /// バッファ内の要素数
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// バッファのサイズ
        /// </summary>
        public int Size => InternalBuffer.Size;

        /// <summary>
        /// バッファの使途
        /// </summary>
        public BufferUsageType BufferUsage => InternalBuffer.BufferUsage;

        Buffer(Buffer internalBuffer, int count)
        {
            InternalBuffer = internalBuffer;
            Count = count;
        }

        /// <summary>
        /// バッファを生成します
        /// </summary>
        /// <param name="usage">バッファの使途</param>
        /// <param name="count">要素数</param>
        /// <returns><see cref="Buffer{T}"/>のインスタンス</returns>
        public static Buffer<T> Create(BufferUsageType usage, int count)
        {
            var internalBuffer = Buffer.Create(usage, Marshal.SizeOf<T>() * count);
            if (internalBuffer == null)
            {
                Engine.Log.Error(LogCategory.Engine, "Buffer<T>::Create: bufferの作成に失敗しました。");
                return null;
            }

            return new Buffer<T>(internalBuffer, count);
        }

        /// <summary>
        /// バッファを生成します
        /// </summary>
        /// <param name="usage">バッファの使途</param>
        /// <param name="count">要素数</param>
        /// <returns><see cref="Buffer{T}"/>のインスタンス</returns>
        /// <exceptions><see cref="ArgumentException"/>バッファの作成に失敗</exceptions>
        public static Buffer<T> CreateStrict(BufferUsageType usage, int count)
        {
            var internalBuffer = Buffer.Create(usage, Marshal.SizeOf<T>() * count);
            if (internalBuffer == null)
            {
                throw new ArgumentException("Bufferの作成に失敗しました。");
            }

            return new Buffer<T>(internalBuffer, count);
        }

        /// <summary>
        /// バッファのデータへアクセスする
        /// </summary>
        /// <returns>バッファのデータ<see cref="Span{T}"/>を持つ<see cref="Container"/></returns>
        public Container Lock()
        {
            unsafe
            {
                var lockPtr = InternalBuffer.Lock();
                if (lockPtr == IntPtr.Zero)
                {
                    return new Container(null, null);
                }
                return new Container(this, new Span<T>(lockPtr.ToPointer(), Count));
            }
        }

        /// <summary>
        /// バッファのデータへアクセスする。
        /// </summary>
        /// <returns>バッファのデータ<see cref="Span{T}"/>を持つ<see cref="Container"/></returns>
        /// <exception cref="InvalidOperationException">バッファのロックに失敗</exception>
        public Container LockStrict()
        {
            var container = Lock();

            if (container.Span == null)
            {
                throw new InvalidOperationException("バッファのロックに失敗しました。");
            }

            return container;
        }

        /// <summary>
        /// バッファへの書き込みを開始します
        /// </summary>
        /// <returns></returns>
        public ref struct Container
        {
            private Buffer<T> buffer;

            /// <summary>
            /// バッファのデータ
            /// </summary>
            /// <returns></returns>
            public Span<T> Span { get; init; }

            internal Container(Buffer<T> buffer, Span<T> span)
            {
                this.buffer = buffer;
                Span = span;
            }

            /// <summary>
            /// バッファのアンロックを行う
            /// </summary>
            public void Dispose() => buffer?.InternalBuffer.Unlock();
        }
    }
}
