using System.Collections.Generic;

namespace Altseed2.NodeEditor
{
    internal class ParallelMove : TransformNodeManipulator
    {
        List<RenderedPolygon> _drawns;

        private RenderedPolygon _XArrowLine, _YArrowLine, _XArrowTriangle, _YArrowTriangle;
        private RenderedPolygon _CenterBox;

        private ControlState _ControlState = ControlState.none;
        private Vector2F _AdjustOffset = new Vector2F(0, 0);

        internal ParallelMove(TransformNode transformNode, RenderedCamera editorCamera, List<RenderedPolygon> drawns) : base (transformNode, editorCamera )
        {
            _XArrowLine = RenderedPolygon.Create();
            _YArrowLine = RenderedPolygon.Create();
            _XArrowTriangle = RenderedPolygon.Create();
            _YArrowTriangle = RenderedPolygon.Create();
            _CenterBox = RenderedPolygon.Create();

            _drawns = drawns;

            void draw(RenderedPolygon renderedPolygon)
            {
                _drawns.Add(renderedPolygon);
            };

            draw(_XArrowLine);
            draw(_YArrowLine);
            draw(_XArrowTriangle);
            draw(_YArrowTriangle);
            draw(_CenterBox);
        }

        internal override void Update(Vector2F mousePosition)
        {
            UpdateArrow(mousePosition);
            UpdateCenterBox();
        }

        internal override bool Input(Vector2F mousePosition)
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
                            if (MouseHit(mousePosition, _CenterBox.Vertexes) || (MouseHit(mousePosition, _XArrowLine.Vertexes) && MouseHit(mousePosition, _YArrowLine.Vertexes)))
                            {
                                _ControlState = ControlState.FreeDrag;
                                return true;
                            }
                            else if (MouseHit(mousePosition, _XArrowLine.Vertexes))
                            {
                                _ControlState = ControlState.Xdrag;
                                return true;
                            }
                            else if (MouseHit(mousePosition, _YArrowLine.Vertexes))
                            {
                                _ControlState = ControlState.Ydrag;
                                return true;
                            }
                        }
                    }
                    return false;

                case ControlState.Xdrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(new Vector2F(mousePosition.X - _AdjustOffset.X, GetScreenPosition(_TransformNode.Position).Y));
                    return true;

                case ControlState.Ydrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(new Vector2F(GetScreenPosition(_TransformNode.Position).X, mousePosition.Y - _AdjustOffset.Y));
                    return true;

                case ControlState.FreeDrag:
                    if (mouseLButton == ButtonState.Release) _ControlState = ControlState.none;
                    AdjustPosition(mousePosition - _AdjustOffset);
                    return true;

                default:
                    return false;
            }
        }

        private void UpdateArrow(Vector2F mousePosition)
        {

            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;

            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            foreach(var child in _TransformNode.Children)
            {
                if(child is TransformerNode)
                {
                    pos = _TransformNode.AbsoluteTransform.Transform3D(pos);
                    break;
                }
            }

            var scale = Engine._DefaultCamera.ViewMatrix[1, 1] * Engine._DefaultCamera.ViewMatrix[2, 2];
            var length = 300 / scale;

            Color xColor = new Color(255, 0, 0), yColor = new Color(0, 0, 255);

            if ((MouseHit(mousePosition, _XArrowLine.Vertexes) || _ControlState == ControlState.Xdrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.Ydrag)
            {
                xColor = new Color(255, 255, 255);
            }
            if ((MouseHit(mousePosition, _YArrowLine.Vertexes) || _ControlState == ControlState.Ydrag || _ControlState == ControlState.FreeDrag) && _ControlState != ControlState.Xdrag)
            {
                yColor = new Color(255, 255, 255);
            }

            SetLine(_XArrowLine, new Vector2F(pos.X, pos.Y), new Vector2F(1, 0) * length, length / 150, xColor);
            SetTriangle(_XArrowTriangle, new Vector2F(pos.X, pos.Y) + new Vector2F(1, 0) * length, new Vector2F(length * 0.1f, 0), new Vector2F(0, length * 0.06f), new Vector2F(0, -length * 0.06f), xColor);
            
            SetLine(_YArrowLine, new Vector2F(pos.X, pos.Y), new Vector2F(0, 1) * length, length / 150, yColor);
            SetTriangle(_YArrowTriangle, new Vector2F(pos.X, pos.Y) + new Vector2F(0, 1) * length, new Vector2F(0, length * 0.1f), new Vector2F(length * 0.06f, 0), new Vector2F(-length * 0.06f, 0), yColor);
        }

        private void UpdateCenterBox()
        {
            var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
            foreach (var child in _TransformNode.Children)
            {
                if (child is TransformerNode)
                {
                    pos = _TransformNode.AbsoluteTransform.Transform3D(pos);
                    break;
                }
            }

            SetBox(_CenterBox, new Vector2F(pos.X, pos.Y), new Vector2F(1, 0), new Vector2F(8, 8), new Color(100, 100, 100));
        }




        internal override void Draw()
        {
            
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
