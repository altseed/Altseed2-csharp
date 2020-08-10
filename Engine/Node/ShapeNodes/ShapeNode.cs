using System;
using System.Collections.Generic;

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
            _RenderedPolygon.Vertexes = VertexArray.Create(0); //TODO: Core の更新で不要になる。
        }

        #region IDrawn

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
            get => _InheritedTransform;
            internal set
            {
                _InheritedTransform = value;
                _RenderedPolygon.Transform = value * Matrix44F.GetTranslation2D(-CenterPosition);
            }
        }

        #endregion

        /// <summary>
        /// 頂点情報のコレクションを取得します。
        /// </summary>
        public IReadOnlyList<Vertex> Vertexes
        {
            get => _RenderedPolygon.Vertexes?.ToArray();
            private protected set
            {
                var vertexArray = VertexArray.Create(value);
                _RenderedPolygon.Vertexes = vertexArray;
                _RequireCalcTransform = true;
            }
        }

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
        /// <param name="vertexes">設定する各頂点の座標を格納するコレクション</param>
        /// <param name="color">各頂点に設定する色</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        private protected void SetVertexes(IEnumerable<Vector2F> vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");

            var array = Vector2FArray.Create(vertexes);
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(color);
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

        /// <inheritdoc/>
        public sealed override Matrix44F AbsoluteTransform => _RenderedPolygon.Transform;
    }
}
