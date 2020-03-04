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
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 3 * 3)]
        private int[,] Values;

        /// <summary>
        /// 指定した位置の値を取得または設定する
        /// </summary>
        /// <param name="x">取得する要素の位置</param>
        /// <param name="y">取得する要素の位置</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="x"/>または<paramref name="y"/>が0未満または3以上</exception>
        /// <returns><paramref name="x"/>と<paramref name="y"/>に対応する値</returns>
        public int this[int x, int y]
        {
            readonly get
            {
                if (x < 0 || x >= 3) throw new ArgumentOutOfRangeException("引数の値は0-2に収めてください", nameof(x));
                if (y < 0 || y >= 3) throw new ArgumentOutOfRangeException("引数の値は0-2に収めてください", nameof(y));
                return Values?[x, y] ?? 0;
            }
            set
            {
                Values ??= new int[3, 3];
                if (x < 0 || x >= 3) throw new ArgumentOutOfRangeException("引数の値は0-2に収めてください", nameof(x));
                if (y < 0 || y >= 3) throw new ArgumentOutOfRangeException("引数の値は0-2に収めてください", nameof(y));
                Values[x, y] = value;
            }
        }

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
            SetIdentity();
            for (int c = 0; c < 3; c++)
                for (int r = c; r < 3; r++)
                {
                    int v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
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
        public readonly Vector2I Transform2D(Vector2I in_)
        {
            int[] values = new int[3];

            for (int i = 0; i < 2; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += 1 * this[i, 2];
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
        public readonly Vector3I Transform3D(Vector3I in_)
        {
            int[] values = new int[3];

            for (int i = 0; i < 3; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
            }

            Vector3I o;
            o.X = values[0];
            o.Y = values[1];
            o.Z = values[2];
            return o;
        }

        public static Matrix33I operator +(Matrix33I left, Matrix33I right)
        {
            var result = new Matrix33I();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = left[i, j] + right[i, j];
            return result;
        }

        public static Matrix33I operator -(Matrix33I matrix) => -1 * matrix;

        public static Matrix33I operator -(Matrix33I left, Matrix33I right)
        {
            var result = new Matrix33I();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = left[i, j] - right[i, j];
            return result;
        }

        public static Matrix33I operator *(Matrix33I matrix, int scalar)
        {
            var result = new Matrix33I();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = matrix[i, j] * scalar;
            return result;
        }

        public static Matrix33I operator *(int scalar, Matrix33I matrix) => matrix * scalar;

        public static Matrix33I operator /(Matrix33I matrix, int scalar)
        {
            var result = new Matrix33I();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = matrix[i, j] / scalar;
            return result;
        }

        public static Matrix33I operator *(Matrix33I left, Matrix33I right)
        {
            var result = new Matrix33I();

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 3; ++k)
                    {
                        result[i, j] += left[i, k] * right[k, j];
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
                    elements[i] += left[i, k] * rop[k];
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
            if (Values == null && other.Values == null) return true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this[i, j] != other[i, j])
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
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    hash.Add(this[i, j]);
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
            var clone = new Matrix33I();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    clone[i, j] = this[i, j];
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();
    }
}
