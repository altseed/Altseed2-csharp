using System;

namespace Altseed2.NodeEditor
{
    internal class Rotate : TransformNodeManipulator
    {
        private RenderedPolygon[] _Ring;
        private ControlState _ControlState = ControlState.none;
        private Vector2F _StartVector;
        private float _BeforeAngle;

        internal Rotate(TransformNode transformNode) : base(transformNode)
        {
            int ringSmoothness = 50;
            _Ring = new RenderedPolygon[ringSmoothness];
            for(int i = 0;i < _Ring.Length;i++)
            {
                _Ring[i] = RenderedPolygon.Create();
            }
        }

        internal override void Update(Vector2F mousePosition)
        {
            UpdateCircle(mousePosition);
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
                            var _mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
                            var _pos = _mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));

                            _StartVector = mousePosition - GetScreenPosition(_pos);
                            _BeforeAngle = _TransformNode.Angle;

                            bool CheckMouseHit(RenderedPolygon polygon)
                            {
                                if (MouseHit(mousePosition, polygon.Vertexes))
                                {
                                    _ControlState = ControlState.drag;
                                    return true;
                                }
                                return false;
                            }

                            foreach(var ringPart in _Ring)
                            {
                                if (CheckMouseHit(ringPart)) return true;
                            }
                        }
                    }
                    return false;

                case ControlState.drag:
                    if (mouseLButton == ButtonState.Release)
                    {
                        _ControlState = ControlState.none;
                        return false;
                    }

                    var mat = _TransformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
                    var pos = mat.Transform3D(new Vector3F(_TransformNode.Position.X, _TransformNode.Position.Y, 0));
                    var currentVector = mousePosition - GetScreenPosition(pos);
                    var angle =( -60f * (MathF.Atan((-_StartVector.Y / _StartVector.X + currentVector.Y / currentVector.X) / (1 + _StartVector.Y / _StartVector.X * currentVector.Y / currentVector.X))) )% 360;
                    
                    RotateTarget(angle);
            
                    _StartVector = currentVector;
                    return true;

                default:
                    return false;
            }
        }

        private void UpdateCircle(Vector2F mousePosition)
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

            var scale = Engine._DefaultCamera.ViewMatrix[1, 1] * Engine._DefaultCamera.ViewMatrix[2, 2];
            var length = 200 / scale;

            Color color = new Color(0, 255, 0);

            if (_ControlState == ControlState.drag)
            {
                color = new Color(255, 255, 255);
            }

            foreach (var ringPart in _Ring)
            {
                if (MouseHit(mousePosition, ringPart.Vertexes))
                {
                    color = new Color(255, 255, 255);
                    break;
                }
            }

            SetRing(_Ring, new Vector2F(pos.X, pos.Y), length, length * 0.015f, color);
        }

        internal override void Draw()
        {
            void draw(RenderedPolygon renderedPolygon)
            {
                Engine.Renderer.DrawPolygon(renderedPolygon);
            }

            foreach (var part in _Ring) draw(part);
        }

        private void RotateTarget(float angle)
        {
            _TransformNode.Angle += angle;
        }

        enum ControlState
        {
            none,
            drag,
        }
    }
}
