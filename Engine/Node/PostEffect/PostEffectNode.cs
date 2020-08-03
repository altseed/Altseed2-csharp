using System;
using System.Collections.Generic;

namespace Altseed2
{
    public abstract class PostEffectNode : Node, IDrawn
    {
        private static Dictionary<int, RenderTextureCache> Cache;

        protected static RenderTexture GetBuffer(int identifier, Vector2I size, TextureFormatType format)
        {
            if (!Cache.ContainsKey(identifier))
            {
                Cache[identifier] = new RenderTextureCache();
            }

            return Cache[identifier].GetRenderTexture(size, format);
        }

        internal static void InitializeCache()
        {
            Cache = new Dictionary<int, RenderTextureCache>();
        }

        internal static void TerminateCache()
        {
            Cache = null;
        }

        internal static void UpdateCache()
        {
            foreach (var cache in Cache)
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

                if (Status == RegisterStatus.Registered)
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
                if (Status == RegisterStatus.Registered)
                {
                    Engine.UpdateDrawnZOrder(this, old);
                }
            }
        }
        private int _ZOrder = 0;

        public PostEffectNode()
        {
        }

        void IDrawn.Draw()
        {
            // 変更されている可能性があるので初期化しておく。
            Engine._PostEffectBuffer.WrapMode = TextureWrapMode.Repeat;
            Engine._PostEffectBuffer.FilterType = TextureFilterType.Linear;
            Draw(Engine._PostEffectBuffer, Engine.ClearColor);
        }

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