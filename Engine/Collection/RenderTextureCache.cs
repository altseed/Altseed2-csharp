using System;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// <see cref="PostEffectNode"/>に用いる<see cref="RenderTexture"/>のキャッシュのクラス
    /// </summary>
    public class RenderTextureCache
    {
        private struct CacheKey : IEquatable<CacheKey>
        {
            public Vector2I size;
            public TextureFormat format;

            public readonly override int GetHashCode()
            {
                return HashCode.Combine(size, format);
            }

            public readonly override bool Equals(object obj)
            {
                return obj is CacheKey other && Equals(other);
            }

            public readonly bool Equals(CacheKey other)
            {
                return size == other.size && format == other.format;
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

        /// <summary>
        /// <see cref="RenderTextureCache"/>の新しいインスタンスを生成します。
        /// </summary>
        public RenderTextureCache()
        {
            cache = new Dictionary<CacheKey, CacheValue>();
            removeKeys = new List<CacheKey>();
        }

        /// <summary>
        /// 指定したサイズとフォーマットの<see cref="RenderTexture"/>をキャッシュから検索する
        /// </summary>
        /// <param name="size">検索する<see cref="RenderTexture"/>のサイズ</param>
        /// <param name="format">検索する<see cref="RenderTexture"/>のフォーマット</param>
        /// <returns><paramref name="size"/>と<paramref name="format"/>を持つ<see cref="RenderTexture"/>のインスタンス</returns>
        public RenderTexture GetRenderTexture(Vector2I size, TextureFormat format)
        {
            var key = new CacheKey { size = size, format = format };

            if (cache.TryGetValue(key, out var result))
            {
                result.life = 5;
                return result.stored;
            }
            else
            {
                var res = RenderTexture.Create(size, format);
                cache.Add(key, new CacheValue { life = 5, stored = res });
                return res;
            }
        }

        /// <summary>
        /// キャッシュの整理を行う
        /// </summary>
        public void Update()
        {
            foreach (var x in cache)
            {
                x.Value.life--;
                if (x.Value.life == 0)
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
