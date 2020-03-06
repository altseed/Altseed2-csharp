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
        private float[,] Values;

        /// <summary>
        /// 単位行列を取得する
        /// </summary>
        public static Matrix44F Identity
        {
            get
            {
                var result = new Matrix44F();
                result.SetIdentity();
                return result;
            }
        }

        /// <summary>
        /// 逆行列を取得する
        /// </summary>
        public readonly Matrix44F Inversion
        {
            get
            {
                var result = this;
                result.SetInverted();
                return result;
            }
        }

        /// <summary>
        /// 転置行列を取得する
        /// </summary>
        public readonly Matrix44F TransPosition
        {
            get
            {
                var result = new Matrix44F();
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        result[i, j] = this[j, i];
                return result;
            }
        }

        /// <summary>
        /// 指定した位置の値を取得または設定する
        /// </summary>
        /// <param name="x">取得する要素の位置</param>
        /// <param name="y">取得する要素の位置</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="x"/>または<paramref name="y"/>が0未満または4以上</exception>
        /// <returns><paramref name="x"/>と<paramref name="y"/>に対応する値</returns>
        public float this[int x, int y]
        {
            readonly get
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                return Values?[x, y] ?? 0.0f;
            }
            set
            {
                Values ??= new float[4, 4];
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                Values[x, y] = value;
            }
        }

        /// <summary>
        /// カメラ行列(右手系)を取得する
        /// </summary>
        /// <param name="eye">カメラの位置</param>
        /// <param name="at">カメラの注視点</param>
        /// <param name="up">カメラの上方向</param>
        public static Matrix44F GetLookAtRH(Vector3F eye, Vector3F at, Vector3F up)
        {
            var result = Identity;

            // F=正面、R=右方向、U=上方向
            var F = (eye - at).Normal;
            var R = Vector3F.Cross(up, F).Normal;
            var U = Vector3F.Cross(F, R).Normal;

            result[0, 0] = R.X;
            result[0, 1] = R.Y;
            result[0, 2] = R.Z;

            result[1, 0] = U.X;
            result[1, 1] = U.Y;
            result[1, 2] = U.Z;

            result[2, 0] = F.X;
            result[2, 1] = F.Y;
            result[2, 2] = F.Z;

            result[0, 3] = -Vector3F.Dot(R, eye);
            result[1, 3] = -Vector3F.Dot(U, eye);
            result[2, 3] = -Vector3F.Dot(F, eye);

            return result;
        }

        /// <summary>
        /// カメラ行列(左手系)を取得する
        /// </summary>
        /// <param name="eye">カメラの位置</param>
        /// <param name="at">カメラの注視点</param>
        /// <param name="up">カメラの上方向</param>
        public static Matrix44F GetLookAtLH(Vector3F eye, Vector3F at, Vector3F up)
        {
            var result = Identity;

            // F=正面、R=右方向、U=上方向
            var F = (at - eye).Normal;
            var R = Vector3F.Cross(up, F).Normal;
            var U = Vector3F.Cross(F, R).Normal;

            result[0, 0] = R.X;
            result[0, 1] = R.Y;
            result[0, 2] = R.Z;

            result[1, 0] = U.X;
            result[1, 1] = U.Y;
            result[1, 2] = U.Z;

            result[2, 0] = F.X;
            result[2, 1] = F.Y;
            result[2, 2] = F.Z;

            result[0, 3] = -Vector3F.Dot(R, eye);
            result[1, 3] = -Vector3F.Dot(U, eye);
            result[2, 3] = -Vector3F.Dot(F, eye);
            result[3, 3] = 0.0f;

            return result;
        }

        /// <summary>
        /// 正射影行列(左手系)を取得する
        /// </summary>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public static Matrix44F GetOrthographicLH(float width, float height, float zn, float zf)
        {
            var result = Identity;

            result[0, 0] = 2 / width;
            result[1, 1] = 2 / height;
            result[2, 2] = 1 / (zf - zn);
            result[2, 3] = zn / (zn - zf);

            return result;
        }

        /// <summary>
        /// 正射影行列(右手系)を取得する
        /// </summary>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public static Matrix44F GetOrthographicRH(float width, float height, float zn, float zf)
        {
            var result = Identity;

            result[0, 0] = 2 / width;
            result[1, 1] = 2 / height;
            result[2, 2] = 1 / (zn - zf);
            result[2, 3] = zn / (zn - zf);
            result[3, 3] = 0.0f;

            return result; ;
        }

        /// <summary>
        /// 射影行列(左手系)を取得する
        /// </summary>
        /// <param name="ovY">Y方向への視野角(度数法)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public static Matrix44F GetPerspectiveFovLH(float ovY, float aspect, float zn, float zf)
        {
            var result = Identity;

            var yScale = 1 / (float)Math.Tan(ovY / 2);
            var xScale = yScale / aspect;

            result[0, 0] = xScale;
            result[1, 1] = yScale;
            result[2, 2] = zf / (zf - zn);
            result[3, 2] = 1.0f;
            result[2, 3] = -zn * zf / (zf - zn);
            result[3, 3] = 0.0f;

            return result;
        }

        /// <summary>
        /// 射影行列(右手系)を取得する
        /// </summary>
        /// <param name="ovY">Y方向への視野角(弧度法)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public static Matrix44F GetPerspectiveFovRH(float ovY, float aspect, float zn, float zf)
        {
            var result = Identity;

            var yScale = 1 / (float)Math.Tan(ovY / 2);
            var xScale = yScale / aspect;

            result[0, 0] = xScale;
            result[1, 1] = yScale;
            result[2, 2] = zf / (zn - zf);
            result[3, 2] = -1.0f;
            result[2, 3] = zn * zf / (zn - zf);

            return result;
        }

        /// <summary>
        /// OpenGL用射影行列(右手系)を取得する
        /// </summary>
        /// <param name="ovY">Y方向への視野角(弧度法)</param>
        /// <param name="aspect">画面のアスペクト比</param>
        /// <param name="zn">最近距離</param>
        /// <param name="zf">最遠距離</param>
        public static Matrix44F GetPerspectiveFovRH_OpenGL(float ovY, float aspect, float zn, float zf)
        {
            var result = Identity;

            var yScale = 1 / (float)Math.Tan(ovY / 2);
            var xScale = yScale / aspect;
            var dz = zf - zn;

            result[0, 0] = xScale;
            result[1, 1] = yScale;
            result[2, 2] = -(zf + zn) / dz;
            result[3, 2] = -1.0f;
            result[2, 3] = -2.0f * zn * zf / dz;

            return result;
        }

        /// <summary>
        /// クオータニオンを元に回転行列(右手)を取得する
        /// </summary>
        /// <param name="quaternion">使用するクオータニオン</param>
        public static Matrix44F GetQuaternion(Vector4F quaternion)
        {
            var result = Identity;

            var xx = quaternion.X * quaternion.X;
            var yy = quaternion.Y * quaternion.Y;
            var zz = quaternion.Z * quaternion.Z;
            var xy = quaternion.X * quaternion.Y;
            var xz = quaternion.X * quaternion.Z;
            var yz = quaternion.Y * quaternion.Z;
            var wx = quaternion.W * quaternion.X;
            var wy = quaternion.W * quaternion.Y;
            var wz = quaternion.W * quaternion.Z;

            result[0, 0] = 1.0f - 2.0f * (yy + zz);
            result[0, 1] = 2.0f * (xy - wz);
            result[0, 2] = 2.0f * (xz + wy);
            result[1, 0] = 2.0f * (xy + wz);
            result[1, 1] = 1.0f - 2.0f * (xx + zz);
            result[1, 2] = 2.0f * (yz - wx);
            result[2, 0] = 2.0f * (xz - wy);
            result[2, 1] = 2.0f * (yz + wx);
            result[2, 2] = 1.0f - 2.0f * (xx + yy);

            return result;
        }

        /// <summary>
        /// 任意軸の反時計回転行列(右手)を取得する
        /// </summary>
        /// <param name="axis">軸</param>
        /// <param name="radian">回転量(弧度法)</param>
        public static Matrix44F GetRotationAxis(Vector3F axis, float radian)
        {
            var result = Identity;

            var cos = (float)Math.Cos(radian);
            var sin = (float)Math.Sin(radian);
            var cosM = 1.0f - cos;

            result[0, 0] = cosM * (axis.X * axis.X) + cos;
            result[1, 0] = cosM * (axis.X * axis.Y) + (axis.Z * sin);
            result[2, 0] = cosM * (axis.Z * axis.X) - (axis.Y * sin);

            result[0, 1] = cosM * (axis.X * axis.Y) - (axis.Z * sin);
            result[1, 1] = cosM * (axis.Y * axis.Y) + cos;
            result[2, 1] = cosM * (axis.Y * axis.Z) + (axis.X * sin);

            result[0, 2] = cosM * (axis.Z * axis.X) + (axis.Y * sin);
            result[1, 2] = cosM * (axis.Y * axis.Z) - (axis.X * sin);
            result[2, 2] = cosM * (axis.Z * axis.Z) + cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のX軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">X軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のX軸回転分を表す行列</returns>
        public static Matrix44F GetRotationX(float radian)
        {
            var sin = (float)Math.Sin(radian);
            var cos = (float)Math.Cos(radian);

            var result = Identity;
            result[1, 1] = cos;
            result[2, 1] = sin;
            result[1, 2] = -sin;
            result[2, 2] = cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のY軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">Y軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のY軸回転分を表す行列</returns>
        public static Matrix44F GetRotationY(float radian)
        {
            var sin = (float)Math.Sin(radian);
            var cos = (float)Math.Cos(radian);

            var result = Identity;
            result[0, 0] = cos;
            result[2, 0] = -sin;
            result[0, 2] = sin;
            result[2, 2] = cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のZ軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">Z軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のZ軸回転分を表す行列</returns>
        public static Matrix44F GetRotationZ(float radian)
        {
            var sin = (float)Math.Sin(radian);
            var cos = (float)Math.Cos(radian);

            var result = Identity;
            result[0, 0] = cos;
            result[0, 1] = -sin;
            result[1, 0] = sin;
            result[1, 1] = cos;

            return result;
        }

        /// <summary>
        /// 2D座標の拡大率を表す行列を取得する
        /// </summary>
        /// <param name="scale2D">設定する拡大率</param>
        /// <returns><paramref name="scale2D"/>分の拡大/縮小を表す行列</returns>
        public static Matrix44F GetScale2D(Vector2F scale2D) => GetScale3D(new Vector3F(scale2D.X, scale2D.Y, 1.0f));

        /// <summary>
        /// 3D座標の拡大率を表す行列を取得する
        /// </summary>
        /// <param name="scale3D">設定する拡大率</param>
        /// <returns><paramref name="scale3D"/>分の拡大/縮小を表す行列</returns>
        public static Matrix44F GetScale3D(Vector3F scale3D)
        {
            var result = Identity;
            result[0, 0] = scale3D.X;
            result[1, 1] = scale3D.Y;
            result[2, 2] = scale3D.Z;

            return result;
        }

        /// <summary>
        /// 2D座標の平行移動分を表す行列を取得する
        /// </summary>
        /// <param name="position2D">平行移動する座標</param>
        /// <returns><paramref name="position2D"/>分の平行移動を表す行列</returns>
        public static Matrix44F GetTranslation2D(Vector2F position2D) => GetTranslation3D(new Vector3F(position2D.X, position2D.Y, 0.0f));
        
        /// <summary>
        /// 3D座標の平行移動分を表す行列を取得する
        /// </summary>
        /// <param name="position3D">平行移動する座標</param>
        /// <returns><paramref name="position3D"/>分の平行移動を表す行列</returns>
        public static Matrix44F GetTranslation3D(Vector3F position3D)
        {
            var result = Identity;

            result[0, 3] = position3D.X;
            result[1, 3] = position3D.Y;
            result[2, 3] = position3D.Z;
            return result;
        }

        /// <summary>
        /// 単位行列に設定する
        /// </summary>
        public void SetIdentity()
        {
            Values ??= new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Values[i, j] = 0.0f;

            Values[0, 0] = 1.0f;
            Values[1, 1] = 1.0f;
            Values[2, 2] = 1.0f;
            Values[3, 3] = 1.0f;
        }

        /// <summary>
        /// 逆行列に設定する
        /// </summary>
        private void SetInverted()
        {
            Values ??= new float[4, 4];
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
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector3F Transform3D(Vector3F in_)
        {
            float[] values = new float[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += this[i, 3];
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
        public readonly Vector4F Transform4D(Vector4F in_)
        {
            float[] values = new float[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += in_.W * this[i, 3];
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
            var result = new Matrix44F();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = left[i, j] + right[i, j];
            return result;
        }

        public static Matrix44F operator -(Matrix44F matrix) => -1 * matrix;

        public static Matrix44F operator -(Matrix44F left, Matrix44F right)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = left[i, j] - right[i, j];
            return result;
        }

        public static Matrix44F operator *(Matrix44F matrix, float scalar)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = matrix[i, j] * scalar;
            return result;
        }

        public static Matrix44F operator *(float scalar, Matrix44F matrix) => matrix * scalar;

        public static Matrix44F operator /(Matrix44F matrix, float scalar)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = matrix[i, j] / scalar;
            return result;
        }

        public static Matrix44F operator *(Matrix44F left, Matrix44F right)
        {
            var o_ = new Matrix44F();
            Mul(ref o_, left, right);
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
        public static void Mul(ref Matrix44F o, in Matrix44F in1, in Matrix44F in2)
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
                        v += _in1[i, k] * _in2[k, j];
                    }
                    o[i, j] = v;
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
        public readonly override bool Equals(object obj) => obj is Matrix44F m ? Equals(m) : false;

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
            var clone = new Matrix44F() { Values = (float[,])Values.Clone() };
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();
    }
}
