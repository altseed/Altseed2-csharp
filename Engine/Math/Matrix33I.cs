using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の3x3行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix33I
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 3 * 3)]
        public int[,] Values;

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



        public static Matrix33I operator *(Matrix33I left, Matrix33I right)
        {
            Matrix33I result = new Matrix33I();

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
    }
}
