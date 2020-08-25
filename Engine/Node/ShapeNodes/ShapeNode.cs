using System;

namespace Altseed2
{
    /// <summary>
    /// 基本的な図形を描画するノードの基底クラスを表します。
    /// </summary>
    [Serializable]
    public abstract class ShapeNode : TransformNode, ICullableDrawn/*, ISized*/
    {
        protected private readonly RenderedPolygon _RenderedPolygon;

        /// <summary>
        /// <see cref="ShapeNode"/>の新しいインスタンスを生成します。
        /// </summary>
        protected ShapeNode()
        {
            _RenderedPolygon = RenderedPolygon.Create();
        }

        #region IDrawn

        Rendered ICullableDrawn.Rendered => _RenderedPolygon;

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawPolygon(_RenderedPolygon);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedPolygon.Id;

        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup;
            set
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

                if (Status == RegisteredStatus.Registered)
                {
                    Engine.UpdateDrawnZOrder(this, old);
                }
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
        /// 先祖の<see cref="IsDrawn" />を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
            Engine.CullingSystem.Register(_RenderedPolygon);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
            Engine.CullingSystem.Unregister(_RenderedPolygon);
        }

        #endregion

        #region RenderedPolygon

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlend AlphaBlend
        {
            get => _RenderedPolygon.AlphaBlend;
            set
            {
                if (_RenderedPolygon.AlphaBlend == value) return;
                _RenderedPolygon.AlphaBlend = value;
            }
        }

        /// <summary>
        /// <see cref="Texture"/>を切り出す範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _RenderedPolygon.Src;
            set
            {
                if (_RenderedPolygon.Src == value) return;

                _RenderedPolygon.Src = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => _RenderedPolygon.Texture;
            set
            {
                if (_RenderedPolygon.Texture == value) return;

                _RenderedPolygon.Texture = value;
                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 描画に適用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => _RenderedPolygon.Material;
            set
            {
                if (_RenderedPolygon.Material == value) return;

                _RenderedPolygon.Material = value;
            }
        }

        /// <inheritdoc/>
        public sealed override Matrix44F InheritedTransform
        {
            get => base.InheritedTransform;
            private protected set
            {
                base.InheritedTransform = value;
                AbsoluteTransform = value * Matrix44F.GetTranslation2D(-CenterPosition);
                _RenderedPolygon.Transform = AbsoluteTransform;
            }
        }

        #endregion

        /// <summary>
        /// 各頂点に指定した色を設定する
        /// </summary>
        /// <param name="color">設定する色</param>
        private protected void OverwriteVertexColor(Color color)
        {
            _RenderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="ReadOnlySpan{Vector2F}"/></param>
        /// <param name="color">各頂点に設定する色</param>
        private protected void SetVertexes(ReadOnlySpan<Vector2F> vertexes, Color color)
        {
            Engine.Vector2FArrayCache.FromSpan(vertexes);
            _RenderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            _RenderedPolygon.OverwriteVertexesColor(color);

            _RequireCalcTransform = true;
        }

        /// <summary>
        /// 頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の情報を格納する<see cref="ReadOnlySpan{T}"/></param>
        private protected void SetVertexes(ReadOnlySpan<Vertex> vertexes)
        {
            _RenderedPolygon.Vertexes.FromSpan(vertexes);
            _RequireCalcTransform = true;
        }

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize
        {
            get
            {
                MathHelper.GetMinMax(out var min, out var max, _RenderedPolygon.Vertexes);
                return max - min;
            }
        }
    }
}
