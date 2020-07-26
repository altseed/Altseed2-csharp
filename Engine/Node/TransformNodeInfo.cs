namespace Altseed2
{
    class TransformNodeInfo
    {
        private TransformNode _TransformNode;

        /// <summary>
        /// <see cref="TransformNode.Size"/>の領域を表示する
        /// </summary>
        private RenderedPolygon[] _SizeBoxLines;

        /// <summary>
        /// <see cref="TransformNode.Pivot"/>の領域を表示する
        /// </summary>
        private RenderedPolygon _PivotBox;

        internal TransformNodeInfo(TransformNode transformNode)
        {
            _TransformNode = transformNode;
            _SizeBoxLines = new RenderedPolygon[4];
            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                _SizeBoxLines[i] = RenderedPolygon.Create();
                _SizeBoxLines[i].Vertexes = VertexArray.Create(4); //TODO: Core の更新で不要になる。
            }

            _PivotBox = RenderedPolygon.Create();
            _PivotBox.Vertexes = VertexArray.Create(4); //TODO: Core の更新で不要になる。
        }

        internal void Update()
        {
            UpdateSizeBox();
            UpdatePivotBox();
        }

        private void UpdateSizeBox()
        {
            var points = new Vector2F[4];
            points[0] = new Vector2F();
            points[1] = new Vector2F(_TransformNode.Size.X, 0);
            points[2] = _TransformNode.Size;
            points[3] = new Vector2F(0, _TransformNode.Size.Y);

            for (int i = 0; i < points.Length; i++)
            {
                var point1 = points[i];
                var point2 = points[points.Length == i + 1 ? 0 : i + 1];

                var positions = new Vector2F[4];
                var vec = point2 - point1;

                var side = new Vector2F(vec.Y, -vec.X).Normal;

                positions[0] = point1 - side;
                positions[1] = point1 + side;
                positions[2] = point2 + side;
                positions[3] = point2 - side;

                var array = Vector2FArray.Create(positions.Length);
                array.FromArray(positions);
                _SizeBoxLines[i].CreateVertexesByVector2F(array);
                _SizeBoxLines[i].OverwriteVertexesColor(new Color(200, 200, 200));
            }
        }

        private void UpdatePivotBox()
        {
            var pos = _TransformNode.CenterPosition;
            var points = new Vector2F[4];
            points[0] = pos + new Vector2F(-3, -3);
            points[1] = pos + new Vector2F(3, -3);
            points[2] = pos + new Vector2F(3, 3);
            points[3] = pos + new Vector2F(-3, 3);

            var array = Vector2FArray.Create(4);
            array.FromArray(points);
            _PivotBox.CreateVertexesByVector2F(array);
            _PivotBox.OverwriteVertexesColor(new Color(0, 0, 255));
        }

        internal void Draw()
        {
            var mat = _TransformNode.AbsoluteTransform;

            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                _SizeBoxLines[i].Transform = mat;
                Engine.Renderer.DrawPolygon(_SizeBoxLines[i]);
            }

            _PivotBox.Transform = mat;
            Engine.Renderer.DrawPolygon(_PivotBox);
        }
    }
}
