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

        private Vector2I _latestWindowSize = Engine.WindowSize;

        public PreviewWindow(IEditorPropertyAccessor accessor, PreviewViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;

            _viewModel.UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM));

            _subscription = accessor.OnSelectedNodeChanged.Subscribe(_ => ChangeManipulatee(accessor.Selected as TransformNode));
        }

        private void ChangeManipulatee(TransformNode target)
        {
            _manipulator?.SetManipulatee(target);
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


            if (Engine.Tool.BeginMainMenuBar())
            {   
                if (Engine.Tool.BeginMenu("PreviewWindow", true))
                {
                    if(Engine.Tool.MenuItem("VisibleTransformNodeInfo", "", Engine.Config.VisibleTransformInfo, true))
                    {
                        Engine.Config.VisibleTransformInfo = !Engine.Config.VisibleTransformInfo;
                    }
                    if(Engine.Tool.MenuItem("Parallel Move", "", _manipulator is ParallelMove, _accessor.Selected is TransformNode))
                    {
                        if (_manipulator is ParallelMove) _manipulator = null;
                        else _manipulator = new ParallelMove(_accessor.Selected as TransformNode);
                    }
                    if(Engine.Tool.MenuItem("Scale", "", _manipulator is Scale, _accessor.Selected is TransformNode))
                    {
                        if (_manipulator is Scale) _manipulator = null;
                        else _manipulator = new Scale(_accessor.Selected as TransformNode);
                    }
                    Engine.Tool.EndMenu();
                }
                Engine.Tool.EndMainMenuBar();
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
    }
}
