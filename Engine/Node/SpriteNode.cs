using System;

namespace Altseed2
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : TransformNode, ICullableDrawn, ISized
    {
        private readonly RenderedSprite _RenderedSprite;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteNode()
        {
            _RenderedSprite = RenderedSprite.Create();
        }

        #region IDrawn

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawSprite(_RenderedSprite);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedSprite.Id;

        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup; set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;
                Engine.UpdateDrawnCameraGroup(this, old);
            }
        }
        private ulong _CameraGroup;

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public int ZOrder
        {
            get => _ZOrder;
            set
            {
                if (value == _ZOrder) return;

                var old = _ZOrder;
                _ZOrder = value;

                Engine.UpdateDrawnZOrder(this, old);
            }
        }
        private int _ZOrder;

        /// <summary>
        /// このノードを描画するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn
        {
            get => _IsDrawn; set
            {
                if (_IsDrawn == value) return;
                _IsDrawn = value;
                this.UpdateIsDrawnActuallyOfDescendants();

            }
        }
        private bool _IsDrawn = true;

        /// <summary>
        /// 先祖の<see cref="IsDrawn">を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);

            CalcTransform();
            var ancestor = GetAncestorSpecificNode<SpriteNode>();
            PropagateTransform(this, ancestor?.AbsoluteTransform ?? Matrix44F.Identity);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
        }

        #endregion

        #region RenderedSprite

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _RenderedSprite.Color;
            set
            {
                if (_RenderedSprite.Color == value) return;
                _RenderedSprite.Color = value;
            }
        }

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlendMode BlendMode
        {
            get => _RenderedSprite.BlendMode;
            set
            {
                if (_RenderedSprite.BlendMode == value) return;
                _RenderedSprite.BlendMode = value;
            }
        }

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _RenderedSprite.Src;
            set
            {
                if (_RenderedSprite.Src == value) return;
                _RenderedSprite.Src = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => _RenderedSprite.Texture;
            set
            {
                if (_RenderedSprite.Texture == value) return;
                _RenderedSprite.Texture = value;

                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します
        /// </summary>
        public Material Material
        {
            get => _RenderedSprite.Material;
            set
            {
                if (_RenderedSprite.Material == value) return;

                _RenderedSprite.Material = value;
            }
        }

        internal override Matrix44F AbsoluteTransform
        {
            get => _RenderedSprite.Transform;
            set
            {
                if (_RenderedSprite.Transform == value) return;
                _RenderedSprite.Transform = value;
            }
        }

        #endregion

        /// <summary>
        /// 拡大率を取得または設定します。
        /// このプロパティを変更すると、 <see cref="ScalingMode"/> が <see cref="ScalingMode.Manual"/> に変更されます。
        /// </summary>
        public override Vector2F Scale
        {
            get => _Scale;
            set
            {
                if (value == _Scale) return;
                _Scale = value;
                ScalingMode = ScalingMode.Manual;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public override Vector2F ContentSize => Src.Size;
    }
}
