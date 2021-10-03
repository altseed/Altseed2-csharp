using System;

namespace Altseed2.NodeEditor
{
    [Serializable]
    abstract class TransformNodeManipulator
    {
        protected TransformNode _TransformNode;
        protected RenderedCamera _Camera;

        internal protected TransformNodeManipulator(TransformNode transformNode, RenderedCamera EditorCamera)
        {
            _TransformNode = transformNode;
            _Camera = EditorCamera; 
        }

        internal abstract void Update(Vector2F mousePosition);

        internal abstract void Draw();

        internal abstract bool Input(Vector2F mousePosition);


        internal protected bool MouseHit(Vector2F pos, VertexArray vertices)
        {
            Vector2F[] screenPosition = new Vector2F[vertices.Count];
            for (int i = 0; i < screenPosition.Length; i++)
            {
                screenPosition[i] = GetScreenPosition(vertices[i].Position);
            }

            var collider = new PolygonCollider();
            collider.Vertexes = screenPosition;

            var mouseCollider = new CircleCollider();
            mouseCollider.Radius = 0f;
            mouseCollider.Position = pos;

            return collider.GetIsCollidedWith(mouseCollider);
        }

        protected Vector2F GetScreenPosition(Vector2F worldPosition)
        {
            var vector3 = _Camera.ProjectionMatrix.Transform3D(_Camera.ViewMatrix.Transform3D(new Vector3F(worldPosition.X, worldPosition.Y, 0)));
            return new Vector2F(vector3.X, vector3.Y);
        }


        protected Vector2F GetScreenPosition(Vector3F worldPosition)
        {
            var vector3 = _Camera.ProjectionMatrix.Transform3D(_Camera.ViewMatrix.Transform3D(worldPosition));
            return new Vector2F(vector3.X, vector3.Y);
        }


        internal protected void SetLine(RenderedPolygon renderedPolygon, Vector2F rootPosition, Vector2F vector,float width, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[4];

            var side = new Vector2F(vector.Y, -vector.X).Normal * width;

            points[0] = rootPosition - side;
            points[1] = rootPosition + side;
            points[2] = rootPosition + vector + side;
            points[3] = rootPosition + vector - side;

            Engine.Vector2FArrayCache.FromSpan(points);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        internal protected void SetBox(RenderedPolygon renderedPolygon, Vector2F position, Vector2F direction,Vector2F size, Color color)
        {
            var angle = direction / direction.Length;
            var parpendicular = new Vector2F(-angle.Y, angle.X);

            Span<Vector2F> points = stackalloc Vector2F[4];
            points[0] = position + angle * size / 2f + parpendicular * size / 2f;
            points[1] = position + angle * size / 2f - parpendicular * size / 2f;
            points[2] = position - angle * size / 2f - parpendicular * size / 2f;
            points[3] = position - angle * size / 2f + parpendicular * size / 2f;

            Engine.Vector2FArrayCache.FromSpan(points);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        internal protected void SetRing(RenderedPolygon[] renderedPolygon, Vector2F position, float radius, float width, Color color)
        {
            int smoothness = renderedPolygon.Length;
            for (int i = 0;i < smoothness; i++)
            {
                Span<Vector2F> points = stackalloc Vector2F[4];
                float angle = (MathF.PI * 2f / smoothness);
                
                float x1 = MathF.Cos(angle * (i + 0.5f));
                float y1 = MathF.Sin(angle * (i + 0.5f));
                float x2 = MathF.Cos(angle * (i - 0.5f));
                float y2 = MathF.Sin(angle * (i - 0.5f));

                points[0] = position + new Vector2F(x1, y1) * (radius + width / 2f);
                points[1] = position + new Vector2F(x1, y1) * (radius - width / 2f);
                points[2] = position + new Vector2F(x2, y2) * (radius - width / 2f);
                points[3] = position + new Vector2F(x2, y2) * (radius + width / 2f);
                
                Engine.Vector2FArrayCache.FromSpan(points);
                renderedPolygon[i].CreateVertexesByVector2F(Engine.Vector2FArrayCache);
                renderedPolygon[i].OverwriteVertexesColor(color);
                renderedPolygon[i].SetDefaultIndexBuffer();
            }

        }

        internal protected void SetTriangle(RenderedPolygon renderedPolygon, Vector2F centerPosition, Vector2F point1, Vector2F point2, Vector2F point3, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[3];
            points[0] = centerPosition + point1;
            points[1] = centerPosition + point2;
            points[2] = centerPosition + point3;

            Engine.Vector2FArrayCache.FromSpan(points);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        internal protected void SetArrow(RenderedPolygon renderedPolygon, Vector2F rootPosition, Vector2F headPosition, float wedge, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[4];

            var vector = headPosition - rootPosition;

            var side = new Vector2F(vector.Y, -vector.X).Normal * 2;

            points[0] = rootPosition - side;
            points[1] = rootPosition + side;
            points[2] = rootPosition + vector + side;
            points[3] = rootPosition + vector - side;

            

            Engine.Vector2FArrayCache.FromSpan(points);
            renderedPolygon.CreateVertexesByVector2F(Engine.Vector2FArrayCache);
            renderedPolygon.OverwriteVertexesColor(color);
            renderedPolygon.SetDefaultIndexBuffer();
        }

        protected bool IsInPreviewWindow(Vector2F position)
        {
            return
                -1f <= position.X
                && position.X <= 1f
                && -1f <= position.Y
                && position.Y <= 1f;
        }

        internal void SetManipulatee(TransformNode transformNode)
        {
            _TransformNode = transformNode;
        }
    }
}