using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Altseed
{
    /// <summary>
    /// <see cref="int"/>型の4x4行列を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Matrix44I : ICloneable, IEquatable<Matrix44I>, ISerializable
    {
        private const string S_Array = "S_Array";

        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 4 * 4)]
        private fixed int Values[16];

        /// <summary>
        /// 単位行列を取得する
        /// </summary>
        public static Matrix44I Identity
        {
            get
            {
                var result = new Matrix44I();
                for (int i = 0; i < 16; i++)
                    result.Values[i] = 0;

                result.Values[0 * 4 + 0] = 1;
                result.Values[1 * 4 + 1] = 1;
                result.Values[2 * 4 + 2] = 1;
                result.Values[3 * 4 + 3] = 1;

                return result;
            }
        }

        /// <summary>
        /// 転置行列を取得する
        /// </summary>
        public readonly Matrix44I TransPosition
        {
            get
            {
                var result = new Matrix44I();
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        result[i, j] = this[j, i];
                return result;
            }
        }

        private Matrix44I(SerializationInfo info, StreamingContext context)
        {
            var array = info.GetValue<int[]>(S_Array) ?? throw new SerializationException("デシリアライズに失敗しました");
            for (int i = 0; i < 16; i++) Values[i] = array[i];
        }

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
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException(nameof(x), $"引数の値は0-3に収めてください\n実際の値：{x}");
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException(nameof(y), $"引数の値は0-3に収めてください\n実際の値：{y}");
                return Values[x * 4 + y];
            }
            set
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException(nameof(x), $"引数の値は0-3に収めてください\n実際の値：{x}");
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException(nameof(y), $"引数の値は0-3に収めてください\n実際の値：{y}");
                Values[x * 4 + y] = value;
            }
        }

        /// <summary>
        /// クオータニオンを元に回転行列(右手)を取得する
        /// </summary>
        /// <param name="quaternion">使用するクオータニオン</param>
        public static Matrix44I GetQuaternion(Vector4I quaternion)
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

            result[0, 0] = 1 - 2 * (yy + zz);
            result[0, 1] = 2 * (xy - wz);
            result[0, 2] = 2 * (xz + wy);
            result[1, 0] = 2 * (xy + wz);
            result[1, 1] = 1 - 2 * (xx + zz);
            result[1, 2] = 2 * (yz - wx);
            result[2, 0] = 2 * (xz - wy);
            result[2, 1] = 2 * (yz + wx);
            result[2, 2] = 1 - 2 * (xx + yy);

            return result;
        }

        /// <summary>
        /// 2D座標の拡大率を表す行列を取得する
        /// </summary>
        /// <param name="scale2D">設定する拡大率</param>
        /// <returns><paramref name="scale2D"/>分の拡大/縮小を表す行列</returns>
        public static Matrix44I GetScale2D(Vector2I scale2D) => GetScale3D(new Vector3I(scale2D.X, scale2D.Y, 1));

        /// <summary>
        /// 3D座標の拡大率を表す行列を取得する
        /// </summary>
        /// <param name="scale3D">設定する拡大率</param>
        /// <returns><paramref name="scale3D"/>分の拡大/縮小を表す行列</returns>
        public static Matrix44I GetScale3D(Vector3I scale3D)
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
        public static Matrix44I GetTranslation2D(Vector2I position2D) => GetTranslation3D(new Vector3I(position2D.X, position2D.Y, 0));

        /// <summary>
        /// 3D座標の平行移動分を表す行列を取得する
        /// </summary>
        /// <param name="position3D">平行移動する座標</param>
        /// <returns><paramref name="position3D"/>分の平行移動を表す行列</returns>
        public static Matrix44I GetTranslation3D(Vector3I position3D)
        {
            var result = Identity;

            result[0, 3] = position3D.X;
            result[1, 3] = position3D.Y;
            result[2, 3] = position3D.Z;
            return result;
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector3I Transform3D(Vector3I in_)
        {
            var values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += this[i, 3];
            }

            return new Vector3I(values[0] / values[3], values[1] / values[3], values[2] / values[3]);
        }

        /// <summary>
        /// 行列でベクトルを変形させる。
        /// </summary>
        /// <param name="in_">変形前ベクトル</param>
        /// <returns>変形後ベクトル</returns>
        public readonly Vector4I Transform4D(Vector4I in_)
        {
            var values = new int[4];

            for (int i = 0; i < 4; i++)
            {
                values[i] = 0;
                values[i] += in_.X * this[i, 0];
                values[i] += in_.Y * this[i, 1];
                values[i] += in_.Z * this[i, 2];
                values[i] += in_.W * this[i, 3];
            }

            return new Vector4I(values[0], values[1], values[2], values[3]);
        }

        public static Matrix44I operator +(Matrix44I left, Matrix44I right)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 16; i++) result.Values[i] = left.Values[i] + right.Values[i]; 
            return result;
        }

        public static Matrix44I operator -(Matrix44I matrix) => -1 * matrix;

        public static Matrix44I operator -(Matrix44I left, Matrix44I right)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 16; i++) result.Values[i] = left.Values[i] - right.Values[i];
            return result;
        }

        public static Matrix44I operator *(Matrix44I matrix, int scalar)
        {
            var result = new Matrix44I();
            for (int i = 0; i < 4; i++) result.Values[i] = matrix.Values[i] * scalar;
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

        public static Matrix44I operator *(Matrix44I left, Matrix44I right)
        {
            var result = new Matrix44I();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        result[i, j] += left[i, k] * right[k, j];
            return result;
        }

        public static Vector3I operator *(Matrix44I left, Vector3I right) => left.Transform3D(right);

        #region IEquatable
        /// <summary>
        /// 2つの<see cref="Matrix44I"/>間の等価性を判定する
        /// </summary>
        /// <param name="other">等価性を判定する<see cref="Matrix44I"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Matrix44I other)
        {
            for (int i = 0; i < 16; i++)
                if (Values[i] != other.Values[i])
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
            for (int i = 0; i < 16; i++) hash.Add(Values[i]);
            return hash.ToHashCode();
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
            var clone = new Matrix44I();
            for (int i = 0; i < 16; i++) clone.Values[i] = Values[i];
            return clone;
        }
        readonly object ICloneable.Clone() => Clone();

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            var array = new int[16];
            for (int i = 0; i < 16; i++) array[i] = Values[i];
            info.AddValue(S_Array, array);
        }
    }
}
