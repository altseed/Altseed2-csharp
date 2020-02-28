using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の3x3行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix33I : ICloneable, IEquatable<Matrix33I>
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 3 * 3)]
        public int[,] Values;

        internal static Matrix33I GetIdentity()
        {
            var result = new Matrix33I();
            result.SetIdentity();
            return result;
        }

        /// <summary>
        /// 単位行列を設定します。
        /// </summary>
        public void SetIdentity()
        {
            if (Values == null)
                Values = new int[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Values[i, j] = 0;

            Values[0, 0] = 1;
            Values[1, 1] = 1;
            Values[2, 2] = 1;
        }

        /// <summary>
        /// 平行移動の行列を設定します。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTranslation(int x, int y)
        {
            SetIdentity();
            Values[0, 2] = x;
            Values[1, 2] = y;
        }

        /// <summary>
        /// 転置行列を設定します。
        /// </summary>
        public void SetTransposed()
        {
            for (int c = 0; c < 3; c++)
            {
                for (int r = c; r < 3; r++)
                {
                    int v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
                }
            }
        }


        /// <summary>
        /// 拡大・縮小行列を設定します。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(int x, int y)
        {
            SetIdentity();
            Values[0, 0] = x;
            Values[1, 1] = y;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public Vector2I Transform2D(Vector2I in_)
        {
            int[] values = new int[3];

            for (int i = 0; i < 2; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += 1 * Values[i, 2];
            }

            Vector2I o;
            o.X = values[0];
            o.Y = values[1];
            return o;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        Vector3I Transform3D(Vector3I in_)
        {
            int[] values = new int[3];

            for (int i = 0; i < 3; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += in_.Z * Values[i, 2];
            }

            Vector3I o;
            o.X = values[0];
            o.Y = values[1];
            o.Z = values[2];
            return o;
        }

        public static Matrix33I operator +(Matrix33I left, Matrix33I right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix33I() { Values = new int[3, 3] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] + right.Values[i, j];
            return result;
        }

        public static Matrix33I operator -(Matrix33I matrix) => -1 * matrix;

        public static Matrix33I operator -(Matrix33I left, Matrix33I right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix33I() { Values = new int[3, 3] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] - right.Values[i, j];
            return result;
        }

        public static Matrix33I operator *(Matrix33I matrix, int scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix33I() { Values = new int[3, 3] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] * scalar;
            return result;
        }

        public static Matrix33I operator *(int scalar, Matrix33I matrix) => matrix * scalar;

        public static Matrix33I operator /(Matrix33I matrix, int scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix33I() { Values = new int[3, 3] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] / scalar;
            return result;
        }

        public static Matrix33I operator *(Matrix33I left, Matrix33I right)
        {
            Matrix33I result = new Matrix33I() { Values = new int[3, 3] };

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    result.Values[i, j] = 0;
                    for (int k = 0; k < 3; ++k)
                    {
                        result.Values[i, j] += left.Values[i, k] * right.Values[k, j];
                    }
                }
            }

            return result;
        }

        public static Vector3I operator *(Matrix33I left, Vector3I right)
        {
            int[] elements = { 0, 0, 0 };
            int[] rop = { right.X, right.Y, right.Z };

            for (int i = 0; i < 3; ++i)
            {
                for (int k = 0; k < 3; ++k)
                {
                    elements[i] += left.Values[i, k] * rop[k];
                }
            }

            return new Vector3I(elements[0], elements[1], elements[2]);
        }

        #region IEquatable
        /// <summary>
        /// 2つの<see cref="Matrix33I"/>間の等価性を判定する
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix33I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix33I other)
        {
            if (Values == null || other.Values == null) return false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Values[i, j] != other.Values[i, j])
                        return false;
            return true;
        }

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間の等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Matrix33I m ? Equals(m) : false;

        /// <summary>
        /// このオブジェクトのハッシュコードを返す
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            var hash = new HashCode();
            if (Values == null) return 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    hash.Add(Values[i, j]);
            return hash.ToHashCode();
        }

        public static bool operator ==(Matrix33I m1, Matrix33I m2) => m1.Equals(m2);
        public static bool operator !=(Matrix33I m1, Matrix33I m2) => !m1.Equals(m2);
        #endregion

        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <returns>このインスタンスの複製</returns>
        public readonly Matrix33I Clone()
        {
            if (Values == null) return default;
            var clone = new Matrix33I
            {
                Values = new int[4, 4]
            };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    clone.Values[i, j] = Values[i, j];
            return clone;
        }
        object ICloneable.Clone() => Clone();
    }
}
