using Altseed2.NodeEditor.ViewModel;
using System.Reactive;
using System.Reactive.Subjects;
using System;

namespace Altseed2.NodeEditor.View
{
    internal sealed class PreviewWindow : IDisposable
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly PreviewViewModel _viewModel;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Main");

        private readonly IDisposable _subscription;
        private MouseControlState _MouseControlState;
        private Vector2F _StartPoint;

        private Vector2I _latestWindowSize = Engine.WindowSize;

        public PreviewWindow(IEditorPropertyAccessor accessor, PreviewViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;

            _viewModel.UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM));
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

            _pane.Render(() =>
            {
                AdjustWindowSize();
                _viewModel.IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocusedFlags.None);

                _viewModel.MousePosition = GetMousePositionInPreiewWindow();

                Engine.Tool.Image(_viewModel.Main, _viewModel.Main.Size, default,
                    new Vector2F(1, 1), new Color(255, 255, 255), new Color());
                
            }, ToolWindowFlags.NoScrollbar);

            Engine.Tool.PopStyleVar(1);
        }

        private void MouseInput(Vector2F MousePosition)
        { 
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
                        foreach(var childNode in target.Children)
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
                
                foreach(var child in node.Children)
                {
                    CheckMouseClick(child);
                }
            }

            foreach (var node in Engine.GetNodes()) CheckMouseClick(node);

            if(IsInPreviewWindow(MousePosition) && _MouseControlState == MouseControlState.none && Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Push)
            {
                _StartPoint = MousePosition;
                _MouseControlState = MouseControlState.CameraDrag;
                
                //ToDo カーソルのテクスチャをドラッグしてるかんじに変更できるように
                Engine.Mouse.CursorMode = CursorMode.Normal;
            }
            
            if(_MouseControlState == MouseControlState.CameraDrag && Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Release)
            {
                _MouseControlState = MouseControlState.none;
                Engine.Mouse.CursorMode = CursorMode.Normal;
            }

            if(_MouseControlState == MouseControlState.CameraDrag)
            {
                const float error = 0.0001f;

                var vec = (_StartPoint - MousePosition);

                if (vec.Length > error)
                {
                    Engine._DefaultCamera.ViewMatrix = Matrix44F.GetTranslation2D(vec * new Vector2F(-1, 1) * 300f) * Engine._DefaultCamera.ViewMatrix;
                }
                _StartPoint = MousePosition;
            }

            if (IsInPreviewWindow(MousePosition))
            {
                var wheelState = Engine.Mouse.Wheel;
                Engine._DefaultCamera.ViewMatrix = Matrix44F.GetScale2D(new Vector2F(1, 1) * (1 + wheelState * 0.25f)) *  Engine._DefaultCamera.ViewMatrix;
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

            Engine._DefaultCamera.ViewMatrix = Matrix44F.GetTranslation2D(- pos2d);
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

        private Vector2F GetScreenPosition(Vector3F worldPosition)
        {
            var vector3 = Engine._DefaultCamera.ProjectionMatrix.Transform3D(Engine._DefaultCamera.ViewMatrix.Transform3D(worldPosition));
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
