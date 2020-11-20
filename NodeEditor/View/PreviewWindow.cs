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
            AdjustWindowSize();

            var size = _latestWindowSize - new Vector2F(600, _accessor.MenuHeight);
            var pos = new Vector2F(300, _accessor.MenuHeight);

            Engine.Tool.PushStyleVar(ToolStyleVar.WindowPadding, new Vector2F());
            Engine.Tool.PushStyleVar(ToolStyleVar.WindowRounding, 0);

            _pane.Render(pos, size, () =>
            {
                _viewModel.IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocusedFlags.None);
                _viewModel.MousePosition = Engine.Mouse.Position - Engine.Tool.GetWindowPos();
                Engine.Tool.Image(_viewModel.Main, _viewModel.Main.Size, default,
                    new Vector2F(1, 1), new Color(255, 255, 255), new Color());
            });

            Engine.Tool.PopStyleVar(2);
        }

        private void AdjustWindowSize()
        {
            if (_latestWindowSize != Engine.WindowSize)
            {
                Vector2I texSize = Engine.WindowSize - new Vector2I(600, (int) _accessor.MenuHeight);

                _viewModel.UpdateRenderTexture(texSize.X > 0 && texSize.Y > 0,
                    RenderTexture.Create(texSize, TextureFormat.R8G8B8A8_UNORM));

                _latestWindowSize = Engine.WindowSize;
            }
        }
    }
}
