using System;
using System.Collections.Generic;

namespace Altseed2
{
    public class RenderTextureCache
    {
        private struct CacheKey : IEquatable<CacheKey>
        {
            public Vector2I size;

            public readonly override int GetHashCode()
            {
                return HashCode.Combine(size);
            }

            public readonly override bool Equals(object obj)
            {
                return obj is CacheKey other && Equals(other);
            }

            public readonly bool Equals(CacheKey other)
            {
                return size == other.size;
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

        private class CacheValue
        {
            public int life;
            public RenderTexture stored;
        }

        private readonly Dictionary<CacheKey, CacheValue> cache;
        private readonly List<CacheKey> removeKeys;

        public RenderTextureCache()
        {
            cache = new Dictionary<CacheKey, CacheValue>();
            removeKeys = new List<CacheKey>();
        }

        public RenderTexture GetRenderTexture(Vector2I size)
        {
            var key = new CacheKey { size = size };

            if (cache.TryGetValue(key, out var result))
            {
                result.life = 5;
                return result.stored;
            }
            else
            {
                var res = RenderTexture.Create(size);
                cache.Add(key, new CacheValue { life = 5, stored = res });
                return res;
            }
        }

        public void Update()
        {
            foreach(var x in cache)
            {
                x.Value.life--;
                if(x.Value.life == 0)
                {
                    removeKeys.Add(x.Key);
                }
            }

            foreach(var key in removeKeys)
            {
                cache.Remove(key);
            }

            removeKeys.Clear();
        }
    }
}
