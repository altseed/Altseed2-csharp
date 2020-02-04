using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Vector
    {
        public static DefaultTraceListener Listener = new DefaultTraceListener()
        {
            LogFileName = "debug.txt"
        };
        [Test, Apartment(System.Threading.ApartmentState.STA)]
        public void Base()
        {
            Serialize();
            Deserialize();
        }
        private void Serialize()
        {
            var formatter = new BinaryFormatter();
            var vectorF = new Vector2DF(0.1f, 0.1f);
            var vectorI = new Vector2DI(1, 1);
            Listener.WriteLine($"F:{vectorF}");
            Listener.WriteLine($"I:{vectorI}");
            using var fsF_c = new FileStream("Test_VectorF.dat", FileMode.Create);
            using var fsI_c = new FileStream("Test_VectorI.dat", FileMode.Create);
            formatter.Serialize(fsF_c, vectorF);
            formatter.Serialize(fsI_c, vectorI);
        }
        private void Deserialize()
        {
            var formatter = new BinaryFormatter();
            using var fsF_o = new FileStream("Test_VectorF.dat", FileMode.Open);
            using var fsI_o = new FileStream("Test_VectorI.dat", FileMode.Open);
            var vectorF = (Vector2DF)formatter.Deserialize(fsF_o);
            var vectorI = (Vector2DI)formatter.Deserialize(fsI_o);
            Listener.WriteLine($"F:{vectorF}");
            Listener.WriteLine($"I:{vectorI}");
        }
    }
}
