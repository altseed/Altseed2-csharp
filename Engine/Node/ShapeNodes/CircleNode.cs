using System;

namespace Altseed
{
    /// <summary>
    /// 円を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class CircleNode : DrawnNode
    {
        private bool changed = false;
        private readonly RenderedPolygon renderedPolygon;

        internal override int CullingId => renderedPolygon.Id;

        public override Matrix44F AbsoluteTransform => renderedPolygon.Transform;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                if (_color == value) return;
                _color = value;
                renderedPolygon.OverwriteVertexesColor(value);
            }
        }
        private Color _color = new Color(255, 255, 255);

        /// <summary>
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material { get => renderedPolygon.Material; set { renderedPolygon.Material = value; } }

        /// <summary>
        /// 半径を取得または設定します。
        /// </summary>
        public float Radius
        {
            get => _radius;
            set
            {
                if (_radius == value) return;
                _radius = value;
                changed = true;
            }
        }
        private float _radius;

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
                renderedPolygon.Src = new RectF(default, value?.Size ?? Vector2F.One);
            }
        }

        /// <summary>
        /// 頂点の個数を取得または設定します。
        /// </summary>
        public int VertNum
        {
            get => _vertnum;
            set
            {
                if (value < 3) throw new ArgumentOutOfRangeException(nameof(value), "設定しようとした値が3未満です");
                if (_vertnum == value) return;
                _vertnum = value;
                changed = true;
            }
        }
        private int _vertnum = 3;

        /// <summary>
        /// <see cref="CircleNode"/>の新しいインスタンスを生成する
        /// </summary>
        public CircleNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(_vertnum);
        }

        public override void AdjustSize()
        {
            var length = _radius * 2;
            Size = new Vector2F(length, length);
        }

        internal override void Draw() => Engine.Renderer.DrawPolygon(renderedPolygon);

        internal override void UpdateInheritedTransform()
        {
            if (changed)
            {
                UpdateVertexes();
                changed = false;
            }
            renderedPolygon.Transform = CalcInheritedTransform();
        }

        private void UpdateVertexes()
        {
            var deg = 360f / _vertnum;          
            var positions = new Vector2F[_vertnum];
            var vec = new Vector2F(0.0f, -_radius);
            
            for (int i = 0; i < _vertnum; i++)
            {
                positions[i] = vec;
                vec.Degree += deg;
            }

            AdjustSize();

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
