using System;

namespace Altseed2.NodeEditor
{
    [Serializable]
    internal class ParallelMove : TransformNodeManipulator
    {
        private RenderedPolygon _XArrow, _YArrow;
        private RenderedPolygon _CenterBox;

        private ControlState _ControlState = ControlState.none;
        private Vector2F _AdjustOffset = new Vector2F(0, 0);

        public Vector2F PositionInRenderedTexture { get { var vec = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(new Vector3F(_TransformNode.CenterPosition.X, _TransformNode.CenterPosition.Y, 0)));  return new Vector2F(vec.X, vec.Y); } }

        internal ParallelMove(TransformNode transformNode) : base (transformNode)
        {
            _XArrow = RenderedPolygon.Create();
            _YArrow = RenderedPolygon.Create();
            _CenterBox = RenderedPolygon.Create();
        }

        internal override void Update(Vector2F mousePosition)
        {
            Input(mousePosition);

            UpdateArrow(mousePosition);
            UpdateCenterBox();
        }

        private void Input(Vector2F mousePosition)
        {
            var mouseLButton = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);

            switch (_ControlState)
            {
                case ControlState.none:
                    if (IsInPreviewWindow(mousePosition))
                    {
                        if (mouseLButton == ButtonState.Push)
                        {
                            _AdjustOffset = mousePosition - GetScreenPosition(_TransformNode.Position);

                            if (MouseHit(mousePosition, _CenterBox.Vertexes) || (MouseHit(mousePosition, _XArrow.Vertexes) && MouseHit(mousePosition, _YArrow.Vertexes)))
                            {
                                _ControlState = ControlState.FreeDrag;
                            }
                            else if (MouseHit(mousePosition, _XArrow.Vertexes))
                            {
                                _ControlState = ControlState.Xdrag;
                            }
                            else if (MouseHit(mousePosition, _YArrow.Vertexes))
                            {
                                _ControlState = ControlState.Ydrag;
                            }
                        }
                    }
                    break;

                case ControlState.Xdrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(new Vector2F(mousePosition.X - _AdjustOffset.X, GetScreenPosition(_TransformNode.Position).Y));
                    break;

                case ControlState.Ydrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(new Vector2F(GetScreenPosition(_TransformNode.Position).X, mousePosition.Y - _AdjustOffset.Y));
                    break;

                case ControlState.FreeDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(mousePosition - _AdjustOffset);
                    break;
            }
        }

        private void UpdateArrow(Vector2F mousePosition)
        {

            var mat = _TransformNode.GetAncestorSpecificNode<TransformerNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));

            var length = 300;

            Color xColor = new Color(255, 255, 255), yColor = new Color(255, 255, 255);

            if ((MouseHit(mousePosition, _XArrow.Vertexes) || _ControlState == ControlState.Xdrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.Ydrag)
            {
                xColor = new Color(255, 0, 0);

            }
            if ((MouseHit(mousePosition, _YArrow.Vertexes) || _ControlState == ControlState.Ydrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.Xdrag)
            {
                yColor = new Color(0, 0, 255);
            }

            SetLine(_XArrow, new Vector2F(pos.X, pos.Y), new Vector2F(1, 0) * length, xColor);
            SetLine(_YArrow, new Vector2F(pos.X, pos.Y), new Vector2F(0, 1) * length, yColor);
        }

        private void UpdateCenterBox()
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformerNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            SetBox(_CenterBox, new Vector2F(pos.X, pos.Y), new Vector2F(8, 8), new Color(100, 100, 100));
        }




        internal override void Draw()
        {
            void draw(RenderedPolygon renderedPolygon)
            {
                Engine.Renderer.DrawPolygon(renderedPolygon);
            };

            draw(_XArrow);
            draw(_YArrow);
            draw(_CenterBox);
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
        enum ControlState { none, Xdrag, Ydrag, FreeDrag}
    }

}
