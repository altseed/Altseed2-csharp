using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    [Serializable]
    sealed class AnchorTransformerNodeInfo : TransformerNodeInfo
    {
        private AnchorTransformerNode AnchorTransformerNode => _TransformerNode as AnchorTransformerNode;

        private RenderedPolygon[] _SizeBoxLines;
        private RenderedPolygon[] _AnchorLines;
        private RenderedPolygon _PositionBox;

        public AnchorTransformerNodeInfo(AnchorTransformerNode transformerNode) : base(transformerNode)
        {
            _SizeBoxLines = new RenderedPolygon[4];
            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                _SizeBoxLines[i] = RenderedPolygon.Create();
            }

            _AnchorLines = new RenderedPolygon[4];
            for (int i = 0; i < _AnchorLines.Length; i++)
            {
                _AnchorLines[i] = RenderedPolygon.Create();
            }

            _PositionBox = RenderedPolygon.Create();
        }

        protected internal override void Update()
        {
            UpdatePositionBox();
            UpdateSizeBox();
            UpdateAnchor();
        }

        protected internal override void Draw()
        {
            void draw(RenderedPolygon renderedPolygon)
            {
                Engine.Renderer.DrawPolygon(renderedPolygon);
            };

            for (int i = 0; i < _SizeBoxLines.Length; i++)
            {
                draw(_SizeBoxLines[i]);
            }

            for (int i = 0; i < _AnchorLines.Length; i++)
            {
                draw(_AnchorLines[i]);
            }

            draw(_PositionBox);
        }

        private void UpdatePositionBox()
        {
            var mat = AnchorTransformerNode.Parent.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var offset
                    = ((AnchorTransformerNode.Parent?.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode)?.Size ?? default) * AnchorTransformerNode.AnchorMin;
            var vector2 = offset + AnchorTransformerNode.Position;
            var vector3 = mat.Transform3D(new Vector3F(vector2.X, vector2.Y, 0));
            SetPoint(_PositionBox, new Vector2F(vector3.X, vector3.Y), 8, new Color(255, 0, 0));
        }

        private void UpdateSizeBox()
        {
            var points = new Vector2F[4];

            var offset
                    = ((AnchorTransformerNode.Parent?.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode)?.Size ?? default) * AnchorTransformerNode.AnchorMin;
            var origin = -AnchorTransformerNode.CenterPosition;
            points[0] = origin;
            points[1] = origin + new Vector2F(AnchorTransformerNode.Size.X, 0);
            points[2] = origin + AnchorTransformerNode.Size;
            points[3] = origin + new Vector2F(0, AnchorTransformerNode.Size.Y);

            var mat = AnchorTransformerNode.Parent.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            mat = mat * Matrix44F.GetTranslation2D(offset + AnchorTransformerNode.Position) * Matrix44F.GetRotationZ(MathHelper.DegreeToRadian(AnchorTransformerNode.Angle));
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

        private void UpdateAnchor()
        {
            var points = new Vector2F[2];

            var offset
                    = ((AnchorTransformerNode.Parent?.GetAncestorSpecificNode<TransformNode>()?.Transfomer as AnchorTransformerNode)?.Size ?? default) * AnchorTransformerNode.AnchorMin;
            points[0] = -AnchorTransformerNode.Position;
            points[1] = AnchorTransformerNode.Size * (new Vector2F(1, 1) - AnchorTransformerNode.Pivot) + AnchorTransformerNode.RightBottom;

            var mat = AnchorTransformerNode.Parent.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            mat = mat * Matrix44F.GetTranslation2D(offset + AnchorTransformerNode.Position) * Matrix44F.GetRotationZ(MathHelper.DegreeToRadian(AnchorTransformerNode.Angle));

            var horizon = new Vector2F(-8, 0);
            var vertical = new Vector2F(0, -8);
            for (int i = 0; i < points.Length; i++)
            {
                var point1 = points[i] + horizon * MathF.Pow(-1, i);
                var point2 = points[i] + vertical * MathF.Pow(-1, i);

                var vector = mat.Transform3D(new Vector3F(points[i].X, points[i].Y, 0));
                points[i] = new Vector2F(vector.X, vector.Y);

                vector = mat.Transform3D(new Vector3F(point1.X, point1.Y, 0));
                point1 = new Vector2F(vector.X, vector.Y);

                vector = mat.Transform3D(new Vector3F(point2.X, point2.Y, 0));
                point2 = new Vector2F(vector.X, vector.Y);

                SetLine(_AnchorLines[i * 2], points[i], point1, new Color(255, 255, 255));
                SetLine(_AnchorLines[i * 2 + 1], points[i], point2, new Color(255, 255, 255));
            }
        }

        void SetLine(RenderedPolygon renderedPolygon, Vector2F point1, Vector2F point2, Color color)
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

        void SetPoint(RenderedPolygon renderedPolygon, Vector2F point, float size, Color color)
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
    }
}
