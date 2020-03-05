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
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 4 * 4)]
        private int[,] Values;

        /// <summary>
        /// 指定した位置の値を取得または設定する
        /// </summary>
        /// <param name="x">取得する要素の位置</param>
        /// <param name="y">取得する要素の位置</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="x"/>または<paramref name="y"/>が0未満または4以上</exception>
        /// <returns><paramref name="x"/>と<paramref name="y"/>に対応する値</returns>
        public int this[int x, int y]
        {
            readonly get
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                return Values?[x, y] ?? 0;
            }
            set
            {
                Values ??= new int[4, 4];
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                Values[x, y] = value;
            }
        }

        internal static Matrix44I GetIdentity()
        {
            var result = new Matrix44I();
            result.SetIdentity();
            return result;
        }

        /// <summary>
        /// 単位行列に設定する
        /// </summary>
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

        /// <summary>
        /// 行列を平行移動させる
        /// </summary>
        /// <param name="x">平行移動するX座標</param>
        /// <param name="y">平行移動するY座標</param>
        /// <param name="z">平行移動するZ座標</param>
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
            SetIdentity();
            for (int c = 0; c < 4; c++)
                for (int r = c; r < 4; r++)
                {
                    int v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
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
            SetIdentity();
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
        public readonly Vector3I Transform3D(Vector3I in_)
        {
            int[] values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += this[i, 3];
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
        public readonly Vector4I Transform4D(Vector4I in_)
        {
            int[] values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += in_.W * this[i, 3];
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
            var o_ = new Matrix44I();
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
                        v += _in1[i, k] * _in2[k, j];
                    }
                    o[i, j] = v;
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
            if (Values == null && other.Values == null) return true;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (this[i, j] != other[i, j])
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
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    hash.Add(this[i, j]);
            return hash.ToHashCode();
        }

        public static Matrix44I operator +(Matrix44I left, Matrix44I right)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = left[i, j] + right[i, j];
            return result;
        }

        public static Matrix44I operator -(Matrix44I matrix) => -1 * matrix;

        public static Matrix44I operator -(Matrix44I left, Matrix44I right)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = left[i, j] - right[i, j];
            return result;
        }

        public static Matrix44I operator *(Matrix44I matrix, int scalar)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = matrix[i, j] * scalar;
            return result;
        }

        public static Matrix44I operator *(int scalar, Matrix44I matrix) => matrix * scalar;

        public static Matrix44I operator /(Matrix44I matrix, int scalar)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = matrix[i, j] / scalar;
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
            var clone = new Matrix44I();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    clone[i, j] = this[i, j];
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();
    }
}
