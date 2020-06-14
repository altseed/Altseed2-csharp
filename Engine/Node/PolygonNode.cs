using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed
{
    [Serializable]
    public class PolygonNode : DrawnNode
    {
        private readonly RenderedPolygon renderedPolygon;

        public override Matrix44F AbsoluteTransform => renderedPolygon.Transform;

        /// <summary>
        /// 描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => renderedPolygon.Src;
            set
            {
                if (renderedPolygon.Src == value) return;
                renderedPolygon.Src = value;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => renderedPolygon.Texture;
            set
            {
                if (renderedPolygon.Texture == value) return;
                renderedPolygon.Texture = value;

                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
            }
        }

        /// <summary>
        /// 描画に適用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => renderedPolygon.Material;
            set
            {
                if (renderedPolygon.Material == value) return;

                renderedPolygon.Material = value;
            }
        }

        /// <summary>
        /// 描画に適用するマテリアルを取得または設定します。
        /// </summary>
        public Vertex[] Vertexes
        {
            get
            {
                return renderedPolygon.Vertexes?.ToArray();
            }
            set
            {
                var vertexArray = VertexArray.Create(value.Length);
                vertexArray.FromArray(value);
                renderedPolygon.Vertexes = vertexArray;
            }
        }

        public void SetVertexes(Vertex[] vertexes)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var vertexArray = VertexArray.Create(vertexes.Length);
            vertexArray.FromArray(vertexes);
            renderedPolygon.Vertexes = vertexArray;
        }

        public void SetVertexes(IEnumerable<Vertex> vertexes)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var array = vertexes.ToArray();
            var vertexArray = VertexArray.Create(array.Length);
            vertexArray.FromArray(array);
            renderedPolygon.Vertexes = vertexArray;
        }

        /// <summary>
        /// 頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        public void SetVertexes(Vector2F[] vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var vertexArray = Vector2FArray.Create(vertexes.Length);
            vertexArray.FromArray(vertexes);
            renderedPolygon.CreateVertexesByVector2F(vertexArray);
            renderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// 頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnull</exception>
        public void SetVertexes(IEnumerable<Vector2F> vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var array = vertexes.ToArray();
            var vertexArray = Vector2FArray.Create(array.Length);
            vertexArray.FromArray(array);
            renderedPolygon.CreateVertexesByVector2F(vertexArray);
            renderedPolygon.OverwriteVertexesColor(color);
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
        internal override int CullingId => renderedPolygon.Id;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public PolygonNode()
        {
            renderedPolygon = RenderedPolygon.Create();
        }

        /// <summary>
        /// 描画を実行します。
        /// </summary>
        protected internal override void Draw()
        {
            Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        /// <summary>
        /// 各頂点に指定した色を設定する
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            renderedPolygon.OverwriteVertexesColor(color);
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

            renderedPolygon.Transform = CalcInheritedTransform() * mat;
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
