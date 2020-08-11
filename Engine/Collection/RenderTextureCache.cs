using System;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// <see cref="PostEffectNode"/>に用いる<see cref="RenderTexture"/>のキャッシュのクラス
    /// </summary>
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

        /// <summary>
        /// <see cref="RenderTextureCache"/>の新しいインスタンスを生成します。
        /// </summary>
        public RenderTextureCache()
        {
            cache = new Dictionary<CacheKey, CacheValue>();
            removeKeys = new List<CacheKey>();
        }

        /// <summary>
        /// 指定したサイズとフォーマットの<see cref="RenderTexture"/>をキャッシュから検索します。
        /// </summary>
        /// <param name="size">検索する<see cref="RenderTexture"/>のサイズ</param>
        /// <param name="format">検索する<see cref="RenderTexture"/>のフォーマット</param>
        /// <returns><paramref name="size"/>と<paramref name="format"/>を持つ<see cref="RenderTexture"/>のインスタンス</returns>
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

        /// <summary>
        /// キャッシュの整理を行います。
        /// </summary>
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
