using System;

namespace Altseed2
{
    [Serializable]
    class TransformNodeInfo
    {
        private TransformNode _TransformNode;

        private RenderedPolygon[] _SizeBoxLines;
        private RenderedPolygon _PositionBox;

        internal TransformNodeInfo(TransformNode transformNode)
        {
            _TransformNode = transformNode;
            _SizeBoxLines = new RenderedPolygon[4];
            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                _SizeBoxLines[i] = RenderedPolygon.Create();
            }

            _PositionBox = RenderedPolygon.Create();
        }

        internal void Update()
        {
            UpdatePositionBox();
            UpdateSizeBox();
        }

        private void UpdatePositionBox()
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            SetPoint(_PositionBox, new Vector2F(pos.X, pos.Y), 8, new Color(255, 0, 0));
        }

        private void UpdateSizeBox()
        {
            var points = new Vector2F[4];

            var origin = -_TransformNode.CenterPosition * _TransformNode.Scale;
            points[0] = origin;
            points[1] = origin + new Vector2F(_TransformNode.ContentSize.X, 0) * _TransformNode.Scale;
            points[2] = origin + _TransformNode.ContentSize * _TransformNode.Scale;
            points[3] = origin + new Vector2F(0, _TransformNode.ContentSize.Y) * _TransformNode.Scale;

            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            mat = mat * Matrix44F.GetTranslation2D(_TransformNode.Position) * Matrix44F.GetRotationZ(MathHelper.DegreeToRadian(_TransformNode.Angle));
            for (int i = 0; i < points.Length; i++)
            {
                var vector = mat.Transform3D(new Vector3F(points[i].X, points[i].Y, 0));
                points[i] = new Vector2F(vector.X, vector.Y);
            }

            for (int i = 0; i < points.Length; i++)
            {
                var point1 = points[i];
                var point2 = points[(i + 1) % points.Length];

                SetLine(_SizeBoxLines[i], point1, point2, new Color(255, 128, 0));
            }
        }

        private void SetLine(RenderedPolygon renderedPolygon, Vector2F point1, Vector2F point2, Color color)
        {
            Span<Vector2F> positions = stackalloc Vector2F[4];
            var vec = point2 - point1;

            var side = new Vector2F(vec.Y, -vec.X).Normal;

            positions[0] = point1 - side;
            positions[1] = point1 + side;
            positions[2] = point2 + side;
            positions[3] = point2 - side;

            Engine.Vector2FArrayCache.FromSpan(positions);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        private void SetPoint(RenderedPolygon renderedPolygon, Vector2F point, float size, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[4];
            points[0] = point + new Vector2F(-1f, -1f) * size / 2f;
            points[1] = point + new Vector2F(1f, -1f) * size / 2f;
            points[2] = point + new Vector2F(1f, 1f) * size / 2f;
            points[3] = point + new Vector2F(-1f, 1f) * size / 2f;

            Engine.Vector2FArrayCache.FromSpan(points);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        internal void Draw()
        {
            void draw(RenderedPolygon renderedPolygon)
            {
                Engine.Renderer.DrawPolygon(renderedPolygon);
            };

            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                draw(_SizeBoxLines[i]);
            }

            draw(_PositionBox);
        }
    }
}
