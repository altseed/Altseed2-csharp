using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class PreviewWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly PreviewViewModel _viewModel;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Main");

        private Vector2I _latestWindowSize = Engine.WindowSize;

        public PreviewWindow(IEditorPropertyAccessor accessor, PreviewViewModel viewModel)
        {
            _accessor = accessor;
            _viewModel = viewModel;

            _viewModel.UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM));
        }

        public void Render()
        {
            Engine.Tool.PushStyleVar(ToolStyleVar.WindowPadding, new Vector2F());

            _pane.Render(() =>
            {
                AdjustWindowSize();
                _viewModel.IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocusedFlags.None);

                _viewModel.MousePosition = Engine.Mouse.Position + _accessor.EditorWindowPosition - (Engine.Tool.GetWindowContentRegionMin() + Engine.Tool.GetWindowPos());

                Engine.Tool.Image(_viewModel.Main, _viewModel.Main.Size, default,
                    new Vector2F(1, 1), new Color(255, 255, 255), new Color());
                UpdateMenu();
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
    }
}
