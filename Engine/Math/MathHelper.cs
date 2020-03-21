using System;

namespace Altseed
{
    /// <summary>
    /// 数学の演算を補助するクラス
    /// </summary>
    public static class MathHelper
    {
        private const float PiPer180 = (float)(Math.PI / 180);

        /// <summary>
        /// 指定した値を決められた範囲に丸める
        /// </summary>
        /// <param name="v">丸める値</param>
        /// <param name="max">最大値</param>
        /// <param name="min">最小値</param>
        /// <returns><paramref name="v"/>が<paramref name="max"/>以上であったり<paramref name="min"/>未満であった場合はその値が，それ以外では<paramref name="v"/>そのまま返される</returns>
        public static int Clamp(int v, int max, int min)
        {
            if (v > max) return max;
            if (v < min) return min;
            return v;
        }

        /// <summary>
        /// 指定した値を決められた範囲に丸める
        /// </summary>
        /// <param name="v">丸める値</param>
        /// <param name="max">最大値</param>
        /// <param name="min">最小値</param>
        /// <returns><paramref name="v"/>が<paramref name="max"/>以上であったり<paramref name="min"/>未満であった場合はその値が，それ以外では<paramref name="v"/>そのまま返される</returns>
        public static float Clamp(float v, float max, float min)
        {
            if (v > max) return max;
            if (v < min) return min;
            return v;
        }

        /// <summary>
        /// 指定した値を決められた範囲に丸める
        /// </summary>
        /// <param name="v">丸める値</param>
        /// <param name="max">最大値</param>
        /// <param name="min">最小値</param>
        /// <returns><paramref name="v"/>が<paramref name="max"/>以上であったり<paramref name="min"/>未満であった場合はその値が，それ以外では<paramref name="v"/>そのまま返される</returns>
        public static T Clamp<T>(T v, T max, T min) where T : IComparable<T>
        {
            if (v.CompareTo(max) > 0) return max;
            if (v.CompareTo(min) < 0) return min;
            return v;
        }

        /// <summary>
        /// 度数法の値を弧度法の値に変換する
        /// </summary>
        /// <param name="degree">変換したい度数法の値</param>
        /// <returns>弧度法としての<paramref name="degree"/>の値</returns>
        public static float DegreeToRadian(float degree) => degree * PiPer180;

        /// <summary>
        /// 弧度法の値を度数法の値に変換する
        /// </summary>
        /// <param name="radian">変換したい弧度法の値</param>
        /// <returns>度数法としての<paramref name="radian"/>の値</returns>
        public static float RadianToDegree(float radian) => radian / PiPer180;
    }
}
