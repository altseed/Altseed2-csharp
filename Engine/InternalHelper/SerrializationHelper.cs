using System;
using System.Runtime.Serialization;

namespace Altseed
{
    internal static class SerrializationHelper
    {
        internal static T GetValue<T>(this SerializationInfo info, string name)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));
            return (T)info.GetValue(name, typeof(T));
        }
    }
}
