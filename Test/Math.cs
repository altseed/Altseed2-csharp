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
                var transform = MathHelper.CalcTransform(position, default, MathHelper.DegreeToRadian(angle), scale);
                MathHelper.CalcFromTransform2D(transform, out var p, out var s, out var a);
                Assert.True(MathF.Abs(position.X - p.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Y - p.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.X - s.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Y - s.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(angle - a) < MathHelper.MatrixError);
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
                var transformBase = Matrix44F.GetTranslation3D(position) * Matrix44F.GetScale3D(scale);

                MathHelper.CalcFromTransform3D(transformBase * Matrix44F.GetRotationX(MathHelper.DegreeToRadian(angle)), out Vector3F p, out Vector3F s, out float a, out _, out _);
                Assert.True(MathF.Abs(position.X - p.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Y - p.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Z - p.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.X - s.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Y - s.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Z - s.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(angle - a) < MathHelper.MatrixError);

                MathHelper.CalcFromTransform3D(transformBase * Matrix44F.GetRotationY(MathHelper.DegreeToRadian(angle)), out p, out s, out _, out a, out _);
                Assert.True(MathF.Abs(position.X - p.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Y - p.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Z - p.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.X - s.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Y - s.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Z - s.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(angle - a) < MathHelper.MatrixError);

                MathHelper.CalcFromTransform3D(transformBase * Matrix44F.GetRotationZ(MathHelper.DegreeToRadian(angle)), out p, out s, out _, out _, out a);
                Assert.True(MathF.Abs(position.X - p.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Y - p.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(position.Z - p.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.X - s.X) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Y - s.Y) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(scale.Z - s.Z) < MathHelper.MatrixError);
                Assert.True(MathF.Abs(angle - a) < MathHelper.MatrixError);
            }
        }
    }
}
