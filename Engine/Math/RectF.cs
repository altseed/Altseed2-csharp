using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の矩形を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RectF : IEquatable<RectF>
    {
        /// <summary>
        /// X座標
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float X;

        /// <summary>
        /// Y座標
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float Y;

        /// <summary>
        /// 幅
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float Width;

        /// <summary>
        /// 高さ
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float Height;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        public RectF(float x, float y, float width, float height)
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
        public RectF(Vector2F position, Vector2F size) : this(position.X, position.Y, size.X, size.Y) { }

        /// <summary>
        /// 2つの<see cref="RectF"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する矩形1</param>
        /// <param name="v2">等価性を判定する矩形2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(RectF v1, RectF v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="RectF"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="RectF"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(RectF other) => X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is RectF r ? Equals(r) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 同じ値を持つ<see cref="RectI"/>の新しいインスタンスを生成する
        /// </summary>
        /// <returns>同じ値を持つ<see cref="RectI"/>の新しいインスタンス</returns>
        public readonly RectI ToI() => new RectI((int)X, (int)Y, (int)Width, (int)Height);

        public static bool operator ==(RectF v1, RectF v2) => Equals(v1, v2);

        public static bool operator !=(RectF v1, RectF v2) => !Equals(v1, v2);

        public static implicit operator RectF(RectI rect) => rect.ToF();
        public static explicit operator RectI(RectF rect) => rect.ToI();
    }
}
