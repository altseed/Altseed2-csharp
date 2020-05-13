using System;

namespace Altseed
{
    /// <summary>
    /// 円弧を描画するノードのクラス
    /// </summary>
    [Serializable]
    public class ArcNode : DrawnNode
    {
        private bool changed = false;
        private readonly RenderedPolygon renderedPolygon;

        internal override int CullingId => renderedPolygon.Id;

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
        /// 描画を終了する角度を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が<see cref="StartDegree"/>未満または360より大きい</exception>
        public float EndDegree
        {
            get => _enddegree;
            set
            {
                if (value < _startdegree) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が{nameof(StartDegree)}(Value : {_startdegree})未満です");
                if (value > 360) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が360より大きいです");
                if (_enddegree == value) return;
                _enddegree = value;
                changed = true;
            }
        }
        private float _enddegree = 360.0f;

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
        /// 描画を開始する頂点を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満または<see cref="EndDegree"/>より大きい</exception>
        public float StartDegree
        {
            get => _startdegree;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "設定しようとした値が0未満です");
                if (value > _enddegree) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が{nameof(EndDegree)}(Value : {_enddegree})より大きいです");
                if (_startdegree == value) return;
                _startdegree = value;
                changed = true;
            }
        }
        private float _startdegree = 0.0f;

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
                if (value < _vertnum)
                {
                    if (value < _enddegree) _enddegree = value;
                    if (_enddegree < _startdegree) _startdegree = 0;
                }
                _vertnum = value;
                changed = true;
            }
        }
        private int _vertnum = 3;

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture { get => renderedPolygon.Texture; set => renderedPolygon.Texture = value; }

        /// <summary>
        /// <see cref="ArcNode"/>の新しいインスタンスを生成する
        /// </summary>
        public ArcNode()
        {
            renderedPolygon = RenderedPolygon.Create();
            renderedPolygon.Vertexes = VertexArray.Create(_vertnum);
        }

        internal override void Draw()
        {
            if (changed)
            {
                UpdateVertexes();
                changed = true;
            }
            Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        private Vector2F GetBaseVector(float degree)
        {
            var result = new Vector2F(0.0f, -_radius);
            result.Degree += degree;
            return result;
        }

        internal override void UpdateInheritedTransform() => renderedPolygon.Transform = CalcInheritedTransform();

        private void UpdateVertexes()
        {
            var deg = 360f / _vertnum;
            var size = (int)((_enddegree - _startdegree) / deg);
            var startVertexNum = (uint)MathF.Ceiling(_startdegree / deg);
            var endVertexNum = (uint)MathF.Floor(_enddegree / deg);
            var startMatched = startVertexNum * deg == _startdegree;
            var endMatched = endVertexNum * deg == _enddegree;
            if (!startMatched) size++;
            if (!endMatched) size++;
            var positions = new Vector2F[size + 2];
            var currentIndex = 1;
            if (!startMatched) positions[currentIndex++] = GetBaseVector(_startdegree);
            var vec = GetBaseVector(deg * startVertexNum);
            for (var i = startVertexNum; i <= endVertexNum; currentIndex++, i++)
            {
                positions[currentIndex] = vec;
                vec.Degree += deg;
            }
            if (!endMatched) positions[currentIndex] = GetBaseVector(_enddegree);
            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
