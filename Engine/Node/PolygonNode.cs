using System;
using System.Linq;

namespace Altseed
{
    [Serializable]
    public class PolygonNode : DrawnNode
    {
        private readonly RenderedPolygon _RenderedPolygon;

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
        /// カリング用ID
        /// </summary>
        internal override int CullingId => _RenderedPolygon.Id;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public PolygonNode()
        {
            _RenderedPolygon = RenderedPolygon.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        internal protected override void Draw()
        {
            Engine.Renderer.DrawPolygon(_RenderedPolygon);
        }

        /// <summary>
        /// 頂点情報を設定する
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        public void SetVertexes(Vertex[] vertexes)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            Vertexes = vertexes;
        }

        /// <summary>
        /// 頂点情報を設定する
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        public void SetVertexes(Vector2F[] vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var vertexArray = Vector2FArray.Create(vertexes.Length);
            vertexArray.FromArray(vertexes);
            _RenderedPolygon.CreateVertexesByVector2F(vertexArray);
            _RenderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// 各頂点に指定した色を設定する
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            _RenderedPolygon.OverwriteVertexesColor(color);
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

            _RenderedPolygon.Transform = CalcInheritedTransform() * mat;
        }

        public override void AdjustSize()
        {
            if (Vertexes == null) return;

            Vector2F min = new Vector2F(float.MaxValue, float.MaxValue);
            Vector2F max = new Vector2F(float.MinValue, float.MinValue);
            foreach (var pos in Vertexes.Select(v => v.Position))
            {
                min.X = min.X > pos.X ? pos.X : min.X;
                min.Y = min.Y > pos.Y ? pos.Y : min.Y;
                max.X = max.X < pos.X ? pos.X : max.X;
                max.Y = max.Y < pos.Y ? pos.Y : max.Y;
            }

            Size = max - min;
        }
    }
}
