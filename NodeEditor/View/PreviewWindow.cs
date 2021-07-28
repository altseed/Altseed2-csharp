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
        private TransformNodeManipulator _manipulator;
        private MouseControlState _MouseControlState;
        private Vector2F _StartPoint;

        private Vector2I _latestWindowSize = Engine.WindowSize;

        public PreviewWindow(IEditorPropertyAccessor accessor, PreviewViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;

            _viewModel.UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM));

            _subscription = accessor.OnSelectedNodeChanged.Subscribe(_ => ChangeManipulatee(accessor.Selected as TransformNode));

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 64);
            

            var texture = Texture2D.Load(@"TestData/IO/AltseedPink.png");
            

            var sprite = new SpriteNode();
            sprite.Texture = texture;
            sprite.ZOrder = 5;

            Vector2F rectSize = texture.Size;
            var parent = new AnchorTransformerNode();
            parent.Position = Engine.WindowSize / 2;
            parent.Size = rectSize;
            parent.AnchorMode = AnchorMode.Fill;
            Engine.AddNode(sprite);
            sprite.AddChildNode(parent);

            var sprite2 = new SpriteNode();
            sprite2.Texture = texture;
            sprite2.Color = new Color(255, 0, 0, 200);
            sprite2.ZOrder = 10;

            var child = new AnchorTransformerNode();
            child.Position = rectSize / 2;
            child.Pivot = new Vector2F(0.5f, 0.5f);
            child.AnchorMin = new Vector2F(0.0f, 0.0f);
            child.AnchorMax = new Vector2F(0.5f, 1f);
            child.HorizontalAlignment = HorizontalAlignment.Left;
            child.VerticalAlignment = VerticalAlignment.Center;
            child.Size = sprite2.ContentSize;
            child.AnchorMode = AnchorMode.KeepAspect;
            sprite.AddChildNode(sprite2);
            sprite2.AddChildNode(child);

            var text = new TextNode();
            text.Font = font;
            text.FontSize = 20;
            text.Color = new Color(0, 0, 0);
            text.Text = "あいうえお";
            text.ZOrder = 15;

            var childText = new AnchorTransformerNode();
            childText.Pivot = new Vector2F(0.5f, 0.5f);
            childText.AnchorMin = new Vector2F(0.5f, 0.5f);
            childText.AnchorMax = new Vector2F(0.5f, 0.5f);
            childText.Size = text.ContentSize;
            //childText.HorizontalAlignment = HorizontalAlignment.Center;
            //childText.VerticalAlignment = VerticalAlignment.Center;
            childText.AnchorMode = AnchorMode.ContentSize;
            sprite2.AddChildNode(text);
            text.AddChildNode(childText);

            var trip = new TriangleNode();
            trip.Point2 = new Vector2F(0, 50);
            trip.Point3 = new Vector2F(100, 0);
            var tric = new TriangleNode();
            tric.Point3 = new Vector2F(0, 50);
            tric.Point2 = new Vector2F(200, 0);
            tric.Color = new Color(0, 250, 0);
            trip.AddChildNode(tric);
            Engine.AddNode(trip);
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
            
            _manipulator?.Update(mousePosition);
            _manipulator?.Draw();

            RenderTransformNodeManipulatorMenu();

            MouseInput(mousePosition);

            if(Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold)
            {
                Engine._DefaultCamera.ViewMatrix = Matrix44F.GetTranslation2D(new Vector2F(0, 5)) * Engine._DefaultCamera.ViewMatrix;
            }

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
            if (_manipulator?.Input(MousePosition) ?? false)
            {
                _MouseControlState = MouseControlState.ControlManipulator;
                return;
            }

            if (_MouseControlState == MouseControlState.ControlManipulator) _MouseControlState = MouseControlState.none;

            foreach (var node in Engine.GetNodes())
            {
                if (!(node is TransformNode)) continue;

                var transformNode = node as TransformNode;

                var mat = transformNode.GetAncestorSpecificNode<TransformNode>()?.InheritedTransform ?? Matrix44F.Identity;
                var pos = mat.Transform3D(new Vector3F(transformNode.Position.X, transformNode.Position.Y, 0));
                
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
                    _accessor.Selected = node;
                    return;
                }
            }

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

            //debug用
            if (Engine.Tool.BeginMainMenuBar())
            {
                Engine.Tool.Text(_MouseControlState.ToString());
                Engine.Tool.EndMainMenuBar();
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

        private void RenderTransformNodeManipulatorMenu()
        {
            if (Engine.Tool.BeginMainMenuBar())
            {
                if (Engine.Tool.MenuItem("VisibleTransformNodeInfo", "", Engine.Config.VisibleTransformInfo, _accessor.Selected is TransformNode))
                {
                    Engine.Config.VisibleTransformInfo = !Engine.Config.VisibleTransformInfo;
                }
                if (Engine.Tool.MenuItem("ParallelMove", "", _manipulator is ParallelMove, _accessor.Selected is TransformNode))
                {
                    if (_manipulator is ParallelMove) _manipulator = null;
                    else _manipulator = new ParallelMove(_accessor.Selected as TransformNode);
                }
                if (Engine.Tool.MenuItem("Scale", "", _manipulator is Scale, _accessor.Selected is TransformNode))
                {
                    if (_manipulator is Scale) _manipulator = null;
                    else _manipulator = new Scale(_accessor.Selected as TransformNode);
                }
                if(Engine.Tool.MenuItem("Find", "", false, _accessor.Selected is TransformNode))
                {
                    FindTransformNode(_accessor.Selected as TransformNode);
                }
                Engine.Tool.EndMainMenuBar();
            }

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
