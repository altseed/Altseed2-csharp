using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の4x4行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix44I
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 4 * 4)]
        public int[,] Values;

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
            Matrix44I o_ = new Matrix44I();
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
    }
}
