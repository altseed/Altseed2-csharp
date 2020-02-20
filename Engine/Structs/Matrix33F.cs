using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の3x3行列表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix33F
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 3 * 3)]
        public float[,] Values;

        /// <summary>
        /// 単位行列を設定する
        /// </summary>
        public void SetIdentity()
        {
            if (Values == null)
                Values = new float[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Values[i, j] = 0.0f;

            Values[0, 0] = 1.0f;
            Values[1, 1] = 1.0f;
            Values[2, 2] = 1.0f;
        }

        /// <summary>
        /// 平行移動の行列を設定する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTranslation(float x, float y)
        {
            SetIdentity();
            Values[0, 2] = x;
            Values[1, 2] = y;
        }

        /// <summary>
        /// 転置行列を設定する。
        /// </summary>
        public void SetTransposed()
        {
            for (int c = 0; c < 3; c++)
            {
                for (int r = c; r < 3; r++)
                {
                    float v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
                }
            }
        }

        /// <summary>
        /// 逆行列を設定する
        /// </summary>
        public void SetInverted()
        {
            float e = 0.00001f;

            float a11 = Values[0, 0];
            float a12 = Values[0, 1];
            float a13 = Values[0, 2];
            float a21 = Values[1, 0];
            float a22 = Values[1, 1];
            float a23 = Values[1, 2];
            float a31 = Values[2, 0];
            float a32 = Values[2, 1];
            float a33 = Values[2, 2];

            /* 行列式の計算 */
            float b11 = +a22 * a33 - a23 * a32;
            float b12 = +a13 * a32 - a12 * a33;
            float b13 = +a12 * a23 - a13 * a22;

            float b21 = +a23 * a31 - a21 * a33;
            float b22 = +a11 * a33 - a13 * a31;
            float b23 = +a13 * a21 - a11 * a23;

            float b31 = +a21 * a32 - a22 * a31;
            float b32 = +a12 * a31 - a11 * a32;
            float b33 = +a11 * a22 - a12 * a21;

            // 行列式の逆数をかける
            float Det = a11 * a22 * a33 + a21 * a32 * a13 + a31 * a12 * a23 - a11 * a32 * a23 - a31 * a22 * a13 - a21 * a12 * a33;
            if ((-e <= Det) && (Det <= +e))
            {
                return;
            }

            float InvDet = 1.0f / Det;

            Values[0, 0] = b11 * InvDet;
            Values[0, 1] = b12 * InvDet;
            Values[0, 2] = b13 * InvDet;
            Values[1, 0] = b21 * InvDet;
            Values[1, 1] = b22 * InvDet;
            Values[1, 2] = b23 * InvDet;
            Values[2, 0] = b31 * InvDet;
            Values[2, 1] = b32 * InvDet;
            Values[2, 2] = b33 * InvDet;
        }

        /// <summary>
        /// 逆行列を取得する。
        /// </summary>
        /// <returns></returns>
        Matrix33F GetInverted()
        {
            Matrix33F o = this;
            o.SetInverted();
            return o;
        }

        /// <summary>
        /// 回転行列を設定する。
        /// </summary>
        /// <param name="angle"></param>
        public void SetRotation(float angle)
        {
            SetIdentity();

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            Values[0, 0] = cos;
            Values[0, 1] = -sin;
            Values[1, 0] = sin;
            Values[1, 1] = cos;

        }

        /// <summary>
        /// 拡大・縮小行列を設定する。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y)
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
        public Vector2F Transform2D(Vector2F in_)
        {
            float[] values = new float[3];

            for (int i = 0; i < 2; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += 1.0f * Values[i, 2];
            }

            Vector2F o;
            o.X = values[0];
            o.Y = values[1];
            return o;
        }
        public static Matrix33F operator *(Matrix33F left, Matrix33F right)
        {
            Matrix33F result = new Matrix33F();

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
    }
}
