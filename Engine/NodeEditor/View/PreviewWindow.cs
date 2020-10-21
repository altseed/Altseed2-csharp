namespace Altseed2.NodeEditor.View
{
    internal sealed class PreviewWindow
    {
        private readonly IEditorPropertyAccessor _accessor;
        private readonly NodeEditorPane _pane = new NodeEditorPane("Main");

        private Vector2I _latestWindowSize = Engine.WindowSize;
        // RenderTextureの管理はViewModelの責務かも
        private RenderTexture _main;

        public PreviewWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;

            UpdateRenderTexture(true,
                RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM));
        }

        public bool IsMainWindowFocus { get; private set; }
        public Vector2F MousePosition { get; private set; }

        public void Render()
        {
            AdjustWindowSize();

            var size = _latestWindowSize - new Vector2F(600, _accessor.MenuHeight);
            var pos = new Vector2F(300, _accessor.MenuHeight);

            Engine.Tool.PushStyleVarVector2F(ToolStyleVar.WindowPadding, default);
            Engine.Tool.PushStyleVarFloat(ToolStyleVar.WindowRounding, 0);

            _pane.Render(pos, size, () =>
            {
                IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocused.None);
                MousePosition = Engine.Mouse.Position - Engine.Tool.GetWindowPos();
                Engine.Tool.Image(_main, _main.Size, default, new Vector2F(1, 1), new Color(255, 255, 255), new Color());
            });

            Engine.Tool.PopStyleVar(2);
        }

        private void AdjustWindowSize()
        {
            if (_latestWindowSize != Engine.WindowSize)
            {
                Vector2I texSize = Engine.WindowSize - new Vector2I(600, (int) _accessor.MenuHeight);

                UpdateRenderTexture(texSize.X > 0 && texSize.Y > 0,
                    RenderTexture.Create(texSize, TextureFormat.R8G8B8A8_UNORM));

                _latestWindowSize = Engine.WindowSize;
            }
        }

        private void UpdateRenderTexture(bool condition, RenderTexture renderTexture)
        {
            if (condition)
            {
                _main = renderTexture;
            }

            Engine._DefaultCamera.TargetTexture = _main;
        }
    }
}
