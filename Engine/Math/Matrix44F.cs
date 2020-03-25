using System;
using System.Runtime.InteropServices;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の4x4行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Matrix44F : ICloneable, IEquatable<Matrix44F>
    {
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 4 * 4)]
        //[FieldOffset(0)]
        private fixed float Values[16];

        /// <summary>
        /// 単位行列を取得する
        /// </summary>
        public static Matrix44F Identity
        {
            get
            {
                var result = new Matrix44F();
                for (int i = 0; i < 16; i++)
                    result.Values[i] = 0.0f;

                result.Values[0 * 4 + 0] = 1.0f;
                result.Values[1 * 4 + 1] = 1.0f;
                result.Values[2 * 4 + 2] = 1.0f;
                result.Values[3 * 4 + 3] = 1.0f;

                return result;
            }
        }

        /// <summary>
        /// 逆行列を取得する
        /// </summary>
        public readonly Matrix44F Inverse
        {
            get
            {
                var result = Identity;
                var e = 0.00001f; // TODO:他と統一

                var a11 = Values[0 * 4 + 0];
                var a12 = Values[0 * 4 + 1];
                var a13 = Values[0 * 4 + 2];
                var a14 = Values[0 * 4 + 3];
                var a21 = Values[1 * 4 + 0];
                var a22 = Values[1 * 4 + 1];
                var a23 = Values[1 * 4 + 2];
                var a24 = Values[1 * 4 + 3];
                var a31 = Values[2 * 4 + 0];
                var a32 = Values[2 * 4 + 1];
                var a33 = Values[2 * 4 + 2];
                var a34 = Values[2 * 4 + 3];
                var a41 = Values[3 * 4 + 0];
                var a42 = Values[3 * 4 + 1];
                var a43 = Values[3 * 4 + 2];
                var a44 = Values[3 * 4 + 3];

                /* 行列式の計算 */
                var b11 = +a22 * (a33 * a44 - a43 * a34) - a23 * (a32 * a44 - a42 * a34) + a24 * (a32 * a43 - a42 * a33);
                var b12 = -a12 * (a33 * a44 - a43 * a34) + a13 * (a32 * a44 - a42 * a34) - a14 * (a32 * a43 - a42 * a33);
                var b13 = +a12 * (a23 * a44 - a43 * a24) - a13 * (a22 * a44 - a42 * a24) + a14 * (a22 * a43 - a42 * a23);
                var b14 = -a12 * (a23 * a34 - a33 * a24) + a13 * (a22 * a34 - a32 * a24) - a14 * (a22 * a33 - a32 * a23);

                var b21 = -a21 * (a33 * a44 - a43 * a34) + a23 * (a31 * a44 - a41 * a34) - a24 * (a31 * a43 - a41 * a33);
                var b22 = +a11 * (a33 * a44 - a43 * a34) - a13 * (a31 * a44 - a41 * a34) + a14 * (a31 * a43 - a41 * a33);
                var b23 = -a11 * (a23 * a44 - a43 * a24) + a13 * (a21 * a44 - a41 * a24) - a14 * (a21 * a43 - a41 * a23);
                var b24 = +a11 * (a23 * a34 - a33 * a24) - a13 * (a21 * a34 - a31 * a24) + a14 * (a21 * a33 - a31 * a23);

                var b31 = +a21 * (a32 * a44 - a42 * a34) - a22 * (a31 * a44 - a41 * a34) + a24 * (a31 * a42 - a41 * a32);
                var b32 = -a11 * (a32 * a44 - a42 * a34) + a12 * (a31 * a44 - a41 * a34) - a14 * (a31 * a42 - a41 * a32);
                var b33 = +a11 * (a22 * a44 - a42 * a24) - a12 * (a21 * a44 - a41 * a24) + a14 * (a21 * a42 - a41 * a22);
                var b34 = -a11 * (a22 * a34 - a32 * a24) + a12 * (a21 * a34 - a31 * a24) - a14 * (a21 * a32 - a31 * a22);

                var b41 = -a21 * (a32 * a43 - a42 * a33) + a22 * (a31 * a43 - a41 * a33) - a23 * (a31 * a42 - a41 * a32);
                var b42 = +a11 * (a32 * a43 - a42 * a33) - a12 * (a31 * a43 - a41 * a33) + a13 * (a31 * a42 - a41 * a32);
                var b43 = -a11 * (a22 * a43 - a42 * a23) + a12 * (a21 * a43 - a41 * a23) - a13 * (a21 * a42 - a41 * a22);
                var b44 = +a11 * (a22 * a33 - a32 * a23) - a12 * (a21 * a33 - a31 * a23) + a13 * (a21 * a32 - a31 * a22);

                // 行列式の逆数をかける
                var det = (a11 * b11) + (a12 * b21) + (a13 * b31) + (a14 * b41);
                if ((-e <= det) && (det <= +e)) throw new InvalidOperationException("逆行列が存在しません。");

                float invDet = 1.0f / det;

                result.Values[0 * 4 + 0] = b11 * invDet;
                result.Values[0 * 4 + 1] = b12 * invDet;
                result.Values[0 * 4 + 2] = b13 * invDet;
                result.Values[0 * 4 + 3] = b14 * invDet;
                result.Values[1 * 4 + 0] = b21 * invDet;
                result.Values[1 * 4 + 1] = b22 * invDet;
                result.Values[1 * 4 + 2] = b23 * invDet;
                result.Values[1 * 4 + 3] = b24 * invDet;
                result.Values[2 * 4 + 0] = b31 * invDet;
                result.Values[2 * 4 + 1] = b32 * invDet;
                result.Values[2 * 4 + 2] = b33 * invDet;
                result.Values[2 * 4 + 3] = b34 * invDet;
                result.Values[3 * 4 + 0] = b41 * invDet;
                result.Values[3 * 4 + 1] = b42 * invDet;
                result.Values[3 * 4 + 2] = b43 * invDet;
                result.Values[3 * 4 + 3] = b44 * invDet;
                return result;
            }
        }

        /// <summary>
        /// 転置行列を取得する
        /// </summary>
        public readonly Matrix44F Transposed
        {
            get
            {
                var result = new Matrix44F();
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        result.Values[i * 4 + j] = Values[j * 4 + i];
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
        public float this[int x ,int y]
        {
            readonly get
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                return Values[x * 4 + y];
            }
            set
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException("引数の値は0-3に収めてください", nameof(y));
                Values[x * 4 + y] = value;
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

            result.Values[0 * 4 + 0] = R.X;
            result.Values[0 * 4 + 1] = R.Y;
            result.Values[0 * 4 + 2] = R.Z;

            result.Values[1 * 4 + 0] = U.X;
            result.Values[1 * 4 + 1] = U.Y;
            result.Values[1 * 4 + 2] = U.Z;

            result.Values[2 * 4 + 0] = F.X;
            result.Values[2 * 4 + 1] = F.Y;
            result.Values[2 * 4 + 2] = F.Z;

            result.Values[0 * 4 + 3] = -Vector3F.Dot(R, eye);
            result.Values[1 * 4 + 3] = -Vector3F.Dot(U, eye);
            result.Values[2 * 4 + 3] = -Vector3F.Dot(F, eye);

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

            result.Values[0 * 4 + 0] = R.X;
            result.Values[0 * 4 + 1] = R.Y;
            result.Values[0 * 4 + 2] = R.Z;

            result.Values[1 * 4 + 0] = U.X;
            result.Values[1 * 4 + 1] = U.Y;
            result.Values[1 * 4 + 2] = U.Z;

            result.Values[2 * 4 + 0] = F.X;
            result.Values[2 * 4 + 1] = F.Y;
            result.Values[2 * 4 + 2] = F.Z;

            result.Values[0 * 4 + 3] = -Vector3F.Dot(R, eye);
            result.Values[1 * 4 + 3] = -Vector3F.Dot(U, eye);
            result.Values[2 * 4 + 3] = -Vector3F.Dot(F, eye);
            result.Values[3 * 4 + 3] = 0.0f;

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

            result.Values[0 * 4 + 0] = 2 / width;
            result.Values[1 * 4 + 1] = 2 / height;
            result.Values[2 * 4 + 2] = 1 / (zf - zn);
            result.Values[2 * 4 + 3] = zn / (zn - zf);

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

            result.Values[0 * 4 + 0] = 2 / width;
            result.Values[1 * 4 + 1] = 2 / height;
            result.Values[2 * 4 + 2] = 1 / (zn - zf);
            result.Values[2 * 4 + 3] = zn / (zn - zf);
            result.Values[3 * 4 + 3] = 0.0f;

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

            var yScale = 1 / MathF.Tan(ovY / 2);
            var xScale = yScale / aspect;

            result.Values[0 * 4 + 0] = xScale;
            result.Values[1 * 4 + 1] = yScale;
            result.Values[2 * 4 + 2] = zf / (zf - zn);
            result.Values[3 * 4 + 2] = 1.0f;
            result.Values[2 * 4 + 3] = -zn * zf / (zf - zn);
            result.Values[3 * 4 + 3] = 0.0f;

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

            var yScale = 1 / MathF.Tan(ovY / 2);
            var xScale = yScale / aspect;

            result.Values[0 * 4 + 0] = xScale;
            result.Values[1 * 4 + 1] = yScale;
            result.Values[2 * 4 + 2] = zf / (zn - zf);
            result.Values[3 * 4 + 2] = -1.0f;
            result.Values[2 * 4 + 3] = zn * zf / (zn - zf);

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

            var yScale = 1 / MathF.Tan(ovY / 2);
            var xScale = yScale / aspect;
            var dz = zf - zn;

            result.Values[0 * 4 + 0] = xScale;
            result.Values[1 * 4 + 1] = yScale;
            result.Values[2 * 4 + 2] = -(zf + zn) / dz;
            result.Values[3 * 4 + 2] = -1.0f;
            result.Values[2 * 4 + 3] = -2.0f * zn * zf / dz;

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

            result.Values[0 * 4 + 0] = 1.0f - 2.0f * (yy + zz);
            result.Values[0 * 4 + 1] = 2.0f * (xy - wz);
            result.Values[0 * 4 + 2] = 2.0f * (xz + wy);
            result.Values[1 * 4 + 0] = 2.0f * (xy + wz);
            result.Values[1 * 4 + 1] = 1.0f - 2.0f * (xx + zz);
            result.Values[1 * 4 + 2] = 2.0f * (yz - wx);
            result.Values[2 * 4 + 0] = 2.0f * (xz - wy);
            result.Values[2 * 4 + 1] = 2.0f * (yz + wx);
            result.Values[2 * 4 + 2] = 1.0f - 2.0f * (xx + yy);

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

            var cos = MathF.Cos(radian);
            var sin = MathF.Sin(radian);
            var cosM = 1.0f - cos;

            result.Values[0 * 4 + 0] = cosM * (axis.X * axis.X) + cos;
            result.Values[1 * 4 + 0] = cosM * (axis.X * axis.Y) + (axis.Z * sin);
            result.Values[2 * 4 + 0] = cosM * (axis.Z * axis.X) - (axis.Y * sin);

            result.Values[0 * 4 + 1] = cosM * (axis.X * axis.Y) - (axis.Z * sin);
            result.Values[1 * 4 + 1] = cosM * (axis.Y * axis.Y) + cos;
            result.Values[2 * 4 + 1] = cosM * (axis.Y * axis.Z) + (axis.X * sin);

            result.Values[0 * 4 + 2] = cosM * (axis.Z * axis.X) + (axis.Y * sin);
            result.Values[1 * 4 + 2] = cosM * (axis.Y * axis.Z) - (axis.X * sin);
            result.Values[2 * 4 + 2] = cosM * (axis.Z * axis.Z) + cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のX軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">X軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のX軸回転分を表す行列</returns>
        public static Matrix44F GetRotationX(float radian)
        {
            var sin = MathF.Sin(radian);
            var cos = MathF.Cos(radian);

            var result = Identity;
            result.Values[1 * 4 + 1] = cos;
            result.Values[2 * 4 + 1] = sin;
            result.Values[1 * 4 + 2] = -sin;
            result.Values[2 * 4 + 2] = cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のY軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">Y軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のY軸回転分を表す行列</returns>
        public static Matrix44F GetRotationY(float radian)
        {
            var sin = MathF.Sin(radian);
            var cos = MathF.Cos(radian);

            var result = Identity;
            result.Values[0 * 4 + 0] = cos;
            result.Values[2 * 4 + 0] = -sin;
            result.Values[0 * 4 + 2] = sin;
            result.Values[2 * 4 + 2] = cos;

            return result;
        }

        /// <summary>
        /// 指定した角度分のZ軸回転(右手)を表す行列を取得する
        /// </summary>
        /// <param name="radian">Z軸回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>のZ軸回転分を表す行列</returns>
        public static Matrix44F GetRotationZ(float radian)
        {
            var sin = MathF.Sin(radian);
            var cos = MathF.Cos(radian);

            var result = Identity;
            result.Values[0 * 4 + 0] = cos;
            result.Values[0 * 4 + 1] = -sin;
            result.Values[1 * 4 + 0] = sin;
            result.Values[1 * 4 + 1] = cos;

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
            result.Values[0 * 4 + 0] = scale3D.X;
            result.Values[1 * 4 + 1] = scale3D.Y;
            result.Values[2 * 4 + 2] = scale3D.Z;

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

            result.Values[0 * 4 + 3] = position3D.X;
            result.Values[1 * 4 + 3] = position3D.Y;
            result.Values[2 * 4 + 3] = position3D.Z;
            return result;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="vector">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector3F Transform3D(Vector3F vector)
        {
            float[] vec = new float[4];

            for (int i = 0; i < 4; i++)
            {
                vec[i] = 0;
                vec[i] += vector.X * Values[i * 4 + 0];
                vec[i] += vector.Y * Values[i * 4 + 1];
                vec[i] += vector.Z * Values[i * 4 + 2];
                vec[i] += Values[i * 4 + 3];
            }

            Vector3F o;
            o.X = vec[0] / vec[3];
            o.Y = vec[1] / vec[3];
            o.Z = vec[2] / vec[3];
            return o;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="vector">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector4F Transform4D(Vector4F vector)
        {
            float[] vec = new float[4];

            for (int i = 0; i < 4; i++)
            {
                vec[i] = 0;
                vec[i] += vector.X * Values[i * 4 + 0];
                vec[i] += vector.Y * Values[i * 4 + 1];
                vec[i] += vector.Z * Values[i * 4 + 2];
                vec[i] += vector.W * Values[i * 4 + 3];
            }

            Vector4F o;
            o.X = vec[0];
            o.Y = vec[1];
            o.Z = vec[2];
            o.W = vec[3];

            return o;
        }

        public static Matrix44F operator +(Matrix44F left, Matrix44F right)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 16; i++)
                result.Values[i] = left.Values[i] + right.Values[i];
            return result;
        }

        public static Matrix44F operator -(Matrix44F matrix) => -1 * matrix;

        public static Matrix44F operator -(Matrix44F left, Matrix44F right)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 16; i++)
                result.Values[i] = left.Values[i] - right.Values[i];
            return result;
        }

        public static Matrix44F operator *(Matrix44F matrix, float scalar)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 16; i++)
                result.Values[i] = matrix.Values[i] * scalar;
            return result;
        }

        public static Matrix44F operator *(float scalar, Matrix44F matrix) => matrix * scalar;

        public static Matrix44F operator /(Matrix44F matrix, float scalar)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 16; i++)
                result.Values[i] = matrix.Values[i] / scalar;
            return result;
        }

        public static Matrix44F operator *(Matrix44F left, Matrix44F right)
        {
            var result = new Matrix44F();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float v = 0.0f;
                    for (int k = 0; k < 4; k++)
                    {
                        v += left.Values[i * 4 + k] * right.Values[k * 4 + j];
                    }
                    result.Values[i * 4 + j] = v;
                }
            }
            return result;
        }

        public static Vector3F operator *(Matrix44F left, Vector3F right)
        {
            return left.Transform3D(right);
        }

        #region IEquatable
        /// <summary>
        /// 2つの<see cref="Matrix44F"/>間の等価性を判定する
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix44F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix44F other)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (Values[i * 4 + j] != other.Values[i * 4 + j])
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
                    hash.Add(Values[i * 4 + j]);
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
            var clone = new Matrix44F();
            for (int i = 0; i < 16; i++) clone.Values[i] = Values[i];
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();
    }
}
