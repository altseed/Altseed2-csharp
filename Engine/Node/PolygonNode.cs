using System;

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
        public Texture2D Texture
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
            get => _RenderedPolygon.Vertexes.ToArray();
            set
            {
                var vertexArray = VertexArray.Create(value.Length);
                vertexArray.FromArray(value);
                _RenderedPolygon.Vertexes = vertexArray;
            }
        }

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
        internal override void Draw()
        {
            _RenderedPolygon.Transform = CalcInheritedTransform();
            Engine.Renderer.DrawPolygon(_RenderedPolygon);
        }

        public void SetVertexes(Vector2F[] vertexes)
        {
            var vertexArray = Vector2FArray.Create(vertexes.Length);
            vertexArray.FromArray(vertexes);
            _RenderedPolygon.SetVertexesByVector2F(vertexArray);
        }

        public void SetAllVertexColor(Color color)
        {
            var vertexArray = Vertexes;
            for (int i = 0; i < vertexArray.Length; ++i)
                vertexArray[i].Color = color;
            Vertexes = vertexArray;
        }
    }
}
