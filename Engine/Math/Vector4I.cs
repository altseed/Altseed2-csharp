using System;
using System.Runtime.InteropServices;

namespace Altseed2
{
    /// <summary>
    /// 4次元ベクトル
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4I : IEquatable<Vector4I>
    {
        /// <summary>
        /// X成分
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int X;

        /// <summary>
        /// Y成分
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int Y;

        /// <summary>
        /// Z成分
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int Z;

        /// <summary>
        /// W成分
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int W;

        /// <summary>
        /// <see cref="Vector4I"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="z">Z座標</param>
        /// <param name="w">W座標</param>
        public Vector4I(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        #region Equivalence
        /// <summary>
        /// 2つの<see cref="Vector4I"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector4I v1, Vector4I v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector4I"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector4I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector4I other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector4I v && Equals(v);

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        /// <summary>
        /// 二つの<see cref="Vector4I"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する<see cref="Vector4I"/>のインスタンス</param>
        /// <param name="v2">等価性を判定する<see cref="Vector4I"/>のインスタンス</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(Vector4I v1, Vector4I v2) => Equals(v1, v2);

        /// <summary>
        /// 二つの<see cref="Vector4I"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="v1">非等価性を判定する<see cref="Vector4I"/>のインスタンス</param>
        /// <param name="v2">非等価性を判定する<see cref="Vector4I"/>のインスタンス</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(Vector4I v1, Vector4I v2) => !Equals(v1, v2);
        #endregion

        /// <summary>
        /// このインスタンスから要素を取り出します。
        /// </summary>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        /// <param name="z"><see cref="Z"/></param>
        /// <param name="w"><see cref="W"/></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public readonly void Deconstruct(out int x, out int y, out int z, out int w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }

        /// <summary>
        /// このベクトルを表す文字列取得します。
        /// </summary>
        /// <returns>このベクトルを表す文字列取得します。</returns>
        public readonly override string ToString() => $"({X}, {Y}, {Z}, {W})";

        /// <summary>
        /// <see cref="Vector4F"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector4F"/>の新しいインスタンス</returns>
        public readonly Vector4F To4F() => new Vector4F(X, Y, Z, W);

        /// <summary>
        /// 外積取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        public static int Dot(Vector4I v1, Vector4I v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z + v1.W * v2.W;

        /// <summary>
        /// 2点間の距離取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>v1とv2の距離</returns>
        public static float Distance(Vector4I v1, Vector4I v2)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            float dz = v1.Z - v2.Z;
            float dw = v1.W - v2.W;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }
        #region CalOperators
        /// <summary>
        /// 2つのベクトルを加算します。
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector4I operator +(Vector4I v1, Vector4I v2) => new Vector4I(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);

        /// <summary>
        /// 与えられたベクトルを返します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/></returns>
        public static Vector4I operator +(Vector4I vector) => vector;

        /// <summary>
        /// ベクトルの符号を反転します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector4I operator -(Vector4I vector) => new Vector4I(-vector.X, -vector.Y, -vector.Z, -vector.W);

        /// <summary>
        /// 2つのベクトルを減算します。
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector4I operator -(Vector4I left, Vector4I right) => new Vector4I(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        /// <summary>
        /// 2つのベクトルを積算します。
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z, v1.W * v2.W)</returns>
        public static Vector4I operator *(Vector4I v1, Vector4I v2) => new Vector4I(v1.X * v2.X, v1.Y * v2.Y, v1.Z + v2.Z, v1.W + v2.W);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector4I operator *(Vector4I vector, int scalar) => new Vector4I(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="scalar">積算する値</param>
        /// <param name="vector">積算するベクトル</param>
        /// <returns>積算結果</returns>
        public static Vector4I operator *(int scalar, Vector4I vector) => new Vector4I(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);

        /// <summary>
        /// 2つのベクトルを除算します。
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W)</returns>
        public static Vector4I operator /(Vector4I left, Vector4I right) => new Vector4I(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);

        /// <summary>
        /// ベクトルを値で除算します。
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar)</returns>
        public static Vector4I operator /(Vector4I vector, int scalar) => new Vector4I(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);
        #endregion
    }
}