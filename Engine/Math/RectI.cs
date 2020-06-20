using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の矩形を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RectI : IEquatable<RectI>
    {
        /// <summary>
        /// X座標
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int X;

        /// <summary>
        /// Y座標
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int Y;

        /// <summary>
        /// 幅
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int Width;

        /// <summary>
        /// 高さ
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int Height;

        public Vector2I Position => new Vector2I(X, Y);

        public Vector2I Size => new Vector2I(Width, Height);

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        public RectI(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">左上の座標</param>
        /// <param name="size">サイズ</param>
        public RectI(Vector2I position, Vector2I size) : this(position.X, position.Y, size.X, size.Y) { }

        /// <summary>
        /// 2つの<see cref="RectI"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する矩形1</param>
        /// <param name="v2">等価性を判定する矩形2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(RectI v1, RectI v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="RectI"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="RectI"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(RectI other) => X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is RectI r && Equals(r);

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

        /// <summary>
        /// 同じ値を持つ<see cref="RectF"/>の新しいインスタンスを生成する
        /// </summary>
        /// <returns>同じ値を持つ<see cref="RectF"/>の新しいインスタンス</returns>
        public readonly RectF ToF() => new RectF(X, Y, Width, Height);

        public static bool operator ==(RectI v1, RectI v2) => Equals(v1, v2);

        public static bool operator !=(RectI v1, RectI v2) => !Equals(v1, v2);
    }
}
