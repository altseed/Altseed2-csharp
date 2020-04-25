using System;
using System.Collections.Generic;

namespace Altseed
{
    public class RenderTextureCache
    {
        private struct CacheKey
        {
            public Vector2I size;

            public override int GetHashCode()
            {
                return HashCode.Combine(size);
            }

            public override bool Equals(object obj)
            {
                return obj is CacheKey other && this == other;
            }

            public static bool operator ==(CacheKey a, CacheKey b)
            {
                return a.size == b.size;
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
