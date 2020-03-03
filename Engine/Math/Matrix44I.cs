using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の4x4行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix44I : ICloneable, IEquatable<Matrix44I>
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 4 * 4)]
        public int[,] Values;

        internal static Matrix44I GetIdentity()
        {
            var result = new Matrix44I();
            result.SetIdentity();
            return result;
        }

        public void SetIdentity()
        {
            if (Values == null)
                Values = new int[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Values[i, j] = 0;

            Values[0, 0] = 1;
            Values[1, 1] = 1;
            Values[2, 2] = 1;
            Values[3, 3] = 1;
        }

        public void SetTranslation(int x, int y, int z)
        {
            SetIdentity();
            Values[0, 3] = x;
            Values[1, 3] = y;
            Values[2, 3] = z;
        }

        /// <summary>
        /// 転置行列を設定します。
        /// </summary>
        public void SetTransposed()
        {
            for (int c = 0; c < 4; c++)
            {
                for (int r = c; r < 4; r++)
                {
                    int v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
                }
            }
        }

        /// <summary>
        /// クオータニオンを元に回転行列(右手)を設定します。
        /// </summary>
        /// <param name="x">クオータニオン</param>
        /// <param name="y">クオータニオン</param>
        /// <param name="z">クオータニオン</param>
        /// <param name="w">クオータニオン</param>
        public void SetQuaternion(int x, int y, int z, int w)
        {
            int xx = x * x;
            int yy = y * y;
            int zz = z * z;
            int xy = x * y;
            int xz = x * z;
            int yz = y * z;
            int wx = w * x;
            int wy = w * y;
            int wz = w * z;

            Values[0, 0] = 1 - 2 * (yy + zz);
            Values[0, 1] = 2 * (xy - wz);
            Values[0, 2] = 2 * (xz + wy);
            Values[0, 3] = 0;

            Values[1, 0] = 2 * (xy + wz);
            Values[1, 1] = 1 - 2 * (xx + zz);
            Values[1, 2] = 2 * (yz - wx);
            Values[1, 3] = 0;

            Values[2, 0] = 2 * (xz - wy);
            Values[2, 1] = 2 * (yz + wx);
            Values[2, 2] = 1 - 2 * (xx + yy);
            Values[2, 3] = 0;

            Values[3, 0] = 0;
            Values[3, 1] = 0;
            Values[3, 2] = 0;
            Values[3, 3] = 1;
            return;
        }

        /// <summary>
        /// 拡大行列を設定します。
        /// </summary>
        /// <param name="x">X方向拡大率</param>
        /// <param name="y">Y方向拡大率</param>
        /// <param name="z">Z方向拡大率</param>
        public void SetScale(int x, int y, int z)
        {
            SetIdentity();
            Values[0, 0] = x;
            Values[1, 1] = y;
            Values[2, 2] = z;
            Values[3, 3] = 1;
            return;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public Vector3I Transform3D(Vector3I in_)
        {
            int[] values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += in_.Z * Values[i, 2];
                values[i] += Values[i, 3];
            }

            Vector3I o;
            o.X = values[0] / values[3];
            o.Y = values[1] / values[3];
            o.Z = values[2] / values[3];
            return o;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public Vector4I Transform4D(Vector4I in_)
        {
            int[] values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += in_.Z * Values[i, 2];
                values[i] += in_.W * Values[i, 3];
            }

            Vector4I o;
            o.X = values[0];
            o.Y = values[1];
            o.Z = values[2];
            o.W = values[3];

            return o;
        }


        public static Matrix44I operator *(Matrix44I left, Matrix44I right)
        {
            Matrix44I o_ = new Matrix44I() { Values = new int[4, 4] };
            Mul(ref o_, ref left, ref right);
            return o_;
        }

        public static Vector3I operator *(Matrix44I left, Vector3I right)
        {
            return left.Transform3D(right);
        }

        /// <summary>
        /// 乗算を行う。
        /// </summary>
        /// <param name="o">出力先</param>
        /// <param name="in1">行列1</param>
        /// <param name="in2">行列2</param>
        public static void Mul(ref Matrix44I o, ref Matrix44I in1, ref Matrix44I in2)
        {
            Matrix44I _in1 = in1;
            Matrix44I _in2 = in2;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int v = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        v += _in1.Values[i, k] * _in2.Values[k, j];
                    }
                    o.Values[i, j] = v;
                }
            }
        }

        #region IEquatable
        /// <summary>
        /// 2つの<see cref="Matrix44I"/>間の等価性を判定する
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix44I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix44I other)
        {
            if (Values == null || other.Values == null) return false;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (Values[i, j] != other.Values[i, j])
                        return false;
            return true;
        }

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間の等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Matrix44I m ? Equals(m) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            var hash = new HashCode();
            if (Values == null) return 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    hash.Add(Values[i, j]);
            return hash.ToHashCode();
        }

        public static Matrix44I operator +(Matrix44I left, Matrix44I right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix44I() { Values = new int[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] + right.Values[i, j];
            return result;
        }

        public static Matrix44I operator -(Matrix44I matrix) => -1 * matrix;

        public static Matrix44I operator -(Matrix44I left, Matrix44I right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix44I() { Values = new int[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] - right.Values[i, j];
            return result;
        }

        public static Matrix44I operator *(Matrix44I matrix, int scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix44I() { Values = new int[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] * scalar;
            return result;
        }

        public static Matrix44I operator *(int scalar, Matrix44I matrix) => matrix * scalar;

        public static Matrix44I operator /(Matrix44I matrix, int scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix44I() { Values = new int[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] / scalar;
            return result;
        }

        public static bool operator ==(Matrix44I m1, Matrix44I m2) => m1.Equals(m2);
        public static bool operator !=(Matrix44I m1, Matrix44I m2) => !m1.Equals(m2);
        #endregion

        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <returns>このインスタンスの複製</returns>
        public readonly Matrix44I Clone()
        {
            if (Values == null) return default;
            var clone = new Matrix44I
            {
                Values = new int[4, 4]
            };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    clone.Values[i, j] = Values[i, j];
            return clone;
        }
        object ICloneable.Clone() => Clone();
    }
}
