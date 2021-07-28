namespace Altseed2.NodeEditor
{
    class Scale : TransformNodeManipulator
    {
        private RenderedPolygon _XArrowLine, _YArrowLine, _XArrowHead, _YArrowHead;
        private RenderedPolygon _CenterBox;

        private ControlState _ControlState = ControlState.none;
        private Vector2F _MousePositionBasis = new Vector2F(0, 0);

        internal Scale(TransformNode transformNode) : base(transformNode)
        {
            _XArrowLine = RenderedPolygon.Create();
            _YArrowLine = RenderedPolygon.Create();
            _XArrowHead = RenderedPolygon.Create();
            _YArrowHead = RenderedPolygon.Create();
            _CenterBox = RenderedPolygon.Create();
        }

        internal override void Update(Vector2F mousePosition)
        {
            UpdateArrow(mousePosition);
            UpdateCenterBox(mousePosition);
        }

        internal override bool Input(Vector2F mousePosition)
        {
            var mouseLButton = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);

            switch (_ControlState)
            {
                case ControlState.none:
                    if (IsInPreviewWindow(mousePosition))
                    {
                        if(mouseLButton == ButtonState.Push)
                        {
                            _MousePositionBasis = mousePosition;
                            if(MouseHit(mousePosition, _CenterBox.Vertexes) || (MouseHit(mousePosition, _XArrowLine.Vertexes) && MouseHit(mousePosition, _YArrowLine.Vertexes)))
                            {
                                _ControlState = ControlState.FreeDrag;
                                return true;
                            }
                            else if(MouseHit(mousePosition, _XArrowLine.Vertexes))
                            {
                                _ControlState = ControlState.XDrag;
                                return true;
                            }
                            else if(MouseHit(mousePosition, _YArrowLine.Vertexes))
                            {
                                _ControlState = ControlState.YDrag;
                                return true;
                            }
                        }
                    }
                    return false ;
                case ControlState.XDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustScale(new Vector2F(mousePosition.X - _MousePositionBasis.X, 0));
                    _MousePositionBasis = mousePosition;
                    return true;
                case ControlState.YDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustScale(new Vector2F(0, mousePosition.Y - _MousePositionBasis.Y));
                    _MousePositionBasis = mousePosition;
                    return true;
                case ControlState.FreeDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustScale(mousePosition - _MousePositionBasis);
                    _MousePositionBasis = mousePosition;
                    return true;
                default:
                    return true;
            }
        }

        private void AdjustScale(Vector2F difference)
        {
            const float error = 0.0001f;
            const float speed = 2.0f;

            if(difference.Length > error)
            {
                _TransformNode.Scale += difference * new Vector2F(1f, -1f) * speed;
            }
        }

        private void UpdateArrow(Vector2F mousePosition)
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));

            var scale = Engine._DefaultCamera.ViewMatrix[1, 1] * Engine._DefaultCamera.ViewMatrix[2, 2];
            var length = 300 / scale;

            Color xColor = new Color(255, 255, 255), yColor = new Color(255, 255, 255);

            if((MouseHit(mousePosition, _XArrowLine.Vertexes) || _ControlState == ControlState.XDrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.YDrag)
            {
                xColor = new Color(255, 0, 0);
            }
            if ((MouseHit(mousePosition, _YArrowLine.Vertexes) || _ControlState == ControlState.YDrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.XDrag)
            {
                yColor = new Color(0, 0, 255);
            }

            SetLine(_XArrowLine, new Vector2F(pos.X, pos.Y), new Vector2F(1f, 0f) * length, length / 150, xColor);
            SetBox(_XArrowHead, new Vector2F(pos.X, pos.Y) + new Vector2F(1, 0) * length, new Vector2F(1, 1) * length * 0.05f, xColor);
            SetLine(_YArrowLine, new Vector2F(pos.X, pos.Y), new Vector2F(0f, 1f) * length, length / 150, yColor);
            SetBox(_YArrowHead, new Vector2F(pos.X, pos.Y) + new Vector2F(0, 1) * length, new Vector2F(1, 1) * length * 0.05f, yColor);
        }

        private void UpdateCenterBox(Vector2F mousePosition)
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            SetBox(_CenterBox, new Vector2F(pos.X, pos.Y), new Vector2F(8, 8), new Color(100, 100, 100));
        }

        internal override void Draw()
        {
            void draw(RenderedPolygon renderedPolygon)
            {
                Engine.Renderer.DrawPolygon(renderedPolygon);
            };

            draw(_XArrowLine);
            draw(_YArrowLine);
            draw(_XArrowHead);
            draw(_YArrowHead);
            draw(_CenterBox);
        }

        enum ControlState
        {
            none, XDrag, YDrag, FreeDrag
        }
    }
}
