using System;

namespace Altseed2
{
    /// <summary>
    /// テクスチャを描画するノードを表します。
    /// </summary>
    [Serializable]
    public class SpriteNode : TransformNode, ICullableDrawn
    {
        private readonly RenderedSprite _RenderedSprite;

        #region IDrawn

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawSprite(_RenderedSprite);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedSprite.Id;

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
        /// この先祖の<see cref="IsDrawn">を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>

        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion

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

        public override Matrix44F AbsoluteTransform => _RenderedSprite.Transform;

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

        public bool IsAutoAdjustSize { get; set; } = true;

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

                if (IsAutoAdjustSize) AdjustSize();
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
                //TODO: Src
            }
        }

        /// <summary>
        /// 描画モードを取得または設定します。
        /// </summary>
        public DrawMode Mode
        {
            get => _Mode;
            set
            {
                if (_Mode == value) return;

                _Mode = value;
            }
        }
        private DrawMode _Mode = DrawMode.Absolute;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpriteNode()
        {
            _RenderedSprite = RenderedSprite.Create();
        }

        internal override void UpdateInheritedTransform()
        {
            var mat = new Matrix44F();
            switch (Mode)
            {
                case DrawMode.Fill:
                    mat = Matrix44F.GetScale2D(Size / Src.Size);
                    break;
                case DrawMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > Src.Size.X / Src.Size.Y)
                        scale.X = Src.Size.X * Size.Y / Src.Size.Y;
                    else
                        scale.Y = Src.Size.Y * Size.X / Src.Size.X;

                    scale /= Src.Size;

                    mat = Matrix44F.GetScale2D(scale);
                    break;
                case DrawMode.Absolute:
                    mat = Matrix44F.Identity;
                    break;
                default:
                    break;
            }

            _RenderedSprite.Transform = CalcInheritedTransform() * mat;
        }

        public void AdjustSize()
        {
            Size = Src.Size;
        }
    }
}
