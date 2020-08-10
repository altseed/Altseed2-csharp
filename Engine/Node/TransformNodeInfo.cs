namespace Altseed2
{
    class TransformNodeInfo
    {
        private TransformNode _TransformNode;

        /// <summary>
        /// <see cref="TransformNode.Size"/>の領域を表示します。
        /// </summary>
        private RenderedPolygon[] _SizeBoxLines;

        /// <summary>
        /// <see cref="TransformNode.Pivot"/>の領域を表示します。
        /// </summary>
        private RenderedPolygon _PivotBox;

        private RenderedPolygon _LeftTop;
        private RenderedPolygon _RightBottom;

        private RenderedPolygon _AnchorMin;
        private RenderedPolygon _AnchorMax;

        internal TransformNodeInfo(TransformNode transformNode)
        {
            _TransformNode = transformNode;
            _SizeBoxLines = new RenderedPolygon[4];
            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                _SizeBoxLines[i] = RenderedPolygon.Create();
            }

            _PivotBox = RenderedPolygon.Create();

            _LeftTop = RenderedPolygon.Create();
            _RightBottom = RenderedPolygon.Create();

            _AnchorMin = RenderedPolygon.Create();
            _AnchorMax = RenderedPolygon.Create();
        }

        //internal void Update()
        //{
        //    var origin = _TransformNode.Position;

        //    UpdateSizeBox(origin);
        //    UpdatePivot();
        //    UpdateMargin(origin);
        //    UpdateAnchors();
        //}

        //private void UpdateSizeBox(Vector2F origin)
        //{
        //    var points = new Vector2F[4];

        //    points[0] = origin + new Vector2F();
        //    points[1] = origin + new Vector2F(_TransformNode.Size.X, 0);
        //    points[2] = origin + _TransformNode.Size;
        //    points[3] = origin + new Vector2F(0, _TransformNode.Size.Y);

        //    for (int i = 0; i < points.Length; i++)
        //    {
        //        var point1 = points[i];
        //        var point2 = points[(i + 1) % points.Length];

        //        SetLine(_SizeBoxLines[i], point1, point2, new Color(255, 128, 0));
        //    }
        //}

        //private void UpdatePivot()
        //{
        //    SetPoint(_PivotBox, _TransformNode.Position, 5f, new Color(255, 128, 0));
        //}

        //private void UpdateMargin(Vector2F origin)
        //{
        //    var ancestorSize = GetAncestorSize();

        //    SetLine(_LeftTop,
        //        ancestorSize * _TransformNode.AnchorMin,
        //        origin, new Color(255, 100, 100));
        //    SetLine(_RightBottom,
        //        ancestorSize * _TransformNode.AnchorMax,
        //        origin + _TransformNode.Size, new Color(100, 100, 255));
        //}

        //private void UpdateAnchors()
        //{
        //    var ancestorSize = GetAncestorSize();

        //    SetPoint(_AnchorMin, ancestorSize * _TransformNode.AnchorMin, 4, new Color(255, 0, 0));
        //    SetPoint(_AnchorMax, ancestorSize * _TransformNode.AnchorMax, 4, new Color(0, 0, 255));
        //}

        private void SetLine(RenderedPolygon renderedPolygon, Vector2F point1, Vector2F point2, Color color)
        {
            var positions = new Vector2F[4];
            var vec = point2 - point1;

            var side = new Vector2F(vec.Y, -vec.X).Normal;

            positions[0] = point1 - side;
            positions[1] = point1 + side;
            positions[2] = point2 + side;
            positions[3] = point2 - side;

            var array = Vector2FArray.Create(positions);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(color);
        }

        private void SetPoint(RenderedPolygon renderedPolygon, Vector2F point, float size, Color color)
        {
            var points = new Vector2F[4];
            points[0] = point + new Vector2F(-1f, -1f) * size / 2f;
            points[1] = point + new Vector2F(1f, -1f) * size / 2f;
            points[2] = point + new Vector2F(1f, 1f) * size / 2f;
            points[3] = point + new Vector2F(-1f, 1f) * size / 2f;

            var array = Vector2FArray.Create(points);
            renderedPolygon.CreateVertexesByVector2F(array);
            renderedPolygon.OverwriteVertexesColor(color);
        }

        //private Vector2F GetAncestorSize()
        //{
        //    var ancestor = _TransformNode.GetAncestorSpecificNode<ISized>();
        //    return ancestor switch
        //    {
        //        TransformNode t => t.Size / t.Scale,
        //        ISized s => s.Size,
        //        _ => new Vector2F()
        //    };
        //}

        internal void Draw()
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?
                .InheritedTransform ?? Matrix44F.Identity;

            void draw(RenderedPolygon renderedPolygon)
            {
                renderedPolygon.Transform = mat;
                Engine.Renderer.DrawPolygon(renderedPolygon);
            };

            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                draw(_SizeBoxLines[i]);
            }

            draw(_PivotBox);
            draw(_LeftTop);
            draw(_RightBottom);
            draw(_AnchorMin);
            draw(_AnchorMax);
        }
    }
}
