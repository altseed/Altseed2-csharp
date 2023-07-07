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
            if (internalBuffer is null)
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
            if (internalBuffer is null)
            {
                throw new ArgumentException("Bufferの作成に失敗しました。");
            }

            return new Buffer<T>(internalBuffer, count);
        }

        /// <summary>
        /// バッファのデータへアクセスする
        /// </summary>
        /// <returns>バッファのデータ<see cref="ReadOnlySpan{T}"/>を持つ<see cref="ReadContainer"/></returns>
        public ReadContainer ReadLock()
        {
            unsafe
            {
                var lockPtr = InternalBuffer.Lock();

                if (lockPtr == IntPtr.Zero
                    || ((InternalBuffer.BufferUsage & BufferUsageType.MapRead) == 0
                        && (InternalBuffer.BufferUsage & BufferUsageType.MapWrite) == 0)
                )
                {
                    return new ReadContainer(null, null);
                }
                return new ReadContainer(this, new ReadOnlySpan<T>(lockPtr.ToPointer(), Count));
            }
        }

        /// <summary>
        /// バッファのデータへアクセスする。
        /// </summary>
        /// <returns>バッファのデータ<see cref="Span{T}"/>を持つ<see cref="ReadContainer"/></returns>
        /// <exception cref="InvalidOperationException">バッファのロックに失敗</exception>
        public ReadContainer ReadLockStrict()
        {
            var container = ReadLock();

            if (container.Span == null)
            {
                throw new InvalidOperationException("バッファのロックに失敗しました。");
            }

            return container;
        }

        /// <summary>
        /// バッファのデータへアクセスする
        /// </summary>
        /// <returns>バッファのデータ<see cref="Span{T}"/>を持つ<see cref="WriteContainer"/></returns>
        public WriteContainer WriteLock()
        {
            unsafe
            {
                var lockPtr = InternalBuffer.Lock();

                if (lockPtr == IntPtr.Zero || ((InternalBuffer.BufferUsage & BufferUsageType.MapWrite) == 0))
                {
                    return new WriteContainer(null, null);
                }
                return new WriteContainer(this, new Span<T>(lockPtr.ToPointer(), Count));
            }
        }

        /// <summary>
        /// バッファのデータへアクセスする。
        /// </summary>
        /// <returns>バッファのデータ<see cref="Span{T}"/>を持つ<see cref="WriteContainer"/></returns>
        /// <exception cref="InvalidOperationException">バッファのロックに失敗</exception>
        public WriteContainer WriteLockStrict()
        {
            var container = WriteLock();

            if (container.Span == null)
            {
                throw new InvalidOperationException("バッファのロックに失敗しました。");
            }

            return container;
        }

        /// <summary>
        /// バッファへ書き込みを行うための情報を保持する構造体。
        /// </summary>
        /// <returns></returns>
        public ref struct ReadContainer
        {
            private readonly Buffer<T> buffer;

            /// <summary>
            /// バッファのデータ
            /// </summary>
            /// <returns></returns>
            public ReadOnlySpan<T> Span { get; private init; }

            /// <summary>
            /// <see cref="Span{T}"/>がnullではない。
            /// </summary>
            public bool IsValid => Span != null;

            internal ReadContainer(Buffer<T> buffer, ReadOnlySpan<T> span)
            {
                this.buffer = buffer;
                Span = span;
            }

            /// <summary>
            /// バッファのアンロックを行う
            /// </summary>
            public void Dispose() => buffer?.InternalBuffer.Unlock();
        }

        /// <summary>
        /// バッファへ書き込みを行うための情報を保持する構造体。
        /// </summary>
        /// <returns></returns>
        public ref struct WriteContainer
        {
            private readonly Buffer<T> buffer;

            /// <summary>
            /// バッファのデータ
            /// </summary>
            /// <returns></returns>
            public Span<T> Span { get; private init; }

            /// <summary>
            /// <see cref="Span{T}"/>がnullではない。
            /// </summary>
            public bool IsValid => Span != null;

            internal WriteContainer(Buffer<T> buffer, Span<T> span)
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
