using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Altseed2
{
    /// <summary>
    /// <see cref="float"/>型の3x3行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Matrix33F : ICloneable, IEquatable<Matrix33F>, ISerializable
    {
        private const string S_Array = "S_Array";

        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 3 * 3)]
        private fixed float Values[9];

        /// <summary>
        /// 単位行列を取得します。
        /// </summary>
        public static Matrix33F Identity
        {
            get
            {
                var result = new Matrix33F();
                for (int i = 0; i < 9; i++) result.Values[i] = 0.0f;

                result.Values[0 * 3 + 0] = 1.0f;
                result.Values[1 * 3 + 1] = 1.0f;
                result.Values[2 * 3 + 2] = 1.0f;

                return result;
            }
        }

        /// <summary>
        /// 逆行列を取得します。
        /// </summary>
        public readonly Matrix33F Inversion
        {
            get
            {
                var result = Identity;

                var a11 = result.Values[0 * 3 + 0];
                var a12 = result.Values[0 * 3 + 1];
                var a13 = result.Values[0 * 3 + 2];
                var a21 = result.Values[1 * 3 + 0];
                var a22 = result.Values[1 * 3 + 1];
                var a23 = result.Values[1 * 3 + 2];
                var a31 = result.Values[2 * 3 + 0];
                var a32 = result.Values[2 * 3 + 1];
                var a33 = result.Values[2 * 3 + 2];

                /* 行列式の計算 */
                var b11 = +a22 * a33 - a23 * a32;
                var b12 = +a13 * a32 - a12 * a33;
                var b13 = +a12 * a23 - a13 * a22;

                var b21 = +a23 * a31 - a21 * a33;
                var b22 = +a11 * a33 - a13 * a31;
                var b23 = +a13 * a21 - a11 * a23;

                var b31 = +a21 * a32 - a22 * a31;
                var b32 = +a12 * a31 - a11 * a32;
                var b33 = +a11 * a22 - a12 * a21;

                // 行列式の逆数をかける
                var Det = a11 * a22 * a33 + a21 * a32 * a13 + a31 * a12 * a23 - a11 * a32 * a23 - a31 * a22 * a13 - a21 * a12 * a33;
                if ((-MathHelper.MatrixError <= Det) && (Det <= +MathHelper.MatrixError)) throw new InvalidOperationException("逆行列が存在しません。");

                var InvDet = 1.0f / Det;

                result.Values[0 * 3 + 0] = b11 * InvDet;
                result.Values[0 * 3 + 1] = b12 * InvDet;
                result.Values[0 * 3 + 2] = b13 * InvDet;
                result.Values[1 * 3 + 0] = b21 * InvDet;
                result.Values[1 * 3 + 1] = b22 * InvDet;
                result.Values[1 * 3 + 2] = b23 * InvDet;
                result.Values[2 * 3 + 0] = b31 * InvDet;
                result.Values[2 * 3 + 1] = b32 * InvDet;
                result.Values[2 * 3 + 2] = b33 * InvDet;

                return result;
            }
        }

        /// <summary>
        /// 転置行列を取得します。
        /// </summary>
        public readonly Matrix33F TransPosition
        {
            get
            {
                var result = new Matrix33F();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        result[i, j] = this[j, i];
                return result;
            }
        }

        private Matrix33F(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<float[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            for (int i = 0; i < 9; i++) Values[i] = array[i];
        }

        /// <summary>
        /// 指定した位置の値を取得または設定します。
        /// </summary>
        /// <param name="x">取得する要素の位置</param>
        /// <param name="y">取得する要素の位置</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="x"/>または<paramref name="y"/>が0未満または3以上</exception>
        /// <returns><paramref name="x"/>と<paramref name="y"/>に対応する値</returns>
        public float this[int x, int y]
        {
            readonly get
            {
                if (x < 0 || x > 3) throw new ArgumentOutOfRangeException(nameof(x), $"引数の値は0-2に収めてください\n実際の値：{x}");
                if (y < 0 || y > 3) throw new ArgumentOutOfRangeException(nameof(y), $"引数の値は0-2に収めてください\n実際の値：{y}");
                return Values[x * 3 + y];
            }
            set
            {
                if (x < 0 || x > 3) throw new ArgumentOutOfRangeException(nameof(x), $"引数の値は0-2に収めてください\n実際の値：{x}");
                if (y < 0 || y > 3) throw new ArgumentOutOfRangeException(nameof(y), $"引数の値は0-2に収めてください\n実際の値：{y}");
                Values[x * 3 + y] = value;
            }
        }

        /// <summary>
        /// 指定した角度分の回転を表す行列を取得します。
        /// </summary>
        /// <param name="radian">回転させる角度(弧度法)</param>
        /// <returns><paramref name="radian"/>の回転分を表す行列</returns>
        public static Matrix33F GetRotation(float radian)
        {
            var sin = MathF.Sin(radian);
            var cos = MathF.Cos(radian);

            var result = Identity;
            result[0, 0] = cos;
            result[0, 1] = -sin;
            result[1, 0] = sin;
            result[1, 1] = cos;

            return result;
        }

        /// <summary>
        /// 2D座標の拡大率を表す行列を取得します。
        /// </summary>
        /// <param name="scale">設定する拡大率</param>
        /// <returns><paramref name="scale"/>分の拡大/縮小を表す行列</returns>
        public static Matrix33F GetScale(Vector2F scale)
        {
            var result = Identity;
            result[0, 0] = scale.X;
            result[1, 1] = scale.Y;

            return result;
        }

        /// <summary>
        /// 2D座標の平行移動分を表す行列を取得します。
        /// </summary>
        /// <param name="position">平行移動する座標</param>
        /// <returns><paramref name="position"/>分の平行移動を表す行列</returns>
        public static Matrix33F GetTranslation(Vector2F position)
        {
            var result = Identity;

            result[0, 2] = position.X;
            result[1, 2] = position.Y;
            return result;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector2F Transform2D(Vector2F in_)
        {
            var values = new float[3];

            for (int i = 0; i < 2; i++)
            {
                values[i] = 0.0f;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += 1.0f * this[i, 2];
            }

            return new Vector2F(values[0], values[1]);
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector3F Transform3D(Vector3F in_)
        {
            var values = new float[3];

            for (int i = 0; i < 3; i++)
            {
                values[i] = 0.0f;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
            }

            return new Vector3F(values[0], values[1], values[2]);
        }

        /// <summary>
        /// 加算を行います。
        /// </summary>
        /// <param name="left">加算する要素</param>
        /// <param name="right">加算される要素</param>
        /// <returns>加算の結果</returns>
        public static Matrix33F operator +(Matrix33F left, Matrix33F right)
        {
            var result = new Matrix33F();
            for (int i = 0; i < 9; i++) result.Values[i] = left.Values[i] + right.Values[i];
            return result;
        }

        /// <summary>
        /// 符合を逆転します。
        /// </summary>
        /// <param name="matrix">符合を逆転する行列</param>
        /// <returns>符合が逆転された行列</returns>
        public static Matrix33F operator -(Matrix33F matrix) => -1 * matrix;

        /// <summary>
        /// 減算を行います。
        /// </summary>
        /// <param name="left">減算する要素</param>
        /// <param name="right">減算される要素</param>
        /// <returns>減算の結果</returns>
        public static Matrix33F operator -(Matrix33F left, Matrix33F right)
        {
            var result = new Matrix33F();
            for (int i = 0; i < 9; i++) result.Values[i] = left.Values[i] - right.Values[i];
            return result;
        }

        /// <summary>
        /// 行列の各値を定数倍にします。
        /// </summary>
        /// <param name="matrix">定数倍される行列</param>
        /// <param name="scalar">乗算する定数</param>
        /// <returns>各値が定数倍された行列</returns>
        public static Matrix33F operator *(Matrix33F matrix, float scalar)
        {
            var result = new Matrix33F();
            for (int i = 0; i < 9; i++) result.Values[i] = matrix.Values[i] * scalar;
            return result;
        }

        /// <summary>
        /// 行列の各値を定数倍にします。
        /// </summary>
        /// <param name="scalar">乗算する定数</param>
        /// <param name="matrix">定数倍される行列</param>
        /// <returns>各値が定数倍された行列</returns>
        public static Matrix33F operator *(float scalar, Matrix33F matrix) => matrix * scalar;

        /// <summary>
        /// 行列の各値を定数倍で除算します。
        /// </summary>
        /// <param name="matrix">除算される行列</param>
        /// <param name="scalar">除算する定数</param>
        /// <returns>各値が定数で除算された行列</returns>
        public static Matrix33F operator /(Matrix33F matrix, float scalar)
        {
            var result = new Matrix33F();
            for (int i = 0; i < 9; i++) result.Values[i] = matrix.Values[i] / scalar;
            return result;
        }

        /// <summary>
        /// 乗算を行います。
        /// </summary>
        /// <param name="left">乗算する要素</param>
        /// <param name="right">乗算される要素</param>
        /// <returns>乗算の結果</returns>
        public static Matrix33F operator *(Matrix33F left, Matrix33F right)
        {
            var result = new Matrix33F();

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    for (int k = 0; k < 3; ++k)
                        result[i, j] += left[i, k] * right[k, j];


            return result;
        }

        /// <summary>
        /// 乗算を行います。
        /// </summary>
        /// <param name="left">乗算する要素</param>
        /// <param name="right">乗算される要素</param>
        /// <returns>乗算の結果</returns>
        public static Vector3F operator *(Matrix33F left, Vector3F right) => left.Transform3D(right);

        #region IEquatable
        /// <summary>
        /// 2つの<see cref="Matrix33F"/>間の等価性を判定します。
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix33F"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix33F other)
        {
            for (int i = 0; i < 9; i++)
                if (Values[i] != other.Values[i])
                    return false;
            return true;
        }

        /// <summary>
        /// 指定したオブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間の等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Matrix33F m && Equals(m);

        /// <summary>
        /// このオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            var hash = new HashCode();
            for (int i = 0; i < 9; i++) hash.Add(Values[i]);
            return hash.ToHashCode();
        }

        /// <summary>
        /// 二つの<see cref="Matrix33F"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="m1">等価性を判定する<see cref="Matrix33F"/>のインスタンス</param>
        /// <param name="m2">等価性を判定する<see cref="Matrix33F"/>のインスタンス</param>
        /// <returns><paramref name="m1"/>と<paramref name="m2"/>の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(Matrix33F m1, Matrix33F m2) => m1.Equals(m2);
        /// <summary>
        /// 二つの<see cref="Matrix33F"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="m1">非等価性を判定する<see cref="Matrix33F"/>のインスタンス</param>
        /// <param name="m2">非等価性を判定する<see cref="Matrix33F"/>のインスタンス</param>
        /// <returns><paramref name="m1"/>と<paramref name="m2"/>の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(Matrix33F m1, Matrix33F m2) => !m1.Equals(m2);
        #endregion

        /// <summary>
        /// このインスタンスの複製を作成します。
        /// </summary>
        /// <returns>このインスタンスの複製</returns>
        public readonly Matrix33F Clone()
        {
            var clone = new Matrix33F();
            for (int i = 0; i < 9; i++) clone.Values[i] = Values[i];
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            var array = new float[9];
            for (int i = 0; i < 9; i++) array[i] = Values[i];
            info.AddValue(S_Array, array);
        }
    }
}
