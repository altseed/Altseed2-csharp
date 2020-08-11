using System;
using System.Runtime.InteropServices;

namespace Altseed2
{
    /// <summary>
    /// 3次元ベクトル
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3I : IEquatable<Vector3I>
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
        /// <see cref="Vector3I"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="x">X成分</param>
        /// <param name="y">Y成分</param>
        /// <param name="z">Z成分</param>
        public Vector3I(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Equivalence
        /// <summary>
        /// 2つの<see cref="Vector3I"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector3I v1, Vector3I v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector3I"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector3I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector3I other) => X == other.X && Y == other.Y && Z == other.Z;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector3I f && Equals(f);

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(X, Y, Z);

        /// <summary>
        /// 二つの<see cref="Vector3I"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する<see cref="Vector3I"/>のインスタンス</param>
        /// <param name="v2">等価性を判定する<see cref="Vector3I"/>のインスタンス</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(Vector3I v1, Vector3I v2) => Equals(v1, v2);

        /// <summary>
        /// 二つの<see cref="Vector3I"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="v1">非等価性を判定する<see cref="Vector3I"/>のインスタンス</param>
        /// <param name="v2">非等価性を判定する<see cref="Vector3I"/>のインスタンス</param>
        /// <returns><paramref name="v1"/> と <paramref name="v2"/> の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(Vector3I v1, Vector3I v2) => !Equals(v1, v2);
        #endregion

        /// <summary>
        /// このインスタンスから要素を取り出します。
        /// </summary>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        /// <param name="z"><see cref="Z"/></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public readonly void Deconstruct(out int x, out int y, out int z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// このベクトルを表す文字列取得します。
        /// </summary>
        /// <returns>このベクトルを表す文字列取得します。</returns>
        public override string ToString() => $"({X}, {Y}, {Z})";

        /// <summary>
        /// <see cref="Vector3F"/>に型変換します。
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector3F"/>の新しいインスタンス</returns>
        public readonly Vector3F To3F() => new Vector3F(X, Y, Z);

        /// <summary>
        /// 外積取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        /// <remarks>
        /// 右手の親指がv1、人差し指がv2としたとき、中指の方向を返します。。
        /// </remarks>
        public static Vector3I Cross(Vector3I v1, Vector3I v2)
        {
            Vector3I o = new Vector3I();
            int x = v1.Y * v2.Z - v1.Z * v2.Y;
            int y = v1.Z * v2.X - v1.X * v2.Z;
            int z = v1.X * v2.Y - v1.Y * v2.X;
            o.X = x;
            o.Y = y;
            o.Z = z;
            return o;
        }

        /// <summary>
        /// 2点間の距離取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>v1とv2の距離</returns>
        public static float Distance(Vector3I v1, Vector3I v2)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            float dz = v1.Z - v2.Z;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// 内積取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>内積v1・v2</returns>
        public static int Dot(Vector3I v1, Vector3I v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        #region CalOperators
        /// <summary>
        /// 2つのベクトルを加算します。
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector3I operator +(Vector3I v1, Vector3I v2) => new Vector3I(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// 与えられたベクトルを返します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/></returns>
        public static Vector3I operator +(Vector3I vector) => vector;

        /// <summary>
        /// ベクトルの符号を反転します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector3I operator -(Vector3I vector) => new Vector3I(-vector.X, -vector.Y, -vector.Z);

        /// <summary>
        /// 2つのベクトルを減算します。
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector3I operator -(Vector3I left, Vector3I right) => new Vector3I(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// 2つのベクトルを積算します。
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z)</returns>
        public static Vector3I operator *(Vector3I v1, Vector3I v2) => new Vector3I(v1.X * v2.X, v1.Y * v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector3I operator *(Vector3I vector, int scalar) => new Vector3I(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="scalar">積算する値</param>
        /// <param name="vector">積算するベクトル</param>
        /// <returns>積算結果</returns>
        public static Vector3I operator *(int scalar, Vector3I vector) => new Vector3I(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        /// <summary>
        /// 2つのベクトルを除算します。
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y, left.Z / right.Z)</returns>
        public static Vector3I operator /(Vector3I left, Vector3I right) => new Vector3I(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        /// <summary>
        /// ベクトルを値で除算します。
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar, vector.Z / scalar)</returns>
        public static Vector3I operator /(Vector3I vector, int scalar) => new Vector3I(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        #endregion
    }
}
