using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の4x4行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix44F : ICloneable, IEquatable<Matrix44F>
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 4 * 4)]
        public float[,] Values;

        internal static Matrix44F GetIdentity()
        {
            var result = new Matrix44F();
            result.SetIdentity();
            return result;
        }

        public void SetIdentity()
        {
            if (Values == null)
                Values = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Values[i, j] = 0.0f;

            Values[0, 0] = 1.0f;
            Values[1, 1] = 1.0f;
            Values[2, 2] = 1.0f;
            Values[3, 3] = 1.0f;
        }

        public void SetTranslation(float x, float y, float z)
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
                    float v = Values[r, c];
                    Values[r, c] = Values[c, r];
                    Values[c, r] = v;
                }
            }
        }

        public void SetInverted()
        {
            float e = 0.00001f;

            float a11 = Values[0, 0];
            float a12 = Values[0, 1];
            float a13 = Values[0, 2];
            float a14 = Values[0, 3];
            float a21 = Values[1, 0];
            float a22 = Values[1, 1];
            float a23 = Values[1, 2];
            float a24 = Values[1, 3];
            float a31 = Values[2, 0];
            float a32 = Values[2, 1];
            float a33 = Values[2, 2];
            float a34 = Values[2, 3];
            float a41 = Values[3, 0];
            float a42 = Values[3, 1];
            float a43 = Values[3, 2];
            float a44 = Values[3, 3];

            /* 行列式の計算 */
            float b11 = +a22 * (a33 * a44 - a43 * a34) - a23 * (a32 * a44 - a42 * a34) + a24 * (a32 * a43 - a42 * a33);
            float b12 = -a12 * (a33 * a44 - a43 * a34) + a13 * (a32 * a44 - a42 * a34) - a14 * (a32 * a43 - a42 * a33);
            float b13 = +a12 * (a23 * a44 - a43 * a24) - a13 * (a22 * a44 - a42 * a24) + a14 * (a22 * a43 - a42 * a23);
            float b14 = -a12 * (a23 * a34 - a33 * a24) + a13 * (a22 * a34 - a32 * a24) - a14 * (a22 * a33 - a32 * a23);

            float b21 = -a21 * (a33 * a44 - a43 * a34) + a23 * (a31 * a44 - a41 * a34) - a24 * (a31 * a43 - a41 * a33);
            float b22 = +a11 * (a33 * a44 - a43 * a34) - a13 * (a31 * a44 - a41 * a34) + a14 * (a31 * a43 - a41 * a33);
            float b23 = -a11 * (a23 * a44 - a43 * a24) + a13 * (a21 * a44 - a41 * a24) - a14 * (a21 * a43 - a41 * a23);
            float b24 = +a11 * (a23 * a34 - a33 * a24) - a13 * (a21 * a34 - a31 * a24) + a14 * (a21 * a33 - a31 * a23);

            float b31 = +a21 * (a32 * a44 - a42 * a34) - a22 * (a31 * a44 - a41 * a34) + a24 * (a31 * a42 - a41 * a32);
            float b32 = -a11 * (a32 * a44 - a42 * a34) + a12 * (a31 * a44 - a41 * a34) - a14 * (a31 * a42 - a41 * a32);
            float b33 = +a11 * (a22 * a44 - a42 * a24) - a12 * (a21 * a44 - a41 * a24) + a14 * (a21 * a42 - a41 * a22);
            float b34 = -a11 * (a22 * a34 - a32 * a24) + a12 * (a21 * a34 - a31 * a24) - a14 * (a21 * a32 - a31 * a22);

            float b41 = -a21 * (a32 * a43 - a42 * a33) + a22 * (a31 * a43 - a41 * a33) - a23 * (a31 * a42 - a41 * a32);
            float b42 = +a11 * (a32 * a43 - a42 * a33) - a12 * (a31 * a43 - a41 * a33) + a13 * (a31 * a42 - a41 * a32);
            float b43 = -a11 * (a22 * a43 - a42 * a23) + a12 * (a21 * a43 - a41 * a23) - a13 * (a21 * a42 - a41 * a22);
            float b44 = +a11 * (a22 * a33 - a32 * a23) - a12 * (a21 * a33 - a31 * a23) + a13 * (a21 * a32 - a31 * a22);

            // 行列式の逆数をかける
            float Det = (a11 * b11) + (a12 * b21) + (a13 * b31) + (a14 * b41);
            if ((-e <= Det) && (Det <= +e))
            {
                return;
            }

            float InvDet = 1.0f / Det;

            Values[0, 0] = b11 * InvDet;
            Values[0, 1] = b12 * InvDet;
            Values[0, 2] = b13 * InvDet;
            Values[0, 3] = b14 * InvDet;
            Values[1, 0] = b21 * InvDet;
            Values[1, 1] = b22 * InvDet;
            Values[1, 2] = b23 * InvDet;
            Values[1, 3] = b24 * InvDet;
            Values[2, 0] = b31 * InvDet;
            Values[2, 1] = b32 * InvDet;
            Values[2, 2] = b33 * InvDet;
            Values[2, 3] = b34 * InvDet;
            Values[3, 0] = b41 * InvDet;
            Values[3, 1] = b42 * InvDet;
            Values[3, 2] = b43 * InvDet;
            Values[3, 3] = b44 * InvDet;
        }

        /// <summary>
		/// 逆行列取得します。
		/// </summary>
		/// <returns></returns>
		public Matrix44F GetInverted()
        {
            Matrix44F o = this;
            o.SetInverted();
            return o;
        }

        /// <summary>
        /// カメラ行列(右手系)を設定します。
        /// </summary>
        /// <param name="eye">カメラの位置</param>
        /// <param name="at">カメラの注視点</param>
        /// <param name="up">カメラの上方向</param>
        public void SetLookAtRH(Vector3F eye, Vector3F at, Vector3F up)
        {
            // F=正面、R=右方向、U=上方向
            Vector3F F = Vector3F.Subtract(eye, at).Normal;
            Vector3F R = Vector3F.Cross(up, F).Normal;
            Vector3F U = Vector3F.Cross(F, R).Normal;

            Values[0, 0] = R.X;
            Values[0, 1] = R.Y;
            Values[0, 2] = R.Z;
            Values[0, 3] = 0.0f;

            Values[1, 0] = U.X;
            Values[1, 1] = U.Y;
            Values[1, 2] = U.Z;
            Values[1, 3] = 0.0f;

            Values[2, 0] = F.X;
            Values[2, 1] = F.Y;
            Values[2, 2] = F.Z;
            Values[2, 3] = 0.0f;

            Values[0, 3] = -Vector3F.Dot(R, eye);
            Values[1, 3] = -Vector3F.Dot(U, eye);
            Values[2, 3] = -Vector3F.Dot(F, eye);
            Values[3, 3] = 1.0f;
        }

        /// <summary>
        /// カメラ行列(左手系)を設定します。
        /// </summary>
        /// <param name="eye">カメラの位置</param>
        /// <param name="at">カメラの注視点</param>
        /// <param name="up">カメラの上方向</param>
        public void SetLookAtLH(Vector3F eye, Vector3F at, Vector3F up)
        {
            // F=正面、R=右方向、U=上方向
            Vector3F F = Vector3F.Subtract(at, eye).Normal;
            Vector3F R = Vector3F.Cross(up, F).Normal;
            Vector3F U = Vector3F.Cross(F, R).Normal;

            Values[0, 0] = R.X;
            Values[0, 1] = R.Y;
            Values[0, 2] = R.Z;
            Values[0, 3] = 0.0f;

            Values[1, 0] = U.X;
            Values[1, 1] = U.Y;
            Values[1, 2] = U.Z;
            Values[1, 3] = 0.0f;

            Values[2, 0] = F.X;
            Values[2, 1] = F.Y;
            Values[2, 2] = F.Z;
            Values[2, 3] = 0.0f;

            Values[0, 3] = -Vector3F.Dot(R, eye);
            Values[1, 3] = -Vector3F.Dot(U, eye);
            Values[2, 3] = -Vector3F.Dot(F, eye);
            Values[3, 3] = 1.0f;
        }

        /// <summary>
        /// 射影行列(右手系)を設定します。
        /// </summary>
        /// <param name="ovY">Y方向への視野角(ラジアン)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public void SetPerspectiveFovRH(float ovY, float aspect, float zn, float zf)
        {
            float yScale = 1 / (float)Math.Tan(ovY / 2);
            float xScale = yScale / aspect;

            Values[0, 0] = xScale;
            Values[1, 0] = 0;
            Values[2, 0] = 0;
            Values[3, 0] = 0;

            Values[0, 1] = 0;
            Values[1, 1] = yScale;
            Values[2, 1] = 0;
            Values[3, 1] = 0;

            Values[0, 2] = 0;
            Values[1, 2] = 0;
            Values[2, 2] = zf / (zn - zf);
            Values[3, 2] = -1;

            Values[0, 3] = 0;
            Values[1, 3] = 0;
            Values[2, 3] = zn * zf / (zn - zf);
            Values[3, 3] = 0;

            return;
        }

        /// <summary>
        /// OpenGL用射影行列(右手系)を設定します。
        /// </summary>
        /// <param name="ovY">Y方向への視野角(ラジアン)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public void SetPerspectiveFovRH_OpenGL(float ovY, float aspect, float zn, float zf)
        {
            float yScale = 1 / (float)Math.Tan(ovY / 2);
            float xScale = yScale / aspect;
            float dz = zf - zn;

            Values[0, 0] = xScale;
            Values[1, 0] = 0;
            Values[2, 0] = 0;
            Values[3, 0] = 0;

            Values[0, 1] = 0;
            Values[1, 1] = yScale;
            Values[2, 1] = 0;
            Values[3, 1] = 0;

            Values[0, 2] = 0;
            Values[1, 2] = 0;
            Values[2, 2] = -(zf + zn) / dz;
            Values[3, 2] = -1.0f;

            Values[0, 3] = 0;
            Values[1, 3] = 0;
            Values[2, 3] = -2.0f * zn * zf / dz;
            Values[3, 3] = 0.0f;
            return;
        }

        /// <summary>
        /// 射影行列(左手系)を設定します。
        /// </summary>
        /// <param name="ovY">Y方向への視野角(ラジアン)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public void SetPerspectiveFovLH(float ovY, float aspect, float zn, float zf)
        {
            float yScale = 1 / (float)Math.Tan(ovY / 2);
            float xScale = yScale / aspect;

            Values[0, 0] = xScale;
            Values[1, 0] = 0;
            Values[2, 0] = 0;
            Values[3, 0] = 0;

            Values[0, 1] = 0;
            Values[1, 1] = yScale;
            Values[2, 1] = 0;
            Values[3, 1] = 0;

            Values[0, 2] = 0;
            Values[1, 2] = 0;
            Values[2, 2] = zf / (zf - zn);
            Values[3, 2] = 1;

            Values[0, 3] = 0;
            Values[1, 3] = 0;
            Values[2, 3] = -zn * zf / (zf - zn);
            Values[3, 3] = 0;
            return;
        }

        /// <summary>
        /// 正射影行列(右手系)を設定します。
        /// </summary>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public void SetOrthographicRH(float width, float height, float zn, float zf)
        {
            Values[0, 0] = 2 / width;
            Values[1, 0] = 0;
            Values[2, 0] = 0;
            Values[3, 0] = 0;

            Values[0, 1] = 0;
            Values[1, 1] = 2 / height;
            Values[2, 1] = 0;
            Values[3, 1] = 0;

            Values[0, 2] = 0;
            Values[1, 2] = 0;
            Values[2, 2] = 1 / (zn - zf);
            Values[3, 2] = 0;

            Values[0, 3] = 0;
            Values[1, 3] = 0;
            Values[2, 3] = zn / (zn - zf);
            Values[3, 3] = 1;
            return;
        }

        /// <summary>
        /// 正射影行列(左手系)を設定します。
        /// </summary>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public void SetOrthographicLH(float width, float height, float zn, float zf)
        {
            Values[0, 0] = 2 / width;
            Values[1, 0] = 0;
            Values[2, 0] = 0;
            Values[3, 0] = 0;

            Values[0, 1] = 0;
            Values[1, 1] = 2 / height;
            Values[2, 1] = 0;
            Values[3, 1] = 0;

            Values[0, 2] = 0;
            Values[1, 2] = 0;
            Values[2, 2] = 1 / (zf - zn);
            Values[3, 2] = 0;

            Values[0, 3] = 0;
            Values[1, 3] = 0;
            Values[2, 3] = zn / (zn - zf);
            Values[3, 3] = 1;
            return;
        }

        /// <summary>
        /// X軸回転行列(右手)を設定します。
        /// </summary>
        /// <param name="angle">X軸回転量(ラジアン)</param>
        public void SetRotationX(float angle)
        {
            float s = (float)Math.Sin(angle);
            float c = (float)Math.Cos(angle);

            Values[0, 0] = 1.0f;
            Values[1, 0] = 0.0f;
            Values[2, 0] = 0.0f;
            Values[3, 0] = 0.0f;

            Values[0, 1] = 0.0f;
            Values[1, 1] = c;
            Values[2, 1] = s;
            Values[3, 1] = 0.0f;

            Values[0, 2] = 0.0f;
            Values[1, 2] = -s;
            Values[2, 2] = c;
            Values[3, 2] = 0.0f;

            Values[0, 3] = 0.0f;
            Values[1, 3] = 0.0f;
            Values[2, 3] = 0.0f;
            Values[3, 3] = 1.0f;
            return;
        }

        /// <summary>
        /// Y軸回転行列(右手)を設定します。
        /// </summary>
        /// <param name="angle">Y軸回転量(ラジアン)</param>
        public void SetRotationY(float angle)
        {
            float s = (float)Math.Sin(angle);
            float c = (float)Math.Cos(angle);

            Values[0, 0] = c;
            Values[1, 0] = 0.0f;
            Values[2, 0] = -s;
            Values[3, 0] = 0.0f;

            Values[0, 1] = 0.0f;
            Values[1, 1] = 1.0f;
            Values[2, 1] = 0.0f;
            Values[3, 1] = 0.0f;

            Values[0, 2] = s;
            Values[1, 2] = 0.0f;
            Values[2, 2] = c;
            Values[3, 2] = 0.0f;

            Values[0, 3] = 0.0f;
            Values[1, 3] = 0.0f;
            Values[2, 3] = 0.0f;
            Values[3, 3] = 1.0f;
            return;
        }

        /// <summary>
        /// Z軸回転行列(右手)を設定します。
        /// </summary>
        /// <param name="angle">Z軸回転量(ラジアン)</param>
        public void SetRotationZ(float angle)
        {
            float s = (float)Math.Sin(angle);
            float c = (float)Math.Cos(angle);

            Values[0, 0] = c;
            Values[1, 0] = s;
            Values[2, 0] = 0.0f;
            Values[3, 0] = 0.0f;

            Values[0, 1] = -s;
            Values[1, 1] = c;
            Values[2, 1] = 0.0f;
            Values[3, 1] = 0.0f;

            Values[0, 2] = 0.0f;
            Values[1, 2] = 0.0f;
            Values[2, 2] = 1.0f;
            Values[3, 2] = 0.0f;

            Values[0, 3] = 0.0f;
            Values[1, 3] = 0.0f;
            Values[2, 3] = 0.0f;
            Values[3, 3] = 1.0f;
            return;
        }

        /// <summary>
        /// 任意軸の反時計回転行列(右手)を設定します。
        /// </summary>
        /// <param name="axis">軸</param>
        /// <param name="angle">回転量(ラジアン)</param>
        public void SetRotationAxis(ref Vector3F axis, float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);
            float cc = 1.0f - c;

            Values[0, 0] = cc * (axis.X * axis.X) + c;
            Values[1, 0] = cc * (axis.X * axis.Y) + (axis.Z * s);
            Values[2, 0] = cc * (axis.Z * axis.X) - (axis.Y * s);

            Values[0, 1] = cc * (axis.X * axis.Y) - (axis.Z * s);
            Values[1, 1] = cc * (axis.Y * axis.Y) + c;
            Values[2, 1] = cc * (axis.Y * axis.Z) + (axis.X * s);

            Values[0, 2] = cc * (axis.Z * axis.X) + (axis.Y * s);
            Values[1, 2] = cc * (axis.Y * axis.Z) - (axis.X * s);
            Values[2, 2] = cc * (axis.Z * axis.Z) + c;

            Values[0, 3] = 0.0f;
            Values[1, 3] = 0.0f;
            Values[2, 3] = 0.0f;
            return;
        }

        /// <summary>
        /// クオータニオンを元に回転行列(右手)を設定します。
        /// </summary>
        /// <param name="x">クオータニオン</param>
        /// <param name="y">クオータニオン</param>
        /// <param name="z">クオータニオン</param>
        /// <param name="w">クオータニオン</param>
        public void SetQuaternion(float x, float y, float z, float w)
        {
            float xx = x * x;
            float yy = y * y;
            float zz = z * z;
            float xy = x * y;
            float xz = x * z;
            float yz = y * z;
            float wx = w * x;
            float wy = w * y;
            float wz = w * z;

            Values[0, 0] = 1.0f - 2.0f * (yy + zz);
            Values[0, 1] = 2.0f * (xy - wz);
            Values[0, 2] = 2.0f * (xz + wy);
            Values[0, 3] = 0.0f;

            Values[1, 0] = 2.0f * (xy + wz);
            Values[1, 1] = 1.0f - 2.0f * (xx + zz);
            Values[1, 2] = 2.0f * (yz - wx);
            Values[1, 3] = 0.0f;

            Values[2, 0] = 2.0f * (xz - wy);
            Values[2, 1] = 2.0f * (yz + wx);
            Values[2, 2] = 1.0f - 2.0f * (xx + yy);
            Values[2, 3] = 0.0f;

            Values[3, 0] = 0.0f;
            Values[3, 1] = 0.0f;
            Values[3, 2] = 0.0f;
            Values[3, 3] = 1.0f;
            return;
        }

        /// <summary>
        /// 拡大行列を設定します。
        /// </summary>
        /// <param name="x">X方向拡大率</param>
        /// <param name="y">Y方向拡大率</param>
        /// <param name="z">Z方向拡大率</param>
        public void SetScale(float x, float y, float z)
        {
            SetIdentity();
            Values[0, 0] = x;
            Values[1, 1] = y;
            Values[2, 2] = z;
            Values[3, 3] = 1.0f;
            return;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public Vector3F Transform3D(Vector3F in_)
        {
            float[] values = new float[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += in_.Z * Values[i, 2];
                values[i] += Values[i, 3];
            }

            Vector3F o;
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
        public Vector4F Transform4D(Vector4F in_)
        {
            float[] values = new float[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * Values[i, 0];
                values[i] += in_.Y * Values[i, 1];
                values[i] += in_.Z * Values[i, 2];
                values[i] += in_.W * Values[i, 3];
            }

            Vector4F o;
            o.X = values[0];
            o.Y = values[1];
            o.Z = values[2];
            o.W = values[3];

            return o;
        }

        public static Matrix44F operator +(Matrix44F left, Matrix44F right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix44F() { Values = new float[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] + right.Values[i, j];
            return result;
        }

        public static Matrix44F operator -(Matrix44F matrix) => -1 * matrix;

        public static Matrix44F operator -(Matrix44F left, Matrix44F right)
        {
            if (left.Values == null || right.Values == null) throw new ArgumentException("引数の状態が不正です");
            var result = new Matrix44F() { Values = new float[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = left.Values[i, j] - right.Values[i, j];
            return result;
        }

        public static Matrix44F operator *(Matrix44F matrix, float scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix44F() { Values = new float[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] * scalar;
            return result;
        }

        public static Matrix44F operator *(float scalar, Matrix44F matrix) => matrix * scalar;

        public static Matrix44F operator /(Matrix44F matrix, float scalar)
        {
            if (matrix.Values == null) throw new ArgumentException("引数の状態が不正です", nameof(matrix));
            var result = new Matrix44F() { Values = new float[4, 4] };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.Values[i, j] = matrix.Values[i, j] / scalar;
            return result;
        }

        public static Matrix44F operator *(Matrix44F left, Matrix44F right)
        {
            Matrix44F o_ = new Matrix44F() { Values = new float[4, 4] };
            Mul(ref o_, ref left, ref right);
            return o_;
        }

        public static Vector3F operator *(Matrix44F left, Vector3F right)
        {
            return left.Transform3D(right);
        }

        /// <summary>
        /// 乗算を行う。
        /// </summary>
        /// <param name="o">出力先</param>
        /// <param name="in1">行列1</param>
        /// <param name="in2">行列2</param>
        public static void Mul(ref Matrix44F o, ref Matrix44F in1, ref Matrix44F in2)
        {
            Matrix44F _in1 = in1;
            Matrix44F _in2 = in2;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float v = 0.0f;
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
        /// 2つの<see cref="Matrix44F"/>間の等価性を判定する
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix44F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix44F other)
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
        public readonly override bool Equals(object obj) => obj is Matrix44F m ? Equals(m) : false;

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

        public static bool operator ==(Matrix44F m1, Matrix44F m2) => m1.Equals(m2);
        public static bool operator !=(Matrix44F m1, Matrix44F m2) => !m1.Equals(m2);
        #endregion

        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <returns>このインスタンスの複製</returns>
        public readonly Matrix44F Clone()
        {
            if (Values == null) return default;
            var clone = new Matrix44F
            {
                Values = new float[4, 4]
            };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    clone.Values[i, j] = Values[i, j];
            return clone;
        }
        object ICloneable.Clone() => Clone();
    }
}
