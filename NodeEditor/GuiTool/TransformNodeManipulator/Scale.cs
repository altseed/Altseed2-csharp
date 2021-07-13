namespace Altseed2.NodeEditor
{
    class Scale : TransformNodeManipulator
    {
        private RenderedPolygon _XArrow, _YArrow;
        private RenderedPolygon _CenterBox;

        private ControlState _ControlState = ControlState.none;
        private Vector2F _AdjustOffset = new Vector2F(0, 0);

        internal Scale(TransformNode transformNode) : base(transformNode)
        {
            _XArrow = RenderedPolygon.Create();
            _YArrow = RenderedPolygon.Create();
            _CenterBox = RenderedPolygon.Create();
        }

        internal override void Update(Vector2F mousePosition)
        {
            Input(mousePosition);

            UpdateArrow(mousePosition);
            UpdateCenterBox(mousePosition);
        }

        private void Input(Vector2F mousePosition)
        {
            var mouseLButton = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);

            switch (_ControlState)
            {
                case ControlState.none:
                    if (IsInPreviewWindow(mousePosition))
                    {
                        if(mouseLButton == ButtonState.Push)
                        {
                            _AdjustOffset = mousePosition - GetScreenPosition(_TransformNode.Position);

                            if(MouseHit(mousePosition, _CenterBox.Vertexes) || (MouseHit(mousePosition, _XArrow.Vertexes) && MouseHit(mousePosition, _YArrow.Vertexes)))
                            {
                                _ControlState = ControlState.FreeDrag;
                            }
                            else if(MouseHit(mousePosition, _XArrow.Vertexes))
                            {
                                _ControlState = ControlState.XDrag;
                            }
                            else if(MouseHit(mousePosition, _YArrow.Vertexes))
                            {
                                _ControlState = ControlState.YDrag;
                            }
                        }
                    }
                    break;
                case ControlState.XDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    break;
                case ControlState.YDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    break;
                case ControlState.FreeDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    break;
            }
        }

        private void UpdateArrow(Vector2F mousePosition)
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformerNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));

            var length = 300;

            Color xColor = new Color(255, 255, 255), yColor = new Color(255, 255, 255);

            if((MouseHit(mousePosition, _XArrow.Vertexes) || _ControlState == ControlState.XDrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.YDrag)
            {
                xColor = new Color(255, 0, 0);
            }
            if ((MouseHit(mousePosition, _YArrow.Vertexes) || _ControlState == ControlState.YDrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.XDrag)
            {
                yColor = new Color(0, 0, 255);
            }

            SetLine(_XArrow, new Vector2F(pos.X, pos.Y), new Vector2F(1f, 0f) * length, xColor);
            SetLine(_YArrow, new Vector2F(pos.X, pos.Y), new Vector2F(0f, 1f) * length, yColor);
        }

        private void UpdateCenterBox(Vector2F mousePosition)
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

        enum ControlState
        {
            none, XDrag, YDrag, FreeDrag
        }
    }
}
