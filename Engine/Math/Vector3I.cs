using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Altseed
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
        /// コンストラクタ
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

        public override string ToString() => $"({X}, {Y}, {Z})";

        /// <summary>
        /// <see cref="Vector3F"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="Vector3F"/>の新しいインスタンス</returns>
        public Vector2F To3F() => new Vector2F(X, Y);


        public static bool operator ==(Vector3I left, Vector3I right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }
        public static bool operator !=(Vector3I left, Vector3I right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z;
        }
        public static Vector3I operator +(Vector3I left, Vector3I right)
        {
            return new Vector3I(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        public static Vector3I operator -(Vector3I left, Vector3I right)
        {
            return new Vector3I(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Vector3I operator -(Vector3I op)
        {
            return new Vector3I(-op.X, -op.Y, -op.Z);
        }
        public static Vector3I operator *(Vector3I op, int scolar)
        {
            return new Vector3I(op.X * scolar, op.Y * scolar, op.Z * scolar);
        }
        public static Vector3I operator *(int scolar, Vector3I op)
        {
            return new Vector3I(scolar * op.X, scolar * op.Y, scolar * op.Z);
        }
        public static Vector3I operator *(Vector3I left, Vector3I right)
        {
            return new Vector3I(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }
        public static Vector3I operator /(Vector3I op, int scolar)
        {
            return new Vector3I(op.X / scolar, op.Y / scolar, op.Z / scolar);
        }
        public static Vector3I operator /(Vector3I left, Vector3I right)
        {
            return new Vector3I(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        /// <summary>
        /// 内積を取得する。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>内積v1・v2</returns>
        public static int Dot(Vector3I v1, Vector3I v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>
        /// 外積を取得する。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>外積v1×v2</returns>
        /// <remarks>
        /// 右手の親指がv1、人差し指がv2としたとき、中指の方向を返す。
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
        /// 加算する。
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3I Add(Vector3I v1, Vector3I v2)
        {
            Vector3I o = new Vector3I();
            o.X = v1.X + v2.X;
            o.Y = v1.Y + v2.Y;
            o.Z = v1.Z + v2.Z;
            return o;
        }

        /// <summary>
        /// 減算する。
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3I Subtract(Vector3I v1, Vector3I v2)
        {
            Vector3I o = new Vector3I();
            o.X = v1.X - v2.X;
            o.Y = v1.Y - v2.Y;
            o.Z = v1.Z - v2.Z;
            return o;
        }

        /// <summary>
        /// 除算する。
        /// </summary>
        /// <param name="v1">値1</param>
        /// <param name="v2">値2</param>
        /// <returns>v1/v2</returns>
        public static Vector3I Divide(Vector3I v1, Vector3I v2)
        {
            var ret = new Vector3I();
            ret.X = v1.X / v2.X;
            ret.Y = v1.Y / v2.Y;
            ret.Z = v1.Z / v2.Z;
            return ret;
        }

        /// <summary>
        /// スカラーで除算する。
        /// </summary>
        /// <param name="v1">値1</param>
        /// <param name="v2">値2</param>
        /// <returns>v1/v2</returns>
        public static Vector3I DivideByScalar(Vector3I v1, int v2)
        {
            var ret = new Vector3I();
            ret.X = v1.X / v2;
            ret.Y = v1.Y / v2;
            ret.Z = v1.Z / v2;
            return ret;
        }

        /// <summary>
        /// 2点間の距離を取得する。
        /// </summary>
        /// <param name="v1">v1ベクトル</param>
        /// <param name="v2">v2ベクトル</param>
        /// <returns>v1とv2の距離</returns>
        public static float Distance(Vector3I v1, Vector3I v2)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            float dz = v1.Z - v2.Z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is Vector3I f && Equals(f);

        /// <summary>
        /// 2つの<see cref="Vector3I"/>間の等価性を判定する
        /// </summary>
        /// <param name="v1">等価性を判定するベクトル1</param>
        /// <param name="v2">等価性を判定するベクトル2</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間に等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool Equals(Vector3I v1, Vector3I v2) => v1.Equals(v2);


        /// <summary>
        /// もう1つの<see cref="Vector3I"/>との等価性を判定する
        /// </summary>
        /// <param name="other">比較する<see cref="Vector3I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>等価性をが認められたらtrue，それ以外でfalse</returns>
        public bool Equals(Vector3I other) => X == other.X && Y == other.Y && Z == other.Z;

        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = -1843799377;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
    }
}
