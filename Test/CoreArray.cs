using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class CoreArray
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Int8()
        {
            //未実装
            throw new NotImplementedException();

            Assert.True(Engine.Initialize("Test : Int8Array", 640, 480));

            var b = new byte[] { 0, 1, 2, 3 };

            Assert.NotNull(b);

            var test = Int8Array.FromByteArray(b);

            Assert.AreEqual(b.Length, test.Count);

            var b2 = test.ToByteArray();

            Assert.True(b.SequenceEqual(b2));

            Engine.Terminate();
        }
    }
}
