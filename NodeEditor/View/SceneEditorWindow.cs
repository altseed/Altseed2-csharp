using Altseed2.NodeEditor.ViewModel;
using System.Reactive;
using System.Reactive.Subjects;
using System;
using System.Collections.Generic;

namespace Altseed2.NodeEditor.View
{
    internal sealed class SceneEditorWindow : IDisposable
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly SceneEditorViewModel _viewModel;
        private readonly NodeEditorPane _pane = new NodeEditorPane("EditWindow");


        private readonly IDisposable _subscription;
        private TransformNodeManipulator _manipulator;
        private MouseControlState _MouseControlState;
        private Vector2F _StartPoint;

        private Vector2I _latestWindowSize = Engine.WindowSize;

        private Texture2D _parallelMoveIcon;
        private Texture2D _scaleIcon;
        private Texture2D _rotateIcon;
        private Color _unavailableIconColor = new Color(100, 100, 100);
        private Color _availableIconColor = new Color(255, 255, 255);

        private RenderedCamera _camera;
        private List<RenderedPolygon> _manipulatorPolygon;

        public SceneEditorWindow(IEditorPropertyAccessor accessor, SceneEditorViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;

            _camera = RenderedCamera.Create();
            _manipulatorPolygon = new();

            _camera.ViewMatrix = Matrix44F.GetTranslation2D(-Engine.WindowSize / 2);
            _camera.RenderPassParameter = new RenderPassParameter( new Color(50, 50, 50), true, true);

            _viewModel.Camera = _camera;

            _viewModel.UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize, TextureFormat.R8G8B8A8_UNORM));

            _camera.RenderPassParameter = new RenderPassParameter(new Color(50, 50, 0), true, true);

            _subscription = accessor.OnSelectedNodeChanged.Subscribe(_ => ChangeManipulatee(accessor.Selected as TransformNode));

            _parallelMoveIcon = Texture2D.Load(@"GUIAsset/ParallelMove.png");
            _scaleIcon = Texture2D.Load(@"GUIAsset/Scale.png");
            _rotateIcon = Texture2D.Load(@"GUIAsset/Rotate.png");
        }

        private void ChangeManipulatee(TransformNode? target)
        {
            if (target != null)
            {
                _manipulator?.SetManipulatee(target);
            }
            else
            {
                _manipulator = null;
            }
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        public void Render()
        {

            Engine.Tool.PushStyleVar(ToolStyleVar.WindowPadding, new Vector2F());

            var mousePosition = _viewModel.MousePosition;

            MouseInput(mousePosition);
            _manipulator?.Update(mousePosition);
            _manipulator?.Draw();

            RenderTransformNodeManipulatorMenu();

            _pane.Render(() =>
            {
                AdjustWindowSize();
                _viewModel.IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocusedFlags.None);

                _viewModel.MousePosition = GetMousePositionInPreiewWindow();

                Engine.DrawCameraGroup(_camera, Engine._DrawnCollection.GetDrawns());
                foreach (var drawn in _manipulatorPolygon)
                    Engine.Renderer.DrawPolygon(drawn);

                Engine.Renderer.Render();

                Engine.Tool.Image(_viewModel.Main, _viewModel.Main.Size, default,
                    new Vector2F(1, 1), new Color(255, 255, 255), new Color());

            }, ToolWindowFlags.NoScrollbar);

            Engine.Tool.PopStyleVar(1);
        }

        private void MouseInput(Vector2F MousePosition)
        {
            if (_manipulator?.Input(MousePosition) ?? false)
            {
                _MouseControlState = MouseControlState.ControlManipulator;
                return;
            }

            if (_MouseControlState == MouseControlState.ControlManipulator) _MouseControlState = MouseControlState.none;

            void CheckMouseClick(Node node)
            {
                if (node is TransformNode)
                {
                    var transformNode = node as TransformNode;

                    var mat = transformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
                    var pos = mat.Transform3D(new Vector3F(transformNode.Position.X, transformNode.Position.Y, 0));

                    bool HasAnchorNode(TransformNode target)
                    {
                        foreach (var childNode in target.Children)
                        {
                            if (childNode is TransformerNode) return true;
                        }
                        return false;
                    }

                    if (HasAnchorNode(transformNode))
                    {
                        pos = transformNode.AbsoluteTransform.Transform3D(pos);
                    }

                    var pos2d = new Vector2F(pos.X, pos.Y);

                    var upperRight = pos2d - transformNode.CenterPosition;
                    var lowerLeft = upperRight + transformNode.ContentSize;

                    Vector2F[] rect = new Vector2F[4];
                    rect[0] = GetScreenPosition(new Vector3F(upperRight.X, upperRight.Y, transformNode is SpriteNode ? (transformNode as SpriteNode).ZOrder : 0));
                    rect[1] = GetScreenPosition(new Vector3F(upperRight.X, lowerLeft.Y, transformNode is SpriteNode ? (transformNode as SpriteNode).ZOrder : 0));
                    rect[2] = GetScreenPosition(new Vector3F(lowerLeft.X, lowerLeft.Y, transformNode is SpriteNode ? (transformNode as SpriteNode).ZOrder : 0));
                    rect[3] = GetScreenPosition(new Vector3F(lowerLeft.X, upperRight.Y, transformNode is SpriteNode ? (transformNode as SpriteNode).ZOrder : 0));

                    if (MouseHit(MousePosition, rect) && Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Push && IsInPreviewWindow(MousePosition))
                    {
                        _accessor.Selected = transformNode;
                        return;
                    }
                }

                foreach (var child in node.Children)
                {
                    CheckMouseClick(child);
                }
            }

            foreach (var node in Engine.GetNodes()) CheckMouseClick(node);

            if (IsInPreviewWindow(MousePosition) && _MouseControlState == MouseControlState.none && Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Push)
            {
                _StartPoint = MousePosition;
                _MouseControlState = MouseControlState.CameraDrag;

                //ToDo カーソルのテクスチャをドラッグしてるかんじに変更できるように
                Engine.Mouse.CursorMode = CursorMode.Normal;
            }

            if (_MouseControlState == MouseControlState.CameraDrag && Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Release)
            {
                _MouseControlState = MouseControlState.none;
                Engine.Mouse.CursorMode = CursorMode.Normal;
            }

            if (_MouseControlState == MouseControlState.CameraDrag)
            {
                const float error = 0.0001f;

                var vec = (_StartPoint - MousePosition);

                if (vec.Length > error)
                {
                    _camera.ViewMatrix = Matrix44F.GetTranslation2D(vec * new Vector2F(-1, 1) * 300f) * _camera.ViewMatrix;
                }
                _StartPoint = MousePosition;
            }

            if (IsInPreviewWindow(MousePosition))
            {
                var wheelState = Engine.Mouse.Wheel;
                _camera.ViewMatrix = Matrix44F.GetScale2D(new Vector2F(1, 1) * (1 + wheelState * 0.25f)) * _camera.ViewMatrix;
            }
        }

        private void AdjustWindowSize()
        {
            if (_latestWindowSize != Engine.Tool.GetWindowSize().To2I())
            {
                Vector2I texSize = Engine.Tool.GetWindowSize().To2I();

                _viewModel.UpdateRenderTexture(texSize.X > 0 && texSize.Y > 0,
                    RenderTexture.Create(texSize, TextureFormat.R8G8B8A8_UNORM));

                _latestWindowSize = texSize;
            }
        }

        private Vector2F GetMousePositionInPreiewWindow()
        {
            var Position0to2 = Engine.Mouse.Position + EditorWindowPosition() - (Engine.Tool.GetWindowContentRegionMin() + Engine.Tool.GetWindowPos());
            return new Vector2F((float)(Position0to2.X / _viewModel.Main.Size.X) * 2f - 1f, -((float)(Position0to2.Y / _viewModel.Main.Size.Y) * 2f - 1f));
        }

        private void FindTransformNode(TransformNode target)
        {
            if (!target.IsRegistered) return;

            var mat = target.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
            var worldPosition = mat.Transform3D(new Vector3F(target.Position.X, target.Position.Y, 0));

            var pos2d = new Vector2F(worldPosition.X, worldPosition.Y);

            _camera.ViewMatrix = Matrix44F.GetTranslation2D(-pos2d);
        }

        private Vector2F EditorWindowPosition()
        {
            var pos = new Vector2F(0, 0);
            if (Engine.Tool.BeginMainMenuBar())
            {
                pos = Engine.Tool.GetWindowPos();
                Engine.Tool.EndMainMenuBar();
            }
            return pos;
        }

        private void RenderTransformNodeManipulatorMenu()
        {
            if (Engine.Tool.BeginMainMenuBar())
            {
                var selectedTransformNode = _accessor.Selected is TransformNode;
                var IconColor = selectedTransformNode ? _availableIconColor : _unavailableIconColor;

                if (Engine.Tool.MenuItem("VisibleTransformNodeInfo", "", Engine.Config.VisibleTransformInfo, selectedTransformNode))
                {
                    Engine.Config.VisibleTransformInfo = !Engine.Config.VisibleTransformInfo;
                }

                if (Engine.Tool.ImageButton(_parallelMoveIcon, new Vector2F(17, 17), new Vector2F(0, 0), new Vector2F(1, 1), 0, new Color(36, 36, 36), IconColor))
                {
                    if (selectedTransformNode)
                    {
                        if (_manipulator is ParallelMove) _manipulator = null;
                        else _manipulator = new ParallelMove(_accessor.Selected as TransformNode, _camera, _manipulatorPolygon);
                    }
                }

                if (Engine.Tool.ImageButton(_scaleIcon, new Vector2F(17, 17), new Vector2F(0, 0), new Vector2F(1, 1), 0, new Color(36, 36, 36), IconColor))
                {
                    if (selectedTransformNode)
                    {
                        if (_manipulator is Scale) _manipulator = null;
                        else _manipulator = new Scale(_accessor.Selected as TransformNode, _camera);
                    }
                }

                if (Engine.Tool.ImageButton(_rotateIcon, new Vector2F(17, 17), new Vector2F(0, 0), new Vector2F(1, 1), 0, new Color(36, 36, 36), IconColor))
                {
                    if (selectedTransformNode)
                    {
                        if (_manipulator is Rotate) _manipulator = null;
                        else _manipulator = new Rotate(_accessor.Selected as TransformNode, _camera);
                    }
                }

                if (Engine.Tool.MenuItem("Find", "", false, _accessor.Selected is TransformNode))
                {
                    FindTransformNode(_accessor.Selected as TransformNode);
                }

                Engine.Tool.EndMainMenuBar();
            }

        }

        private Vector2F GetScreenPosition(Vector3F worldPosition)
        {
            var vector3 = _camera.ProjectionMatrix.Transform3D(_camera.ViewMatrix.Transform3D(worldPosition));
            return new Vector2F(vector3.X, vector3.Y);
        }

        bool MouseHit(Vector2F mousePosision, Vector2F[] rect)
        {

            var collider = new PolygonCollider();
            collider.Vertexes = rect;

            var mouseCollider = new CircleCollider();
            mouseCollider.Radius = 0f;
            mouseCollider.Position = mousePosision;

            return collider.GetIsCollidedWith(mouseCollider);
        }

        private bool IsInPreviewWindow(Vector2F position)
        {
            return
                -1f <= position.X
                && position.X <= 1f
                && -1f <= position.Y
                && position.Y <= 1f;
        }

        enum MouseControlState
        {
            none, CameraDrag, ControlManipulator
        }
    }
}
