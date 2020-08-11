using System;
using System.Collections.Generic;

namespace Altseed2
{
    public class RenderTextureCache
    {
        private readonly struct CacheKey : IEquatable<CacheKey>
        {
            public readonly Vector2I Size;
            public readonly TextureFormat Format;

            public CacheKey(Vector2I size, TextureFormat format)
            {
                Size = size;
                Format = format;
            }

            public readonly override int GetHashCode()
            {
                return HashCode.Combine(Size, Format);
            }

            public readonly override bool Equals(object obj)
            {
                return obj is CacheKey other && Equals(other);
            }

            public readonly bool Equals(CacheKey other)
            {
                return Size == other.Size && Format == other.Format;
            }

            public static bool operator ==(CacheKey a, CacheKey b)
            {
                return a.Equals(b);
            }

            public static bool operator !=(CacheKey a, CacheKey b)
            {
                return !(a == b);
            }
        }

        private sealed class CacheValue
        {
            public int Life;
            public RenderTexture Stored;
        }

        private readonly Dictionary<CacheKey, CacheValue> cache;
        private readonly List<CacheKey> removeKeys;

        public RenderTextureCache()
        {
            cache = new Dictionary<CacheKey, CacheValue>();
            removeKeys = new List<CacheKey>();
        }

        public RenderTexture GetRenderTexture(Vector2I size, TextureFormat format)
        {
            var key = new CacheKey(size, format);

            if (cache.TryGetValue(key, out var result))
            {
                result.Life = 5;
                return result.Stored;
            }
            else
            {
                var res = RenderTexture.Create(size, format);
                cache.Add(key, new CacheValue { Life = 5, Stored = res });
                return res;
            }
        }

        public void Update()
        {
            foreach (var x in cache)
            {
                x.Value.Life--;
                if (x.Value.Life == 0)
                {
                    removeKeys.Add(x.Key);
                }
            }

            foreach (var key in removeKeys)
            {
                cache.Remove(key);
            }

            removeKeys.Clear();
        }
    }
}
