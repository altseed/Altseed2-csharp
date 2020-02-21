using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Altseed
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
        /// コンストラクタ
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

        public override string ToString() => $"({X}, {Y}, {Z}, {W})";

        /// <summary>
        /// <see cref="Vector4F"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector4F"/>の新しいインスタンス</returns>
        public Vector4F To4F() => new Vector4F(X, Y, Z, W);



        public static bool operator ==(Vector4I left, Vector4I right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;
        }
        public static bool operator !=(Vector4I left, Vector4I right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;
        }
        public static Vector4I operator +(Vector4I left, Vector4I right)
        {
            return new Vector4I(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Vector4I operator -(Vector4I left, Vector4I right)
        {
            return new Vector4I(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vector4I operator -(Vector4I op)
        {
            return new Vector4I(-op.X, -op.Y, -op.Z, -op.W);
        }
        public static Vector4I operator *(Vector4I op, int scolar)
        {
            return new Vector4I(op.X * scolar, op.Y * scolar, op.Z * scolar, op.W * scolar);
        }
        public static Vector4I operator *(int scolar, Vector4I op)
        {
            return new Vector4I(scolar * op.X, scolar * op.Y, scolar * op.Z, scolar * op.W);
        }
        public static Vector4I operator *(Vector4I left, Vector4I right)
        {
            return new Vector4I(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }
        public static Vector4I operator /(Vector4I op, int scolar)
        {
            return new Vector4I(op.X / scolar, op.Y / scolar, op.Z / scolar, op.W / scolar);
        }
        public static Vector4I operator /(Vector4I left, Vector4I right)
        {
            return new Vector4I(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        /// <summary>
        /// 外積を取得する。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        public static int Dot(Vector4I v1, Vector4I v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z + v1.W * v2.W;
        }

        /// <summary>
        /// 2点間の距離を取得する。
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
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        /// <summary>
        /// 2つの<see cref="Vector4I"/>間の等価性を判定する
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool Equals(Vector4I v1, Vector4I v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector4I"/>との等価性を判定する
        /// </summary>
        /// <param name="other">比較する<see cref="Vector4I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue，それ以外でfalse</returns>
        public bool Equals(Vector4I other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is Vector4I v ? Equals(v) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + W.GetHashCode();
            return hashCode;
        }

    }
}