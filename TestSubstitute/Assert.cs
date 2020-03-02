using System;

namespace Altseed.Test
{
    public static class Assert
    {
        public static void True(bool condition)
        {
            if (!condition)
                Console.WriteLine("Not True・I");
        }

        public static void False(bool condition)
        {
            if (condition)
                Console.WriteLine("Not False・I");
        }

        public static void NotNull(object obj)
        {
            if (obj == null)
                Console.WriteLine("Null・I");
        }

        public static void AreEqual(double expected, double actual, double delta)
        {
            if (Math.Abs(expected - actual) > delta)
                Console.WriteLine("Not Equal・I");
        }

        public static void AreEqual(object expected, object actual)
        {
            if (expected != actual)
                Console.WriteLine("Not Equal・I");
        }

        public static void AreNotEqual(double expected, double actual, double delta)
        {
            if (Math.Abs(expected - actual) < delta)
                Console.WriteLine("Equal・I");
        }

        public static void AreNotEqual(object expected, object actual)
        {
            if (expected == actual)
                Console.WriteLine("Equal・I");
        }
    }
}