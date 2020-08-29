using System;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// ポストエフェクトを扱うノードの基底クラス
    /// </summary>
    public abstract class PostEffectNode : Node, IDrawn
    {
        private static Dictionary<int, RenderTextureCache> _Cache;

        /// <summary>
        /// 指定したIDとサイズ，フォーマットを持つ<see cref="RenderTexture"/>のインスタンスをキャッシュから検索し，取得します。
        /// </summary>
        /// <param name="identifier">検索する<see cref="RenderTexture"/>のID</param>
        /// <param name="size">検索する<see cref="RenderTexture"/>の大きさ</param>
        /// <param name="format">検索する<see cref="RenderTexture"/>のフォーマット</param>
        /// <returns><paramref name="identifier"/>，<paramref name="size"/>，<paramref name="format"/>を持つ<see cref="RenderTexture"/>のインスタンス</returns>
        protected static RenderTexture GetBuffer(int identifier, Vector2I size, TextureFormat format)
        {
            if (!_Cache.ContainsKey(identifier))
            {
                _Cache[identifier] = new RenderTextureCache();
            }

            return _Cache[identifier].GetRenderTexture(size, format);
        }

        internal static void InitializeCache()
        {
            _Cache = new Dictionary<int, RenderTextureCache>();
        }

        internal static void TerminateCache()
        {
            _Cache = null;
        }

        internal static void UpdateCache()
        {
            foreach (var cache in _Cache)
            {
                cache.Value.Update();
            }
        }

        /// <summary>
        /// このノードを描画するカメラを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup;
            set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;

                if (Status == RegisteredStatus.Registered)
                {
                    Engine.UpdateDrawnCameraGroup(this, old);
                }
            }
        }
        private ulong _CameraGroup = 0;

        /// <summary>
        /// PostEffectNodeが描画される順番。DrawnNodeを描画した後にまとめて描画されます。
        /// </summary>
        public int ZOrder
        {
            get => _ZOrder;
            set
            {
                if (_ZOrder == value) return;
                var old = _ZOrder;
                _ZOrder = value;
                if (Status == RegisteredStatus.Registered)
                {
                    Engine.UpdateDrawnZOrder(this, old);
                }
            }
        }
        private int _ZOrder = 0;

        /// <summary>
        /// <see cref="PostEffectNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <exception cref="InvalidOperationException">Graphics機能が初期化されていない。</exception>
        public PostEffectNode()
        {
            if (!Engine.Config.EnabledCoreModules.HasFlag(CoreModules.Graphics))
            {
                throw new InvalidOperationException("Graphics機能が初期化されていません。");
            }
        }

        void IDrawn.Draw()
        {
            // 変更されている可能性があるので初期化しておく。
            Engine._PostEffectBuffer.WrapMode = TextureWrapMode.Repeat;
            Engine._PostEffectBuffer.FilterType = TextureFilter.Linear;
            Draw(Engine._PostEffectBuffer, Engine.ClearColor);
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        /// <param name="src">描画先の<see cref="RenderTexture"/>のインスタンス</param>
        /// <param name="clearColor">描画されないピクセルを埋めるときの色</param>
        protected abstract void Draw(RenderTexture src, Color clearColor);

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
        }

        #endregion
    }
}