using System;
using System.Collections.Generic;
using System.Linq;

namespace Altseed2
{
    [Serializable]
    public class PolygonNode : DrawnNode
    {
        private readonly RenderedPolygon renderedPolygon;

        private bool _IsValid;

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
                if (value.Length < 3)
                {
                    Engine.Log.Warn(LogCategory.Engine, "Polygon whose number of vertexes is less than 3 will not be drawn.");
                    _IsValid = false;
                }
                else
                {
                    for(int i = 0; i < value.Length; ++i)
                        for(int j = i + 1; j < value.Length; ++j)
                            if (value[i] == value[j])
                            {
                                Engine.Log.Warn(LogCategory.Engine, "Polygon which has same vertexes will not be drawn.");
                                _IsValid = false;
                                return;
                            }

                    _IsValid = true;
                }

                var vertexArray = VertexArray.Create(value.Length);
                vertexArray.FromArray(value);
                renderedPolygon.Vertexes = vertexArray;

                if (IsAutoAdjustSize) AdjustSize();
            }
        }

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlendMode BlendMode
        {
            get => renderedPolygon.BlendMode;
            set
            {
                if (renderedPolygon.BlendMode == value) return;
                renderedPolygon.BlendMode = value;
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
        internal override void Draw()
        {
            if(_IsValid) Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        /// <summary>
        /// 各頂点に指定した色を設定する
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            renderedPolygon.OverwriteVertexesColor(color);
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
            renderedPolygon.Vertexes = vertexArray;

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
            renderedPolygon.CreateVertexesByVector2F(vertexArray);
            renderedPolygon.OverwriteVertexesColor(color);

            if (IsAutoAdjustSize) AdjustSize();
        }

        internal override void UpdateInheritedTransform()
        {
            var array = renderedPolygon.Vertexes;
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

            renderedPolygon.Transform = CalcInheritedTransform() * mat;
        }

        public override void AdjustSize()
        {
            if (Vertexes == null) return;

            var array = renderedPolygon.Vertexes;
            if (array != null && array.Count > 0)
            {
                MathHelper.GetMinMax(out var min, out var max, array);
                Size = max - min;
            }
            else Size = default;
        }
    }
}
