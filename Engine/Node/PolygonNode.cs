using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed2
{
    [Serializable]
    public class PolygonNode : TransformNode, ICullableDrawn
    {
        protected private readonly RenderedPolygon _RenderedPolygon;

        #region IDrawn

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawPolygon(_RenderedPolygon);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedPolygon.Id;

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

        public override Matrix44F AbsoluteTransform => _RenderedPolygon.Transform;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _RenderedPolygon.Src;
            set
            {
                if (_RenderedPolygon.Src == value) return;
                _RenderedPolygon.Src = value;
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

        /// <summary>
        /// 描画に適用するマテリアルを取得または設定します。
        /// </summary>
        public Vertex[] Vertexes
        {
            get
            {
                return _RenderedPolygon.Vertexes?.ToArray();
            }
            set
            {
                var vertexArray = VertexArray.Create(value.Length);
                vertexArray.FromArray(value);
                _RenderedPolygon.Vertexes = vertexArray;

                if (IsAutoAdjustSize) AdjustSize();
            }
        }

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlendMode BlendMode
        {
            get => _RenderedPolygon.BlendMode;
            set
            {
                if (_RenderedPolygon.BlendMode == value) return;
                _RenderedPolygon.BlendMode = value;
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
        public PolygonNode()
        {
            _RenderedPolygon = RenderedPolygon.Create();
        }

        /// <summary>
        /// 各頂点に指定した色を設定する
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            _RenderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納するコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        /// <remarks>色は白(255, 255, 255)に設定されます。</remarks>
        public void SetVertexes(IEnumerable<Vertex> vertexes)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            Vertex[] array;
            switch (vertexes)
            {
                case Vertex[] a:
                    array = a;
                    break;
                case ICollection<Vertex> c:
                    array = new Vertex[c.Count];
                    c.CopyTo(array, 0);
                    break;
                default:
                    array = vertexes.ToArray();
                    break;
            }
            var vertexArray = VertexArray.Create(array.Length);
            vertexArray.FromArray(array);
            _RenderedPolygon.Vertexes = vertexArray;

            if (IsAutoAdjustSize) AdjustSize();
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納するコレクション</param>
        /// <param name="color">各頂点に設定する色</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        public void SetVertexes(IEnumerable<Vector2F> vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            Vector2F[] array;
            switch (vertexes)
            {
                case Vector2F[] a:
                    array = a;
                    break;
                case ICollection<Vector2F> c:
                    array = new Vector2F[c.Count];
                    c.CopyTo(array, 0);
                    break;
                default:
                    array = vertexes.ToArray();
                    break;
            }
            var vertexArray = Vector2FArray.Create(array.Length);
            vertexArray.FromArray(array);
            _RenderedPolygon.CreateVertexesByVector2F(vertexArray);
            _RenderedPolygon.OverwriteVertexesColor(color);

            if (IsAutoAdjustSize) AdjustSize();
        }

        internal override void UpdateInheritedTransform()
        {
            var array = _RenderedPolygon.Vertexes;
            MathHelper.GetMinMax(out var min, out var max, array);
            var size = max - min;

            var mat = new Matrix44F();
            switch (Mode)
            {
                case DrawMode.Fill:
                    mat = Matrix44F.GetScale2D(Size / size);
                    break;
                case DrawMode.KeepAspect:
                    var scale = Size;

                    if (Size.X / Size.Y > size.X / size.Y)
                        scale.X = size.X * Size.Y / size.Y;
                    else
                        scale.Y = size.Y * Size.X / size.X;

                    scale /= size;

                    mat = Matrix44F.GetScale2D(scale);
                    break;
                case DrawMode.Absolute:
                    mat = Matrix44F.Identity;
                    break;
                default:
                    break;
            }
            mat *= Matrix44F.GetTranslation2D(-min);

            _RenderedPolygon.Transform = CalcInheritedTransform() * mat;
        }

        public override void AdjustSize()
        {
            if (Vertexes == null) return;

            var array = _RenderedPolygon.Vertexes;
            if (array != null && array.Count > 0)
            {
                MathHelper.GetMinMax(out var min, out var max, array);
                Size = max - min;
            }
            else Size = default;
        }
    }
}
