using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の二次元ベクトルを表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2F : IEquatable<Vector2F>
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
        /// ベクトルの度数法の角度を取得または設定します。
        /// </summary>
        public float Degree
        {
            readonly get => MathHelper.RadianToDegree(Radian);
            set
            {
                Radian = MathHelper.DegreeToRadian(value);
            }
        }

        /// <summary>
        /// このベクトルの単位ベクトル取得します。
        /// </summary>
        public readonly Vector2F Normal => this / Length;

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
            }
        }

        /// <summary>
        /// ベクトルの弧度法の角度を取得または設定します。
        /// </summary>
        public float Radian
        {
            readonly get => (float)Math.Atan2(Y, X);
            set
            {
                var length = Length;
                X = (float)Math.Cos(value) * length;
                Y = (float)Math.Sin(value) * length;
            }
        }

        /// <summary>
        /// ベクトルの長さの2乗取得します。
        /// </summary>
        public readonly float SquaredLength => X * X + Y * Y;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        #region Equivalence
        /// <summary>
        /// 2つの<see cref="Vector2F"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector2F v1, Vector2F v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector2F"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector2F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector2F other) => X == other.X && Y == other.Y;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector2F v ? Equals(v) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Vector2F v1, Vector2F v2) => Equals(v1, v2);

        public static bool operator !=(Vector2F v1, Vector2F v2) => !Equals(v1, v2);
        #endregion

        /// <summary>
        /// 単位ベクトル化します。
        /// </summary>
        public void Normalize()
        {
            var length = Length;
            X /= length;
            Y /= length;
        }

        /// <summary>
        /// このベクトルを表す文字列取得します。
        /// </summary>
        /// <returns>このベクトルを表す文字列取得します。</returns>
        public readonly override string ToString() => $"({X}, {Y})";

        /// <summary>
        /// <see cref="Vector2I"/>に型変換します。
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector2I"/>の新しいインスタンス</returns>
        public readonly Vector2I To2I() => new Vector2I((int)X, (int)Y);

        /// <summary>
        /// 2つのベクトルの外積を求めます。
        /// </summary>
        /// <param name="left">使用するベクトル1</param>
        /// <param name="right">使用するベクトル2</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の外積</returns>
        public static float Cross(Vector2F left, Vector2F right) => left.X * right.Y - right.X * left.Y;

        /// <summary>
        /// 2つのベクトル間の距離を求めます。
        /// </summary>
        /// <param name="v1">距離を求めるベクトル1</param>
        /// <param name="v2">距離を求めるベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間の距離</returns>
        public static float Distance(Vector2F v1, Vector2F v2)
        {
            var x = v1.X - v2.X;
            var y = v1.Y - v2.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// 2つのベクトルの内積を求めます。
        /// </summary>
        /// <param name="v1">使用するベクトル1</param>
        /// <param name="v2">使用するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の内積</returns>
        public static float Dot(Vector2F v1, Vector2F v2) => v1.X * v2.X + v1.Y + v2.Y;

        #region CalOperators
        /// <summary>
        /// 2つのベクトルを加算します。
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector2F operator +(Vector2F v1, Vector2F v2) => new Vector2F(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// ベクトルの符号を反転します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector2F operator -(Vector2F vector) => new Vector2F(-vector.X, -vector.Y);

        /// <summary>
        /// 与えられたベクトルを返します。
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/></returns>
        public static Vector2F operator +(Vector2F vector) => vector;

        /// <summary>
        /// 2つのベクトルを減算します。
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector2F operator -(Vector2F left, Vector2F right) => new Vector2F(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 2つのベクトルを積算します。
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y * v2.Y)</returns>
        public static Vector2F operator *(Vector2F v1, Vector2F v2) => new Vector2F(v1.X * v2.X, v1.Y * v2.Y);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector2F operator *(Vector2F vector, float scalar) => new Vector2F(vector.X * scalar, vector.Y * scalar);

        /// <summary>
        /// ベクトルと値を積算します。
        /// </summary>
        /// <param name="scalar">積算する値</param>
        /// <param name="vector">積算するベクトル</param>
        /// <returns>積算結果</returns>
        public static Vector2F operator *(float scalar, Vector2F vector) => new Vector2F(vector.X * scalar, vector.Y * scalar);

        /// <summary>
        /// 2つのベクトルを除算します。
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y)</returns>
        public static Vector2F operator /(Vector2F left, Vector2F right) => new Vector2F(left.X / right.X, left.Y / right.Y);

        /// <summary>
        /// ベクトルを値で除算します。
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar)</returns>
        public static Vector2F operator /(Vector2F vector, float scalar) => new Vector2F(vector.X / scalar, vector.Y / scalar);
        #endregion

        public static explicit operator Vector2I(Vector2F f) => f.To2I();

        public static implicit operator Vector2F(Vector2I i) => i.To2F();
    }
}
