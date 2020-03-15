using System;

namespace Altseed
{
    [Serializable]
    public class PolygonNode : DrawnNode
    {
        private readonly RenderedPolygon renderedPolygon;

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
        public Texture2D Texture
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
            get => renderedPolygon.Vertexes.ToArray();
            set
            {
                var vertexArray = VertexArray.Create(value.Length);
                vertexArray.FromArray(value);
                renderedPolygon.Vertexes = vertexArray;
            }
        }

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
            UpdateTransform(); // TODO:変更時のみにする（親ノードでの変更に注意）
            Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        protected internal override void UpdateTransform()
        {
            var matAncestor = Matrix44F.Identity;
            foreach (var n in EnumerateAncestors())
            {
                if (n is DrawnNode d)
                {
                    matAncestor = d.Transform * matAncestor;
                }
            }
            var mat = _MatCenterPosition * _MatPosition * _MatAngle * _MatScale * _MatCenterPositionInv;

            renderedPolygon.Transform = matAncestor * mat;
            Transform = mat;
        }

        public void SetVertexesByVector2F(Vector2F[] vertexes)
        {
            var vertexArray = Vector2FArray.Create(vertexes.Length);
            vertexArray.FromArray(vertexes);
            renderedPolygon.SetVertexesByVector2F(vertexArray);
        }

        public void SetAllVertexColor(Color color)
        {
            var vertexArray = Vertexes;
            for(int i = 0; i < vertexArray.Length; ++i)
                vertexArray[i].Color = color;
            Vertexes = vertexArray;
        }
    }
}
