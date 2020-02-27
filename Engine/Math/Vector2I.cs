using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の二次元ベクトルを表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2I : IEquatable<Vector2I>
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
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 2つの<see cref="Vector2I"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector2I v1, Vector2I v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector2I"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector2I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector2I other) => X == other.X && Y == other.Y;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector2I v ? Equals(v) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// このベクトルを表す文字列取得します。
        /// </summary>
        /// <returns>このベクトルを表す文字列取得します。</returns>
        public readonly override string ToString() => $"({X}, {Y})";

        /// <summary>
        /// <see cref="Vector2F"/>に型変換します。
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector2F"/>の新しいインスタンス</returns>
        public readonly Vector2F To2DF() => new Vector2F(X, Y);

        /// <summary>
        /// 2つのベクトルの外積を求めます。
        /// </summary>
        /// <param name="left">使用するベクトル1</param>
        /// <param name="right">使用するベクトル2</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の外積</returns>
        public static int Cross(Vector2I left, Vector2I right) => left.X * right.Y - right.X * left.Y;

        /// <summary>
        /// 2つのベクトルの内積を求めます。
        /// </summary>
        /// <param name="v1">使用するベクトル1</param>
        /// <param name="v2">使用するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の内積</returns>
        public static int Dot(Vector2I v1, Vector2I v2) => v1.X * v2.X + v1.Y + v2.Y;

        public static bool operator ==(Vector2I v1, Vector2I v2) => Equals(v1, v2);

        public static bool operator !=(Vector2I v1, Vector2I v2) => !Equals(v1, v2);

        /// <summary>
        /// 2つのベクトルを加算します。
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector2I operator +(Vector2I v1, Vector2I v2) => new Vector2I(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// ベクトルの符号を反転します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector2I operator -(Vector2I vector) => new Vector2I(-vector.X, -vector.Y);

        /// <summary>
        /// 2つのベクトルを減算します。
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector2I operator -(Vector2I left, Vector2I right) => new Vector2I(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 2つのベクトルを積算します。
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y + v2.Y)</returns>
        public static Vector2I operator *(Vector2I v1, Vector2I v2) => new Vector2I(v1.X * v2.X, v1.Y * v2.Y);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector2I operator *(Vector2I vector, int scalar) => new Vector2I(vector.X * scalar, vector.Y * scalar);

        /// <summary>
        /// ベクトルと値を積算する
        /// </summary>
        /// <param name="scalar">積算する値</param>
        /// <param name="vector">積算するベクトル</param>
        /// <returns>積算結果</returns>
        public static Vector2I operator *(int scalar, Vector2I vector) => new Vector2I(vector.X * scalar, vector.Y * scalar);

        /// <summary>
        /// 2つのベクトルを除算します。
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y)</returns>
        public static Vector2I operator /(Vector2I left, Vector2I right) => new Vector2I(left.X / right.X, left.Y / right.Y);

        /// <summary>
        /// ベクトルを値で除算します。
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar)</returns>
        public static Vector2I operator /(Vector2I vector, int scalar) => new Vector2I(vector.X / scalar, vector.Y / scalar);
    }
}
