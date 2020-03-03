using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// 4次元ベクトル
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4F : IEquatable<Vector4F>
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
        /// W成分
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float W;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="z">Z座標</param>
        /// <param name="w">W座標</param>
        public Vector4F(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public readonly override string ToString() => $"({X}, {Y}, {Z}, {W})";

        /// <summary>
        /// <see cref="Vector4I"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector4I"/>の新しいインスタンス</returns>
        public readonly Vector4I To4I() => new Vector4I((int)X, (int)Y, (int)Z, (int)W);


        /// <summary>
        /// ベクトルの長さを取得または設定します。
        /// </summary>
        public float Length
        {
            readonly get { return (float)Math.Sqrt(SquaredLength); }
            set
            {
                var len = Length;
                X /= (value / len);
                Y /= (value / len);
                Z /= (value / len);
                W /= (value / len);
            }
        }
        /// <summary>
        /// ベクトルの長さの二乗取得します。
        /// </summary>
        public readonly float SquaredLength
        {
            get { return X * X + Y * Y + Z * Z + W * W + Z * Z; }
        }

        /// <summary>
        /// このベクトルの単位ベクトル取得します。
        /// </summary>
        public readonly Vector4F Normal => this / Length;

        /// <summary>
        /// このベクトルを単位ベクトル化します。
        /// </summary>
        public void Normalize()
        {
            float length = Length;
            X /= length;
            Y /= length;
            Z /= length;
            W /= length;
        }

        public static bool operator ==(Vector4F left, Vector4F right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;
        }
        public static bool operator !=(Vector4F left, Vector4F right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;
        }
        public static Vector4F operator +(Vector4F left, Vector4F right)
        {
            return new Vector4F(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Vector4F operator -(Vector4F left, Vector4F right)
        {
            return new Vector4F(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vector4F operator -(Vector4F op)
        {
            return new Vector4F(-op.X, -op.Y, -op.Z, -op.W);
        }
        public static Vector4F operator *(Vector4F op, float scolar)
        {
            return new Vector4F(op.X * scolar, op.Y * scolar, op.Z * scolar, op.W * scolar);
        }
        public static Vector4F operator *(float scolar, Vector4F op)
        {
            return new Vector4F(scolar * op.X, scolar * op.Y, scolar * op.Z, scolar * op.W);
        }
        public static Vector4F operator *(Vector4F left, Vector4F right)
        {
            return new Vector4F(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }
        public static Vector4F operator /(Vector4F op, float scolar)
        {
            return new Vector4F(op.X / scolar, op.Y / scolar, op.Z / scolar, op.W / scolar);
        }
        public static Vector4F operator /(Vector4F left, Vector4F right)
        {
            return new Vector4F(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        /// <summary>
        /// 外積取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        public static float Dot(Vector4F v1, Vector4F v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z + v1.W * v2.W;
        }

        /// <summary>
        /// 2点間の距離取得します。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>v1とv2の距離</returns>
        public static float Distance(Vector4F v1, Vector4F v2)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            float dz = v1.Z - v2.Z;
            float dw = v1.W - v2.W;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        /// <summary>
        /// 2つの<see cref="Vector4F"/>間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue、それ以外でfalse</returns>
        public static bool Equals(Vector4F v1, Vector4F v2) => v1.Equals(v2);

        /// <summary>
        /// もう1つの<see cref="Vector4F"/>との等価性を判定します。
        /// </summary>
        /// <param name="other">比較する<see cref="Vector4F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue、それ以外でfalse</returns>
        public readonly bool Equals(Vector4F other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue、それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vector4F v ? Equals(v) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
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