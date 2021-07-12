using System;

namespace Altseed2.NodeEditor
{
    [Serializable]
    internal class ParallelMove
    {
        private TransformNode _TransformNode;
        private RenderedPolygon _XArrow, _YArrow;
        private RenderedPolygon _CenterBox;
        private Vector2F[] _XArrowHitBox = new Vector2F[4];
        private Vector2F[] _YArrowHitBox = new Vector2F[4];
        private PolygonCollider _Collider;

        private ControlState state = ControlState.none;
        private Vector2F _AdjustOffset = new Vector2F(0, 0);

        public Vector2F PositionInRenderedTexture { get { var vec = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(_TransformNode.CenterPosition.X, _TransformNode.CenterPosition.Y, 0)));  return new Vector2F(vec.X, vec.Y); } }

        

        internal ParallelMove(TransformNode tranfromNode)
        {
            _TransformNode = tranfromNode;
            _Collider = new PolygonCollider();

            _XArrow = RenderedPolygon.Create();
            _YArrow = RenderedPolygon.Create();
            _CenterBox = RenderedPolygon.Create();
        }

        internal void Input(Vector2F mousePosition)
        {
            var mouseLButton = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);

            switch (state)
            {
                case ControlState.none:
                    if (IsInPreviewWindow(mousePosition))
                    {
                        if(mouseLButton == ButtonState.Push)
                        {
                            if(MouseHit(mousePosition, _XArrow.Vertexes))
                            {
                                _AdjustOffset = mousePosition - GetScreenPosition(_TransformNode.Position);
                                state = ControlState.Xdrag;
                            }
                            else if(MouseHit(mousePosition, _YArrow.Vertexes))
                            {

                            }
                            else if(MouseHit(mousePosition, _CenterBox.Vertexes))
                            {

                            }
                        }
                    }
                    break;

                case ControlState.Xdrag:
                    if (mouseLButton == ButtonState.Release) state = ControlState.none;
                    AdjustPosition(new Vector2F(mousePosition.X, _TransformNode.Position.Y));
                    break;

                case ControlState.Ydrag:
                    break;

                case ControlState.FreeDrag:
                    break;
            }
        }

        private void AdjustPosition(Vector2F referenceScreenPosition)
        {
            const float error = 0.0001f;

            if (Engine.Tool.BeginMainMenuBar())
            {
                Engine.Tool.Text("moving");
                Engine.Tool.Text("offset =>" + _AdjustOffset.ToString());
                //Engine.Tool.Text(Engine._DefaultCamera.ProjectionMatrix.Inverse.Transform3D(Engine._DefaultCamera.ViewMatrix.Inverse.Transform3D(new Vector3F(referenceScreenPosition.X, referenceScreenPosition.Y, 0))).ToString());
                Engine.Tool.EndMainMenuBar();
            }

            var vec = (GetScreenPosition(_TransformNode.Position) - referenceScreenPosition + _AdjustOffset);

            if (vec.Length > error)
            {
                _TransformNode.Position = _TransformNode.Position + new Vector2F(-100000f, 0f) * vec / vec.Length;
            }
        }

        internal void Update(Vector2F mousePosition)
        {
            Input(mousePosition);

            UpdateArrow(mousePosition);
            UpdateCenterBox();


            
            var position = GetScreenPosition(_TransformNode.Position);

            if (Engine.Tool.BeginMainMenuBar())
            {
                Engine.Tool.Text("TrNd" + position);
                Engine.Tool.EndMainMenuBar();
            }
        }

        private void UpdateArrow(Vector2F mousepos)
        {

            var mat = _TransformNode.GetAncestorSpecificNode<TransformerNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));

            var length = 300;

            Color xColor = new Color(255, 255, 255), yColor = new Color(255, 255, 255);

            if (MouseHit(mousepos, _XArrow.Vertexes))
            {
                xColor = new Color(255, 0, 0);

                var vec = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0)));
                if (Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Hold)
                {
                    //_TransformNode.Position = new Vector2F(_TransformNode.Position.X+10*(mousepos - new Vector2F(vec.X,vec.Y)).X, _TransformNode.Position.Y);
                }
            }
            if (MouseHit(mousepos, _YArrow.Vertexes))
            {
                yColor = new Color(0, 0, 255);
            }

            //_XArrowHitBox = _XArrow.Vertexes;
            //_YArrowHitBox = _YArrow.Vertexes;

            SetArrow(_XArrow, new Vector2F(pos.X, pos.Y), new Vector2F(1, 0) * length, xColor);
            SetArrow(_YArrow, new Vector2F(pos.X, pos.Y), new Vector2F(0, 1) * length, yColor);
        }

        private void UpdateCenterBox()
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformerNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            SetBox(_CenterBox, new Vector2F(pos.X, pos.Y), new Vector2F(8, 8), new Color(100, 100, 100));
        }



        private void SetArrow(RenderedPolygon renderedPolygon, Vector2F rootPosition, Vector2F vector, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[4];

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

        private void SetBox(RenderedPolygon renderedPolygon, Vector2F position, Vector2F size, Color color)
        {
            Span<Vector2F> points = stackalloc Vector2F[4];
            points[0] = position + new Vector2F(-1f, -1f) * size / 2f;
            points[1] = position + new Vector2F(1f, -1f) * size / 2f;
            points[2] = position + new Vector2F(1f, 1f) * size / 2f;
            points[3] = position + new Vector2F(-1f, 1f) * size / 2f;

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

            draw(_XArrow);
            draw(_YArrow);
            draw(_CenterBox);
        }

        private bool MouseHit(Vector2F pos, VertexArray vertices)
        {
            Vector2F[] screenPosition = new Vector2F[vertices.Count];
            for(int i = 0;i < screenPosition.Length;i++)
            {
                screenPosition[i] = GetScreenPosition(vertices[i].Position);
            }



            _Collider.Vertexes = screenPosition;

            var mouseCollider = new CircleCollider();
            mouseCollider.Radius = 0f;
            mouseCollider.Position = pos;

            return _Collider.GetIsCollidedWith(mouseCollider);
        }

        private Vector2F GetScreenPosition(Vector2F worldPosition)
        {
            var vector3 = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(worldPosition.X, worldPosition.Y, 0)));
            return new Vector2F(vector3.X, vector3.Y);
        }

        private Vector2F GetScreenPosition(Vector3F worldPosition)
        {
            var vector3 = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(worldPosition.X, worldPosition.Y, worldPosition.Z)));
            return new Vector2F(vector3.X, vector3.Y);
        }

        private bool IsInPreviewWindow(Vector2F position)
        {
            return
                -1f <= position.X
                && position.X <= 1f
                && -1f <= position.Y
                && position.Y <= 1f;
        }

        enum ControlState { none, Xdrag, Ydrag, FreeDrag}
    }

}
