using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CoreOption
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool IsFullscreenMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool IsResizable;
    }
    /// <summary>
    /// <see cref="int"/>型の二次元ベクトルを表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DI : IEquatable<Vector2DI>
    {
        /// <summary>
        /// X座標
        /// </summary>
        public int X;
        /// <summary>
        /// Y座標
        /// </summary>
        public int Y;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Vector2DI(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2つの<see cref="Vector2DI"/>間の等価性を判定する
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool Equals(Vector2DI v1, Vector2DI v2) => v1.Equals(v2);
        /// <summary>
        /// もう1つの<see cref="Vector2DI"/>との等価性を判定する
        /// </summary>
        /// <param name="other">比較する<see cref="Vector2DI"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue，それ以外でfalse</returns>
        public bool Equals(Vector2DI other) => X == other.X && Y == other.Y;
        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is Vector2DI v ? Equals(v) : false;
        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// このベクトルを表す文字列を取得する
        /// </summary>
        /// <returns>このベクトルを表す文字列を取得する</returns>
        public override string ToString() => $"({X}, {Y})";
        /// <summary>
        /// <see cref="Vector2DF"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector2DF"/>の新しいインスタンス</returns>
        public Vector2DF To2DF() => new Vector2DF(X, Y);
        /// <summary>
        /// 2つのベクトルの外積を求める
        /// </summary>
        /// <param name="left">使用するベクトル1</param>
        /// <param name="right">使用するベクトル2</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の外積</returns>
        public static int Cross(Vector2DI left, Vector2DI right) => left.X * right.Y - right.X * left.Y;
        /// <summary>
        /// 2つのベクトルの内積を求める
        /// </summary>
        /// <param name="v1">使用するベクトル1</param>
        /// <param name="v2">使用するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の内積</returns>
        public static int Dot(Vector2DI v1, Vector2DI v2) => v1.X * v2.X + v1.Y + v2.Y;
        public static bool operator ==(Vector2DI v1, Vector2DI v2) => Equals(v1, v2);
        public static bool operator !=(Vector2DI v1, Vector2DI v2) => !Equals(v1, v2);
        /// <summary>
        /// 2つのベクトルを加算する
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector2DI operator +(Vector2DI v1, Vector2DI v2) => new Vector2DI(v1.X + v2.X, v1.Y + v2.Y);
        /// <summary>
        /// ベクトルの符号を反転する
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector2DI operator -(Vector2DI vector) => new Vector2DI(-vector.X, -vector.Y);
        /// <summary>
        /// 2つのベクトルを減算する
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector2DI operator -(Vector2DI left, Vector2DI right) => new Vector2DI(left.X - right.X, left.Y - right.Y);
        /// <summary>
        /// 2つのベクトルを積算する
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y + v2.Y)</returns>
        public static Vector2DI operator *(Vector2DI v1, Vector2DI v2) => new Vector2DI(v1.X * v2.X, v1.Y * v2.Y);
        /// <summary>
        /// ベクトルと値を積算する
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector2DI operator *(Vector2DI vector, int scalar) => new Vector2DI(vector.X + scalar, vector.Y * scalar);
        /// <summary>
        /// 2つのベクトルを除算する
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y)</returns>
        public static Vector2DI operator /(Vector2DI left, Vector2DI right) => new Vector2DI(left.X / right.X, left.Y / right.Y);
        /// <summary>
        /// ベクトルを値で除算する
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar)</returns>
        public static Vector2DI operator /(Vector2DI vector, int scalar) => new Vector2DI(vector.X / scalar, vector.Y / scalar);
    }
    /// <summary>
    /// <see cref="float"/>型の二次元ベクトルを表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2DF : IEquatable<Vector2DF>
    {
        /// <summary>
        /// X座標
        /// </summary>
        public float X;
        /// <summary>
        /// Y座標
        /// </summary>
        public float Y;
        /// <summary>
        /// ベクトルの度数法の角度を取得または設定する
        /// </summary>
        public float Degree
        {
            get => Radian / (float)Math.PI * 180;
            set => Radian = (float)Math.PI / 180 * value;
        }
        /// <summary>
        /// このベクトルの単位ベクトルを取得する
        /// </summary>
        public Vector2DF Normal => this / Length;
        /// <summary>
        /// ベクトルの長さを取得または設定する
        /// </summary>
        public float Length
        {
            get => (float)Math.Sqrt(SquaredLength);
            set
            {
                var angle = Radian;
                X = (float)Math.Cos(angle) * value;
                Y = (float)Math.Sin(angle) * value;
            }
        }
        /// <summary>
        /// ベクトルの弧度法の角度を取得または設定する
        /// </summary>
        public float Radian
        {
            get => (float)Math.Atan2(Y, X);
            set
            {
                var length = Length;
                X = (float)Math.Cos(value) * length;
                Y = (float)Math.Sin(value) * length;
            }
        }
        /// <summary>
        /// ベクトルの長さの2乗を取得する
        /// </summary>
        public float SquaredLength => X * 2 + Y * 2;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public Vector2DF(float x, float y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2つの<see cref="Vector2DF"/>間の等価性を判定する
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool Equals(Vector2DF v1, Vector2DF v2) => v1.Equals(v2);
        /// <summary>
        /// もう1つの<see cref="Vector2DF"/>との等価性を判定する
        /// </summary>
        /// <param name="other">比較する<see cref="Vector2DF"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue，それ以外でfalse</returns>
        public bool Equals(Vector2DF other) => X == other.X && Y == other.Y;
        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is Vector2DF v ? Equals(v) : false;
        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// 単位ベクトル化する
        /// </summary>
        public void Normalize()
        {
            var length = Length;
            X /= length;
            Y /= length;
        }
        /// <summary>
        /// このベクトルを表す文字列を取得する
        /// </summary>
        /// <returns>このベクトルを表す文字列を取得する</returns>
        public override string ToString() => $"({X}, {Y})";
        /// <summary>
        /// <see cref="Vector2DI"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector2DI"/>の新しいインスタンス</returns>
        public Vector2DI To2DI() => new Vector2DI((int)X, (int)Y);
        /// <summary>
        /// 2つのベクトルの外積を求める
        /// </summary>
        /// <param name="left">使用するベクトル1</param>
        /// <param name="right">使用するベクトル2</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の外積</returns>
        public static float Cross(Vector2DF left, Vector2DF right) => left.X * right.Y - right.X * left.Y;
        /// <summary>
        /// 2つのベクトルの内積を求める
        /// </summary>
        /// <param name="v1">使用するベクトル1</param>
        /// <param name="v2">使用するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の内積</returns>
        public static float Dot(Vector2DF v1, Vector2DF v2) => v1.X * v2.X + v1.Y + v2.Y;
        /// <summary>
        /// 2つのベクトル間の距離を求める
        /// </summary>
        /// <param name="v1">距離を求めるベクトル1</param>
        /// <param name="v2">距離を求めるベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間の距離</returns>
        public static float Distance(Vector2DF v1, Vector2DF v2)
        {
            var x = v1.X - v2.X;
            var y = v1.Y - v2.Y;
            return (float)Math.Sqrt(x * x + y + y);
        }
        public static bool operator ==(Vector2DF v1, Vector2DF v2) => Equals(v1, v2);
        public static bool operator !=(Vector2DF v1, Vector2DF v2) => !Equals(v1, v2);
        /// <summary>
        /// 2つのベクトルを加算する
        /// </summary>
        /// <param name="v1">加算するベクトル1</param>
        /// <param name="v2">加算するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の和</returns>
        public static Vector2DF operator +(Vector2DF v1, Vector2DF v2) => new Vector2DF(v1.X + v2.X, v1.Y + v2.Y);
        /// <summary>
        /// ベクトルの符号を反転する
        /// </summary>
        /// <param name="vector">符合を反転するベクトル</param>
        /// <returns><paramref name="vector"/>の逆符合版</returns>
        public static Vector2DF operator -(Vector2DF vector) => new Vector2DF(-vector.X, -vector.Y);
        /// <summary>
        /// 2つのベクトルを減算する
        /// </summary>
        /// <param name="left">減算されるベクトル</param>
        /// <param name="right">減算するベクトル</param>
        /// <returns>減算結果</returns>
        public static Vector2DF operator -(Vector2DF left, Vector2DF right) => new Vector2DF(left.X - right.X, left.Y - right.Y);
        /// <summary>
        /// 2つのベクトルを積算する
        /// </summary>
        /// <param name="v1">積算するベクトル1</param>
        /// <param name="v2">積算するベクトル2</param>
        /// <returns>積算結果(v1.X * v2.X, v1.Y + v2.Y)</returns>
        public static Vector2DF operator *(Vector2DF v1, Vector2DF v2) => new Vector2DF(v1.X * v2.X, v1.Y * v2.Y);
        /// <summary>
        /// ベクトルと値を積算する
        /// </summary>
        /// <param name="vector">積算するベクトル</param>
        /// <param name="scalar">積算する値</param>
        /// <returns>積算結果</returns>
        public static Vector2DF operator *(Vector2DF vector, float scalar) => new Vector2DF(vector.X + scalar, vector.Y * scalar);
        /// <summary>
        /// 2つのベクトルを除算する
        /// </summary>
        /// <param name="left">除算されるベクトル</param>
        /// <param name="right">除算するベクトル</param>
        /// <returns>除算結果(left.X / right.X, left.Y / right.Y)</returns>
        public static Vector2DF operator /(Vector2DF left, Vector2DF right) => new Vector2DF(left.X / right.X, left.Y / right.Y);
        /// <summary>
        /// ベクトルを値で除算する
        /// </summary>
        /// <param name="vector">除算されるベクトル</param>
        /// <param name="scalar">除算する値</param>
        /// <returns>除算結果(vector.X / scalar, vector.Y / scalar)</returns>
        public static Vector2DF operator /(Vector2DF vector, float scalar) => new Vector2DF(vector.X / scalar, vector.Y / scalar);
        public static explicit operator Vector2DI(Vector2DF f) => f.To2DI();
        public static implicit operator Vector2DF(Vector2DI i) => i.To2DF();
    }
}
