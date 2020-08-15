using System;
using System.Linq;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 図形を描画するノードを表します。
    /// </summary>
    [Serializable]
    public class PolygonNode : TransformNode, ICullableDrawn/*, ISized*/
    {
        protected private readonly RenderedPolygon _RenderedPolygon;

        private bool _IsValid = false;

        /// <summary>
        /// <see cref="PolygonNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public PolygonNode()
        {
            _RenderedPolygon = RenderedPolygon.Create();
        }

        #region IDrawn

        void IDrawn.Draw()
        {
            if (_IsValid) Engine.Renderer.DrawPolygon(_RenderedPolygon);
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
        /// 先祖の<see cref="IsDrawn"/>を考慮して、このノードを描画するかどうかを取得します。
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
        /// 頂点情報のコレクションを取得または設定します。
        /// </summary>
        public IReadOnlyList<Vertex> Vertexes
        {
            get => _RenderedPolygon.Vertexes?.ToArray();
            set
            {
                _RenderedPolygon.Vertexes.FromEnumerable(value);
                SetVertexes(_RenderedPolygon.Vertexes);
            }
        }

        /// <summary>
        /// 頂点情報が有効かどうかを判定します。
        /// </summary>
        /// <param name="vertexes">頂点情報</param>
        private bool Validate(VertexArray vertexes)
        {
            if (vertexes.Count < 3)
            {
                Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点が 3 個未満のためこのノードは描画されません。");
                return false;
            }

            //for (int i = 0; i < vertexes.Count; ++i)
            //    for (int j = i + 1; j < vertexes.Count; ++j)
            //        if (vertexes[i].Position == vertexes[j].Position)
            //        {
            //            Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点に重複があるためこのノードは描画されません。");
            //            return false;
            //        }
            return true;
        }

        /// <summary>
        /// 頂点情報が有効かどうかを判定します。
        /// </summary>
        /// <param name="vertexes">頂点情報</param>
        private bool Validate(Vector2FArray vertexes)
        {
            if (vertexes.Count < 3)
            {
                Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点が 3 個未満のためこのノードは描画されません。");
                return false;
            }

            //for (int i = 0; i < vertexes.Count; ++i)
            //    for (int j = i + 1; j < vertexes.Count; ++j)
            //        if (vertexes[i] == vertexes[j])
            //        {
            //            Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点に重複があるためこのノードは描画されません。");
            //            return false;
            //        }
            return true;
        }

        internal void SetVertexes(VertexArray array)
        {
            _RenderedPolygon.Vertexes = array;
            _IsValid = Validate(array);
            _RequireCalcTransform = true;
        }

        internal void SetVertexesFromPositions(Vector2FArray array, Color color)
        {
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(color);
            _IsValid = Validate(array);
            _RequireCalcTransform = true;
        }

        /// <summary>
        /// 各頂点に指定した色を設定します。
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            _RenderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="Span{Vertex}" /></param>
        /// <remarks>
        /// 色は白(255, 255, 255)に設定されます。
        /// </remarks>
        public void SetVertexes(ReadOnlySpan<Vertex> vertexes)
        {
            _RenderedPolygon.Vertexes.FromSpan(vertexes);
            SetVertexes(_RenderedPolygon.Vertexes);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="IEnumerable{Vertex}" /></param>
        /// <remarks>
        /// 色は白(255, 255, 255)に設定されます。
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnullです。</exception>
        public void SetVertexes(IEnumerable<Vertex> vertexes)
        {
            if (vertexes is null) throw new ArgumentNullException(nameof(vertexes));
            _RenderedPolygon.Vertexes.FromEnumerable(vertexes);
            SetVertexes(_RenderedPolygon.Vertexes);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="Span{Vector2F}" /></param>
        /// <param name="color">各頂点に設定する色</param>
        public void SetVertexes(ReadOnlySpan<Vector2F> vertexes, Color color)
        {
            Engine.Vector2FArrayCache.FromSpan(vertexes);
            SetVertexesFromPositions(Engine.Vector2FArrayCache, color);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="IEnumerable{Vector2F}" /></param>
        /// <param name="color">各頂点に設定する色</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnullです。</exception>
        public void SetVertexes(IEnumerable<Vector2F> vertexes, Color color)
        {
            if (vertexes is null) throw new ArgumentNullException(nameof(vertexes));
            Engine.Vector2FArrayCache.FromEnumerable(vertexes);
            SetVertexesFromPositions(Engine.Vector2FArrayCache, color);
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
