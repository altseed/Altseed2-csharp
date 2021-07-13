using System;

namespace Altseed2
{
    [Serializable]
    abstract class TransformNodeManipulator
    {
        protected TransformNode _TransformNode;

        internal TransformNodeManipulator(TransformNode transformNode)
        {
            _TransformNode = transformNode;
        }

        internal abstract void Update(Vector2F mousePosition);

        internal abstract void Draw();

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
            var vector3 = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(worldPosition.X, worldPosition.Y, 0)));
            return new Vector2F(vector3.X, vector3.Y);
        }

        internal protected void AdjustPosition(Vector2F referenceScreenPosition)
        {
            const float error = 0.0001f;

            var vec = (referenceScreenPosition - GetScreenPosition(_TransformNode.Position));

            if (vec.Length > error)
            {
                _TransformNode.Position = _TransformNode.Position + vec * new Vector2F(1, -1) * 100f;
            }
        }

        protected Vector2F GetScreenPosition(Vector3F worldPosition)
        {
            var vector3 = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(worldPosition));
            return new Vector2F(vector3.X, vector3.Y);
        }

        protected bool IsInPreviewWindow(Vector2F position)
        {
            return
                -1f <= position.X
                && position.X <= 1f
                && -1f <= position.Y
                && position.Y <= 1f;
        }
    }
}