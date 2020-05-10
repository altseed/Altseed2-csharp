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
        /// 描画を終了する頂点を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が<see cref="StartVertNum"/>未満または<see cref="VertNum"/>より大きい</exception>
        public int EndVertNum
        {
            get => _endvertnum;
            set
            {
                if (value < _startvertnum) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が{nameof(StartVertNum)}(Value : {_startvertnum})未満です");
                if (value > _vertnum) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が{nameof(VertNum)}(Value : {_vertnum})より大きいです");
                if (_endvertnum == value) return;
                _endvertnum = value;
                changed = true;
            }
        }
        private int _endvertnum = 2;

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
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満または<see cref="EndVertNum"/>より大きい</exception>
        public int StartVertNum
        {
            get => _startvertnum;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "設定しようとした値が0未満です");
                if (value > _endvertnum) throw new ArgumentOutOfRangeException(nameof(value), $"設定しようとした値が{nameof(EndVertNum)}(Value : {_endvertnum})より大きいです");
                if (_startvertnum == value) return;
                _startvertnum = value;
                changed = true;
            }
        }
        private int _startvertnum = 0;

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
                    if (value < _endvertnum) _endvertnum = value;
                    if (_endvertnum < _startvertnum) _startvertnum = 0;
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

        internal override void UpdateInheritedTransform() => renderedPolygon.Transform = CalcInheritedTransform();

        private void UpdateVertexes()
        {
            var deg = 360f / _vertnum;          
            var positions = new Vector2F[_endvertnum - _startvertnum + 2];
            var vec = new Vector2F(0.0f, -_radius);
            vec.Degree += deg * _startvertnum;
            for (int i = _startvertnum; i <= _endvertnum; i++)
            {
                positions[i- _startvertnum + 1] = vec;
                vec.Degree += deg;
            }

            var array = Vector2FArray.Create(positions.Length);
            array.FromArray(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(_color);
        }
    }
}
