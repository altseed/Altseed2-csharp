using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// 3次元ベクトル
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3F : IEquatable<Vector3F>
    {
        /// <summary>
        /// X成分
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float X;

        /// <summary>
        /// Y成分
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float Y;

        /// <summary>
        /// Z成分
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float Z;

        /// <summary>
        /// ベクトルの長さを取得または設定します。
        /// </summary>
        public float Length
        {
            readonly get => (float)Math.Sqrt(SquaredLength);
            set
            {
                var len = Length;
                X /= (value / len);
                Y /= (value / len);
                Z /= (value / len);
            }
        }

        /// <summary>
        /// このベクトルの単位ベクトルを取得します。
        /// </summary>
        public readonly Vector3F Normal => this / Length;

        /// <summary>
        /// ベクトルの長さの二乗を取得します。
        /// </summary>
        public readonly float SquaredLength => X * X + Y * Y + Z * Z;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X成分</param>
        /// <param name="y">Y成分</param>
        /// <param name="z">Z成分</param>
        public Vector3F(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Equivalence
        /// <summary>
        /// 2つの<see cref="Vector3F"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector3F v1, Vector3F v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector3F"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector3F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector3F other) => X == other.X && Y == other.Y && Z == other.Z;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector3F v ? Equals(v) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static bool operator ==(Vector3F v1, Vector3F v2) => Equals(v1, v2);

        public static bool operator !=(Vector3F v1, Vector3F v2) => !Equals(v1, v2);
        #endregion

        /// <summary>
        /// このベクトルを単位ベクトル化します。
        /// </summary>
        public void Normalize()
        {
            var length = Length;
            X /= length;
            Y /= length;
            Z /= length;
        }

        /// <summary>
        /// このベクトルを表す文字列取得します。
        /// </summary>
        /// <returns>このベクトルを表す文字列取得します。</returns>
        public readonly override string ToString() => $"({X}, {Y}, {Z})";

        /// <summary>
        /// <see cref="Vector3I"/>に型変換します。
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector3I"/>の新しいインスタンス</returns>
        public readonly Vector3I To3I() => new Vector3I((int)X, (int)Y, (int)Z);

        /// <summary>
        /// 外積を取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        /// <remarks>
        /// 右手の親指がv1、人差し指がv2としたとき、中指の方向を返します。。
        /// </remarks>
        public static Vector3F Cross(Vector3F v1, Vector3F v2)
        {
            Vector3F o = new Vector3F();
            float x = v1.Y * v2.Z - v1.Z * v2.Y;
            float y = v1.Z * v2.X - v1.X * v2.Z;
            float z = v1.X * v2.Y - v1.Y * v2.X;
            o.X = x;
            o.Y = y;
            o.Z = z;
            return o;
        }

        /// <summary>
        /// 内積を取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>内積v1・v2</returns>
        public static float Dot(Vector3F v1, Vector3F v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        /// <summary>
        /// 2点間の距離を取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>v1とv2の距離</returns>
        public static float Distance(Vector3F v1, Vector3F v2)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            float dz = v1.Z - v2.Z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        #region CalOperators
        /// <summary>
        /// 2つのベクトルを加算します。
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector3F operator +(Vector3F v1, Vector3F v2) => new Vector3F(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// ベクトルの符号を反転します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector3F operator -(Vector3F vector) => new Vector3F(-vector.X, -vector.Y, -vector.Z);

        /// <summary>
        /// 2つのベクトルを減算します。
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector3F operator -(Vector3F left, Vector3F right) => new Vector3F(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// 2つのベクトルを積算します。
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z)</returns>
        public static Vector3F operator *(Vector3F v1, Vector3F v2) => new Vector3F(v1.X * v2.X, v1.Y * v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector3F operator *(Vector3F vector, float scalar) => new Vector3F(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="scalar">積算する値</param>
        /// <param name="vector">積算するベクトル</param>
        /// <returns>積算結果</returns>
        public static Vector3F operator *(float scalar, Vector3F vector) => new Vector3F(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        /// <summary>
        /// 2つのベクトルを除算します。
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y, left.Z / right.Z)</returns>
        public static Vector3F operator /(Vector3F left, Vector3F right) => new Vector3F(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        /// <summary>
        /// ベクトルを値で除算します。
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar, vector.Z / scalar)</returns>
        public static Vector3F operator /(Vector3F vector, float scalar) => new Vector3F(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        #endregion

        public static implicit operator Vector3F(Vector3I v) => v.To3F();
        public static explicit operator Vector3I(Vector3F v) => v.To3I();
    }
}
