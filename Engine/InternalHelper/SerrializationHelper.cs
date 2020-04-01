using System;
using System.Runtime.Serialization;

namespace Altseed
{
    internal static class SerrializationHelper
    {
        internal static T GetValue<T>(this SerializationInfo info, string name)
        {
            if (info == null) throw new ArgumentNullException(nameof(info), "引数がnullです");
            return (T)info.GetValue(name, typeof(T));
        }
    }
}
