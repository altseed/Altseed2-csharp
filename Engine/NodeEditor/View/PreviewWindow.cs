namespace Altseed2.NodeEditor.View
{
    class PreviewWindow
    {
        private readonly IEditorPropertyAccessor _accessor;

        private Vector2I _windowSize = Engine.WindowSize;
        private RenderTexture _main;

        public PreviewWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;

            _main = RenderTexture.Create(Engine.WindowSize - new Vector2I(600, 18), TextureFormat.R8G8B8A8_UNORM);
            Engine._DefaultCamera.TargetTexture = _main;
        }

        public bool IsMainWindowFocus { get; private set; }
        public Vector2F MousePosition { get; private set; }

        public void UpdateMainWindow()
        {
            if (_windowSize != Engine.WindowSize)
            {
                Vector2I texSize = Engine.WindowSize - new Vector2I(600, (int)_accessor.MenuHeight);
                if (texSize.X > 0 && texSize.Y > 0)
                    _main = RenderTexture.Create(texSize, TextureFormat.R8G8B8A8_UNORM);
                Engine._DefaultCamera.TargetTexture = _main;
                _windowSize = Engine.WindowSize;
            }

            var size = _windowSize - new Vector2F(600, _accessor.MenuHeight);
            var pos = new Vector2F(300, _accessor.MenuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);
            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoTitleBar | ToolWindowFlags.NoScrollWithMouse;

            Engine.Tool.PushStyleVarVector2F(ToolStyleVar.WindowPadding, default);
            Engine.Tool.PushStyleVarFloat(ToolStyleVar.WindowRounding, 0);
            if (Engine.Tool.Begin("Main", flags))
            {
                IsMainWindowFocus = Engine.Tool.IsWindowFocused(ToolFocused.None);
                MousePosition = Engine.Mouse.Position - Engine.Tool.GetWindowPos();
                Engine.Tool.Image(_main, _main.Size, default, new Vector2F(1, 1), new Color(255, 255, 255), new Color());
                Engine.Tool.End();
            }
            Engine.Tool.PopStyleVar(2);
        }
    }
}
