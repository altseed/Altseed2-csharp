using NUnit.Framework;

using System;
using System.Threading;

namespace Altseed2.Test
{
    [TestFixture]
    class Math
    {
        [Test, Apartment(ApartmentState.STA)]
        public void CalcFromTransform2D()
        {
            Calc(new Vector2F(30, 30), 0, new Vector2F(1f, 1f));
            Calc(new Vector2F(30, 30), 30, new Vector2F(1f, 1f));
            Calc(new Vector2F(30, 30), 0, new Vector2F(2f, 2f));
            Calc(new Vector2F(30, 30), 30, new Vector2F(2f, 2f));
            Calc(new Vector2F(30, 30), 0, new Vector2F(3f, 2f));
            Calc(new Vector2F(30, 30), 30, new Vector2F(3f, 2f));

            static void Calc(Vector2F position, float angle, Vector2F scale)
            {
                var transform = MathHelper.CalcTransform(position, MathHelper.DegreeToRadian(angle), scale);
                MathHelper.CalcFromTransform2D(transform, out var p, out var s, out var a);
                TestValue(position, p);
                TestValue(scale, s);
                TestValue(angle, a);
            }
        }

        [Test, Apartment(ApartmentState.STA)]
        public void CalcFromTransform3D()
        {
            Calc(new Vector3F(30, 30, 30), 0, new Vector3F(1f, 1f, 1f));
            Calc(new Vector3F(30, 30, 30), 30, new Vector3F(1f, 1f, 1f));
            Calc(new Vector3F(30, 30, 30), 0, new Vector3F(2f, 2f, 2f));
            Calc(new Vector3F(30, 30, 30), 30, new Vector3F(2f, 2f, 2f));
            Calc(new Vector3F(30, 30, 30), 0, new Vector3F(3f, 2f, 5f));
            Calc(new Vector3F(30, 30, 30), 30, new Vector3F(3f, 2f, 5f));

            static void Calc(Vector3F position, float angle, Vector3F scale)
            {
                var radian = MathHelper.DegreeToRadian(angle);
                var rotation = Matrix44F.GetRotationX(radian) * Matrix44F.GetRotationY(radian) * Matrix44F.GetRotationZ(radian);
                var transform = Matrix44F.GetTranslation3D(position) * rotation * Matrix44F.GetScale3D(scale);

                MathHelper.CalcFromTransform3D(transform, out var p, out var s, out var r);
                TestValue(position, p);
                TestValue(scale, s);
                TestValue(rotation, r);
            }
        }

        public static void TestValue(float left, float right)
        {
            if (MathF.Abs(left - right) >= MathHelper.MatrixError) throw new AssertionException($"left: {left}\nright: {right}");
        }
        public static void TestValue(Vector2F left, Vector2F right)
        {
            if (MathF.Abs(left.X - right.X) >= MathHelper.MatrixError) throw new AssertionException($"At X:\nleft: {left.X}\nright: {right.X}");
            if (MathF.Abs(left.Y - right.Y) >= MathHelper.MatrixError) throw new AssertionException($"At Y:\nleft: {left.Y}\nright: {right.Y}");
        }
        public static void TestValue(Vector3F left, Vector3F right)
        {
            if (MathF.Abs(left.X - right.X) >= MathHelper.MatrixError) throw new AssertionException($"At X:\nleft: {left.X}\nright: {right.X}");
            if (MathF.Abs(left.Y - right.Y) >= MathHelper.MatrixError) throw new AssertionException($"At Y:\nleft: {left.Y}\nright: {right.Y}");
            if (MathF.Abs(left.Z - right.Z) >= MathHelper.MatrixError) throw new AssertionException($"At Y:\nleft: {left.Z}\nright: {right.Z}");
        }
        public static void TestValue(Matrix33F left, Matrix33F right)
        {
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (MathF.Abs(left[x, y] - right[x, y]) >= MathHelper.MatrixError)
                        throw new AssertionException($"At {x}, {y}:\nleft: {left[x, y]}\nright: {right[x, y]}");
        }
        public static void TestValue(Matrix44F left, Matrix44F right)
        {
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    if (MathF.Abs(left[x, y] - right[x, y]) >= MathHelper.MatrixError)
                        throw new AssertionException($"At {x}, {y}:\nleft: {left[x, y]}\nright: {right[x, y]}");
        }
    }
}
